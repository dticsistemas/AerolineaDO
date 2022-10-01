using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Clientes.CrearCliente
{
	public class CrearClienteCommand : IRequest<Guid>
	{
		public Guid Id { get; set; }
		public int Cantidad { get; set; }
		public String Detalle { get; set; }
		public decimal PrecioPasaje { get; set; }

		private CrearClienteCommand() { }

		public CrearClienteCommand(Guid id, int cantidad, string detalle, decimal precioPasaje)
		{
			Id = id;
			Cantidad = cantidad;
			Detalle = detalle;
			PrecioPasaje = precioPasaje;
		}
	}
}
