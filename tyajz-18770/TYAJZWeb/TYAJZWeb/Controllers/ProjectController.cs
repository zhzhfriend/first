using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TYAJZWeb.Models;
using TYAJZWeb.Data;
using TYAJZWeb.Utils;

namespace TYAJZWeb.Controllers
{
    public class ProjectController : BaseController
    {
        [CookiesAuthorize]
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        [CookiesAuthorize]
        public ActionResult List()
        {
            return View();
        }

        [CookiesAuthorize]
        [HttpGet]
        public ActionResult Add(String EquipmentId)
        {
            return View(new ProjectAddModel(Context.Equipments.SingleOrDefault(t => t.Eq_no == EquipmentId)));
        }

        [CookiesAuthorize]
        [HttpPost]
        public ActionResult Add(ProjectAddModel model)
        {
            return null;
        }

        [CookiesAuthorize]
        [HttpGet]
        public ActionResult ApplyForm(int id)
        {
            return View();
        }
    }
}
