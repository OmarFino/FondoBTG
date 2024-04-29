namespace FondoBTG.Models
{
    public class Response
    {
        
        
        public String statusCode {  get; set; }
       public String statusMessage {  get; set; }

        public dynamic data { get; set; }

        public Response(String statusCode, String statusMessage, dynamic data)
        {
            this.statusCode = statusCode;
            this.statusMessage = statusMessage;
            this.data = data;
        }
    }
}
