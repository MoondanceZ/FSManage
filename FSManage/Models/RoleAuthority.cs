using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSManage.Models
{
    public class RoleAuthority
    {
        public int RoleTypeId { get; set; }
        public int AuthorityId { get; set; }
    }
}
