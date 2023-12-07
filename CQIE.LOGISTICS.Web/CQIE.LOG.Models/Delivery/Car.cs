using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CQIE.LOG.Models.Delivery
{
    /// <summary>
    /// 车辆表
    /// </summary>
    [Table("TB_SysCar")]

    public class Car
    {
        public int Id { get; set; }
        public string CarNumber { get; set; }//车牌号
        public int State { get; set; }
        public int CarType_Id { get; set; }
        public CarType CarType { get; set; }
        public List<Delivery_Order> deliveries { get; set; }
    }
}
