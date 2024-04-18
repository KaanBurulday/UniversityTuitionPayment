using System.ComponentModel.DataAnnotations;

namespace UniversityTuitionPayment.Model.Dto
{
    public class UniversityDto
    {
        public int Id { get; set; }
        public string UniversityCode { get; set; }
        public string UniversityName { get; set; }
        public double TuitionFee { get; set; }
        public List<Student> Students { get; set; }
        public Term CurrentTerm { get; set; }
        public List<Term> Terms { get; set; }
    }

    public class UniversityResultDto : APIResultDto
    { 
        public int Id { get; set; } 
    }
}
