using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Facturas.ListarFacturas;
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Reservas.ListarReservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Aplicacion.UsesCases.Queries
{
	public class ListarReservasQuery_Test
	{
		[Fact]
		public void ListarReservasQuery_DataValid()
		{
			var query = new ListarReservasQuery();

			Assert.NotNull(query);
		}
	}
}
