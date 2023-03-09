using System.ComponentModel.DataAnnotations;

namespace Hotel.API.Proxy.ViewModels.Writing
{
    public class CustomerRegistrationViewModel
    {
        public Guid CustomerID { get; set; }

        [MinLength(2, ErrorMessage = "Enter at least {1} letters.")]
        [MaxLength(100, ErrorMessage = "Enter at maximum {1} letters.")]
        [Required(ErrorMessage = "The client name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The BirthDate is required.")]
        public DateTime BirthDate { get; set; }

        [MaxLength(100, ErrorMessage = "Enter at maximum {1} letters.")]
        [EmailAddress(ErrorMessage = "The Email is invalid.")]
        [Required(ErrorMessage = "The Email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The SIN is required.")]
        public int SIN { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}
