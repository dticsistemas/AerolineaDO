using ControlDocumentoFactura.Dominio.Models.Facturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.Services.Reservas {
	public class FacturaService:IFacturaService {

		public Task<string> GenerarNroFacturaAsync() {
			int length = 13;
			Random random = new Random();
			const string characters = "0123456789";
			var codigo = new string(Enumerable.Repeat(characters,length)
			  .Select(s => s[random.Next(s.Length)]).ToArray());

			return Task.FromResult(codigo);
		}


	}
}
