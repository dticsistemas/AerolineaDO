using ControlDocumentoFactura.Dominio.IntegrationEvents;
using ControlDocumentoFactura.Dominio.Models.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Dominio.IntegrationEvents
{
	public class ClienteCreado_Test
	{
		[Fact]
		public void ClienteCreado_CheckPropertiesValid()
		{
			Guid Id = new Guid();
			String NombreCompleto = "nuevo";
			String Name = "demo";
			String LastName = "test";
			String Passport = "123";
			String NeedAssistance = "true";
			String Nit = "456";
			String Email = "demo@demo.com";
			String Phone = "100";
			var objValue = new ClienteCreado();

			objValue.Id = Id;
			objValue.NombreCompleto = NombreCompleto;
			objValue.Name = Name;
			objValue.LastName = LastName;
			objValue.Passport = Passport;
			objValue.NeedAssistance = NeedAssistance;
			objValue.Nit = Nit;
			objValue.Email = Email;
			objValue.Phone = Phone;

			Assert.Equal(Id, objValue.Id);
			Assert.Equal(NombreCompleto, objValue.NombreCompleto);
			Assert.Equal(Name, objValue.Name);
			Assert.Equal(LastName, objValue.LastName);
			Assert.Equal(Passport, objValue.Passport);
			Assert.Equal(NeedAssistance, objValue.NeedAssistance);
			Assert.Equal(Nit, objValue.Nit);
			Assert.Equal(Email, objValue.Email);
			Assert.Equal(Phone, objValue.Phone);

		}
	}
}
