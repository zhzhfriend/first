using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TYAJZWeb.Models;
using TYAJZWeb.Data;

namespace TYAJZWeb.Controllers
{
    public class UserController : BaseController
    {
        public ActionResult List()
        {
            var r = Context.Users.Where(t => t.IsDeleted == false)
                .OrderByDescending(t => t.Id)
                .Select(t => (UserListModel)t)
                .Skip(0).Take(20).ToList();
            return View(r);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View("Edit");
        }

        [HttpPost]
        public ActionResult Add(UserEditModel model)
        {
            if (ModelState.IsValid)
            {
                User c = (User)model;
                c.CreateDT = DateTime.Now;
                c.ModifiedDT = DateTime.Now;
                c.IsDeleted = false;
                Context.Users.InsertOnSubmit(c);
                Context.SubmitChanges();
                return RedirectToAction("List");
            }
            return View("Edit", model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View("Edit", (UserEditModel)Context.Users.Single(t => t.Id == id));

        }

        [HttpPost]
        public ActionResult Edit(UserEditModel model)
        {
            if (ModelState.IsValid)
            {
                var c = Context.Users.Single(t => t.Id == model.Id);
                
                Context.SubmitChanges();
                return RedirectToAction("List");

            }
            return View("Add", model);
        }

        public ActionResult Delete(int id)
        {
            var c = Context.Users.Single(t => t.Id == id);
            c.IsDeleted = true;
            Context.SubmitChanges();
            return RedirectToAction("List");

        }
    }
}
