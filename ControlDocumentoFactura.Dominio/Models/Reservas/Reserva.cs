﻿using ControlDocumentoFactura.Dominio.Events.Facturas;
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

		public CodigoReservaValue ReservationNumber { get; private set; }
		public String ReservationStatus { get; private set; }
		public MontoValue Monto { get; private set; }
		public MontoValue Deuda { get; private set; }
		public DateTime Fecha { get; private set; }
		public String TipoReserva { get; private set; }
		public Guid ClienteId { get; private set; }
		public Guid VueloId { get; private set; }

		private Reserva() { }
		public Reserva(Guid id, String reservationNumber,Guid clienteId, Guid vueloId,DateTime fecha, decimal monto,String reservationStatus) {
			Id = Guid.NewGuid();
			ReservationNumber= reservationNumber;
			Monto = monto;
			Deuda = monto;
			Fecha = fecha;
			TipoReserva = "R";
			ReservationStatus= reservationStatus;
			ClienteId = clienteId;
			VueloId = vueloId;
		}


	}
}
