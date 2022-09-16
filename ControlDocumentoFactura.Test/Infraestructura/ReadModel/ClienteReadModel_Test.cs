using ControlDocumentoFactura.Infraestructura.EntityFramework.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Infraestructura.ReadModel {
	public class ClienteReadModel_Test {
		[Fact]
		public void ClienteReadModel_CheckPropertiesValid() {
			var idCliente = Guid.NewGuid();
			var nombreCliente = "Juan Prueba Test";
			var objCliente = new ClienteReadModel();
			Assert.Equal(Guid.Empty,objCliente.Id);
			Assert.Null(objCliente.NombreCompleto);

			objCliente.Id = idCliente;
			objCliente.NombreCompleto = nombreCliente;
			Assert.Equal(idCliente,objCliente.Id);
			Assert.Equal(nombreCliente,objCliente.NombreCompleto);



		}
	}
}
