using CQIE.LOG.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
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
        private readonly CQIE.LOG.DBManager.IDbManager _dbManger;
        public SysWayBillImp(CQIE.LOG.DBManager.IDbManager dbManger)
        {
            _dbManger = dbManger;
        }
        Task<object> ISysWayBill.Get_By_IdAsync(int id)
        {
            return null;
        }

        Task<List<object>> ISysWayBill.Get_By_NameAsync(int Page, int Limit, string name)
        {
            return null;
        }

        async Task<string> ISysWayBill.Save_Add_WaybillAsync(CQIE.LOG.Models.Waybill.WayBill waybill,
            List<CQIE.LOG.Models.Waybill.GoodsInfo> goods,
            CQIE.LOG.Models.Tool.Carrier_Temp carrier,
            CQIE.LOG.Models.Tool.Shipper_Temp shipper)
        {

            using (var transaction = _dbManger.Ctx.Database.BeginTransaction())
            {
                try
                {
                    //先添加两个人
                    CQIE.LOG.Models.Waybill.ShipperConsigneeInfo p1 = new Models.Waybill.ShipperConsigneeInfo()
                    {
                        Name = carrier.Carrier_Name,
                        Phone = carrier.Carrier_Phone,
                        Address = carrier.Carrier_Address,
                        PostalCode = carrier.Carrier_PostalCode,
                        Email = carrier.Carrier_Email
                    };
                    _dbManger.Ctx.ShipperConsigneeInfos.Add(p1);
                    CQIE.LOG.Models.Waybill.ShipperConsigneeInfo p2 = new Models.Waybill.ShipperConsigneeInfo()
                    {
                        Name = shipper.Shipper_Name,
                        Phone = shipper.Shipper_Phone,
                        Address = shipper.Shipper_Address,
                        PostalCode = shipper.Shipper_PostalCode,
                        Email = shipper.Shipper_Email
                    };
                    _dbManger.Ctx.ShipperConsigneeInfos.Add(p2);

                    //新用法
                    _dbManger.Ctx.SaveChanges();
                    int P1_id = p1.Id;
                    int P2_id = p2.Id;
                    //添加货运单

                    waybill.ShipperID = P2_id;
                    waybill.ConsigneeID = P1_id;
                    waybill.UpTime = DateTime.Now;
                    waybill.EditTime = DateTime.Now;


                    var tw = waybill;
                    _dbManger.Ctx.WayBills.Add(tw);
                    _dbManger.Ctx.SaveChanges();

                    int WID = tw.Id;
                    //再添加货物
                    foreach (var temp in goods)
                    {
                        temp.OrderID = WID;
                        _dbManger.Ctx.GoodsInfos.Add(temp);
                    }

                    await _dbManger.Ctx.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return JsonSerializer.Serialize(new { success = true, message = "角色创建成功。" });
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return JsonSerializer.Serialize(new { success = false, message = $"错误{ex}" });
                }
            }
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
