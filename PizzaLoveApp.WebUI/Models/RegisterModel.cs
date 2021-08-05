using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaLoveApp.WebUI.Models
{
    public class RegisterModel
    {
        [Required]
        [Display(Name = "İsim Soyisim")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Şifre Tekrarı")]
        public string RePassword { get; set; }  

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Adresi")]
        public string Email { get; set; }

        /*
         * TODO: Adres ve telefon numarası eklenecek
         */


    }
}
