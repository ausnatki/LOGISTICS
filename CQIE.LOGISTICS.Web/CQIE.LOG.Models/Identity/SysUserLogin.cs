using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CQIE.LOG.Models.Identity
{
    [Table("TB_SysUserLogin")]
    public class SysUserLogin : Microsoft.AspNetCore.Identity.IdentityUserLogin<int>
    {
        public int Id { get; set; }
    }
}
