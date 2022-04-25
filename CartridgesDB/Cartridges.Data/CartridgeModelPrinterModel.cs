using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cartridges.Data
{
    public class CartridgeModelPrinterModel
    {
        public long Id { get; set; }
        public long CartridgeModelId { get; set; }
        public CartridgeModel CartridgeModel { get; set; }
        public long PrinterModelId { get; set; }
        public PrinterModel PrinterModel { get; set; }
    }
    public class CartridgeModelPrinterModelMap
    {
        public CartridgeModelPrinterModelMap(EntityTypeBuilder<CartridgeModelPrinterModel> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);
        }
    }
}
