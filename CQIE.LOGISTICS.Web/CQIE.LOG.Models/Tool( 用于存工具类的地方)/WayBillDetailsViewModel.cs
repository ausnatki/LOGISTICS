using CQIE.LOG.Models.Tool;
using CQIE.LOG.Models.Waybill;
using System;
using System.Collections.Generic;
using System.Text;
namespace CQIE.LOG.Models.Tool 
{
    public class WayBillDetailsViewModel
    {
        public WayBill WayBill { get; set; }
        public List<GoodsInfo> GoodsInfo { get; set; }
        public Shipper_Temp Shipper { get; set; }
        public Carrier_Temp Carrier { get; set; }
    }
}
