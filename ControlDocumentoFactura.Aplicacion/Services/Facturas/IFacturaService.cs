using ControlDocumentoFactura.Dominio.Models.Facturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.Services.Reservas {
	public interface IFacturaService {
		Task<string> GenerarNroFacturaAsync();

	}
}
