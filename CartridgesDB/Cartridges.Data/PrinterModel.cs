using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cartridges.Data
{
    public class PrinterModel:BaseModel
    {
        public PrinterCompany PrinterCompany { get; set; }
        public long PrinterCompanyId { get; set; }
        public List <CartridgeModelPrinterModel> CartridgeModelPrinterModel { get; set; }
        public List<Request> Requests { get; set; }
        public PrinterModel()
        {
            CartridgeModelPrinterModel = new List<CartridgeModelPrinterModel>();
            Requests = new List<Request>();
        }
    }
    public class PrinterModelMap
    {
        public PrinterModelMap(EntityTypeBuilder<PrinterModel> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.Property(e => e.Name).IsRequired();
            entityBuilder.HasMany(e => e.CartridgeModelPrinterModel).WithOne(e => e.PrinterModel).HasForeignKey(e => e.PrinterModelId);
            entityBuilder.HasMany(e => e.Requests).WithOne(e => e.PrinterModel).HasForeignKey(e => e.PrinterModelId);
        }
    }
}
