using CQIE.LOG.DBManager;
using CQIE.LOG.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQIE.LOGISTICS.Web.Controllers
{
    public class SysDeliveryController : Controller
    {

        private readonly CQIE.LOG.Services.ITool _tool;
        private readonly CQIE.LOG.DBManager.IDbManager _manager;
        private readonly CQIE.LOG.Services.ISysDelivery _sysDelivery;

        public SysDeliveryController(ITool tool, IDbManager manager, ISysDelivery sysDelivery)
        {
            _tool = tool;
            _manager = manager;
            _sysDelivery = sysDelivery;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region 获取所有送货表信息
        [HttpGet]
        public async Task<IActionResult> GetAll(int Page, int Limit, string A)
        {
            try
            {
                var data = await _sysDelivery.Get_All_Delivery_ListAsync(Page, Limit, A);

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

        #region 根据用户id查找用户信息
        public async Task<IActionResult> Get_By_Id(int id)
        {
            try
            {
                var data = await _sysDelivery.Get_By_IdAsync(id);

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
        public async Task<JsonResult> Edit([FromBody] CQIE.LOG.Models.Delivery.Delivery_Order order)
        {
            var result = await _sysDelivery.Save_Update_DeliveryAsync(order);

            return Json(result);
        }
        #endregion

        #region 添加功能

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var htmlcontent = await _tool.RenderToStringAsync("Delivery/Add");
            return Content(htmlcontent);
        }

        [HttpPost]
        public async Task<JsonResult> Add([FromBody] CQIE.LOG.Models.Delivery.Delivery_Order order)
        {
            var result = await _sysDelivery.Save_Add_DeliveryAsync(order);

            return Json(result);
        }

        #endregion

        #region 删除功能
        [HttpGet]
        public async Task<JsonResult> Del(int id)
        {
            var result = await _sysDelivery.Save_Del_DeliveryAsync(id);
            return Json(result);
        }
        #endregion

    }
}
