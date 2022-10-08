using ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Vuelos.CrearVuelo;
using ControlDocumentoFactura.Dominio.IntegrationEvents;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.UsesCases.Consumers
{
	public class VueloCreadoConsumer : IConsumer<VueloCreado>
	{
		private readonly IMediator _mediator;
		public const string ExchangeName = "articulo-creado-exchange";
		public const string QueueName = "articulo-creado-inventario";

		public VueloCreadoConsumer(IMediator mediator)
		{
			_mediator = mediator;
		}

		public async Task Consume(ConsumeContext<VueloCreado> context)
		{
			VueloCreado @event = context.Message;

			CrearVueloCommand command = new CrearVueloCommand(@event.Id,@event.Flight_program_id, @event.Source_airport_code,@event.Destiny_airport_code, @event.Status,@event.Information);

			await _mediator.Send(command);

		}
	}
}
