using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Facturas.ListarFacturas;
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Facturas.ObtenerConfiguracionFactura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Aplicacion.UsesCases.Queries
{
	public class ObtenerConfiguracionFacturaQuery_Test
	{
		[Fact]
		public void ObtenerConfiguracionFacturaQuery_DataValid()
		{
			var query = new ObtenerConfiguracionFacturaQuery();

			Assert.NotNull(query);
		}
	}
}
