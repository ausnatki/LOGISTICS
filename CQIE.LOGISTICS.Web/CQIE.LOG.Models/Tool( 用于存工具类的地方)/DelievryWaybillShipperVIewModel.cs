using System;
using System.Collections.Generic;
using System.Text;

namespace CQIE.LOG.Models.Tool
{
    public class DelievryWaybillShipperVIewModel
    {
        public CQIE.LOG.Models.Delivery.Delivery_Order delivery { get; set; }
        public CQIE.LOG.Models.Waybill.ShipperConsigneeInfo Shipper_Temp { get; set; }
        public CQIE.LOG.Models.Waybill.ShipperConsigneeInfo Carrier_Temp { get; set; }
    }
}
