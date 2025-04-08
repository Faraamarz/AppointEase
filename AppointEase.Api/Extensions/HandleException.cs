using AppointEase.Api.Models;
using Serilog;

namespace AppointEase.Api.Extensions
{
    public static class HandleException
    {
        public static ResponseModel Handle(this Exception exception)
        {
            Log.Error(exception, "exception");

            ResponseModel response = new()
            {
                Success = false,
                Message = "خطا در پردازش اطلاعات"
            };

            return response;
        }
    }
}
