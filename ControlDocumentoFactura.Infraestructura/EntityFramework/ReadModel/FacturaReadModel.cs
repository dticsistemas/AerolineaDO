using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Infraestructura.EntityFramework.ReadModel
{
	public class FacturaReadModel
	{
		public Guid Id { get; set; }
		public decimal Monto { get; set; }
		public decimal Importe { get; set; }
		public DateTime Fecha { get; set; }
		public String NroFactura { get; set; }
		public String Lugar { get; set; }
		public String NitBeneficiario { get; set; }
		public String RazonSocialBeneficiario { get; set; }
		public String NroAutorizacion { get; set; }
		public String Estado { get; set; }
		public String TipoNit { get; set; }
		public ReservaReadModel Reserva { get; set; }
		public ClienteReadModel Cliente { get; set; }
		public VueloReadModel Vuelo { get; set; }
		public ConfiguracionFacturaReadModel ConfiguracionFactura { get; set; }


	}
}
