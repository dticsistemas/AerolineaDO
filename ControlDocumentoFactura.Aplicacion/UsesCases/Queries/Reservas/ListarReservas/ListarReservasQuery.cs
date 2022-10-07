using ControlDocumentoFactura.Aplicacion.Dtos.Reservas;
using ControlDocumentoFactura.Aplicacion.Dtos.Vuelos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Reservas.ListarReservas
{
	public class ListarReservasQuery : IRequest<ICollection<ReservaDto>>
	{
		public ListarReservasQuery() { }

	}
}
