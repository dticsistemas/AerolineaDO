using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Infraestructura.EntityFramework.ReadModel {
		public class ReservaReadModel {
			public Guid Id { get; set; }
			public String ReservationNumber { get; set; }
			public String ReservationStatus { get; set; }
			public decimal Monto { get; set; }
			public decimal Deuda { get; set; }
			public DateTime Fecha { get; set; }
			public String TipoReserva { get; set; }
			public Guid ClienteId { get; set; }
			public Guid VueloId { get; set; }
	}
}
