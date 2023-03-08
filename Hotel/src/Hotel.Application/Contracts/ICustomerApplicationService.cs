using Hotel.Application.ViewModels.Reading;
using Hotel.Application.ViewModels.Writing;

namespace Hotel.Application.Contracts
{
    public interface ICustomerApplicationService
    {
        Task<bool> CreateCustomerAsync(CustomerRegistrationViewModel model);
        Task<bool> UpdateCustomerAsync(CustomerUpdateViewModel model);
        Task<bool> DeleteCustomerAsync(Guid customerID);
        Task<List<CustomerResponseViewModel>> GetAllCustomersAsync();
        Task<CustomerResponseViewModel> GetCustomerByIDAsync(Guid customerID);
    }
}
