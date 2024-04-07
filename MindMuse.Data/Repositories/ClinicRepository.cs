using MindMuse.Data.Contracts.Models;
using MindMuse.Data.Data;
using MindMuse.Data.Repositories;

namespace MindMuse.Data.Repositories
{
    public class ClinicRepository : Repository<Clinic>
    {
        public ClinicRepository(MindMuseContext context) : base(context)
        {
        }
    }
}