﻿using System.ComponentModel.DataAnnotations;

namespace Employee_Management.ViewModels {
    public class RegisterUserViewModel 
    {
        [Required]
        [EmailAddress]
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
