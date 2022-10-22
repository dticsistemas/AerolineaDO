using ControlDocumentoFactura.Infraestructura.EntityFramework.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Infraestructura.ReadModel
{
	public class ClienteReadModel_Test
	{
		[Fact]
		public void ClienteReadModel_CheckPropertiesValid()
		{
			var idCliente = Guid.NewGuid();
			var nombreCliente = "Juan Prueba Test";
			String Name = "Juan";
			String LastName = "Perez";
			String Passport = "123";
			String NeedAssistance = "true";
			String Nit = "456";
			String Email = "demo@demo.com";
			String Phone = "789";

			var objCliente = new ClienteReadModel();
			Assert.Equal(Guid.Empty, objCliente.Id);
			Assert.Null(objCliente.NombreCompleto);

			objCliente.Id = idCliente;
			objCliente.NombreCompleto = nombreCliente;
			objCliente.Name = Name;
			objCliente.LastName = LastName;
			objCliente.Passport = Passport;
			objCliente.NeedAssistance = NeedAssistance;
			objCliente.Nit = Nit;
			objCliente.Email = Email;
			objCliente.Phone = Phone;
			Assert.Equal(idCliente, objCliente.Id);
			Assert.Equal(nombreCliente, objCliente.NombreCompleto);
			Assert.Equal(Name, objCliente.Name);
			Assert.Equal(LastName, objCliente.LastName);
			Assert.Equal(Passport, objCliente.Passport);
			Assert.Equal(NeedAssistance, objCliente.NeedAssistance);
			Assert.Equal(Nit, objCliente.Nit);
			Assert.Equal(Email, objCliente.Email);
			Assert.Equal(Phone, objCliente.Phone);



		}
	}
}
