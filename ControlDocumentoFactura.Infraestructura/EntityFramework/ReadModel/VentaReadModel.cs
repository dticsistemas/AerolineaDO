using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Infraestructura.EntityFramework.ReadModel
{
	public class VentaReadModel
	{
		public Guid Id { get; set; }
		public String Estado{ get; set; }
		public decimal Monto { get; set; }
		public DateTime Fecha { get; set; }
		public int Tipo{ get; set; }		
		public Guid AsientoId { get; set; }
		public ClienteReadModel Cliente { get; set; }
		public VueloReadModel Vuelo { get; set; }
	}
}
