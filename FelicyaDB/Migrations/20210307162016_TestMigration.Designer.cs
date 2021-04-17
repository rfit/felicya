﻿// <auto-generated />
using System;
using FelicyaDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FelicyaDB.Migrations
{
    [DbContext(typeof(FelicyaContext))]
    [Migration("20210307162016_TestMigration")]
    partial class TestMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FelicyaDB.Entities.Material", b =>
                {
                    b.Property<int>("MaterialId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Disposal")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<double>("Height");

                    b.Property<double>("Length");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("NumberOfUnits");

                    b.Property<Guid?>("ProjectId");

                    b.Property<string>("Purpose")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<int>("Type")
                        .HasMaxLength(128);

                    b.Property<DateTime>("UpdatedOn");

                    b.Property<double>("Width");

                    b.HasKey("MaterialId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("FelicyaDB.Entities.Project", b =>
                {
                    b.Property<Guid>("ProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BudgetNumber");

                    b.Property<string>("ConstructionLeader")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("ConstructionPurpose")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("FestivalDivision")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("PhysicalCapacity");

                    b.Property<int>("PhysicalSize");

                    b.Property<string>("ProjectDescription")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("ProjectLeader")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("ProjectNumber");

                    b.Property<string>("ProjectOwner")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<DateTime>("UpdatedOn");

                    b.Property<int>("YearOfConstruction");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("FelicyaDB.Entities.Material", b =>
                {
                    b.HasOne("FelicyaDB.Entities.Project", "Project")
                        .WithMany("Materials")
                        .HasForeignKey("ProjectId");
                });
#pragma warning restore 612, 618
        }
    }
}