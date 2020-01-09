using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public HomeController(ContextNews context, IHostingEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
            _dbNews = context;
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

        private readonly IStringLocalizer<HomeController> _localizer; //для новостей на разных языках
        public IndexView _indexViews;


        public async Task<IActionResult> Index()
        {
            var newsTable = _dbNews.NewsTable.Where(p => p.DateTime != null).Where(p => p.DateTime != "");
            var news = _dbNews.NewsTable.Where(p => p.DateTime != null).Where(p => p.DateTime != "");
           // _indexViews = new IndexView(news, newsTable);
            return View();
        }

    
    }
}
