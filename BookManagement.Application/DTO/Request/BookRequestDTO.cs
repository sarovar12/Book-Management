using BookManagement.Domain.Enum;
using System.ComponentModel.DataAnnotations;


namespace BookManagement.Application.DTO.Request
{
    public class BookRequestDTO
    {
        [Required(ErrorMessage="Id is required and cannot be zero.")]
        public int BookId { get; set; }
        public string BookName { get; set; }
        public BookAvailable BookStatus { get; set; }
        public string BookAuthor { get; set; }
        public string BookDescription { get; set; }
        public int BookQuantity { get; set; }

    }
}
