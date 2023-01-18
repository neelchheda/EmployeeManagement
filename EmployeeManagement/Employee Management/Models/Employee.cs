using System.ComponentModel.DataAnnotations;

namespace Employee_Management.Models {
    public class Employee {

        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="Name cannot exceed 50 characters")]
        public string Name { get; set; }
        [Required]
        [RegularExpression("^\\S+@\\S+\\.\\S+$", ErrorMessage ="Invalid Email Format")] 
        public string Email { get; set; }
        [Required]
        public Depte? Department { get; set; }
        public string PhotoPath { get; set; }
    }
}