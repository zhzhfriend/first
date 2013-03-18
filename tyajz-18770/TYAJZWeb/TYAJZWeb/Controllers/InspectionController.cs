using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TYAJZWeb.Data;
using TYAJZWeb.Models;

namespace TYAJZWeb.Controllers
{
    public class InspectionController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(String no)
        {
            Equipment equipment = Context.Equipments.SingleOrDefault(t => t.Eq_no == no);
            if (equipment == null)
            {
                ModelState.AddModelError("Error", "未找到该编号,请核对设备编号是否正确");
            }
            else
            {
                EquipmentBaseModel.EquipmentStatus status = EquipmentBaseModel.EquipmentStatus.Available;
                if (Enum.TryParse<EquipmentBaseModel.EquipmentStatus>(equipment.Eq_Status, out status))
                {
                    switch (status)
                    {
                        case EquipmentBaseModel.EquipmentStatus.Available:
                            return RedirectToAction("Add", "Project", new { EquipmentId = no });
                            break;
                        case EquipmentBaseModel.EquipmentStatus.Destoryed:
                            ModelState.AddModelError("Error", "该设备为在用设备，请核对设备编号是否正确或该设备是否需要报拆。");
                            break;
                        case EquipmentBaseModel.EquipmentStatus.Working:
                            ModelState.AddModelError("Error", "该设备为已经报废，请核对设备编号是否正确。");
                            break;
                    }
                }
            }
            return View("SearchError");
        }
    }
}
