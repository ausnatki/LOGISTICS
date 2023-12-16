using CQIE.LOG.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.LOG.Services
{
    public class SysWayBillImp : ISysWayBill
    {
        #region 获取所有货运单信息
        Task<List<object>> ISysWayBill.Get_All_WayBill_ListAsync(int Page, int Limit, string name)
        {
            try 
            {
                return null;
            } 
            catch 
            {
                return null;
            }
        }
        #endregion

        Task<object> ISysWayBill.Get_By_IdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<object>> ISysWayBill.Get_By_NameAsync(int Page, int Limit, string name)
        {
            throw new NotImplementedException();
        }

        Task<string> ISysWayBill.Save_Add_WaybillAsync(CQIE.LOG.Models.Waybill.WayBill waybill,
            List<CQIE.LOG.Models.Waybill.GoodsInfo> goods,
            CQIE.LOG.Models.Tool.Carrier_Temp carrier,
            CQIE.LOG.Models.Tool.Shipper_Temp shipper)
        {
            throw new NotImplementedException();
        }

        Task<string> ISysWayBill.Save_Del_RoleAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<string> ISysWayBill.Save_Update_RoleAsync(SysRole role)
        {
            throw new NotImplementedException();
        }
    }
}
