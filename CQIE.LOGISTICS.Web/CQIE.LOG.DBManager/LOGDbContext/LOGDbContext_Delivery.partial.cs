using CQIE.LOG.Models.Delivery;
using CQIE.LOG.Models.Expenses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQIE.LOG.DBManager
{
    public partial class LOGDbContext
    {
        // 继续编写 OnModelCreating 方法的内容
        partial void AdditionalModelConfiguration_hyk(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CQIE.LOG.Models.Delivery.Delivery_Order>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.HasOne(c => c.WayBill).WithOne(c => c.Delivery).HasForeignKey<Delivery_Order>(d => d.WayBill_Id);
                entity.HasOne(c => c.Car).WithMany(c => c.deliveries).HasForeignKey(c => c.Car_Id);
                entity.HasOne(c => c.Delivery_Man).WithMany(c => c.deliveries).HasForeignKey(c => c.Delivery_man_Id);
            });

            modelBuilder.Entity<CQIE.LOG.Models.Delivery.Car>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.HasOne(c => c.CarType).WithMany(c => c.cars).HasForeignKey(c => c.CarType_Id);
            });

            modelBuilder.Entity<CQIE.LOG.Models.Delivery.CarType>(entity =>
            {
                entity.HasKey(c => c.Id);
            });

            modelBuilder.Entity<CQIE.LOG.Models.Delivery.Delivery_Man>(entity =>
            {
                entity.HasKey(c => c.Id);
            });

            modelBuilder.Entity<CQIE.LOG.Models.Expenses.Expenses>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.HasOne(c => c.Cost).WithOne(c => c.Expenses).HasForeignKey<Expenses>(c => c.Cost_Id);
                entity.HasOne(c => c.Delivery).WithOne(c => c.Expenses).HasForeignKey<Expenses>(c => c.Delivery_Id);
            });

        }
    }
}
