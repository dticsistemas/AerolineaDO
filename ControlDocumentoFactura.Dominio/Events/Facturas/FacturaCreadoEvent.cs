using ControlDocumentoFactura.Dominio.Models.Facturas.ValueObjetcs;
using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Dominio.Events.Facturas {
	public record FacturaCreadoEvent:DomainEvent {

		public decimal Monto { get; }
		public Guid FacturaId { get; }
		public Guid ClienteId { get; }
		public Guid ReservaId { get; }

		public FacturaCreadoEvent(decimal monto,Guid facturaId,Guid clienteId,Guid reservaId
			) : base(DateTime.Now) {
			Monto = monto;
			FacturaId = facturaId;
			ClienteId = clienteId;
			ReservaId = reservaId;

		}
	}
}
