using ControlDocumentoFactura.Dominio.Models.Clientes;
using ControlDocumentoFactura.Dominio.Models.Vuelos;
using ControlDocumentoFactura.Dominio.Repositories.Clientes;
using ControlDocumentoFactura.Dominio.Repositories.Vuelos;
using ControlDocumentoFactura.Infraestructura.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Infraestructura.EntityFramework.Repository
{
	public class ClienteRepository : IClienteRepository
	{

		public readonly DbSet<Cliente> _clientes;

		public ClienteRepository(WriteDbContext context)
		{
			_clientes = context.Cliente;
		}

		public async Task CreateAsync(Cliente obj)
		{
			await _clientes.AddAsync(obj);
		}
		public async Task<Cliente> FindByIdAsync(Guid id)
		{
			return await _clientes.SingleOrDefaultAsync(x => x.Id == id);
		}

		public Task UpdateAsync(Cliente obj)
		{
			_clientes.Update(obj);

			return Task.CompletedTask;
		}
		public async Task<List<Cliente>> GetAll()
		{
			return await _clientes.ToListAsync();

		}




	}
}
