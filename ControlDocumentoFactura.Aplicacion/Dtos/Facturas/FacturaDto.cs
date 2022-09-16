using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.Dtos.Pagos {
	public class FacturaDto {
		public Guid Id { get; set; }
		public decimal Monto { get; set; }
		public decimal Importe { get; set; }
		public DateTime Fecha { get; set; }
		public String NroFactura { get; set; }
		public String Lugar { get; set; }
		public String NitProveedor { get; set; }
		public String RazonSocialProveedor { get; set; }
		public String NitBeneficiario { get; set; }
		public String RazonSocialBeneficiario { get; set; }
		public String NroAutorizacion { get; set; }
		public String Estado { get; set; }
		public Guid ReservaId { get; set; }
		public Guid ClienteId { get; set; }
		public Guid VueloId { get; set; }



	}
}
