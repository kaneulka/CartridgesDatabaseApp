using Cartridges.Data;
using Cartridges.Repo.CartridgeModelRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cartridges.Ser.CartridgeModelSer
{
    public class CartridgeModelService : ICartridgeModelService
    {
        private ICartridgeModelRepo cartridgeModelRepository;

        public CartridgeModelService(ICartridgeModelRepo cartridgeModelRepository)
        {
            this.cartridgeModelRepository = cartridgeModelRepository;
        }

        public IEnumerable<CartridgeModel> GetCartridgeModels()
        {
            return cartridgeModelRepository.GetAll();
        }

        public CartridgeModel GetCartridgeModel(long id)
        {
            return cartridgeModelRepository.Get(id);
        }

        public void InsertCartridgeModel(CartridgeModel entity)
        {
            cartridgeModelRepository.Insert(entity);
        }
        public void UpdateCartridgeModel(CartridgeModel entity)
        {
            cartridgeModelRepository.Update(entity);
        }
        public void UpdateCartridgeModels(List<CartridgeModel> entities)
        {
            entities.ForEach(entity=> cartridgeModelRepository.Update(entity));
        }
        public void DeleteCartridgeModel(long id)
        {
            CartridgeModel cartridgeModel = GetCartridgeModel(id);
            cartridgeModelRepository.Remove(cartridgeModel);
            cartridgeModelRepository.SaveChanges();
        }
        public bool CheckCartridgeModelsExist()
        {
            return cartridgeModelRepository.CheckCartridgeModelsExist();
        }
    }
}
