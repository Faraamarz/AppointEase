using AppointEase.Application.DTOs.UserDTOs;
using AppointEase.Application.Interfaces;
using AppointEase.Domain.Entities;
using AppointEase.Domain.Interfaces.UnitOfWork;
using Mapster;

namespace AppointEase.Application.Services
{
    public class UserService(IUnitOfWork unitOfWork) : BaseService<User>(unitOfWork), IUserService
    {
        public async Task<bool> AddUser(AddUserDto userDto)
        {
            var user = userDto.Adapt<User>();
            
            user.CreatedAt = DateTime.Now;
            user.IsActive = true;
            
            await Add(user);
            await unitOfWork.SaveAsync();
            
            return true;
        }

        public async Task<bool> UpdateUser(UpdateUserDto userDto)
        {
            var user = userDto.Adapt<User>();

            await Update(user);
            await unitOfWork.SaveAsync();

            return true;
        }
    }
}
