namespace UserExplorer.Core.Application.DTOs.User
{
    public class UserCreateDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public required string Company { get; set; }
        public required string City { get; set; }
    }
}
