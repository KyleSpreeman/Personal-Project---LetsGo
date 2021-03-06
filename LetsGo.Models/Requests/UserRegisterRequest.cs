using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsGo.Models.Requests
{
    public class UserRegisterRequest
    {
            [Required]
            [MaxLength(254)]
            [Display(Name = "FirstName")]
            public string FirstName { get; set; }

            [Required]
            [MaxLength(254)]
            [Display(Name = "LastName")]
            public string LastName { get; set; }

            [Required]
            [MaxLength(254)]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Required]
            [Display(Name = "Confirm Password")]
            [Compare(nameof(Password), ErrorMessage = "Passwords don't match")]
            public string ConfirmPassword { get; set; }

        
    }
}
