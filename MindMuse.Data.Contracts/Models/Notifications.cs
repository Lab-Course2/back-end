using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Data.Contracts.Models
{
    public class Notifications
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string IdNotification { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string FromId { get; set; }
        public string ToId { get; set; }
        public string Type { get; set; }
        public string? IdType { get; set; }
        public string MessageType { get; set; }
        public bool IsRead { get; set; }
        public DateTime dateTimestamp { get; set; }
    }
}
