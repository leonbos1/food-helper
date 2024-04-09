using FoodHelper.Data.Models;
using FoodHelper.Data.Repositories;
using FoodHelper.Logic.Services.Base;

namespace FoodHelper.Logic.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserRepository _userRepository;
        private readonly TokenRepository _tokenRepository;

        public AuthService(UserRepository userRepository, TokenRepository tokenRepository)
        {
            _userRepository = userRepository;
            _tokenRepository = tokenRepository;
        }

        public async Task<string> Register(string email, string username, string password)
        {
            if (_userRepository.GetByEmail(email) != null)
            {
                return "Email already exists";
            }

            if (_userRepository.GetByUsername(username) != null)
            {
                return "Username already exists";
            }

            var user = new User
            {
                Email = email,
                Username = username,
                Password = password
            };

            await _userRepository.Add(user);

            return "Success";
        }

        public async Task<string> Login(string email, string password)
        {
            var user = _userRepository.GetByEmail(email);

            if (user == null)
            {
                return "User not found";
            }

            if (user.Password != password)
            {
                return "Invalid password";
            }

            user.Token = new Token
            {
                Value = Guid.NewGuid().ToString(),
                ExpiryDate = DateTime.Now.AddDays(1)
            };

            _userRepository.Update(user);

            await _tokenRepository.Add(user.Token);

            return user.Token.Value;
        }

        public bool IsLoggedIn(string token)
        {
            return _tokenRepository.GetByValue(token) != null;
        }

        public string Logout()
        {
            return "Success";
        }
    }
}
