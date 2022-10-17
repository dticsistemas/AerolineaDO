using ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Clientes.CrearCliente;
using ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Reservas;
using ControlDocumentoFactura.Dominio.Models.Clientes;
using ControlDocumentoFactura.Dominio.Models.Vuelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Aplicacion.UsesCases.Commands
{
	public class CrearReservaCommand_Test
	{
		[Fact]
		public void CrearReservaCommand_DataValid()
		{

			var id = new Guid();
			var reservationNumber = "123";
			var clienteId = new Guid();
			var vueloId = new Guid();
			var fecha = DateTime.Now.ToString();
			var monto = new Decimal(10);
			var reservationStatus = "456";
			var command = new CrearReservaCommand(id,reservationNumber,clienteId,vueloId,fecha,monto,reservationStatus);
			Assert.Equal(monto,command.Deuda);
			Assert.Equal(monto,command.Monto);
			Assert.Equal(reservationNumber, command.ReservationNumber);
			Assert.Equal(reservationStatus, command.ReservationStatus);
			Assert.Equal("R",command.TipoReserva);
			Assert.NotNull(command.Fecha);
			Assert.Equal(id, command.Id);
			Assert.Equal(clienteId, command.ClienteId);
			Assert.Equal(vueloId, command.VueloId);

		}


		[Fact]
		public void TestConstructor_IsPrivate()
		{
			var command = (CrearReservaCommand)Activator.CreateInstance(typeof(CrearReservaCommand), true);
			Assert.Equal(0,command.Deuda);
			Assert.Equal(0,command.Monto);
			Assert.Null(command.TipoReserva);
			Assert.Null(command.ReservationNumber);
			Assert.Null(command.ReservationStatus);
			Assert.Null(command.TipoReserva);
			Assert.Null(command.Fecha);
			Assert.Equal(Guid.Empty, command.Id);
			Assert.Equal(Guid.Empty, command.ClienteId);
			Assert.Equal(Guid.Empty, command.VueloId);
		}
	}
}
