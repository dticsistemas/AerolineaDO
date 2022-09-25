using ControlDocumentoFactura.Dominio.Models.Reservas;
using ControlDocumentoFactura.Dominio.Models.Ventas;
using ControlDocumentoFactura.Dominio.Repositories.Reservas;
using ControlDocumentoFactura.Dominio.Repositories.Ventas;
using ControlDocumentoFactura.Infraestructura.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Infraestructura.EntityFramework.Repository
{
	public class VentaRepository : IVentaRepository
	{
		public readonly DbSet<Venta> _ventas;

		public VentaRepository(WriteDbContext context)
		{
			_ventas = context.Venta;
		}

		public async Task CreateAsync(Venta obj)
		{
			await _ventas.AddAsync(obj);
		}

		public async Task<Venta> FindByIdAsync(Guid id)
		{
			return await _ventas.SingleOrDefaultAsync(x => x.Id == id);
		}

		public Task UpdateAsync(Venta obj)
		{
			_ventas.Update(obj);

			return Task.CompletedTask;
		}
	}
}
