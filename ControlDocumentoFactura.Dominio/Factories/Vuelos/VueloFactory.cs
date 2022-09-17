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
		public Vuelo Create(Guid id, int cantidad, string detalle, decimal precioPasaje)
		{
			return new Vuelo(id, cantidad, detalle, precioPasaje);
		}
	}
}
