using ControlDocumentoFactura.Aplicacion.Dtos.Pagos;
using ControlDocumentoFactura.Aplicacion.Dtos.Vuelos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Vuelos.BuscarVueloPorId
{
	public class BuscarVueloPorIdQuery : IRequest<VueloDto>
	{
		public Guid Id { get; set; }
		public BuscarVueloPorIdQuery(Guid id)
		{
			Id = id;
		}
		public BuscarVueloPorIdQuery() { }

	}
}
