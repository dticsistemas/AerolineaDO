using ControlDocumentoFactura.Dominio.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Dominio.IntegrationEvents
{
	public class VueloCreado_Test
	{
		[Fact]
		public void VueloCreado_CheckPropertiesValid()
		{
			var idVueloTest = Guid.NewGuid();
			
			VueloCreado vuelo = new VueloCreado();
			vuelo.Id = idVueloTest;
			vuelo.Source_airport_code = "LPZ";
			vuelo.Destiny_airport_code = "MIA";
			vuelo.Status = "A";
			vuelo.Flight_program_id = 10;
			vuelo.Information = "info";
			Assert.Equal(idVueloTest,vuelo.Id);
			Assert.Equal("LPZ", vuelo.Source_airport_code);
			Assert.Equal("MIA", vuelo.Destiny_airport_code);
			Assert.Equal("A", vuelo.Status);
			Assert.Equal(10, vuelo.Flight_program_id);
			Assert.Equal("info", vuelo.Information);

		}
	}
}
