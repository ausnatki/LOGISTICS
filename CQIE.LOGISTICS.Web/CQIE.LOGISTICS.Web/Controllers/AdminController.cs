using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQIE.LOGISTICS.Web.Controllers
{
    public class AdminController : Controller
    {
        private static System.Text.StringBuilder m_Resp = new System.Text.StringBuilder();
        private Microsoft.AspNetCore.Identity.UserManager<CQIE.LOG.Models.Identity.SysUser> m_UserManager;

        //[Authorize(Roles = "admin")]
        public IActionResult Index2([FromServices] CQIE.LOG.DBManager.IDbManager dbManager)
        {
            return View();
        }

        public AdminController(Microsoft.AspNetCore.Identity.UserManager<CQIE.LOG.Models.Identity.SysUser> UserManager)
        {
            m_UserManager = UserManager;
        }

        /// <summary>
        /// 创建数据库
        /// </summary>
        /// <param name="dbManager"></param>
        /// <returns></returns>
        public async Task<IActionResult> CreateDB([FromServices] CQIE.LOG.DBManager.IDbManager dbManager)
        {
            m_Resp.AppendLine("开始创建数据库。。。。。");
            dbManager.Ctx.Database.EnsureDeleted();
            dbManager.Ctx.Database.EnsureCreated();
            m_Resp.AppendLine("数据库创建成功");

            //InitMenu(dbManager);
            await InitData(dbManager);
            return Content(m_Resp.ToString());
        }

        #region 数据初始化
        public async Task InitData(CQIE.LOG.DBManager.IDbManager dbManager)
        {
            #region 系统账户初始化
            m_Resp.AppendLine("开始初始化系统账户.......");
            var administrator = new CQIE.LOG.Models.Identity.SysUser()
            {
                UserName = "kkk",
                Email = "admin@LOG.com",
                PhoneNumber = "13800138000",
            };
            var result = await m_UserManager.CreateAsync(administrator, "123456");

            if (result.Succeeded)
            {
                m_Resp.AppendLine("................................初始化系统账户完成.");
            }
            else
            {
                m_Resp.AppendLine("................................初始化系统账户失败");
                foreach (var e in result.Errors)
                {
                    m_Resp.AppendLine(e.Description);
                }
            }
            #endregion

            #region 普通账号初始化
            m_Resp.AppendLine("开始初始化普通账户.......");
            var normalUser = new CQIE.LOG.Models.Identity.SysUser()
            {
                UserName = "Normal",
                Email = "normal@LOG.com",
                PhoneNumber = "13800138002",
            };
            var result2 = await m_UserManager.CreateAsync(normalUser, "123456");

            if (result2.Succeeded)
            {
                m_Resp.AppendLine("................................初始化普通账户完成.");
            }
            else
            {
                m_Resp.AppendLine("................................初始化普通账户失败");
                foreach (var e in result.Errors)
                {
                    m_Resp.AppendLine(e.Description);
                }
            }
            #endregion

            #region 角色初始化
            var adminRole = new CQIE.LOG.Models.Identity.SysRole()
            {
                Name = "系统管理员",
                NormalizedName = "系统管理员"
            };

            var viewerRole = new CQIE.LOG.Models.Identity.SysRole()
            {
                Name = "只能查看权限",
                NormalizedName = "只能查看权限"
            };

            dbManager.Ctx.Roles.AddRange(adminRole, viewerRole);
            dbManager.Ctx.SaveChanges();
            #endregion

            #region 角色用户关系表初始化
            m_Resp.AppendLine("开始初始化账户与角色关系.......");
            administrator = dbManager.Ctx.Users.Where(c => c.UserName == "kkk").FirstOrDefault();
            normalUser = dbManager.Ctx.Users.Where(c => c.UserName == "Normal").FirstOrDefault();
            var administrator_Role = new CQIE.LOG.Models.Identity.SysUserRole()
            {
                User = administrator,
                Role = adminRole
            };
            var normalUser_Role = new CQIE.LOG.Models.Identity.SysUserRole()
            {
                User = normalUser,
                Role = viewerRole
            };
            dbManager.Ctx.SysUserRoles.Add(administrator_Role);
            dbManager.Ctx.SysUserRoles.Add(normalUser_Role);
            dbManager.Ctx.SaveChanges();
            m_Resp.AppendLine("................................初始化账户与角色关系完成.");
            #endregion

            #region 操作项目
            m_Resp.AppendLine("开始初始化操作项目.......");
            var view = new CQIE.LOG.Models.SysOperation()
            {
                Id = 1,
                Code = "VIEW",
                Name = "查看",
            };

            var add = new CQIE.LOG.Models.SysOperation()
            {
                Id = 2,
                Code = "ADD",
                Name = "新增",
            };

            var edit = new CQIE.LOG.Models.SysOperation()
            {
                Id = 3,
                Code = "EDIT",
                Name = "修改",
            };

            var delete = new CQIE.LOG.Models.SysOperation()
            {
                Id = 4,
                Code = "DELETE",
                Name = "删除",
            };
            dbManager.Ctx.SysOperations.AddRange(view, add, edit, delete);
            dbManager.Ctx.SaveChanges();
            m_Resp.AppendLine("................................初始化操作项目完成.");
            #endregion

            #region 主菜单
            m_Resp.AppendLine("开始初始化菜单.......");
            var system = new CQIE.LOG.Models.SystemMenu()
            {
                Name = "系统管理",
                IconClassName = "fa fa-feed",
                SortOrder = 1,
                Url = null,
            };
            system.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = view
            });

            dbManager.Ctx.SystemMenus.Add(system);
            dbManager.Ctx.SaveChanges();

            var system2 = new CQIE.LOG.Models.SystemMenu()
            {
                Name = "订单管理",
                IconClassName = "fa fa-feed",
                SortOrder = 1,
                Url = null,
            };
            system2.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = view
            });

            dbManager.Ctx.SystemMenus.Add(system2);
            dbManager.Ctx.SaveChanges();

            var system3 = new CQIE.LOG.Models.SystemMenu()
            {
                Name = "调度管理",
                IconClassName = "fa fa-feed",
                SortOrder = 1,
                Url = null,
            };
            system3.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = view
            });

            dbManager.Ctx.SystemMenus.Add(system3);
            dbManager.Ctx.SaveChanges();

            var system4 = new CQIE.LOG.Models.SystemMenu()
            {
                Name = "车辆管理管理",
                IconClassName = "fa fa-feed",
                SortOrder = 1,
                Url = null,
            };
            system4.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = view
            });

            dbManager.Ctx.SystemMenus.Add(system4);
            dbManager.Ctx.SaveChanges();
            m_Resp.AppendLine("................................初始化主功能菜单完成.");
            #endregion

            #region 子功能菜单
            //用户管理
            var userManager = new CQIE.LOG.Models.SystemMenu()
            {
                Name = "人员管理",
                IconClassName = "fa fa-feed",
                SortOrder = 1,
                Url = "/SysUser/Index",
            };
            userManager.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = view
            });
            userManager.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = add
            });
            userManager.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = edit
            });
            userManager.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = delete
            });


            //角色管理
            var roleManager = new CQIE.LOG.Models.SystemMenu()
            {
                Name = "角色管理",
                IconClassName = "fa fa-feed",
                SortOrder = 1,
                Url = "/SysRole/Index",
            };
            roleManager.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = view
            });
            roleManager.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = add
            });
            roleManager.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = edit
            });
            roleManager.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = delete
            });

            //账单管理
            var waybillManager = new CQIE.LOG.Models.SystemMenu()
            {
                Name = "账单管理",
                IconClassName = "fa fa-feed",
                SortOrder = 2,
                Url = "/SysWaybill/Index",
            };
            waybillManager.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = view
            });
            waybillManager.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = add
            });
            waybillManager.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = edit
            });
            waybillManager.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = delete
            });

            //账单添加
            var waybillAdd = new CQIE.LOG.Models.SystemMenu()
            {
                Name = "账单添加",
                IconClassName = "fa fa-feed",
                SortOrder = 2,
                Url = "/SysWaybill/Add",
            };
            waybillAdd.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = view
            });
            waybillAdd.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = add
            });
            waybillAdd.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = edit
            });
            waybillAdd.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = delete
            });

            //账单调度单管理
            var DeliveryManager = new CQIE.LOG.Models.SystemMenu()
            {
                Name = "调度单管理",
                IconClassName = "fa fa-feed",
                SortOrder = 1,
                Url = "/SysDelivery/Index",
            };
            waybillAdd.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = view
            });
            waybillAdd.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = add
            });
            waybillAdd.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = edit
            });
            waybillAdd.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = delete
            });

            //送货人员管理
            var DeliverymanManager = new CQIE.LOG.Models.SystemMenu()
            {
                Name = "送货人员管理",
                IconClassName = "fa fa-feed",
                SortOrder = 1,
                Url = "/SysDeliveryMan/Index",
            };
            waybillAdd.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = view
            });
            waybillAdd.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = add
            });
            waybillAdd.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = edit
            });
            waybillAdd.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = delete
            });

            //送货车辆管理
            var DeliverycarManager = new CQIE.LOG.Models.SystemMenu()
            {
                Name = "送货车辆",
                IconClassName = "fa fa-feed",
                SortOrder = 1,
                Url = "/SysCar/Index",
            };
            waybillAdd.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = view
            });
            waybillAdd.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = add
            });
            waybillAdd.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = edit
            });
            waybillAdd.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = delete
            });

            //车辆类别
            var DeliverycartyeManager = new CQIE.LOG.Models.SystemMenu()
            {
                Name = "车辆类别",
                IconClassName = "fa fa-feed",
                SortOrder = 1,
                Url = "/SysCarType/Index",
            };
            waybillAdd.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = view
            });
            waybillAdd.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = add
            });
            waybillAdd.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = edit
            });
            waybillAdd.SysMenuOperations.Add(new CQIE.LOG.Models.SysMenuOperation()
            {
                Operation = delete
            });


            ////
            system.SubMenus.Add(userManager);
            system.SubMenus.Add(roleManager);
            system2.SubMenus.Add(waybillManager);
            system2.SubMenus.Add(waybillAdd);

            system3.SubMenus.Add(DeliveryManager);
            system3.SubMenus.Add(DeliverymanManager);
            system4.SubMenus.Add(DeliverycarManager);
            system4.SubMenus.Add(DeliverycartyeManager);

            dbManager.Ctx.SaveChanges();
            m_Resp.AppendLine("................................初始化子功能菜单完成.");
            #endregion

            #region 功能菜单与角色的关系
            m_Resp.AppendLine("开始初始化功能菜单与角色的关系.......");

            #region 初始化 adminRole 角色的功能菜单
            // 系统管理
            var adminRoleMenu1 = new CQIE.LOG.Models.SysRoleMenu()
            {
                Role = adminRole,
                Menu = system
            };
            adminRoleMenu1.SysRoleMenuOperations.Add(new CQIE.LOG.Models.SysRoleMenuOperation()
            {
                Operation = view
            });
            dbManager.Ctx.SysRoleMenus.Add(adminRoleMenu1);



            ///用户管理 --------------------
            var adminRoleMenu2 = new CQIE.LOG.Models.SysRoleMenu()
            {
                Role = adminRole,
                Menu = userManager
            };
            adminRoleMenu2.SysRoleMenuOperations.Add(new CQIE.LOG.Models.SysRoleMenuOperation()
            {
                Operation = view
            });
            adminRoleMenu2.SysRoleMenuOperations.Add(new CQIE.LOG.Models.SysRoleMenuOperation()
            {
                Operation = add
            });
            adminRoleMenu2.SysRoleMenuOperations.Add(new CQIE.LOG.Models.SysRoleMenuOperation()
            {
                Operation = edit
            });
            adminRoleMenu2.SysRoleMenuOperations.Add(new CQIE.LOG.Models.SysRoleMenuOperation()
            {
                Operation = delete
            });
            dbManager.Ctx.SysRoleMenus.Add(adminRoleMenu2);

            ///角色管理 ------------------------------
            var adminRoleMenu3 = new CQIE.LOG.Models.SysRoleMenu()
            {
                Role = adminRole,
                Menu = roleManager
            };
            adminRoleMenu3.SysRoleMenuOperations.Add(new CQIE.LOG.Models.SysRoleMenuOperation()
            {
                Operation = view
            });
            adminRoleMenu3.SysRoleMenuOperations.Add(new CQIE.LOG.Models.SysRoleMenuOperation()
            {
                Operation = add
            });
            adminRoleMenu3.SysRoleMenuOperations.Add(new CQIE.LOG.Models.SysRoleMenuOperation()
            {
                Operation = edit
            });
            adminRoleMenu3.SysRoleMenuOperations.Add(new CQIE.LOG.Models.SysRoleMenuOperation()
            {
                Operation = delete
            });
            dbManager.Ctx.SysRoleMenus.Add(adminRoleMenu3);
            #endregion


            #region 初始化 viewerRole 角色的功能菜单
            // 系统管理
            var viewerRoleMenu1 = new CQIE.LOG.Models.SysRoleMenu()
            {
                Role = viewerRole,
                Menu = system
            };
            viewerRoleMenu1.SysRoleMenuOperations.Add(new CQIE.LOG.Models.SysRoleMenuOperation()
            {
                Operation = view
            });
            dbManager.Ctx.SysRoleMenus.Add(viewerRoleMenu1);


            ///用户管理 --------------------
            var viewerRoleMenu2 = new CQIE.LOG.Models.SysRoleMenu()
            {
                Role = viewerRole,
                Menu = userManager
            };
            viewerRoleMenu2.SysRoleMenuOperations.Add(new CQIE.LOG.Models.SysRoleMenuOperation()
            {
                Operation = view
            });
            dbManager.Ctx.SysRoleMenus.Add(viewerRoleMenu2);
            #endregion 


            dbManager.Ctx.SaveChanges();
            m_Resp.AppendLine("................................初始化功能菜单与角色的关系完成");
            #endregion
        }
        #endregion

        #region 菜单初始化
        private void InitMenu(CQIE.LOG.DBManager.IDbManager dbManager)
        {
            m_Resp.AppendLine("开始初始菜单化...");

            dbManager.Ctx.SystemMenus.Add(new CQIE.LOG.Models.SystemMenu()
            {
                //Id = 0,
                ParentID = 0,
                Name = "订单管理",
                IconClassName = "fa fa-feed",
                SortOrder = 1,
                Url = "~/Order/TestMyContainer",
            });

            dbManager.Ctx.SystemMenus.Add(new CQIE.LOG.Models.SystemMenu()
            {
                //Id = 1,
                ParentID = 0,
                Name = "车辆管理",
                IconClassName = "fa fa-feed",
                SortOrder = 1,
                Url = "~/Order/TestMyContainer",
            });

            dbManager.Ctx.SystemMenus.Add(new CQIE.LOG.Models.SystemMenu()
            {
                //Id = 2,
                ParentID = 0,
                Name = "物流管理",
                IconClassName = "fa fa-feed",
                SortOrder = 1,
                Url = "~/Order/TestMyContainer",
            });

            dbManager.Ctx.SystemMenus.Add(new CQIE.LOG.Models.SystemMenu()
            {
                //Id = 3,
                ParentID = 0,
                Name = "人员管理",
                IconClassName = "fa fa-feed",
                SortOrder = 1,
                Url = "~/Order/TestMyContainer",
            });

            dbManager.Ctx.SystemMenus.Add(new CQIE.LOG.Models.SystemMenu()
            {
                //Id = 4,
                ParentID = 0,
                Name = "系统管理",
                IconClassName = "fa fa-feed",
                SortOrder = 1,
                Url = "~/Order/TestMyContainer",
            });


            dbManager.Ctx.SaveChanges();
            m_Resp.AppendLine("初始化菜单成功");
        }
        #endregion

        #region 
        #endregion
    }
}
