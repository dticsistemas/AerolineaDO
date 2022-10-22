using ControlDocumentoFactura.Dominio.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Dominio.IntegrationEvents
{
	public class ReservaPagado_Test
	{
		[Fact]
		public void ReservaPagado_CheckPropertiesValid()
		{

			ReservaPagado reserva = new ReservaPagado();
			reserva.Id = new Guid();
			reserva.ReservaId = new Guid();
			reserva.TransactionNumber = "1234";
			reserva.Amount = new decimal(10);
			Assert.NotNull(reserva.Id);
			Assert.NotNull(reserva.ReservaId);
			Assert.Equal("1234", reserva.TransactionNumber);
			Assert.Equal(new decimal(10), reserva.Amount);
		}
	}
}
