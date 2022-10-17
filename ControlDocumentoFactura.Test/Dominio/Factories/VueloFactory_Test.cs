using ControlDocumentoFactura.Dominio.Factories.Facturas;
using ControlDocumentoFactura.Dominio.Factories.Vuelos;
using ControlDocumentoFactura.Dominio.Models.Facturas;
using ControlDocumentoFactura.Dominio.Models.Vuelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Dominio.Factories
{
	public class VueloFactory_Test
	{
		[Fact]
		public void VueloFactory_CheckPropertiesValid()
		{
			VueloFactory _vueloFactory = new VueloFactory();
			Guid idVuelo = new Guid();
			int flight_program_id = 102;
			String source_airport_code = "SCZ";
			String destiny_airport_code = "LPZ";
			String status = "open";
			String information = "Vuelo SCz-LPZ";
			Vuelo objVuelo = _vueloFactory.Create(idVuelo, flight_program_id,source_airport_code,destiny_airport_code, status,information);

			Assert.Equal(idVuelo, objVuelo.Id);
			Assert.Equal(flight_program_id, objVuelo.Flight_program_id);
			Assert.Equal(source_airport_code, objVuelo.Source_airport_code);
			Assert.Equal(destiny_airport_code, objVuelo.Destiny_airport_code);
			Assert.Equal(status, objVuelo.Status);
			Assert.Equal(information, objVuelo.Information);





		}
	}
}
