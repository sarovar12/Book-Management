namespace BookManagement.Application.DTO.Request
{
    public class IssueRequestDTO
    {
        public int BookId { get; set; }
        public Guid StudentId { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public int IsAvailable { get; set; }
        public double Fine { get; set; }


    }
}
