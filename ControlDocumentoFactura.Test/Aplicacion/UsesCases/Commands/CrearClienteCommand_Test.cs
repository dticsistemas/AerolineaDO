using ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Clientes.CrearCliente;
using ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Facturas.CrearFactura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Aplicacion.UsesCases.Commands
{
	public class CrearClienteCommand_Test
	{
		[Fact]
		public void CrearClienteCommand_DataValid()
		{
			
			var IdTest = new Guid();
			var name = "Juan";
			var lastName = "Prueba";
			var passport = "123";
			var needAssistance = "true";
			var nit = "456";
			var email = "demo@demo.com";
			var phone = "789";			
			var command = new CrearClienteCommand(IdTest,name,lastName,passport,needAssistance,nit,email,phone);
			Assert.Equal(IdTest, command.Id);
			Assert.Equal(name,command.Name);
			Assert.Equal(lastName,command.LastName);
			Assert.Equal(passport,command.Passport);
			Assert.Equal(needAssistance,command.NeedAssistance);
			Assert.Equal(nit,command.Nit);
			Assert.Equal(email,command.Email);
			Assert.Equal(phone, command.Phone);

		}


		[Fact]
		public void TestConstructor_IsPrivate()
		{
			var command = (CrearClienteCommand)Activator.CreateInstance(typeof(CrearClienteCommand), true);
			Assert.Null(command.Name);
			Assert.Null(command.LastName);
			Assert.Null(command.NombreCompleto);
			Assert.Null(command.NeedAssistance);
			Assert.Null(command.Nit);
			Assert.Null(command.Email);
			Assert.Equal(Guid.Empty, command.Id);
		}
	}
}
