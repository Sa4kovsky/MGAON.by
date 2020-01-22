using Microsoft.AspNetCore.Http;


namespace Website.Models.UsersSendEmail
{
    public class Person
    {
        public string Designation { get; set; }

        public string Name { get; set; }

        public string NameLegal { get; set; }

        public string Address { get; set; }

        public string Message { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public IFormFile File { get; set; }

    }
}
