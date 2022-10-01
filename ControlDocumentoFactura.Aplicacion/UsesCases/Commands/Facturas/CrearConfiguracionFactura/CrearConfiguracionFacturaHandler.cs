using ControlDocumentoFactura.Aplicacion.Services.Reservas;
using ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Facturas.CrearFactura;
using ControlDocumentoFactura.Dominio.Factories.Facturas;
using ControlDocumentoFactura.Dominio.Models.Facturas;
using ControlDocumentoFactura.Dominio.Repositories.Facturas;
using ControlDocumentoFactura.Dominio.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Facturas.CrearConfiguracionFactura
{
	public class CrearConfiguracionFacturaHandler : IRequestHandler<CrearConfiguracionFacturaCommand, Guid>
	{
		private readonly IConfiguracionFacturaRepository _configuracionFacturaRepository;
		private readonly ILogger<CrearConfiguracionFacturaHandler> _logger;
		private readonly IConfiguracionFacturaFactory _configuracionFacturaFactory;
		private readonly IUnitOfWork _unitOfWork;

		public CrearConfiguracionFacturaHandler(IConfiguracionFacturaRepository configuracionFacturaRepository, ILogger<CrearConfiguracionFacturaHandler> logger,
			IConfiguracionFacturaFactory configuracionFacturaFactory, IUnitOfWork unitOfWork)
		{
			_configuracionFacturaRepository = configuracionFacturaRepository;
			_logger = logger;
			_configuracionFacturaFactory = configuracionFacturaFactory;
			_unitOfWork = unitOfWork;
		}
		public async Task<Guid> Handle(CrearConfiguracionFacturaCommand request, CancellationToken cancellationToken)
		{
			try
			{
				ConfiguracionFactura objConfigFactura = _configuracionFacturaFactory.Create();

				objConfigFactura.CrearConfiguracionFactura(request.NitProveedor, request.RazonSocialProveedor);
				//--Update Esatdo de los anteriore Inactivo

				await _configuracionFacturaRepository.CreateAsync(objConfigFactura);
				await _unitOfWork.Commit();
				return objConfigFactura.Id;

			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error al crear Configuracion Factura");
			}
			return Guid.Empty;
		}

	}
}
