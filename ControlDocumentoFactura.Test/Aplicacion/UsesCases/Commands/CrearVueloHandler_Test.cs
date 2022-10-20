using ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Reservas;
using ControlDocumentoFactura.Dominio.Repositories.Reservas;
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
using ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Vuelos.CrearVuelo;
using ControlDocumentoFactura.Dominio.Repositories.Vuelos;
using ControlDocumentoFactura.Dominio.Factories.Facturas;
using ControlDocumentoFactura.Dominio.Factories.Vuelos;

namespace ControlDocumentoFactura.Test.Aplicacion.UsesCases.Commands
{
	public class CrearVueloHandler_Test
	{
		private readonly Mock<IVueloRepository> _objRepository;
		private readonly Mock<ILogger<CrearVueloHandler>> _logger;
		private readonly Mock<IVueloFactory> _objFactory;
		private readonly Mock<IUnitOfWork> _unitOfWork;



		private Guid _idTest = new();
		private int flight_program_id = 10;
		private String source_airport_code = "MIA";
		private String destiny_airport_code = "SCZ";
		private String status = "R";
		private String information = "info";


		public CrearVueloHandler_Test()
		{
			_objRepository = new Mock<IVueloRepository>();
			_objFactory = new Mock<IVueloFactory>();
			_logger = new Mock<ILogger<CrearVueloHandler>>();
			_unitOfWork = new Mock<IUnitOfWork>();

		}
		[Fact]
		public void CrearVuelo_HandleCorrectly()
		{


			var objHandler = new CrearVueloHandler(
				_objRepository.Object,
				_logger.Object,
				_objFactory.Object,
				_unitOfWork.Object
			);


			var objRequest = new CrearVueloCommand(_idTest,flight_program_id,source_airport_code,destiny_airport_code,status,information);
			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest, tcs.Token);
			Assert.IsType<Guid>(result.Result);

			//var domainEventList = (List<DomainEvent>)_clienteTest.DomainEvents;
			//Assert.Single(domainEventList);
			//Assert.IsType<FacturaCreadoEvent>(domainEventList[0]);
		}
		[Fact]
		public void CrearVueloHandler_Handle_Fail()
		{
			// Failing by returning null values

			var objHandler = new CrearVueloHandler(
				_objRepository.Object,
				_logger.Object,
				_objFactory.Object,
				_unitOfWork.Object
			);


			var objRequest = new CrearVueloCommand(_idTest, flight_program_id, source_airport_code, destiny_airport_code, status, information);

			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest, tcs.Token);
			_logger.Verify(mock => mock.Log(
				It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
				It.Is<EventId>(eventId => eventId.Id == 0),
				It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == "Error al crear vuelo"),
				It.IsAny<Exception>(),
				It.IsAny<Func<It.IsAnyType, Exception, string>>())
			, Times.Once);
		}
	}
}
