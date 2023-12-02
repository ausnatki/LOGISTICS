using System;
using System.Collections.Generic;
using System.Text;

namespace CQIE.LOG.Models.Waybill
{
    public class WayBill
    {
        public int Id { get; set; }
        public Delivery.Delivery Delivery { get; set; }//1对1
    }
}
