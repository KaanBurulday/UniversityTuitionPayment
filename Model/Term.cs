using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniversityTuitionPayment.Model
{
    public class Term
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int StartYear { get; set; }

        [Required]
        public int EndYear { get; set; }

        [Required]
        public SemesterType Semester { get; set; }

        public enum SemesterType
        {
            Fall,
            Spring
        }
    }
}
