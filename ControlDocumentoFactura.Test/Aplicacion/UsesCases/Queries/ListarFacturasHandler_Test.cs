using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Clientes.ListarPasajeros;
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
using ControlDocumentoFactura.Dominio.Repositories.Facturas;
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Facturas.ListarFacturas;
using ControlDocumentoFactura.Dominio.Models.Facturas;

namespace ControlDocumentoFactura.Test.Aplicacion.UsesCases.Queries
{
	public class ListarFacturasHandler_Test
	{
		private readonly Mock<IFacturaRepository> _objRepository;
		private readonly Mock<ILogger<ListarFacturasQuery>> _logger;
		private readonly Mock<IUnitOfWork> _unitOfWork;
		public ListarFacturasHandler_Test()
		{
			_objRepository = new Mock<IFacturaRepository>();
			_logger = new Mock<ILogger<ListarFacturasQuery>>();
			_unitOfWork = new Mock<IUnitOfWork>();

		}
		[Fact]
		public void ListarFacturasHandler_HandleCorrectly()
		{
			var factura = new Factura("789");
			List<Factura> parts = new List<Factura>();
			parts.Add(factura);
			_objRepository.Setup(objRepository => objRepository.GetAll()).ReturnsAsync(parts);

			var objHandler = new ListarFacturasHandler(
			_objRepository.Object,
			_logger.Object
			);

			var objRequest = new ListarFacturasQuery();
			var tcs = new CancellationTokenSource(1000);
			var result = objHandler.Handle(objRequest, tcs.Token);
			Assert.NotNull(result);
		}
	}
}
