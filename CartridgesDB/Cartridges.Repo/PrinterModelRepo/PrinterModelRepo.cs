using Cartridges.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cartridges.Repo.PrinterModelRepo
{
    public class PrinterModelRepo : IPrinterModelRepo
    {
        private readonly ApplicationContext context;
        private DbSet<PrinterModel> entities;
        string errorMessage = string.Empty;

        public PrinterModelRepo(ApplicationContext context)
        {
            this.context = context;
            entities = context.Set<PrinterModel>();
        }

        public IEnumerable<PrinterModel> GetAll()
        {
            return entities.Include(e=> e.PrinterCompany)
                .AsEnumerable();
        }
        public PrinterModel Get(long id)
        {
            return entities.Include(e => e.PrinterCompany)
                .SingleOrDefault(s => s.Id == id);
        }
        public void Insert(PrinterModel entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            entities.Add(entity);
            context.SaveChanges();
        }
        public void Update(PrinterModel entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            context.SaveChanges();
        }
        public void Delete(PrinterModel entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            entities.Remove(entity);
            context.SaveChanges();
        }
        public void Remove(PrinterModel entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            entities.Remove(entity);
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
        public bool CheckPrinterModelsExist()
        {
            if (entities.Count() > 0)
                return true;
            else
                return false;
        }
    }
}
