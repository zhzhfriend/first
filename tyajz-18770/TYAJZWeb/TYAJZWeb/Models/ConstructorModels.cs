using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using TYAJZWeb.Data;
using System.ComponentModel.DataAnnotations;

namespace TYAJZWeb.Models
{
    public class ConstructorBaseModel
    {
        public int Id { get; set; }

        [Display(Name = "出生年份")]
        [Required]
        public int BirthYear { get; set; }

        [Display(Name = "人员编号")]
        public String NO { get; set; }

        [Display(Name = "姓名")]
        [Required]
        public String Name { get; set; }

        [Display(Name = "上岗证号")]
        [Required]
        public String CertificationNO { get; set; }

        [Display(Name = "上保类型")]
        public int InsuranceId { get; set; }

        [Display(Name = "备注")]
        public String Comment { get; set; }

        [Display(Name = "所在单位")]
        [Required]
        public String Employer { get; set; }

        [Display(Name = "司机类别")]
        [Required]
        public int CategoryId { get; set; }
    }

    public class ConstructorListModel : ConstructorBaseModel
    {
        public bool IsPrinted { get; set; }
        public String Category { get; set; }
        [Display(Name = "上保类型")]
        public String Insurance { get; set; }
        public DateTime RegisterDate { get; set; }

        public static explicit operator ConstructorListModel(Constructor model)
        {
            return new ConstructorListModel()
            {
                Category = model.Category.Value,
                CertificationNO = model.CertificationNO,
                Comment = model.Comment,
                Employer = model.Employer,
                Id = model.Id,
                InsuranceId = model.InsuranceId,
                IsPrinted = model.IsPrinted,
                Name = model.Name,
                NO = String.Format("{0:D5}", model.Id),
                Insurance = model.Insurance.Value,
                RegisterDate = model.CreateDT
            };
        }
    }

    public class ConstructorEditModel : ConstructorBaseModel
    {
        [Display(Name = "发证机关")]
        [Required]
        public String IssuingAuthority { get; set; }

        [Display(Name = "发证日期")]
        public DateTime IssueDate { get; set; }

        public static explicit operator Constructor(ConstructorEditModel model)
        {
            return new Constructor()
            {
                BirthYear = model.BirthYear,
                CategoryId = model.CategoryId,
                CertificationNO = model.CertificationNO,
                Comment = model.Comment,
                Employer = model.Employer,
                InsuranceId = model.InsuranceId,
                IssueDate = model.IssueDate,
                IssuingAuthority = model.IssuingAuthority,
                Name = model.Name
            };
        }

        public static explicit operator ConstructorEditModel(Constructor model)
        {
            return new ConstructorEditModel()
            {
                BirthYear = model.BirthYear,
                CategoryId = model.CategoryId,
                CertificationNO = model.CertificationNO,
                Comment = model.Comment,
                Employer = model.Employer,
                InsuranceId = model.InsuranceId,
                IssueDate = model.IssueDate,
                IssuingAuthority = model.IssuingAuthority,
                Name = model.Name
            };
        }
    }
}