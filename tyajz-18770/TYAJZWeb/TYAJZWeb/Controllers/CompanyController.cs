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
    public class CompanyController : BaseController
    {
        [CookiesAuthorize]
        public ActionResult List()
        {
            var r = Context.Companies.Where(t => t.IsDeleted == false)
                .OrderByDescending(t => t.Id)
                .Select(t => (CompanyListModel)t)
                .Skip(0).Take(20).ToList();
            return View(r);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View("Edit");
        }

        [HttpPost]
        public ActionResult Add(CompanyEditModel model)
        {
            ValidateModels(model);

            if (!model.CanProduct) model.ProductNO = string.Empty;
            if (!model.CanLend) model.LendNO = string.Empty;
            if (!model.CanInstall) model.InstallNO = string.Empty;

            if (ModelState.IsValid)
            {
                Company c = (Company)model;
                c.CreateDT = DateTime.Now;
                c.ModifiedDT = DateTime.Now;
                c.LastModifiedUser = 1;
                c.IsDeleted = false;
                Context.Companies.InsertOnSubmit(c);
                Context.SubmitChanges();
                return RedirectToAction("List");
            }
            return View("Edit", model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View("Edit", (CompanyEditModel)Context.Companies.Single(t => t.Id == id));

        }

        [HttpPost]
        public ActionResult Edit(CompanyEditModel model)
        {
            ValidateModels(model);
            
            if (!model.CanProduct) model.ProductNO = string.Empty;
            if (!model.CanLend) model.LendNO = string.Empty;
            if (!model.CanInstall) model.InstallNO = string.Empty;

            if (ModelState.IsValid)
            {
                var c = Context.Companies.Single(t => t.Id == model.Id);
                c.Address = model.Address;
                c.CanInstall = model.CanInstall;
                c.CanLend = model.CanLend;
                c.CanProduct = model.CanProduct;
                c.Comment = model.Comment;
                c.Contactor = model.Contactor;
                c.ContactorPhone = model.PhoneOfContactor;
                c.InstallCertNO = model.InstallNO;
                c.LastModifiedUser = 1;
                c.Legal = model.Legal;
                c.LendCertNO = model.LendNO;
                c.ModifiedDT = DateTime.Now;
                c.Name = model.Name;
                c.PhoneOfLegal = model.PhoneOfLegal;
                c.ProductCertNO = model.ProductNO;
                Context.SubmitChanges();
                return RedirectToAction("List");

            }
            return View("Add", model);
        }

        public ActionResult Delete(int id)
        {
            var c = Context.Companies.Single(t => t.Id == id);
            c.IsDeleted = true;
            Context.SubmitChanges();
            return RedirectToAction("List");

        }

        #region  "private"
        public void ValidateModels(CompanyEditModel model)
        {
            if (model.CanInstall && String.IsNullOrEmpty(model.InstallNO))
                ModelState.AddModelError("InstallNO", "安装资质编号不能为空");

            if (model.CanLend && String.IsNullOrEmpty(model.LendNO))
                ModelState.AddModelError("LendNO", "租赁资质编号不能为空");


            if (model.CanProduct && String.IsNullOrEmpty(model.ProductNO))
                ModelState.AddModelError("ProductNO", "生产资质编号不能为空");

        }

        #endregion
    }
}
