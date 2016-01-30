using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Danyl.SnnuURP.WebUI.Areas.Teacher.Controllers
{
    public class MyInfoController : Controller
    {
        // GET: Teacher/MyInfo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Info()
        {
            int Tid = Convert.ToInt32(HttpContext.Session["userid"]);
            Danyl.SnnuURP.Model.Teacher teacher = new BLL.Teacher().GetModel(Tid);
            try
            {
                Danyl.SnnuURP.Model.Depart depart = new BLL.Depart().GetModel(teacher.DeptId);
                Danyl.SnnuURP.Model.TeacherType TType = new BLL.TeacherType().GetModel(teacher.TeacherTypeId);
                Danyl.SnnuURP.Model.UserInfo userInfo = new BLL.UserInfo().GetModel(Tid);
                ViewBag.Tid = teacher.Tid;
                ViewBag.Tname = teacher.Tname;
                ViewBag.Sex = teacher.Sex ? '男' : '女';
                ViewBag.IdNumber = teacher.IdNumber;
                ViewBag.Depart = depart.DeptName;
                ViewBag.Degree = teacher.Degree;
                ViewBag.TeacherType = TType.TeacherTypes;
                ViewBag.Phone = userInfo.UserPhone;
                ViewBag.Email = userInfo.UserEmail;
                return View(ViewBag);
            }
            catch (Exception ex)
            {
                return Redirect("~/Teacher/Account/Login");
            }
        }
    }
}