namespace Hotel.Domain.Entities
{
    public class Room
    {
        public Guid RoomID { get; set; } = Guid.NewGuid();
        public int Number { get; set; }
        public bool IsAvailable { get; set; }
        public decimal DailyRate { get; set; }
        public DateTime NextBookingAvailableDate { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastUpdate { get; set; }
        
        public Guid HotelID { get; set; }
        public virtual Hotel Hotel { get; set; }

        public virtual List<Booking> Bookings { get; set; }
    }
}
