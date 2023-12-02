using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CQIE.LOG.Models.Identity
{
    [Table("TB_SysUser")]
    public class SysUser : Microsoft.AspNetCore.Identity.IdentityUser<int>
    {
        public string LoginPassword { get; set; }
        public ICollection<SysUserRole> SysUserRoles { get; set; } = new HashSet<SysUserRole>();
    }
}
