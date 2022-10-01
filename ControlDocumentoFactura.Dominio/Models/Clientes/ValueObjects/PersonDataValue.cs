using ShareKernel.Cores;
using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Dominio.Models.Clientes.ValueObjects
{
	public record PersonDataValue : ValueObject
	{
		public string Value { get; }

		public PersonDataValue(string name)
		{
			CheckRule(new StringNotNullOrEmptyRule(name));
			if (name.Length > 500)
			{
				throw new BussinessRuleValidationException("PersonName can't be more than 500 characters");
			}
			Value = name;
		}

		public static implicit operator string(PersonDataValue value)
		{
			return value.Value;
		}

		public static implicit operator PersonDataValue(string name)
		{
			return new PersonDataValue(name);
		}
	}
}
