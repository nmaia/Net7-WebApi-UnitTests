using Hotel.Domain.Contracts.Repositories;
using Hotel.Domain.Entities;
using Hotel.Infra.Repository.Context;

namespace Hotel.Infra.Repository.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly HotelContextDb _dbContext;

        public CustomerRepository(HotelContextDb dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
