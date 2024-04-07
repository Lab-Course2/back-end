using MindMuse.Data.Contracts.Models;
using MindMuse.Data.Data;
using MindMuse.Data.Repositories;

namespace MindMuse.Data.Repositories
{
    public class DoctorReporsitory : Repository<Doctor>
    {
        public DoctorReporsitory(MindMuseContext context) : base(context)
        {
        }
    }
}