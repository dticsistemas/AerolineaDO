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
		public NitFacturaValue NitProveedor { get; set; }
		public RazonSocialValue RazonSocialProveedor { get; set; }
		public NumeroAutorizacionValue NroAutorizacion { get; set; }
		public string Estado { get; set; }



		private CrearConfiguracionFacturaCommand() { }
		public CrearConfiguracionFacturaCommand(string nitProveedor, string razonSocialProveedor, string nroAutorizacion)
		{
			NitProveedor = nitProveedor;
			RazonSocialProveedor = razonSocialProveedor;
			NroAutorizacion = nroAutorizacion;			
		}
	}
}
