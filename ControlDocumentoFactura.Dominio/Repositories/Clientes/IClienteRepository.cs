using ControlDocumentoFactura.Dominio.Models.Clientes;
using ControlDocumentoFactura.Dominio.Models.Vuelos;
using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Dominio.Repositories.Clientes
{
	public interface IClienteRepository : IRepository<Cliente, Guid>
	{
		Task UpdateAsync(Cliente obj);
		Task<List<Cliente>> GetAll();

	}
}
