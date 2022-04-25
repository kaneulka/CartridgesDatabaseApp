using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cartridges.Data
{
    public class Building: BaseModel
    {
        public string OtherNames { get; set; }
        public List<Request> Requests { get; set; }
        public Building()
        {
            Requests = new List<Request>();
        }
    }
    public class BuildingMap
    {
        public BuildingMap(EntityTypeBuilder<Building> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.Property(e => e.Name).IsRequired();
            entityBuilder.HasMany(e => e.Requests).WithOne(e => e.Building).HasForeignKey(e => e.BuildingId);
        }
    }
}
