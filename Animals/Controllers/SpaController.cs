using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Animals.Controllers
{
    public class SpaController : Controller
    {
        // GET: Spa
        public ActionResult Index()
        {
            return View();
        }
    }
}