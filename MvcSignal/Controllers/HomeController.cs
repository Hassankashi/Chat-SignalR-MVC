using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSignal.Controllers
{
    public class HomeController : Controller
    {
           
        public ActionResult Chat()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    
    }
}
