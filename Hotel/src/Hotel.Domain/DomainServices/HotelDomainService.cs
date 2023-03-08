using Hotel.Domain.Contracts.DomainServices;
using Hotel.Domain.Contracts.Repositories;
using Entities = Hotel.Domain.Entities;

namespace Hotel.Domain.DomainServices
{
    public class HotelDomainService : BaseDomainService<Entities.Hotel>, IHotelDomainService
    {
        private readonly IHotelRepository _hotelRepository;


        public HotelDomainService(IHotelRepository hotelRepository)
            : base(hotelRepository)
        {
            _hotelRepository = hotelRepository;            
        }
    }
}
