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
using ControlDocumentoFactura.Dominio.Repositories.Vuelos;
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Vuelos.BuscarVueloPorId;

namespace ControlDocumentoFactura.Test.Aplicacion.UsesCases.Queries
{
	public class BuscarVueloPorIdHandler_Test
	{
		private readonly Mock<IVueloRepository> _objRepository;
		private readonly Mock<ILogger<ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Vuelos.BuscarVueloPorId.BuscarVueloPorIdQuery>> _logger;
		private readonly Mock<IUnitOfWork> _unitOfWork;
		private Guid idTest = new();
		public BuscarVueloPorIdHandler_Test()
		{
			_objRepository = new Mock<IVueloRepository>();
			_logger = new Mock<ILogger<BuscarVueloPorIdQuery>>();
			_unitOfWork = new Mock<IUnitOfWork>();

		}
		[Fact]
		public void BuscarClientePorIdHandler_HandleCorrectly()
		{
			var objHandler = new BuscarVueloPorIdHandler(
			_objRepository.Object,
			_logger.Object
			);

			var objRequest = new BuscarVueloPorIdQuery(Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"));
			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest, tcs.Token);
			Assert.Null(result.Result);
		}
		[Fact]
		public void BuscarClientePorIdHandler_Handle_Fail()
		{
			// Failing by returning null values

			var objHandler = new BuscarVueloPorIdHandler(
			_objRepository.Object,
			_logger.Object
			);

			var objRequest = new BuscarVueloPorIdQuery(idTest);
			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest, tcs.Token);
			_logger.Verify(mock => mock.Log(
				It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
				It.Is<EventId>(eventId => eventId.Id == 0),
				It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == "Error al obtener Vuelo Id"),
				It.IsAny<Exception>(),
				It.IsAny<Func<It.IsAnyType, Exception, string>>())
			, Times.Once);
		}
	}
}
