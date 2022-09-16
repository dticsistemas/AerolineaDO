using ControlDocumentoFactura.Infraestructura.EntityFramework.ReadModel;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Infraestructura.ReadModel {
	public class FacturaReadModel_Test {


		[Fact]
		public void FacturaDto_CheckPropertiesValid() {
			var idFacturaTest = new Guid();
			decimal montoTest = new(4.0);
			decimal importeTest = new(4.0);
			DateTime fechaTest = DateTime.Now;
			var nroFacturaTest = "2022-05-15";
			var lugarTest = "SCZ B/ Los Olivos";
			var nitProveedorTest = "123456";
			var nitBeneficiarioTest = "654321";
			var razonSocialProveedorTest = "AEROPRO";
			var razonSocialBeneficiarioTest = "Juan Perez";
			var nroAutorizacionTest = "1";
			var estadoTest = "P";
			var _reservaReadModel = new ReservaReadModel();
			var _clienteReadModel = new ClienteReadModel();
			var _vueloReadModel = new VueloReadModel();


			var objFactura = new FacturaReadModel();

			Assert.Equal(Guid.Empty,objFactura.Id);
			Assert.Null(objFactura.Reserva);
			Assert.Null(objFactura.Cliente);
			Assert.Null(objFactura.Vuelo);
			Assert.Equal(new decimal(0.0),objFactura.Monto);
			Assert.Equal(new decimal(0.0),objFactura.Importe);
			Assert.Equal(DateTime.MinValue,objFactura.Fecha);
			Assert.Null(objFactura.NroFactura);
			Assert.Null(objFactura.Lugar);
			Assert.Null(objFactura.NroAutorizacion);
			Assert.Null(objFactura.RazonSocialBeneficiario);
			Assert.Null(objFactura.RazonSocialProveedor);
			Assert.Null(objFactura.NitBeneficiario);
			Assert.Null(objFactura.NitProveedor);
			Assert.Null(objFactura.Estado);



			objFactura.Id = idFacturaTest;
			objFactura.Monto = montoTest;
			objFactura.Importe = importeTest;
			objFactura.Fecha = fechaTest;
			objFactura.NroFactura = nroFacturaTest;
			objFactura.Lugar = lugarTest;
			objFactura.NitProveedor = nitProveedorTest;
			objFactura.NitBeneficiario = nitBeneficiarioTest;
			objFactura.RazonSocialProveedor = razonSocialProveedorTest;
			objFactura.RazonSocialBeneficiario = razonSocialBeneficiarioTest;
			objFactura.NroAutorizacion = nroAutorizacionTest;
			objFactura.Estado = estadoTest;


			objFactura.Reserva = _reservaReadModel;
			objFactura.Cliente = _clienteReadModel;
			objFactura.Vuelo = _vueloReadModel;

			Assert.Equal(idFacturaTest,objFactura.Id);
			Assert.Equal(montoTest,objFactura.Monto);
			Assert.Equal(importeTest,objFactura.Importe);
			Assert.Equal(fechaTest,objFactura.Fecha);
			Assert.Equal(nroFacturaTest,objFactura.NroFactura);
			Assert.Equal(lugarTest,objFactura.Lugar);
			Assert.Equal(nitProveedorTest,objFactura.NitProveedor);
			Assert.Equal(nitBeneficiarioTest,objFactura.NitBeneficiario);
			Assert.Equal(razonSocialProveedorTest,objFactura.RazonSocialProveedor);
			Assert.Equal(razonSocialBeneficiarioTest,objFactura.RazonSocialBeneficiario);
			Assert.Equal(nroAutorizacionTest,objFactura.NroAutorizacion);
			Assert.Equal(estadoTest,objFactura.Estado);

			Assert.Equal(_clienteReadModel,objFactura.Cliente);
			Assert.Equal(_vueloReadModel,objFactura.Vuelo);
			Assert.Equal(_reservaReadModel,objFactura.Reserva);

		}
	}
}
