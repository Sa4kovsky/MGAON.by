using System.ComponentModel.DataAnnotations;


namespace Website.Assistant.SendEmail.UsersSendEmail
{
    public class PhysicalPerson
    {
        public string Designation { get; set; }
        [Required(ErrorMessage = "Укажите полностью ФИО")]
        [RegularExpression(@"^([А-яёіў ][а-яёіў ]+[\-\'\s]?){3,}?$", ErrorMessage = "Укажите полностью ФИО (кириллица).")]
        public string Name { get; set; }

        public string Address { get; set; }

        public string Message { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; } 
    }
}
