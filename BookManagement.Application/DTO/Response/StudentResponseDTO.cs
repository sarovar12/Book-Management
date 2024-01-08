

namespace BookManagement.Application.DTO.Response
{
    public class StudentResponseDTO
    {
        public Guid StudentId { get; set; }
        public string StudentName { get; set; }
        public string Faculty { get; set; }
        public int Batch { get; set; }
        public int RollNo { get; set; }
    }
}
