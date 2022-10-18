using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Clientes.BuscarClientePorId;
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Pagos.BuscarFacturaPorId;
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Vuelos.BuscarVueloPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Aplicacion.UsesCases.Queries
{
	public class BuscarVueloPorIdQuery_Test
	{
		[Fact]
		public void BuscarVueloPorIdQuery_DataValid()
		{
			var idClienteTest = new Guid();
			var query = new BuscarVueloPorIdQuery(idClienteTest);

			Assert.Equal(idClienteTest, query.Id);
		}

		[Fact]
		public void TestConstructor_IsPrivate()
		{
			var query = (BuscarVueloPorIdQuery)Activator.CreateInstance(typeof(BuscarVueloPorIdQuery), true);
			Assert.Equal(Guid.Empty, query.Id);
		}
	}
}
