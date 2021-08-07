using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaLoveApp.WebUI.Models
{
    public class ResetPasswordModel
    {
        [Required]
        public string Token { get; set; }
        [Required]
        [DataType(DataType.EmailAddress),Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password),Display(Name="Yeni Şifre")]
        public string Password { get; set; }
    }
}
