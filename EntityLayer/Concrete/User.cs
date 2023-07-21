using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User
    {
        [Key]
        public int UserID{ get; set; }
        public string Name{ get; set; }
        public string Surname{ get; set; }
        public string Username{ get; set; }
        public string Mail{ get; set; }
        public string Password{ get; set; }
        public string ImageURL{ get; set; }
        public bool Status{ get; set; }
        public List<UserMessage> UserMessages { get; set; } // 1'e çok ilişki kuruldu, yani bir kullanıcı birden fazla mesaj atabilir.
    }
}