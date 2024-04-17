using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityTuitionPayment.Model
{
    [Table("Student")]
    [Index(nameof(StudentCode), IsUnique = true)]
    [Index(nameof(TCKimlik), IsUnique = true)]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string StudentCode { get; set; }
        
        [Required]
        public string TCKimlik { get; set; }
        
        [Required]
        public string FullName { get; set; }
        
        [Required]
        [ForeignKey("University")]
        public University university { get; set; }

        [Required]
        public StudentStatusType StudentStatus { get; set; }    

        public enum StudentStatusType
        {
            Active,
            Passive,
            OnPayment
        }
    }
}
