using ControlDocumentoFactura.Dominio.IntegrationEvents;
using ControlDocumentoFactura.Infraestructura.EntityFramework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Dominio.IntegrationEvents
{
	public class ReservaCreadoTest
	{
		[Fact]
		public void ReservaCreado_CheckPropertiesValid()
		{

			ReservaCreado reserva = new ReservaCreado();
			reserva.Id = new Guid();
			reserva.ReservationNumber = "123";
			reserva.ReservationStatus = "456";
			reserva.Monto = new decimal(10);
			reserva.Deuda = new decimal(10);
			reserva.Fecha = "Now";
			reserva.TipoReserva = "R";
			reserva.ClienteId = new Guid();
			reserva.VueloId = new Guid();
			Assert.Equal("123", reserva.ReservationNumber);
			Assert.Equal("456", reserva.ReservationStatus);
			Assert.Equal(new decimal(10), reserva.Monto);
			Assert.Equal(new decimal(10), reserva.Deuda);
			Assert.Equal("Now", reserva.Fecha);
			Assert.Equal("R", reserva.TipoReserva);
			Assert.NotNull(reserva.Id);
			Assert.NotNull(reserva.ClienteId);
			Assert.NotNull(reserva.VueloId);



		}
	}
}
