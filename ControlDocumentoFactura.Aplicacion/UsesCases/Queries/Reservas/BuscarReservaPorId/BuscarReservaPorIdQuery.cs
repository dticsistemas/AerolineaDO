using ControlDocumentoFactura.Aplicacion.Dtos.Pagos;
using ControlDocumentoFactura.Aplicacion.Dtos.Reservas;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Reservas.BuscarReservaPorId
{
	public class BuscarReservaPorIdQuery : IRequest<ReservaDto>
	{
		public Guid Id { get; set; }
		public BuscarReservaPorIdQuery(Guid id)
		{
			Id = id;
		}
		public BuscarReservaPorIdQuery() { }

	}
}
