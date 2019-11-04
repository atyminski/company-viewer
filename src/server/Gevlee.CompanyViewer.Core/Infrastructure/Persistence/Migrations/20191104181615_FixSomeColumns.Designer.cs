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
    [Migration("20191104181615_FixSomeColumns")]
    partial class FixSomeColumns
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
                        .HasColumnType("character varying(10)")
                        .HasMaxLength(10);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnName("city")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasColumnName("house_number")
                        .HasColumnType("character varying(10)")
                        .HasMaxLength(10);

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnName("postal_code")
                        .HasColumnType("character varying(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnName("street")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("NationalBusinessRegistryNumber")
                        .IsRequired()
                        .HasColumnName("national_business_registry_number")
                        .HasColumnType("character varying(9)")
                        .HasComment("National Business Registry Number")
                        .HasMaxLength(9);

                    b.Property<string>("NationalCourtRegisterNumber")
                        .IsRequired()
                        .HasColumnName("national_court_register_number")
                        .HasColumnType("character varying(9)")
                        .HasComment("National Court Register Number")
                        .HasMaxLength(9);

                    b.Property<string>("TaxNumber")
                        .IsRequired()
                        .HasColumnName("tax_number")
                        .HasColumnType("character varying(10)")
                        .HasMaxLength(10);

                    b.HasKey("Id")
                        .HasName("pk_company");

                    b.HasIndex("AddressId")
                        .HasName("ix_company_address_id");

                    b.HasIndex("NationalBusinessRegistryNumber")
                        .HasName("ix_company_national_business_registry_number");

                    b.HasIndex("NationalCourtRegisterNumber")
                        .HasName("ix_company_national_court_register_number");

                    b.HasIndex("TaxNumber")
                        .HasName("ix_company_tax_number");

                    b.ToTable("company");
                });

            modelBuilder.Entity("Gevlee.CompanyViewer.Core.Domain.Entities.CompanySearchRequest", b =>
                {
                    b.Property<string>("Ip")
                        .HasColumnName("ip")
                        .HasColumnType("character varying(15)")
                        .HasMaxLength(15);

                    b.Property<string>("RequestData")
                        .IsRequired()
                        .HasColumnName("request_data")
                        .HasColumnType("jsonb");

                    b.Property<string>("SearchPhrase")
                        .IsRequired()
                        .HasColumnName("search_phrase")
                        .HasColumnType("text");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnName("timestamp")
                        .HasColumnType("timestamp without time zone");

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
