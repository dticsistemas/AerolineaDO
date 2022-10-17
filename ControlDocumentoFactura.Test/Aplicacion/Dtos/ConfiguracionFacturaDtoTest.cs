using ControlDocumentoFactura.Aplicacion.Dtos.Facturas;
using ControlDocumentoFactura.Aplicacion.Dtos.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Aplicacion.Dtos
{
	public class ConfiguracionFacturaDtoTest
	{
		[Fact]
		public void FacturaDto_CheckPropertiesValid()
		{
			var idFacturaTest = new Guid();		
			var nitProveedorTest = "123456";
			var razonSocialProveedorTest = "AEROPRO";
			var nroAutorizacionTest = "1";
			var estadoTest = "P";

			var objFactura = new ConfiguracionFacturaDto();

			objFactura.Id = idFacturaTest;			
			objFactura.NitProveedor = nitProveedorTest;
			objFactura.RazonSocialProveedor = razonSocialProveedorTest;
			objFactura.NroAutorizacion = nroAutorizacionTest;
			objFactura.Estado = estadoTest;
			objFactura.Fecha = DateTime.Now;	

			Assert.Equal(idFacturaTest, objFactura.Id);
			Assert.Equal(nitProveedorTest, objFactura.NitProveedor);
			Assert.Equal(razonSocialProveedorTest, objFactura.RazonSocialProveedor);
			Assert.Equal(nroAutorizacionTest, objFactura.NroAutorizacion);
			Assert.Equal(estadoTest, objFactura.Estado);
			Assert.NotNull(objFactura.Fecha);

		}
	}
}
