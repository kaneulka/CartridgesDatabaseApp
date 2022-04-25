using Cartridges.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cartridges.Ser.CartridgeModelPrinterModelSer
{
    public interface ICartridgeModelPrinterModelService
    {
        CartridgeModelPrinterModel Get(CartridgeModelPrinterModel entity);
        List<CartridgeModelPrinterModel> GetAll();
        void Insert(CartridgeModelPrinterModel entity);
        void Delete(CartridgeModelPrinterModel entity);
        void DeleteSome(List<CartridgeModelPrinterModel> entities);
        void InsertSome(List<CartridgeModelPrinterModel> entities);
        bool IsExist(long cartridgeModelId, long printerModelId);
    }
}
