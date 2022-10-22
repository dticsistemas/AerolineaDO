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
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Clientes.ListarPasajeros;
using ControlDocumentoFactura.Aplicacion.Dtos.Clientes;
using ControlDocumentoFactura.Dominio.Models.Clientes;
using static System.Collections.Specialized.BitVector32;

namespace ControlDocumentoFactura.Test.Aplicacion.UsesCases.Queries
{
	public class ListarPasajerosHandler_Test
	{
		private readonly Mock<IClienteRepository> _objRepository;
		private readonly Mock<ILogger<ListarPasajerosQuery>> _logger;
		private readonly Mock<IUnitOfWork> _unitOfWork;
		public ListarPasajerosHandler_Test()
		{
			_objRepository = new Mock<IClienteRepository>();
			_logger = new Mock<ILogger<ListarPasajerosQuery>>();
			_unitOfWork = new Mock<IUnitOfWork>();

		}
		[Fact]
		public void ListarPasajerosHandler_HandleCorrectly()
		{
			var cliente = new Cliente(new Guid(), "nombre", "lasstname", "123", "true", "456", "emailo@aaa.com", "789");
			List<Cliente> parts = new List<Cliente>();
			parts.Add(cliente);
			_objRepository.Setup(objRepository => objRepository.GetAll()).ReturnsAsync(parts);

			var objHandler = new ListarPasajerosHandler(
			_objRepository.Object,
			_logger.Object
			);

			var objRequest = new ListarPasajerosQuery();
			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest, tcs.Token);
			Assert.NotNull(result);
		}

	}
}
