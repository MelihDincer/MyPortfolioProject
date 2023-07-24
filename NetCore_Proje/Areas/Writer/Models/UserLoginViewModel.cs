using System.ComponentModel.DataAnnotations;

namespace NetCore_Proje.Area.Writer.Models
{
    public class UserLoginViewModel
    {
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen Kullanıcı Adını Giriniz...!")]
        public string Username { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen Şifreyi Giriniz...!")]
        public string Password { get; set; }
    }
}