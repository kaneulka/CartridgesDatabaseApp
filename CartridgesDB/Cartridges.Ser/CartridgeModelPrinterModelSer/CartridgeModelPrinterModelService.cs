using Cartridges.Data;
using Cartridges.Repo.CartridgeModelPrinterModelRepo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cartridges.Ser.CartridgeModelPrinterModelSer
{
    public class CartridgeModelPrinterModelService : ICartridgeModelPrinterModelService
    {
        private ICartridgeModelPrinterModelRepo cartridgeModelPrinterModelRepository;

        public CartridgeModelPrinterModelService(ICartridgeModelPrinterModelRepo cartridgeModelPrinterModelRepository)
        {
            this.cartridgeModelPrinterModelRepository = cartridgeModelPrinterModelRepository;
        }

        public CartridgeModelPrinterModel Get(CartridgeModelPrinterModel entity)
        {
            return cartridgeModelPrinterModelRepository.Get(entity);
        }
        public List<CartridgeModelPrinterModel> GetAll()
        {
            return cartridgeModelPrinterModelRepository.GetAll();
        }

        public void Insert(CartridgeModelPrinterModel cartridgeModelPrinterModel)
        {
            cartridgeModelPrinterModelRepository.Insert(cartridgeModelPrinterModel);
        }

        public void Delete(CartridgeModelPrinterModel entity)
        {
            cartridgeModelPrinterModelRepository.Delete(entity);
            cartridgeModelPrinterModelRepository.SaveChanges();
        }
        public void DeleteSome(List<CartridgeModelPrinterModel> entities)
        {
            cartridgeModelPrinterModelRepository.DeleteSome(entities);
            cartridgeModelPrinterModelRepository.SaveChanges();
        }
        public void InsertSome(List<CartridgeModelPrinterModel> entities)
        {
            cartridgeModelPrinterModelRepository.InsertSome(entities);
            cartridgeModelPrinterModelRepository.SaveChanges();
        }
        public bool IsExist(long cartridgeModelId, long printerModelId)
        {
            return cartridgeModelPrinterModelRepository.IsExist(cartridgeModelId, printerModelId);
        }
    }
}
