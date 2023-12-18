using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.LOG.Services
{
    public interface ISysDelivery
    {
        public Task<List<object>> Get_All_Delivery_ListAsync(int Page, int Limit, string name);
        public Task<CQIE.LOG.Models.Tool.DelievryWaybillShipperVIewModel> Get_By_IdAsync(int id);
        public Task<string> Save_Update_DeliveryAsync(CQIE.LOG.Models.Delivery.Delivery_Order order);
        public Task<string> Save_Del_DeliveryAsync(int id);
        public Task<string> Save_Add_DeliveryAsync(CQIE.LOG.Models.Delivery.Delivery_Order order);

        public Task<CQIE.LOG.Models.Tool.CarTypeCarWaybillShipperUserModel> Edit_Init(int id);

        //public Task<List<object>> Get_All_DeliveryMan_ListAsync(int Page, int Limit, string name);
        //public Task<object> Get_By_DeliveryMan_IdAsync(int id);
        //public Task<string> Save_Update_DeliveryManAsync(CQIE.LOG.Models.Delivery.Delivery_Man order);
        //public Task<string> Save_Del_DeliveryManAsync(int id);
        //public Task<string> Save_Add_DeliveryManAsync(CQIE.LOG.Models.Delivery.Delivery_Man order);

    }
}
