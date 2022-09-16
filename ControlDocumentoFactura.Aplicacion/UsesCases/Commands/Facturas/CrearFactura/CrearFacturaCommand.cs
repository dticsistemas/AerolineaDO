using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Facturas.CrearFactura {
	public class CrearFacturaCommand:IRequest<Guid> {
		public decimal Monto { get; set; }
		public decimal Importe { get; set; }
		public String Lugar { get; set; }
		public String NitBeneficiario { get; set; }
		public String RazonSocialBeneficiario { get; set; }
		public Guid ReservaId { get; set; }
		public Guid ClienteId { get; set; }
		public Guid VueloId { get; set; }



		private CrearFacturaCommand() { }
		public CrearFacturaCommand(decimal monto,decimal importe,string lugar,string nitBeneficiario,string razonSocialBeneficiario,Guid clienteId,Guid vueloId,Guid reservaId) {
			Monto = monto;
			Importe = importe;
			Lugar = lugar;
			NitBeneficiario = nitBeneficiario;
			RazonSocialBeneficiario = razonSocialBeneficiario;
			ClienteId = clienteId;
			VueloId = vueloId;
			ReservaId = reservaId;

		}
	}

}
