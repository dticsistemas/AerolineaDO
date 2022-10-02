using ControlDocumentoFactura.Dominio.Models.Facturas.ValueObjetcs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Aplicacion.UsesCases.Commands.Facturas.CrearConfiguracionFactura
{
	public class CrearConfiguracionFacturaCommand : IRequest<Guid>
	{
		public String NitProveedor { get; set; }
		public String RazonSocialProveedor { get; set; }
		public String NroAutorizacion { get; set; }



		private CrearConfiguracionFacturaCommand() { }
		public CrearConfiguracionFacturaCommand(string nitProveedor, string razonSocialProveedor, string nroAutorizacion)
		{
			NitProveedor = nitProveedor;
			RazonSocialProveedor = razonSocialProveedor;
			NroAutorizacion = nroAutorizacion;			
		}
	}
}
