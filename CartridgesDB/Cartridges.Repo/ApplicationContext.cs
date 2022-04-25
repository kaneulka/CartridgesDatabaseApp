using Cartridges.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cartridges.Repo
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Bill> Bill { get; set; }
        public DbSet<Building> Building { get; set; }
        public DbSet<Department> Department { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new PrinterCompanyMap(modelBuilder.Entity<PrinterCompany>());
            new PrinterModelMap(modelBuilder.Entity<PrinterModel>());
            new CartridgeModelMap(modelBuilder.Entity<CartridgeModel>());
            new CartridgeIncomeMap(modelBuilder.Entity<CartridgeIncome>());
            new RequestMap(modelBuilder.Entity<Request>());
            new BuildingMap(modelBuilder.Entity<Building>());
            new DepartmentMap(modelBuilder.Entity<Department>());
            new BillMap(modelBuilder.Entity<Bill>());
            new CartridgeModelPrinterModelMap(modelBuilder.Entity<CartridgeModelPrinterModel>());
        }
    }
}
