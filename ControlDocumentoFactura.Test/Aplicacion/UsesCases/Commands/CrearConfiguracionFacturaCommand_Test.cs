using ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Clientes.CrearCliente;
using ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Facturas.CrearConfiguracionFactura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Aplicacion.UsesCases.Commands
{
	public class CrearConfiguracionFacturaCommand_Test
	{
		[Fact]
		public void CrearConfiguracionFacturaCommand_DataValid()
		{

			var nitProveedor = "123";
			var razonSocialProveedor = "demo";
			var nroAutorizacion = "1";
			var command = new CrearConfiguracionFacturaCommand(nitProveedor,razonSocialProveedor,nroAutorizacion);
			Assert.Equal(nroAutorizacion, command.NroAutorizacion);
			Assert.Equal(razonSocialProveedor, command.RazonSocialProveedor);
			Assert.Equal(nitProveedor, command.NitProveedor);

		}


		[Fact]
		public void TestConstructor_IsPrivate()
		{
			var command = (CrearConfiguracionFacturaCommand)Activator.CreateInstance(typeof(CrearConfiguracionFacturaCommand), true);
			Assert.Null(command.NroAutorizacion);
			Assert.Null(command.RazonSocialProveedor);
			Assert.Null(command.NitProveedor);
		}
	}
}
