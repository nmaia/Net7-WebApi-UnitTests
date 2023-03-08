using Hotel.Domain.Contracts.Repositories;
using Hotel.Infra.Repository.Context;
using Entities = Hotel.Domain.Entities;

namespace Hotel.Infra.Repository.Repositories
{
    public class BookingRepository : BaseRepository<Entities.Booking>, IBookingRepository
    {
        private readonly HotelContextDb _dbContext;

        public BookingRepository(HotelContextDb dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
