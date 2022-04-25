using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cartridges.Data
{
    public class CartridgeIncome:BaseModel
    {
        public long IncomeQuantity { get; set; }
        public CartridgeModel CartridgeModel { get; set; }
        public long CartridgeModelId { get; set; }
    }
    public class CartridgeIncomeMap
    {
        public CartridgeIncomeMap(EntityTypeBuilder<CartridgeIncome> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.Property(e => e.Name).IsRequired();
        }
    }
}
