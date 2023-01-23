using Employee_Management.Controllers;
using Employee_Management.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Employee_Management.ViewModels {
    public class RegisterUserViewModel 
    {
        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailInUse", controller:"Account")]
        [ValidEmailDomain(allowedDomain:"gmail.com",
            ErrorMessage ="The domain name must be \"gmail.com\"")]
        public string Email{ get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Compare("Password", ErrorMessage="The passwords dont match!")]
        public string ConfirmPassword { get; set; }
       
    }
}
