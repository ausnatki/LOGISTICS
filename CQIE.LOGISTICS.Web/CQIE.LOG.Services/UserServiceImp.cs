using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CQIE.LOG.Services
{
    public class UserServiceImp : IUserService
    {
        private readonly CQIE.LOG.DBManager.IDbManager m_Manager;
        private readonly UserManager<CQIE.LOG.Models.Identity.SysUser> _userManager;
        //构造函数注入信息
        public UserServiceImp(CQIE.LOG.DBManager.IDbManager manager, UserManager<CQIE.LOG.Models.Identity.SysUser> userManager)
        {
            m_Manager = manager;
            _userManager = userManager;
        }

        #region 获取所有用户信息（返回值为datatable）
        public async Task<DataTable> Get_All_User_DataTableAsync(int Page, int Limit, string name)
        {
            try
            {
                int startIndex = (Page - 1) * Limit;
                //通过用户id查询出他的角色，然后通过角色查询出他的权限和角色
                //我要查出他的名字，id，电话，
                var listUser = await (from o in m_Manager.Ctx.SysUsers
                                      join b in m_Manager.Ctx.SysUserRoles on o.Id equals b.UserId
                                      join c in m_Manager.Ctx.SysRoles on b.RoleId equals c.Id
                                      where string.IsNullOrEmpty(name) || o.UserName.Contains(name) //只要 UserName 包含了字符串 name，就会匹配条件。这实现了一个简单的模糊查询。
                                      select new
                                      {
                                          UID = o.Id,
                                          Name = o.UserName,
                                          Email = o.Email,
                                          Iphone = o.PhoneNumber,
                                          Role = c.Name
                                      })
                                .Skip(startIndex)
                                .Take(Limit)
                                .ToListAsync();

                return Tool.DataTableExtensions.ToDataTable(listUser);
            }
            catch (Exception ex)
            {
                //这里要添加日志信息记录错误信息
                return null;
            }
        }
        #endregion

        #region 通过用户名查询
        public async Task<List<object>> Get_By_NameAsync(int Page, int Limit, string name)
        {
            try
            {
                int startIndex = (Page - 1) * Limit;
                //通过用户id查询出他的角色，然后通过角色查询出他的权限和角色
                //我要查出他的名字，id，电话，
                var listUser = await (from o in m_Manager.Ctx.SysUsers
                                      where string.IsNullOrEmpty(name) || o.UserName.Contains(name) //只要 UserName 包含了字符串 name，就会匹配条件。这实现了一个简单的模糊查询。
                                      select new
                                      {
                                          UID = o.Id,
                                          Name = o.UserName,
                                          Email = o.Email,
                                          Iphone = o.PhoneNumber,
                                      })
                                .Skip(startIndex)
                                .Take(Limit)
                                .ToListAsync();


                return listUser.Cast<object>().ToList();
            }
            catch (Exception ex)
            {
                //这里要添加日志信息记录错误信息
                return null;
            }
        }
        #endregion

        #region 返回的是一个object类型的所有用户的list数据同时也是搜索的实现
        public async Task<List<object>> Get_All_User_ListAsync(int Page, int Limit, string name)
        {
            try
            {
                int startIndex = (Page - 1) * Limit;
                //通过用户id查询出他的角色，然后通过角色查询出他的权限和角色
                //我要查出他的名字，id，电话，
                var listUser = await (from o in m_Manager.Ctx.SysUsers
                                      where string.IsNullOrEmpty(name) || o.UserName.Contains(name) //只要 UserName 包含了字符串 name，就会匹配条件。这实现了一个简单的模糊查询。
                                      select new
                                      {
                                          UID = o.Id,
                                          Name = o.UserName,
                                          Email = o.Email,
                                          Iphone = o.PhoneNumber,
                                      })
                                .OrderByDescending(user => user.UID)
                                .Skip(startIndex)
                                .Take(Limit)
                                .ToListAsync();


                return listUser.Cast<object>().ToList(); ;
            }
            catch (Exception ex)
            {
                //这里要添加日志信息记录错误信息
                return null;
            }
        }
        #endregion

        #region 通过id查询用户数据
        public async Task<object> Get_By_IdAsync(int id)
        {
            try
            {
                var listUser = await (from o in m_Manager.Ctx.SysUsers
                                      where o.Id == id
                                      select new
                                      {
                                          UID = o.Id,
                                          Name = o.UserName,
                                          Email = o.Email,
                                          Iphone = o.PhoneNumber,

                                      }).FirstOrDefaultAsync();

                return listUser;
            }
            catch (Exception ex)
            {
                //这里要记录日志
                return null;
            }
        }
        #endregion

        #region 修改功能
        public async Task<string> Save_Update_UserAsync(CQIE.LOG.Models.Identity.SysUser user)
        {
            using (var transaction = m_Manager.Ctx.Database.BeginTransaction())
            {
                string tun = m_Manager.Ctx.SysUsers.Where(c => c.Id == user.Id).FirstOrDefault().UserName;

                if (user.UserName != tun)
                {
                    var tu = m_Manager.Ctx.SysUsers.Where(c => c.UserName == user.UserName).FirstOrDefault();
                    if (tu != null)
                    {
                        transaction.Rollback();
                        return JsonSerializer.Serialize(new { success = false, message = "用户名已经存在" });
                    }
                }
                try
                {
                    var u = await m_Manager.Ctx.SysUsers.Where(c => c.Id == user.Id).FirstOrDefaultAsync();
                    u.UserName = user.UserName;
                    u.Email = user.Email;
                    u.PhoneNumber = user.PhoneNumber;
                    m_Manager.Ctx.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return JsonSerializer.Serialize(new { success = false, message = $"{ex}。" });
                }
            }
            return JsonSerializer.Serialize(new { success = true, message = "修改成功" });
        }
        #endregion

        #region 删除
        public async Task<string> Save_Del_UserAsync(int id)
        {
            using (var transaction = m_Manager.Ctx.Database.BeginTransaction())
            {
                try
                {
                    var u = await m_Manager.Ctx.SysUsers.Where(c => c.Id == id).FirstOrDefaultAsync();
                    //var r = await m_Manager.Ctx.SysUserRoles.Where(c => c.UserId == id).ToListAsync();
                    //m_Manager.Ctx.SysUserRoles.RemoveRange(r);
                    m_Manager.Ctx.SysUsers.Remove(u);
                    m_Manager.Ctx.SaveChanges();
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

        #region 添加功能实现
        public async Task<string> Save_Add_UserAsync(CQIE.LOG.Models.Identity.SysUser user)
        {
            using (var transaction = m_Manager.Ctx.Database.BeginTransaction())
            {
                try
                {
                    // 判断是否有相同的规范化用户名
                    CQIE.LOG.Models.Identity.SysUser tuser = await m_Manager.Ctx.SysUsers
                        .Where(c => c.NormalizedUserName == user.UserName.ToUpper())
                        .FirstOrDefaultAsync();

                    if (tuser != null)
                    {
                        await transaction.RollbackAsync();
                        return JsonSerializer.Serialize(new { success = false, message = "相同用户名的用户已存在。" });
                    }

                    // 创建用户
                    await _userManager.CreateAsync(user, user.LoginPassword);

                    // 获取 ID 为 2 的角色
                    CQIE.LOG.Models.Identity.SysRole role = await m_Manager.Ctx.SysRoles
                        .Where(c => c.Id == 2)
                        .FirstOrDefaultAsync();

                    if (role == null)
                    {
                        // 处理角色 ID 为 2 的角色不存在的情况
                        await transaction.RollbackAsync();
                        return JsonSerializer.Serialize(new { success = false, message = "ID 为 2 的角色不存在。" });
                    }

                    // 将角色分配给用户
                    CQIE.LOG.Models.Identity.SysUserRole ur = new CQIE.LOG.Models.Identity.SysUserRole
                    {
                        Role = role,
                        User = user
                    };

                    await m_Manager.Ctx.SysUserRoles.AddAsync(ur);
                    await m_Manager.Ctx.SaveChangesAsync();

                    // 记录成功操作
                    await transaction.CommitAsync();
                    return JsonSerializer.Serialize(new { success = true, message = "用户创建成功。" });
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

    }
}
