using ControlDocumentoFactura.Dominio.Models.Facturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Dominio.Factories.Facturas {
	public interface IFacturaFactory {
		Factura Create(string nroComprobante);
	}
}
