using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Website.Models.Context;
using Website.Models.OneWin;

namespace Website.Controllers
{
    [Route("information")]
    public class HelpInformationController : Controller
    {
        /*
         * Для вывода всей инфы справочной системы используется несколько хранимых процедур:
         * 1.ProceduresList - выводит название перечней, глав, процедур.
         * 2.При нажатии на выбраную процедуру в хранимы процедуры передается ID-процедуры и выводятся данные для данной процедуры. 
         */
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        string _area;
        void Area(string area)
        {
            switch (area)
            {
                case "Заводской район":
                    _area = "onewin_zav_db";
                    break;
                case "Ленинский район":
                    _area = "onewin_len_db";
                    break;
                case "Московский район":
                    _area = "onewin_mos_db";
                    break;
                case "Октябрьский район":
                    _area = "onewin_okt_db";
                    break;
                case "Партизанский район":
                    _area = "onewin_par_db";
                    break;
                case "Первомайский район":
                    _area = "onewin_per_db";
                    break;
                case "Советский район":
                    _area = "onewin_sov_db";
                    break;
                case "Фрунзенcкий район":
                    _area = "onewin_frun_db"; 
                    break;
                case "Центральный район":
                    _area = "onewin_cen_db";
                    break;
                case "Мингорисполком":
                    _area = "onewin_mingor_db";
                    break;
                default:
                    _area = "onewin_mingor_db";
                    break;
            }
        }

        public FileResult Download(string path, string area)
        {
            Area(area);
            var doc = new byte[0];
            doc = System.IO.File.ReadAllBytes("/app/wwwroot/temp_site/" + _area + '/' + path);
            return File(doc, " application/vnd.openxmlformats-officedocument.wordprocessingml.document", path);
        }

        [HttpPost]
        [Route("index")]
        public IActionResult Index(string area, int check)
        {
            Area(area);
            using (Context _db = new Context())
            {
                List<ProceduresList> registrations = _db.ProceduresLists.FromSql("EXECUTE dbo.ProceduresLists @nameDB = {0}, @IP = {1}", _area, check).ToList();
                return View(registrations);
            }
        }

        /// <summary>
        /// Функция получает от Ajax метода данные для создания запросов в SQL, для получения информации о процедуре не обнавляя View
        /// </summary>
        /// <param name="person">данные о человеке и его обращение</param>
        /// <returns></returns>
        [Route("docregistry")]
        public JsonResult DocRegistry(string id, string area)
        {
            Area(area);
            using (Context _db = new Context())
            {
                ListRegistry listRegistry = new ListRegistry
                {
                    Registries = _db.Registry.FromSql("EXECUTE dbo.Registry @id = {0},  @nameDB = {1}", id, _area).ToList(),
                    NormativeDocs = _db.NormativeDoc.FromSql("EXECUTE dbo.NormativeDoc @id = {0},  @nameDB = {1}", id, _area).OrderBy(i=>i.Name).ToList(),
                    Documents = _db.Document.FromSql("EXECUTE dbo.Docs @id = {0},  @nameDB = {1}", id, _area).OrderBy(i=>i.Name).ToList(),
                    RequestedDocuments = _db.RequestedDocuments.FromSql("EXECUTE dbo.ZaprDocs @id = {0},  @nameDB = {1}", id, _area).OrderBy(i=>i.Name).ToList(),
                    Performers = _db.Performers.FromSql("EXECUTE dbo.Performers @id = {0},  @nameDB = {1}", id, _area).ToList(),
                    Departaments = _db.Departaments.FromSql("EXECUTE dbo.Departments @id = {0},  @nameDB = {1}", id, _area).ToList(),
                    Executor = _db.Performers.FromSql("EXECUTE dbo.Executor @id = {0},  @nameDB = {1}", id, _area).ToList(),
                    PaymentAccaount = _db.PaumentAccaounts.FromSql("EXECUTE dbo.PaymentAccount @id = {0},  @nameDB = {1}", id, _area).ToList(),
                    DepartamentsAccept = _db.Departaments.FromSql("EXECUTE dbo.DepartmentsAccept @id = {0},  @nameDB = {1}", id, _area).ToList(),
                    DocumentAccept = _db.Performers.FromSql("EXECUTE dbo.DocumentAccept @id = {0},  @nameDB = {1}", id, _area).ToList(),
                    CommentDepartaments = _db.CommentDepartaments.FromSql("EXECUTE CommentDepartaments  @id = {0}, @nameDB = {1}", id, _area).ToList()
                };

                return new JsonResult(listRegistry);
            }
        }

        [Route("unique")]
        public IActionResult UniqueId()
        {
            return View();
        }



        [Route("admprocedure")]
        public IActionResult AdmProcedure()
        {
            return View();
        }

        [Route("webcamers")]
        public IActionResult WebCamers()
        {
            return View();
        }
    }
}
