﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eCommerce.Products.Infrastructure;

#nullable disable

namespace eCommerce.Products.Infrastructure.Migrations
{
    [DbContext(typeof(ProductsDBContext))]
    [Migration("20240130034710_ChangeColumnNameKeepingData")]
    partial class ChangeColumnNameKeepingData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("eCommerce.Products.Core.Products.Catalag.Models.ProductDevice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BillingType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Products", t =>
                        {
                            t.HasCheckConstraint("Ck_Product_BillingType", "BillingType IN ('Recurring', 'OneTime')");

                            t.HasCheckConstraint("Ck_Product_Category", "Category IN ('VoicePlanProduct', 'DeviceMobile', 'DeviceTable','Other')");

                            t.HasCheckConstraint("Ck_Product_Status", "Status IN ('Active', 'Inactive')");
                        });
                });

            modelBuilder.Entity("eCommerce.Products.Core.Products.Catalag.Models.ProductDevice", b =>
                {
                    b.OwnsOne("eCommerce.Products.Core.Products.Catalag.Models.ProductDeviceDetails", "Details", b1 =>
                        {
                            b1.Property<int>("ProductDeviceId")
                                .HasColumnType("int");

                            b1.Property<string>("Brand")
                                .IsRequired()
                                .HasMaxLength(60)
                                .HasColumnType("nvarchar(60)");

                            b1.Property<string>("Color")
                                .IsRequired()
                                .HasMaxLength(60)
                                .HasColumnType("nvarchar(60)");

                            b1.Property<string>("Maker")
                                .IsRequired()
                                .HasMaxLength(60)
                                .HasColumnType("nvarchar(60)");

                            b1.Property<string>("Model")
                                .IsRequired()
                                .HasMaxLength(60)
                                .HasColumnType("nvarchar(60)");

                            b1.HasKey("ProductDeviceId");

                            b1.ToTable("Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductDeviceId");
                        });

                    b.Navigation("Details")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
