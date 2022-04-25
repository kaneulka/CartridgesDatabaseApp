using Cartridges.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cartridges.Repo.PrinterCompanyRepo
{
    public class PrinterCompanyRepo : IPrinterCompanyRepo
    {
        private readonly ApplicationContext context;
        private DbSet<PrinterCompany> entities;
        string errorMessage = string.Empty;

        public PrinterCompanyRepo(ApplicationContext context)
        {
            this.context = context;
            entities = context.Set<PrinterCompany>();
        }

        public IEnumerable<PrinterCompany> GetAll()
        {
            return entities.AsEnumerable();
        }
        public PrinterCompany Get(long id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }
        public void Insert(PrinterCompany entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            entities.Add(entity);
            context.SaveChanges();
        }
        public void Update(PrinterCompany entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            context.SaveChanges();
        }
        public void Delete(PrinterCompany entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            entities.Remove(entity);
            context.SaveChanges();
        }
        public void Remove(PrinterCompany entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            entities.Remove(entity);
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
