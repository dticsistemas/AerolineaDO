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
using ControlDocumentoFactura.Dominio.Repositories.Reservas;
using ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Reservas;

namespace ControlDocumentoFactura.Test.Aplicacion.UsesCases.Commands
{
	public class CrearReservaHandler_Test
	{
		private readonly Mock<IReservaRepository> _objRepository;
		private readonly Mock<ILogger<CrearReservaHandler>> _logger;
		private readonly Mock<IUnitOfWork> _unitOfWork;



		private Guid _idTest= new();
		private String ReservationNumber = "123";
		private Guid ClienteId = new();
		private Guid VueloId = new();
		private String Fecha="2022-01-01";
		private decimal Monto = new(10);
		private String ReservationStatus = "";


		public CrearReservaHandler_Test()
		{
			_objRepository = new Mock<IReservaRepository>();
			_logger = new Mock<ILogger<CrearReservaHandler>>();
			_unitOfWork = new Mock<IUnitOfWork>();

		}
		[Fact]
		public void CrearReserva_HandleCorrectly()
		{


			var objHandler = new CrearReservaHandler(
				_objRepository.Object,
				_logger.Object,
				_unitOfWork.Object
			);


			var objRequest = new CrearReservaCommand(_idTest,ReservationNumber,ClienteId,VueloId,Fecha,Monto,ReservationStatus);
			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest, tcs.Token);
			Assert.IsType<Guid>(result.Result);

			//var domainEventList = (List<DomainEvent>)_clienteTest.DomainEvents;
			//Assert.Single(domainEventList);
			//Assert.IsType<FacturaCreadoEvent>(domainEventList[0]);
		}
		[Fact]
		public void CrearReservaHandler_Handle_Fail()
		{
			// Failing by returning null values

			var objHandler = new CrearReservaHandler(
				_objRepository.Object,
				_logger.Object,
				_unitOfWork.Object
			);


			var objRequest = new CrearReservaCommand(_idTest,"", ClienteId, VueloId, Fecha, Monto, ReservationStatus);

			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest, tcs.Token);
			_logger.Verify(mock => mock.Log(
				It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
				It.Is<EventId>(eventId => eventId.Id == 0),
				It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == "Error al crear Reserva"),
				It.IsAny<Exception>(),
				It.IsAny<Func<It.IsAnyType, Exception, string>>())
			, Times.Once);
		}
	}
}
