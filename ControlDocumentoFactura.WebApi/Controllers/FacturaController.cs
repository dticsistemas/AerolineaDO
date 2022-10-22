using ControlDocumentoFactura.Aplicacion.Dtos.Clientes;
using ControlDocumentoFactura.Aplicacion.Dtos.Pagos;
using ControlDocumentoFactura.Aplicacion.Dtos.Reservas;
using ControlDocumentoFactura.Aplicacion.Dtos.Vuelos;
using ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Clientes.CrearCliente;
using ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Facturas.CrearConfiguracionFactura;
using ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Facturas.CrearFactura;
using ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Vuelos.CrearVuelo;
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Clientes.BuscarClientePorId;
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Clientes.ListarPasajeros;
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Facturas.ListarFacturas;
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Facturas.ObtenerConfiguracionFactura;
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Facturas.SearchFacturasClienteQuery;
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Pagos.BuscarFacturaPorId;
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Reservas.BuscarReservaPorId;
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Reservas.ListarReservas;
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Vuelos.BuscarVueloPorId;
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Vuelos.ListarVuelos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.WebApi.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]
	public class FacturaController : ControllerBase
	{
		private readonly IMediator _mediator;

		public FacturaController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[Route("create")]
		[HttpPost]
		public async Task<IActionResult> CreateFactura([FromBody] CrearFacturaCommand command)
		{
			Guid id = await _mediator.Send(command);

			if (id == Guid.Empty)
				return BadRequest();

			return Ok(id);
		}
		[Route("configuracion")]
		[HttpPost]
		public async Task<IActionResult> CreateConfiguracionFactura([FromBody] CrearConfiguracionFacturaCommand command)
		{
			Guid id = await _mediator.Send(command);

			if (id == Guid.Empty)
				return BadRequest();

			return Ok(id);
		}
		[Route("configuracion")]
		[HttpGet]
		public async Task<IActionResult> ObtenerConfiguracionFactura([FromRoute] ObtenerConfiguracionFacturaQuery query)
		{
			var configFacturas = await _mediator.Send(query);

			if (configFacturas == null)
				return BadRequest();

			return Ok(configFacturas);
		}

		[Route("{id:guid}")]
		[HttpGet]
		public async Task<IActionResult> ObtenerFacturaPorId([FromRoute] BuscarFacturaPorIdQuery command)
		{
			FacturaDto result = await _mediator.Send(command);

			if (result == null)
				return NotFound();

			return Ok(result);
		}
		[Route("vuelos")]
		[HttpGet]
		public async Task<IActionResult> ListarVuelos([FromRoute] ListarVuelosQuery command)
		{
			var result = await _mediator.Send(command);

			if (result == null)
				return NotFound();

			return Ok(result);
		}
		[Route("vuelo/{id:guid}")]
		[HttpGet]
		public async Task<IActionResult> ObtenerVueloPorId([FromRoute] BuscarVueloPorIdQuery command)
		{
			VueloDto result = await _mediator.Send(command);

			if (result == null)
				return NotFound();

			return Ok(result);
		}
		[Route("pasajeros")]
		[HttpGet]
		public async Task<IActionResult> ListarPasajeros([FromRoute] ListarPasajerosQuery command)
		{
			var result = await _mediator.Send(command);

			if (result == null)
				return NotFound();

			return Ok(result);
		}
		[Route("cliente/{id:guid}")]
		[HttpGet]
		public async Task<IActionResult> ObtenerClientePorId([FromRoute] BuscarClientePorIdQuery command)
		{
			ClienteDto result = await _mediator.Send(command);

			if (result == null)
				return NotFound();

			return Ok(result);
		}
		[Route("reservas")]
		[HttpGet]
		public async Task<IActionResult> ListarReservas([FromRoute] ListarReservasQuery command)
		{
			var result = await _mediator.Send(command);

			if (result == null)
				return NotFound();

			return Ok(result);
		}
		[Route("reserva/{id:guid}")]
		[HttpGet]
		public async Task<IActionResult> ObtenerReservaPorId([FromRoute] BuscarReservaPorIdQuery command)
		{
			ReservaDto result = await _mediator.Send(command);

			if (result == null)
				return NotFound();

			return Ok(result);
		}
		[Route("facturas")]
		[HttpGet]
		public async Task<IActionResult> ListarFacturas([FromRoute] ListarFacturasQuery command)
		{
			var result = await _mediator.Send(command);

			if (result == null)
				return NotFound();

			return Ok(result);
		}
		[Route("search")]
		[HttpPost]
		public async Task<IActionResult> Search([FromBody] SearchFacturasClienteQuery query)
		{
			var facturas = await _mediator.Send(query);

			if (facturas == null)
				return BadRequest();

			return Ok(facturas);
		}



	}
}
