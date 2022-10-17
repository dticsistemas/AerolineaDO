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
	public class DescripcionLugarValue_Test
	{
		[Fact]
		public void Descripcion_CheckPropertiesValid()
		{
			var lugarTest = "Santa Cruz de la Sierra";
			var descripcionValue = new DescripcionLugarValue(lugarTest);

			Assert.Equal(descripcionValue.Value, lugarTest);
			Assert.NotNull(descripcionValue.ToString());
			Assert.Equal(descripcionValue, lugarTest);

			Action testCodigoNombreExcedente100Caracteres = () => {
			descripcionValue = new DescripcionLugarValue("123456789101234567890123456789+01234567890123456789descripcion de lugar mayora que la cantidad dfe caracteres permitidos generandoi una esxcepcion para comporobar mediante test unitatrios7654321");
			};
			var exception = Record.Exception(testCodigoNombreExcedente100Caracteres);
			Assert.NotNull(exception);
			Assert.IsType<BussinessRuleValidationException>(exception);



		}

	}
}
