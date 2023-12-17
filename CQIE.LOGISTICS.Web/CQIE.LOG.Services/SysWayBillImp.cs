using CQIE.LOG.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data;
using CQIE.LOG.Models.Tool;

namespace CQIE.LOG.Services
{
    public class SysWayBillImp : ISysWayBill
    {
        private readonly CQIE.LOG.DBManager.IDbManager _dbManger;
        public SysWayBillImp(CQIE.LOG.DBManager.IDbManager dbManger)
        {
            _dbManger = dbManger;
        }

        #region 获取所有货运单信息
        public async Task<List<object>> Get_All_WayBill_ListAsync(int Page, int Limit, string name)
        {
            try
            {
                int startIndex = (Page - 1) * Limit;
                //通过用户id查询出他的角色，然后通过角色查询出他的权限和角色
                //我要查出他的名字，id，电话，
                var listWaybill = await (from o in _dbManger.Ctx.WayBills
                                         where string.IsNullOrEmpty(name) || o.ArrivalStation.ToString().Contains(name)
                                         select new
                                         {
                                             WID = o.Id,
                                             DepartureStation = o.DepartureStation,
                                             ArrivalStation = o.ArrivalStation,
                                             UpTime = o.UpTime.ToShortDateString(),
                                             EditTime=o.EditTime.ToShortDateString()
                                         })
                                        .Skip(startIndex)
                                        .Take(Limit)
                                        .ToListAsync();

                return listWaybill.Cast<object>().ToList();
            }
            catch (Exception ex)
            {
                //这里要添加日志信息记录错误信息
                return null;
            }
        }

        #endregion

        #region 通过货运单id获得信息
        public async Task<WayBillDetailsViewModel> Get_By_IdAsync(int id)
        {
            try
            {
                var waybillDetails = await (
                    from o in _dbManger.Ctx.WayBills
                    where o.Id == id
                    select new WayBillDetailsViewModel
                    {
                        WayBill = o,
                        GoodsInfo = o.goodsInfos.ToList(),
                        Shipper = (
                            from s in _dbManger.Ctx.ShipperConsigneeInfos
                            where s.Id == o.ShipperID
                            select new Shipper_Temp
                            {
                                Shipper_Name = s.Name,
                                Shipper_Phone = s.Phone,
                                Shipper_Address = s.Address,
                                Shipper_PostalCode = s.PostalCode,
                                Shipper_Email = s.Email
                            }
                        ).FirstOrDefault(),
                        Carrier = (
                            from c in _dbManger.Ctx.ShipperConsigneeInfos
                            where c.Id == o.ConsigneeID
                            select new Carrier_Temp
                            {
                                Carrier_Name = c.Name,
                                Carrier_Phone = c.Phone,
                                Carrier_Address = c.Address,
                                Carrier_PostalCode = c.PostalCode,
                                Carrier_Email = c.Email
                            }
                        ).FirstOrDefault()
                    }
                ).FirstOrDefaultAsync();


                return waybillDetails;
            }
            catch
            {
                // 处理异常
                return null;
            }
        }

        #endregion

        #region 添加模块
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
                        if(temp.GoodsName!=null)
                        _dbManger.Ctx.GoodsInfos.Add(temp);
                    }

                    //再添加调度单和报销单
                    var d1 = new CQIE.LOG.Models.Delivery.Delivery_Order()
                    {
                        WayBill = waybill
                    };
                    _dbManger.Ctx.Delivery_Orders.Add(d1);

                    var e1 = new CQIE.LOG.Models.Expenses.Expenses()
                    {
                        Delivery = d1
                    };
                    _dbManger.Ctx.Expenses.Add(e1);

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
        #endregion

        #region 删除模块
        async Task<string> ISysWayBill.Save_Del_WaybillAsync(int id)
        {
            using (var transaction = _dbManger.Ctx.Database.BeginTransaction()) 
            {
                try 
                {
                    //这里没有删除发货人收货人信息。。。纯懒
                    var tw = _dbManger.Ctx.WayBills.Where(c => c.Id == id).FirstOrDefault();
                    _dbManger.Ctx.WayBills.Remove(tw);
                    await _dbManger.Ctx.SaveChangesAsync();
                    transaction.Commit();
                    return JsonSerializer.Serialize(new { success = true, message = "修改成功" });
                } 
                catch(Exception ex)
                {
                    transaction.Rollback();
                    return JsonSerializer.Serialize(new { success = false, message = $"{ex}。" });
                }
            }
        }
        #endregion

        #region 修改模块
        public async Task<string> Save_Update_WaybillAsync(CQIE.LOG.Models.Waybill.WayBill waybill,
            List<CQIE.LOG.Models.Waybill.GoodsInfo> goods,
            CQIE.LOG.Models.Tool.Carrier_Temp carrier,
            CQIE.LOG.Models.Tool.Shipper_Temp shipper)
        {
            using (var transaction = _dbManger.Ctx.Database.BeginTransaction()) 
            {
                try 
                {
                    //找到我的waybill表
                    var twaybill = _dbManger.Ctx.WayBills.Where(c => c.Id == waybill.Id).FirstOrDefault();
                    //找到我的goods表
                    var tgoods = _dbManger.Ctx.GoodsInfos.Where(c => c.OrderID == waybill.Id);
                    //找到我的收货人信息
                    var tcarrier =await _dbManger.Ctx.ShipperConsigneeInfos.Where(c => c.Id == twaybill.ConsigneeID).FirstOrDefaultAsync();
                    //找到我的托人人信息
                    var tshipper =await _dbManger.Ctx.ShipperConsigneeInfos.Where(c => c.Id == twaybill.ShipperID).FirstOrDefaultAsync();

                    //执行修改流程
                    twaybill = waybill;

                    twaybill.EditTime = DateTime.Now;
                    
                    //关于商品的操作初步做法为先删除在执行添加来实行

                    _dbManger.Ctx.GoodsInfos.RemoveRange(tgoods);
                    _dbManger.Ctx.SaveChanges();
                    foreach (var t in goods) 
                    {
                        t.OrderID = twaybill.Id;
                    }
                    await _dbManger.Ctx.GoodsInfos.AddRangeAsync(goods);

                    //关于人员方面

                    tcarrier.Name = carrier.Carrier_Name;
                    tcarrier.Phone = carrier.Carrier_Phone;
                    tcarrier.Address = carrier.Carrier_Address;
                    tcarrier.PostalCode = carrier.Carrier_PostalCode;
                    tcarrier.Email = carrier.Carrier_Email;

                    tshipper.Name = shipper.Shipper_Name;
                    tshipper.Phone = shipper.Shipper_Phone;
                    tshipper.Address = shipper.Shipper_Address;
                    tshipper.PostalCode = shipper.Shipper_PostalCode;
                    tshipper.Email = shipper.Shipper_Email;

                    //保存
                    await _dbManger.Ctx.SaveChangesAsync();

                    transaction.Commit();
                    return JsonSerializer.Serialize(new { success = true, message = "修改成功" });
                } 
                catch(Exception ex)
                {
                    transaction.Rollback();
                    return JsonSerializer.Serialize(new { success = false, message = $"{ex}。" });
                }
            }
        }
        #endregion
    }
}
