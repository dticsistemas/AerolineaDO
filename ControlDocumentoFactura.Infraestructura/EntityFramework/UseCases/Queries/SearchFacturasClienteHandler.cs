using ControlDocumentoFactura.Aplicacion.Dtos.Pagos;
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Facturas.SearchFacturasClienteQuery;
using ControlDocumentoFactura.Infraestructura.EntityFramework.Contexts;
using ControlDocumentoFactura.Infraestructura.EntityFramework.ReadModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Infraestructura.EntityFramework.UseCases.Queries
{
	public class SearchFacturasClienteHandler :
								IRequestHandler<SearchFacturasClienteQuery, ICollection<FacturaDto>>
	{
		private readonly DbSet<FacturaReadModel> _facturas;

		public SearchFacturasClienteHandler(ReadDbContext context)
		{
			_facturas = context.Factura;
		}

		public async Task<ICollection<FacturaDto>> Handle(SearchFacturasClienteQuery request, CancellationToken cancellationToken)
		{

			var facturaList = await _facturas
							.AsNoTracking()
							.Include(x => x.Cliente)
							.Include(x => x.Reserva)
							.Include(x => x.Vuelo)
							//.ThenInclude(x => x.Reserva)
							.Where(x => x.Cliente.Id.ToString().Contains(request.IdCliente))
							.ToListAsync();

			var result = new List<FacturaDto>();

			foreach (var objFactura in facturaList)
			{
				var facturaDto = new FacturaDto();

				facturaDto.Id = objFactura.Id;
				facturaDto.Monto = objFactura.Monto;
				facturaDto.Importe = objFactura.Importe;
				facturaDto.Fecha = objFactura.Fecha;
				facturaDto.NroFactura = objFactura.NroFactura;
				facturaDto.Lugar = objFactura.Lugar;
				facturaDto.NitProveedor = objFactura.NitProveedor;
				facturaDto.RazonSocialProveedor = objFactura.RazonSocialProveedor;
				facturaDto.NitBeneficiario = objFactura.NitBeneficiario;
				facturaDto.RazonSocialBeneficiario = objFactura.RazonSocialBeneficiario;
				facturaDto.NroAutorizacion = objFactura.NroAutorizacion;
				facturaDto.Estado = objFactura.Estado;
				facturaDto.ReservaId = objFactura.Reserva.Id;
				facturaDto.ClienteId = objFactura.Cliente.Id;
				facturaDto.VueloId = objFactura.Vuelo.Id;
				

				
				result.Add(facturaDto);
			}

			return result;
		}

		
	}
}
