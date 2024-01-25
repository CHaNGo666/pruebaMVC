namespace prueba1.Models
{
    public class CustomerCreateDto
    {
        public string CustomerId { get; set; } = null!;

        public string CompanyName { get; set; } = null!;

        public string? ContactName { get; set; }

        public string? ContactTitle { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Region { get; set; }

        public string? PostalCodeo { get; set; }

        public string? Country { get; set; }

        public string? Phone { get; set; }

        public string? Fao { get; set; }

    }
}
