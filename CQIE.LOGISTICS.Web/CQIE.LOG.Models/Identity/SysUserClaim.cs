using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CQIE.LOG.Models.Identity
{
    [Table("TB_SysUserClaim")]
    public class SysUserClaim : Microsoft.AspNetCore.Identity.IdentityUserClaim<int>
    {

    }
}
