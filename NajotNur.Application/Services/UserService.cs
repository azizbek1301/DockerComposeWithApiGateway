using Microsoft.EntityFrameworkCore;
using NajotNur.Application.DTOs;
using NajotNur.Domain.Models;
using NajotNur.Infrastructure;

namespace NajotNur.Application.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async ValueTask<bool> CreateUserAsync(UserDto userDto)
        {
            try
            {
                var res = new User()
                {
                    Name =userDto.Name,
                    Email = userDto.Email,
                    Password = userDto.Password,
                   
                };
                await _context.Users.AddAsync(res);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async ValueTask<string> DeleteByIdAsync(int id)
        {
            try
            {
                var res = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
                if (res != null)
                {
                    _context.Users.Remove(res);
                    await _context.SaveChangesAsync();
                    return "Deleted";
                }
                else
                {
                    return "Not found Apartment";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async ValueTask<List<User>> GetAllAsync()
        {
            try
            {
                var res = await _context.Users.AsNoTracking().ToListAsync();
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async ValueTask<User> GetByIdAsync(int id)
        {
            try
            {
                var res = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
                return res;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async ValueTask<string> UpdateUserAsync(int id, UserDto userDto)
        {
            try
            {
                var res = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
                if (res != null)
                {
                    res.Name = userDto.Name;
                    
                    await _context.SaveChangesAsync();
                    return "YAngilndi";
                }
                else
                {
                    return "Topilmadi";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
