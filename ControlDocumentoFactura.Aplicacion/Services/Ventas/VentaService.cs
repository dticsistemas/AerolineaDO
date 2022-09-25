using ControlDocumentoFactura.Aplicacion.Services.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.Services.Ventas
{
	public class VentaService : IVentaService
	{

		public Task<string> GenerarNroVentaAsync()
		{
			int length = 13;
			Random random = new Random();
			const string characters = "0123456789";
			var codigo = new string(Enumerable.Repeat(characters, length)
					.Select(s => s[random.Next(s.Length)]).ToArray());

			return Task.FromResult(codigo);
		}
	}
}
