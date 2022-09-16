using ControlDocumentoFactura.Dominio.Models.Facturas;
using ShareKernel.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDocumentoFactura.Dominio.Repositories.Facturas {
	public interface IFacturaRepository:IRepository<Factura,Guid> {
		Task UpdateAsync(Factura obj);

	}
}
