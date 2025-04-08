using AppointEase.Application.DTOs.CustomerDTOs;
using AppointEase.Domain.Entities;

namespace AppointEase.Application.Interfaces
{
    public interface ICustomerService : IBaseService<Customer>
    {
        Task<bool> AddCustomer(AddCustomerDto customerDto);
        Task<bool> UpdateCustomer(UpdateCustomerDto customerDto);
    }
}
