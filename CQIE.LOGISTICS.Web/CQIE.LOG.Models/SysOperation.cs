using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQIE.LOG.Models
{
    /// <summary>
    /// 操作项目
    /// </summary>
    /// 
    [Table("TB_SysOperation")]
    public class SysOperation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]//不自动增长

        public int Id { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        public ICollection<SysMenuOperation> SysMenuOperations { get; set; } = new HashSet<SysMenuOperation>();

        public ICollection<SysRoleMenuOperation> SysRoleMenuOperations { get; set; } = new HashSet<SysRoleMenuOperation>();
    }
}
