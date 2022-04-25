using Cartridges.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cartridges.Ser.CartridgeIncomeSer
{
    public interface ICartridgeIncomeService
    {
        IEnumerable<CartridgeIncome> GetCartridgeIncomes();
        CartridgeIncome GetCartridgeIncome(long id);
        void InsertCartridgeIncome(CartridgeIncome entity);
        void UpdateCartridgeIncome(CartridgeIncome entity);
        void DeleteCartridgeIncome(long id);
    }
}
