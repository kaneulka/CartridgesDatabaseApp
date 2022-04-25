using Cartridges.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cartridges.Ser.PrinterModelSer
{
    public interface IPrinterModelService
    {
        IEnumerable<PrinterModel> GetPrinterModels();
        PrinterModel GetPrinterModel(long id);
        void InsertPrinterModel(PrinterModel entity);
        void UpdatePrinterModel(PrinterModel entity);
        void DeletePrinterModel(long id);
        public bool CheckPrinterModelsExist();
    }
}
