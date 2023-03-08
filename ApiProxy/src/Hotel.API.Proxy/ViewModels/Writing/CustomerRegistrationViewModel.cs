using System.ComponentModel.DataAnnotations;

namespace Hotel.API.Proxy.ViewModels.Writing
{
    public class CustomerRegistrationViewModel
    {
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

        [MaxLength(9, ErrorMessage = "Enter at maximum {1} letters.")]
        [Required(ErrorMessage = "The SIN is required.")]
        public string SIN { get; set; }
    }
}
