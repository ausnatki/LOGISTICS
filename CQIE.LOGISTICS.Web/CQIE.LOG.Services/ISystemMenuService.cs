using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQIE.LOG.Services
{
    /// <summary>
    /// 功能菜单服务接口
    /// </summary>
    public interface ISystemMenuService
    {
        /// <summary>
        /// 获取功能菜单的内容 方法
        /// </summary>
        /// <returns></returns>
        IQueryable<CQIE.LOG.Models.SystemMenu> GetSystemMenus();

        /// <summary>
        /// 保存功能菜单 方法
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        bool SaveSystemMenu(CQIE.LOG.Models.SystemMenu menu);
    }
}
