using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TYAJZWeb.Data;

namespace TYAJZWeb.Models
{
    public class DriverBaseModel
    {
        [Display(Name = "人员编号")]
        public String NO { get; set; }

        [Display(Name = "姓名")]
        [Required]
        public String Name { get; set; }

        [Display(Name = "上岗证号")]
        [Required]
        public String CertificationNO { get; set; }

        [Display(Name = "是否上保")]
        public bool IsInsurance { get; set; }

        [Display(Name = "正在操机")]
        public bool IsWorking { get; set; }

        [Display(Name = "备注")]
        public String Comment { get; set; }

        [Display(Name = "所在单位")]
        [Required]
        public String Employer { get; set; }

        [Display(Name = "司机类别")]
        public String Category { get; set; }

        [Display(Name = "录入日期")]
        public DateTime RegisterDate { get; set; }
    }

    public class DriverListModel : DriverBaseModel
    {
        public int Id { get; set; }
        public bool IsPrinted { get; set; }

        public static explicit operator DriverListModel(Driver model)
        {
            return new DriverListModel()
            {
                Id = model.Id,
                NO = model.NO,
                Category = model.Category.Value,
                CertificationNO = model.CertificationNO,
                Comment = model.Comment,
                Employer = model.Employer,
                IsInsurance = model.IsInsurance,
                IsPrinted = model.IsPrinted,
                IsWorking = model.IsWorking,
                Name = model.Name,
                RegisterDate = model.CreateDT
            };
        }
    }

    public class DriverEditModel : DriverBaseModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "性别")]
        public String Gender { get; set; }

        [Display(Name = "出生年份")]
        public int BirthYear { get; set; }

        [Display(Name = "发证机关")]
        [Required]
        public String IssuingAuthority { get; set; }

        [Display(Name = "发证日期")]
        public DateTime IssueDate { get; set; }

        [Display(Name = "司机类别")]
        public int CategoryId { get; set; }

        public static explicit operator Driver(DriverEditModel model)
        {
            return new Driver()
            {
                BirthYear = model.BirthYear,
                CategoryId = Convert.ToInt32(model.Category),
                CertificationNO = model.CertificationNO,
                Comment = model.Comment,
                Employer = model.Employer,
                Gender = (model.Gender == "男" ? 0 : 1),
                IsInsurance = model.IsInsurance,
                IssueDate = model.IssueDate,
                IssuingAuthority = model.IssuingAuthority,
                IsWorking = model.IsWorking,
                Name = model.Name
            };
        }

        public static explicit operator DriverEditModel(Driver model)
        {
            return new DriverEditModel()
            {
                BirthYear = model.BirthYear,
                CategoryId = model.CategoryId,
                CertificationNO = model.CertificationNO,
                Comment = model.Comment,
                Employer = model.Employer,
                Gender = (model.Gender == 1 ? "男" : "女"),
                IsInsurance = model.IsInsurance,
                IssueDate = model.IssueDate,
                IssuingAuthority = model.IssuingAuthority,
                IsWorking = model.IsWorking,
                Name = model.Name
            };
        }
    }
}