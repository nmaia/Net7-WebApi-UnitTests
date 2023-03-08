using Hotel.Application.ViewModels.Reading;
using Hotel.Application.ViewModels.Writing;

namespace Hotel.Application.Contracts
{
    public interface IBookingApplicationService
    {
        Task<bool> CreateBookingAsync(BookingRegistrationViewModel model);
        Task<bool> UpdateBookingAsync(BookingUpdateViewModel model);
        Task<bool> DeleteBookingAsync(Guid bookingID);
        Task<List<BookingResponseViewModel>> GetAllBookingsAsync();
        Task<BookingResponseViewModel> GetBookingByIDAsync(Guid bookingID);        
    }
}
