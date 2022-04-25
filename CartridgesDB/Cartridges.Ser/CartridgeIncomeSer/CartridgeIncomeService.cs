using Cartridges.Data;
using Cartridges.Repo.CartridgeIncomeRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cartridges.Ser.CartridgeIncomeSer
{
    public class CartridgeIncomeService : ICartridgeIncomeService
    {
        private ICartridgeIncomeRepo cartridgeIncome;

        public CartridgeIncomeService(ICartridgeIncomeRepo cartridgeIncome)
        {
            this.cartridgeIncome = cartridgeIncome;
        }

        public IEnumerable<CartridgeIncome> GetCartridgeIncomes()
        {
            return cartridgeIncome.GetAll();
        }

        public CartridgeIncome GetCartridgeIncome(long id)
        {
            return cartridgeIncome.Get(id);
        }

        public void InsertCartridgeIncome(CartridgeIncome entity)
        {
            cartridgeIncome.Insert(entity);
        }
        public void UpdateCartridgeIncome(CartridgeIncome entity)
        {
            cartridgeIncome.Update(entity);
        }
        public void DeleteCartridgeIncome(long id)
        {
            CartridgeIncome CartridgeIncome = GetCartridgeIncome(id);
            cartridgeIncome.Remove(CartridgeIncome);
            cartridgeIncome.SaveChanges();
        }
    }
}
