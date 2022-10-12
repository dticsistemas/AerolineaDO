using SharedKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Dominio.IntegrationEvents
{
	public record ReservaCreado:IntegrationEvent
	{
			public Guid Id { get; set; }
			public String ReservationNumber { get; set; }
			public String ReservationStatus { get; set; }
			public decimal Monto { get; set; }
			public decimal Deuda { get; set; }
			public string Fecha { get; set; }
			public String TipoReserva { get; set; }
			public Guid ClienteId { get; set; }
			public Guid VueloId { get; set; }

	}
}
