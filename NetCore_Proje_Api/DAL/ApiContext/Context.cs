using Microsoft.EntityFrameworkCore;
using NetCore_Proje_Api.DAL.Entity;

namespace NetCore_Proje_Api.DAL.ApiContext
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.onconfiguring(optionsbuilder);
            optionsBuilder.UseSqlServer("server=DESKTOP-PBE5IS4\\SQLEXPRESS;database=CoreProjeDB2;integrated security=true");
        }

        public DbSet<Category> Categories { get; set; }
    }
}
