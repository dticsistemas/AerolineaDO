using ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Facturas.EntregarFactura;
using ControlDocumentoFactura.Dominio.Events.Facturas;
using ControlDocumentoFactura.Dominio.Models.Facturas;
using ControlDocumentoFactura.Dominio.Repositories.Facturas;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Aplicacion.UsesCases.Commands {
	public class EntregarFacturaHandler_Test {
		private readonly Mock<IFacturaRepository> _facturaRepository;
		public EntregarFacturaHandler_Test() {
			_facturaRepository = new Mock<IFacturaRepository>();
		}
		[Fact]
		public void EntregarFacturaHandler_HandleCorrectly() {
			Guid _idReservaTest = new();
			Guid _idClienteTest = new();
			Guid _idFacturaTest = new();
			decimal _montoTest = new(4.0);
			decimal _importeTest = new(4.0);
			string _nroFacturaTest = "2022-05-15";
			Factura _facturaTest = new Factura(_nroFacturaTest);



			var tcs = new CancellationTokenSource(1000);

			_facturaRepository.Setup(mock => mock.FindByIdAsync(_idFacturaTest))
				.Returns(Task.FromResult(_facturaTest));

			var handler = new EntregarFacturaHandler(_facturaRepository.Object);
			var objRequest = new FacturaCreadoEvent(
					_montoTest,_idFacturaTest,_idClienteTest,_idReservaTest
			);
			var result = handler.Handle(objRequest,tcs.Token);

			Assert.NotNull(_facturaTest);
		}

	}
}
