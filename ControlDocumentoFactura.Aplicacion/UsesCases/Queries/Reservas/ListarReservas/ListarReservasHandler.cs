using ControlDocumentoFactura.Aplicacion.Dtos.Reservas;
using ControlDocumentoFactura.Aplicacion.Dtos.Vuelos;
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Vuelos.ListarVuelos;
using ControlDocumentoFactura.Dominio.Repositories.Reservas;
using ControlDocumentoFactura.Dominio.Repositories.Vuelos;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Reservas.ListarReservas
{
	public class ListarReservasHandler : IRequestHandler<ListarReservasQuery, ICollection<ReservaDto>>
	{
		private readonly IReservaRepository _reservaRepository;
		private readonly ILogger<ListarReservasQuery> _logger;
		public ListarReservasHandler(IReservaRepository reservaRepository, ILogger<ListarReservasQuery> logger)
		{
			_reservaRepository = reservaRepository;
			_logger = logger;
		}

		public async Task<ICollection<ReservaDto>> Handle(ListarReservasQuery request, CancellationToken cancellationToken)
		{

			var reservaList = await _reservaRepository.GetAll();

			var result = new List<ReservaDto>();

			foreach (var objReserva in reservaList)
			{
				var reservaDto = new ReservaDto()
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

				result.Add(reservaDto);
			}

			return result;
		}
	}
}
