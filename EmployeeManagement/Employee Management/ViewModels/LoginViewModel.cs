using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;



namespace Employee_Management.ViewModels {
    public class LoginViewModel 
    {
        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailCorrect", controller: "Account")]

        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }


    }
}
