using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityTuitionPayment.Model
{
    [Table("BankAccount")]
    [Index(nameof(AccountCode), IsUnique = true)]
    [Index(nameof(TCKimlik), IsUnique = true)]
    public class BankAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public string AccountCode { get; set; }
        
        [Required]
        public double Balance { get; set; }
        
        [Required]
        public string TCKimlik { get; set; }

    }
}
