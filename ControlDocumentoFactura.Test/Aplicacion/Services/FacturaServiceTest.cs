using ControlDocumentoFactura.Aplicacion.Services.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Aplicacion.Services {
	public class FacturaServiceTest {
		[Theory]
		[InlineData("ABC",false)]
		[InlineData("123",false)]
		[InlineData("456",false)]
		[InlineData("789",false)]
		[InlineData("",false)]
		[InlineData(null,false)]
		[InlineData("2022",false)]
		public async void GenerarNroFactura_CheckValidData(string expectedNroFactura,bool isEqual) {
			var facturaService = new FacturaService();
			string nroFactura = await facturaService.GenerarNroFacturaAsync();
			if( isEqual ) {
				Assert.Equal(expectedNroFactura,nroFactura);
			}
			else {
				Assert.NotEqual(expectedNroFactura,nroFactura);
			}

		}
	}
}
