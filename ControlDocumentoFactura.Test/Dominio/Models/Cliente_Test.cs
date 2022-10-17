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
			var lastName = "Perez";
			var objCliente = new Cliente(idCliente,nombreCliente,lastName,"passport","0","1234","email@email.com","7654321");
			Assert.NotEqual(Guid.Empty,objCliente.Id);
			Assert.Equal(nombreCliente,objCliente.Name);

			nombreCliente = "ABCSDEFGHIJKLMNOPQRSTVUWXYZ01234567489ABCSDEFGHIJKLMNOPQRSTVUWXYZ01234567489ABCSDEFGHIJKLMNOPQRSTVUWXYZ01234567489";
			nombreCliente += "ABCSDEFGHIJKLMNOPQRSTVUWXYZ01234567489ABCSDEFGHIJKLMNOPQRSTVUWXYZ01234567489ABCSDEFGHIJKLMNOPQRSTVUWXYZ01234567489";
			nombreCliente += "ABCSDEFGHIJKLMNOPQRSTVUWXYZ01234567489ABCSDEFGHIJKLMNOPQRSTVUWXYZ01234567489ABCSDEFGHIJKLMNOPQRSTVUWXYZ01234567489";
			nombreCliente += "ABCSDEFGHIJKLMNOPQRSTVUWXYZ01234567489ABCSDEFGHIJKLMNOPQRSTVUWXYZ01234567489ABCSDEFGHIJKLMNOPQRSTVUWXYZ01234567489";
			nombreCliente += "ABCSDEFGHIJKLMNOPQRSTVUWXYZ01234567489ABCSDEFGHIJKLMNOPQRSTVUWXYZ01234567489ABCSDEFGHIJKLMNOPQRSTVUWXYZ01234567489";


			Action testCodigoNombreExcedente500Caracteres = () => {
				objCliente = new Cliente(idCliente, nombreCliente, lastName, "passport", "0", "1234", "email@email.com", "7654321");
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
