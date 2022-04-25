using Cartridges.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cartridges.Repo.CartridgeModelRepo
{
    public interface ICartridgeModelRepo : IRepository<CartridgeModel>
    {
        public bool CheckCartridgeModelsExist();
    }
}
