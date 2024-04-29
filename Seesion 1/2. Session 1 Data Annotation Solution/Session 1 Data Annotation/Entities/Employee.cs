using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_1_Data_Annotation.Entities
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //(1,1)
        public int EmpId { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        //[MinLength(10)]
        //[MaxLength(50)]
        [StringLength(50,MinimumLength =10)]
        public string? Name { get; set; }  

        // [Column(TypeName ="money")]
        [DataType(DataType.Currency)]
        public Decimal Salary { get; set; }

        [Range(20,50)]
        public int? Age { get; set; }

        //[DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        //[DataType(DataType.PhoneNumber)]
        [Phone]
        public string PhoneNumber { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
