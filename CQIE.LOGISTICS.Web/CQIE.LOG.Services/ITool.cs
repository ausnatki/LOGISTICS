using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.LOG.Services
{
    public interface ITool
    {
        /// <summary>
        /// 这里的是可以将我的cshtml转为html的方法
        /// </summary>
        /// <param name="viewName"></param>
        /// <returns></returns>
        Task<string> RenderToStringAsync(string viewName);
    }
}
