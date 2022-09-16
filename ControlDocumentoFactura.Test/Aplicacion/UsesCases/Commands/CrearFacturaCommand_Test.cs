using ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Facturas.CrearFactura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Aplicacion.UsesCases.Commands {
	public class CrearFacturaCommand_Test {
		[Fact]
		public void CrearFacturaCommand_DataValid() {

			var montoTest = new decimal(50.0);
			var importeTest = new decimal(50.0);
			var lugarTest = "NN";
			var nitBeneficiarioTest = "654321";
			var razonSocialBeneficiarioTest = "Juan Perez";
			var reservaIdTest = new Guid();
			var clienteIdTest = new Guid();
			var vueloIdTest = new Guid();

			var command = new CrearFacturaCommand(montoTest,importeTest,lugarTest,nitBeneficiarioTest,razonSocialBeneficiarioTest,clienteIdTest,vueloIdTest,reservaIdTest);

			Assert.Equal(montoTest,command.Monto);
			Assert.Equal(importeTest,command.Importe);
			Assert.Equal(lugarTest,command.Lugar);
			Assert.Equal(nitBeneficiarioTest,command.NitBeneficiario);
			Assert.Equal(razonSocialBeneficiarioTest,command.RazonSocialBeneficiario);
			Assert.Equal(reservaIdTest,command.ReservaId);
			Assert.Equal(clienteIdTest,command.ClienteId);
			Assert.Equal(vueloIdTest,command.VueloId);
		}


		[Fact]
		public void TestConstructor_IsPrivate() {
			var command = ( CrearFacturaCommand )Activator.CreateInstance(typeof(CrearFacturaCommand),true);
			Assert.Equal(new decimal(0.0),command.Monto);
			Assert.Equal(new decimal(0.0),command.Importe);
			Assert.Null(command.Lugar);
			Assert.Null(command.NitBeneficiario);
			Assert.Null(command.RazonSocialBeneficiario);
			Assert.Equal(Guid.Empty,command.ReservaId);
			Assert.Equal(Guid.Empty,command.ClienteId);
			Assert.Equal(Guid.Empty,command.VueloId);
		}

	}
}
