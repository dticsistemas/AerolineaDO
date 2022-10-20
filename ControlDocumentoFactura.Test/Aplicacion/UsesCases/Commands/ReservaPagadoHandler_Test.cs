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

namespace ControlDocumentoFactura.Test.Aplicacion.UsesCases.Commands
{
	public class ReservaPagadoHandler_Test
	{
		private readonly Mock<IReservaRepository> _objRepository;
		private readonly Mock<ILogger<ReservaPagadoHandler>> _logger;
		private readonly Mock<IUnitOfWork> _unitOfWork;

		private Guid _idTest = new();
		private Guid reservaId = new();
		private String transactionNumber;
		private decimal amount = new(10);

		public ReservaPagadoHandler_Test()
		{
			_objRepository = new Mock<IReservaRepository>();
			_logger = new Mock<ILogger<ReservaPagadoHandler>>();
			_unitOfWork = new Mock<IUnitOfWork>();

		}
		[Fact]
		public void CrearCliente_HandleCorrectly()
		{
			var objHandler = new ReservaPagadoHandler(
				_objRepository.Object,
				_logger.Object,
				_unitOfWork.Object
			);

			var objRequest = new ReservaPagadoCommand(_idTest,reservaId,transactionNumber,amount);
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

			var objHandler = new ReservaPagadoHandler(
				_objRepository.Object,
				_logger.Object,
				_unitOfWork.Object
			);

			var objRequest = new ReservaPagadoCommand(_idTest, reservaId, transactionNumber, amount);
			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest, tcs.Token);
			_logger.Verify(mock => mock.Log(
				It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
				It.Is<EventId>(eventId => eventId.Id == 0),
				It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == "Error al actualizar Estado Reserva Pagada"),
				It.IsAny<Exception>(),
				It.IsAny<Func<It.IsAnyType, Exception, string>>())
			, Times.Once);
		}
	}
}
