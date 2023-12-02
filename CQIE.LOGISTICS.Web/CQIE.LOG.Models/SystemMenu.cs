using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CQIE.LOG.Models
{
    /// <summary>
    /// 系统功能
    /// </summary>
    [Table("TB_SystemMenu")]
    public class SystemMenu
    {
        /// <summary>
        /// 功能ID编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 上级功能的编号
        /// </summary>
        public int? ParentID { get; set; }

        /// <summary>
        /// 功能名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 功能目标地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 功能图标
        /// </summary>
        public string IconClassName { get; set; }

        /// <summary>
        /// 功能排序
        /// </summary>
        public int SortOrder { get; set; }


        /// <summary>
        /// 上级功能
        /// </summary>
        public virtual SystemMenu Parent { get; set; }

        /// <summary>
        /// 子功能项
        /// </summary>
        public virtual ICollection<SystemMenu> SubMenus { get; set; } = new HashSet<SystemMenu>();


        public ICollection<SysMenuOperation> SysMenuOperations { get; set; } = new HashSet<SysMenuOperation>();

        public ICollection<SysRoleMenu> SysRoleMenus { get; set; } = new HashSet<SysRoleMenu>();
    }
}
