using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace DAL.Repository
{
    public class AuthRepository : Repository<User>, IAuthRepository
    {
        public AuthRepository(ETDbContext context) : base(context) { }

        public async Task<bool> changePassword(User user)
        {
            try
            {
                if (user == null || user.Password == "" || user.Password == null)
                    return false;

                var hashPass = GenerateHashedPassword(user.Password);

                user.HashedPassword = hashPass;

                return await this.Update(user);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> login(string username, string password)
        {
            try
            {
                var user = await _dbset.FirstOrDefaultAsync(u => u.Username == username);

                if (user != null && (user.Password == password || user.HashedPassword == password)) 
                {
                    return user;
                }

                return new User();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> signup(User user)
        {
            try
            {
                //1. Check if the user exists!//

                //bool check = _dbset.Any(x => x.Username == user.Username || x.Id == user.Id);

                //2.Create a user
               return await this.Create(user);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        //utility function//
        private string GenerateHashedPassword(string password)
        {
            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.UTF8.GetBytes(password);
                var hashBytes = md5.ComputeHash(inputBytes);

                // Convert byte array to a hex string
                var sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }



    }
}
