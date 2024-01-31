

using BookManagement.Domain.Enum;

namespace BookManagement.Application.DTO.Request
{
    public class StaffRequestDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public StaffType StaffType { get; set; }
    }
}
