using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cartridges.Data
{
    public class Request:BaseModel
    {
        public long CartridgeModelId { get; set; }
        public CartridgeModel CartridgeModel { get; set; }
        public long BuildingId { get; set; }
        public Building Building { get; set; }
        public long DepartmentId { get; set; }
        public Department Department { get; set; }
        public string Room { get; set; }
        public string InventoryNumber { get; set; }
        public long PrinterModelId { get; set; }
        public PrinterModel PrinterModel { get; set; }
        public bool Defective { get; set; }
    }
    public class RequestMap
    {
        public RequestMap(EntityTypeBuilder<Request> entityBuilder)
        { 
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.Property(e => e.Name).IsRequired();
            entityBuilder.Property(e => e.InventoryNumber).IsRequired();
            entityBuilder.Property(e => e.Room).IsRequired();
        }
    }
}
