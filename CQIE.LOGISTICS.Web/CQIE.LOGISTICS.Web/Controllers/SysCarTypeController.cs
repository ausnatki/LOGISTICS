using CQIE.LOG.DBManager;
using CQIE.LOG.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQIE.LOGISTICS.Web.Controllers
{
    public class SysCarTypeController : Controller
    {
        private readonly CQIE.LOG.Services.ITool _tool;
        private readonly CQIE.LOG.DBManager.IDbManager _manager;
        private readonly CQIE.LOG.Services.ISysCar _syscar;

        public SysCarTypeController(ITool tool, IDbManager manager, ISysCar syscar)
        {
            _tool = tool;
            _manager = manager;
            _syscar = syscar;
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
                var data = await _syscar.Get_All_CarType_ListAsync(Page, Limit, A);

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

        #region 修改界面的初始化
        public IActionResult Edit_Init(int id)
        {
            ViewBag.id = id;
            return View();
        }
        #endregion

        #region 根据id查询
        [HttpGet]
        public async Task<IActionResult> Get_By_Id(int id)
        {
            try
            {
                var data = await _syscar.Get_By_CarType_IdAsync(id);

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

        #region 修改功能
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Edit_Init(id);
            var htmlcontent = await _tool.RenderToStringAsync("Edit_Init");
            return Content(htmlcontent);
        }

        [HttpPost]
        public async Task<JsonResult> Edit(CQIE.LOG.Models.Delivery.CarType car)
        {
            var result = await _syscar.Save_Update_CarTypeAsync(car);

            return Json(result);
        }
        #endregion

        #region 添加功能

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var htmlcontent = await _tool.RenderToStringAsync("SysCarType/Add");
            return Content(htmlcontent);
        }

        [HttpPost]
        public async Task<JsonResult> Add([FromBody] CQIE.LOG.Models.Delivery.CarType car)
        {
            var result = await _syscar.Save_Add_CarTypeAsync(car);

            return Json(result);
        }

        #endregion

        #region 删除功能
        [HttpGet]
        public async Task<JsonResult> Del(int id)
        {
            var result = await _syscar.Save_Del_CarTypeAsync(id);
            return Json(result);
        }
        #endregion


    }
}
