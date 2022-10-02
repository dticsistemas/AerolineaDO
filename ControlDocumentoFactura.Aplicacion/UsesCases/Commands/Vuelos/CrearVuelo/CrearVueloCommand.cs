using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Vuelos.CrearVuelo
{
	
		public class CrearVueloCommand : IRequest<Guid>
	{
		public Guid Id { get; set; }
		public String Source_airport_code { get; set; }
		public String Destiny_airport_code { get; set; }
		public String Status { get; set; }
		public int Flight_program_id { get; set; }
		public string Information { get; set; }

		private CrearVueloCommand() { }

		public CrearVueloCommand(Guid id, int flight_program_id, String source_airport_code, String destiny_airport_code, String status, String information)
		{
			Id = id;
			Source_airport_code = source_airport_code;
			Destiny_airport_code = destiny_airport_code;
			Status = status;
			Flight_program_id = flight_program_id;
			Information = information;
		}
	}
}
