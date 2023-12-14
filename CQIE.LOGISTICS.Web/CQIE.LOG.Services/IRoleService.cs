using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CQIE.LOG.Services
{
    public interface IRoleService
    {
        public Task<List<object>> Get_All_Role_ListAsync(int Page, int Limit, string name);
        public Task<List<object>> Get_By_NameAsync(int Page, int Limit, string name);
        public Task<object> Get_By_IdAsync(int id);
        public Task<string> Save_Update_RoleAsync(CQIE.LOG.Models.Identity.SysRole role);
        public Task<string> Save_Del_RoleAsync(int id);
        public Task<string> Save_Add_RoleAsync(CQIE.LOG.Models.Identity.SysRole role);
        public Task<string> Get_Role_Manage_InitAsync(int id);
        public Task<string> Save_Role_Manage_EditAsync(List<CQIE.LOG.Models.Tool.Role_Manage> list, int rid);
        public Task<string> Get_Role_Operation_InitAsync(int id);
        public Task<string> Save_Role_Operation_EditAsync(List<CQIE.LOG.Models.Tool.Role_Manage> list, int rid);
    }
}
