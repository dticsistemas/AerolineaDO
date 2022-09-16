using ControlDocumentoFactura.Dominio.Models.Vuelos;
using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Dominio.Repositories.Vuelos {
	public interface IVueloRepository:IRepository<Vuelo,Guid> {
		Task UpdateAsync(Vuelo obj);

	}
}
