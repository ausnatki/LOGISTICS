using System;
using System.Collections.Generic;
using System.Text;

namespace CQIE.LOG.Utility
{
    public class ConfigService
    {
        private Microsoft.Extensions.Configuration.IConfiguration m_Configuration;

        public ConfigService(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            m_Configuration = configuration;
        }
        /// <summary>
        /// 读取配置文件中的连接字符串
        /// </summary>
        /// <returns></returns>
        public string GetConnectionString()
        {
            return m_Configuration["ConnectionStrings:LMSDB"];
        }
    }
}
