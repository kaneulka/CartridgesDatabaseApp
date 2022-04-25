using Cartridges.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cartridges.Ser.PrinterCompanySer
{
    public interface IPrinterCompanyService
    {
        IEnumerable<PrinterCompany> GetPrinterCompanies();
        PrinterCompany GetPrinterCompany(long id);
        void InsertPrinterCompany(PrinterCompany entity);
        void UpdatePrinterCompany(PrinterCompany entity);
        void DeletePrinterCompany(long id);
    }
}
