using ControlDocumentoFactura.Dominio.Factories.Vuelos;
using ControlDocumentoFactura.Dominio.Models.Vuelos;
using ControlDocumentoFactura.Dominio.Repositories;
using ControlDocumentoFactura.Dominio.Repositories.Vuelos;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Vuelos.CrearVuelo
{
	public class CrearVueloHandler : IRequestHandler<CrearVueloCommand, Guid>
	{
		private readonly IVueloRepository _vueloRepository;
		private readonly ILogger<CrearVueloHandler> _logger;
		private readonly IVueloFactory _vueloFactory;
		private readonly IUnitOfWork _unitOfWork;

		public CrearVueloHandler(IVueloRepository vueloRepository, ILogger<CrearVueloHandler> logger, IVueloFactory vueloFactory, IUnitOfWork unitOfWork)
		{
			_vueloRepository = vueloRepository;
			_logger = logger;
			_vueloFactory = vueloFactory;
			_unitOfWork = unitOfWork;
		}

		public async Task<Guid> Handle(CrearVueloCommand request, CancellationToken cancellationToken)
		{
			try
			{
				Vuelo objVuelo = _vueloFactory.Create(request.Id, request.Flight_program_id, request.Source_airport_code, request.Destiny_airport_code, request.Status, request.Information);

				await _vueloRepository.CreateAsync(objVuelo);
				await _unitOfWork.Commit();

				return objVuelo.Id;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error al crear vuelo");
			}
			return Guid.Empty;
		}
	}
}
