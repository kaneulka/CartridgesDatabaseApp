﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cartridges.Data
{
    public class Department : BaseModel
    {
        public string OtherNames { get; set; }
        public List<Request> Requests { get; set; }
        public Department()
        {
            Requests = new List<Request>();
        }
    }
    public class DepartmentMap
    {
        public DepartmentMap(EntityTypeBuilder<Department> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);
            entityBuilder.Property(e => e.Name).IsRequired();
            entityBuilder.HasMany(e => e.Requests).WithOne(e => e.Department).HasForeignKey(e => e.DepartmentId);
        }
    }
}
