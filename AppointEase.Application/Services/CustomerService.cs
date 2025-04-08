using AppointEase.Application.DTOs.CustomerDTOs;
using AppointEase.Application.Interfaces;
using AppointEase.Domain.Entities;
using AppointEase.Domain.Interfaces.UnitOfWork;
using Mapster;

namespace AppointEase.Application.Services
{
    public class CustomerService(IUnitOfWork unitOfWork) : BaseService<Customer>(unitOfWork), ICustomerService
    {
        public async Task<bool> AddCustomer(AddCustomerDto customerDto)
        {
            var customer = customerDto.Adapt<Customer>();

            customer.CreatedAt = DateTime.Now;
            customer.IsActive = true;

            await Add(customer);
            await unitOfWork.SaveAsync();

            return true;
        }

        public async Task<bool> UpdateCustomer(UpdateCustomerDto customerDto)
        {
            var customer = customerDto.Adapt<Customer>();

            await Update(customer);
            await unitOfWork.SaveAsync();

            return true;
        }
    }
}
