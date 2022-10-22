using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Clientes.BuscarClientePorId;
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Facturas.SearchFacturasClienteQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Aplicacion.UsesCases.Queries
{
	public class SearchFacturasClienteQuery_Test
	{
		[Fact]
		public void SearchFacturasClienteQuery_DataValid()
		{
			var idClienteTest = new Guid();
			var query = new SearchFacturasClienteQuery(idClienteTest);

			Assert.Equal(idClienteTest, query.idClienteTest);
		}


	}
}
