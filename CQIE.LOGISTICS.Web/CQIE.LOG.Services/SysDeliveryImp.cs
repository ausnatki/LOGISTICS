using CQIE.LOG.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CQIE.LOG.Models.Delivery;
using System.Text.Json;

namespace CQIE.LOG.Services
{
    public class SysDeliveryImp : ISysDelivery
    {
        private readonly CQIE.LOG.DBManager.IDbManager _dbManger;


        public SysDeliveryImp(CQIE.LOG.DBManager.IDbManager dbManger)
        {
            _dbManger = dbManger;
        }

        #region 获取所有送货表信息
        public async Task<List<object>> Get_All_Delivery_ListAsync(int Page, int Limit, string name)
        {
            try 
            {
                int startIndex = (Page - 1) * Limit;
                var Deliverylist = await (from o in _dbManger.Ctx.Delivery_Orders
                                          where string.IsNullOrEmpty(name) || o.WayBill.ArrivalStation.Contains(name)
                                          select new
                                          {
                                              Shipper = _dbManger.Ctx.ShipperConsigneeInfos.Where(c => c.Id == o.WayBill.ShipperID).Select(c=>c.Name).FirstOrDefault(),
                                              carrier = _dbManger.Ctx.ShipperConsigneeInfos.Where(c => c.Id == o.WayBill.ConsigneeID).Select(c => c.Name).FirstOrDefault(),
                                              Did = o.Id,
                                              DepartureStation = o.WayBill.DepartureStation,
                                              ArrTime = o.WayBill.UpTime.ToLongDateString(),//者是虚假的到站时间,
                                              Deliver_date = o.Delivery_data.ToLongDateString()
                                          })
                                          .Skip(startIndex)
                                          .Take(Limit)
                                          .ToListAsync();

                return Deliverylist.Cast<object>().ToList();
            } 
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region 通过id获取送货表信息
        public async Task<CQIE.LOG.Models.Tool.DelievryWaybillShipperVIewModel> Get_By_IdAsync(int id)
        {
            try 
            {
                var Delivery = await(from o in _dbManger.Ctx.Delivery_Orders
                                         where o.Id == id
                                         select new CQIE.LOG.Models.Tool.DelievryWaybillShipperVIewModel
                                         {
                                             delivery =o,
                                             Shipper_Temp = _dbManger.Ctx.ShipperConsigneeInfos.Where(c => c.Id == o.WayBill.ShipperID).FirstOrDefault(),
                                             Carrier_Temp = _dbManger.Ctx.ShipperConsigneeInfos.Where(c => c.Id == o.WayBill.ConsigneeID).FirstOrDefault(),
                                         })
                                         .FirstOrDefaultAsync();

                return Delivery;
            } 
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region 修改送货单信息
        public async Task<string> Save_Update_DeliveryAsync(CQIE.LOG.Models.Delivery.Delivery_Order order) 
        {
            using (var transaction = _dbManger.Ctx.Database.BeginTransaction()) 
            {
                try 
                {
                    var Doder = _dbManger.Ctx.Delivery_Orders.Where(c => c.Id == order.Id).FirstOrDefault();
                    Doder.Car_Id = order.Car_Id;
                    Doder.Delivery_man_Id = order.Delivery_man_Id;
                    Doder.Delivery_data = DateTime.Now;
                    await _dbManger.Ctx.SaveChangesAsync();
                    transaction.Commit();
                    return JsonSerializer.Serialize(new { success = true, message = "修改成功" });
                } 
                catch (Exception ex) 
                {
                    transaction.Rollback();
                    return JsonSerializer.Serialize(new { success = false, message = "修改失败" });
                }
            }
        }
        #endregion

        #region 删除送货单信息
        public async Task<string> Save_Del_DeliveryAsync(int id) 
        {
            using (var transaction = _dbManger.Ctx.Database.BeginTransaction()) 
            {
                try 
                {
                    var td =await _dbManger.Ctx.Delivery_Orders.Where(c => c.Id == id).FirstOrDefaultAsync();
                    _dbManger.Ctx.Delivery_Orders.Remove(td);
                    _dbManger.Ctx.SaveChanges();
                    transaction.Commit();
                    return JsonSerializer.Serialize(new { success = true, message = "删除成功" });
                } 
                catch (Exception ex) 
                {
                    transaction.Rollback();
                    return JsonSerializer.Serialize(new { success = false, message = "删除失败" });
                }
            }
        }
        #endregion

        #region 添加送货单信息
        public async Task<string> Save_Add_DeliveryAsync(CQIE.LOG.Models.Delivery.Delivery_Order order) 
        {
            using (var transaction = _dbManger.Ctx.Database.BeginTransaction()) 
            {
                try 
                {
                    _dbManger.Ctx.Delivery_Orders.Add(order);
                    await _dbManger.Ctx.SaveChangesAsync();
                    transaction.Commit();
                    return JsonSerializer.Serialize(new { success = true, message = "添加成功" });
                } 
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return JsonSerializer.Serialize(new { success = false, message = "添加失败" });
                }
            } 
        }

        #endregion

        #region 修改的初始化数据
        public async Task<Models.Tool.CarTypeCarWaybillShipperUserModel> Edit_Init(int id)
        {
            try 
            {
                CQIE.LOG.Models.Delivery.Delivery_Order delivery = _dbManger.Ctx.Delivery_Orders.Where(c => c.Id == id).FirstOrDefault();

                List<CQIE.LOG.Models.Delivery.Car> cars = await _dbManger.Ctx.Cars.Select(c => c).ToListAsync();

                List<CQIE.LOG.Models.Delivery.CarType> carTypes = await _dbManger.Ctx.CarTypes.Select(c => c).ToListAsync();

                CQIE.LOG.Models.Waybill.WayBill wayBills = await (from o in _dbManger.Ctx.Delivery_Orders
                                                                  join a in _dbManger.Ctx.WayBills on o.WayBill_Id equals a.Id
                                                                  where o.Id == id
                                                                  select a).FirstOrDefaultAsync();


                CQIE.LOG.Models.Waybill.ShipperConsigneeInfo Shipper = await _dbManger.Ctx.ShipperConsigneeInfos.Where(c => c.Id == wayBills.ShipperID).FirstOrDefaultAsync();
                CQIE.LOG.Models.Waybill.ShipperConsigneeInfo Carieer = await _dbManger.Ctx.ShipperConsigneeInfos.Where(c => c.Id == wayBills.ConsigneeID).FirstOrDefaultAsync();

                List<CQIE.LOG.Models.Identity.SysUser> Man = await(from o in _dbManger.Ctx.SysUsers
                                                              join a in _dbManger.Ctx.SysUserRoles on o.Id equals a.UserId
                                                              join b in _dbManger.Ctx.SysRoles on a.RoleId equals b.Id
                                                              where b.Id == 3
                                                              select o).ToListAsync();

                Models.Tool.CarTypeCarWaybillShipperUserModel result = new Models.Tool.CarTypeCarWaybillShipperUserModel()
                {
                    delivery = delivery,
                    cars = cars,
                    carTypes = carTypes,
                    Shipper = Shipper,
                    Carieer = Carieer,
                    Delivery_Man = Man,
                    wayBill = wayBills 
                };

                return result;

            } 
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

    }
}
