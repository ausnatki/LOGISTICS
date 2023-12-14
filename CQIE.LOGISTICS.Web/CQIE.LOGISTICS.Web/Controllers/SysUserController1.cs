using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQIE.LOGISTICS.Web.Controllers
{
    public class SysUserController : Controller
    {
        private readonly UserManager<CQIE.LOG.Models.Identity.SysUser> _userManager;
        private readonly CQIE.LOG.Services.IUserService _user;
        private readonly CQIE.LOG.Services.ITool _tool;
        private readonly CQIE.LOG.DBManager.IDbManager _manager;
        // 构造函数注册服务
        public SysUserController(UserManager<CQIE.LOG.Models.Identity.SysUser> userManager,
            CQIE.LOG.Services.IUserService user,
            CQIE.LOG.Services.ITool viewEngine,
            CQIE.LOG.DBManager.IDbManager m_manager)
        {
            _userManager = userManager;
            _user = user;
            _tool = viewEngine;
            _manager = m_manager;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region 获取所有用户信息
        [HttpGet]
        public async Task<IActionResult> GetAll(int Page, int Limit, string A)
        {
            try
            {
                var data = await _user.Get_All_User_ListAsync(Page, Limit, A);

                var result = new
                {
                    code = 0,
                    msg = "查询成功",
                    success = true,
                    data = data,
                    count = _manager.Ctx.SysUsers.Count()
                };
                return Json(result);
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately, e.g., log the exception
                return Json(new { code = 500, msg = "服务器错误", success = false });
            }
        }
        #endregion

        #region 根据用户名查询
        public async Task<IActionResult> Get_By_Name(int Page, int Limit, string name)
        {
            try
            {
                var list = await _user.Get_By_NameAsync(Page, Limit, name);
                int count = list.Count();
                var result = new
                {
                    code = 0,
                    msg = "查询成功",
                    success = true,
                    data = list,
                    count = count
                };
                return Json(result);
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately, e.g., log the exception
                return Json(new { code = 500, msg = "服务器错误", success = false });
            }
        }
        #endregion

        #region 根据用户id查找用户信息
        public async Task<IActionResult> Get_By_Id(int id)
        {
            try
            {
                var data = await _user.Get_By_IdAsync(id);

                var result = new
                {
                    code = 0,
                    success = true,
                    data = data,
                    msg = "查询成功"
                };
                return Json(result);
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately, e.g., log the exception
                return Json(new { code = 500, msg = "服务器错误", success = false });
            }
        }
        #endregion

        #region 修改界面的初始化
        public IActionResult Edit_Init(int id)
        {
            ViewBag.id = id;
            return View();
        }
        #endregion

        #region 修改功能
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Edit_Init(id);
            var htmlcontent = await _tool.RenderToStringAsync("Edit_Init");
            return Content(htmlcontent);
        }

        [HttpPost]
        public async Task<JsonResult> Edit([FromBody] CQIE.LOG.Models.Identity.SysUser user)
        {
            var result = await _user.Save_Update_UserAsync(user);

            return Json(result);
        }
        #endregion

        #region 添加功能

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var htmlcontent = await _tool.RenderToStringAsync("SysUser/Add");
            return Content(htmlcontent);
        }

        [HttpPost]
        public async Task<JsonResult> Add([FromBody] CQIE.LOG.Models.Identity.SysUser user)
        {
            var result = await _user.Save_Add_UserAsync(user);

            return Json(result);
        }

        #endregion

        #region 删除功能
        [HttpGet]
        public async Task<JsonResult> Del(int id)
        {
            var result = await _user.Save_Del_UserAsync(id);
            return Json(result);
        }
        #endregion
    }
}
