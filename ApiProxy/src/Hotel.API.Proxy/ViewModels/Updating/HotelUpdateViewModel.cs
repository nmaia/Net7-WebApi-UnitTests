using System.ComponentModel.DataAnnotations;

namespace Hotel.API.Proxy.ViewModels.Writing
{
    public class HotelUpdateViewModel
    {
        public Guid HotelID { get; set; }

        [MaxLength(50, ErrorMessage = "Enter at maximum {1} letters.")]
        [Required(ErrorMessage = "The Hotel Name is required.")]
        public string Name { get; set; }
        public DateTime LastUpdate { get; set; } = DateTime.Now;
    }
}
