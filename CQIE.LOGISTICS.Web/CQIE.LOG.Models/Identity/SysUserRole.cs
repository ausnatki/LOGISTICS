using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CQIE.LOG.Models.Identity
{
    [Table("TB_SysUserRole")]
    public class SysUserRole : Microsoft.AspNetCore.Identity.IdentityUserRole<int>
    {
        public int Id { get; set; }
        public SysRole Role { get; set; }

        public SysUser User { get; set; }
    }
}
