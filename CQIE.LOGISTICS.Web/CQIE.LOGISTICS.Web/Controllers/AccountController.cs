using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQIE.LOGISTICS.Web.Controllers
{
    public class AccountController : Controller
    {
        private Microsoft.AspNetCore.Identity.SignInManager<CQIE.LOG.Models.Identity.SysUser> m_SignInManager;
        private Microsoft.AspNetCore.Identity.UserManager<CQIE.LOG.Models.Identity.SysUser> m_UserManager;
        public IActionResult Index()
        {

            return View();
        }

        public AccountController(Microsoft.AspNetCore.Identity.SignInManager<CQIE.LOG.Models.Identity.SysUser> signInManager,
            Microsoft.AspNetCore.Identity.UserManager<CQIE.LOG.Models.Identity.SysUser> userManager)
        {
            m_SignInManager = signInManager;
            m_UserManager = userManager;
        }

        /// <summary>
        /// 登录视图
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> Login(string UserName, string LoginPassword) /*[FromForm]CQIE.LOG.Models.Identity.SysUser loginUser*/
        {
            var result = await this.m_SignInManager.PasswordSignInAsync(UserName, LoginPassword, false, true);
            if (result.Succeeded)
            {
                var user = await m_UserManager.FindByNameAsync(UserName);
                if (user != null)
                {
                    var userJson = System.Text.Json.JsonSerializer.Serialize(user);
                    this.HttpContext.Session.Set("SessionUser", System.Text.Encoding.UTF8.GetBytes(userJson));
                }
                return Json(new { success = true, message = "登录成功！" });
            }
            else if (result.IsLockedOut)
            {
                return Json(new { success = false, message = "用户被锁定" });
            }
            else if (result.IsNotAllowed)
            {
                return Json(new { success = false, message = "用户未验证" });
            }
            else
            {
                return Json(new { success = false, message = "错误的用户名或密码" });
            }
        }

        /// <summary>
        /// 退出登录状态
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public async Task<IActionResult> Logout([FromServices] CQIE.LOG.Models.SessionService session)
        {
            session.Clear();
            await m_SignInManager.SignOutAsync();
            return Redirect("~/Account/Login");
        }

    }
}
