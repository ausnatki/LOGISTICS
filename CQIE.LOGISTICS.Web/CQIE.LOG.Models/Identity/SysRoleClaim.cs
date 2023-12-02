using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CQIE.LOG.Models.Identity
{
    [Table("TB_SysRoleClaim")]
    public class SysRoleClaim : Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>
    {
    }
}
