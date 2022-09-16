using ControlDocumentoFactura.Dominio.Events.Facturas;
using ControlDocumentoFactura.Dominio.Models.Reservas.ValueObjects;
using ControlDocumentoFactura.Dominio.Models.ValueObjects;
using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Dominio.Models.Reservas {
	public class Reserva:AggregateRoot<Guid> {

		public CodigoReservaValue CodReserva;
		public String EstadoReserva;
		public MontoValue Monto;
		public MontoValue Deuda;
		public DateTime Fecha;
		public String TipoReserva;
		public Guid ClienteId;
		public Guid VueloId;

		private Reserva() { }
		public Reserva(String codReserva) {
			Id = Guid.NewGuid();
			CodReserva = codReserva;
			Monto = new MontoValue(0m);
			Deuda = new MontoValue(0m);
			Fecha = DateTime.Now;
			EstadoReserva = "C";
		}


	}
}
