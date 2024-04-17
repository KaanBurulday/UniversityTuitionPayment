using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityTuitionPayment.Model
{
    [Table("Tuition")]
    public class Tuition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public Term CurrentTerm { get; set; }

        [Required]
        public Student student { get; set; }

        [Required]
        public University university{ get; set; }

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

    }
}
