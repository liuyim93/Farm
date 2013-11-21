using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Advise
    {
        public int AdviseID { get; set; }
        public string RealName { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public DateTime LoadTime { get; set; }
    }
}
