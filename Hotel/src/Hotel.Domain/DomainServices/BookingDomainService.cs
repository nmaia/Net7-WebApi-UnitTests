using Hotel.Domain.Entities;
using Hotel.Domain.Contracts.DomainServices;
using Hotel.Domain.Contracts.Repositories;

namespace Hotel.Domain.DomainServices
{
    public class BookingDomainService : BaseDomainService<Booking>, IBookingDomainService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IRoomRepository _roomRepository;

        public BookingDomainService(IBookingRepository bookingRepository, IRoomRepository roomRepository)
            : base(bookingRepository)
        {
            _bookingRepository = bookingRepository;
            _roomRepository = roomRepository;
        }

        //todo: improve this method to return an object instead of bool.
        //todo: replace bool returns by validation messages (add them to a list of messages)
        //todo: we could use fluent validation here in order to avoid lots of IFs
        public override async Task<Booking> CreateAsync(Booking booking)
        {
            var numberOfNights = (int)booking.CheckoutDate.Subtract(booking.CheckinDate).TotalDays;
            var room = await _roomRepository.GetByIDAsync(booking.RoomID);

            if(this.IsBookingValidForCreation(booking, room, numberOfNights))
            {
                booking.TotalCost = numberOfNights * room.DailyRate;
                var result = await _bookingRepository.CreateAsync(booking);

                room.IsAvailable = false;
                room.NextBookingAvailableDate = booking.CheckinDate.AddDays(numberOfNights);
                await _roomRepository.UpdateAsync(room);

                return result;
            }
            else
            {
                return null;
            }
        }

        public override async Task<bool> UpdateAsync(Booking booking)
        {
            booking.TotalCost = 0; // the value will be updated based on the new period of stay

            var numberOfNights = (int)booking.CheckoutDate.Subtract(booking.CheckinDate).TotalDays;
            var room = await _roomRepository.GetByIDAsync(booking.RoomID);

            if(this.IsBookingValidForUpdate(booking, room, numberOfNights))
            {
                booking.TotalCost = numberOfNights * room.DailyRate;
                await _bookingRepository.UpdateAsync(booking);

                room.IsAvailable = false;
                room.NextBookingAvailableDate = booking.CheckinDate.AddDays(numberOfNights);
                await _roomRepository.UpdateAsync(room);

                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsBookingValidForUpdate(Booking booking, Room room, int numberOfNights)
        {
            if (booking.CheckinDate < DateTime.Now || booking.CheckoutDate < DateTime.Now) return false;

            if (room == null) return false;

            if (numberOfNights > 3) return false;

            if ((booking.CheckinDate - DateTime.Today).Days > 30) return false;

            return true;
        }

        private bool IsBookingValidForCreation(Booking booking, Room room, int numberOfNights)
        {
            if (booking.CheckinDate < DateTime.Now || booking.CheckoutDate < DateTime.Now) return false;

            if (room == null) return false;

            if (!room.IsAvailable) return false;            

            if (numberOfNights > 3) return false;

            if ((booking.CheckinDate - DateTime.Today).Days > 30) return false;

            if (booking.CheckinDate <= room.NextBookingAvailableDate) return false;

            return true;
        }
    }
}
