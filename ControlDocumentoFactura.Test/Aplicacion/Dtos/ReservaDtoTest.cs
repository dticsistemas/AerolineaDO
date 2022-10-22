using ControlDocumentoFactura.Aplicacion.Dtos.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Aplicacion.Dtos
{
	public class ReservaDtoTest
	{
		[Fact]
		public void ReservaDto_CheckPropertiesValid()
		{


			var idReservaTest = new Guid();
			var idVueloTest = new Guid();
			var idClienteTest = new Guid();
			decimal montoTest = new(720.0);
			decimal deudaTest = new(720.0);
			DateTime fechaTest = DateTime.Now;
			var codReservaTest = "ABC12";
			var estadoReservaTest = "P";
			var tipoReservaTest = "R";

			var objReserva = new ReservaDto();

			Assert.Equal(Guid.Empty, objReserva.Id);
			Assert.Equal(Guid.Empty, objReserva.ClienteId);
			Assert.Equal(Guid.Empty, objReserva.VueloId);
			Assert.Equal(new decimal(0.0), objReserva.Monto);
			Assert.Equal(new decimal(0.0), objReserva.Deuda);
			Assert.Equal(DateTime.MinValue, objReserva.Fecha);
			Assert.Null(objReserva.ReservationNumber);
			Assert.Null(objReserva.ReservationStatus);
			Assert.Null(objReserva.TipoReserva);

			objReserva.Id = idReservaTest;
			objReserva.ClienteId = idClienteTest;
			objReserva.VueloId = idVueloTest;
			objReserva.Monto = montoTest;
			objReserva.Deuda = deudaTest;
			objReserva.Fecha = fechaTest;
			objReserva.ReservationNumber = codReservaTest;
			objReserva.ReservationStatus = estadoReservaTest;
			objReserva.TipoReserva = tipoReservaTest;

			Assert.Equal(idReservaTest, objReserva.Id);
			Assert.Equal(idClienteTest, objReserva.ClienteId);
			Assert.Equal(idVueloTest, objReserva.VueloId);
			Assert.Equal(montoTest, objReserva.Monto);
			Assert.Equal(deudaTest, objReserva.Deuda);
			Assert.Equal(fechaTest, objReserva.Fecha);
			Assert.Equal(codReservaTest, objReserva.ReservationNumber);
			Assert.Equal(estadoReservaTest, objReserva.ReservationStatus);
			Assert.Equal(tipoReservaTest, objReserva.TipoReserva);

		}
	}
}
