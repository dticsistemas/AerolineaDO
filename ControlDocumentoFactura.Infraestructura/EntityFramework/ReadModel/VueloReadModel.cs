using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Infraestructura.EntityFramework.ReadModel {
		public class VueloReadModel {
				public Guid Id { get; set; }
				public int Cantidad { get; set; }
				public String Detalle { get; set; }
				public decimal PrecioPasaje { get; set; }



		}
}
