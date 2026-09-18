using BloodBankManagementSystem.Data;
using BloodBankManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BloodBankManagementSystem.Services
{
    public class UserService : IUserService
    {
        private readonly BloodBankDbContext _context;
        private readonly PasswordHasher<User> _passwordHasher;

        public UserService(BloodBankDbContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<User>();
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Users
                .AnyAsync(u => u.Email == email);
        }

        public async Task<User> RegisterUserAsync(RegisterViewModel model)
        {
            var user = new User
            {
                FullName = model.FullName,
                Email = model.Email,
                Role = model.Role,
                IsActive = true,
                CreatedDate = DateTime.Now
            };

            user.PasswordHash = _passwordHasher.HashPassword(
                user,
                model.Password
            );

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
        public async Task<bool> ValidatePasswordAsync(string email, string password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null || !user.IsActive)
                return false;

            var result = _passwordHasher.VerifyHashedPassword(
                user,
                user.PasswordHash,
                password
            );

            return result == PasswordVerificationResult.Success;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users
                .OrderBy(u => u.UserId)
                .ToListAsync();
        }

        public async Task<bool> UpdateUserRoleAsync(int userId, string role)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null)
                return false;

            user.Role = role;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ToggleUserStatusAsync(int userId)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null)
                return false;

            user.IsActive = !user.IsActive;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}