using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagement.Domain.Entities
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid StudentId { get; set; }
        public string StudentName { get; set; }
        public string Faculty { get; set; }
        public int Batch { get; set; }
        public int RollNo { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateDeleted { get; set; }

    }
}
