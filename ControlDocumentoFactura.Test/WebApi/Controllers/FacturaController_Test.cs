using ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Facturas.CrearFactura;
using ControlDocumentoFactura.WebApi.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.WebApi.Controllers
{
	public class FacturaController_Test
	{
		//private readonly IMediator _mediator;
		public FacturaController_Test()
		{

		}
		[Fact]
		public async Task CreatePago_TestAsync()
		{
			Guid clienteId = new();
			Guid vueloId = new();
			Guid reservaId = new();
			var mock = new Moq.Mock<IMediator>();
			Guid configFacturaId = new();
			CrearFacturaCommand commandFactura = new CrearFacturaCommand(new(40.0), "ci", "lugar", "nit", "rz", clienteId, vueloId, reservaId, configFacturaId);


			//mock.Setup(mock => mock.Foo(It.IsAny<string>())).Returns(false);
			//Moq.Language.Flow.IReturnsResult<IMediator> returnsResult = mock.Setup(m => m.Send(obj)).Returns(1);

			FacturaController facturaControllerTest = new FacturaController((IMediator)mock);

			IActionResult result = await facturaControllerTest.CreateFactura(commandFactura);
			Assert.NotNull(result);

		}
	}
}
