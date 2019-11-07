namespace Gevlee.CompanyViewer.Core.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public string AppartmentNumber { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }
    }
}