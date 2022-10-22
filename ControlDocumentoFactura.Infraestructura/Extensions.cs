using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ControlDocumentoFactura.Dominio.Repositories;
using ControlDocumentoFactura.Dominio.Repositories.Reservas;
using ControlDocumentoFactura.Infraestructura.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using ControlDocumentoFactura.Aplicacion;
using ControlDocumentoFactura.Infraestructura.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using ControlDocumentoFactura.Infraestructura.EntityFramework.Repository;
using ControlDocumentoFactura.Dominio.Repositories.Facturas;
using ControlDocumentoFactura.Dominio.Repositories.Vuelos;
using ControlDocumentoFactura.Dominio.Repositories.Clientes;
using ControlDocumentoFactura.WebApi;
using ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Clientes.CrearCliente;
using MediatR;

namespace ControlDocumentoFactura.Infraestructura
{
	public static class Extensions
	{
		public static async Task<IServiceCollection> AddInfrastructureAsync(this IServiceCollection services,
					IConfiguration configuration)
		{
			services.AddApplication();

			//services.AddMediatR(Assembly.GetExecutingAssembly());
			services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());


			var connectionString =
							configuration.GetConnectionString("ReservaDbConnectionString");

			services.AddDbContext<ReadDbContext>(context =>
				context.UseSqlServer(connectionString));
			services.AddDbContext<WriteDbContext>(context =>
				context.UseSqlServer(connectionString));

			services.AddScoped<IReservaRepository, ReservaRepository>();

			services.AddScoped<IVueloRepository, VueloRepository>();

			services.AddScoped<IClienteRepository, ClienteRepository>();

			services.AddScoped<IFacturaRepository, FacturaRepository>();

			services.AddScoped<IConfiguracionFacturaRepository, ConfiguracionFacturaRepository>();

			services.AddScoped<IUnitOfWork, UnitOfWork>();


			services.AddHostedService<SqsBackgroundService>();
			//services.AddHostedService<ScopedWorker>();






			return services;
		}


	}
}
