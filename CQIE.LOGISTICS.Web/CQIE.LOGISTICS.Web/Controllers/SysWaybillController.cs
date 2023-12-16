using CQIE.LOG.DBManager;
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

        [HttpGet]
        public IActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public JsonResult Add(CQIE.LOG.Models.Waybill.WayBill waybill,
            List<CQIE.LOG.Models.Waybill.GoodsInfo> goods,
            CQIE.LOG.Models.Tool.Carrier_Temp carrier,
            CQIE.LOG.Models.Tool.Shipper_Temp shipper) 
        {

            var result=_sysWaybill.Save_Add_WaybillAsync(waybill, goods, carrier, shipper);

            return Json(result);
        }


    }
}
