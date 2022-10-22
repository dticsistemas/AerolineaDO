using ControlDocumentoFactura.Dominio.Events.Facturas;
using ControlDocumentoFactura.Dominio.Models.Reservas;
using ControlDocumentoFactura.Dominio.Repositories.Reservas;
using MediatR;
using SharedKernel.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Reservas
{
	public class UpdateReservaEstadoFacturaCreadoHandler : INotificationHandler<FacturaCreadoEvent>
	{
		private readonly IReservaRepository _reservaRepository;

		public UpdateReservaEstadoFacturaCreadoHandler(IReservaRepository reservaRepository)
		{
			_reservaRepository = reservaRepository;
		}

		public async Task Handle(FacturaCreadoEvent notification, CancellationToken cancellationToken)
		{
			Reserva objProducto = await _reservaRepository.FindByIdAsync(notification.ReservaId);
			objProducto.ActualizarReservaFacturada();

			await _reservaRepository.UpdateAsync(objProducto);

		}
	}
}
