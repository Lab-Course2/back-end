using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMuse.Application.Contracts.Models.Requests
{
    public class SearchRequest
    {
        public string? SearchTerm { get; set; } = string.Empty;
        public string? Location { get; set; } = string.Empty;
        public string? Category { get; set; } = string.Empty;
        public string? SearchType { get; set; }
    }
}
