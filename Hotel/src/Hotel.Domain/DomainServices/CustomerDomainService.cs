using Hotel.Domain.Contracts.DomainServices;
using Hotel.Domain.Contracts.Repositories;
using Hotel.Domain.Entities;

namespace Hotel.Domain.DomainServices
{
    public class CustomerDomainService : BaseDomainService<Customer>, ICustomerDomainService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerDomainService(ICustomerRepository customerRepository)
            : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }
    }
}
