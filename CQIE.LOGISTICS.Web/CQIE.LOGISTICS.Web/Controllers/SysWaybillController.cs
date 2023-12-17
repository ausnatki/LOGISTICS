using CQIE.LOG.DBManager;
using CQIE.LOG.Models.Tool;
using CQIE.LOG.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQIE.LOGISTICS.Web.Controllers
{
    public class SysWaybillController : Controller
    {
        private readonly CQIE.LOG.Services.ISysWayBill _sysWaybill;
        private readonly CQIE.LOG.Services.ITool _tool;
        private readonly CQIE.LOG.DBManager.IDbManager _manager;
        /// <summary>
        /// 构造函数传递上下文
        /// </summary>
        /// <param name="sysWaybill"></param>
        /// <param name="tool"></param>
        /// <param name="manager"></param>
        public SysWaybillController(ISysWayBill sysWaybill, ITool tool, IDbManager manager)
        {
            _sysWaybill = sysWaybill;
            _tool = tool;
            _manager = manager;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region 添加模块
        [HttpGet]
        public IActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Add(CQIE.LOG.Models.Waybill.WayBill waybill,
            List<CQIE.LOG.Models.Waybill.GoodsInfo> goods,
            CQIE.LOG.Models.Tool.Carrier_Temp carrier,
            CQIE.LOG.Models.Tool.Shipper_Temp shipper) 
        {

           var result = await _sysWaybill.Save_Add_WaybillAsync(waybill, goods, carrier, shipper);

            return Json(result);
        }
        #endregion

        #region 获取用户信息
        [HttpGet]
        public async Task<IActionResult> GetAll(int Page, int Limit, string A)
        {
            try
            {
                var data = await _sysWaybill.Get_All_WayBill_ListAsync(Page, Limit, A);

                var result = new
                {
                    code = 0,
                    msg = "查询成功",
                    success = true,
                    data = data,
                    count = _manager.Ctx.WayBills.Count()
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
            WayBillDetailsViewModel t =await _sysWaybill.Get_By_IdAsync(id);

            ViewBag.data = t;
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
        public async Task<JsonResult> Edit(CQIE.LOG.Models.Waybill.WayBill waybill,
            List<CQIE.LOG.Models.Waybill.GoodsInfo> goods,
            CQIE.LOG.Models.Tool.Carrier_Temp carrier,
            CQIE.LOG.Models.Tool.Shipper_Temp shipper,
            int WId)
        {
            waybill.Id = WId;

            var result = await _sysWaybill.Save_Update_WaybillAsync(waybill,goods,carrier,shipper);

            return Json(result);
        }
        #endregion

        #region 根据用户id查找用户信息
        public async Task<IActionResult> Get_By_Id(int id)
        {
            try
            {
                var data = await _sysWaybill.Get_By_IdAsync(id);

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

        #region 删除功能
        [HttpPost]
        public async Task<JsonResult> Del(int id) 
        {
            var result =await _sysWaybill.Save_Del_WaybillAsync(id);
            return Json(result);
        }
        #endregion
    }
}
