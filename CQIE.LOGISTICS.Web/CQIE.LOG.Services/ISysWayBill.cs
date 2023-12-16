using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.LOG.Services
{
    /// <summary>
    /// 我的货物订单
    /// </summary>
    public interface ISysWayBill
    {
        public Task<List<object>> Get_All_WayBill_ListAsync(int Page, int Limit, string name);
        public Task<List<object>> Get_By_NameAsync(int Page, int Limit, string name);
        public Task<object> Get_By_IdAsync(int id);
        public Task<string> Save_Update_RoleAsync(CQIE.LOG.Models.Identity.SysRole role);
        public Task<string> Save_Del_RoleAsync(int id);
        public Task<string> Save_Add_WaybillAsync(CQIE.LOG.Models.Waybill.WayBill waybill,
            List<CQIE.LOG.Models.Waybill.GoodsInfo> goods,
            CQIE.LOG.Models.Tool.Carrier_Temp carrier,
            CQIE.LOG.Models.Tool.Shipper_Temp shipper);
    }
}
