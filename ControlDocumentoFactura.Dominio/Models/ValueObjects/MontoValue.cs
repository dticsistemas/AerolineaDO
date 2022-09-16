using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Dominio.Models.ValueObjects {
	public record MontoValue:ValueObject {
		public decimal Value { get; }
		public MontoValue(decimal value) {
			if( value < 0 ) {
				throw new BussinessRuleValidationException("Price value cannot be negative");
			}
			Value = value;
		}

		public static implicit operator decimal(MontoValue value) {
			return value.Value;
		}

		public static implicit operator MontoValue(decimal value) {
			return new MontoValue(value);
		}


	}
}
