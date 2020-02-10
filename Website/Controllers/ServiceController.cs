using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Website.Assistant.SendEmail;
using Website.Models.Context;
using Website.Models.OneWin;
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

        SendEmail _sendEmail = new SendEmail();
        Models.UsersSendEmail.FileMode file;
        
        /// <summary>
        /// Функция получает от Ajax метода данные для отправки по почте не обнавляя View
        /// </summary>
        /// <param name="person">данные о человеке и его обращение</param>
        /// <returns></returns>
        [Route("sendEmail")]
        public JsonResult SendEmail(Person person)
        {
            if (person.File != null)
            {
                // путь к папке Files
                string path = person.File.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream("/app/wwwroot/share-pictures/" + person.File.FileName, System.IO.FileMode.Create))
                {
                    person.File.CopyToAsync(fileStream);
                }
                file = new Models.UsersSendEmail.FileMode { Name = person.File.FileName, Path = person.File.FileName };
            }
            _sendEmail.SendEmailAsync(person, "Электронное обращение", file);
            return new JsonResult("Ваше сообщение было отправлено. Спасибо!");
        }

        [Route("information")]
        [HttpGet]
        public IActionResult Information()
        {
            return View();
        }

        [Route("information")]
        [HttpPost]
        public IActionResult Information(string lName, int docNo, string area)
        {
            Area(area);
            using (ContextNews contextDB = new ContextNews())
            {
                List<Registration> registrations = contextDB.Registration.FromSql("EXECUTE dbo.Registration @nameDB = {0}, @lName = {1}, @docNo = {2}", stringConnect.ToString(), lName, docNo).ToList();
                return View(registrations);
            }
        }

        StringBuilder stringConnect = new StringBuilder();

        void Area(string area)
        {
            switch (area)
            {
                case "Заводской":
                    stringConnect = new StringBuilder("onewin_zav_db");
                    break;
                case "Ленинский":
                    stringConnect = new StringBuilder("onewin_len_db");
                    break;
                case "Московский":
                    stringConnect = new StringBuilder("onewin_mos_db");
                    break;
                case "Октябрьский":
                    stringConnect = new StringBuilder("onewin_okt_db");
                    break;
                case "Партизанский":
                    stringConnect = new StringBuilder("onewin_par_db");
                    break;
                case "Первомайский":
                    stringConnect = new StringBuilder("onewin_per_db");
                    break;
                case "Советский":
                    stringConnect = new StringBuilder("onewin_sov_db");
                    break;
                case "Фрунзенcкий":
                    stringConnect = new StringBuilder("onewin_frun_db");
                    break;
                case "Центральный":
                    stringConnect = new StringBuilder("onewin_cen_db");
                    break;
                case "Мингорисполком":
                    stringConnect = new StringBuilder("onewin_mingor_db");
                    break;
                default:
                    stringConnect = new StringBuilder("onewin_test_db");
                    break;
            }
        }
    }
}