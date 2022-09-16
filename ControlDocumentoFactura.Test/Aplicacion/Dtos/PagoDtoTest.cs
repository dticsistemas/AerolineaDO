using ControlDocumentoFactura.Aplicacion.Dtos.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Aplicacion.Dtos {
	public class PagoDtoTest {
		[Fact]
		public void PagoDto_CheckPropertiesValid() {
			var idPagoTest = new Guid();
			var idReservaTest = new Guid();
			decimal montoTest = new(4.0);
			DateTime fechaTest = DateTime.Now;
			var codComprobanteTest = "2022-05-15";

			var objPago = new PagoDto();

			Assert.Equal(Guid.Empty,objPago.Id);
			Assert.Equal(Guid.Empty,objPago.ReservaId);
			Assert.Equal(new decimal(0.0),objPago.Monto);
			Assert.Equal(DateTime.MinValue,objPago.Fecha);
			Assert.Null(objPago.CodComprobante);

			objPago.Id = idPagoTest;
			objPago.ReservaId = idReservaTest;
			objPago.Monto = montoTest;
			objPago.Fecha = fechaTest;
			objPago.CodComprobante = codComprobanteTest;

			Assert.Equal(idPagoTest,objPago.Id);
			Assert.Equal(idReservaTest,objPago.ReservaId);
			Assert.Equal(montoTest,objPago.Monto);
			Assert.Equal(fechaTest,objPago.Fecha);
			Assert.Equal(codComprobanteTest,objPago.CodComprobante);

		}
	}

}
