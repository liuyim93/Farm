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
        public string Password { get; set; }
        public int IsSuperAdmin { get; set; }
    }
}
