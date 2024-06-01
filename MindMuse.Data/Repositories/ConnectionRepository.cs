using MindMuse.Data.Contracts.Models;
using MindMuse.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Data.Repositories
{
    public class ConnectionRepository : Repository<Connections>
    {
        public ConnectionRepository(MindMuseContext context) : base(context)
        {
        }
    }
}