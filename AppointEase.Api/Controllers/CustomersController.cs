using AppointEase.Api.Extensions;
using AppointEase.Api.Models;
using AppointEase.Application.DTOs.CustomerDTOs;
using AppointEase.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppointEase.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomersController(ICustomerService customerService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromForm] AddCustomerDto customer)
        {
            try
            {
                ResponseModel response = new();
                await customerService.AddCustomer(customer);
                response.Message = "مشتری با موفقیت افزوده شد";
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(HandleException.Handle(ex));
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromForm] UpdateCustomerDto customer)
        {
            try
            {
                ResponseModel response = new();
                await customerService.UpdateCustomer(customer);
                response.Message = "مشتری با موفقیت ویرایش شد";
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(HandleException.Handle(ex));
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer([FromQuery] int id)
        {
            try
            {
                ResponseModel response = new();
                await customerService.Delete(id);
                response.Message = "مشتری با موفقیت حذف شد";
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(HandleException.Handle(ex));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerById([FromQuery] int id)
        {
            try
            {
                ResponseModel response = new();

                var customer = await customerService.GetById(id);

                if (customer == null)
                {
                    response.Success = false;
                    response.Message = "مشتری با این مشخصات یافت نشد";
                    return NotFound(response);
                }
                else
                {
                    response.Data = customer;
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(HandleException.Handle(ex));
            }
        }

        [HttpGet]
        [Route("customer-list")]
        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                ResponseModel response = new();
                var customers = await customerService.GetAll();
                response.Data = customers;
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(HandleException.Handle(ex));
            }
        }
    }
}
