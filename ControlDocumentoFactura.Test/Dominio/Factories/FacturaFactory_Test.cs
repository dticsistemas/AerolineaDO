using ControlDocumentoFactura.Dominio.Factories.Facturas;
using ControlDocumentoFactura.Dominio.Models.Facturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Dominio.Factories {
	public class FacturaFactory_Test {
		[Fact]
		public void FacturaFactory_CheckPropertiesValid() {
			decimal montoTest = new(40);
			string nroFacturaTest = "12345657890123";
			FacturaFactory _facturaFactory = new FacturaFactory();

			Factura objFactura = _facturaFactory.Create(nroFacturaTest);

			Assert.Equal(Guid.Empty,objFactura.ReservaId);
			Assert.Equal(Guid.Empty,objFactura.ClienteId);
			Assert.Equal(Guid.Empty,objFactura.VueloId);
			//Assert.Equal(new decimal(0.0), (decimal)objFactura.Monto);
			//Assert.Equal(new decimal(0.0), (decimal)objFactura.Importe);
			Assert.Equal(DateTime.MinValue,objFactura.Fecha);
			Assert.Equal(nroFacturaTest,objFactura.NroFactura);
			Assert.Null(objFactura.Lugar);
			Assert.Null(objFactura.NroAutorizacion);
			Assert.Null(objFactura.RazonSocialBeneficiario);
			Assert.Null(objFactura.RazonSocialProveedor);
			Assert.Null(objFactura.NitBeneficiario);
			Assert.Null(objFactura.NitProveedor);
			Assert.Null(objFactura.Estado);
		}
	}
}
