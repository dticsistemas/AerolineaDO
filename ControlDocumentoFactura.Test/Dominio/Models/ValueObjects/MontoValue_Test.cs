using ControlDocumentoFactura.Dominio.Models.Clientes;
using ControlDocumentoFactura.Dominio.Models.ValueObjects;
using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Dominio.Models.ValueObjects
{
	public class MontoValue_Test
	{
		[Fact]
		public void MontoValue_CheckPropertiesValid()
		{
			var resdecimal = new decimal(10);
			var montoValue = new MontoValue(resdecimal);
			
			Assert.Equal(montoValue.Value, resdecimal);

			Action testValoresNegativos = () => {
				montoValue = new MontoValue(-10);
			};
			var exception = Record.Exception(testValoresNegativos);
			Assert.NotNull(exception);



		}
		
	}
}
