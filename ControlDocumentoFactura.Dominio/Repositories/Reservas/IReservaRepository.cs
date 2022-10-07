using ControlDocumentoFactura.Dominio.Models.Reservas;
using ControlDocumentoFactura.Dominio.Models.Vuelos;
using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Dominio.Repositories.Reservas {
	public interface IReservaRepository:IRepository<Reserva,Guid> {
		Task UpdateAsync(Reserva obj);
		Task<List<Reserva>> GetAll();

	}
}
