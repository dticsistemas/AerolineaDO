using Microsoft.EntityFrameworkCore;
using ControlDocumentoFactura.Dominio.Models.Clientes;
using ControlDocumentoFactura.Dominio.Models.Facturas;
using ControlDocumentoFactura.Dominio.Models.Reservas;
using ControlDocumentoFactura.Dominio.Models.Vuelos;
using ControlDocumentoFactura.Infraestructura.EntityFramework.Config.WriteConfig;
using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Infraestructura.EntityFramework.Contexts {
		public class WriteDbContext:DbContext {
				public virtual DbSet<Cliente> Cliente { get; set; }

				public virtual DbSet<Vuelo> Vuelo { get; set; }
				public virtual DbSet<Reserva> Reserva { get; set; }

				public virtual DbSet<Factura> Factura { get; set; }
				public virtual DbSet<ConfiguracionFactura> ConfiguracionFactura { get; set; }


		public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options) {
				}

				protected override void OnModelCreating(ModelBuilder modelBuilder) {
						base.OnModelCreating(modelBuilder);

						var clienteConfig = new ClienteWriteConfig();
						modelBuilder.ApplyConfiguration<Cliente>(clienteConfig);

						var vueloConfig = new VueloWriteConfig();
						modelBuilder.ApplyConfiguration<Vuelo>(vueloConfig);

						var reservaConfig = new ReservaWriteConfig();
						modelBuilder.ApplyConfiguration<Reserva>(reservaConfig);

						var facturaConfig = new FacturaWriteConfig();
						modelBuilder.ApplyConfiguration<Factura>(facturaConfig);

						var configuracionFacturaConfig = new ConfiguracionFacturaWriteConfig();
						modelBuilder.ApplyConfiguration<ConfiguracionFactura>(configuracionFacturaConfig);

					

			modelBuilder.Ignore<DomainEvent>();
				}
		}
}
