using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers
{
    [Route("information")]
    public class HelpInformationController : Controller
    {
        [Route("index")]
        public IActionResult Index()
        {
            return View();
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
