using MindMuse.Data.Contracts.Models;
using MindMuse.Data.Data;
using MindMuse.Data.Repositories;

namespace MindMuse.Data.Repositories
{
    public class UserRepository : Repository<Patient>
    {
        public UserRepository(MindMuseContext context) : base(context)
        {
        }
    }
}