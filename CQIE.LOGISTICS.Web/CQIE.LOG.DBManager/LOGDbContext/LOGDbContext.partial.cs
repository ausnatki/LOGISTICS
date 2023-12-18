using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CQIE.LOG.DBManager
{
    public partial class LOGDbContext 
    {
        public DbSet<CQIE.LOG.Models.SystemMenu> SystemMenus { get; set; }
        public DbSet<CQIE.LOG.Models.SysOperation> SysOperations { get; set; }
        public DbSet<CQIE.LOG.Models.SysMenuOperation> SysMenuOperations { get; set; }
        public DbSet<CQIE.LOG.Models.SysRoleMenu> SysRoleMenus { get; set; }
        public DbSet<CQIE.LOG.Models.Identity.SysUserRole> SysUserRoles { get; set; }
        public DbSet<CQIE.LOG.Models.Identity.SysUser> SysUsers { get; set; }
        public DbSet<CQIE.LOG.Models.Identity.SysRole> SysRoles { get; set; }
        public DbSet<CQIE.LOG.Models.SysRoleMenuOperation> sysRoleMenuOperations { get; set; }
        public DbSet<CQIE.LOG.Models.Waybill.GoodsInfo> GoodsInfos { get; set; }
        public DbSet<CQIE.LOG.Models.Waybill.ShipperConsigneeInfo> ShipperConsigneeInfos { get; set; }
        public DbSet<CQIE.LOG.Models.Waybill.WayBill> WayBills { get; set; }
        public DbSet<CQIE.LOG.Models.Delivery.Delivery_Order> Delivery_Orders { get; set; }
        public DbSet<CQIE.LOG.Models.Delivery.CarType> CarTypes { get; set;}
        public DbSet<CQIE.LOG.Models.Delivery.Car> Cars { get; set; }
        public DbSet<CQIE.LOG.Models.Expenses.Expenses> Expenses { get; set; }
        public DbSet<CQIE.LOG.Models.Expenses.Cost> Costs { get; set; }
    }
}
