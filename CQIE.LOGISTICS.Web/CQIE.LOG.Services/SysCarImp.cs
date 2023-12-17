using CQIE.LOG.Models.Delivery;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace CQIE.LOG.Services
{
    public class SysCarImp : ISysCar
    {
        private readonly CQIE.LOG.DBManager.IDbManager _dbManger;
        public SysCarImp(CQIE.LOG.DBManager.IDbManager dbManger)
        {
            _dbManger = dbManger;
        }

        #region 获得所有车的信息
        public async Task<List<object>> Get_All_Car_ListAsync(int Page, int Limit, string name) 
        {
            try 
            {
                int startIndex = (Page - 1) * Limit;
                var carlist = await(from o in _dbManger.Ctx.Cars
                                    where string.IsNullOrEmpty(name) || o.CarNumber.Contains(name)
                                    select o)
                                          .OrderBy(o => o.Id)
                                          .Skip(startIndex)
                                          .Take(Limit)
                                          .ToListAsync();

                return carlist.Cast<object>().ToList();
            } 
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region 通过id获得车的信息
        public async Task<object> Get_By_Car_IdAsync(int id)
        {
            try
            {
                var car=await _dbManger.Ctx.Cars.Where(c => c.Id == id).FirstOrDefaultAsync();
                return car;
            } 
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region 修改车信息
        public async Task<string> Save_Update_CarManAsync(CQIE.LOG.Models.Delivery.Car order)
        {
            using (var transaction = _dbManger.Ctx.Database.BeginTransaction()) 
            {
                try 
                {
                    var cartype = await _dbManger.Ctx.Cars.Where(c => c.Id == order.Id).FirstOrDefaultAsync() ;
                    cartype = order;
                    _dbManger.Ctx.SaveChanges();
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

        #region 删除车信息
        public async Task<string> Save_Del_CarAsync(int id)
        {
            using (var transaction = _dbManger.Ctx.Database.BeginTransaction()) 
            {
                try 
                {
                    var car = await _dbManger.Ctx.Cars.Where(c => c.Id == id).FirstOrDefaultAsync();
                    _dbManger.Ctx.Cars.Remove(car);
                    _dbManger.Ctx.SaveChanges();
                    transaction.Commit();
                    return JsonSerializer.Serialize(new { success = true, message = "删除成功" });
                } 
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return JsonSerializer.Serialize(new { success = false, message = "修改失败" });
                }
            }
        }
        #endregion

        #region 添加车信息
        public async Task<string> Save_Add_CarManAsync(CQIE.LOG.Models.Delivery.Car order)
        {
            using (var transaction = _dbManger.Ctx.Database.BeginTransaction()) 
            {
                try 
                {
                    _dbManger.Ctx.Cars.Add(order);
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



        #region  获得多有车种类信息
        public async Task<List<object>> Get_All_CarType_ListAsync(int Page, int Limit, string name) 
        {
            try
            {
                int startIndex = (Page - 1) * Limit;
                var carTypelist = await (from o in _dbManger.Ctx.CarTypes
                                    where string.IsNullOrEmpty(name) || o.Name.Contains(name)
                                    select o)
                                          .OrderBy(o => o.Id)
                                          .Skip(startIndex)
                                          .Take(Limit)
                                          .ToListAsync();

                return carTypelist.Cast<object>().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region 通过id获得车种类的信息
        public async Task<object> Get_By_CarType_IdAsync(int id) 
        {
            try
            {
                var cartype = await _dbManger.Ctx.CarTypes.Where(c => c.Id == id).FirstOrDefaultAsync();
                return cartype;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region 修改车种类信息
        public async Task<string> Save_Update_CarTypeAsync(CQIE.LOG.Models.Delivery.CarType order) 
        {
            using (var transaction = _dbManger.Ctx.Database.BeginTransaction())
            {
                try
                {
                    var cartype = await _dbManger.Ctx.CarTypes.Where(c => c.Id == order.Id).FirstOrDefaultAsync();
                    cartype = order;
                    _dbManger.Ctx.SaveChanges();
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

        #region 删除车类型
        public async Task<string> Save_Del_CarTypeAsync(int id) 
        {
            using (var transaction = _dbManger.Ctx.Database.BeginTransaction())
            {
                try
                {
                    var cartype = await _dbManger.Ctx.CarTypes.Where(c => c.Id == id).FirstOrDefaultAsync();
                    _dbManger.Ctx.CarTypes.Remove(cartype);
                    _dbManger.Ctx.SaveChanges();
                    transaction.Commit();
                    return JsonSerializer.Serialize(new { success = true, message = "删除成功" });
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return JsonSerializer.Serialize(new { success = false, message = "修改失败" });
                }
            }
        }
        #endregion

        #region 添加车种类
        public async Task<string> Save_Add_CarTypeAsync(CQIE.LOG.Models.Delivery.CarType order)
        {
            using (var transaction = _dbManger.Ctx.Database.BeginTransaction())
            {
                try
                {
                    _dbManger.Ctx.CarTypes.Add(order);
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
    }
}
