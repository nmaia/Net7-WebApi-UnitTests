using Hotel.Domain.Contracts.Repositories;
using Hotel.Infra.Repository.Context;
using Entities = Hotel.Domain.Entities;

namespace Hotel.Infra.Repository.Repositories
{
    public class HotelRepository : BaseRepository<Entities.Hotel>, IHotelRepository
    {
        private readonly HotelContextDb _dbContext;

        public HotelRepository(HotelContextDb dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
