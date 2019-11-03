namespace Gevlee.CompanyViewer.Core.Domain.Entities
{
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string TaxNumber { get; set; }

        public string NationalBusinessRegistryNumber { get; set; }

        public string NationalCourtRegister { get; set; }

        public Address Address { get; set; }
    }
}
