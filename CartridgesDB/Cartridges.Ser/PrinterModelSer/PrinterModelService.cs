using Cartridges.Data;
using Cartridges.Repo.PrinterModelRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cartridges.Ser.PrinterModelSer
{
    public class PrinterModelService : IPrinterModelService
    {
        private IPrinterModelRepo printerModelRepository;

        public PrinterModelService(IPrinterModelRepo printerModelRepository)
        {
            this.printerModelRepository = printerModelRepository;
        }

        public IEnumerable<PrinterModel> GetPrinterModels()
        {
            return printerModelRepository.GetAll();
        }

        public PrinterModel GetPrinterModel(long id)
        {
            return printerModelRepository.Get(id);
        }

        public void InsertPrinterModel(PrinterModel entity)
        {
            printerModelRepository.Insert(entity);
        }
        public void UpdatePrinterModel(PrinterModel entity)
        {
            printerModelRepository.Update(entity);
        }
        public void DeletePrinterModel(long id)
        {
            PrinterModel printerModel = GetPrinterModel(id);
            printerModelRepository.Remove(printerModel);
            printerModelRepository.SaveChanges();
        }
        public bool CheckPrinterModelsExist()
        {
            return printerModelRepository.CheckPrinterModelsExist();
        }
    }
}
