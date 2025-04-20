using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Repositories.Config;

namespace WebApi.Repositories
{
    public class RepositoryContext: DbContext //kalıttık /*veritabanı yansıtma vb. bir çok özelliğe sahip dataBase Context*/
    {

        public RepositoryContext(DbContextOptions options):
            base(options) 
        {
            
        }
        public DbSet <Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //geçersiz kılıp isteğimize göre düzenledik
        {
            modelBuilder.ApplyConfiguration(new BookConfig());

            //FurkanKzltprk

        }
    }
}
