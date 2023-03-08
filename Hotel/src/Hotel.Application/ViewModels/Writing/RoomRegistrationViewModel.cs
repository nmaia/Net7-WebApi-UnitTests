using System.ComponentModel.DataAnnotations;

namespace Hotel.Application.ViewModels.Writing
{
    public class RoomRegistrationViewModel
    {
        [Required(ErrorMessage = "The Room Number is required.")]
        public string Number { get; set; }

        [Required(ErrorMessage = "It's necessary to inform the room availability.")]
        public bool IsAvailable { get; set; }

        [Required(ErrorMessage = "It's necessary to inform the room DailyRate.")]
        public string DailyRate { get; set; }

        [Required(ErrorMessage = "It's necessary to inform which hotel this room belongs to.")]
        public Guid HotelID { get; set; }
    }
}
