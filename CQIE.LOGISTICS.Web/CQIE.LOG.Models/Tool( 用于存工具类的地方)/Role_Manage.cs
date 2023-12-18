using System;
using System.Collections.Generic;
using System.Text;

namespace CQIE.LOG.Models.Tool
{
    public class Role_Manage
    {
        /// <summary>
        /// 这个类是接受我修改角色权限的信息的类
        /// </summary>
        public int value { get; set; }
        public string title { get; set; }
        public bool disabled { get; set; }
        public bool @checked { get; set; }
    }
}
