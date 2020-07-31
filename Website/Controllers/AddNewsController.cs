using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Website.Assistant.LoadXLSX;
using Website.Models.Context;
using Website.Models.WebSiteBD;
using Website.Models.WebSiteBD.LoadXLSX;

namespace Website.Controllers
{
    public class AddNewsController : Controller
    {
        public IActionResult Index()
        {
            using (Context _dbNews = new Context())
            {
                var news = _dbNews.News.Where(d => d.DateStart.Month >= DateTime.Now.Month).Where(f => f.DateStart.Month <= DateTime.Now.Month + 1).OrderBy(t => t.DateStart).ToList();
                return View(news);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new News());
        }

        public ViewResult Edit(int Id)
        {
            using (Context _dbNews = new Context())
            {
                News news = _dbNews.News
            .FirstOrDefault(g => g.Id == Id);
                return View(news);
            }
        }

        [HttpPost]
        public ActionResult Edit(News news)
        {
            if (ModelState.IsValid)
            {
                Save(news);
                TempData["message"] = string.Format("Изменения в новости \"{0}\" были сохранены", news.Title);
                return Redirect("Index");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(news);
            }
        }

        public void Save(News news)
        {
            using (Context _dbNews = new Context())
            {
                if (news.Id == 0)
                    _dbNews.Add(news);
            else
            {
                News dbEntry = _dbNews.News.Find(news.Id);
                if (dbEntry != null)
                {
                    dbEntry.Title = news.Title;
                    dbEntry.Name = news.Name;
                    dbEntry.Organization = news.Organization;
                    dbEntry.Position = news.Position;
                    dbEntry.DateStart = news.DateStart;
                    dbEntry.DateFinish = news.DateFinish;
                    dbEntry.Language = news.Language;
                }
            }
                _dbNews.SaveChanges();
            }
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            News deleted = DeleteNews(Id);
            if (deleted != null)
            {
                TempData["message"] = string.Format("Новость \"{0}\" была удалена",
                    deleted.Title);
            }
            return Redirect("Index");
        }

        public News DeleteNews(int Id)
        {
            using (Context _dbNews = new Context())
            {
                News dbEntry = _dbNews.News.Find(Id);
                if (dbEntry != null)
                {
                    _dbNews.News.Remove(dbEntry);
                    _dbNews.SaveChanges();
                }
                return dbEntry;
            }
        }


        int week = DateTime.Now.Month;
        public IActionResult NewsTable()
        {
            using (Context _dbNews = new Context())
            {
                var news = _dbNews.NewsTable.Where(p => Convert.ToDateTime(p.DateTime.Substring(0, 9)).Month == week).OrderBy(d => d.DateTime).ToList();
                return View(news);
            }
        }

        public ViewResult CreateTable()
        {
            return View("EditTable", new NewsTable());
        }

        public ViewResult EditTable(int Id)
        {
            using (Context _dbNews = new Context())
            {
                NewsTable news = _dbNews.NewsTable
            .FirstOrDefault(g => g.Id == Id);
            return View(news);
            }
        }

        [HttpPost]
        public ActionResult EditTable(NewsTable news)
        {
            if (ModelState.IsValid)
            {
                Save(news);
                TempData["message"] = string.Format("Изменения в новости \"{0}\" были сохранены", news.Name);
                return Redirect("NewsTable");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(news);
            }
        }

        public void Save(NewsTable news)
        {
            using (Context _dbNews = new Context())
            {
                if (news.Id == 0)
                    _dbNews.Add(news);
                else
                {
                    NewsTable dbEntry = _dbNews.NewsTable.Find(news.Id);
                    if (dbEntry != null)
                    {
                        dbEntry.DateTime = news.DateTime;
                        dbEntry.Name = news.Name;
                        dbEntry.Executor = news.Executor;
                    }
                }
                _dbNews.SaveChanges();
            }
        }

        [HttpPost]
        public ActionResult DeleteTable(int Id)
        {
            NewsTable deleted = DeleteNewsTable(Id);
            if (deleted != null)
            {
                TempData["message"] = string.Format("Новость \"{0}\" была удалена",
                    deleted.Name);
            }
            return Redirect("NewsTable");
        }

        public NewsTable DeleteNewsTable(int Id)
        {
            using (Context _dbNews = new Context())
            {
                NewsTable dbEntry = _dbNews.NewsTable.Find(Id);
                if (dbEntry != null)
                {
                    _dbNews.NewsTable.Remove(dbEntry);
                    _dbNews.SaveChanges();
                }
                return dbEntry;
            }
        }


        public ActionResult SaveNewsTable()
        {
            var dt = new LoadEcxel().ReadFile("/app/wwwroot/loading/ReadMePlease.xlsx");
            var myDataFromExcel = new List<NewsTable>();
            //Заполняем наш объект, считанными данными из DataTable
            foreach (DataRow item in dt.Rows)
            {
                if (item.ItemArray[0].ToString() != "") 
                {
                    myDataFromExcel.Add(new NewsTable(item));
                }
            }

            foreach (var item in myDataFromExcel)
            {
                using (Context _dbNews = new Context())
                {
                    _dbNews.Add(item);
                    _dbNews.SaveChanges();
                }
            }
            return Redirect("NewsTable");
        }

    }
}