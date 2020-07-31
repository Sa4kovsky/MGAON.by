using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Website.Models.UsersSendEmail;
using Website.Models.Context;
using Website.Models.ModelsView;
using Website.Assistant.SendEmail;
using System.Collections.Generic;

namespace Website.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        private protected readonly IHostingEnvironment _appEnvironment;
        private protected readonly IStringLocalizer<HomeController> _localizer; //для новостей на разных языках

        /*public HomeController(ContextNews context, IHostingEnvironment appEnvironment, IStringLocalizer<HomeController> localizer)
        {
            _appEnvironment = appEnvironment;
            _dbNews = context;
            _localizer = localizer;
        }
        */
        public HomeController(IHostingEnvironment appEnvironment, IStringLocalizer<HomeController> localizer)
        {
            _appEnvironment = appEnvironment;
            _localizer = localizer;
        }


        /*Используем куки для установки культуры.
         Этот метод в качестве параметров принимает код устанавливаемой культуры и адрес, на который надо вернуться после установки культуры.*/
        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
            return LocalRedirect(returnUrl);
        }


        DateTime monday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday).AddDays(-7);
        DateTime friday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Saturday);
        int week = DateTime.Now.Month;

        /// <summary>
        /// monday - переменная определяет понедельник прошлой недели
        /// friday - переменная определяет текущее воскресенье
        /// indexViewsModels - модель в которую записываются данные трех других моделей 
        ///     (
        ///     News - новости, 
        ///     NewsTable - таблица новостей на месяц, 
        ///     SummaryOneWin - хранимая процедура для сектора Факты
        ///     Procedures - перечень административных процедур, выполняемых комунальным унитарным предприятием
        ///     )
        /// </summary>
        /// <returns>Трех моделей в одной</returns>
        [Route("index")]
        [Route("")]
        [Route("~/")]
        public IActionResult Index()
        {
            using (Context _dbNews = new Context())
            {
                IndexViewModels indexViewsModels = new IndexViewModels
                {
                    News = _dbNews.News.Where(p => p.Language == _localizer["Language"].Value.ToString())
                                   .Where(p => p.DateStart >= monday && p.DateFinish <= friday)
                                   .OrderBy(p => p.DateStart).ToList(),
                    NewsTable = _dbNews.NewsTable.Where(p => Convert.ToDateTime(p.DateTime.Substring(0,9)).Month == week).OrderBy(o => o.DateTime).ToList(),
                   // NewsTable = _dbNews.NewsTable.OrderBy(o => o.DateTime).ToList(),
                    SummaryOneWin = _dbNews.ViewSummaryOneWin.ToList(),
                    Procedures = _dbNews.Procedures.ToList(),
                    People = new Person()
                };

                return View(indexViewsModels);
            }
        }


        SendEmail _sendEmail = new SendEmail();

        [Route("sendEmail")]
        public JsonResult Contacts(Person person)
        {
           _sendEmail.SendEmailAsync(person, "Обратная связь");
            return new JsonResult("Ваше сообщение было отправлено. Спасибо!");
        }

    }
}
