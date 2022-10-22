using ControlDocumentoFactura.Aplicacion.Dtos.Pagos;
using ControlDocumentoFactura.Aplicacion.Dtos.Vuelos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Vuelos.ListarVuelos
{
	public class ListarVuelosQuery : IRequest<ICollection<VueloDto>>
	{

		public ListarVuelosQuery() { }

	}
}
