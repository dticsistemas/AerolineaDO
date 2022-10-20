using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Clientes.BuscarClientePorId;
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
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Reservas.BuscarReservaPorId;

namespace ControlDocumentoFactura.Test.Aplicacion.UsesCases.Queries
{
	public class BuscarReservaPorIdHandler_Test
	{
		private readonly Mock<IReservaRepository> _objRepository;
		private readonly Mock<ILogger<BuscarReservaPorIdQuery>> _logger;
		private readonly Mock<IUnitOfWork> _unitOfWork;
		private Guid idTest = new();
		public BuscarReservaPorIdHandler_Test()
		{
			_objRepository = new Mock<IReservaRepository>();
			_logger = new Mock<ILogger<BuscarReservaPorIdQuery>>();
			_unitOfWork = new Mock<IUnitOfWork>();

		}
		[Fact]
		public void BuscarReservaPorIdHandler_HandleCorrectly()
		{
			var objHandler = new BuscarReservaPorIdHandler(
			_objRepository.Object,
			_logger.Object
			);

			var objRequest = new BuscarReservaPorIdQuery(Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"));
			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest, tcs.Token);
			Assert.Null(result.Result);
		}
		[Fact]
		public void BuscarReservaPorIdHandler_Handle_Fail()
		{
			// Failing by returning null values

			var objHandler = new BuscarReservaPorIdHandler(
			_objRepository.Object,
			_logger.Object
			);

			var objRequest = new BuscarReservaPorIdQuery(idTest);
			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest, tcs.Token);
			_logger.Verify(mock => mock.Log(
				It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
				It.Is<EventId>(eventId => eventId.Id == 0),
				It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == "Error al obtener Reserva Id"),
				It.IsAny<Exception>(),
				It.IsAny<Func<It.IsAnyType, Exception, string>>())
			, Times.Once);
		}
	}
}
