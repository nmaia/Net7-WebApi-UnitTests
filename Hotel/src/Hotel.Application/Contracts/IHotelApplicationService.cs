using Hotel.Application.ViewModels.Reading;
using Hotel.Application.ViewModels.Writing;

namespace Hotel.Application.Contracts
{
    public interface IHotelApplicationService
    {
        Task<HotelRegistrationViewModel> CreateHotelAsync(HotelRegistrationViewModel model);
        Task<bool> UpdateHotelAsync(HotelUpdateViewModel model);
        Task<bool> DeleteHotelAsync(Guid hotelID);
        Task<List<HotelResponseViewModel>> GetAllHotelsAsync();
        Task<HotelResponseViewModel> GetHotelByIDAsync(Guid hotelID);        
    }
}
