using ControlDocumentoFactura.Aplicacion.Dtos.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Aplicacion.Dtos {
	public class FacturaDtoTest {
		[Fact]
		public void FacturaDto_CheckPropertiesValid() {
			var idFacturaTest = new Guid();
			var idReservaTest = new Guid();
			var idClienteTest = new Guid();
			var idVueloTest = new Guid();
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

			var objFactura = new FacturaDto();

			Assert.Equal(Guid.Empty,objFactura.Id);
			Assert.Equal(Guid.Empty,objFactura.ReservaId);
			Assert.Equal(Guid.Empty,objFactura.ClienteId);
			Assert.Equal(Guid.Empty,objFactura.VueloId);
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
			objFactura.ReservaId = idReservaTest;
			objFactura.ClienteId = idClienteTest;
			objFactura.VueloId = idVueloTest;
			objFactura.Estado = estadoTest;

			Assert.Equal(idFacturaTest,objFactura.Id);
			Assert.Equal(idReservaTest,objFactura.ReservaId);
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
			Assert.Equal(idClienteTest,objFactura.ClienteId);
			Assert.Equal(idVueloTest,objFactura.VueloId);
			Assert.Equal(estadoTest,objFactura.Estado);

		}
	}
}
