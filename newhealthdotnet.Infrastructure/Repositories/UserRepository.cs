using Microsoft.EntityFrameworkCore;
using newhealthdotnet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newhealthdotnet.Infrastructure.Repositories
{
    public class UserRepository(ApplicationDbContext context) : IUserRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}

