using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Website.Models;
using Website.Models.Context;
using Website.Models.ModelsView;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        IHostingEnvironment _appEnvironment;
        private ContextNews _dbNews;
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



        public ActionResult Index()
        {
            DateTime _monday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday).AddDays(-7);
            DateTime _friday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Saturday);
            var aws = (DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Thursday)).AddDays(-6).ToShortDateString();
            IndexViewModels _indexViewsModels = new IndexViewModels();
            _indexViewsModels.News = _dbNews.News.Where(p => p.Language == _localizer["Language"].Value.ToString())
                               .Where(p => p.DateStart >= _monday && p.DateFinish <= _friday)
                               .OrderBy(p => p.DateStart).ToList();
            _indexViewsModels.NewsTable = _dbNews.NewsTable.Where(p => p.DateTime != null).Where(p => p.DateTime != "").ToList();


            return View(_indexViewsModels);
        }
    }
}
