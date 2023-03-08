namespace Hotel.Domain.Entities
{
    public class Customer
    {
        public Guid CustomerID { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public int SIN { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastUpdate { get; set; }

        public virtual List<Booking> Bookings { get; set; }
    }
}
