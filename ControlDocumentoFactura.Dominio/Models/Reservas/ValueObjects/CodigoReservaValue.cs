using ShareKernel.Cores;
using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Dominio.Models.Reservas.ValueObjects {
	public record CodigoReservaValue:ValueObject {
		public string Value { get; }

		public CodigoReservaValue(string value) {
			CheckRule(new StringNotNullOrEmptyRule(value));
			//TODO: validar el formato del codigo de reserva
			Value = value;
		}


		public static implicit operator string(CodigoReservaValue value) {
			return value.Value;
		}

		public static implicit operator CodigoReservaValue(string value) {
			return new CodigoReservaValue(value);
		}



	}
}
