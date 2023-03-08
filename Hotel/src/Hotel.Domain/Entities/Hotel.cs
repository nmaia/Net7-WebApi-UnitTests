namespace Hotel.Domain.Entities
{
    public class Hotel
    {
        public Guid HotelID { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastUpdate { get; set; }
        
        public virtual List<Room> Rooms { get; set; }
        public virtual List<Booking> Bookings { get; set; }
    }
}
