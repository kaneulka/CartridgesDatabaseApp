using Cartridges.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cartridges.Repo.BuildingRepo
{
    public class BuildingRepo : IBuildingRepo
    {
        private readonly ApplicationContext context;
        private DbSet<Building> entities;
        string errorMessage = string.Empty;

        public BuildingRepo(ApplicationContext context)
        {
            this.context = context;
            entities = context.Set<Building>();
        }

        public IEnumerable<Building> GetAll()
        {
            return entities.AsEnumerable();
        }
        public Building Get(long id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }
        public void Insert(Building entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            entities.Add(entity);
            context.SaveChanges();
        }
        public void Update(Building entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            context.SaveChanges();
        }
        public void Delete(Building entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            entities.Remove(entity);
            context.SaveChanges();
        }
        public void Remove(Building entity)
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
