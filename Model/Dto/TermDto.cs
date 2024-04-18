using static UniversityTuitionPayment.Model.Term;
using System.ComponentModel.DataAnnotations;

namespace UniversityTuitionPayment.Model.Dto
{
    public class TermDto
    {
        public int Id { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public SemesterType Semester { get; set; }
    }

    public class TermResultDto : APIResultDto
    {
        public int Id { get; set; }
    }
}
