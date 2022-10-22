using SharedKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Dominio.IntegrationEvents
{
	public record ReservaPagado : IntegrationEvent
	{
		public Guid Id { get; set; }
		public Guid ReservaId { get; set; }
		public String TransactionNumber { get; set; }
		public decimal Amount { get; set; }

	}
}
