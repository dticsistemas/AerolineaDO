using ControlDocumentoFactura.Aplicacion.Dtos.Pagos;
using ControlDocumentoFactura.Aplicacion.Dtos.Vuelos;
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Pagos.BuscarFacturaPorId;
using ControlDocumentoFactura.Dominio.Models.Facturas;
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

namespace ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Vuelos.ListarVuelos
{
	public class ListarVuelosHandler : IRequestHandler<ListarVuelosQuery, ICollection<VueloDto>>
	{
		private readonly IVueloRepository _vueloRepository;
		private readonly ILogger<ListarVuelosQuery> _logger;
		public ListarVuelosHandler(IVueloRepository vueloRepository, ILogger<ListarVuelosQuery> logger)
		{
			_vueloRepository = vueloRepository;
			_logger = logger;
		}

		public async Task<ICollection<VueloDto>> Handle(ListarVuelosQuery request, CancellationToken cancellationToken)
		{

			var vueloList = await _vueloRepository.GetAll();

			var result = new List<VueloDto>();

			foreach (var objVuelo in vueloList)
			{
				var vueloDto = new VueloDto()
				{
					Id = objVuelo.Id,
					Source_airport_code = objVuelo.Source_airport_code,
					Destiny_airport_code = objVuelo.Destiny_airport_code,
					Status = objVuelo.Status,
					Flight_program_id = objVuelo.Flight_program_id,
					Information = objVuelo.Information
				};
				result.Add(vueloDto);
			}

			return result;
		}
	}
}
