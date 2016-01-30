using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Danyl.SnnuURP.WebUI.Areas.Teacher.Controllers
{
    public class EducationCenterController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Teach()
        {
            List<Danyl.SnnuURP.Model.TeachCourseView> teachList = new BLL.TeachCourseView().GetModelList(" Tid= " + this.HttpContext.Session["userid"].ToString());
            ViewBag.TeachList = teachList;
            return View(ViewBag);
        }

        public ActionResult StudentGrade()
        {
            List<Danyl.SnnuURP.Model.TeacherScoreView> scoreList = new BLL.TeacherScoreView().GetModelList(" Tid= " + this.HttpContext.Session["userid"].ToString());
            ViewBag.ScoreList = scoreList;
            return View(ViewBag);
        }

        public ActionResult MyBook()
        {
            return View();
        }
    }
}