using ControlDocumentoFactura.Dominio.Models.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Dominio.Models {
	public class ReservaTest {
		[Fact]
		public void Reserva_CheckPropertiesValid() {

			string codReservaTest = "123456";
			String estadoReservaTest = "C";
			Guid reservaId = Guid.NewGuid();
			var objReserva = new Reserva(reservaId,codReservaTest,new Guid(),new Guid(),new DateTime().ToString(), new decimal(0.0),estadoReservaTest);
			
			Assert.NotEqual(Guid.Empty,objReserva.Id);
			Assert.Equal(Guid.Empty,objReserva.ClienteId);
			Assert.Equal(Guid.Empty,objReserva.VueloId);
			Assert.Equal(codReservaTest,objReserva.ReservationNumber);
			Assert.NotNull(objReserva.Fecha);
			Assert.Equal(new decimal(0.0),( decimal )objReserva.Deuda);
			Assert.Equal(new decimal(0.0),( decimal )objReserva.Monto);
			Assert.Equal(estadoReservaTest,objReserva.ReservationStatus);
			objReserva.ActualizarReservaPagada();
			Assert.Equal("pagado", objReserva.ReservationStatus);


		}
		[Fact]
		public void TestConstructor_IsPrivate() {
			var reserva = ( Reserva )Activator.CreateInstance(typeof(Reserva),true);
			Assert.Equal(Guid.Empty,reserva.Id);
			Assert.Equal(Guid.Empty,reserva.ClienteId);
			Assert.Equal(Guid.Empty,reserva.VueloId);
			//Assert.Null(reserva.CodReserva);
			Assert.Equal(DateTime.MinValue,reserva.Fecha);
		}
	}
}
