using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQIE.LOG.DBManager
{
    public partial class LOGDbContext
    {
        partial void AdditionalModelConfiguration_WayBill(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CQIE.LOG.Models.Waybill.GoodsInfo>(e =>
            {
                e.HasKey(c => c.Id);
                e.HasOne(c => c.wayBill).WithMany(c => c.goodsInfos).HasForeignKey(c => c.OrderID);
            });
            modelBuilder.Entity<CQIE.LOG.Models.Waybill.ShipperConsigneeInfo>(e =>
            {
                e.HasKey(c => c.Id);
            });
            modelBuilder.Entity<CQIE.LOG.Models.Waybill.WayBill>(e =>
            {
                e.HasKey(c => c.Id);
                e.HasOne(c => c.ShipperConsigneeInfo).WithOne(c => c.Waybill).HasForeignKey<CQIE.LOG.Models.Waybill.WayBill>(c => c.ShipperID);
            });
        }
    }
}
