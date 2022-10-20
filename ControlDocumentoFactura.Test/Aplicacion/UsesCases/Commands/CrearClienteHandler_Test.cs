using ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Clientes.CrearCliente;
using ControlDocumentoFactura.Dominio.Repositories.Clientes;
using ControlDocumentoFactura.Dominio.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Threading;
using ControlDocumentoFactura.Dominio.Models.Clientes;
using Xunit;
using ControlDocumentoFactura.Aplicacion.Services.Reservas;

namespace ControlDocumentoFactura.Test.Aplicacion.UsesCases.Commands
{
	public class CrearClienteHandler_Test
	{
		private readonly Mock<IClienteRepository> _clienteRepository;
		private readonly Mock<ILogger<CrearClienteHandler>> _logger;
		private readonly Mock<IUnitOfWork> _unitOfWork;



		private Guid _idClienteTest = new();
		private string _name = "Juan";
		private string _lastName = "Perez";
		private string _passport = "654321";
		private string _email = "demo@demo.com";
		private string _phone = "7894561";
		private string _nit = "7894561";
		private string _needAssistance = "true";

		private Cliente _clienteTest;

		public CrearClienteHandler_Test()
		{
			_clienteRepository = new Mock<IClienteRepository>();
			_logger = new Mock<ILogger<CrearClienteHandler>>();
			_unitOfWork = new Mock<IUnitOfWork>();
			_clienteTest = new Cliente();

		}
		[Fact]
		public void CrearCliente_HandleCorrectly()
		{


			var objHandler = new CrearClienteHandler(
				_clienteRepository.Object,
				_logger.Object,
				_unitOfWork.Object
			);


			var objRequest = new CrearClienteCommand(_idClienteTest,_name,_lastName,_passport,_needAssistance,_nit,_email,_phone);
			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest, tcs.Token);
			Assert.IsType<Guid>(result.Result);

			//var domainEventList = (List<DomainEvent>)_clienteTest.DomainEvents;
			//Assert.Single(domainEventList);
			//Assert.IsType<FacturaCreadoEvent>(domainEventList[0]);
		}
		[Fact]
		public void CrearClienteHandler_Handle_Fail()
		{
			// Failing by returning null values
			var objHandler = new CrearClienteHandler(
				_clienteRepository.Object,
				_logger.Object,
				_unitOfWork.Object
			);
			var objRequest = new CrearClienteCommand(_idClienteTest, "", _lastName, _passport, _needAssistance, _nit, _email, _phone);


			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest, tcs.Token);
			_logger.Verify(mock => mock.Log(
				It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
				It.Is<EventId>(eventId => eventId.Id == 0),
				It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == "Error al crear cliente"),
				It.IsAny<Exception>(),
				It.IsAny<Func<It.IsAnyType, Exception, string>>())
			, Times.Once);
		}
	}
}
