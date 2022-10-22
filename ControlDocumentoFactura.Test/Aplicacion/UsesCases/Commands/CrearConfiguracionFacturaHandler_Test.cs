using ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Clientes.CrearCliente;
using ControlDocumentoFactura.Dominio.Models.Clientes;
using ControlDocumentoFactura.Dominio.Repositories.Clientes;
using ControlDocumentoFactura.Dominio.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Facturas.CrearConfiguracionFactura;
using ControlDocumentoFactura.Dominio.Factories.Facturas;
using ControlDocumentoFactura.Dominio.Repositories.Facturas;

namespace ControlDocumentoFactura.Test.Aplicacion.UsesCases.Commands
{
	public class CrearConfiguracionFacturaHandler_Test
	{
		private readonly Mock<IConfiguracionFacturaRepository> _objRepository;
		private readonly Mock<ILogger<CrearConfiguracionFacturaHandler>> _logger;
		private readonly Mock<IConfiguracionFacturaFactory> _objFactory;
		private readonly Mock<IUnitOfWork> _unitOfWork;



		private Guid _idClienteTest = new();
		private string _nitProveedor = "Juan";
		private string _razonSocialProveedor = "Perez";
		private string _nroAutorizacion = "654321";

		private Cliente _clienteTest;

		public CrearConfiguracionFacturaHandler_Test()
		{
			_objRepository = new Mock<IConfiguracionFacturaRepository>();
			_logger = new Mock<ILogger<CrearConfiguracionFacturaHandler>>();
			_objFactory = new Mock<IConfiguracionFacturaFactory>();
			_unitOfWork = new Mock<IUnitOfWork>();
			_clienteTest = new Cliente();

		}
		[Fact]
		public void CrearConfigFactura_HandleCorrectly()
		{


			var objHandler = new CrearConfiguracionFacturaHandler(
				_objRepository.Object,
				_logger.Object,
				_objFactory.Object,
				_unitOfWork.Object
			);


			var objRequest = new CrearConfiguracionFacturaCommand(_nitProveedor, _razonSocialProveedor, _nroAutorizacion);
			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest, tcs.Token);
			Assert.IsType<Guid>(result.Result);

			//var domainEventList = (List<DomainEvent>)_clienteTest.DomainEvents;
			//Assert.Single(domainEventList);
			//Assert.IsType<FacturaCreadoEvent>(domainEventList[0]);
		}
		[Fact]
		public void CrearConfigFacturaHandler_Handle_Fail()
		{
			var objHandler = new CrearConfiguracionFacturaHandler(
				_objRepository.Object,
				_logger.Object,
				_objFactory.Object,
				_unitOfWork.Object
			);


			var objRequest = new CrearConfiguracionFacturaCommand("", _razonSocialProveedor, _nroAutorizacion);

			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest, tcs.Token);
			_logger.Verify(mock => mock.Log(
				It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
				It.Is<EventId>(eventId => eventId.Id == 0),
				It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == "Error al crear Configuracion Factura"),
				It.IsAny<Exception>(),
				It.IsAny<Func<It.IsAnyType, Exception, string>>())
			, Times.Once);
		}
	}
}
