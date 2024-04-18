using static UniversityTuitionPayment.Model.Tuition;
using System.ComponentModel.DataAnnotations;

namespace UniversityTuitionPayment.Model.Dto
{
    public class TuitionDto
    {
        public int Id { get; set; }
        public int currentTermId { get; set; }
        public int studentId { get; set; }
        public int universityId { get; set; }
        public double TuitionTotal { get; set; }
        public double TuitionPaid { get; set; }
        public DateTime LastPaymentDate { get; set; }
        public PaymentStatusType PaymentStatus { get; set; }
    }

    public class TuitionResultDto : APIResultDto
    {
        public int Id { get; set; }
    }
}
