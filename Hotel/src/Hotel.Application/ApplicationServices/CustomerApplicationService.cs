using Hotel.Application.Contracts;
using Hotel.Application.ViewModels.Reading;
using Hotel.Application.ViewModels.Writing;
using Hotel.Domain.Contracts.DomainServices;
using Entities = Hotel.Domain.Entities;

namespace Hotel.Application.ApplicationServices
{
    public class CustomerApplicationService : ICustomerApplicationService
    {
        private readonly ICustomerDomainService _customerDomainService;

        public CustomerApplicationService(ICustomerDomainService customerDomainService)
        {
            _customerDomainService = customerDomainService;
        }

        public async Task<CustomerRegistrationViewModel> CreateCustomerAsync(CustomerRegistrationViewModel model)
        {
            var customer = new Entities.Customer()
            {
                Name = model.Name,
                Email = model.Email,
                SIN = Convert.ToInt32(model.SIN),
                BirthDate = model.BirthDate
            };

            var entity = await _customerDomainService.CreateAsync(customer);

            // todo: use automapper here
            var response = new CustomerRegistrationViewModel()
            {
                Name = entity.Name,
                Email = entity.Email,
                SIN = entity.SIN,
                BirthDate = entity.BirthDate,
                CustomerID = entity.CustomerID,
                CreatedDate = entity.CreatedDate,
                LastUpdate = entity.LastUpdate
            };

            return response;
        }

        public async Task<CustomerResponseViewModel> GetCustomerByIDAsync(Guid customerID)
        {
            var customer = await _customerDomainService.GetByIDAsync(customerID);

            if (customer == null) return null;

            var response = new CustomerResponseViewModel()
            {
                CustomerID = customer.CustomerID,
                Name = customer.Name,
                BirthDate= customer.BirthDate,
                SIN = customer.SIN.ToString(),
                Email = customer.Email,
                CreatedDate = customer.CreatedDate,
                LastUpdate = customer.LastUpdate
            };

            return response;
        }

        public async Task<bool> UpdateCustomerAsync(CustomerUpdateViewModel model)
        {
            var customer = await _customerDomainService.GetByIDAsync(model.CustomerID);
            
            customer.Name = model.Name;
            customer.BirthDate = model.BirthDate;
            customer.SIN = Convert.ToInt32(model.SIN);
            customer.Email = model.Email;
            customer.LastUpdate = model.LastUpdate;

            return await _customerDomainService.UpdateAsync(customer);
        }

        public async Task<List<CustomerResponseViewModel>> GetAllCustomersAsync()
        {
            var customers = await _customerDomainService.GetAllAsync();

            if (customers.Count == 0 || customers == null) return null;

            var response = new List<CustomerResponseViewModel>();

            foreach (var customer in customers)
            {
                var model = new CustomerResponseViewModel();

                model.CustomerID = customer.CustomerID;
                model.Name = customer.Name;
                model.BirthDate = customer.BirthDate;
                model.SIN = customer.SIN.ToString();
                model.Email = customer.Email;
                model.CreatedDate = customer.CreatedDate;
                model.LastUpdate = customer.LastUpdate;

                response.Add(model);
            }

            return response;
        }

        public async Task<bool> DeleteCustomerAsync(Guid customerID)
        {
            var customer = await _customerDomainService.GetByIDAsync(customerID);

            return await _customerDomainService.DeleteAsync(customer);
        }
    }
}
