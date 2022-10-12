using ControlDocumentoFactura.Aplicacion.Dtos.Clientes;
using ControlDocumentoFactura.Aplicacion.Dtos.Pagos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Facturas.ListarFacturas
{
	public class ListarFacturasQuery : IRequest<ICollection<FacturaDto>>
	{

		public ListarFacturasQuery() { }

	}
}
