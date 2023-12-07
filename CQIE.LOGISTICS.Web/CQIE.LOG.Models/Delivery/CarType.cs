using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CQIE.LOG.Models.Delivery
{
    /// <summary>
    /// 车类型表
    /// </summary>
    [Table("TB_SysCarType")]
    public class CarType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int State { get; set; }
        public List<Car> cars { get; set; }
        public List<Delivery_Order> deliveries { get; set; }
    }
}
