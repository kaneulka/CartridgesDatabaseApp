using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cartridges.Data
{
    public class CartridgeModel:BaseModel
    {
        public Bill Bill { get; set; }
        public long BillId { get; set; }

        public long Quantity { get; set; }
        public string NomenclatureNumber { get; set; }

        public List<CartridgeIncome> CartridgesIncome{ get; set; }
        public List<Request> Requests { get; set; }
        public List<CartridgeModelPrinterModel> CartridgeModelPrinterModel { get; set; }
        public CartridgeModel()
        {
            CartridgesIncome = new List<CartridgeIncome>();
            Requests = new List<Request>();
            CartridgeModelPrinterModel = new List<CartridgeModelPrinterModel>();
        }
    }
    public class CartridgeModelMap
    {
        public CartridgeModelMap(EntityTypeBuilder<CartridgeModel> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.Property(e => e.Name).IsRequired();
            entityBuilder.Property(e => e.Quantity).IsRequired();
            entityBuilder.Property(e => e.NomenclatureNumber).IsRequired();
            entityBuilder.HasMany(e => e.CartridgesIncome).WithOne(e => e.CartridgeModel).HasForeignKey(e => e.CartridgeModelId);
            entityBuilder.HasMany(e => e.Requests).WithOne(e => e.CartridgeModel).HasForeignKey(e => e.CartridgeModelId);
            entityBuilder.HasMany(e => e.CartridgeModelPrinterModel).WithOne(e => e.CartridgeModel).HasForeignKey(e => e.CartridgeModelId);
        }
    }
}
