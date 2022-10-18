using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Clientes.BuscarClientePorId;
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Pagos.BuscarFacturaPorId;
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Reservas.BuscarReservaPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Aplicacion.UsesCases.Queries
{
	public class BuscarReservaPorIdQuery_Test
	{
		[Fact]
		public void BuscarReservaPorIdQuery_DataValid()
		{
			var idClienteTest = new Guid();
			var query = new BuscarReservaPorIdQuery(idClienteTest);

			Assert.Equal(idClienteTest, query.Id);
		}

		[Fact]
		public void TestConstructor_IsPrivate()
		{
			var query = (BuscarReservaPorIdQuery)Activator.CreateInstance(typeof(BuscarReservaPorIdQuery), true);
			Assert.Equal(Guid.Empty, query.Id);
		}
	}
}
