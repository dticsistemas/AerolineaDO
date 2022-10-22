using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Reservas
{
	public class ReservaPagadoCommand : IRequest<Guid>
	{
		public Guid Id { get; set; }
		public Guid ReservaId { get; set; }
		public String TransactionNumber { get; set; }
		public decimal Amount { get; set; }
		private ReservaPagadoCommand() { }
		public ReservaPagadoCommand(Guid id, Guid reservaId, String transactionNumber, decimal amount)
		{
			Id = id;
			ReservaId = reservaId;
			TransactionNumber = transactionNumber;
			Amount = amount;
		}

	}
}
