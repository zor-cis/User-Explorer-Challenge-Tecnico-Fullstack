namespace UserExplorer.Core.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public required string Company { get; set; }
        public required string City { get; set; }
    }
}
