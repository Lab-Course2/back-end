using MindMuse.Data.Contracts.Models;
using MindMuse.Data.Data;
using MindMuse.Data.Repositories;

namespace MindMuse.Data.Repositories
{
    public class AdminRepository : Repository<TblAdmin>
    {
        public AdminRepository(MindMuseContext context) : base(context)
        {
        }
    }
}