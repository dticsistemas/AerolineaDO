using ControlDocumentoFactura.Dominio.Models.Clientes;
using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Dominio.Models {
	public class Cliente_Test {
		[Fact]
		public void Cliente_CheckPropertiesValid() {
			var idCliente = Guid.NewGuid();
			var nombreCliente = "Juan Prueba Test";
			var objCliente = new Cliente(nombreCliente);
			Assert.NotEqual(Guid.Empty,objCliente.Id);
			Assert.Equal(nombreCliente,objCliente.NombreCompleto);

			nombreCliente = "ABCSDEFGHIJKLMNOPQRSTVUWXYZ01234567489ABCSDEFGHIJKLMNOPQRSTVUWXYZ01234567489ABCSDEFGHIJKLMNOPQRSTVUWXYZ01234567489";
			nombreCliente += "ABCSDEFGHIJKLMNOPQRSTVUWXYZ01234567489ABCSDEFGHIJKLMNOPQRSTVUWXYZ01234567489ABCSDEFGHIJKLMNOPQRSTVUWXYZ01234567489";
			nombreCliente += "ABCSDEFGHIJKLMNOPQRSTVUWXYZ01234567489ABCSDEFGHIJKLMNOPQRSTVUWXYZ01234567489ABCSDEFGHIJKLMNOPQRSTVUWXYZ01234567489";
			nombreCliente += "ABCSDEFGHIJKLMNOPQRSTVUWXYZ01234567489ABCSDEFGHIJKLMNOPQRSTVUWXYZ01234567489ABCSDEFGHIJKLMNOPQRSTVUWXYZ01234567489";
			nombreCliente += "ABCSDEFGHIJKLMNOPQRSTVUWXYZ01234567489ABCSDEFGHIJKLMNOPQRSTVUWXYZ01234567489ABCSDEFGHIJKLMNOPQRSTVUWXYZ01234567489";


			Action testCodigoNombreExcedente500Caracteres = () => {
				objCliente = new Cliente(nombreCliente);
			};
			var exception = Record.Exception(testCodigoNombreExcedente500Caracteres);
			Assert.NotNull(exception);
			Assert.IsType<BussinessRuleValidationException>(exception);



		}
		[Fact]
		public void TestConstructor_IsPrivate() {
			var cliente = new Cliente();
			Assert.Null(cliente.NombreCompleto);
			Assert.Equal(Guid.Empty,cliente.Id);
		}

	}
}
