using ControlDocumentoFactura.Dominio.Events;
using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Dominio.Models.Transacciones
{
	public class Transaccion : AggregateRoot<Guid>
	{
		public DateTime FechaRegistro { get; private set; }
		public DateTime? FechaConfirmacion { get; private set; }
		public DateTime? FechaAnulacion { get; private set; }
		public EstadoTransaccion Estado { get; private set; }
		public TipoTransaccion Tipo { get; private set; }

		private readonly List<DetalleTransaccion> _detalle;

		public IEnumerable<DetalleTransaccion> DetalleTransaccion
		{
			get
			{
				return _detalle;
			}
		}


		public Transaccion(TipoTransaccion tipo)
		{
			Id = Guid.NewGuid();
			FechaRegistro = DateTime.Now;
			Estado = EstadoTransaccion.Registrado;
			Tipo = tipo;
			_detalle = new List<DetalleTransaccion>();
		}

		public void Confirmar()
		{
			if (Estado != EstadoTransaccion.Registrado)
				throw new BussinessRuleValidationException("La transaccion no se puede confirmar");
			FechaConfirmacion = DateTime.Now;
			Estado = EstadoTransaccion.Confirmado;

			List<TransaccionConfirmada.DetalleTransaccionConfirmada> detalle =
							_detalle.Select(x => new TransaccionConfirmada.DetalleTransaccionConfirmada(x.Cantidad, x.ArticuloId,0)).ToList(); //remove 0

			AddDomainEvent(new TransaccionConfirmada(Id, detalle, DateTime.UtcNow));
		}

		public void Anular()
		{
			if (Estado != EstadoTransaccion.Registrado)
				throw new BussinessRuleValidationException("La transaccion no se puede anular");
			FechaAnulacion = DateTime.Now;
			Estado = EstadoTransaccion.Anulado;
		}



	}
}
