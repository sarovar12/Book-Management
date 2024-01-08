using BookManagement.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace BookManagement.Domain.Entities
{
    public class Staff
    {
        [Key]
        public StaffType StaffType { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateDeleted { get; set; }

    }
}
