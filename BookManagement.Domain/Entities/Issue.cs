
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagement.Domain.Entities
{
    public class Issue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IssueId { get; set; } 
        public DateTime IssuedDate { get; set; } = DateTime.Now;
        public DateTime ExpectedReturnDate { get; set; } = DateTime.Now.AddDays(30);
        public DateTime? ReturnedDate { get; set; }
        public int IsAvailable { get; set; }
        public double Fine {  get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }

        [ForeignKey("Student")]
        public Guid StudentId { get; set; }

        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
        public DateTime? DateDeleted { get; set; }
     


    }
}
