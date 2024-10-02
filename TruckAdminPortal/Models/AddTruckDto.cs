namespace TruckAdminPortal.Models
{
    public class AddTruckDto
    {
        public Guid Id { get; set; }
        public required string? Name { get; set; }
        public required string LicensePlate { get; set; }
        public required string Supplier { get; set; }
        public decimal InputWeight { get; set; }
        public decimal ExitWeight { get; set; }
        public decimal NetWeight { get; set; }
        public decimal Amount { get; set; }
    }
}
