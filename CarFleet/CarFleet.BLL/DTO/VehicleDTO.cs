namespace CarFleet.BLL.DTO
{
    public class VehicleDTO
    {
        public string? Id { get; set; }
        public string? CategoryId { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? Description { get; set; }
        public string? PathFile { get; set; }
        public int Price { get; set; }
        public int Horsepower { get; set; }
        public int NumberOfSeats { get; set; }
        public int Mileage { get; set; }
    }
}
