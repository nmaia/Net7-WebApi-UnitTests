using Hotel.Application.Contracts;
using Hotel.Application.ViewModels.Reading;
using Hotel.Application.ViewModels.Writing;
using Hotel.Domain.Contracts.DomainServices;
using Entities = Hotel.Domain.Entities;

namespace Hotel.Application.ApplicationServices
{
    public class RoomApplicationService : IRoomApplicationService
    {
        private readonly IRoomDomainService _roomDomainService;

        public RoomApplicationService(IRoomDomainService roomDomainService)
        {
            _roomDomainService = roomDomainService;
        }

        public async Task<bool> CreateRoomAsync(RoomRegistrationViewModel model)
        {
            var room = new Entities.Room()
            {
                Number = Convert.ToInt32(model.Number),
                IsAvailable = model.IsAvailable,
                HotelID = model.HotelID,
                DailyRate = decimal.Parse(model.DailyRate)
            };

            return await _roomDomainService.RegisterAsync(room);
        }

        public async Task<bool> DeleteRoomAsync(Guid roomID)
        {
            var room = await _roomDomainService.GetByIDAsync(roomID);

            return await _roomDomainService.DeleteAsync(room);
        }

        public async Task<List<RoomResponseViewModel>> GetAllRoomsAsync()
        {
            var rooms = await _roomDomainService.GetAllAsync();

            if (rooms.Count == 0 || rooms == null) return null;

            var response = new List<RoomResponseViewModel>();

            foreach (var room in rooms)
            {
                var model = new RoomResponseViewModel();

                model.RoomID = room.RoomID;
                model.Number = room.Number.ToString();
                model.IsAvailable = room.IsAvailable;                
                model.HotelID = room.HotelID;
                model.CreatedDate = room.CreatedDate;
                model.LastUpdate = room.LastUpdate;
                model.DailyRate = room.DailyRate.ToString();
                model.NextBookingAvailableDate = room.NextBookingAvailableDate;

                response.Add(model);
            }

            return response;
        }

        public async Task<RoomResponseViewModel> GetRoomByIDAsync(Guid roomID)
        {
            var room = await _roomDomainService.GetByIDAsync(roomID);

            if (room == null) return null;

            var response = new RoomResponseViewModel()
            {
                RoomID = room.RoomID,
                Number = room.Number.ToString(),
                IsAvailable = room.IsAvailable,
                HotelID = room.HotelID,
                CreatedDate = room.CreatedDate,
                LastUpdate = room.LastUpdate,
                DailyRate = room.DailyRate.ToString(),
                NextBookingAvailableDate = room.NextBookingAvailableDate
            };

            return response;
        }

        public async Task<bool> UpdateRoomAsync(RoomUpdateViewModel model)
        {
            var room = await _roomDomainService.GetByIDAsync(model.RoomID);

            room.RoomID = model.RoomID;
            room.Number = Convert.ToInt32(model.Number);
            room.IsAvailable = model.IsAvailable;
            room.HotelID = model.HotelID;
            room.LastUpdate = model.LastUpdate;
            room.DailyRate = decimal.Parse(model.DailyRate);

            return await _roomDomainService.UpdateAsync(room);
        }
    }
}
