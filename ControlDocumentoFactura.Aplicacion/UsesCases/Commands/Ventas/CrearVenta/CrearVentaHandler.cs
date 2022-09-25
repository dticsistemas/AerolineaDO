using ControlDocumentoFactura.Aplicacion.Services.Ventas;
using ControlDocumentoFactura.Dominio.Factories.Ventas;
using ControlDocumentoFactura.Dominio.Models.Ventas;
using ControlDocumentoFactura.Dominio.Repositories.Ventas;
using ControlDocumentoFactura.Dominio.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Ventas.CrearVenta
{
	public class CrearVentaHandler : IRequestHandler<CrearVentaCommand, Guid>
	{
		private readonly IVentaRepository _ventaRepository;
		private readonly ILogger<CrearVentaHandler> _logger;
		private readonly IVentaService _ventaService;
		private readonly IVentaFactory _ventaFactory;
		private readonly IUnitOfWork _unitOfWork;

		public CrearVentaHandler(IVentaRepository ventaRepository, ILogger<CrearVentaHandler> logger,
			IVentaService ventaService, IVentaFactory ventaFactory, IUnitOfWork unitOfWork)
		{
			_ventaRepository = ventaRepository;
			_logger = logger;
			_ventaService = ventaService;
			_ventaFactory = ventaFactory;
			_unitOfWork = unitOfWork;
		}
		public async Task<Guid> Handle(CrearVentaCommand request, CancellationToken cancellationToken)
		{
			try
			{
				//string nroVenta = await _ventaService.GenerarNroVentaAsync();
				Venta objVenta = _ventaFactory.Create();

				objVenta.CrearVenta(request.Monto, request.ClienteId, request.VueloId);
				await _ventaRepository.CreateAsync(objVenta);
				await _unitOfWork.Commit();
				return objVenta.Id;

			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error al crear Venta");
			}
			return Guid.Empty;
		}

	}

}
