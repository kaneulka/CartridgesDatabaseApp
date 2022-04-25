using Cartridges.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cartridges.Repo.CartridgeModelPrinterModelRepo
{
    public interface ICartridgeModelPrinterModelRepo
    {
        CartridgeModelPrinterModel Get(CartridgeModelPrinterModel entity);
        List<CartridgeModelPrinterModel> GetAll();
        void Insert(CartridgeModelPrinterModel entity);
        void Delete(CartridgeModelPrinterModel entity);
        void DeleteSome(List<CartridgeModelPrinterModel> entities);
        void InsertSome(List<CartridgeModelPrinterModel> entities);
        bool IsExist(long cartridgeModelId, long printerModelId);
        void Remove(CartridgeModelPrinterModel entity);
        void SaveChanges();
    }
}
