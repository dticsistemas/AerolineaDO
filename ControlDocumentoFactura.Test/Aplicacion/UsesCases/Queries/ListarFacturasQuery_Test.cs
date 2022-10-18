using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Clientes.BuscarClientePorId;
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Facturas.ListarFacturas;
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Pagos.BuscarFacturaPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Aplicacion.UsesCases.Queries
{
	public class ListarFacturasQuery_Test
	{
		[Fact]
		public void ListarFacturasQuery_DataValid()
		{			
			var query = new ListarFacturasQuery();

			Assert.NotNull( query);
		}

	}
}
