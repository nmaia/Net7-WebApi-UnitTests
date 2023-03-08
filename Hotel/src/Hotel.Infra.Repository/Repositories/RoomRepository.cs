using Hotel.Domain.Contracts.Repositories;
using Hotel.Domain.Entities;
using Hotel.Infra.Repository.Context;

namespace Hotel.Infra.Repository.Repositories
{
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        private readonly HotelContextDb _dbContext;

        public RoomRepository(HotelContextDb dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
