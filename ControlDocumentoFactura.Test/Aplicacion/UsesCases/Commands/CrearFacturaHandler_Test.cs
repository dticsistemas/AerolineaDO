using ControlDocumentoFactura.Aplicacion.Services.Reservas;
using ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Facturas.CrearFactura;
using ControlDocumentoFactura.Dominio.Events.Facturas;
using ControlDocumentoFactura.Dominio.Factories.Facturas;
using ControlDocumentoFactura.Dominio.Models.Facturas;
using ControlDocumentoFactura.Dominio.Repositories;
using ControlDocumentoFactura.Dominio.Repositories.Facturas;
using Microsoft.Extensions.Logging;
using Moq;
using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Aplicacion.UsesCases.Commands {
	public class CrearFacturaHandler_Test {
		private readonly Mock<IFacturaRepository> _facturaRepository;
		private readonly Mock<ILogger<CrearFacturaHandler>> _logger;
		private readonly Mock<IFacturaService> _facturaService;
		private readonly Mock<IFacturaFactory> _facturaFactory;
		private readonly Mock<IUnitOfWork> _unitOfWork;

		private Guid _idReservaTest = new();
		private Guid _idClienteTest = new();
		private Guid _idVueloTest = new();
		private decimal _montoTest = new(4.0);
		private decimal _importeTest = new(4.0);
		private string _nroFacturaTest = "2022-05-15";
		private string _lugarTest = "SCZ B/ Los Olivos";
		private string _nitBeneficiarioTest = "654321";
		private string _razonSocialBeneficiarioTest = "Juan Perez";

		private Factura _facturaTest;

		public CrearFacturaHandler_Test() {
			_facturaRepository = new Mock<IFacturaRepository>();
			_logger = new Mock<ILogger<CrearFacturaHandler>>();
			_facturaService = new Mock<IFacturaService>();
			_facturaFactory = new Mock<IFacturaFactory>();
			_unitOfWork = new Mock<IUnitOfWork>();
			_facturaTest = new FacturaFactory().Create(_nroFacturaTest);

		}
		[Fact]
		public void CrearFacturaHandler_HandleCorrectly() {

			_facturaService.Setup(_facturaService => _facturaService.GenerarNroFacturaAsync()).Returns(Task.FromResult(_nroFacturaTest));
			_facturaFactory.Setup(_factory => _factory.Create(_nroFacturaTest))
				.Returns(_facturaTest);

			var objHandler = new CrearFacturaHandler(
				_facturaRepository.Object,
				_logger.Object,
				_facturaService.Object,
				_facturaFactory.Object,
				_unitOfWork.Object
			);


			var objRequest = new CrearFacturaCommand(_montoTest,_importeTest,_lugarTest,_nitBeneficiarioTest,_razonSocialBeneficiarioTest,_idClienteTest,_idVueloTest,_idReservaTest);
			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest,tcs.Token);
			Assert.IsType<Guid>(result.Result);

			var domainEventList = ( List<DomainEvent> )_facturaTest.DomainEvents;
			//Assert.Single(domainEventList);
			Assert.IsType<FacturaCreadoEvent>(domainEventList[0]);
		}
		[Fact]
		public void CrearProductoHandler_Handle_Fail() {
			// Failing by returning null values
			var objHandler = new CrearFacturaHandler(
				_facturaRepository.Object,
				_logger.Object,
				_facturaService.Object,
				_facturaFactory.Object,
				_unitOfWork.Object
			 );
			var objRequest = new CrearFacturaCommand(_montoTest,_importeTest,_lugarTest,_nitBeneficiarioTest,_razonSocialBeneficiarioTest,_idClienteTest,_idVueloTest,_idReservaTest);


			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest,tcs.Token);
			_logger.Verify(mock => mock.Log(
				It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
				It.Is<EventId>(eventId => eventId.Id == 0),
				It.Is<It.IsAnyType>((@object,@type) => @object.ToString() == "Error al crear Factura"),
				It.IsAny<Exception>(),
				It.IsAny<Func<It.IsAnyType,Exception,string>>())
			,Times.Once);
		}
	}
}
