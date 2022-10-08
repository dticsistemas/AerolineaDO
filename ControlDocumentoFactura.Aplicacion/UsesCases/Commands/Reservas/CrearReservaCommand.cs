using ControlDocumentoFactura.Dominio.Models.Clientes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Reservas
{
	public class CrearReservaCommand : IRequest<Guid>
	{
		public Guid Id { get; set; }
		public String ReservationNumber { get; set; }
		public String ReservationStatus { get; set; }
		public decimal Monto { get; set; }
		public decimal Deuda { get; set; }
		public DateTime Fecha { get; set; }
		public String TipoReserva { get; set; }
		public Guid ClienteId { get; set; }
		public Guid VueloId { get; set; }
		private CrearReservaCommand() { }
		public CrearReservaCommand(Guid id, String reservationNumber, Guid clienteId, Guid vueloId, DateTime fecha, decimal monto, String reservationStatus)
		{
			Id = id;
			ReservationNumber = reservationNumber;
			Monto = monto;
			Deuda = monto;
			Fecha = fecha;
			TipoReserva = "R";
			ReservationStatus = reservationStatus;
			ClienteId = clienteId;
			VueloId = vueloId;
		}

	}
}
