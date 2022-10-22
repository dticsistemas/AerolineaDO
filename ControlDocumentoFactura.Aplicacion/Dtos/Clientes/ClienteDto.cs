 using ControlDocumentoFactura.Dominio.Models.Clientes.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.Dtos.Clientes {
	public class ClienteDto {
			public Guid Id { get; set; }
		public String NombreCompleto { get; set; }
		public String Name { get; set; }
			public String LastName { get; set; }
		public String Passport { get; set; }
				public String NeedAssistance { get; set; }
		public String Nit { get; set; }
		public String Email { get; set; }
			public String Phone { get; set; }
	}
}
