using Cartridges.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cartridges.Repo.BillRepo
{
    public class BillRepo : IBillRepo
    {
        private readonly ApplicationContext context;
        private DbSet<Bill> entities;
        string errorMessage = string.Empty;

        public BillRepo(ApplicationContext context)
        {
            this.context = context;
            entities = context.Set<Bill>();
        }

        public IEnumerable<Bill> GetAll()
        {
            return entities.AsEnumerable();
        }
        public Bill Get(long id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }
        public void Insert(Bill entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            entities.Add(entity);
            context.SaveChanges();
        }
        public void Update(Bill entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            context.SaveChanges();
        }
        public void Delete(Bill entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            entities.Remove(entity);
            context.SaveChanges();
        }
        public void Remove(Bill entity)
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
