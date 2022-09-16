using ShareKernel.Cores;
using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Dominio.Models.Facturas.ValueObjetcs {
	public record NumeroAutorizacionValue:ValueObject {
		public string Value { get; }

		public NumeroAutorizacionValue(string value) {
			CheckRule(new StringNotNullOrEmptyRule(value));
			//TODO: validar el formato del numero de factura
			Value = value;
		}


		public static implicit operator string(NumeroAutorizacionValue value) {
			return value.Value;
		}

		public static implicit operator NumeroAutorizacionValue(string value) {
			return new NumeroAutorizacionValue(value);
		}



	}
}
