using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TYAJZWeb.Models;
using TYAJZWeb.Data;

namespace TYAJZWeb.Controllers
{
    public class DriversController : BaseController
    {
        String[] Categories = { "塔机", "龙门架", "电梯" };
        String[] Genders = { "男", "女" };

        public ActionResult List()
        {
            var r = Context.Drivers.Where(t => t.IsDeleted == false)
                .OrderByDescending(t => t.Id)
                .Select(t => (DriverListModel)t)
                .Skip(0).Take(20).ToList();
            return View(r);
        }

        [HttpGet]
        public ActionResult Add()
        {
            LoadDropDownList();

            return View("Edit");
        }

        private void LoadDropDownList()
        {
            ViewBag.Categories = Context.Categories.Select(t => new SelectListItem() { Text = t.Value, Value = t.Id.ToString() }).ToList();
            ViewBag.Genders = Genders.Select(t => new SelectListItem() { Text = t, Value = t }).ToList();
        }

        [HttpPost]
        public ActionResult Add(DriverEditModel model)
        {
            model.RegisterDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                Driver driver = (Driver)model;
                driver.CreateDT = DateTime.Now;
                driver.LastModifiedUser = 1;
                driver.ModifiedDT = DateTime.Now;
                driver.NO = "NOTASSIGNED";
                driver.IsPrinted = false;
                driver.IsDeleted = false;
                Context.Drivers.InsertOnSubmit(driver);
                Context.SubmitChanges();

                driver.NO = String.Format("{0:D5}", Context.Drivers.Count(t => t.Id < driver.Id) + 1);

                Context.SubmitChanges();

                return RedirectToAction("List");

            }
            LoadDropDownList();
            return View("Edit", model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            LoadDropDownList();
            var d = Context.Drivers.Single(t => t.Id == id);
            return View("Edit", (DriverEditModel)d);
        }

        [HttpPost]
        public ActionResult Edit(DriverEditModel model)
        {
            if (ModelState.IsValid)
            {
                var d = Context.Drivers.Single(t => t.Id == model.Id);
                d.Gender = (model.Gender == "男" ? 0 : 1);
                d.ModifiedDT = DateTime.Now;
                d.BirthYear = model.BirthYear;
                d.CategoryId = model.CategoryId;
                d.CertificationNO = model.CertificationNO;
                d.Comment = model.Comment;
                d.Employer = model.Employer;
                d.IsInsurance = model.IsInsurance;
                d.IssueDate = model.IssueDate;
                d.IssuingAuthority = model.IssuingAuthority;
                d.IsWorking = model.IsWorking;
                d.LastModifiedUser = 1;
                d.Name = model.Name;
                Context.SubmitChanges();
                return RedirectToAction("List");
            }
            LoadDropDownList();
            return View("Edit", model);
        }

        public ActionResult Delete(int id)
        {
            var d = Context.Drivers.Single(t => t.Id == id);
            d.IsDeleted = true;
            Context.SubmitChanges();
            return RedirectToAction("List");
        }

        public ActionResult Print(int id)
        {
            return View();
        }
    }
}
