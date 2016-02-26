using System;
using System.ComponentModel.DataAnnotations;

namespace FSManage.Models
{
    public class UserInfo
    {
        [Key]
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "用户名")]
        //[Required(ErrorMessage = "请输入用户名")]
        public string LoginId { get; set; }
        [Display(Name = "密码")]
        //[Required(ErrorMessage = "请输入密码")]
        public string PassWord { get; set; }
        public string Guid { get; set; }
        [Display(Name = "电话")]
        //[RegularExpression(@"^1[3|4|5|7|8][0-9]\d{4,8}$",ErrorMessage ="请输入正确的电话号码")]
        public string Telephone { get; set; }
        [Display(Name = "邮箱")]
        //[RegularExpression(@"^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(.[a-zA-Z0-9_-])+",ErrorMessage ="请输入正确的邮箱")]
        public string Email { get; set; }
        [Display(Name = "注册时间")]
        public DateTime? RegTime { get; set; }
        public int UType { get; set; }
        //public ShoppingCart ShoppingCart { get; set; }
    }
}