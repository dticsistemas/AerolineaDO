using ShareKernel.Cores;
using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Dominio.Models.Facturas.ValueObjetcs
{
	public record TipoNitValue:ValueObject {
		public string Value { get; }

	public TipoNitValue(string value)
	{
		CheckRule(new StringNotNullOrEmptyRule(value));
		//TODO: validar el formato del codigo de reserva
		Value = value;
	}


	public static implicit operator string(TipoNitValue value)
	{
		return value.Value;
	}

	public static implicit operator TipoNitValue(string value)
	{
		return new TipoNitValue(value);
	}



}
}
