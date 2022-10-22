using ControlDocumentoFactura.Aplicacion.Dtos.Facturas;
using ControlDocumentoFactura.Aplicacion.UsesCases.Queries.Facturas.ObtenerConfiguracionFactura;
using ControlDocumentoFactura.Infraestructura.EntityFramework.Contexts;
using ControlDocumentoFactura.Infraestructura.EntityFramework.ReadModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Infraestructura.EntityFramework.UseCases.Queries
{
	public class ObtenerConfiguracionFacturaHandler : IRequestHandler<ObtenerConfiguracionFacturaQuery, ConfiguracionFacturaDto>
	{
		private readonly DbSet<ConfiguracionFacturaReadModel> _configFacturas;

		public ObtenerConfiguracionFacturaHandler(ReadDbContext context)
		{
			_configFacturas = context.ConfiguracionFactura;
		}

		public async Task<ConfiguracionFacturaDto> Handle(ObtenerConfiguracionFacturaQuery request, CancellationToken cancellationToken)
		{

			var configuracionList = await _configFacturas.Where(x => x.Estado.Contains("A")).ToListAsync();

			var result = new ConfiguracionFacturaDto();

			foreach (var objconfig in configuracionList)
			{
				result.Id = objconfig.Id;
				result.NitProveedor = objconfig.NitProveedor;
				result.RazonSocialProveedor = objconfig.RazonSocialProveedor;
				result.NroAutorizacion = objconfig.NroAutorizacion;
				result.Estado = objconfig.Estado;

			}

			return result;
		}
	}
}
