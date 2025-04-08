using AppointEase.Api.Extensions;
using AppointEase.Api.Models;
using AppointEase.Application.DTOs.UserDTOs;
using AppointEase.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppointEase.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddUser([FromForm] AddUserDto user)
        {
            try
            {
                ResponseModel response = new();
                await userService.AddUser(user);
                response.Message = "کاربر با موفقیت افزوده شد";
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(HandleException.Handle(ex));
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromForm] UpdateUserDto user)
        {
            try
            {
                ResponseModel response = new();
                await userService.UpdateUser(user);
                response.Message = "کاربر با موفقیت ویرایش شد";
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(HandleException.Handle(ex));
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromQuery] int id)
        {
            try
            {
                ResponseModel response = new();
                await userService.Delete(id);
                response.Message = "کاربر با موفقیت حذف شد";
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(HandleException.Handle(ex));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUserById([FromQuery] int id)
        {
            try
            {
                ResponseModel response = new();

                var users = await userService.GetById(id);

                if (users == null)
                {
                    response.Success = false;
                    response.Message = "کاربری با این مشخصات یافت نشد";
                    return NotFound(response);
                }
                else
                {
                    response.Data = users;
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(HandleException.Handle(ex));
            }
        }

        [HttpGet]
        [Route("user-list")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                ResponseModel response = new();
                var users = await userService.GetAll();
                response.Data = users;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(HandleException.Handle(ex));
            }
        }
    }
}
