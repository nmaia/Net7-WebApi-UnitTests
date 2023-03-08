using Hotel.Domain.Contracts.DomainServices;
using Hotel.Domain.Contracts.Repositories;
using Hotel.Domain.Entities;

namespace Hotel.Domain.DomainServices
{
    public class RoomDomainService : BaseDomainService<Room>, IRoomDomainService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomDomainService(IRoomRepository roomRepository)
            : base(roomRepository)
        {
            _roomRepository = roomRepository;
        }
    }
}
