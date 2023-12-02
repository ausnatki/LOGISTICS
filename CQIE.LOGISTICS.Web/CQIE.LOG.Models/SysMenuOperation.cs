using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CQIE.LOG.Models
{
    [Table("TB_SysMenuOperation")]
    //这段代码是使用C#语言中的一种数据访问框架（可能是Entity Framework或类似的框架）来定义一个名为SysMenuOperation的类，
    //该类映射到数据库中的一个名为TB_SysMenuOperation的表。
    public class SysMenuOperation
    {
        public int Id { get; set; }

        /// <summary>
        /// 菜单编号
        /// </summary>
        public int MenuID { get; set; }

        /// <summary>
        /// 操作编号
        /// </summary>
        public int OperationID { get; set; }

        public SystemMenu Menu { get; set; }

        public SysOperation Operation { get; set; }


    }
}
