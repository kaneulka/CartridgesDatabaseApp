// <auto-generated />
using System;
using Cartridges.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cartridges.Repo.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210315123812_secnd")]
    partial class secnd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cartridges.Data.Building", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Building");
                });

            modelBuilder.Entity("Cartridges.Data.CartridgeIncome", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("CartridgeModelId")
                        .HasColumnType("bigint");

                    b.Property<long>("IncomeQuantity")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CartridgeModelId");

                    b.ToTable("CartridgeIncome");
                });

            modelBuilder.Entity("Cartridges.Data.CartridgeModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PrinterModelId")
                        .HasColumnType("bigint");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PrinterModelId");

                    b.ToTable("CartridgeModel");
                });

            modelBuilder.Entity("Cartridges.Data.Department", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("Cartridges.Data.PrinterCompany", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PrinterCompany");
                });

            modelBuilder.Entity("Cartridges.Data.PrinterModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PrinterCompanyId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PrinterCompanyId");

                    b.ToTable("PrinterModel");
                });

            modelBuilder.Entity("Cartridges.Data.Request", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("BuildingId")
                        .HasColumnType("bigint");

                    b.Property<long>("CartridgeModelId")
                        .HasColumnType("bigint");

                    b.Property<long>("DepartmentId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.HasIndex("CartridgeModelId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Request");
                });

            modelBuilder.Entity("Cartridges.Data.CartridgeIncome", b =>
                {
                    b.HasOne("Cartridges.Data.CartridgeModel", "CartridgeModel")
                        .WithMany("CartridgesIncome")
                        .HasForeignKey("CartridgeModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CartridgeModel");
                });

            modelBuilder.Entity("Cartridges.Data.CartridgeModel", b =>
                {
                    b.HasOne("Cartridges.Data.PrinterModel", "PrinterModel")
                        .WithMany("CartridgeModels")
                        .HasForeignKey("PrinterModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PrinterModel");
                });

            modelBuilder.Entity("Cartridges.Data.PrinterModel", b =>
                {
                    b.HasOne("Cartridges.Data.PrinterCompany", "PrinterCompany")
                        .WithMany("PrinterModels")
                        .HasForeignKey("PrinterCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PrinterCompany");
                });

            modelBuilder.Entity("Cartridges.Data.Request", b =>
                {
                    b.HasOne("Cartridges.Data.Building", "Building")
                        .WithMany("Requests")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cartridges.Data.CartridgeModel", "CartridgeModel")
                        .WithMany("Requests")
                        .HasForeignKey("CartridgeModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cartridges.Data.Department", "Department")
                        .WithMany("Requests")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");

                    b.Navigation("CartridgeModel");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Cartridges.Data.Building", b =>
                {
                    b.Navigation("Requests");
                });

            modelBuilder.Entity("Cartridges.Data.CartridgeModel", b =>
                {
                    b.Navigation("CartridgesIncome");

                    b.Navigation("Requests");
                });

            modelBuilder.Entity("Cartridges.Data.Department", b =>
                {
                    b.Navigation("Requests");
                });

            modelBuilder.Entity("Cartridges.Data.PrinterCompany", b =>
                {
                    b.Navigation("PrinterModels");
                });

            modelBuilder.Entity("Cartridges.Data.PrinterModel", b =>
                {
                    b.Navigation("CartridgeModels");
                });
#pragma warning restore 612, 618
        }
    }
}
