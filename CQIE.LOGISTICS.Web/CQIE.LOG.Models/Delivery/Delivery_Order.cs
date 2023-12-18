using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CQIE.LOG.Models.Delivery
{
    /// <summary>
    /// 送货表
    /// </summary>
    [Table("TB_SysDeliveryOrder")]
    public class Delivery_Order
    {
        public int Id { get; set; }
        public int Car_Id { get; set; }  
        public int WayBill_Id{get;set;}
        public int Delivery_man_Id { get; set; }
        public DateTime Delivery_data { get; set; }        
        //public Car Car { get; set; }

        //public Identity.SysUser Delivery_Man { get; set; }
        public Waybill.WayBill WayBill { get; set; }

        public Expenses.Expenses Expenses { get; set; }

    }
}
