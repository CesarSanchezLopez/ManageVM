using ManageVM.Api.Core.Entities;
using ManageVM.Api.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManageVM.Api.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }
        public User GetUser(User userModel)
        {
            return _context.Users.Where(x => x.Username.ToLower() == userModel.Username.ToLower()
                && x.Password == userModel.Password).FirstOrDefault();
        }
        public async Task<ActionResult<User>> GetId(int id)
        {
            return await _context.Users.FindAsync(id);
        }

    }
}
