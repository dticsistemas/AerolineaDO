using ControlDocumentoFactura.Dominio.Events;
using MassTransit;
using MediatR;
using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.UsesCases.DomainEventHandler
{
	public class PublishIntegrationEventWhenReservaCreadoHandler /*: INotificationHandler<ConfirmedDomainEvent<ReservaCreado>>*/
	{
		private readonly IPublishEndpoint _publishEndpoint;

		public PublishIntegrationEventWhenReservaCreadoHandler(IPublishEndpoint publishEndpoint)
		{
			_publishEndpoint = publishEndpoint;
		}
		/*
	public async Task Handle(ConfirmedDomainEvent<ReservaCreado> notification, CancellationToken cancellationToken)
	{
			/*SharedKernel.IntegrationEvents.ReservaCreado evento = new SharedKernel.IntegrationEvents.ReservaCreado()
			{
				ReservaId = notification.DomainEvent.ReservaId,
				Nombre = notification.DomainEvent.Nombre,
				PrecioVenta = 0// notification.DomainEvent.PrecioVenta
		};
		await _publishEndpoint.Publish<ReservaCreado>(evento);
			

	}*/
	}

}
