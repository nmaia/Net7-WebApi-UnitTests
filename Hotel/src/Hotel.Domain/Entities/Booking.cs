namespace Hotel.Domain.Entities
{
    public class Booking
    {
        public Guid BookingID { get; set; } = Guid.NewGuid();
        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastUpdate { get; set; }

        public Guid CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        public Guid RoomID { get; set; }
        public virtual Room Room { get; set; }
    }
}
