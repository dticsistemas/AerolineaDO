using ControlDocumentoFactura.Dominio.Events.Facturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Dominio.Events {
	public class FacturaCreadoEvent_Test {
		[Fact]
		public void FacturaCreadoEvent_CheckPropertiesValid() {
			decimal montoTest = new(40);
			Guid facturaIdTest = new();
			Guid clienteIdTest = new();
			Guid reservaIdTest = new();

			FacturaCreadoEvent objFacturaCreadoEvent = new FacturaCreadoEvent(montoTest,facturaIdTest,clienteIdTest,reservaIdTest);
			Assert.NotNull(objFacturaCreadoEvent);
			Assert.NotEqual(Guid.Empty,objFacturaCreadoEvent.Id);
			Assert.Equal(facturaIdTest,objFacturaCreadoEvent.FacturaId);
			Assert.Equal(reservaIdTest,objFacturaCreadoEvent.ReservaId);
			Assert.Equal(clienteIdTest,objFacturaCreadoEvent.ClienteId);
			Assert.Equal(montoTest,objFacturaCreadoEvent.Monto);
		}
	}
}
