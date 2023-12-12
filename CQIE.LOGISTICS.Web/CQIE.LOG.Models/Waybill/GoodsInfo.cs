using System;
using System.Collections.Generic;
using System.Text;

namespace CQIE.LOG.Models.Waybill
{
    public class GoodsInfo
    {
        public int Id { get; set; }
        public string GoodsName { get; set; }//货物名
        public string SealNumber { get; set; }//施封号码
        public decimal TransportationFee { get; set; }//运输费
        public int OrderID { get; set; }//货运单Id
        public string ContainerType { get; set; }//集装箱箱型
        public string ContainerCatgory { get; set; }//集装箱箱类
        public string ContainerNumber { get; set; }//集装箱号码
        public int Amount { get; set; }//集装箱数量
        public WayBill wayBill{ get; set; }
    }
}
