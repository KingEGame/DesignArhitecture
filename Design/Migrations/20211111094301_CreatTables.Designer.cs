﻿// <auto-generated />
using System;
using Design.services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Design.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20211111094301_CreatTables")]
    partial class CreatTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Design.objects.Client", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("phone")
                        .HasColumnType("int");

                    b.Property<string>("size")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("clients");
                });

            modelBuilder.Entity("Design.objects.Employer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("position")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("employers");
                });

            modelBuilder.Entity("Design.objects.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("clientid")
                        .HasColumnType("int");

                    b.Property<int?>("employerid")
                        .HasColumnType("int");

                    b.Property<float>("prepaymant")
                        .HasColumnType("real");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.Property<DateTime?>("timeFit")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("timeOfReciept")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("timeReady")
                        .HasColumnType("datetime2");

                    b.Property<int?>("typeOfItemid")
                        .HasColumnType("int");

                    b.Property<int?>("typeOfServid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("clientid");

                    b.HasIndex("employerid");

                    b.HasIndex("typeOfItemid");

                    b.HasIndex("typeOfServid");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("Design.objects.Tariff", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.Property<int?>("typeOfItemid")
                        .HasColumnType("int");

                    b.Property<int?>("typeOfServiceid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("typeOfItemid");

                    b.HasIndex("typeOfServiceid");

                    b.ToTable("tariffs");
                });

            modelBuilder.Entity("Design.objects.TypeOfItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("typeOfItems");
                });

            modelBuilder.Entity("Design.objects.TypeOfService", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("typeOfServices");
                });

            modelBuilder.Entity("Design.objects.Order", b =>
                {
                    b.HasOne("Design.objects.Client", "client")
                        .WithMany()
                        .HasForeignKey("clientid");

                    b.HasOne("Design.objects.Employer", "employer")
                        .WithMany()
                        .HasForeignKey("employerid");

                    b.HasOne("Design.objects.TypeOfItem", "typeOfItem")
                        .WithMany()
                        .HasForeignKey("typeOfItemid");

                    b.HasOne("Design.objects.TypeOfService", "typeOfServ")
                        .WithMany()
                        .HasForeignKey("typeOfServid");
                });

            modelBuilder.Entity("Design.objects.Tariff", b =>
                {
                    b.HasOne("Design.objects.TypeOfItem", "typeOfItem")
                        .WithMany()
                        .HasForeignKey("typeOfItemid");

                    b.HasOne("Design.objects.TypeOfService", "typeOfService")
                        .WithMany()
                        .HasForeignKey("typeOfServiceid");
                });
#pragma warning restore 612, 618
        }
    }
}
