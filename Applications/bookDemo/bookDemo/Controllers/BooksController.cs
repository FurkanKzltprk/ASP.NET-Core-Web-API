using System.Security.Cryptography.X509Certificates;
using bookDemo.Data;
using bookDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace bookDemo.Controllers
{
    [Route("api/books")]
    [ApiController]  /* bir behavior davranış kazandırıyor
                       Response body'deki bilgiler !önemli!  */

    /*şuanki veriler inMemory data var , program kapanınca gidiyor.
    veri tabanı olayı yok yani*/

    public class BooksController : ControllerBase
    {
        [HttpGet] //bir http verb ifadesi geldi.
        public IActionResult GetAllBooks()
        {
            //var books = ApplicationContext.Books.ToList();// böyle de kullanılabilir.

            var books = ApplicationContext.Books;  //liste olarak döndürüyor

            return Ok(books);

        }


        // [HttpGet]   //aynı istekle geldi hangisini çalıştıracak ? Eror! Verir.
        [HttpGet("{id:int}")]  // bu hali daha iyi ...."https/books/1" doğru

        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {
            //var books = ApplicationContext.Books.ToList();// böyle de kullanılabilir.
            //liste olarak döndürüyor


            //Not
            /*LINQ sorgusu , dile entegre sorgu demek .sizin yerinize gidiyor
             id'si parametreden gelene eşit olan kitabı filtreliyor 
             SingleOrDefault , tek bir ifade ya da null döner */
            var book = ApplicationContext
                .Books
                .Where(b => b.Id.Equals(id))
                .SingleOrDefault();

            /* Restin amacı : istemciyle sunucu arasındaki veriyi 
            takas etmek*/

            if (book is null)
            {
                return NotFound(); // book is null ise 404 
            }


            return Ok(book); //book(s) değil dikkat book

        }



        /* Post istekleri kısmı*/
        [HttpPost]

        public IActionResult CreateOneBook([FromBody] Book book)
        {
            try
            {
                if (book is null)
                    return BadRequest(); //400 bad request
                ApplicationContext.Books.Add(book);
                return StatusCode(201, book); //201 created
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

        [HttpPut("{id:int}")]

        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id,
          [FromBody] Book book) // binding'e req'den gelen gövdeye bağlı olarak gerçekleşirileceğini gösteriyorum.

        {
            //check book yapıyorum ? var,yok?

            var entity = ApplicationContext
                .Books
                .Find(b => b.Id.Equals(id));

            if (entity is null)
            {
                return NotFound(); //404 
            }

            //check id
            if (id != book.Id)
                return BadRequest(); //400
                                     //↑↑↑↑↑↑↑↑↑↑↑ istisna durumlar halledilid

            ApplicationContext.Books.Remove(entity); //entity siliyorum
            book.Id = entity.Id; //her ihtimale karşı map'liyorum
            ApplicationContext.Books.Add(book);
            return Ok(book);   //200

        }

        [HttpDelete]
        public IActionResult DeleteAllBooks()
        {
            ApplicationContext.Books.Clear();  //basit bir kod anlaşılır
            return NoContent();  //204

        }

        //Delete istekleri
        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name = "id")]int id)
        {
            var entity = ApplicationContext
                .Books
                .Find(b => b.Id.Equals(id));

            if(entity is null)
                return NotFound(new
                {
                    statusCode = 404,
                    message =$"Book with id:{id} could not found."
                }); //404


            ApplicationContext.Books.Remove(entity);
            return NoContent();
        }



        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name ="id")]int id,
           [FromBody] JsonPatchDocument <Book> bookPatch) 

        {
            //check entity
            var entity = ApplicationContext.Books.Find(b => b.Id.Equals(id));
            if (entity is null)
                return NotFound(); //404
            bookPatch.ApplyTo(entity);
            return NoContent(); 


        }

    }
}
