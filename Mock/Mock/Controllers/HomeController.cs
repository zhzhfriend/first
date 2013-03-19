using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mock.Models;
using Mock.Models.Interfaces;
using Mock.Models.Entities;

namespace Mock.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        //public ActionResult Index()
        //{
        //    ICategoryService cServ = ServiceBuilde.BuildCategoryService();
        //    ViewData["Categories"] = cServ.GetAll();
        //    return View("index");

        //}
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserloginModel model)
        {
            var user = model.UserName;
            var a = model.PassWord;

            return RedirectToAction("Index");
        }
    }
}
