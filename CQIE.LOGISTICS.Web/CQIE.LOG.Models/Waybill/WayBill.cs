using System;
using System.Collections.Generic;
using System.Text;

namespace CQIE.LOG.Models.Waybill
{
    public class WayBill
    {
        public int Id { get; set; }
        public string DepartureStation { get; set; }//发站
        public string ArrivalStation { get; set; }//到站
        public string ProvinceOfArrivalStation { get; set; }//到站所属市
        public string ShippingLocation { get; set; }//发货地点
        public string DeliveryLocation { get; set; }//交货地点
        public string AttachedDocuments { get; set; }//托运人记载事项
        public decimal GoodsPrice { get; set; }//添付文件
        public string CarrierRemarks { get; set; }//货物价格
        public int ShipperID { get; set; }//托运人id
        public int ConsigneeID { get; set; }//收货人Id
        public int Status { get; set; }//状态
        public List<GoodsInfo> goodsInfos { get; set; }//一个货运单中可以有多个货物信息
        public Delivery.Delivery_Order Delivery { get; set; }//1对1
        public ShipperConsigneeInfo ShipperConsigneeInfo { get; set; }//货运单和托运人/收货人是一对一的关系
    }
}
