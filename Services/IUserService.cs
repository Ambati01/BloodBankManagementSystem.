using BloodBankManagementSystem.Models;
namespace BloodBankManagementSystem.Services
{
    public interface IUserService
    {
        Task<User?> GetUserByEmailAsync(string email);

        Task<bool> EmailExistsAsync(string email);

        Task<User> RegisterUserAsync(RegisterViewModel model);

        Task<bool> ValidatePasswordAsync(string email, string password);

        Task<List<User>> GetAllUsersAsync();

        Task<bool> UpdateUserRoleAsync(int userId, string role);

        Task<bool> ToggleUserStatusAsync(int userId);
    }
}
