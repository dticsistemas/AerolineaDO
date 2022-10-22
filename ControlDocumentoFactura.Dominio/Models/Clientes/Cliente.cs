using ControlDocumentoFactura.Dominio.Models.Clientes.ValueObjects;
using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Dominio.Models.Clientes
{
	public class Cliente : AggregateRoot<Guid>
	{
		public PersonNameValue NombreCompleto { get; set; }
		public PersonNameValue Name { get; set; }
		public PersonNameValue LastName { get; set; }
		public PersonDataValue Passport { get; set; }
		public PersonDataValue NeedAssistance { get; set; }
		public PersonDataValue Nit { get; set; }
		public PersonDataValue Email { get; set; }
		public PersonDataValue Phone { get; set; }

		public Cliente() { }
		public Cliente(Guid id, string name, string lastName, string passport, string needAssistance, string nit, string email, string phone)
		{
			Id = id;
			NombreCompleto = name + " " + lastName;
			Name = name;
			LastName = lastName;
			Passport = passport;
			NeedAssistance = needAssistance;
			Nit = nit;
			Email = email;
			Phone = phone;

		}


	}
}
