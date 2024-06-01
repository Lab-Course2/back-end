using MindMuse.Application.Contracts.Models.Operations;
using MindMuse.Data.Contracts.Interfaces;
using MindMuse.Data.Contracts.Models;
using MindMuse.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Data.Repositories
{
    public class ChatMessagesRepository : Repository<ChatMessages>, IChatMessagesRepository
    {
        public ChatMessagesRepository(MindMuseContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ChatMessages>> GetMessages(string senderId, string receiverId)
        {
            var getAllMessages = await GetAllAsync();
            var messages = getAllMessages
            .Where(m => m.SenderId == senderId && m.ReceiverId == receiverId).ToList();

            return messages;
        }

        public async Task<OperationResult> SaveMessages(ChatMessages message)
        {
            try
            {
                await AddAsync(message);
                return new OperationResult(true, "Message sent successfully");
            }
            catch (Exception ex)
            {
                // Kthimi i një rezultati negativ në rastin e ndonjë gabimi
                return new OperationResult(false, $"Error sending message: {ex.Message}");
            }
        }
    }

}