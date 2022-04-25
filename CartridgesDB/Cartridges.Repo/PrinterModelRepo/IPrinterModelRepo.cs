using Cartridges.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cartridges.Repo.PrinterModelRepo
{
    public interface IPrinterModelRepo : IRepository<PrinterModel>
    {
        public bool CheckPrinterModelsExist();
    }
}
