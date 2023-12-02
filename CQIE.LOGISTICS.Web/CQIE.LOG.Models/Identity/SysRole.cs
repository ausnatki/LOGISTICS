using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CQIE.LOG.Models.Identity
{
    [Table("TB_SysRole")]
    public class SysRole : Microsoft.AspNetCore.Identity.IdentityRole<int>
    {
        public ICollection<SysRoleMenu> SysRoleMenus { get; set; } = new HashSet<SysRoleMenu>();

        public ICollection<SysUserRole> SysUserRoles { get; set; } = new HashSet<SysUserRole>();
    }
}
