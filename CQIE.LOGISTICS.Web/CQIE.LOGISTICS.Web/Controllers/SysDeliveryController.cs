using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQIE.LOGISTICS.Web.Controllers
{
    public class SysDeliveryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
