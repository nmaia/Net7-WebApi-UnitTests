﻿using System.ComponentModel.DataAnnotations;

namespace Hotel.API.Proxy.ViewModels.Writing
{
    public class RoomUpdateViewModel
    {
        public Guid RoomID { get; set; }

        [Required(ErrorMessage = "The Room Number is required.")]
        public string Number { get; set; }

        [Required(ErrorMessage = "It's necessary to inform the room availability.")]
        public bool IsAvailable { get; set; }

        [Required(ErrorMessage = "It's necessary to inform the room DailyRate.")]
        public string DailyRate { get; set; }

        public DateTime LastUpdate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "It's necessary to inform which hotel this room belongs to.")]
        public Guid HotelID { get; set; }
    }
}
