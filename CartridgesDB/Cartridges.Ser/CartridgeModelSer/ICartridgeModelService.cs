using Cartridges.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cartridges.Ser.CartridgeModelSer
{
    public interface ICartridgeModelService
    {
        IEnumerable<CartridgeModel> GetCartridgeModels();
        CartridgeModel GetCartridgeModel(long id);
        void InsertCartridgeModel(CartridgeModel entity);
        void UpdateCartridgeModel(CartridgeModel entity);
        void UpdateCartridgeModels(List<CartridgeModel> entityies);
        void DeleteCartridgeModel(long id);
        public bool CheckCartridgeModelsExist();
    }
}
