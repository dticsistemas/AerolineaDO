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
using ControlDocumentoFactura.Dominio.Repositories.Vuelos;
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Vuelos.ListarVuelos;
using ControlDocumentoFactura.Infraestructura.EntityFramework.Repository;
using ControlDocumentoFactura.Dominio.Models.Reservas;
using ControlDocumentoFactura.Dominio.Models.Vuelos;

namespace ControlDocumentoFactura.Test.Aplicacion.UsesCases.Queries
{
	public class ListarVuelosHandler_Test
	{
		private readonly Mock<IVueloRepository> _objRepository;
		private readonly Mock<ILogger<ListarVuelosQuery>> _logger;
		private readonly Mock<IUnitOfWork> _unitOfWork;
		public ListarVuelosHandler_Test()
		{
			_objRepository = new Mock<IVueloRepository>();
			_logger = new Mock<ILogger<ListarVuelosQuery>>();
			_unitOfWork = new Mock<IUnitOfWork>();

		}
		[Fact]
		public void ListarVuelosHandler_HandleCorrectly()
		{
			var vuelo = new Vuelo(new Guid(), 10, "MIA", "LPZ", "A", "info");
			List<Vuelo> parts = new List<Vuelo>();
			parts.Add(vuelo);
			_objRepository.Setup(objRepository => objRepository.GetAll()).ReturnsAsync(parts);
			var objHandler = new ListarVuelosHandler(
			_objRepository.Object,
			_logger.Object
			);

			var objRequest = new ListarVuelosQuery();
			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest, tcs.Token);
			Assert.NotNull(result);
		}
	}
}
