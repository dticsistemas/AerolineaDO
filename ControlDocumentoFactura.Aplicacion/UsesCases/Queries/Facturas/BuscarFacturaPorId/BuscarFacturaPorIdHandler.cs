using MediatR;
using Microsoft.Extensions.Logging;
using ControlDocumentoFactura.Aplicacion.Dtos.Pagos;
using ControlDocumentoFactura.Aplicacion.Dtos.Reservas;
using ControlDocumentoFactura.Dominio.Models.Facturas;
using ControlDocumentoFactura.Dominio.Repositories.Facturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Pagos.BuscarFacturaPorId {
	public class BuscarFacturaPorIdHandler:IRequestHandler<BuscarFacturaPorIdQuery,FacturaDto> {
		private readonly IFacturaRepository _facturaRepository;
		private readonly ILogger<BuscarFacturaPorIdQuery> _logger;
		public BuscarFacturaPorIdHandler(IFacturaRepository reservaRepository,ILogger<BuscarFacturaPorIdQuery> logger) {
			_facturaRepository = reservaRepository;
			_logger = logger;
		}

		public async Task<FacturaDto> Handle(BuscarFacturaPorIdQuery request,CancellationToken cancellationToken) {
			FacturaDto result = null;
			try {
				Factura objFactura = await _facturaRepository.FindByIdAsync(request.Id);

				result = new FacturaDto() {
					Id = objFactura.Id,
					Monto = objFactura.Monto,
					Importe = objFactura.Importe,
					Fecha = objFactura.Fecha,
					NroFactura = objFactura.NroFactura,
					NitProveedor = objFactura.NitProveedor,
					NitBeneficiario = objFactura.NitBeneficiario,
					RazonSocialProveedor = objFactura.RazonSocialProveedor,
					RazonSocialBeneficiario = objFactura.RazonSocialBeneficiario,
					ReservaId = objFactura.ReservaId,
					ClienteId = objFactura.ClienteId,
					VueloId = objFactura.VueloId,
					Estado = objFactura.Estado


				};

			}
			catch( Exception ex ) {
				_logger.LogError(ex,"Error al obtener Factura Id");
			}

			return result;
		}
	}
}
