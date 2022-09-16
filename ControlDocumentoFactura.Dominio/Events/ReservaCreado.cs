using SharedKernel.Cores;
using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Dominio.Events
{
	public record ReservaCreado /*: DomainEvent*/
	{

		public Guid ReservaId { get; set; }
		public string Nombre { get; set; }

		public decimal PrecioVenta { get; set; }

		public ReservaCreado(Guid reservaId, string nombre, decimal precioVenta, DateTime occuredOn)/* : base(occuredOn)*/
		{
			ReservaId = reservaId;
			Nombre = nombre;
			PrecioVenta = precioVenta;
		}
	}
	
}
