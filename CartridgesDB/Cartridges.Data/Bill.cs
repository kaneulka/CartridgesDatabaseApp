using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cartridges.Data
{
    public class Bill : BaseModel
    {
        public int BillNumber { get; set; }
        public List<CartridgeModel> CartridgeModels { get; set; }
        public Bill()
        {
            CartridgeModels = new List<CartridgeModel>();
        }
    }
    public class BillMap
    {
        public BillMap(EntityTypeBuilder<Bill> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.Property(e => e.Name).IsRequired();
            entityBuilder.Property(e => e.BillNumber).IsRequired();
            entityBuilder.HasMany(e => e.CartridgeModels).WithOne(e => e.Bill).HasForeignKey(e => e.BillId);
        }
    }
}
