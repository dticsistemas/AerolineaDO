using ControlDocumentoFactura.Aplicacion.Services.Reservas;
using ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Facturas.CrearFactura;
using ControlDocumentoFactura.Dominio.Factories.Facturas;
using ControlDocumentoFactura.Dominio.Models.Facturas;
using ControlDocumentoFactura.Dominio.Repositories.Facturas;
using ControlDocumentoFactura.Dominio.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using ControlDocumentoFactura.Aplicacion.Dtos.Vuelos;
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Vuelos.ListarVuelos;
using ControlDocumentoFactura.Dominio.Repositories.Vuelos;
using ControlDocumentoFactura.Aplicacion.Dtos.Clientes;
using ControlDocumentoFactura.Dominio.Repositories.Clientes;

namespace ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Clientes.ListarPasajeros
{
	public class ListarPasajerosHandler : IRequestHandler<ListarPasajerosQuery, ICollection<ClienteDto>>
	{
		private readonly IClienteRepository _clienteRepository;
		private readonly ILogger<ListarPasajerosQuery> _logger;
		public ListarPasajerosHandler(IClienteRepository clienteRepository, ILogger<ListarPasajerosQuery> logger)
		{
			_clienteRepository = clienteRepository;
			_logger = logger;
		}

		public async Task<ICollection<ClienteDto>> Handle(ListarPasajerosQuery request, CancellationToken cancellationToken)
		{

			var pasajeroList = await _clienteRepository.GetAll();

			var result = new List<ClienteDto>();

			foreach (var objPasajero in pasajeroList)
			{
				var pasajeroDto = new ClienteDto()
				{
					Id = objPasajero.Id,
					NombreCompleto=objPasajero.NombreCompleto

				};

				result.Add(pasajeroDto);
			}

			return result;
		}
	}
}
