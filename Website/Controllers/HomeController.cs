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
        private readonly IHostingEnvironment _appEnvironment;
        private readonly ContextNews _dbNews;
        private readonly IStringLocalizer<HomeController> _localizer; //для новостей на разных языках

        public HomeController(ContextNews context, IHostingEnvironment appEnvironment, IStringLocalizer<HomeController> localizer)
        {
            _appEnvironment = appEnvironment;
            _dbNews = context;
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

        /// <summary>
        /// monday - переменная определяет понедельник прошлой недели
        /// friday - переменная определяет текущее воскресенье
        /// indexViewsModels - модель в которую записываются данные трех других моделей 
        ///     (
        ///     News - новости, 
        ///     NewsTable - таблица новостей на месяц, 
        ///     SummaryOneWin - хранимая процедура для сектора Факты
        ///     )
        /// </summary>
        /// <returns>Терех моделей в одной</returns>
        [Route("index")]
        [Route("")]
        [Route("~/")]
        public IActionResult Index()
        {
            DateTime monday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday).AddDays(-7);
            DateTime friday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Saturday);

            IndexViewModels indexViewsModels = new IndexViewModels();
            //запись данных News которые соответсвуют текущему языку на сайте в промежуток времени от monday до friday
            indexViewsModels.News = _dbNews.News.Where(p => p.Language == _localizer["Language"].Value.ToString())
                               .Where(p => p.DateStart >= monday && p.DateFinish <= friday)
                               .OrderBy(p => p.DateStart).ToList();
            indexViewsModels.NewsTable = _dbNews.NewsTable.Where(p => p.DateTime != null).Where(p => p.DateTime != "").ToList();
            indexViewsModels.SummaryOneWin = _dbNews.ViewSummaryOneWin.ToList();
            indexViewsModels.People = new Person();
            return View(indexViewsModels);
        }


        SendEmail _sendEmail = new SendEmail();

        [Route("sendEmail")]
        public JsonResult Contacts(Person person)
        {
         //   _sendEmail.SendEmailAsync(person, "Обратная связь");
            return new JsonResult("Ваше сообщение было отправлено. Спасибо!");
        }

    }
}
