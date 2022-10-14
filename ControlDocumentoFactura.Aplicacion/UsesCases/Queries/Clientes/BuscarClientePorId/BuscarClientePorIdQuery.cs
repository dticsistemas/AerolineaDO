using ControlDocumentoFactura.Aplicacion.Dtos.Clientes;
using ControlDocumentoFactura.Aplicacion.Dtos.Pagos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Clientes.BuscarClientePorId
{
	public class BuscarClientePorIdQuery : IRequest<ClienteDto>
	{
		public Guid Id { get; set; }
		public BuscarClientePorIdQuery(Guid id)
		{
			Id = id;
		}
		public BuscarClientePorIdQuery() { }

	}
}
