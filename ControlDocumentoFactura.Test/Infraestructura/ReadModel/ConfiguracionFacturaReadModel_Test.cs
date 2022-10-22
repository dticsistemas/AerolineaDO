using ControlDocumentoFactura.Infraestructura.EntityFramework.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Infraestructura.ReadModel
{
	public class ConfiguracionFacturaReadModel_Test
	{
		[Fact]
		public void ConfiguracionFacturaModel_CheckPropertiesValid()
		{
			var idFacturaTest = new Guid();

			var nitProveedorTest = "123456";
			var razonSocialProveedorTest = "AEROPRO";
			var nroAutorizacionTest = "1";
			var estadoTest = "P";
			var fechaTest = DateTime.Now;

			var objFactura = new ConfiguracionFacturaReadModel();

			Assert.Equal(Guid.Empty, objFactura.Id);


			objFactura.Id = idFacturaTest;
			objFactura.Fecha = fechaTest;
			objFactura.NroAutorizacion = nroAutorizacionTest;
			objFactura.Estado = estadoTest;
			objFactura.RazonSocialProveedor = razonSocialProveedorTest;
			objFactura.NitProveedor = nitProveedorTest;

			Assert.Equal(idFacturaTest, objFactura.Id);
			Assert.Equal(fechaTest, objFactura.Fecha);
			Assert.Equal(nitProveedorTest, objFactura.NitProveedor);
			Assert.Equal(nroAutorizacionTest, objFactura.NroAutorizacion);
			Assert.Equal(estadoTest, objFactura.Estado);
			Assert.Equal(razonSocialProveedorTest, objFactura.RazonSocialProveedor);

		}
	}
}
