using Cartridges.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cartridges.Repo.CartridgeModelPrinterModelRepo
{
    public class CartridgeModelPrinterModelRepo : ICartridgeModelPrinterModelRepo
    {
        private readonly ApplicationContext context;
        private DbSet<CartridgeModelPrinterModel> cartridgeModelPrinterModel;
        string errorMessage = string.Empty;

        public CartridgeModelPrinterModelRepo(ApplicationContext context)
        {
            this.context = context;
            cartridgeModelPrinterModel = context.Set<CartridgeModelPrinterModel>();
        }

        public CartridgeModelPrinterModel Get(CartridgeModelPrinterModel entity)
        {
            return cartridgeModelPrinterModel.SingleOrDefault(s => s.CartridgeModelId == entity.CartridgeModelId && s.PrinterModelId == entity.PrinterModelId);
        }

        public List<CartridgeModelPrinterModel> GetAll()
        {
            return cartridgeModelPrinterModel.ToList();
        }
        public void Insert(CartridgeModelPrinterModel entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            cartridgeModelPrinterModel.Add(entity);
            context.SaveChanges();
        }
        public void Delete(CartridgeModelPrinterModel entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            cartridgeModelPrinterModel.Remove(entity);
            context.SaveChanges();
        }
        public void DeleteSome(List<CartridgeModelPrinterModel> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entity");
            }
            foreach (var entity in entities)
            {
                cartridgeModelPrinterModel.Remove(entity);
            }
            context.SaveChanges();
        }
        public void InsertSome(List<CartridgeModelPrinterModel> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entity");
            }
            foreach (var entity in entities)
            {
                cartridgeModelPrinterModel.Add(entity);
            }
            context.SaveChanges();
        }
        public void Remove(CartridgeModelPrinterModel entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            cartridgeModelPrinterModel.Remove(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public bool IsExist(long cartridgeModelId, long printerModelId)
        {
            if (cartridgeModelId > 0)
            {
                if (cartridgeModelPrinterModel.Where(cpm=> cpm.CartridgeModelId == cartridgeModelId).Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (printerModelId > 0)
                {
                    if (cartridgeModelPrinterModel.Where(cpm => cpm.PrinterModelId == printerModelId).Count() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else return false;
            }
        }
    }
}
