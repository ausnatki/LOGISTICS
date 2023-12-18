using System;
using System.Collections.Generic;
using System.Text;

namespace CQIE.LOG.Models.Tool
{
    public class CarTypeCarWaybillShipperUserModel
    {
        public List<CQIE.LOG.Models.Delivery.Car> cars { get; set; }
        public List<CQIE.LOG.Models.Delivery.CarType> carTypes { get; set; }
        public CQIE.LOG.Models.Waybill.ShipperConsigneeInfo Shipper { get; set; }
        public CQIE.LOG.Models.Waybill.ShipperConsigneeInfo Carieer { get; set; }
        public List<CQIE.LOG.Models.Identity.SysUser> Delivery_Man { get; set; }
        public CQIE.LOG.Models.Waybill.WayBill wayBill { get; set; }

    }
}
