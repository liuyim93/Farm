using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Admin
    {
        public int AdminID { get; set; }
        public string UserName { get; set; }
        public string password { get; set; }
        public int IsSuperAdmin { get; set; }
        public string Remark { get; set; }
    }
}
