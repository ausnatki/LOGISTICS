using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CQIE.LOG.Models.Delivery
{
    /// <summary>
    /// 送货表
    /// </summary>
    [Table("TB_SysDelivery")]
    public class Delivery
    {
        public int Id { get; set; }
        public int CarType_Id { get; set; }
        public int Car_Id { get; set; }
        public int WayBill_Id{get;set;}
        public int Delivery_man_Id { get; set; }
        public DateTime Delivery_data { get; set; }        
        public CarType carType { get; set; }
        public Car Car { get; set; }
        public Delivery_Man Delivery_Man { get; set; }
        public Waybill.WayBill WayBill { get; set; }

        public Expenses.Expenses Expenses { get; set; }

    }
}
