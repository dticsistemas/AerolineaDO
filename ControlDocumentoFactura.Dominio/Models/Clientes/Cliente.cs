using ControlDocumentoFactura.Dominio.Models.Clientes.ValueObjects;
using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Dominio.Models.Clientes {
	public class Cliente:AggregateRoot<Guid> {
		public PersonNameValue NombreCompleto { get; set; }
		public Cliente() { }
		public Cliente(string nombreCompleto) {
			Id = Guid.NewGuid();
			NombreCompleto = nombreCompleto;
		}


	}
}
