using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Dominio.Models.Transacciones.ValueObjects
{
	public record CantidadTransaccion
	{
		public decimal Value { get; init; }

		public CantidadTransaccion(decimal value)
		{
			if (value <= 0)
			{
				throw new BussinessRuleValidationException("La cantidad no puede ser menor o igual que 0");
			}
			Value = value;
		}

		public static implicit operator decimal(CantidadTransaccion value)
		{
			return value.Value;
		}

		public static implicit operator CantidadTransaccion(decimal value)
		{
			return new CantidadTransaccion(value);
		}
	}
}
