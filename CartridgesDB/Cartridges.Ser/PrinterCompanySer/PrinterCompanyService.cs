using Cartridges.Data;
using Cartridges.Repo.PrinterCompanyRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cartridges.Ser.PrinterCompanySer
{
    public class PrinterCompanyService : IPrinterCompanyService
    {
        private IPrinterCompanyRepo printerCompanyRepository;

        public PrinterCompanyService(IPrinterCompanyRepo printerCompanyRepository)
        {
            this.printerCompanyRepository = printerCompanyRepository;
        }

        public IEnumerable<PrinterCompany> GetPrinterCompanies()
        {
            return printerCompanyRepository.GetAll();
        }

        public PrinterCompany GetPrinterCompany(long id)
        {
            return printerCompanyRepository.Get(id);
        }

        public void InsertPrinterCompany(PrinterCompany entity)
        {
            printerCompanyRepository.Insert(entity);
        }
        public void UpdatePrinterCompany(PrinterCompany entity)
        {
            printerCompanyRepository.Update(entity);
        }
        public void DeletePrinterCompany(long id)
        {
            PrinterCompany printerCompany = GetPrinterCompany(id);
            printerCompanyRepository.Remove(printerCompany);
            printerCompanyRepository.SaveChanges();
        }
    }
}
