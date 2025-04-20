using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Models;

namespace WebApi.Repositories.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { Id = 1, Title = "Karagöz ve Hacivatt", Price = 75 },
                new Book { Id = 2, Title = "İrade terbiyesi", Price = 125 },
                new Book { Id = 3, Title = "Mesnevi", Price = 175 }

                );
        }
    }
}
