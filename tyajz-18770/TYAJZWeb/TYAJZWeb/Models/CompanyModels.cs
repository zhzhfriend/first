using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TYAJZWeb.Data;

namespace TYAJZWeb.Models
{
    public abstract class CompanyBaseModel
    {
        [Display(Name = "机构名称")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "机构名称不许为空")]
        public String Name { get; set; }

        [Display(Name = "机构地址")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "机构地址不许为空")]
        public String Address { get; set; }

        [Display(Name = "法人")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "法人不许为空")]
        public String Legal { get; set; }

        [Display(Name = "法人联系方式")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "法人联系方式不许为空")]
        public String PhoneOfLegal { get; set; }

        [Display(Name = "联系人")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "联系人不许为空")]
        public String Contactor { get; set; }

        [Display(Name = "联系人联系方式")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "联系人联系方式不许为空")]
        public String PhoneOfContactor { get; set; }

        [Display(Name = "是否具有生产许可")]
        public bool CanProduct { get; set; }

        [Display(Name = "生产许可编号")]
        public String ProductNO { get; set; }

        [Display(Name = "是否具有安装许可")]
        public bool CanInstall { get; set; }

        [Display(Name = "安装许可编号")]
        public String InstallNO { get; set; }

        [Display(Name = "是否具有租赁许可")]
        public bool CanLend { get; set; }

        [Display(Name = "租赁许可编号")]
        public String LendNO { get; set; }

        [Display(Name = "备注")]
        [DataType(DataType.MultilineText)]
        public String Comment { get; set; }
    }

    public class CompanyListModel : CompanyBaseModel
    {
        public int Id { get; set; }
        public String NO { get; set; }

        public static explicit operator CompanyListModel(Company model)
        {
            return new CompanyListModel()
            {
                Id = model.Id,
                NO = String.Format("{0:D5}", model.Id),
                Address = model.Address,
                CanInstall = model.CanInstall,
                CanLend = model.CanLend,
                CanProduct = model.CanProduct,
                Comment = model.Comment,
                Contactor = model.Contactor,
                InstallNO = model.InstallCertNO,
                Legal = model.Legal,
                LendNO = model.LendCertNO,
                Name = model.Name,
                PhoneOfContactor = model.ContactorPhone,
                PhoneOfLegal = model.PhoneOfLegal,
                ProductNO = model.ProductCertNO
            };
        }
    }

    public class CompanyEditModel : CompanyBaseModel
    {
        public int Id { get; set; }
        public static explicit operator Company(CompanyEditModel model)
        {
            return new Company()
            {
                Id = model.Id,
                Address = model.Address,
                CanInstall = model.CanInstall,
                CanLend = model.CanLend,
                CanProduct = model.CanProduct,
                Comment = model.Comment,
                Contactor = model.Contactor,
                InstallCertNO = model.InstallNO,
                Legal = model.Legal,
                LendCertNO = model.LendNO,
                Name = model.Name,
                ContactorPhone = model.PhoneOfContactor,
                PhoneOfLegal = model.PhoneOfLegal,
                ProductCertNO = model.ProductNO
            };
        }

        public static explicit operator CompanyEditModel(Company model)
        {
            return new CompanyEditModel()
            {
                Id = model.Id,
                Address = model.Address,
                CanInstall = model.CanInstall,
                CanLend = model.CanLend,
                CanProduct = model.CanProduct,
                Comment = model.Comment,
                Contactor = model.Contactor,
                InstallNO = model.InstallCertNO,
                Legal = model.Legal,
                LendNO = model.LendCertNO,
                Name = model.Name,
                PhoneOfContactor = model.ContactorPhone,
                PhoneOfLegal = model.PhoneOfLegal,
                ProductNO = model.ProductCertNO
            };
        }

    }
}