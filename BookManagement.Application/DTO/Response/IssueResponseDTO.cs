
using BookManagement.Application.DTO.Navigation;

namespace BookManagement.Application.DTO.Response
{
    public class IssueResponseDTO
    {
        public Guid IssueId { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public int IsAvailable { get; set; }
        public double Fine { get; set; }
        public int BookId { get; set; }
        public Guid StudentId { get; set; }

        //Navigation Property 
        public BookNavigationDTO Book {  get; set; }
        public StudentNavigationDTO Student { get; set; }


    }
}
