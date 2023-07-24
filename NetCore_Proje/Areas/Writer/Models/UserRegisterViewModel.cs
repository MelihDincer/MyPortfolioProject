using System.ComponentModel.DataAnnotations;

namespace NetCore_Proje.Area.Writer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen Adınızı Girin")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen Soyadınızı Girin")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Lütfen Resim URL Değeri Girin")]
        public string ImageURL { get; set; }
        [Required(ErrorMessage = "Lütfen bir ImageURL Girin")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen Kullanıcı Adını Girin")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Lütfen Şifreyi Tekrar Girin")]
        [Compare("Password", ErrorMessage = "Şifreler Uyumlu Değil!")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Lütfen Mail Girin")]
        public string Mail { get; set; }
    }
}