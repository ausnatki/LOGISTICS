using System;
using System.Collections.Generic;
using System.Text;

namespace CQIE.LOG.Models.Waybill
{
    /// <summary>
    /// 托运人和收货人信息表
    /// </summary>
    public class ShipperConsigneeInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }//邮编
        public WayBill Waybill { get; set; }
    }
}
