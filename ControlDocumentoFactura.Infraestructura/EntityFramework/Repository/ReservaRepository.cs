using Microsoft.EntityFrameworkCore;
using ControlDocumentoFactura.Dominio.Models.Reservas;
using ControlDocumentoFactura.Dominio.Repositories.Reservas;
using ControlDocumentoFactura.Infraestructura.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Infraestructura.EntityFramework.Repository {
		public class ReservaRepository:IReservaRepository {
				public readonly DbSet<Reserva> _reservas;

				public ReservaRepository(WriteDbContext context) {
						_reservas = context.Reserva;
				}

				public async Task CreateAsync(Reserva obj) {
						await _reservas.AddAsync(obj);
				}

				public async Task<Reserva> FindByIdAsync(Guid id) {
						return await _reservas.SingleOrDefaultAsync(x => x.Id == id);
				}

				public Task UpdateAsync(Reserva obj) {
						_reservas.Update(obj);

						return Task.CompletedTask;
				}
		}
}
