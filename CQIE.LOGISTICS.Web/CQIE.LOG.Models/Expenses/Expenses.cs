using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CQIE.LOG.Models.Expenses
{
    /// <summary>
    /// 报销单表
    /// </summary>
    [Table("TB_SysExpenses")]
    public class Expenses
    {
        public int Id { get; set; }
        public bool Back_Car { get; set; } 
        public int Cost_Id { get; set; }
        public int Delivery_Id { get; set; }
        public decimal Production { get; set; }
        public Cost Cost { get; set; }
        public Delivery.Delivery_Order Delivery { get; set; }
    }
}
