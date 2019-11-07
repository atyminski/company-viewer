using Gevlee.CompanyViewer.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gevlee.CompanyViewer.Core.Infrastructure.Persistence.Seed
{
    public class CompaniesSeeder : SeederBase
    {
        protected override Func<CompaniesDbContext, bool> SeedingRequired => (context) => !context.Set<Company>().Any();

        protected override IEnumerable<object> Data =>
            new Company[]{
                new Company
                {
                    Name = "Nisl Elementum Purus Corp.",
                    NationalBusinessRegistryNumber = "958798884",
                    NationalCourtRegisterNumber = "000000001",
                    TaxNumber = "3764470566",
                    Address = new Address
                    {
                        Street = "Poznańska",
                        HouseNumber = "56F",
                        AppartmentNumber = "6",
                        PostalCode = "50-001",
                        City = "Wrocław"
                    },
                },
                new Company
                {
                    Name = "Sed Auctor PC",
                    NationalBusinessRegistryNumber = "176102391",
                    NationalCourtRegisterNumber = "000000002",
                    TaxNumber = "5689992630",
                    Address = new Address
                    {
                        Street = "Nowa",
                        HouseNumber = "62",
                        AppartmentNumber = null,
                        PostalCode = "01-001",
                        City = "Warszawa"
                    },
                },
                new Company
                {
                    Name = "Dui Limited",
                    NationalBusinessRegistryNumber = "577317336",
                    NationalCourtRegisterNumber = "000000003",
                    TaxNumber = "5096231929",
                    Address = new Address
                    {
                        Street = "Wiejska",
                        HouseNumber = "6",
                        AppartmentNumber = "7",
                        PostalCode = "50-002",
                        City = "Wrocław"
                    },
                },
                new Company
                {
                    Name = "Eget Magna Suspendisse Consulting",
                    NationalBusinessRegistryNumber = "298636221",
                    NationalCourtRegisterNumber = "000000004",
                    TaxNumber = "8260839761",
                    Address = new Address
                    {
                        Street = "Dworcowa",
                        HouseNumber = "77",
                        AppartmentNumber = null,
                        PostalCode = "10-006",
                        City = "Olsztyn"
                    },
                },
                new Company
                {
                    Name = "Mauris Morbi Non Institute",
                    NationalBusinessRegistryNumber = "679594841",
                    NationalCourtRegisterNumber = "000000005",
                    TaxNumber = "5223144431",
                    Address = new Address
                    {
                        Street = "Mostowa",
                        HouseNumber = "88",
                        AppartmentNumber = "6",
                        PostalCode = "87-101",
                        City = "Toruń"
                    },
                },
                new Company
                {
                    Name = "Scelerisque Lorem Ipsum Industries",
                    NationalBusinessRegistryNumber = "136387812",
                    NationalCourtRegisterNumber = "000000006",
                    TaxNumber = "5099185420",
                    Address = new Address
                    {
                        Street = "Bałtycka",
                        HouseNumber = "202",
                        AppartmentNumber = "56",
                        PostalCode = "80-012",
                        City = "Gdańsk"
                    },
                },
                new Company
                {
                    Name = "Sapien Ltd",
                    NationalBusinessRegistryNumber = "259580420",
                    NationalCourtRegisterNumber = "000000007",
                    TaxNumber = "1198228840",
                    Address = new Address
                    {
                        Street = "Grudziądzka",
                        HouseNumber = "1",
                        AppartmentNumber = null,
                        PostalCode = "80-212",
                        City = "Gdynia"
                    },
                },

                new Company
                {
                    Name = "Consectetuer Company",
                    NationalBusinessRegistryNumber = "499702570",
                    NationalCourtRegisterNumber = "000000008",
                    TaxNumber = "5317067582",
                    Address = new Address
                    {
                        Street = "Kościuszki",
                        HouseNumber = "44",
                        AppartmentNumber = null,
                        PostalCode = "50-301",
                        City = "Sopot"
                    },
                },

                new Company
                {
                    Name = "Mi Foundation",
                    NationalBusinessRegistryNumber = "452839310",
                    NationalCourtRegisterNumber = "000000009",
                    TaxNumber = "3811670925",
                    Address = new Address
                    {
                        Street = "Kubusia Puchatka",
                        HouseNumber = "33",
                        AppartmentNumber = null,
                        PostalCode = "35-232",
                        City = "Rzeszów"
                    },
                },

                new Company
                {
                    Name = "Elit Inc.",
                    NationalBusinessRegistryNumber = "753810090",
                    NationalCourtRegisterNumber = "000000010",
                    TaxNumber = "1117644618",
                    Address = new Address
                    {
                        Street = "Centralna",
                        HouseNumber = "2",
                        AppartmentNumber = "1",
                        PostalCode = "45-011",
                        City = "Opole"
                    },
                },
            };
    }
}
