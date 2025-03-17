using Banca.Core.Interfaces;
using Banca.Domain.Common;
using Banca.Domain.Entities;
using Banca.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Banca.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Name == username);  
        }

        public async Task<Result> CreateAsync(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return Result.Success("El Usuario se creo correctamente");
            }
            catch (Exception ex)
            {
                return Result.Failure("Ocurrio un Error: "+ex.Message);
            }
        }
    }
}