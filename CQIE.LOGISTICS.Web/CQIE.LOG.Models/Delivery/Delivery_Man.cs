using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CQIE.LOG.Models.Delivery
{
    /// <summary>
    /// 送货人表
    /// </summary>
    [Table("TB_SysDelivery_Man")]
    public class Delivery_Man
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int State { get; set; }
        public List<Delivery> deliveries { get; set; }
    }
}
