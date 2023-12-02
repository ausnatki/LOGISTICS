using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CQIE.LOG.Models.Identity
{
    [Table("TB_SysUserToken")]
    public class SysUserToken : Microsoft.AspNetCore.Identity.IdentityUserToken<int>
    {
        public int Id { get; set; }
    }
}
