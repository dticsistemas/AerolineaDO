using ControlDocumentoFactura.Dominio.Models.Facturas.ValueObjetcs;
using ControlDocumentoFactura.Dominio.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Dominio.Models.ValueObjects
{
	public class TipoNitValue_Test
	{
		[Fact]
		public void TipoNitValue_CheckPropertiesValid()
		{
			var tipoNitTest = "passport";
			var objValue = new TipoNitValue(tipoNitTest);





			Assert.Equal(objValue.Value, tipoNitTest);
			Assert.Equal(tipoNitTest, objValue.Value);
			Assert.NotNull(objValue.ToString());
			Assert.Equal(tipoNitTest, objValue);

			Action testValoresNull = () =>
			{
				objValue = new TipoNitValue(null);
			};
			var exception = Record.Exception(testValoresNull);
			Assert.NotNull(exception);





		}
	}
}