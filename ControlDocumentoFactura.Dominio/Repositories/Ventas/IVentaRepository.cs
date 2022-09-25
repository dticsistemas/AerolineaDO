using ControlDocumentoFactura.Dominio.Models.Clientes;
using ControlDocumentoFactura.Dominio.Models.Reservas;
using ControlDocumentoFactura.Dominio.Models.Ventas;
using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Dominio.Repositories.Ventas
{
	public interface IVentaRepository : IRepository<Venta, Guid>
	{
		Task UpdateAsync(Venta obj);

	}
}
