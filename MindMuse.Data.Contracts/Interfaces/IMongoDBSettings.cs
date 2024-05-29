using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Data.Contracts.Interfaces
{
    public interface IMongoDBSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}