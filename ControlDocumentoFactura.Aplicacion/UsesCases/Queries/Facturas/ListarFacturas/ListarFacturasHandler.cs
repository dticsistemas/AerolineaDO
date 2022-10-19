using ControlDocumentoFactura.Aplicacion.Dtos.Clientes;
using ControlDocumentoFactura.Aplicacion.Dtos.Pagos;
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Clientes.ListarPasajeros;
using ControlDocumentoFactura.Dominio.Repositories.Clientes;
using ControlDocumentoFactura.Dominio.Repositories.Facturas;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Facturas.ListarFacturas
{
	public class ListarFacturasHandler : IRequestHandler<ListarFacturasQuery, ICollection<FacturaDto>>
	{
		private readonly IFacturaRepository _facturaRepository;
		private readonly ILogger<ListarFacturasQuery> _logger;
		public ListarFacturasHandler(IFacturaRepository facturaRepository, ILogger<ListarFacturasQuery> logger)
		{
			_facturaRepository = facturaRepository;
			_logger = logger;
		}

		public async Task<ICollection<FacturaDto>> Handle(ListarFacturasQuery request, CancellationToken cancellationToken)
		{

			var facturaList = await _facturaRepository.GetAll();

			var result = new List<FacturaDto>();

			foreach (var objFactura in facturaList)
			{
				var facturaDto = new FacturaDto()
				{
					Id = objFactura.Id,
					Monto = objFactura.Monto,
					Importe = objFactura.Importe,
					Fecha = objFactura.Fecha,
					NroFactura = objFactura.NroFactura,
					Lugar = objFactura.Lugar,
					NitBeneficiario = objFactura.NitBeneficiario,
					RazonSocialBeneficiario = objFactura.RazonSocialBeneficiario,
					Estado = objFactura.Estado,
					TipoNit = objFactura.TipoNit,
					ReservaId = objFactura.ReservaId,
					ClienteId = objFactura.ClienteId,
					VueloId = objFactura.VueloId,
					ConfiguracionFacturaId = objFactura.ConfiguracionFacturaId

	};

				result.Add(facturaDto);
			}

			return result;
		}
	}
}
