using ControlDocumentoFactura.Dominio.Models.ValueObjects;
using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Dominio.Models.Vuelos {
	public class Vuelo:AggregateRoot<Guid> {
		public int Cantidad { get; private set; }
		public String Detalle { get; private set; }
		public MontoValue PrecioPasaje { get; private set; }
		public Vuelo() {
			Id = Guid.NewGuid();
			PrecioPasaje = new decimal(0.0);
		}
		public Vuelo(int cantidad,String detalle,decimal precioPasaje) {
			Id = Guid.NewGuid();
			Detalle = detalle;
			Cantidad = cantidad;
			PrecioPasaje = precioPasaje;
		}

	}
}
