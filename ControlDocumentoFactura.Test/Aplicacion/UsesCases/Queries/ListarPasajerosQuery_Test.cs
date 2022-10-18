using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Clientes.ListarPasajeros;
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Facturas.ListarFacturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Aplicacion.UsesCases.Queries
{
	public class ListarPasajerosQuery_Test
	{
		[Fact]
		public void ListarPasajerosQuery_DataValid()
		{
			var query = new ListarPasajerosQuery();

			Assert.NotNull(query);
		}
	}
}
