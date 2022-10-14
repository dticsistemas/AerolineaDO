using ControlDocumentoFactura.Aplicacion.Dtos.Pagos;
using ControlDocumentoFactura.Aplicacion.Dtos.Vuelos;
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Pagos.BuscarFacturaPorId;
using ControlDocumentoFactura.Dominio.Models.Facturas;
using ControlDocumentoFactura.Dominio.Models.Vuelos;
using ControlDocumentoFactura.Dominio.Repositories.Facturas;
using ControlDocumentoFactura.Dominio.Repositories.Vuelos;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Vuelos.BuscarVueloPorId
{
	public class BuscarVueloPorIdHandler : IRequestHandler<BuscarVueloPorIdQuery, VueloDto>
	{
		private readonly IVueloRepository _vueloRepository;
		private readonly ILogger<BuscarVueloPorIdQuery> _logger;
		public BuscarVueloPorIdHandler(IVueloRepository vueloRepository, ILogger<BuscarVueloPorIdQuery> logger)
		{
			_vueloRepository = vueloRepository;
			_logger = logger;
		}

		public async Task<VueloDto> Handle(BuscarVueloPorIdQuery request, CancellationToken cancellationToken)
		{
			VueloDto result = null;
			try
			{
				Vuelo objVuelo = await _vueloRepository.FindByIdAsync(request.Id);

				result = new VueloDto()
				{
					Id = objVuelo.Id,
					Source_airport_code = objVuelo.Source_airport_code,
					Destiny_airport_code = objVuelo.Destiny_airport_code,
					Status = objVuelo.Status,
					Flight_program_id = objVuelo.Flight_program_id,
					Information = objVuelo.Information
				};

			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error al obtener Vuelo Id");
			}

			return result;
		}
	}
}
