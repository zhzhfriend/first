using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TYAJZWeb.Data;

namespace TYAJZWeb.Models
{
    public class UserLogonModel
    {
        [Display(Name = "用户名")]
        [Required(ErrorMessage = "用户名必须填写")]
        public String UserName { get; set; }

        [Display(Name = "密码")]
        [Required(ErrorMessage = "密码必须填写")]
        [DataType(DataType.Password)]
        public String PassWord { get; set; }
    }

    public class UserBaseModel
    {

    }

    public class UserListModel : UserBaseModel
    {
        public static explicit operator UserListModel(User model)
        {
            return new UserListModel()
            {
                
            };
        }
    }

    public class UserEditModel : UserBaseModel
    {
        public int Id { get; set; }

        public static explicit operator UserEditModel(User model)
        {
            return new UserEditModel()
            {

            };
        }

        public static explicit operator User(UserEditModel model)
        {
            return new User()
            {

            };
        }
    }
}