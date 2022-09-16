using ShareKernel.Cores;
using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Dominio.Models.ValueObjects {
	public record DescripcionLugarValue:ValueObject {
		public string Value { get; }

		public DescripcionLugarValue(string name) {
			CheckRule(new NotNullRule(name));
			if( name.Length > 100 ) {
				throw new BussinessRuleValidationException("DescripcionLugar can't be more than 100 characters");
			}
			Value = name;
		}

		public static implicit operator string(DescripcionLugarValue value) {
			return value.Value;
		}

		public static implicit operator DescripcionLugarValue(string name) {
			return new DescripcionLugarValue(name);
		}
	}
}
