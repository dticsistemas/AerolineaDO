using ControlDocumentoFactura.Infraestructura.EntityFramework.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Infraestructura.ReadModel {
	public class ReservaReadModel_Test {
		[Fact]
		public void ReservaDto_CheckPropertiesValid() {


			var idReservaTest = new Guid();
			var _clienteReadModel = new ClienteReadModel();
			var _vueloReadModel = new VueloReadModel();

			decimal montoTest = new(720.0);
			decimal deudaTest = new(720.0);
			DateTime fechaTest = DateTime.Now;
			var codReservaTest = "ABC12";
			var estadoReservaTest = "P";
			var tipoReservaTest = "R";

			var objReserva = new ReservaReadModel();

			Assert.Equal(Guid.Empty,objReserva.Id);
			Assert.Null(objReserva.Cliente);
			Assert.Null(objReserva.Vuelo);
			Assert.Equal(new decimal(0.0),objReserva.Monto);
			Assert.Equal(new decimal(0.0),objReserva.Deuda);
			Assert.Equal(DateTime.MinValue,objReserva.Fecha);
			Assert.Null(objReserva.CodReserva);
			Assert.Null(objReserva.EstadoReserva);
			Assert.Null(objReserva.TipoReserva);

			objReserva.Id = idReservaTest;
			objReserva.Cliente = _clienteReadModel;
			objReserva.Vuelo = _vueloReadModel;
			objReserva.Monto = montoTest;
			objReserva.Deuda = deudaTest;
			objReserva.Fecha = fechaTest;
			objReserva.CodReserva = codReservaTest;
			objReserva.EstadoReserva = estadoReservaTest;
			objReserva.TipoReserva = tipoReservaTest;

			Assert.Equal(idReservaTest,objReserva.Id);
			Assert.Equal(_clienteReadModel,objReserva.Cliente);
			Assert.Equal(_vueloReadModel,objReserva.Vuelo);
			Assert.Equal(montoTest,objReserva.Monto);
			Assert.Equal(deudaTest,objReserva.Deuda);
			Assert.Equal(fechaTest,objReserva.Fecha);
			Assert.Equal(codReservaTest,objReserva.CodReserva);
			Assert.Equal(estadoReservaTest,objReserva.EstadoReserva);
			Assert.Equal(tipoReservaTest,objReserva.TipoReserva);

		}
	}
}
