using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.Dtos.Pagos {
	public class PagoDto {
		public Guid Id { get; set; }
		public Guid ReservaId { get; set; }
		public decimal Monto { get; set; }
		public DateTime Fecha { get; set; }
		public String CodComprobante { get; set; }
	}
}
