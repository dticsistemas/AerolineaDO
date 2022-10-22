using ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Clientes.CrearCliente;
using ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Vuelos.CrearVuelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Aplicacion.UsesCases.Commands
{
	public class CrearVueloCommand_Test
	{
		[Fact]
		public void CrearVueloCommand_DataValid()
		{

			var id = new Guid();
			var flight_program_id = 10;
			var source_airport_code = "MIA";
			var destiny_airport_code = "LPZ";
			var status = "open";
			var information = "info";
			var command = new CrearVueloCommand(id, flight_program_id, source_airport_code, destiny_airport_code, status, information);
			Assert.Equal(flight_program_id, command.Flight_program_id);
			Assert.Equal(information, command.Information);
			Assert.Equal(destiny_airport_code, command.Destiny_airport_code);
			Assert.Equal(source_airport_code, command.Source_airport_code);
			Assert.Equal(status, command.Status);
			Assert.Equal(Guid.Empty, command.Id);

		}


		[Fact]
		public void TestConstructor_IsPrivate()
		{
			var command = (CrearVueloCommand)Activator.CreateInstance(typeof(CrearVueloCommand), true);
			Assert.Null(command.Information);
			Assert.Null(command.Destiny_airport_code);
			Assert.Null(command.Source_airport_code);
			Assert.Null(command.Status);
			Assert.Equal(0, command.Flight_program_id);
			Assert.Equal(Guid.Empty, command.Id);
		}
	}
}
