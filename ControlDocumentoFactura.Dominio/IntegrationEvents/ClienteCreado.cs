using SharedKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Dominio.IntegrationEvents
{
	public record ClienteCreado : IntegrationEvent
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

	}
}
