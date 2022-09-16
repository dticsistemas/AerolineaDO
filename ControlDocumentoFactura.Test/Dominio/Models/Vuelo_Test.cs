using ControlDocumentoFactura.Dominio.Models.Vuelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Dominio.Models {
	public class Vuelo_Test {
		[Fact]
		public void Vuelo_CheckPropertiesValid() {
			var idVueloTest = Guid.NewGuid();
			int cantidadVuelo = 85;
			string detalleVuelo = "SCZ-LPZ";
			decimal precioPasajeVuelo = new(40.0);

			var objVuelo = new Vuelo(cantidadVuelo,detalleVuelo,precioPasajeVuelo);
			Assert.NotEqual(Guid.Empty,objVuelo.Id);
			Assert.Equal(cantidadVuelo,objVuelo.Cantidad);
			Assert.Equal(detalleVuelo,objVuelo.Detalle);
			Assert.Equal(precioPasajeVuelo,( decimal )objVuelo.PrecioPasaje);

		}
		[Fact]
		public void TestConstructor_IsPrivate() {
			var vuelo = new Vuelo();
			Assert.NotEqual(Guid.Empty,vuelo.Id);
			Assert.Equal(0,vuelo.Cantidad);
			Assert.Null(vuelo.Detalle);
			Assert.Equal(new decimal(0.0),( decimal )vuelo.PrecioPasaje);
		}
	}
}
