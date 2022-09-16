using MediatR;
using Microsoft.Extensions.Logging;
using ControlDocumentoFactura.Aplicacion.Services.Reservas;
using ControlDocumentoFactura.Dominio.Factories.Facturas;
using ControlDocumentoFactura.Dominio.Models.Facturas;
using ControlDocumentoFactura.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ControlDocumentoFactura.Dominio.Repositories.Facturas;

namespace ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Facturas.CrearFactura {
	public class CrearFacturaHandler:IRequestHandler<CrearFacturaCommand,Guid> {
		private readonly IFacturaRepository _facturaRepository;
		private readonly ILogger<CrearFacturaHandler> _logger;
		private readonly IFacturaService _facturaService;
		private readonly IFacturaFactory _facturaFactory;
		private readonly IUnitOfWork _unitOfWork;

		public CrearFacturaHandler(IFacturaRepository facturaRepository,ILogger<CrearFacturaHandler> logger,
			IFacturaService facturaService,IFacturaFactory facturaFactory,IUnitOfWork unitOfWork) {
			_facturaRepository = facturaRepository;
			_logger = logger;
			_facturaService = facturaService;
			_facturaFactory = facturaFactory;
			_unitOfWork = unitOfWork;
		}
		public async Task<Guid> Handle(CrearFacturaCommand request,CancellationToken cancellationToken) {
			try {
				string nroFactura = await _facturaService.GenerarNroFacturaAsync();
				Factura objFactura = _facturaFactory.Create(nroFactura);

				objFactura.CrearFactura(request.Monto,request.Importe,request.Lugar,request.NitBeneficiario,request.RazonSocialBeneficiario,request.ClienteId,request.VueloId,request.ReservaId);
				objFactura.EntregaFactura();
				await _facturaRepository.CreateAsync(objFactura);
				await _unitOfWork.Commit();
				return objFactura.Id;

			}
			catch( Exception ex ) {
				_logger.LogError(ex,"Error al crear Factura");
			}
			return Guid.Empty;
		}

	}
}
