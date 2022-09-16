using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Pagos.BuscarFacturaPorId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Aplicacion.UsesCases.Queries {
	public class BuscarFacturaPorIdQuery_Test {
		[Fact]
		public void BuscarFacturaPorIdQuery_DataValid() {
			var idFacturaTest = new Guid();
			var query = new BuscarFacturaPorIdQuery(idFacturaTest);

			Assert.Equal(idFacturaTest,query.Id);
		}

		[Fact]
		public void TestConstructor_IsPrivate() {
			var query = ( BuscarFacturaPorIdQuery )Activator.CreateInstance(typeof(BuscarFacturaPorIdQuery),true);
			Assert.Equal(Guid.Empty,query.Id);
		}

	}
}
