using System.ComponentModel.DataAnnotations;

namespace UniversityTuitionPayment.Model.Dto
{
    public class BankAccountDto
    {
        public int Id { get; set; }
        public string AccountCode { get; set; }
        public double Balance { get; set; }
        public string TCKimlik { get; set; }
    }

    public class BankAccountResultDto : APIResultDto
    { 
        public int Id { get; set; } 
    }
}
