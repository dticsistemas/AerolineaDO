using ControlDocumentoFactura.Dominio.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.Dtos.Ventas
{
	public class VentaDto
	{
		public Guid Id { get; set; }
		public String Estado { get; set; }
		public MontoValue Monto { get; set; }
		public DateTime Fecha { get; set; }
		public int Tipo { get; set; }
		public Guid ClienteId { get; set; }
		public Guid VueloId { get; set; }
	}
}
