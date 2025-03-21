namespace HelloWebAPi.Models
{
    public class ResponseModel
    {

        public int HttpStatus { get; set; } // HTTP durum kodunu tutar (örn: 200, 404, 500)
        public string Message { get; set; } // API'nin döndüreceği mesajı tutar

    }
}
