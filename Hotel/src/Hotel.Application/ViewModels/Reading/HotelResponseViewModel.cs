namespace Hotel.Application.ViewModels.Reading
{
    public class HotelResponseViewModel
    {
        public Guid HotelID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
