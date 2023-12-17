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
                                          where string.IsNullOrEmpty(name) || o.Delivery_Man.Name.Contains(name)
                                          select new
                                          {
                                              Shipper = _dbManger.Ctx.ShipperConsigneeInfos.Where(c => c.Id == o.WayBill.ShipperID).Select(c=>c.Name).FirstOrDefault(),
                                              carrier = _dbManger.Ctx.ShipperConsigneeInfos.Where(c => c.Id == o.WayBill.ConsigneeID).Select(c => c.Name).FirstOrDefault(),
                                              Did = o.Id,
                                              DepartureStation = o.WayBill.DepartureStation,
                                              ArrTime = o.WayBill.UpTime
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
                    Doder = order;
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


        #region 送货人相关接口
        #region 获取所有送货人员信息
        public async Task<List<object>> Get_All_DeliveryMan_ListAsync(int Page, int Limit, string name)
        {
            try
            {
                int startIndex = (Page - 1) * Limit;
                var Manlist = await (from o in _dbManger.Ctx.Delivery_Men
                                     where string.IsNullOrEmpty(name) || o.Name.Contains(name)
                                     select o)
                                          .OrderBy(o => o.Id)
                                          .Skip(startIndex)
                                          .Take(Limit)
                                          .ToListAsync();

                return Manlist.Cast<object>().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region 通过id获取送货人员信息
        public async Task<object> Get_By_DeliveryMan_IdAsync(int id)
        {
            try
            {
                var man = await _dbManger.Ctx.Delivery_Men.Where(c => c.Id == id).FirstOrDefaultAsync();
                return man;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region 送货人修改功能 -- 一定要传id
        public async Task<string> Save_Update_DeliveryManAsync(CQIE.LOG.Models.Delivery.Delivery_Man order)
        {
            using (var transaction = _dbManger.Ctx.Database.BeginTransaction())
            {
                try
                {
                    var tm = await _dbManger.Ctx.Delivery_Men.Where(c => c.Id == order.Id).FirstOrDefaultAsync();
                    tm = order;
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

        #region 送货人删除模块
        public async Task<string> Save_Del_DeliveryManAsync(int id)
        {
            using (var transaction = _dbManger.Ctx.Database.BeginTransaction())
            {
                try
                {
                    var tm = await _dbManger.Ctx.Delivery_Men.Where(c => c.Id == id).FirstOrDefaultAsync();
                    _dbManger.Ctx.Remove(tm);
                    await _dbManger.Ctx.SaveChangesAsync();
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

        #region 送货人添加模块
        public async Task<string> Save_Add_DeliveryManAsync(CQIE.LOG.Models.Delivery.Delivery_Man order)
        {
            using (var transaction = _dbManger.Ctx.Database.BeginTransaction())
            {
                try
                {
                    _dbManger.Ctx.Delivery_Men.Add(order);
                    await _dbManger.Ctx.SaveChangesAsync();
                    transaction.Commit();
                    return JsonSerializer.Serialize(new { success = true, message = "添加成功" });
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return JsonSerializer.Serialize(new { success = false, message = "修改失败" });
                }
            }
        }
        #endregion
        #endregion

    }
}
