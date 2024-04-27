using MindMuse.Application.Contracts.Models.EmailConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Application.Contracts.Interfaces
{
    public interface IEmailServices
    {
        Task SendEmail(Messages messages);
    }
}
