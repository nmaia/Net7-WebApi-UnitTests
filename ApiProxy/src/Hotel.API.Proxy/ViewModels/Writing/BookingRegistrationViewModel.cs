using System.ComponentModel.DataAnnotations;

namespace Hotel.API.Proxy.ViewModels.Writing
{
    public class BookingRegistrationViewModel
    {
        [Required(ErrorMessage = "The CheckinDate is required.")]
        public DateTime CheckinDate { get; set; }

        [Required(ErrorMessage = "The CheckoutDate is required.")]
        public DateTime CheckoutDate { get; set; }

        [Required(ErrorMessage = "It's necessary to inform which Customer is booking the hotel room.")]
        public Guid CustomerID { get; set; }

        [Required(ErrorMessage = "It's necessary to inform which hotel Room is being booked by the customer.")]
        public Guid RoomID { get; set; }
    }
}
