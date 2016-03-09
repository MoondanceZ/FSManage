using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSManage.Models
{
    public class AdminRole
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }
    }
}
