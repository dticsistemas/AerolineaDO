using ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Vuelos.CrearVuelo;
using ControlDocumentoFactura.Dominio.Factories.Vuelos;
using ControlDocumentoFactura.Dominio.Models.Vuelos;
using ControlDocumentoFactura.Dominio.Repositories.Vuelos;
using ControlDocumentoFactura.Dominio.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ControlDocumentoFactura.Dominio.Repositories.Clientes;
using ControlDocumentoFactura.Dominio.Models.Clientes;
using System.Numerics;
using System.Xml.Linq;

namespace ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Clientes.CrearCliente
{
	public class CrearClienteHandler : IRequestHandler<CrearClienteCommand, Guid>
	{
		private readonly IClienteRepository _clienteRepository;
		private readonly ILogger<CrearClienteHandler> _logger;
		private readonly IUnitOfWork _unitOfWork;

		public CrearClienteHandler(IClienteRepository clienteRepository, ILogger<CrearClienteHandler> logger, IUnitOfWork unitOfWork)
		{
			_clienteRepository = clienteRepository;
			_logger = logger;
			_unitOfWork = unitOfWork;
		}

		public async Task<Guid> Handle(CrearClienteCommand request, CancellationToken cancellationToken)
		{
			try
			{
				Cliente objCliente = new Cliente(request.Id, request.Name, request.LastName, request.Passport, request.NeedAssistance, request.Nit, request.Email, request.Phone);

				await _clienteRepository.CreateAsync(objCliente);
				await _unitOfWork.Commit();

				return objCliente.Id;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error al crear cliente");
			}
			return Guid.Empty;
		}
	}
}
