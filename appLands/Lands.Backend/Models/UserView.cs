


using System.ComponentModel.DataAnnotations;

namespace Lands.Backend.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Lands.Domain;
    using System.ComponentModel.DataAnnotations.Schema;


    [NotMapped]
    public class UserView : User
    {
        [DataType(DataType.Password)]
        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [StringLength(20), MinLength(6)]
        [Compare("Password", ErrorMessage = "The password and confirm doesn't mach. ")]
        [Display(Name = "Password Confirm")]
        public string PasswordConfirm { get; set; }
    }
}