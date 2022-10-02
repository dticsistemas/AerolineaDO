using ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Clientes.CrearCliente;
using ControlDocumentoFactura.Dominio.Models.Clientes;
using ControlDocumentoFactura.Dominio.Repositories.Clientes;
using ControlDocumentoFactura.Dominio.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ControlDocumentoFactura.Dominio.Repositories.Reservas;
using ControlDocumentoFactura.Dominio.Models.Reservas;
using ControlDocumentoFactura.Dominio.Models.Vuelos;

namespace ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Reservas
{
	public class CrearReservaHandler : IRequestHandler<CrearReservaCommand, Guid>
	{
		private readonly IReservaRepository _reservaRepository;
		private readonly ILogger<CrearReservaHandler> _logger;
		private readonly IUnitOfWork _unitOfWork;

		public CrearReservaHandler(IReservaRepository reservaRepository, ILogger<CrearReservaHandler> logger, IUnitOfWork unitOfWork)
		{
			_reservaRepository = reservaRepository;
			_logger = logger;
			_unitOfWork = unitOfWork;
		}

		public async Task<Guid> Handle(CrearReservaCommand request, CancellationToken cancellationToken)
		{
			try
			{
				Reserva objReserva = new Reserva(request.Id, request.ReservationNumber, request.ClienteId, request.VueloId, request.Fecha, request.Monto, request.ReservationStatus);

				await _reservaRepository.CreateAsync(objReserva);
				await _unitOfWork.Commit();

				return objReserva.Id;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error al crear Reserva");
			}
			return Guid.Empty;
		}
	}
}
