using ControlDocumentoFactura.Infraestructura.EntityFramework.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Infraestructura.ReadModel {
	public class VueloReadModel_Tets {
		[Fact]
		public void VueloReadModel_CheckPropertiesValid() {
			var idVueloTest = new Guid();
			var cantidadTest = 200;
			decimal precioPasajeTest = new(720.0);
			var detalleTest = "SCZ-LPZ";

			var objVuelo = new VueloReadModel();

			Assert.Equal(Guid.Empty,objVuelo.Id);
			Assert.Equal(0,objVuelo.Cantidad);
			Assert.Null(objVuelo.Detalle);
			Assert.Equal(new decimal(0.0),objVuelo.PrecioPasaje);

			objVuelo.Id = idVueloTest;
			objVuelo.Cantidad = cantidadTest;
			objVuelo.PrecioPasaje = precioPasajeTest;
			objVuelo.Detalle = detalleTest;


			Assert.Equal(idVueloTest,objVuelo.Id);
			Assert.Equal(cantidadTest,objVuelo.Cantidad);
			Assert.Equal(detalleTest,objVuelo.Detalle);
			Assert.Equal(precioPasajeTest,objVuelo.PrecioPasaje);

		}
	}
}
