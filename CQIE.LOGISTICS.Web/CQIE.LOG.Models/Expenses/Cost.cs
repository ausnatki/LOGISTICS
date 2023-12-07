using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CQIE.LOG.Models.Expenses
{
    /// <summary>
    /// 报销单费用表
    /// </summary>
 
    [Table("TB_SysCost")]
    public class Cost
    {
        public int Id { get; set; }
        public decimal Charge { get; set; }//路桥费
        public decimal Cheer { get; set; }//加邮费
        public decimal Maintain { get; set; }//车辆维护费
        public decimal Other { get; set; }//其他费用
        public string Explain { get; set; }//费用说明
        public Expenses Expenses { get; set; }
    }
}
