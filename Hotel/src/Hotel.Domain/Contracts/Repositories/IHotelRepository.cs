using Entities = Hotel.Domain.Entities;

namespace Hotel.Domain.Contracts.Repositories
{
    public interface IHotelRepository : IBaseRepository<Entities.Hotel>
    {
    }
}
