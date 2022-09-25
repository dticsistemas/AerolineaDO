using ControlDocumentoFactura.Dominio.Models.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Ventas.CrearVenta
{
	public class CrearVentaCommand : IRequest<Guid>
	{
		public Guid Id { get; set; }
		public String Estado { get; set; }
		public MontoValue Monto { get; set; }
		public DateTime Fecha { get; set; }
		public int Tipo { get; set; }
		public Guid ClienteId { get; set; }
		public Guid VueloId { get; set; }



		private CrearVentaCommand() { }
		public CrearVentaCommand(decimal monto, Guid clienteId, Guid vueloId)
		{
			Monto = monto;
			ClienteId = clienteId;
			VueloId = vueloId;

		}
	}
}
