using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TYAJZWeb.Data;

namespace TYAJZWeb.Models
{
    public abstract class EquipmentBaseModel
    {
        [Display(Name = "备案编号")]
        public String Eq_no { get; set; }

        [Display(Name = "本地外地判断")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "本地外地判断不许为空")]
        public bool IsLocal { get; set; }

        [Display(Name = "设备名称")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "设备名称不许为空")]
        public String Eq_Name { get; set; }

        [Display(Name = "设备型号")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "设备型号不许为空")]
        public String Eq_Type { get; set; }

        [Display(Name = "合格证号")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "合格证号不许为空")]
        public String Eq_CertNo { get; set; }

        [Display(Name = "出厂日期")]
        public DateTime Eq_MadeDate { get; set; }

        [Display(Name = "出厂代号")]
        public String Eq_MadeNo { get; set; }

        [Display(Name = "产权单位")]
        public String Eq_Owner { get; set; }

        [Display(Name = "负责人")]
        public String Eq_OwnerInCharge { get; set; }

        [Display(Name = "地址")]
        public String Eq_OwnerAdderss { get; set; }

        [Display(Name = "联系电话")]
        public String Eq_OwnerPhone { get; set; }

        [Display(Name = "设备生产厂家")]
        public String Eq_Producer { get; set; }

        [Display(Name = "特种设备制造许可证编号")]
        public String Eq_SpecCertNo { get; set; }

        [Display(Name = "设备年限")]
        public String Eq_LimitMonths { get; set; }

        [Display(Name = "已用年限")]
        public String Eq_HaveUsedMonths { get; set; }

        [Display(Name = "档案位置柜号")]
        public String Eq_RecDeskNo { get; set; }

        [Display(Name = "档案位置档案盒号")]
        public String Eq_RecBoxNo { get; set; }

        [Display(Name = "设备状态")]
        public EquipmentStatus Eq_Status { get; set; }

        [Display(Name = "打印标注")]
        public bool Eq_IsPrinted { get; set; }

        [Display(Name = "录入员")]
        public String Eq_Recorder { get; set; }

        [Display(Name = "备注")]
        public String Eq_Comment { get; set; }


        public enum EquipmentStatus
        {
            Available,
            Working,
            Destoryed
        }
    }

    public class EquipmentListModel : EquipmentBaseModel
    {
        public int Id { get; set; }
        public String NO { get; set; }
        public DateTime RegisterDate { get; set; }

        public static explicit operator EquipmentListModel(Equipment model)
        {
            EquipmentListModel m = new EquipmentListModel()
            {
                Id = model.Id,
                //NO = String.Format("{0:D5}", model.Id),
                NO = model.Eq_no,
                Eq_OwnerAdderss = model.Eq_Adderss,
                Eq_CertNo = model.Eq_CertNo,
                Eq_Comment = model.Eq_Comment,
                Eq_HaveUsedMonths = Convert.ToInt32((DateTime.Now - model.Eq_MadeDate).TotalDays / 365).ToString(),
                Eq_OwnerInCharge = (model.IsLocal) ? model.Company.Contactor : model.Eq_InCharge,
                Eq_IsPrinted = model.Eq_IsPrinted,
                Eq_LimitMonths = Convert.ToInt32(model.EquipmentType.LimitedMonth / 12).ToString(),
                Eq_MadeDate = model.Eq_MadeDate,
                Eq_MadeNo = model.Eq_MadeNo,
                Eq_Name = model.EquipmentType.Name,
                Eq_Owner = (model.IsLocal) ? model.Company.Name : model.Eq_Owner,
                Eq_no = String.Format("{0:D5}", model.Id),
                Eq_Producer = (model.IsLocal) ? model.Company1.Name : model.Eq_Producer,
                Eq_RecBoxNo = model.Eq_RecBoxNo,
                Eq_RecDeskNo = model.Eq_RecDeskNo,
                Eq_Recorder = "wlifeng",
                Eq_SpecCertNo = (model.IsLocal) ? model.Company1.ProductCertNO : model.Eq_SpecCertNo,
                Eq_Status = (EquipmentStatus)Enum.Parse(typeof(EquipmentStatus), model.Eq_Status, true),
                Eq_Type = model.Eq_Type,
                 RegisterDate=model.CreateDT,
                IsLocal = model.IsLocal
            };
            return m;
        }
    }

    public class EquipmentEditModel : EquipmentBaseModel
    {
        public int Id { get; set; }

        [Display(Name = "产权单位")]
        [Required(AllowEmptyStrings=true)]
        public int Eq_OwnerCompanyId { get; set; }
        
        [Display(Name = "设备生产厂家")]
        public int Eq_ProducerCompanyId { get; set; }

        [Display(Name = "备案管理部门")]
        [Required]
        public String RegisterDepartment { get; set; }

        [Display(Name = "地址")]
        [Required]
        public String RegisterDepartmentAddress { get; set; }

        [Display(Name = "电话")]
        [Required]
        public String RegisterDepartmentPhone { get; set; }

        public static explicit operator Equipment(EquipmentEditModel model)
        {
            return new Equipment()
            {
                Eq_Adderss = model.Eq_OwnerAdderss,
                Eq_SpecCertNo = model.Eq_SpecCertNo,
                Eq_CertNo = model.Eq_CertNo,
                Eq_Comment = model.Eq_Comment,
                Eq_InCharge = model.Eq_OwnerInCharge,
                Eq_MadeDate = model.Eq_MadeDate,
                Eq_Owner = model.Eq_Owner,
                Eq_OwnerId = model.Eq_OwnerCompanyId,
                Eq_Producer = model.Eq_Producer,
                Eq_ProducerId = model.Eq_ProducerCompanyId,
                Eq_RecBoxNo = model.Eq_RecBoxNo,
                Eq_RecDeskNo = model.Eq_RecDeskNo,
                Eq_Status = model.Eq_Status.ToString(),
                Eq_Name = Convert.ToInt32(model.Eq_Name),
                IsLocal = model.IsLocal,
                Id = model.Id,
                Eq_MadeNo = model.Eq_MadeNo,
                Eq_Type = model.Eq_Type
            };
        }

        public static explicit operator EquipmentEditModel(Equipment model)
        {
            return new EquipmentEditModel()
            {
                Eq_OwnerAdderss = model.Eq_Adderss,
                Eq_SpecCertNo = model.Eq_SpecCertNo,
                Eq_CertNo = model.Eq_CertNo,
                Eq_Comment = model.Eq_Comment,
                Eq_OwnerInCharge = model.Eq_InCharge,
                Eq_MadeDate = model.Eq_MadeDate,
                Eq_Owner = model.Eq_Owner,
                Eq_OwnerCompanyId = model.Eq_OwnerId ?? 0,
                Eq_Producer = model.Eq_Producer,
                Eq_ProducerCompanyId = model.Eq_ProducerId ?? 0,
                Eq_RecBoxNo = model.Eq_RecBoxNo,
                Eq_RecDeskNo = model.Eq_RecDeskNo,
                Eq_Status = (EquipmentStatus)Enum.Parse(typeof(EquipmentStatus), model.Eq_Status, true),
                IsLocal = model.IsLocal,
                Id = model.Id,
                Eq_MadeNo = model.Eq_MadeNo,
                Eq_Type = model.Eq_Type
            };
        }

    }
}