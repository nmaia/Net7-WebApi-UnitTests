namespace Hotel.API.Proxy.ViewModels.Reading
{
    public class BookingResponseViewModel
    {
        public Guid BookingID { get; set; }
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public decimal TotalCost { get; set; }
        public Guid CustomerID { get; set; }
        public Guid RoomID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
