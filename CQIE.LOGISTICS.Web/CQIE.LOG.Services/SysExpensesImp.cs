using CQIE.LOG.Models.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CQIE.LOG.Models.Delivery;
using System.Text.Json;
using CQIE.LOG.Models;

namespace CQIE.LOG.Services
{
    public class SysExpensesImp : ISysExpenses
    {
        private readonly CQIE.LOG.DBManager.IDbManager _dbManger;
        private readonly CQIE.LOG.Models.SessionService _session;
        public SysExpensesImp(CQIE.LOG.DBManager.IDbManager dbManger, SessionService session)
        {
            _dbManger = dbManger;
            _session = session;
        }

        #region 获得所有报销单信息
        public async Task<List<object>> Get_All_Expenses_ListAsync(int Page, int Limit, string name)
        {
            try 
            {
                int Id = _session.GetUserId();

                var roleName = await (from o in _dbManger.Ctx.SysUsers
                                         join a in _dbManger.Ctx.SysUserRoles on o.Id equals a.UserId
                                         where o.Id == Id && a.RoleId == 1
                                         select new { name = o.UserName }
                                        ).FirstOrDefaultAsync();

                if (roleName != null)
                {
                    int startIndex = (Page - 1) * Limit;
                    var expenseslist = await (from o in _dbManger.Ctx.Expenses
                                              join a in _dbManger.Ctx.SysUsers on o.Delivery.Delivery_man_Id equals a.Id
                                              where string.IsNullOrEmpty(name) || o.Delivery.WayBill.ArrivalStation.Contains(name)
                                              select new
                                              {
                                                  id = o.Id,
                                                  Name = a.UserName,
                                                  Time = o.Delivery.Delivery_data.ToLongDateString(),
                                                  Back = o.Back_Car == false ? "未归还" : "归还",
                                                  Production = o.Delivery.WayBill.goodsInfos.Sum(item => item.TransportationFee) - (o.Cost.Charge + o.Cost.Cheer + o.Cost.Maintain + o.Cost.Other)
                                              }).Skip(startIndex)
                                          .Take(Limit)
                                          .ToListAsync();
                    return expenseslist.Cast<object>().ToList();
                }
                else {
                    int startIndex = (Page - 1) * Limit;
                    var expenseslist = await (from o in _dbManger.Ctx.Expenses
                                              join a in _dbManger.Ctx.SysUsers on o.Delivery.Delivery_man_Id equals a.Id
                                              where a.Id==Id && string.IsNullOrEmpty(name) || o.Delivery.WayBill.ArrivalStation.Contains(name)
                                              select new
                                              {
                                                  id = o.Id,
                                                  Name = a.UserName,
                                                  Time = o.Delivery.Delivery_data.ToLongDateString(),
                                                  Back = o.Back_Car == false ? "未归还" : "归还",
                                                  Production = o.Delivery.WayBill.goodsInfos.Sum(item => item.TransportationFee) - (o.Cost.Charge + o.Cost.Cheer + o.Cost.Maintain + o.Cost.Other)
                                              }).Skip(startIndex)
                                          .Take(Limit)
                                          .ToListAsync();
                    return expenseslist.Cast<object>().ToList();
                }
            } 
            catch(Exception ex)
            {
                return null;
            }
        }


        #endregion

        #region 通过id查找
        public async Task<CQIE.LOG.Models.Expenses.Expenses> Get_By_IdAsync(int id)
        {
            try 
            {
                CQIE.LOG.Models.Expenses.Expenses expenses = await (from o in _dbManger.Ctx.Expenses
                                                                    join a in _dbManger.Ctx.Delivery_Orders on o.Delivery_Id equals a.Id
                                                                    join b in _dbManger.Ctx.Costs on o.Cost_Id equals b.Id
                                                                    where o.Id == id
                                                                    select new CQIE.LOG.Models.Expenses.Expenses
                                                                    {
                                                                        Id = o.Id,
                                                                        Back_Car = o.Back_Car,
                                                                        Cost = b,
                                                                        Cost_Id = b.Id,
                                                                        Delivery = a,
                                                                        Delivery_Id = a.Id,
                                                                    }).FirstOrDefaultAsync();

                return expenses;
            } 
            catch (Exception ex) 
            {
                return null;
            }
        }
        #endregion

        #region 修改模块
        public async Task<string> Save_Update_ExpensesAsync(CQIE.LOG.Models.Expenses.Expenses expenses, CQIE.LOG.Models.Expenses.Cost cost)
        {
            using (var transaction = _dbManger.Ctx.Database.BeginTransaction())
            {
                try
                {
                    var t = _dbManger.Ctx.Expenses.Where(c => c.Id == expenses.Id).FirstOrDefault();

                    var tt = (from o in _dbManger.Ctx.Expenses
                             join a in _dbManger.Ctx.Costs on o.Cost_Id equals a.Id
                             where o.Id == t.Id
                             select a).FirstOrDefault();


                    t.Cost = tt;

                    t.Back_Car = expenses.Back_Car;
                    t.Cost.Charge = cost.Charge;
                    t.Cost.Cheer = cost.Cheer;
                    t.Cost.Maintain = cost.Maintain;
                    t.Cost.Other = cost.Other;
                    t.Cost.Explain = cost.Explain;

                    await _dbManger.Ctx.SaveChangesAsync();
                    transaction.Commit();
                    return JsonSerializer.Serialize(new { success = true, message = "创建成功。" });

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return JsonSerializer.Serialize(new { success = false, message = "失败" });
                }

            }
        }
        #endregion
    }
}
