using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TYAJZWeb.Models;
using TYAJZWeb.Data;


namespace TYAJZWeb.Controllers
{
    public class EquipmentController : BaseController
    {
        public ActionResult List()
        {
            var r = Context.Equipments.Where(t => t.IsDeleted == false)
                .OrderByDescending(t => t.Id)
                .Select(t => (EquipmentListModel)t)
                .Skip(0).Take(20).ToList();
            return View(r);
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.OwnerCompanies = Context.Companies.Where(t => t.IsDeleted == false && t.CanLend == true).Select(t =>
                new SelectListItem()
                {
                    Value = t.Id.ToString(),
                    Text = String.Format("{0}  | {1} | {2}", t.Name, t.Contactor, t.ContactorPhone)
                }).ToList();
            (ViewBag.OwnerCompanies as IList<SelectListItem>).Insert(0, new SelectListItem() { Value = "0", Text = "请选择" });

            ViewBag.ProductCompanies = Context.Companies.Where(t => t.IsDeleted == false && t.CanProduct == true).Select(t =>
                new SelectListItem()
                {
                    Value = t.Id.ToString(),
                    Text = String.Format("{0}  | {1} | {2}", t.Name, t.Contactor, t.ContactorPhone)
                }).ToList();

            (ViewBag.ProductCompanies as IList<SelectListItem>).Insert(0, new SelectListItem() { Value = "0", Text = "请选择" });

            ViewBag.Names = Context.EquipmentTypes.Select(t =>
                new SelectListItem()
                {
                    Value = t.Id.ToString(),
                    Text = t.Name
                }).ToList();
            return View("Edit");
        }

        [HttpPost]
        public ActionResult Add(EquipmentEditModel model)
        {
            if (ModelState.IsValid)
            {
                Equipment c = (Equipment)model;
                c.CreateDT = DateTime.Now;
                c.ModifiedDT = DateTime.Now;
                c.Eq_Recorder = 1;
                c.IsDeleted = false;
                c.Eq_no = c.Eq_no ?? string.Empty;
                c.Eq_Comment = c.Eq_Comment ?? string.Empty;

                if (c.IsLocal)
                {
                    c.Eq_Owner = Context.Companies.Single(t => t.IsDeleted == false && t.Id == c.Eq_OwnerId).Name;
                    c.Eq_InCharge = Context.Companies.Single(t => t.IsDeleted == false && t.Id == c.Eq_OwnerId).Contactor;
                    c.Eq_Adderss = Context.Companies.Single(t => t.IsDeleted == false && t.Id == c.Eq_OwnerId).Address;

                    c.Eq_Producer = Context.Companies.Single(t => t.Id == c.Eq_ProducerId).Name;
                    c.Eq_SpecCertNo = Context.Companies.Single(t => t.Id == c.Eq_ProducerId).ProductCertNO;
                }
                else
                {
                    c.Eq_OwnerId = null;
                    c.Eq_ProducerId = null;
                }

                Context.Equipments.InsertOnSubmit(c);

                Context.SubmitChanges();

                c.Eq_no = String.Format("{0}{1:D5}", c.EquipmentType.Prefix, (Context.Equipments.Count(t => t.Id < c.Id && t.Eq_Name == c.Eq_Name) + 1));

                Context.SubmitChanges();
                return RedirectToAction("List");
            }

            ViewBag.OwnerCompanies = Context.Companies.Where(t => t.IsDeleted == false && t.CanLend == true).Select(t =>
                new SelectListItem()
                {
                    Value = t.Id.ToString(),
                    Text = String.Format("{0}  | {1} | {2}", t.Name, t.Contactor, t.ContactorPhone)
                }).ToList();

            ViewBag.ProductCompanies = Context.Companies.Where(t => t.IsDeleted == false && t.CanProduct == true).Select(t =>
                new SelectListItem()
                {
                    Value = t.Id.ToString(),
                    Text = String.Format("{0}  | {1} | {2}", t.Name, t.Contactor, t.ContactorPhone)
                }).ToList();

            ViewBag.Names = Context.EquipmentTypes.Select(t =>
                new SelectListItem()
                {
                    Value = t.Id.ToString(),
                    Text = t.Name
                }).ToList();
            return View("Edit", model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.OwnerCompanies = Context.Companies.Where(t => t.IsDeleted == false && t.CanLend == true).Select(t =>
                new SelectListItem()
                {
                    Value = t.Id.ToString(),
                    Text = String.Format("{0}  | {1} | {2}", t.Name, t.Contactor, t.ContactorPhone)
                }).ToList();

            ViewBag.ProductCompanies = Context.Companies.Where(t => t.IsDeleted == false && t.CanProduct == true).Select(t =>
                new SelectListItem()
                {
                    Value = t.Id.ToString(),
                    Text = String.Format("{0}  | {1} | {2}", t.Name, t.Contactor, t.ContactorPhone)
                }).ToList();

            ViewBag.Names = Context.EquipmentTypes.Select(t =>
                new SelectListItem()
                {
                    Value = t.Id.ToString(),
                    Text = t.Name
                }).ToList();

            return View("Edit", (EquipmentEditModel)Context.Equipments.Single(t => t.Id == id));
        }

        [HttpPost]
        public ActionResult Edit(EquipmentEditModel model)
        {

            if (ModelState.IsValid)
            {
                var c = Context.Companies.Single(t => t.Id == model.Id);

                Context.SubmitChanges();
                return RedirectToAction("List");

            }

            ViewBag.OwnerCompanies = Context.Companies.Where(t => t.IsDeleted == false && t.CanLend == true).Select(t =>
                new SelectListItem()
                {
                    Value = t.Id.ToString(),
                    Text = String.Format("{0}  | {1} | {2}", t.Name, t.Contactor, t.ContactorPhone)
                }).ToList();

            ViewBag.ProductCompanies = Context.Companies.Where(t => t.IsDeleted == false && t.CanProduct == true).Select(t =>
                new SelectListItem()
                {
                    Value = t.Id.ToString(),
                    Text = String.Format("{0}  | {1} | {2}", t.Name, t.Contactor, t.ContactorPhone)
                }).ToList();

            ViewBag.Names = Context.EquipmentTypes.Select(t =>
                new SelectListItem()
                {
                    Value = t.Id.ToString(),
                    Text = t.Name
                }).ToList();

            return View("Edit", model);
        }

        public ActionResult Delete(int id)
        {
            var c = Context.Equipments.Single(t => t.Id == id);
            c.IsDeleted = true;
            Context.SubmitChanges();
            return RedirectToAction("List");

        }

        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(String no)
        {
            return View();
        }
    }
}
