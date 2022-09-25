﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ControlDocumentoFactura.Aplicacion.Services.Reservas;
using ControlDocumentoFactura.Dominio.Factories.Facturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ControlDocumentoFactura.Dominio.Factories.Vuelos;
using ControlDocumentoFactura.Aplicacion.Services.Ventas;
using ControlDocumentoFactura.Dominio.Factories.Ventas;

namespace ControlDocumentoFactura.Aplicacion {
	public static class Extensions {
		public static IServiceCollection AddApplication(this IServiceCollection services) {
			services.AddMediatR(Assembly.GetExecutingAssembly());
			services.AddTransient<IFacturaService,FacturaService>();
			services.AddTransient<IFacturaFactory,FacturaFactory>();
			services.AddTransient<IVueloFactory, VueloFactory>();
			//services.AddTransient<IClienteFactory, ClienteFactory>();
			services.AddTransient<IVentaService, VentaService>();
			services.AddTransient<IVentaFactory, VentaFactory>();

			return services;
		}

	}
}
