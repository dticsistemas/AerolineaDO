using ControlDocumentoFactura.Dominio.Models.Transacciones;
using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Dominio.Events
{
	public record TransaccionConfirmada : DomainEvent
	{

		public Guid TransaccionId { get; init; }
		public TipoTransaccion Tipo { get; set; }

		public List<DetalleTransaccionConfirmada> Detalle { get; init; }

		public TransaccionConfirmada(Guid transaccionId, List<DetalleTransaccionConfirmada> detalle, DateTime occuredOn) : base(occuredOn)
		{
			TransaccionId = transaccionId;
			Detalle = detalle;
		}

		public record DetalleTransaccionConfirmada(decimal Cantidad, Guid ProductoId, decimal Costo);
	}
}
