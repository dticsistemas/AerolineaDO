using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Clientes.CrearCliente
{
	public class CrearClienteCommand : IRequest<Guid>
	{
		public Guid Id { get; set; }
		public String NombreCompleto { get; set; }
		public String Name { get; set; }
		public String LastName { get; set; }
		public String Passport { get; set; }
		public String NeedAssistance { get; set; }
		public String Nit { get; set; }
		public String Email { get; set; }
		public String Phone { get; set; }

		private CrearClienteCommand() { }

		public CrearClienteCommand(Guid id, string name, string lastName, string passport, string needAssistance, string nit, string email, string phone)
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
