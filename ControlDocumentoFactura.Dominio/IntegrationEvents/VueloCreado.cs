using SharedKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Dominio.IntegrationEvents
{
	public record VueloCreado:IntegrationEvent
	{
		public Guid Id { get; set; }
		public String Source_airport_code { get; set; }
		public String Destiny_airport_code { get; set; }
		public String Status { get; set; }
		public int Flight_program_id { get; set; }
		public string Information { get; set; }



	}
}
