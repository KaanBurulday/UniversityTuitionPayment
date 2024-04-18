using static UniversityTuitionPayment.Model.Student;
using System.ComponentModel.DataAnnotations;

namespace UniversityTuitionPayment.Model.Dto
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string StudentCode { get; set; }
        public string TCKimlik { get; set; }
        public string FullName { get; set; }
        public int universityId { get; set; }
        public StudentStatusType StudentStatus { get; set; }
    }

    public class StudentResultDto : APIResultDto
    {
        public int Id { get; set; }
    }
}
