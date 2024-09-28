using DAL.Model;

namespace DAL.Repository
{
    public interface IAuthRepository : IRepository<User>
    {
        Task<bool> signup(User user);
        Task<User> login(string username,string password);
        Task<bool> changePassword(User user);
        
    }
}
