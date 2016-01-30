using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Danyl.SnnuURP.WebUI.Areas.Teacher.Controllers
{
    public class MessegeController : Controller
    {
        // GET: Teacher/Messege
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CollegeMsg()
        {
            ViewBag.CollegeMsg = null;
            return View(ViewBag);
        }
        
        public ActionResult LetterMsg()
        {
            ViewBag.LetterMsg = null;
            return View(ViewBag);
        }

        public ActionResult Advice()
        {
            ViewBag.Advice = null;
            return View(ViewBag);
        }
    }
}