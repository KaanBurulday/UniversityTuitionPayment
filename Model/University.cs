using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityTuitionPayment.Model
{
    [Table("University")]
    [Index(nameof(UniversityCode), IsUnique = true)]
    public class University
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string UniversityCode { get; set; }
        
        [Required]
        public string UniversityName { get; set; }

        [Required]
        public double TuitionFee { get; set; }

        public List<Student> Students { get; set; }
        
        public Term CurrentTerm { get; set; }
        
        public List<Term> Terms { get; set; }
    }
}
