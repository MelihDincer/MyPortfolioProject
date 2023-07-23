using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class WriterUser : IdentityUser<int>
    {
        [Key]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageURL { get; set; }
    }
}