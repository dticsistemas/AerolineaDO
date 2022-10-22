using ControlDocumentoFactura.Infraestructura.EntityFramework.Config.ReadConfig;
using ControlDocumentoFactura.Infraestructura.EntityFramework.ReadModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControlDocumentoFactura.Test.Infraestructura.Config
{
	public class ClienteReadConfig_Test
	{
		[Fact]
		public void ClienteReadConfig_CheckPropertiesValid()
		{


			ClienteReadConfig cfg = new ClienteReadConfig();

			//cfg.Configure()

		}
	}
}
