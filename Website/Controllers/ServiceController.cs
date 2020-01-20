using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Website.Assistant.SendEmail;
using Website.Models.UsersSendEmail;

namespace Website.Controllers
{
    [Route("service")]
    public class ServiceController : Controller
    {
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("information")]
        public IActionResult Information()
        {
            return View();
        }

        SendEmail _sendEmail = new SendEmail();

        [Route("sendEmail")]
        public JsonResult SendEmail(Person person)
        {
            //   _sendEmail.SendEmailAsync(person, "Обратная связь");
            return new JsonResult("Ваше сообщение было отправлено. Спасибо!");
        }
    }
}