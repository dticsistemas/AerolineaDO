using ControlDocumentoFactura.Aplicacion.Dtos.Vuelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Aplicacion.Dtos
{
	public class VueloDtoTest
	{
		[Fact]
		public void VueloDto_CheckPropertiesValid()
		{
			var idVueloTest = new Guid();
			String Source_airport_code = "MIA";
			String Destiny_airport_code = "LPZ";
			String Status = "open";
			int Flight_program_id = 10;
			string Information = "info";

			var objVuelo = new VueloDto();

			Assert.Equal(Guid.Empty, objVuelo.Id);

			objVuelo.Id = idVueloTest;
			objVuelo.Source_airport_code = Source_airport_code;
			objVuelo.Destiny_airport_code = Destiny_airport_code;
			objVuelo.Status = Status;
			objVuelo.Flight_program_id = Flight_program_id;
			objVuelo.Information = Information;

			Assert.Equal(idVueloTest, objVuelo.Id);
			Assert.Equal(Source_airport_code, objVuelo.Source_airport_code);
			Assert.Equal(Destiny_airport_code, objVuelo.Destiny_airport_code);
			Assert.Equal(Status, objVuelo.Status);
			Assert.Equal(Flight_program_id, objVuelo.Flight_program_id);
			Assert.Equal(Information, objVuelo.Information);



		}
	}
}
