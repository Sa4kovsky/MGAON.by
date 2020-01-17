using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
    }
}