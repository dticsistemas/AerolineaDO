using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Infraestructura.EntityFramework.ReadModel
{
	public class ConfiguracionFacturaReadModel
	{
		public Guid Id { get; set; }
		public DateTime Fecha { get; set; }
		public String NitProveedor { get; set; }
		public String RazonSocialProveedor { get; set; }
		public String NroAutorizacion { get; set; }
		public string Estado { get; set; }


	}
}
