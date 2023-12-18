using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.LOG.Services
{
    public interface IUserService
    {
        public Task<DataTable> Get_All_User_DataTableAsync(int Page, int Limit, string name);
        public Task<List<object>> Get_All_User_ListAsync(int Page, int Limit, string name);
        public Task<List<object>> Get_By_NameAsync(int Page, int Limit, string name);
        public Task<object> Get_By_IdAsync(int id);
        public Task<string> Save_Update_UserAsync(CQIE.LOG.Models.Identity.SysUser user);
        public Task<string> Save_Del_UserAsync(int id);
        public Task<string> Save_Add_UserAsync(CQIE.LOG.Models.Identity.SysUser user);
    }
}
