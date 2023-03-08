using Hotel.Application.Contracts;
using Hotel.Application.ViewModels.Reading;
using Hotel.Application.ViewModels.Writing;
using Hotel.Domain.Contracts.DomainServices;
using Entities = Hotel.Domain.Entities;

namespace Hotel.Application.ApplicationServices
{
    public class HotelApplicationService : IHotelApplicationService
    {
        private readonly IHotelDomainService _hotelDomainService;

        public HotelApplicationService(IHotelDomainService hotelDomainService)
        {
            _hotelDomainService = hotelDomainService;
        }

        public async Task<bool> CreateHotelAsync(HotelRegistrationViewModel model)
        {
            var hotel = new Entities.Hotel()
            {
                Name= model.Name
            };

            return await _hotelDomainService.RegisterAsync(hotel);
        }

        public async Task<bool> UpdateHotelAsync(HotelUpdateViewModel model)
        {
            var hotel = await _hotelDomainService.GetByIDAsync(model.HotelID);

            hotel.Name = model.Name;
            hotel.LastUpdate = model.LastUpdate;

            return await _hotelDomainService.UpdateAsync(hotel);
        }

        public async Task<bool> DeleteHotelAsync(Guid hotelID)
        {
            var hotel = await _hotelDomainService.GetByIDAsync(hotelID);

            return await _hotelDomainService.DeleteAsync(hotel);
        }

        public async Task<List<HotelResponseViewModel>> GetAllHotelsAsync()
        {
            var hotels = await _hotelDomainService.GetAllAsync();

            if (hotels.Count == 0 || hotels == null) return null;

            var response = new List<HotelResponseViewModel>();

            foreach (var hotel in hotels)
            {
                var model = new HotelResponseViewModel();

                model.HotelID = hotel.HotelID;
                model.Name = hotel.Name;
                model.CreatedDate = hotel.CreatedDate;
                model.LastUpdate = hotel.LastUpdate;

                response.Add(model);
            }

            return response;
        }

        public async Task<HotelResponseViewModel> GetHotelByIDAsync(Guid hotelID)
        {
            var hotel = await _hotelDomainService.GetByIDAsync(hotelID);

            if(hotel == null) return null;

            var response = new HotelResponseViewModel()
            {
                HotelID = hotel.HotelID,
                Name = hotel.Name,
                CreatedDate = hotel.CreatedDate,
                LastUpdate = hotel.LastUpdate
            };

            return response;
        }
    }
}
