namespace ForumUnifeso.src.API.Service.Auth
{
    using ForumUnifeso.src.API.Interface;
    using ForumUnifeso.src.API.Interface.Login;
    using ForumUnifeso.src.API.Model.User;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    public class AuthService : ILoginService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthService(IConfiguration configuration, IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> Authenticate(string usernameOrEmail, string password)
        {
            var user = await _userRepository.GetByUsernameOrEmailAsync(usernameOrEmail, usernameOrEmail);

            if (user == null)
                return null;

            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);

            if (passwordVerificationResult != PasswordVerificationResult.Success)
            {
                return null; 
            }

            string token = GenerateJwtToken(user);

            return token;
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                 {
                    new Claim(ClaimTypes.Name, user.Username),
                 }),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
