using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WareHouse.Model.Enum;

namespace WareHouse.UI.Areas.Admin.Models.DTO
{
    public class UserDTO:BaseDTO
    {
        [Required(ErrorMessage ="Please add your First name!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please add your Last name!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please add your User name!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please add your Email address!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your Password!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please choose your user role!")]
        public Role Role { get; set; }
        [Required(ErrorMessage = "Please choose your user gender!")]
        public Gender Gender { get; set; }
    }
}