using application.DataAccess;
using application.DataAccess.Models;
using Application.DataAccessContracts;

namespace API_Project.DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
