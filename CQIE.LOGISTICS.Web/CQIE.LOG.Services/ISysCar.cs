using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.LOG.Services
{
    public interface ISysCar
    {
        public Task<List<object>> Get_All_Car_ListAsync(int Page, int Limit, string name);
        public Task<object> Get_By_Car_IdAsync(int id);
        public Task<string> Save_Update_CarAsync(CQIE.LOG.Models.Delivery.Car order);
        public Task<string> Save_Del_CarAsync(int id);
        public Task<string> Save_Add_CarAsync(CQIE.LOG.Models.Delivery.Car order);


        public Task<List<object>> Get_All_CarType_ListAsync(int Page, int Limit, string name);
        public Task<object> Get_By_CarType_IdAsync(int id);
        public Task<string> Save_Update_CarTypeAsync(CQIE.LOG.Models.Delivery.CarType order);
        public Task<string> Save_Del_CarTypeAsync(int id);
        public Task<string> Save_Add_CarTypeAsync(CQIE.LOG.Models.Delivery.CarType order);
    }
}
