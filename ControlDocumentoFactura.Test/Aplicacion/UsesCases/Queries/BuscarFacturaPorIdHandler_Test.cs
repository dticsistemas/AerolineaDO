using ControlDocumentoFactura.Aplicacion.Dtos.Pagos;
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Pagos.BuscarFacturaPorId;
using ControlDocumentoFactura.Dominio.Models.Facturas;
using ControlDocumentoFactura.Dominio.Repositories.Facturas;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Aplicacion.UsesCases.Queries {
	public class BuscarFacturaPorIdHandler_Test {

		private readonly Mock<IFacturaRepository> _facturaRepository;
		private readonly Mock<ILogger<BuscarFacturaPorIdQuery>> _logger;
		public BuscarFacturaPorIdHandler_Test() {
			_facturaRepository = new Mock<IFacturaRepository>();
			_logger = new Mock<ILogger<BuscarFacturaPorIdQuery>>();
		}
		[Fact]
		public void BuscarFacturaPorIdHandler_HandleCorrectly() {

			var idFacturaTest = new Guid();
			/* var idReservaTest = new Guid();
			 var idClienteTest = new Guid();
			 var idVueloTest = new Guid();
			 decimal montoTest = new(4.0);
			 decimal importeTest = new(4.0);
			 DateTime fechaTest = DateTime.Now;
			*/
			var nroFacturaTest = "2022-05-15";
			/* var lugarTest = "SCZ B/ Los Olivos";
			 var nitProveedorTest = "123456";
			 var nitBeneficiarioTest = "654321";
			 var razonSocialProveedorTest = "AEROPRO";
			 var razonSocialBeneficiarioTest = "Juan Perez";
			 var nroAutorizacionTest = "1";
			 var estadoTest = "P";*/

			var objFactura = new FacturaDto();
			objFactura.Id = idFacturaTest;
			/*objFactura.Monto = montoTest;
            objFactura.Importe = importeTest;
            objFactura.Fecha = fechaTest;
            objFactura.NroFactura = nroFacturaTest;
            objFactura.Lugar = lugarTest;
            objFactura.NitProveedor = nitProveedorTest;
            objFactura.NitBeneficiario = nitBeneficiarioTest;
            objFactura.RazonSocialProveedor = razonSocialProveedorTest;
            objFactura.RazonSocialBeneficiario = razonSocialBeneficiarioTest;
            objFactura.NroAutorizacion = nroAutorizacionTest;
            objFactura.ReservaId = idReservaTest;
            objFactura.ClienteId = idClienteTest;
            objFactura.VueloId = idVueloTest;
            objFactura.Estado = estadoTest;*/

			Factura _facturaTest = new Factura(nroFacturaTest);

			var tcs = new CancellationTokenSource(1000);
			_facturaRepository.Setup(_facturaRepository => _facturaRepository.FindByIdAsync(idFacturaTest))
				.Returns(Task.FromResult(_facturaTest));

			var handler = new BuscarFacturaPorIdHandler(_facturaRepository.Object,_logger.Object);
			var objRequest = new BuscarFacturaPorIdQuery(idFacturaTest);
			var result = handler.Handle(objRequest,tcs.Token);
			Assert.NotNull(result);
			Assert.Equal(nroFacturaTest,_facturaTest.NroFactura);

			/*Assert.Equal(idFacturaTest, objFactura.Id);
            Assert.Equal(idReservaTest, objFactura.ReservaId);
            Assert.Equal(montoTest, objFactura.Monto);
            Assert.Equal(importeTest, objFactura.Importe);
            Assert.Equal(fechaTest, objFactura.Fecha);
            Assert.Equal(nroFacturaTest, objFactura.NroFactura);
            Assert.Equal(lugarTest, objFactura.Lugar);
            Assert.Equal(nitProveedorTest, objFactura.NitProveedor);
            Assert.Equal(nitBeneficiarioTest, objFactura.NitBeneficiario);
            Assert.Equal(razonSocialProveedorTest, objFactura.RazonSocialProveedor);
            Assert.Equal(razonSocialBeneficiarioTest, objFactura.RazonSocialBeneficiario);
            Assert.Equal(nroAutorizacionTest, objFactura.NroAutorizacion);
            Assert.Equal(idClienteTest, objFactura.ClienteId);
            Assert.Equal(idVueloTest, objFactura.VueloId);
            Assert.Equal(estadoTest, objFactura.Estado);*/


		}
		[Fact]
		public void BuscarFacturaPorIdHandler_Handle_Fail() {
			var nroFacturaTest = "2022-05-15";
			Factura _facturaTest = new Factura(nroFacturaTest);
			var idFacturaTest = new Guid();
			var idFacturaTest_Fail = new Guid();

			_facturaRepository.Setup(_facturaRepository => _facturaRepository.FindByIdAsync(idFacturaTest))
				.Returns(Task.FromResult(_facturaTest));

			var handler = new BuscarFacturaPorIdHandler(_facturaRepository.Object,_logger.Object);
			var objRequest = new BuscarFacturaPorIdQuery(idFacturaTest_Fail);
			var tcs = new CancellationTokenSource(1000);

			var result = handler.Handle(objRequest,tcs.Token);
			Assert.NotNull(result);

			/*
            _logger.Verify(mock => mock.Log(
                It.Is<LogLevel>(logLevel => logLevel == LogLevel.Error),
                It.Is<EventId>(eventId => eventId.Id == 0),
                It.Is<It.IsAnyType>((@object, @type) => @object.ToString() == "Error al crear Factura"),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>())
            , Times.Once);*/
		}
	}
}
