using MindMuse.Application.Contracts.Identity;
using MindMuse.Data.Contracts.Models;
using MindMuse.Data.Data;
using MindMuse.Data.Repositories;

namespace MindMuse.Data.Repositories
{
    public class UsersRepository : Repository<ApplicationUser>
    {
        public UsersRepository(MindMuseContext context) : base(context)
        { }
    }
}