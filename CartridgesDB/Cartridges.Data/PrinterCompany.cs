using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace Cartridges.Data
{
    public class PrinterCompany:BaseModel
    {
        public List<PrinterModel> PrinterModels { get; set; }

        public PrinterCompany()
        {
            PrinterModels = new List<PrinterModel>();
        }
    }

    public class PrinterCompanyMap
    {
        public PrinterCompanyMap(EntityTypeBuilder<PrinterCompany> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.Property(e => e.Name).IsRequired();
            entityBuilder.HasMany(e => e.PrinterModels).WithOne(e => e.PrinterCompany).HasForeignKey(e => e.PrinterCompanyId);
        }
    }
}
