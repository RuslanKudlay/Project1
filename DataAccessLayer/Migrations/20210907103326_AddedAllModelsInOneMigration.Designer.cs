﻿// <auto-generated />
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210907103326_AddedAllModelsInOneMigration")]
    partial class AddedAllModelsInOneMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccessLayer.Entities.ComputerManufactyrer", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ManufactyrerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ComputerManufactyrers");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.ComputerModelTag", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ComputerModelId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TagInfo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ComputerModelId");

                    b.ToTable("ComputerModelTags");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.ComtuperModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ComputerManufactyrerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ModelName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ComputerManufactyrerId");

                    b.ToTable("ComtuperModels");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.ComputerModelTag", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.ComtuperModel", "ComputerModel")
                        .WithMany("ComputerModelTag")
                        .HasForeignKey("ComputerModelId");

                    b.OwnsOne("DataAccessLayer.Entities.SalesInfo", "SalesInfo", b1 =>
                        {
                            b1.Property<string>("ComputerModelTagId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("DepartmentLocation")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("DepartmentZipCode")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("SalesDepartment")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ComputerModelTagId");

                            b1.ToTable("ComputerModelTags");

                            b1.WithOwner()
                                .HasForeignKey("ComputerModelTagId");
                        });

                    b.Navigation("ComputerModel");

                    b.Navigation("SalesInfo");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.ComtuperModel", b =>
                {
                    b.HasOne("DataAccessLayer.Entities.ComputerManufactyrer", "ComputerManufactyrer")
                        .WithMany("ComtuperModels")
                        .HasForeignKey("ComputerManufactyrerId");

                    b.Navigation("ComputerManufactyrer");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.ComputerManufactyrer", b =>
                {
                    b.Navigation("ComtuperModels");
                });

            modelBuilder.Entity("DataAccessLayer.Entities.ComtuperModel", b =>
                {
                    b.Navigation("ComputerModelTag");
                });
#pragma warning restore 612, 618
        }
    }
}