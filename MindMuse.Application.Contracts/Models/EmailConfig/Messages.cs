using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Application.Contracts.Models.EmailConfig
{
    public class Messages
    {
        public List<MailboxAddress> To { get; set; }
        public string Content { get; set; }
        public string Subject { get; set; }
        public Messages(IEnumerable<string> To, string Subject, string Content)
        {
            this.To = new List<MailboxAddress>();
            this.To.AddRange(To.Select(x => new MailboxAddress("email", x)));
            this.Subject = Subject;
            this.Content = Content;
        }
    }
}
