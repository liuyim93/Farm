using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class News
    {
        public int NewsID { get; set; }
        public string Title { get; set; }
        public int NewsTypeID { get; set; }
        public string Author { get; set; }
        public int AdminID { get; set; }
        public string Detail { get; set; }
        public DateTime LoadTime { get; set; }
    }
}
