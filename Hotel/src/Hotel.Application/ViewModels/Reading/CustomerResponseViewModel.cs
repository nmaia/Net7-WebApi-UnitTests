namespace Hotel.Application.ViewModels.Reading
{
    public class CustomerResponseViewModel
    {
        public Guid CustomerID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string SIN { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
