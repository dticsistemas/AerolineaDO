using ControlDocumentoFactura.Aplicacion.Dtos.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Aplicacion.Dtos {
	public class ClienteDtoTest {
		[Fact]
		public void ClienteDto_CheckPropertiesValid() {
			var idCliente = Guid.NewGuid();
			var nombreCliente = "Juan Prueba Test";
			var objCliente = new ClienteDto();
			Assert.Equal(Guid.Empty,objCliente.Id);
			Assert.Null(objCliente.NombreCompleto);

			objCliente.Id = idCliente;
			objCliente.NombreCompleto = nombreCliente;
			Assert.Equal(idCliente,objCliente.Id);
			Assert.Equal(nombreCliente,objCliente.NombreCompleto);



		}


	}
}
