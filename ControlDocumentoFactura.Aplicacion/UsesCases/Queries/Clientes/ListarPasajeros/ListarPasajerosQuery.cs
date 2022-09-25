using ControlDocumentoFactura.Aplicacion.Dtos.Clientes;
using ControlDocumentoFactura.Aplicacion.Dtos.Vuelos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Clientes.ListarPasajeros
{
	public class ListarPasajerosQuery : IRequest<ICollection<ClienteDto>>
	{

		public ListarPasajerosQuery() { }

	}
}
