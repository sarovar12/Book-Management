using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.DTO.Response
{
    public class IssueUpdateResponseDTO
    {
        public Guid IssueId { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public int IsAvailable { get; set; }
        public double Fine { get; set; }
        public int BookId { get; set; }
        public Guid StudentId { get; set; }
    }
}
