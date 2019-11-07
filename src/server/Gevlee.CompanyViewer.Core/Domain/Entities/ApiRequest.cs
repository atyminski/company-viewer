using System;

namespace Gevlee.CompanyViewer.Core.Domain.Entities
{
    public class ApiRequest
    {
        public string Id { get; set; }

        public DateTime Timestamp { get; set; }

        public string RequestData { get; set; }
    }
}
