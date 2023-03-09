using System.ComponentModel.DataAnnotations;

namespace Hotel.Application.ViewModels.Writing
{
    public class BookingRegistrationViewModel
    {
        public Guid BookingID { get; set; }

        [Required(ErrorMessage = "The CheckinDate is required.")]
        public DateTime CheckinDate { get; set; }

        [Required(ErrorMessage = "The CheckoutDate is required.")]
        public DateTime CheckoutDate { get; set; }

        [Required(ErrorMessage = "It's necessary to inform which Customer is booking the hotel room.")]
        public Guid CustomerID { get; set; }

        [Required(ErrorMessage = "It's necessary to inform which hotel Room is being booked by the customer.")]
        public Guid RoomID { get; set; }
                
        public decimal TotalCost { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        public DateTime LastUpdate { get; set; }
    }
}
