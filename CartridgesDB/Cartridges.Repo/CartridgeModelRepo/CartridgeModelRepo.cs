using Cartridges.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cartridges.Repo.CartridgeModelRepo
{
    public class CartridgeModelRepo : ICartridgeModelRepo
    {
        private readonly ApplicationContext context;
        private DbSet<CartridgeModel> entities;
        string errorMessage = string.Empty;

        public CartridgeModelRepo(ApplicationContext context)
        {
            this.context = context;
            entities = context.Set<CartridgeModel>();
        }

        public IEnumerable<CartridgeModel> GetAll()
        {
            return entities
                .Include(e=> e.Bill)
                .AsEnumerable();
        }
        public CartridgeModel Get(long id)
        {
            return entities
                .Include(e => e.Bill)
                .SingleOrDefault(s => s.Id == id);
        }
        public void Insert(CartridgeModel entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            entities.Add(entity);
            context.SaveChanges();
        }
        public void Update(CartridgeModel entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            context.SaveChanges();
        }
        public void Delete(CartridgeModel entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            entities.Remove(entity);
            context.SaveChanges();
        }
        public void Remove(CartridgeModel entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            entities.Remove(entity);
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public bool CheckCartridgeModelsExist()
        {
            if (entities.Count() > 0) 
                return true; 
            else
                return false;
        }
    }
}
