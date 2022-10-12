using ControlDocumentoFactura.Dominio.Models.Reservas;
using ControlDocumentoFactura.Dominio.Repositories.Reservas;
using ControlDocumentoFactura.Dominio.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ControlDocumentoFactura.Dominio.Repositories.Facturas;

namespace ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Reservas
{
	public class ReservaPagadoHandler : IRequestHandler<ReservaPagadoCommand, Guid>
	{
		private readonly IReservaRepository _reservaRepository;
		private readonly ILogger<ReservaPagadoHandler> _logger;
		private readonly IUnitOfWork _unitOfWork;

		public ReservaPagadoHandler(IReservaRepository reservaRepository, ILogger<ReservaPagadoHandler> logger, IUnitOfWork unitOfWork)
		{
			_reservaRepository = reservaRepository;
			_logger = logger;
			_unitOfWork = unitOfWork;
		}

		public async Task<Guid> Handle(ReservaPagadoCommand request, CancellationToken cancellationToken)
		{
			try
			{
				Reserva objReserva = await _reservaRepository.FindByIdAsync(request.ReservaId);
				objReserva.ActualizarReservaPagada();
				//await _reservaRepository.UpdateAsync(objReserva);
				await _unitOfWork.Commit();

				return objReserva.Id;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error al actualizar Estado Reserva Pagada");
			}
			return Guid.Empty;
		}
	}
}
