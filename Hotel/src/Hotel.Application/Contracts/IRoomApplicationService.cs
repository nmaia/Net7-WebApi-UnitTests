using Hotel.Application.ViewModels.Reading;
using Hotel.Application.ViewModels.Writing;

namespace Hotel.Application.Contracts
{
    public interface IRoomApplicationService
    {
        Task<RoomRegistrationViewModel> CreateRoomAsync(RoomRegistrationViewModel model);
        Task<bool> UpdateRoomAsync(RoomUpdateViewModel model);
        Task<bool> DeleteRoomAsync(Guid roomID);
        Task<List<RoomResponseViewModel>> GetAllRoomsAsync();
        Task<RoomResponseViewModel> GetRoomByIDAsync(Guid roomID);
    }
}
