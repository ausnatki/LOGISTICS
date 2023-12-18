using CQIE.LOG.DBManager;
using CQIE.LOG.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQIE.LOGISTICS.Web.Controllers
{

    [Authorize(Roles = "系统管理员,送货人员")]
    public class SysExpensesController : Controller
    {
        private readonly CQIE.LOG.Services.ISysExpenses _sysExpenses;
        private readonly CQIE.LOG.Services.ITool _tool;
        private readonly CQIE.LOG.DBManager.IDbManager _manager;

        public SysExpensesController(ISysExpenses sysExpenses, ITool tool, IDbManager manager)
        {
            _sysExpenses = sysExpenses;
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
                var data = await _sysExpenses.Get_All_Expenses_ListAsync(Page, Limit, A);

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

        #region 根据用户id查找用户信息
        public async Task<IActionResult> Get_By_Id(int id)
        {
            try
            {
                var data = await _sysExpenses.Get_By_IdAsync(id);

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
        public async Task<IActionResult> Edit_Init(int id)
        {
            CQIE.LOG.Models.Expenses.Expenses expenses = await _sysExpenses.Get_By_IdAsync(id);
            ViewBag.data = expenses;
            return View();
        }
        #endregion

        #region 修改功能
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            await Edit_Init(id);
            var htmlcontent = await _tool.RenderToStringAsync("Edit_Init");
            return Content(htmlcontent);
        }

        [HttpPost]
        public async Task<JsonResult> Edit(CQIE.LOG.Models.Expenses.Expenses expenses, CQIE.LOG.Models.Expenses.Cost cost)
        {
            var result = await _sysExpenses.Save_Update_ExpensesAsync(expenses,cost);

            return Json(result);
        }
        #endregion

    }
}
