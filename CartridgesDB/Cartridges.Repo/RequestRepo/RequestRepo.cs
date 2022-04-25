using Cartridges.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cartridges.Repo.RequestRepo
{
    public class RequestRepo : IRequestRepo
    {
        private readonly ApplicationContext context;
        private DbSet<Request> entities;
        string errorMessage = string.Empty;

        public RequestRepo(ApplicationContext context)
        {
            this.context = context;
            entities = context.Set<Request>();
        }

        public IEnumerable<Request> GetAll()
        {
            return entities.Include(e=> e.CartridgeModel)
                .Include(e=> e.PrinterModel)
                .ThenInclude(e=> e.PrinterCompany)
                .Include(e=> e.Department)
                .Include(e => e.Building)
                .AsEnumerable();
        }
        public Request Get(long id)
        {
            return entities.Include(e => e.CartridgeModel)
                .Include(e => e.PrinterModel)
                .ThenInclude(e => e.PrinterCompany)
                .Include(e => e.Department)
                .Include(e => e.Building)
                .SingleOrDefault(s => s.Id == id);
        }
        public void Insert(Request entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            entities.Add(entity);
            context.SaveChanges();
        }
        public void Update(Request entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            context.SaveChanges();
        }
        public void Delete(Request entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            entities.Remove(entity);
            context.SaveChanges();
        }
        public void Remove(Request entity)
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
