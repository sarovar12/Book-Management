using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.DTO.Request
{
    public class StudentRequestDTO
    {
        public string StudentName { get; set; }
        public string Faculty { get; set; }
        public int Batch { get; set; }
        public int RollNo { get; set; }
    }
}
