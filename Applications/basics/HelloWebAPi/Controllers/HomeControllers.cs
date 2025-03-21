using HelloWebAPi.Models;
using Microsoft.AspNetCore.Mvc;
using HelloWebAPi.Models;
using System.Net;

namespace HelloWebAPi.Controllers
{

    [ApiController]// Bu sınıfın bir API kontrolcüsü olduğunu belirtiyor
    [Route("home")] // Bu kontrolcü "home" route'unda çalışacak
    public class HomeControllers : ControllerBase
    {
        [HttpGet]// HTTP GET isteği alır

        public IActionResult GetMessage()
        {
            var result = new ResponseModel()
            {
                HttpStatus = 200, // HTTP durum kodu 200 (Başarılı) 
                Message = "Hello ASP.Net Core Web API" // Döndürülecek mesaj
            };

            return Ok(result); // HTTP 200 ile JSON formatında yanıt döndürür

        }


    }
}
