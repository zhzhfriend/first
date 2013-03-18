using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TYAJZWeb.Data;

namespace TYAJZWeb.Models
{
    public class ProjectBaseModel
    {
        public int Id { get; set; }

        [Display(Name = "工程名称")]
        [Required]
        public String Name { get; set; }

        [Display(Name = "工程地址")]
        [Required]
        public String Address { get; set; }

        [Display(Name = "设备")]
        public int EquipmentId { get; set; }

        [Display(Name = "施工单位")]
        [Required]
        public String ConstructionCompany { get; set; }

        [Display(Name = "项目经理")]
        [Required]
        public String ConstructionProjectManager { get; set; }

        [Display(Name = "联系电话")]
        [Required]
        public String ConstructionProjectManagerPhoneMobile { get; set; }


        [Display(Name = "安拆单位")]
        [Required]
        public String DemolitionCompany { get; set; }

        [Display(Name = "负责人")]
        [Required]
        public String DemolitionCompanyManager { get; set; }

        [Display(Name = "联系电话")]
        [Required]
        public String DemolitionCompanyManagerMobile { get; set; }

        [Display(Name = "检测单位")]
        [Required]
        public String InspectCompany { get; set; }

        [Display(Name = "检测时间")]
        [Required]
        public String InspectTime { get; set; }

        [Display(Name = "检测编号")]
        [Required]
        public String InspectNo { get; set; }

        [Display(Name = "安装日期")]
        [Required]
        public DateTime ConstructDateTime { get; set; }

        [Display(Name = "计划拆卸日期")]
        [Required]
        public DateTime DemolitionDateTime { get; set; }

        [Display(Name = "建筑高度")]
        [Required]
        public String High { get; set; }

        [Display(Name = "备注")]
        public String Comment { get; set; }

        [Display(Name="工程状态")]
        public ProjectStatus Status { get; set; }
    }

    public enum InspectResults
    {
        None,
        Failure,
        Pass
    }

    public enum ProjectStatus
    {
        New,
        InspectResultSuccess,
        InspectResultFailure,
        Working,
        Finish,
        Destroyed
    }

    public class ProjectAddModel : ProjectBaseModel
    {
        public Equipment Equipment;

        public ProjectAddModel(Equipment e)
        {
            Equipment = e;
        }

        public String EquipmentName
        {
            get
            {
                return Equipment.EquipmentType.Name;
            }
        }
        public String EquipmentModel
        {
            get
            {
                return Equipment.Eq_Type;
            }
        }
        public String EquipmentNO
        {
            get
            {
                return Equipment.Eq_no;
            }
        }

        public String OwnerCompany
        {
            get
            {
                return Equipment.Company.Name;
            }
        }
        public String Owner
        {
            get
            {
                return Equipment.Company.Legal;
            }
        }
        public String Mobile
        {
            get
            {
                return Equipment.Company.PhoneOfLegal;
            }
        }
    }

    public class ProjectListModel : ProjectBaseModel
    {

        public String EquipmentNo { get; set; }
        public String EquipmentCertNo { get; set; }
        public InspectResults InspectResult { get; set; }
        public String InspectResultString
        {
            get
            {
                switch (InspectResult)
                {
                    case InspectResults.None:
                        return string.Empty;
                    case InspectResults.Failure:
                        return "未通过";
                    case InspectResults.Pass:
                        return "通过";
                    default:
                        return string.Empty;
                }
            }
        }
        public bool HasPrinted { get; set; }

        public string HasPrintedString
        {
            get
            {
                return (HasPrinted) ? "是" : "否";
            }
        }
    }
}