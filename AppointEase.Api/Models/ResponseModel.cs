namespace AppointEase.Api.Models
{
    public class ResponseModel
    {
        public object? Data { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool Success { get; set; } = true;
    }
}
