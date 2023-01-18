using Employee_Management.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Employee_Management.ViewModels {
    public class EmployeeCreateViewModel {

        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }
        [Required]
        [RegularExpression("^\\S+@\\S+\\.\\S+$", ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }
        [Required]
        public Depte? Department { get; set; }
        public List<IFormFile> Photos { get; set; }
    }
}
