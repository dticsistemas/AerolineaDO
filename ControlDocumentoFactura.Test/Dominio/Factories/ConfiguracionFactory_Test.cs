using ControlDocumentoFactura.Dominio.Factories.Facturas;
using ControlDocumentoFactura.Dominio.Models.Facturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Dominio.Factories
{
	public class ConfiguracionFactory_Test
	{
		[Fact]
		public void ConfigFacturaFactory_CheckPropertiesValid()
		{
			ConfiguracionFacturaFactory _cfgfacturaFactory = new ConfiguracionFacturaFactory();

			ConfiguracionFactura objCFactura = _cfgfacturaFactory.Create();

			Assert.NotNull(objCFactura.Id);
			Assert.Equal("A", objCFactura.Estado);
		}
	}
}
