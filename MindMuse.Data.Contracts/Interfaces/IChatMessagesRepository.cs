using MindMuse.Application.Contracts.Models.Operations;
using MindMuse.Data.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Data.Contracts.Interfaces
{
    public interface IChatMessagesRepository
    {
        Task<IEnumerable<ChatMessages>> GetMessages(string senderId, string receiverId);
        Task<OperationResult> SaveMessages(ChatMessages message);
    }
}