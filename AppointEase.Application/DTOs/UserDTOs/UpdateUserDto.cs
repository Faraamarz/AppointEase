namespace AppointEase.Application.DTOs.UserDTOs
{
    public class UpdateUserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}
