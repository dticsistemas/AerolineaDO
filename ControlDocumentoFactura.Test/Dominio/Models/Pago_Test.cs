using ControlDocumentoFactura.Dominio.Models.Facturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Dominio.Models {
	public class Pago_Test {
		[Fact]
		public void Pago_CheckPropertiesValid() {

			var nitFacturaTest = "123456";
			var objPago = new Pago(nitFacturaTest);
			Assert.NotEqual(Guid.Empty,objPago.Id);
			Assert.Equal(nitFacturaTest,objPago.CodComprobante);
			Assert.Equal(Guid.Empty,objPago.ReservaId);
			Assert.Equal(DateTime.MinValue,objPago.Fecha);
			Assert.Equal(new decimal(0.0),( decimal )objPago.Monto);

		}
		[Fact]
		public void TestConstructor_IsPrivate() {
			var pago = new Pago();
			Assert.Equal(Guid.Empty,pago.Id);
			Assert.Equal(Guid.Empty,pago.ReservaId);
			Assert.Null(pago.CodComprobante);
			Assert.Equal(DateTime.MinValue,pago.Fecha);
		}
	}
}
