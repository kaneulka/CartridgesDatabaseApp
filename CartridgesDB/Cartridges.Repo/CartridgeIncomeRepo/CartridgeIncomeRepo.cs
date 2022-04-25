using Cartridges.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cartridges.Repo.CartridgeIncomeRepo
{
    public class CartridgeIncomeRepo : ICartridgeIncomeRepo
    {
        private readonly ApplicationContext context;
        private DbSet<CartridgeIncome> entities;
        string errorMessage = string.Empty;

        public CartridgeIncomeRepo(ApplicationContext context)
        {
            this.context = context;
            entities = context.Set<CartridgeIncome>();
        }

        public IEnumerable<CartridgeIncome> GetAll()
        {
            return entities.Include(c=> c.CartridgeModel)
                .AsEnumerable();
        }
        public CartridgeIncome Get(long id)
        {
            return entities.Include(c => c.CartridgeModel)
                .SingleOrDefault(s => s.Id == id);
        }
        public void Insert(CartridgeIncome entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            entities.Add(entity);
            context.SaveChanges();
        }
        public void Update(CartridgeIncome entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            context.SaveChanges();
        }
        public void Delete(CartridgeIncome entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            entities.Remove(entity);
            context.SaveChanges();
        }
        public void Remove(CartridgeIncome entity)
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
