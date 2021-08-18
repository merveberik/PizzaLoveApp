using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaLoveApp.WebUI.Models
{
    public class OrderModel
    {
        [DisplayName("İsim")]
        public string FirstName { get; set; }

        [DisplayName("Soyisim")]
        public string LastName { get; set; }

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

        [DisplayName("Kart Adı")]
        public string CardName { get; set; }

        [DisplayName("Kart Numarası")]
        public string CardNumber { get; set; }
        [DisplayName("Ay")]
        public string ExpirationMonth { get; set; }

        [DisplayName("Yıl")]
        public string ExpirationYear { get; set; }

        [DisplayName("Güvenlik Kodu")]
        public string Cvv { get; set; }

        public CartModel CartModel { get; set; }



    }
}
