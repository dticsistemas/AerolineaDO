using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Clientes.BuscarClientePorId;
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Pagos.BuscarFacturaPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Aplicacion.UsesCases.Queries
{
	public class BuscarClientePorIdQuery_Test
	{
		[Fact]
		public void BuscarClientePorIdQuery_DataValid()
		{
			var idClienteTest = new Guid();
			var query = new BuscarClientePorIdQuery(idClienteTest);

			Assert.Equal(idClienteTest, query.Id);
		}

		[Fact]
		public void TestConstructor_IsPrivate()
		{
			var query = (BuscarClientePorIdQuery)Activator.CreateInstance(typeof(BuscarClientePorIdQuery), true);
			Assert.Equal(Guid.Empty, query.Id);
		}
	}
}
