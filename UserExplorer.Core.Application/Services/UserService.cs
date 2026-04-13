using Microsoft.EntityFrameworkCore;
using UserExplorer.Core.Application.DTOs.User;
using UserExplorer.Core.Application.Interfaces;
using UserExplorer.Core.Domain.Entities;
using UserExplorer.Core.Domain.Interfaces;

namespace UserExplorer.Core.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        #region create user 

        public async Task AddUser(UserCreateDto userCreateDto)
        {
            try
            {
                if (userCreateDto == null)
                {
                    throw new ArgumentNullException(nameof(userCreateDto), "User data cannot be null.");
                }

                var user = new User
                {
                    Id = 0,
                    Name = userCreateDto.Name,
                    Email = userCreateDto.Email,
                    Phone = userCreateDto.Phone,
                    Company = userCreateDto.Company,
                    City = userCreateDto.City
                };

                await _userRepo.AddUserAsync(user);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while adding the user.", ex);
            }
        }

        #endregion


        #region Gets users

        public async Task<List<UserResponseDto>> GetAllUsers()
        {
            try
            {
                var users = await _userRepo.GetAllUsersAsync();

                if (!users.Any())
                    return new List<UserResponseDto>();

                return users.Select(u => new UserResponseDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    Phone = u.Phone,
                    Company = u.Company,
                    City = u.City
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving users.", ex);
            }
        }

        public async Task<UserResponseDto?> GetUserById(int id)
        {
            try
            {
                var user = await _userRepo.GetUserByIdAsync(id);

                if (user == null)
                    return null;

                return new UserResponseDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Phone = user.Phone,
                    Company = user.Company,
                    City = user.City
                };
            }
            catch (Exception ex)
            {
                throw new ApplicationException(
                    $"An error occurred while retrieving the user with ID {id}.", ex);
            }
        }

        public async Task<List<UserResponseDto>> GetUsersByFilters(string? search, string? company, string? city)
        {
            try
            {
                var query = _userRepo.GetUsersQuery();

                if (!string.IsNullOrWhiteSpace(search))
                {
                    query = query.Where(u => u.Name.Contains(search) || u.Email.Contains(search));
                }

                if (!string.IsNullOrWhiteSpace(company))
                {
                    query = query.Where(u => u.Company != null && u.Company.Contains(company));
                }

                if (!string.IsNullOrWhiteSpace(city))
                {
                    query = query.Where(u => u.City.Contains(city));
                }


                return await query.Select(u => new UserResponseDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    Phone = u.Phone,
                    Company = u.Company,
                    City = u.City
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving users with filters.", ex);
            }
        }

        #endregion
    }
}
