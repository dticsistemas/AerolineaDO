using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Facturas.ListarFacturas;
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Vuelos.ListarVuelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Aplicacion.UsesCases.Queries
{
	public class ListarVuelosQuery_Test
	{
		[Fact]
		public void ListarVuelosQuery_DataValid()
		{
			var query = new ListarVuelosQuery();

			Assert.NotNull(query);
		}
	}
}
