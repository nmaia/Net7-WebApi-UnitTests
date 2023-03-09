using System.ComponentModel.DataAnnotations;

namespace Hotel.API.Proxy.ViewModels.Writing
{
    public class RoomRegistrationViewModel
    {
        [Required(ErrorMessage = "The Room Number is required.")]
        public int Number { get; set; }

        [Required(ErrorMessage = "It's necessary to inform the room availability.")]
        public bool IsAvailable { get; set; }

        [Required(ErrorMessage = "It's necessary to inform the room DailyRate.")]
        public decimal DailyRate { get; set; }

        [Required(ErrorMessage = "It's necessary to inform which hotel this room belongs to.")]
        public Guid HotelID { get; set; }
    }
}
