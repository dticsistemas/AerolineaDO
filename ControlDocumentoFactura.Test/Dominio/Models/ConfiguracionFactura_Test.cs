using ControlDocumentoFactura.Dominio.Models.Clientes;
using ControlDocumentoFactura.Dominio.Models.Facturas;
using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Dominio.Models
{
	public class ConfiguracionFactura_Test
	{
		[Fact]
		public void ConfiguracionFactura_CheckPropertiesValid()
		{
			var cfacturaTest = new ConfiguracionFactura();
			string nitProveedor = "123456";
			string razonSocialProveedor = "aeronur";
			string nroAutorizacion = "123";
			cfacturaTest.CrearConfiguracionFactura(nitProveedor, razonSocialProveedor, nroAutorizacion);
			Assert.NotNull(cfacturaTest.Id);
			Assert.Equal(nitProveedor, cfacturaTest.NitProveedor);
			Assert.Equal(razonSocialProveedor, cfacturaTest.RazonSocialProveedor);
			Assert.Equal(nroAutorizacion, cfacturaTest.NroAutorizacion);

		}
		[Fact]
		public void TestConstructor_IsPrivate()
		{
			var configFacturaTest = new ConfiguracionFactura();
			Assert.Equal("A", configFacturaTest.Estado);
			Assert.NotNull(configFacturaTest.Id);
		}
		[Fact]
		public void UpdateConfiugacionInactivo_IsPrivate()
		{
			var configFacturaTest = new ConfiguracionFactura();
			configFacturaTest.UpddateEstadoConfiguracionFacturaInactivo();
			Assert.Equal("I", configFacturaTest.Estado);
		}

	}
}
