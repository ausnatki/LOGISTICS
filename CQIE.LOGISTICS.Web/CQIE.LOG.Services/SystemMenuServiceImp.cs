using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQIE.LOG.Services
{
    public class ISystemMenuServiceImp : ISystemMenuService
    {

        private readonly CQIE.LOG.DBManager.IDbManager m_Manager;

        public ISystemMenuServiceImp(CQIE.LOG.DBManager.IDbManager manager)
        {
            m_Manager = manager;
        }

        public IQueryable<CQIE.LOG.Models.SystemMenu> GetSystemMenus()
        {
            var query = m_Manager.Ctx.SystemMenus.Select(c => c); //这里没有注册却可以使用ctx中的systemmenu是应为我ctx的类型就是LOGDbContext
            return query;
        }

        public bool SaveSystemMenu(CQIE.LOG.Models.SystemMenu menu)
        {
            m_Manager.Ctx.SystemMenus.Add(menu);
            m_Manager.Ctx.SaveChanges();
            return true;
        }

    }
}
