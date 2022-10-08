using ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Clientes.CrearCliente;
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
	public class ClienteCreadoConsumer : IConsumer<ClienteCreado>
	{
		private readonly IMediator _mediator;
		public const string ExchangeName = "articulo-creado-exchange";
		public const string QueueName = "articulo-creado-inventario";

		public ClienteCreadoConsumer(IMediator mediator)
		{
			_mediator = mediator;
		}

		public async Task Consume(ConsumeContext<ClienteCreado> context)
		{
			ClienteCreado @event = context.Message;

			CrearClienteCommand command = new CrearClienteCommand(@event.Id,@event.Name,@event.LastName,@event.Passport, @event.NeedAssistance,@event.Nit,@event.Email,@event.Phone);

			await _mediator.Send(command);

		}
	}
}
