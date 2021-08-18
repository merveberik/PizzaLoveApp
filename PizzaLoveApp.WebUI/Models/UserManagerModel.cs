using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaLoveApp.WebUI.Models
{
    public class UserManagerModel
    {
        public string UserId { get; set; }
        [DisplayName("İsim")]
        public string FirstName { get; set; }
        [DisplayName("Soyisim")]
        public string LastName { get; set; }
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }
        [DisplayName("Adres")]
        public string Address { get; set; }
        [DisplayName("Şehir")]
        public string City { get; set; }
        [DisplayName("Posta Kodu")]
        public string ZipCode { get; set; }
        [DisplayName("Telefon Numarası")]
        public string Phone { get; set; }
        [DisplayName("Email Adresi")]
        public string Email { get; set; }
        [DisplayName("İsim Soyisim")]
        public string FullName { get; set; }
        [DisplayName("PizzaLove Puan")]
        public decimal PointPrize { get; set; }
        
    }
}
