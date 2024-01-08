using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.DTO.Request
{
    public class BookRequestDTO
    {
        [Required(ErrorMessage="Id is required and cannot be zero.")]
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public string BookDescription { get; set; }
        public int BookQuantity { get; set; }

    }
}
