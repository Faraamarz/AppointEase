using AppointEase.Application.DTOs.UserDTOs;
using AppointEase.Domain.Entities;

namespace AppointEase.Application.Interfaces
{
    public interface IUserService : IBaseService<User>
    {
        Task<bool> AddUser(AddUserDto userDto);
        Task<bool> UpdateUser(UpdateUserDto userDto);
    }
}
