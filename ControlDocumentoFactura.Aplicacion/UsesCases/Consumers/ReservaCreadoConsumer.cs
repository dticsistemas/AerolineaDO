using ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Reservas;
using ControlDocumentoFactura.Dominio.Events;
using ControlDocumentoFactura.Dominio.IntegrationEvents;
using MassTransit;
using MassTransit.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.UsesCases.Consumers
{
	public class ReservaCreadoConsumer : IConsumer<ReservaCreado>
	{
		private readonly IMediator _mediator;
		public const string ExchangeName = "articulo-creado-exchange";
		public const string QueueName = "articulo-creado-inventario";

		public ReservaCreadoConsumer(IMediator mediator)
		{
			_mediator = mediator;
		}

		public async Task Consume(ConsumeContext<ReservaCreado> context)
		{
			ReservaCreado @event = context.Message;

			CrearReservaCommand command = new CrearReservaCommand(@event.Id,@event.ReservationNumber, @event.ClienteId, @event.VueloId, @event.Fecha, @event.Monto, @event.ReservationStatus);

			await _mediator.Send(command);

		}
	}
}
