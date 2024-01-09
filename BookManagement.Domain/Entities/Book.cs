using BookManagement.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace BookManagement.Domain.Entities
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public BookAvailable BookStatus { get; set; }
        public string BookDescription { get; set; }
        public int BookQuantity { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateDeleted { get; set; }
    }
}
