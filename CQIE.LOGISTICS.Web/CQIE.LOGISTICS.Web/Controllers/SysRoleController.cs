using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQIE.LOGISTICS.Web.Controllers
{
    public class SysRoleController : Controller
    {
        private readonly CQIE.LOG.Services.IRoleService _role;
        private readonly CQIE.LOG.Services.ITool _tool;
        private readonly CQIE.LOG.DBManager.IDbManager _manager;

        public SysRoleController(CQIE.LOG.Services.IRoleService role, CQIE.LOG.Services.ITool tool, CQIE.LOG.DBManager.IDbManager manager)
        {
            _role = role;
            _tool = tool;
            _manager = manager;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region 获取全部数据
        [HttpGet]
        public async Task<IActionResult> GetAll(int Page, int Limit, string A)
        {
            try
            {
                var data = await _role.Get_All_Role_ListAsync(Page, Limit, A);

                var result = new
                {
                    code = 0,
                    msg = "查询成功",
                    success = true,
                    data = data,
                    count = _manager.Ctx.SysRoles.Count()
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
                var list = await _role.Get_By_NameAsync(Page, Limit, name);
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
                var data = await _role.Get_By_IdAsync(id);

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
        public async Task<JsonResult> Edit([FromBody] CQIE.LOG.Models.Identity.SysRole role)
        {
            var result = await _role.Save_Update_RoleAsync(role);

            return Json(result);
        }
        #endregion

        #region 添加功能

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var htmlcontent = await _tool.RenderToStringAsync("SysRole/Add");
            return Content(htmlcontent);
        }

        [HttpPost]
        public async Task<JsonResult> Add([FromBody] CQIE.LOG.Models.Identity.SysRole role)
        {
            var result = await _role.Save_Add_RoleAsync(role);

            return Json(result);
        }

        #endregion

        #region 删除功能
        [HttpGet]
        public async Task<JsonResult> Del(int id)
        {
            var result = await _role.Save_Del_RoleAsync(id);
            return Json(result);
        }
        #endregion

        #region 用户角色赋予组件模块初始化
        [HttpGet]

        public async Task<JsonResult> Role_Manage_Init(int id)
        {
            var result = await _role.Get_Role_Manage_InitAsync(id);
            return Json(result);
        }
        #endregion

        #region 用户角色修改

        [HttpPost]
        public async Task<JsonResult> Edit_Role_Manage(List<CQIE.LOG.Models.Tool.Role_Manage> list, int Rid)
        {
            var result = await _role.Save_Role_Manage_EditAsync(list, Rid);

            return Json(result);
        }
        #endregion

        [HttpGet]
        public async Task<JsonResult> Role_Operation_Init(int id)
        {
            var result = await _role.Get_Role_Operation_InitAsync(id);
            return Json(result);
        }


        [HttpPost]
        public async Task<JsonResult> Edit_Operation_Manage(List<CQIE.LOG.Models.Tool.Role_Manage> list, int Rid)
        {
            var result = await _role.Save_Role_Operation_EditAsync(list, Rid);
            return Json(result);
        }

    }
}
