using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Facturas.ListarFacturas;
using ControlDocumentoFactura.Dominio.Repositories.Facturas;
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
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Reservas.ListarReservas;
using ControlDocumentoFactura.Dominio.Repositories.Reservas;
using ControlDocumentoFactura.Dominio.Models.Clientes;
using ControlDocumentoFactura.Dominio.Models.Reservas;

namespace ControlDocumentoFactura.Test.Aplicacion.UsesCases.Queries
{
	public class ListarReservasHandler_Test
	{
		private readonly Mock<IReservaRepository> _objRepository;
		private readonly Mock<ILogger<ListarReservasQuery>> _logger;
		private readonly Mock<IUnitOfWork> _unitOfWork;
		public ListarReservasHandler_Test()
		{
			_objRepository = new Mock<IReservaRepository>();
			_logger = new Mock<ILogger<ListarReservasQuery>>();
			_unitOfWork = new Mock<IUnitOfWork>();

		}
		[Fact]
		public void ListarReservasHandler_HandleCorrectly()
		{
			var reserva = new Reserva(new Guid(), "1234", new Guid(), new Guid(), "2022-01-01", new decimal(10), "R");
			List<Reserva> parts = new List<Reserva>();
			parts.Add(reserva);
			_objRepository.Setup(objRepository => objRepository.GetAll()).ReturnsAsync(parts);
			var objHandler = new ListarReservasHandler(
			_objRepository.Object,
			_logger.Object
			);

			var objRequest = new ListarReservasQuery();
			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest, tcs.Token);
			Assert.NotNull(result);
		}
	}
}
