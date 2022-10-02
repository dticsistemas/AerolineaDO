using ControlDocumentoFactura.Dominio.Models.ValueObjects;
using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Dominio.Models.Vuelos {
	public class Vuelo:AggregateRoot<Guid> {		
		public String Source_airport_code { get; private set; }
		public String Destiny_airport_code { get; private set; }
		public String Status { get; private set; }
		public int Flight_program_id { get; private set; }
		public string Information  { get; private set; }

		public Vuelo() {
			Id = Guid.NewGuid();
		}
		public Vuelo(Guid id, int flight_program_id,String source_airport_code,String destiny_airport_code, String status,String information) {
			Id = id;
			Source_airport_code = source_airport_code;
			Destiny_airport_code = destiny_airport_code;
			Status = status;
			Flight_program_id = flight_program_id;
			Information = information;
		}

	}
}
