using ControlDocumentoFactura.Aplicacion.Dtos.Clientes;
using ControlDocumentoFactura.Aplicacion.Dtos.Pagos;
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Pagos.BuscarFacturaPorId;
using ControlDocumentoFactura.Dominio.Models.Clientes;
using ControlDocumentoFactura.Dominio.Models.Facturas;
using ControlDocumentoFactura.Dominio.Repositories.Clientes;
using ControlDocumentoFactura.Dominio.Repositories.Facturas;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Clientes.BuscarClientePorId
{
	public class BuscarClientePorIdHandler : IRequestHandler<BuscarClientePorIdQuery, ClienteDto>
	{
		private readonly IClienteRepository _clienteRepository;
		private readonly ILogger<BuscarClientePorIdQuery> _logger;
		public BuscarClientePorIdHandler(IClienteRepository clienteRepository, ILogger<BuscarClientePorIdQuery> logger)
		{
			_clienteRepository = clienteRepository;
			_logger = logger;
		}

		public async Task<ClienteDto> Handle(BuscarClientePorIdQuery request, CancellationToken cancellationToken)
		{
			ClienteDto result = null;
			try
			{
				Cliente objCliente = await _clienteRepository.FindByIdAsync(request.Id);

				result = new ClienteDto()
				{
					Id =objCliente.Id,
					NombreCompleto =objCliente.NombreCompleto,
					Name = objCliente.Name,
					LastName = objCliente.LastName,
					Passport = objCliente.Passport,
					NeedAssistance = objCliente.NeedAssistance,
					Nit = objCliente.Nit,
					Email = objCliente.Email,
					Phone = objCliente.Phone
				};

			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error al obtener Cliente Id");
			}

			return result;
		}
	}
}
