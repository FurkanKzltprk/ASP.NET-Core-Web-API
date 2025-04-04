using System.Reflection;
using bookDemo.Models;

namespace bookDemo.Data
{
    //bu sınıf diğerlerinden farklı olarak static olacak.
    public static  class ApplicationContext
    {

        public static List<Book> Books { get; set; }
        static ApplicationContext()
        {
            Books = new List<Book>()
            {
                new Book(){Id=1, Title="irade terbiyesi", Price=125},
                new Book(){Id=2, Title="Atomik Alışkanlıklar", Price=100},
                new Book(){Id=3, Title="Küçük Prens", Price=85}

                //3 tane kitap içeren bir liste tanımlaması yaptım.
                /*static olduğu için , değişiklik olursa herkes bundan 
                etkilenmiş olacak*/
            };

        }


    }
}
