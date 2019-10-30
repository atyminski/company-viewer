﻿// <auto-generated />
using System;
using Gevlee.CompanyViewer.Core.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Gevlee.CompanyViewer.Core.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(PostgresCompaniesDbContext))]
    [Migration("20191030200017_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Gevlee.CompanyViewer.Core.Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AppartmentNumber")
                        .HasColumnName("appartment_number")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnName("city")
                        .HasColumnType("text");

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasColumnName("house_number")
                        .HasColumnType("text");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnName("postal_code")
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnName("street")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("pk_address");

                    b.ToTable("address");
                });

            modelBuilder.Entity("Gevlee.CompanyViewer.Core.Domain.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("AddressId")
                        .HasColumnName("address_id")
                        .HasColumnType("integer");

                    b.Property<string>("NationalBusinessRegistryNumber")
                        .IsRequired()
                        .HasColumnName("national_business_registry_number")
                        .HasColumnType("text");

                    b.Property<string>("NationalCourtRegister")
                        .IsRequired()
                        .HasColumnName("national_court_register")
                        .HasColumnType("text");

                    b.Property<string>("TaxNumber")
                        .IsRequired()
                        .HasColumnName("tax_number")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("pk_company");

                    b.HasIndex("AddressId")
                        .HasName("ix_company_address_id");

                    b.HasIndex("NationalBusinessRegistryNumber")
                        .HasName("ix_company_national_business_registry_number");

                    b.HasIndex("NationalCourtRegister")
                        .HasName("ix_company_national_court_register");

                    b.HasIndex("TaxNumber")
                        .HasName("ix_company_tax_number");

                    b.ToTable("company");
                });

            modelBuilder.Entity("Gevlee.CompanyViewer.Core.Domain.Entities.CompanySearchRequest", b =>
                {
                    b.Property<string>("RequestData")
                        .IsRequired()
                        .HasColumnName("request_data")
                        .HasColumnType("text");

                    b.Property<string>("SearchPhrase")
                        .IsRequired()
                        .HasColumnName("search_phrase")
                        .HasColumnType("text");

                    b.ToTable("company_search_request");
                });

            modelBuilder.Entity("Gevlee.CompanyViewer.Core.Domain.Entities.Company", b =>
                {
                    b.HasOne("Gevlee.CompanyViewer.Core.Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .HasConstraintName("fk_company_address_address_id");
                });
#pragma warning restore 612, 618
        }
    }
}