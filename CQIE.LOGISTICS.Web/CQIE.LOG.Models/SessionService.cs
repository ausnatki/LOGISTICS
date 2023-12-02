using System;
using System.Collections.Generic;
using System.Text;

namespace CQIE.LOG.Models
{
    public class SessionService
    {
        private Microsoft.AspNetCore.Http.HttpContext m_HttpContext;
        private CQIE.LOG.Models.Identity.SysUser m_User;

        public SessionService(Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor != null && httpContextAccessor.HttpContext != null)
            {
                this.m_HttpContext = httpContextAccessor.HttpContext;
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return this.m_HttpContext.User.Identity.IsAuthenticated;
            }
        }

        public CQIE.LOG.Models.Identity.SysUser GetSessionUser()
        {
            if (m_User == null && m_HttpContext.Session != null)
            {
                var buffer = new byte[0];
                if (m_HttpContext.Session.TryGetValue("SessionUser", out buffer))
                {
                    try
                    {
                        var str = System.Text.Encoding.UTF8.GetString(buffer);
                        m_User = System.Text.Json.JsonSerializer.Deserialize<CQIE.LOG.Models.Identity.SysUser>(str);
                    }
                    catch { }
                }
            }

            return m_User;
        }

        public string UserName
        {
            get
            {
                var user = this.GetSessionUser();
                if (user != null)
                {
                    return user.UserName;
                }

                return null;
            }
        }

        public int GetUserId()
        {
            var user = this.GetSessionUser();
            if (user != null)
            {
                return user.Id;
            }
            return 0;
        }
        public void Clear()
        {
            if (m_HttpContext.Session != null)
            {
                m_HttpContext.Session.Clear();
            }
        }

    }
}
