using ControlDocumentoFactura.Aplicacion.Dtos.Pagos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Facturas.SearchFacturasClienteQuery
{
	public class SearchFacturasClienteQuery : IRequest<ICollection<FacturaDto>>
	{
		public Guid idClienteTest { get; set; }

		public SearchFacturasClienteQuery(Guid idClienteTest)
		{
			this.idClienteTest = idClienteTest;
		}

	}
}
