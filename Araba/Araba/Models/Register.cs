using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Araba.Models
{
    public class Register
    {
        [Required]
        [DisplayName("Adı")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Soyadı")]
        public string Surname { get; set; }
        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string Username { get; set; }
        [Required]
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage ="Geçersiz Email Adresi")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Şifre")]
        public string Password { get; set; }
        [Required]
        [DisplayName("Şifre Tekrar")]
        [Compare("Password",ErrorMessage ="Şifreler Aynı Değil")]
        public string RePassword { get; set; }
    }
}