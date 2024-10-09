using ForumUnifeso.src.API.Base.Context;
using ForumUnifeso.src.API.Interface;
using ForumUnifeso.src.API.Model.User;
using Microsoft.EntityFrameworkCore;

namespace ForumUnifeso.src.API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly PrincipalDbContext _context;

        public UserRepository(PrincipalDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByUsernameOrEmailAsync(string username, string email)
        {
            return await _context.User.AsNoTracking().FirstOrDefaultAsync(u => u.Username == username || u.Email == email);
        }

        public async Task<User> AddAsync(User entity)
        {
            _context.User.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public Task<bool> DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }

    }
}
