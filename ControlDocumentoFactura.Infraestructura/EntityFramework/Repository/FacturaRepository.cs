using Microsoft.EntityFrameworkCore;
using ControlDocumentoFactura.Dominio.Models.Facturas;
using ControlDocumentoFactura.Dominio.Repositories.Facturas;
using ControlDocumentoFactura.Infraestructura.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Infraestructura.EntityFramework.Repository {
		public class FacturaRepository:IFacturaRepository {
				public readonly DbSet<Factura> _facturas;

				public FacturaRepository(WriteDbContext context) {
						_facturas = context.Factura;
				}

				public async Task CreateAsync(Factura obj) {
						await _facturas.AddAsync(obj);
				}

				public async Task<Factura> FindByIdAsync(Guid id) {
						return await _facturas.SingleOrDefaultAsync(x => x.Id == id);
				}

				public Task UpdateAsync(Factura obj) {
						_facturas.Update(obj);

						return Task.CompletedTask;
				}
		}
}
