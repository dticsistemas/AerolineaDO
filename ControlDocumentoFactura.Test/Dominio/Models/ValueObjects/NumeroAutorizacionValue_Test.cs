using ControlDocumentoFactura.Dominio.Models.Facturas.ValueObjetcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Dominio.Models.ValueObjects
{
	public class NumeroAutorizacionValue_Test
	{
		[Fact]
		public void TipoNitValue_CheckPropertiesValid()
		{
			var valueTest = "123";
			var NroAutorizacionValue = new NumeroAutorizacionValue(valueTest);
			Assert.NotNull(NroAutorizacionValue.ToString());

			Assert.Equal(NroAutorizacionValue.Value, valueTest);

			Action testValoresNull = () =>
			{
				NroAutorizacionValue = new NumeroAutorizacionValue(null);
			};
			var exception = Record.Exception(testValoresNull);
			Assert.NotNull(exception);

			Action testValoresVacio = () =>
			{
				NroAutorizacionValue = new NumeroAutorizacionValue("");
			};
			var exception2 = Record.Exception(testValoresVacio);
			Assert.NotNull(exception2);




		}
	}
}
