using Hotel.Application.Contracts;
using Hotel.Application.ViewModels.Reading;
using Hotel.Application.ViewModels.Writing;
using Hotel.Domain.Contracts.DomainServices;
using Entities = Hotel.Domain.Entities;

namespace Hotel.Application.ApplicationServices
{
    public class BookingApplicationService : IBookingApplicationService
    {
        private readonly IBookingDomainService _bookingDomainService;

        public BookingApplicationService(IBookingDomainService bookingDomainService)
        {
            _bookingDomainService = bookingDomainService;
        }

        public async Task<bool> CreateBookingAsync(BookingRegistrationViewModel model)
        {
            var booking = new Entities.Booking()
            {
                CheckinDate= model.CheckinDate,
                CheckoutDate= model.CheckoutDate,
                CustomerID= model.CustomerID,
                RoomID= model.RoomID
            };

            return await _bookingDomainService.RegisterAsync(booking);
        }

        public async Task<bool> DeleteBookingAsync(Guid bookingID)
        {
            var room = await _bookingDomainService.GetByIDAsync(bookingID);

            return await _bookingDomainService.DeleteAsync(room);
        }

        public async Task<List<BookingResponseViewModel>> GetAllBookingsAsync()
        {
            var bookings = await _bookingDomainService.GetAllAsync();

            if (bookings.Count == 0 || bookings == null) return null;

            var response = new List<BookingResponseViewModel>();

            foreach (var booking in bookings)
            {
                var model = new BookingResponseViewModel()
                {
                    BookingID = booking.BookingID,
                    CheckinDate = booking.CheckinDate,
                    CheckoutDate = booking.CheckoutDate,
                    CustomerID = booking.CustomerID,
                    RoomID = booking.RoomID,
                    CreatedDate = booking.CreatedDate,
                    LastUpdate = booking.LastUpdate,
                    TotalCost = booking.TotalCost
                };

                response.Add(model);
            }

            return response;
        }

        public async Task<BookingResponseViewModel> GetBookingByIDAsync(Guid bookingID)
        {
            var booking = await _bookingDomainService.GetByIDAsync(bookingID);

            if (booking == null) return null;

            var response = new BookingResponseViewModel()
            {
                BookingID = booking.BookingID,
                RoomID = booking.RoomID,
                CreatedDate = booking.CreatedDate,
                LastUpdate = booking.LastUpdate,
                CustomerID = booking.CustomerID,
                CheckoutDate = booking.CheckoutDate,
                CheckinDate = booking.CheckinDate,
                TotalCost = booking.TotalCost
            };

            return response;
        }

        public async Task<bool> UpdateBookingAsync(BookingUpdateViewModel model)
        {
            var booking = await _bookingDomainService.GetByIDAsync(model.BookingID);

            booking.BookingID = model.BookingID;
            booking.RoomID = model.RoomID;
            booking.CustomerID = model.CustomerID;
            booking.CheckinDate = model.CheckinDate;
            booking.CheckoutDate = model.CheckoutDate;            
            booking.LastUpdate = model.LastUpdate;

            return await _bookingDomainService.UpdateAsync(booking);
        }
    }
}
