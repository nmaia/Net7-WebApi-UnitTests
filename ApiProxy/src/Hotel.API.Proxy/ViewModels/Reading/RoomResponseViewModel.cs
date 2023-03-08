namespace Hotel.API.Proxy.ViewModels.Reading
{
    public class RoomResponseViewModel
    {
        public Guid RoomID { get; set; }
        public string Number { get; set; }
        public bool IsAvailable { get; set; }
        public Guid HotelID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public string DailyRate { get; set; }
        public DateTime NextBookingAvailableDate { get; set; }
    }
}
