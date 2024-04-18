using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityTuitionPayment.Model
{
    [Table("Tuition")]
    public class Tuition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int currentTermId { get; set; }

        [Required]
        public int studentId { get; set; }

        [Required]
        public int universityId { get; set; }

        [Required]
        public double TuitionTotal { get; set; }
        
        [Required]
        public double TuitionPaid { get; set; }

        [Required]
        public DateTime LastPaymentDate { get; set; }

        [Required]
        public PaymentStatusType PaymentStatus { get; set; }

        public enum PaymentStatusType
        {
            Pending,
            Completed,
            Failed
        }

        [ForeignKey("currentTermId")]
        public Term currentTerm { get; set; }

        [ForeignKey("studentId")]
        public Student student { get; set; }

        [ForeignKey("universityId")]
        public University university { get; set; }
    }
}
