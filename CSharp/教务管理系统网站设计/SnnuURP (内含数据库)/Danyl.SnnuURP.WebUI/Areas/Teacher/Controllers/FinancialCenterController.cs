using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Danyl.SnnuURP.Model;

namespace Danyl.SnnuURP.WebUI.Areas.Teacher.Controllers
{
    public class FinancialCenterController : Controller
    {
        // GET: Teacher/FinancialCenter
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyFinancial()
        {
            List<TeacherWageAdjustmentView> teacherWage = new BLL.TeacherWageAdjustmentView().GetModelList(" Tid=" + Session["userid"].ToString());
            ViewBag.TeacherWageList = teacherWage;
            return View();
        }
    }
}