using ControlDocumentoFactura.Dominio.Models.Vuelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Dominio.Factories.Vuelos
{
	public class VueloFactory : IVueloFactory
	{
		public Vuelo Create(Guid id, int flight_program_id, String source_airport_code, String destiny_airport_code, String status, String information)
		{
			return new Vuelo(id,flight_program_id,source_airport_code,destiny_airport_code,status,information);
		}
	}
}
