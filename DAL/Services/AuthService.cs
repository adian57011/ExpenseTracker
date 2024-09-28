using DAL.Model;
using DAL.Repository;

namespace DAL.Services
{
    public class AuthService
    {
        private readonly IAuthRepository _auth;

        public AuthService(IAuthRepository auth)
        {
            _auth = auth;
        }

        public async Task<User> Login(string username,string password)
        {
            return await _auth.login(username, password);
        }

        public async Task<bool> SignUp(User user)
        {
            return await _auth.signup(user);
        }

        public async Task<bool> ChangePassword(User user)
        {
            return await _auth.changePassword(user);
        }

    }
}
