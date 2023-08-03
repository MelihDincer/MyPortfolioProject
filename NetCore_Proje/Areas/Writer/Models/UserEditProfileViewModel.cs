using Microsoft.AspNetCore.Http;

namespace NetCore_Proje.Areas.Writer.Models
{
    public class UserEditProfileViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; }
        public string PictureURL { get; set; }
        public IFormFile Picture { get; set; }
    }
}