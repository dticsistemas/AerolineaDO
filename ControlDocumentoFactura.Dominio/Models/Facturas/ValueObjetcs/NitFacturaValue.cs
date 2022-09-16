using ShareKernel.Cores;
using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Dominio.Models.Facturas.ValueObjetcs {
	public record NitFacturaValue:ValueObject {
		public string Value { get; }

		public NitFacturaValue(string value) {
			CheckRule(new StringNotNullOrEmptyRule(value));
			//TODO: validar el formato del codigo de reserva
			Value = value;
		}


		public static implicit operator string(NitFacturaValue value) {
			return value.Value;
		}

		public static implicit operator NitFacturaValue(string value) {
			return new NitFacturaValue(value);
		}



	}
}
