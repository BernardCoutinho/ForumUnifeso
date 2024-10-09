using ForumUnifeso.src.API.Interface;
using ForumUnifeso.src.API.Model.User;
using ForumUnifeso.src.API.View.User;
using Microsoft.AspNetCore.Identity;

namespace ForumUnifeso.src.API.Service
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> CreateUserAsync(UserRequest request)
        {
            var existingUser = await _userRepository.GetByUsernameOrEmailAsync(request.Username, request.Email);
            if (existingUser != null)
            {
                throw new Exception("Usuário ou email já existe.");
            }

            var user = new User
            {
                Username = request.Username,
                Email = request.Email
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

            await AddAsync(user);

            return user;
        }

        public async Task<User> AddAsync(User user)
        {
            return await _userRepository.AddAsync(user);
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
