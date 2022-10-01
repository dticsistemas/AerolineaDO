using ControlDocumentoFactura.Dominio.Factories.Facturas;
using ControlDocumentoFactura.Dominio.Models.Facturas;
using ControlDocumentoFactura.Dominio.Repositories.Facturas;
using ControlDocumentoFactura.Infraestructura.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Infraestructura.EntityFramework.Repository
{
	public class ConfiguracionFacturaRepository:IConfiguracionFacturaRepository
	{
		public readonly DbSet<ConfiguracionFactura> _configuracionFacturas;

		public ConfiguracionFacturaRepository(WriteDbContext context)
		{
			_configuracionFacturas = context.ConfiguracionFactura;
		}		

		public async Task CreateAsync(ConfiguracionFactura obj)
		{
			await _configuracionFacturas.AddAsync(obj);
		}

		public async Task<ConfiguracionFactura> FindByIdAsync(Guid id)
		{
			return await _configuracionFacturas.SingleOrDefaultAsync(x => x.Id == id);
		}

		public Task UpdateAsync(ConfiguracionFactura obj)
		{
			_configuracionFacturas.Update(obj);

			return Task.CompletedTask;
		}
	}
}
