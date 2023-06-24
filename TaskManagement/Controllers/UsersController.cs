using TaskManagement.Data;
using TaskManagement.Models;

namespace TaskManagement.Controllers
{
    public class UsersController
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public bool Authenticate(string userName, string password)
        {
            return _context.Users.Any(u => u.UserName == userName && u.Password == password);
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }
    }


}
