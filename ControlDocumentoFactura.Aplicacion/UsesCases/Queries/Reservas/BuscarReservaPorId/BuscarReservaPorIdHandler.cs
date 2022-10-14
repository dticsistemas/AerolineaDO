using ControlDocumentoFactura.Aplicacion.Dtos.Pagos;
using ControlDocumentoFactura.Aplicacion.Dtos.Reservas;
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Pagos.BuscarFacturaPorId;
using ControlDocumentoFactura.Dominio.Models.Facturas;
using ControlDocumentoFactura.Dominio.Models.Reservas;
using ControlDocumentoFactura.Dominio.Repositories.Facturas;
using ControlDocumentoFactura.Dominio.Repositories.Reservas;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Reservas.BuscarReservaPorId
{
	public class BuscarReservaPorIdHandler : IRequestHandler<BuscarReservaPorIdQuery, ReservaDto>
	{
		private readonly IReservaRepository _reservaRepository;
		private readonly ILogger<BuscarReservaPorIdQuery> _logger;
		public BuscarReservaPorIdHandler(IReservaRepository reservaRepository, ILogger<BuscarReservaPorIdQuery> logger)
		{
			_reservaRepository = reservaRepository;
			_logger = logger;
		}

		public async Task<ReservaDto> Handle(BuscarReservaPorIdQuery request, CancellationToken cancellationToken)
		{
			ReservaDto result = null;
			try
			{
				Reserva objReserva = await _reservaRepository.FindByIdAsync(request.Id);

				result = new ReservaDto()
				{
					Id = objReserva.Id,
					ReservationNumber = objReserva.ReservationNumber,
					ReservationStatus = objReserva.ReservationStatus,
					Monto = objReserva.Monto,
					Deuda = objReserva.Deuda,
					Fecha = objReserva.Fecha,
					TipoReserva = objReserva.TipoReserva,
					ClienteId = objReserva.ClienteId,
					VueloId = objReserva.VueloId
				};

			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error al obtener Reserva Id");
			}

			return result;
		}
	}
}
