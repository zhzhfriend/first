using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVCWeb.Utils;
using TYAJZWeb.Models;

using TYAJZWeb.Utils;

namespace TYAJZWeb.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserLogonModel model)
        {
            if (ModelState.IsValid)
            {
                var user = Context.Users.Where(t => t.IsDeleted == false).SingleOrDefault(t => t.Name == model.UserName && t.PassWord == model.PassWord);
                if (user != null)
                {
                    UserAuthnicationHelper.Login(user, HttpContext);

                    if (!String.IsNullOrEmpty(Request.QueryString[GlobalVariables.QS_NEXT_PARAMETERNAME]))
                    {
                        return Redirect(Request.QueryString[GlobalVariables.QS_NEXT_PARAMETERNAME]);
                    }
                    else
                    {
                        return RedirectToAction("Main");
                    }
                }
                else
                {
                    ModelState.AddModelError("Error", "用户名密码错误");
                    return View(model);
                }
            }
            return View(model);
        }

        [CookiesAuthorize]
        public ActionResult Main()
        {
            return View();
        }

        public ActionResult Logout()
        {
            UserAuthnicationHelper.Logout(HttpContext);
            return RedirectToAction("Index");
        }



    }
}
