using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace SupermarkerWEB.Models
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string? Description { get; set; }

    }
}
