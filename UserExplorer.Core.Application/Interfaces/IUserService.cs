using UserExplorer.Core.Application.DTOs.User;

namespace UserExplorer.Core.Application.Interfaces
{
    public interface IUserService
    {
        Task AddUser(UserCreateDto userCreateDto);
        Task<List<UserResponseDto>> GetAllUsers();
        Task<UserResponseDto?> GetUserById(int id);
        Task<List<UserResponseDto>> GetUsersByFilters(string? search, string? company, string city);
    }
}