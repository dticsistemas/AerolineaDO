using ShareKernel.Cores;
using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Dominio.Models.Facturas.ValueObjetcs {
	public record RazonSocialValue:ValueObject {
		public string Value { get; }

		public RazonSocialValue(string name) {
			CheckRule(new StringNotNullOrEmptyRule(name));
			if( name.Length > 120 ) {
				throw new BussinessRuleValidationException("RazonSocial can't be more than 120 characters");
			}
			Value = name;
		}

		public static implicit operator string(RazonSocialValue value) {
			return value.Value;
		}

		public static implicit operator RazonSocialValue(string name) {
			return new RazonSocialValue(name);
		}
	}
}
