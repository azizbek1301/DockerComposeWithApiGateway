using NajotNur.Application.DTOs;
using NajotNur.Domain.Models;

namespace NajotNur.Application.Services
{
    public interface IUserService
    {
        public ValueTask<bool> CreateUserAsync(UserDto userDto);
        public ValueTask<List<User>> GetAllAsync();
        public ValueTask<User> GetByIdAsync(int id);
        public ValueTask<string> DeleteByIdAsync(int id);
        public ValueTask<string> UpdateUserAsync(int id, UserDto userDto);
    }
}
