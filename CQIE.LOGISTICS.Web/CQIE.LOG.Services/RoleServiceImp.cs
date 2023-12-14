using CQIE.LOG.Models.Identity;
using CQIE.LOG.Models.Tool;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CQIE.LOG.Services
{
    public class RoleServiceImp : IRoleService
    {
        private readonly CQIE.LOG.DBManager.IDbManager _dbManger;

        public RoleServiceImp(CQIE.LOG.DBManager.IDbManager dbManager)
        {
            _dbManger = dbManager;
        }

        #region 获得所有的角色信息
        public async Task<List<object>> Get_All_Role_ListAsync(int Page, int Limit, string name)
        {
            try
            {
                int startIndex = (Page - 1) * Limit;
                var Listrole = await (from o in _dbManger.Ctx.SysRoles
                                      where string.IsNullOrEmpty(name) || o.Name.Contains(name)
                                      select o)
                                      .OrderBy(o => o.Id)
                                      .Skip(startIndex)
                                      .Take(Limit)
                                      .ToListAsync();

                return Listrole.Cast<object>().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region 通过id获取相应角色信息
        public async Task<object> Get_By_IdAsync(int id)
        {
            try
            {
                var role = await _dbManger.Ctx.SysRoles.Where(c => c.Id == id).FirstOrDefaultAsync();
                return role;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region 通过角色名字查询相应信息
        public async Task<List<object>> Get_By_NameAsync(int Page, int Limit, string name)
        {
            try
            {
                int startIndex = (Page - 1) * Limit;
                //通过用户id查询出他的角色，然后通过角色查询出他的权限和角色
                //我要查出他的名字，id，电话，
                var Listrole = await (from o in _dbManger.Ctx.SysRoles
                                      where string.IsNullOrEmpty(name) || o.Name.Contains(name)
                                      select o)
                                     .OrderBy(o => o.Id)
                                     .Skip(startIndex)
                                     .Take(Limit)
                                     .ToListAsync();

                return Listrole.Cast<object>().ToList();
            }
            catch (Exception ex)
            {
                //这里要添加日志信息记录错误信息
                return null;
            }
        }
        #endregion

        #region 角色添加
        public async Task<string> Save_Add_RoleAsync(CQIE.LOG.Models.Identity.SysRole role)
        {
            using (var transaction = _dbManger.Ctx.Database.BeginTransaction())
            {
                try
                {
                    // 判断是否有相同的规范化用户名
                    CQIE.LOG.Models.Identity.SysRole trole = await _dbManger.Ctx.SysRoles
                        .Where(c => c.Name == role.Name)
                        .FirstOrDefaultAsync();

                    if (trole != null)
                    {
                        await transaction.RollbackAsync();
                        return JsonSerializer.Serialize(new { success = false, message = "相同角色名的用户已存在。" });
                    }
                    role.NormalizedName = role.Name.ToUpper();
                    _dbManger.Ctx.SysRoles.Add(role);
                    // 记录成功操作
                    await _dbManger.Ctx.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return JsonSerializer.Serialize(new { success = true, message = "角色创建成功。" });
                }
                catch (Exception ex)
                {
                    // 处理发生异常的情况
                    await transaction.RollbackAsync();
                    return JsonSerializer.Serialize(new { success = false, message = "处理请求时发生错误。" });
                }
            }
        }

        #endregion

        #region 角色删除
        public async Task<string> Save_Del_RoleAsync(int id)
        {
            using (var transaction = _dbManger.Ctx.Database.BeginTransaction())
            {
                try
                {
                    var role = await _dbManger.Ctx.SysRoles.Where(c => c.Id == id).FirstOrDefaultAsync();
                    _dbManger.Ctx.Remove(role);
                    await _dbManger.Ctx.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return JsonSerializer.Serialize(new { success = true, message = "删除成功" });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return JsonSerializer.Serialize(new { success = false, message = "删除失败" + ex });
                }
            }
        }
        #endregion

        #region 修改操作
        public async Task<string> Save_Update_RoleAsync(SysRole role)
        {
            using (var transaction = _dbManger.Ctx.Database.BeginTransaction())
            {
                try
                {
                    var tr = await _dbManger.Ctx.SysRoles.Where(c => c.Id == role.Id).FirstOrDefaultAsync();
                    tr.Name = role.Name;
                    tr.NormalizedName = role.Name;
                    await _dbManger.Ctx.SaveChangesAsync();
                    transaction.Commit();
                    return JsonSerializer.Serialize(new { success = true, message = "修改成功" });
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return JsonSerializer.Serialize(new { success = false, message = "修改失败" + ex });
                }
            }
        }
        #endregion

        #region 角色赋予的初始信息
        public async Task<string> Get_Role_Manage_InitAsync(int id)
        {
            try
            {
                var userwithRole = await (from o in _dbManger.Ctx.SysUsers
                                          join a in _dbManger.Ctx.SysUserRoles on o.Id equals a.UserId
                                          where a.RoleId == id
                                          select new
                                          {
                                              value = o.Id,
                                          }).ToListAsync();

                var data = await (from o in _dbManger.Ctx.SysUsers
                                  select new
                                  {
                                      value = o.Id,
                                      title = o.UserName,
                                      disabled = false,
                                      @checked = false
                                  }).ToListAsync();


                return JsonSerializer.Serialize(new { success = true, left = data, right = userwithRole, message = "初始化成功" });
            }
            catch (Exception ex)
            {
                return JsonSerializer.Serialize(new { success = false, message = $"初始化错误+{ex}" });
            }

        }
        #endregion

        #region 角色赋予修改功能
        public async Task<string> Save_Role_Manage_EditAsync(List<CQIE.LOG.Models.Tool.Role_Manage> list, int rid)
        {
            using (var transaction = _dbManger.Ctx.Database.BeginTransaction())
            {
                try
                {
                    //先找到所有roleid为我传过来的id然后将他们全部删除再加
                    var roles = _dbManger.Ctx.SysUserRoles.Where(c => c.RoleId == rid);
                    _dbManger.Ctx.SysUserRoles.RemoveRange(roles);

                    //List<CQIE.LOG.Models.Identity.SysUserRole> userRoles = new List<SysUserRole>();

                    //遍历所有的list然后将他们一个个的添加到表中
                    foreach (var userole in list)
                    {
                        CQIE.LOG.Models.Identity.SysUserRole temp = new SysUserRole
                        {
                            UserId = userole.value,
                            RoleId = rid
                        };
                        await _dbManger.Ctx.SysUserRoles.AddAsync(temp);
                    }
                    await _dbManger.Ctx.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return JsonSerializer.Serialize(new { success = true, message = "修改成功" });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return JsonSerializer.Serialize(new { success = false, message = $"修改失败{ex}" });
                }
            }
        }
        #endregion

        #region 角色权限初始化
        public async Task<string> Get_Role_Operation_InitAsync(int id)
        {
            try
            {

                //找出全部信息 功能信息 - 权限名称 - 是否checked
                //1.先找出全部的和这个角色有关联的菜单
                //2.然后找出所有的角色菜单中间表
                //3.通过foreach遍历如果我的角色菜单中间表中有这个数据的话就把他存在另一个数组中

                List<CQIE.LOG.Models.Tool.Role_Manage> Left_result = new List<Models.Tool.Role_Manage>();

                List<int> resultarr = new List<int>();

                var RoleMenulist = await (from o in _dbManger.Ctx.SystemMenus
                                          join a in _dbManger.Ctx.SysRoleMenus on o.Id equals a.MenuId
                                          join b in _dbManger.Ctx.sysRoleMenuOperations on a.Id equals b.SysRoleMenuID
                                          join c in _dbManger.Ctx.SysOperations on b.OperationID equals c.Id
                                          where a.RoleId == id
                                          select new
                                          {
                                              Name = o.Name,
                                              MenuId = o.Id,
                                              OperationId = b.OperationID,
                                              OperationName = c.Name
                                          }).ToListAsync();//现在把我的这个角色的菜单找出来了


                //找所有Operation信息
                var Operationlist = await (from o in _dbManger.Ctx.SysOperations
                                           select new
                                           {
                                               Id = o.Id,
                                               Name = o.Name
                                           }).ToListAsync();

                //1.先找出全部的和这个角色有关联的菜单
                //2.然后找出所有的角色菜单中间表
                //3.通过foreach遍历如果我的角色菜单中间表中有这个数据的话就把他存在另一个数组中

                int index = 0;
                string[] Operation_string = { "查看", "新增", "修改", "删除" };

                // 查找不同的MenuIds
                //var distinctMenuIds = RoleMenulist.Select(r => r.MenuId).Distinct();
                var distinctMenuIds = _dbManger.Ctx.SystemMenus.Select(r => r.Id).Distinct();
                var menuNamelist = _dbManger.Ctx.SystemMenus.Select(c => new { MenuId = c.Id, Name = c.Name }).ToList();
                foreach (var menuId in distinctMenuIds)
                {
                    // 获取当前菜单的所有操作
                    var allOperations = Enumerable.Range(1, 4).ToList();

                    // 获取当前菜单已有的操作
                    var operationsForMenu = RoleMenulist.Where(r => r.MenuId == menuId).Select(r => new { r.OperationId, r.OperationName }).ToList();

                    // 检查是否存在所有操作
                    foreach (var operationId in allOperations)
                    {
                        var operationInfo = operationsForMenu.FirstOrDefault(o => o.OperationId == operationId);

                        var menuName = menuNamelist.FirstOrDefault(r => r.MenuId == menuId)?.Name;

                        //var menuName = await _dbManger.Ctx.SystemMenus.Where(c => c.Id == 1).Select(r=> r.Name).FirstOrDefaultAsync();
                        //var menuName = _dbManger.Ctx.SystemMenus.Where(c => c.Id == menuId).FirstOrDefault().Name;
                        var operationName = operationInfo?.OperationName ?? $"{Operation_string[operationId - 1]}";

                        var temprole = new Role_Manage
                        {
                            value = index,
                            title = $"{menuName}-{operationName}", // 根据需要自定义标题
                            disabled = false,
                            @checked = false
                        };

                        Left_result.Add(temprole);

                        if (operationsForMenu.Any() && operationsForMenu.Select(o => o.OperationId).Contains(operationId))
                        {
                            resultarr.Add(index); // 将 @checked = true 的 value 添加到 resultarr
                        }

                        index++;
                    }
                }



                return JsonSerializer.Serialize(new { success = true, left = Left_result, right = resultarr, message = "初始化成功" });
            }
            catch (Exception ex)
            {
                return JsonSerializer.Serialize(new { success = true, message = $"初始化失败！+{ex}" });
            }



        }
        #endregion

        #region 角色权限修改
        public async Task<string> Save_Role_Operation_EditAsync(List<CQIE.LOG.Models.Tool.Role_Manage> list, int rid)
        {
            using (var transaction = _dbManger.Ctx.Database.BeginTransaction())
            {
                try
                {

                    //找出全部信息 功能信息 - 权限名称 - 是否checked
                    //1.先找出全部的和这个角色有关联的菜单
                    //2.然后找出所有的角色菜单中间表
                    //3.通过foreach遍历如果我的角色菜单中间表中有这个数据的话就把他存在另一个数组中

                    List<CQIE.LOG.Models.Tool.Role_Manage> Left_result = new List<Models.Tool.Role_Manage>();

                    List<int> resultarr = new List<int>();

                    var RoleMenulist = await (from o in _dbManger.Ctx.SystemMenus
                                              join a in _dbManger.Ctx.SysRoleMenus on o.Id equals a.MenuId
                                              join b in _dbManger.Ctx.sysRoleMenuOperations on a.Id equals b.SysRoleMenuID
                                              join c in _dbManger.Ctx.SysOperations on b.OperationID equals c.Id
                                              where a.RoleId == rid
                                              select new
                                              {
                                                  Name = o.Name,
                                                  MenuId = o.Id,
                                                  OperationId = b.OperationID,
                                                  OperationName = c.Name
                                              }).ToListAsync();//现在把我的这个角色的菜单找出来了


                    //找所有Operation信息
                    var Operationlist = await (from o in _dbManger.Ctx.SysOperations
                                               select new
                                               {
                                                   Id = o.Id,
                                                   Name = o.Name
                                               }).ToListAsync();

                    //1.先找出全部的和这个角色有关联的菜单
                    //2.然后找出所有的角色菜单中间表
                    //3.通过foreach遍历如果我的角色菜单中间表中有这个数据的话就把他存在另一个数组中

                    int index = 0;
                    string[] Operation_string = { "查看", "新增", "修改", "删除" };
                    List<CQIE.LOG.Models.Tool.RoleMenuOperation_Temp> temp_roleMenuoperation = new List<RoleMenuOperation_Temp>();


                    // 查找不同的MenuIds
                    var distinctMenuIds = _dbManger.Ctx.SystemMenus.Select(r => r.Id).Distinct();
                    var menuNamelist = _dbManger.Ctx.SystemMenus.Select(c => new { MenuId = c.Id, Name = c.Name }).ToList();
                    foreach (var menuId in distinctMenuIds)
                    {
                        // 获取当前菜单的所有操作
                        var allOperations = Enumerable.Range(1, 4).ToList();

                        // 获取当前菜单已有的操作
                        var operationsForMenu = RoleMenulist.Where(r => r.MenuId == menuId).Select(r => new { r.OperationId, r.OperationName }).ToList();

                        // 检查是否存在所有操作
                        foreach (var operationId in allOperations)
                        {
                            var operationInfo = operationsForMenu.FirstOrDefault(o => o.OperationId == operationId);

                            var menuName = menuNamelist.FirstOrDefault(r => r.MenuId == menuId)?.Name;
                            var operationName = operationInfo?.OperationName ?? $"{Operation_string[operationId - 1]}";

                            var temprole = new Role_Manage
                            {
                                value = index,
                                title = $"{menuName}-{operationName}", // 根据需要自定义标题
                                disabled = false,
                                @checked = false
                            };

                            var temp_rmo = new CQIE.LOG.Models.Tool.RoleMenuOperation_Temp
                            {
                                Value = index,
                                Rid = rid,
                                Mid = menuId,
                                Oid = operationId
                            };

                            temp_roleMenuoperation.Add(temp_rmo);

                            Left_result.Add(temprole);

                            if (operationsForMenu.Any() && operationsForMenu.Select(o => o.OperationId).Contains(operationId))
                            {
                                resultarr.Add(index); // 将 @checked = true 的 value 添加到 resultarr
                            }

                            index++;
                        }
                    }
                    //先将我RoleMenu中间表中关于Rid的所有信息删除完

                    var roleMenuToDelete = _dbManger.Ctx.SysRoleMenus
                                            .Where(rm => rm.RoleId == rid)
                                            .ToList();
                    if (roleMenuToDelete != null)
                    {
                        _dbManger.Ctx.SysRoleMenus.RemoveRange(roleMenuToDelete);
                    }

                    //我现在要进行操作的有三个对象
                    //----我的目标是通过这个两个对象将我要找的对象从rolemenuoperation中找出来
                    //通过value值直接对应找出来提取出来就行

                    List<CQIE.LOG.Models.Tool.RoleMenuOperation_Temp> result = new List<RoleMenuOperation_Temp>();

                    foreach (var t in list)
                    {
                        var temp = temp_roleMenuoperation.Where(c => c.Value == t.value).FirstOrDefault();
                        result.Add(temp);
                    }

                    var result_menu = result.Select(c => c.Mid).Distinct();

                    foreach (var t in result_menu)
                    {
                        var tr = new CQIE.LOG.Models.SysRoleMenu
                        {
                            MenuId = t,
                            RoleId = rid
                        };
                        _dbManger.Ctx.SysRoleMenus.Add(tr);

                        foreach (var t2 in result)
                        {
                            //如果我的mid相等
                            if (t2.Mid == t)
                            {
                                var trmo = new CQIE.LOG.Models.SysRoleMenuOperation
                                {
                                    RoleMenu = tr,
                                    OperationID = t2.Oid
                                };
                                _dbManger.Ctx.sysRoleMenuOperations.Add(trmo);
                            }
                        }
                    }
                    _dbManger.Ctx.SaveChanges();
                    transaction.Commit();

                    return JsonSerializer.Serialize(new { success = true, message = "修改成功" });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return JsonSerializer.Serialize(new { success = false, message = $"修改失败{ex}" });
                }
            }
        }
        #endregion
    }
}
