using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TYAJZWeb.Models;
using TYAJZWeb.Data;


namespace TYAJZWeb.Controllers
{
    public class ConstructorController : BaseController
    {

        public ActionResult List()
        {
            var r = Context.Constructors.Where(t => t.IsDeleted == false)
                .OrderByDescending(t => t.Id)
                .Select(t => (ConstructorListModel)t)
                .Skip(0).Take(20).ToList();
            return View(r);
        }

        [HttpGet]
        public ActionResult Add()
        {
            LoadDropDownList();
            return View("Edit");
        }

        [HttpPost]
        public ActionResult Add(ConstructorEditModel model)
        {
            if (ModelState.IsValid)
            {
                Constructor c = (Constructor)model;
                c.CreateDT = DateTime.Now;
                c.ModifiedDT = DateTime.Now;
                c.LastModifiedUser = 1;
                c.IsPrinted = false;
                c.IsDeleted = false;
                Context.Constructors.InsertOnSubmit(c);
                Context.SubmitChanges();

                return RedirectToAction("List");
            }
            return View("Edit", model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            LoadDropDownList();
            return View("Edit", (ConstructorEditModel)Context.Constructors.Single(t => t.Id == id));
        }

        [HttpPost]
        public ActionResult Edit(ConstructorEditModel model)
        {
            if (ModelState.IsValid)
            {
                var c = Context.Constructors.Single(t => t.Id == model.Id);
                c.BirthYear = model.BirthYear;
                c.CategoryId = model.CategoryId;
                c.CertificationNO = model.CertificationNO;
                c.Comment = model.Comment;
                c.Employer = model.Employer;
                c.InsuranceId = model.InsuranceId;
                c.IssueDate = model.IssueDate;
                c.IssuingAuthority = model.IssuingAuthority;
                c.LastModifiedUser = 1;
                c.ModifiedDT = DateTime.Now;
                c.Name = model.Name;
                Context.SubmitChanges();
                return RedirectToAction("List");
            }
            return View("Edit", model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var c = Context.Constructors.Single(t => t.Id == id);
            c.IsDeleted = true;
            Context.SubmitChanges();
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Print(int id)
        {
            return View();
        }


        private void LoadDropDownList()
        {
            ViewBag.Categories = Context.Categories.Select(t => new SelectListItem() { Text = t.Value, Value = t.Id.ToString() }).ToList();
            ViewBag.Insurances = Context.Insurances.Select(t => new SelectListItem() { Text = t.Value, Value = t.Id.ToString() }).ToList();
        }
    }
}
