using Cartridges.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cartridges.Repo.DepartmentRepo
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly ApplicationContext context;
        private DbSet<Department> entities;
        string errorMessage = string.Empty;

        public DepartmentRepo(ApplicationContext context)
        {
            this.context = context;
            entities = context.Set<Department>();
        }

        public IEnumerable<Department> GetAll()
        {
            return entities.AsEnumerable();
        }
        public Department Get(long id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }
        public void Insert(Department entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            entities.Add(entity);
            context.SaveChanges();
        }
        public void Update(Department entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            context.SaveChanges();
        }
        public void Delete(Department entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            entities.Remove(entity);
            context.SaveChanges();
        }
        public void Remove(Department entity)
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
