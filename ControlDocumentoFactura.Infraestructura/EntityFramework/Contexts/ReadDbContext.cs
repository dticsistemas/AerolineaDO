using Microsoft.EntityFrameworkCore;
using ControlDocumentoFactura.Dominio.Events.Facturas;
using ControlDocumentoFactura.Infraestructura.EntityFramework.Config.ReadConfig;
using ControlDocumentoFactura.Infraestructura.EntityFramework.ReadModel;
using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Infraestructura.EntityFramework.Contexts
{
	public class ReadDbContext : DbContext
	{
		public virtual DbSet<ClienteReadModel> Cliente { set; get; }
		public virtual DbSet<VueloReadModel> Vuelo { set; get; }
		public virtual DbSet<ReservaReadModel> Reserva { set; get; }
		public virtual DbSet<FacturaReadModel> Factura { set; get; }
		public virtual DbSet<ConfiguracionFacturaReadModel> ConfiguracionFactura { set; get; }


		public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			var clienteConfig = new ClienteReadConfig();
			modelBuilder.ApplyConfiguration<ClienteReadModel>(clienteConfig);

			var vueloConfig = new VueloReadConfig();
			modelBuilder.ApplyConfiguration<VueloReadModel>(vueloConfig);

			var reservaConfig = new ReservaReadConfig();
			modelBuilder.ApplyConfiguration<ReservaReadModel>(reservaConfig);

			var facturaConfig = new FacturaReadConfig();
			modelBuilder.ApplyConfiguration<FacturaReadModel>(facturaConfig);

			var configuracionFacturaConfig = new ConfiguracionFacturaReadConfig();
			modelBuilder.ApplyConfiguration<ConfiguracionFacturaReadModel>(configuracionFacturaConfig);



			modelBuilder.Ignore<DomainEvent>();
		}
	}
}
