using ControlDocumentoFactura.Dominio.Models.Clientes.ValueObjects;
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
	public class PersonDataValue_Test
	{
		[Fact]
		public void PersonData_CheckPropertiesValid()
		{

			var objTest = "Santa Cruz de la Sierra";
			var objValue = new PersonDataValue(objTest);

			Assert.Equal(objValue.Value, objTest);
			Assert.Equal(objTest, objValue.Value);
			Assert.NotNull(objValue.ToString());
			Assert.Equal(objTest, objValue);

			Action testCodigoNombreExcedente500Caracteres = () =>
			{
				var cadena = "123456789101234567890123456789+01234567890123456789descripcion de lugar mayora que la cantidad dfe caracteres permitidos generandoi una esxcepcion para comporobar mediante test unitatrios7654321";
				cadena = cadena + cadena + cadena + cadena + cadena + cadena + cadena + cadena;

				objValue = new PersonDataValue(cadena + "123456789101234567890123456789+01234567890123456789descripcion de lugar mayora que la cantidad dfe caracteres permitidos generandoi una esxcepcion para comporobar mediante test unitatrios7654321");
			};
			var exception = Record.Exception(testCodigoNombreExcedente500Caracteres);
			Assert.NotNull(exception);
			Assert.IsType<BussinessRuleValidationException>(exception);



		}
	}
}
