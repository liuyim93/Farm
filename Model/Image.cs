using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Image
    {
        public int ImgID { get; set; }
        public string ImgName { get; set; }
        public string ImgUrl { get; set; }
        public int AdminID { get; set; }
        public int ImgTypeID { get; set; }
        public int IsShow { get; set; }
        public string Remark { get; set; }
        public DateTime LoadTime { get; set; }
        public int IsHomeTopShow { get; set; }
        public string LinkUrl { get; set; }
        public int IsHomeBottomShow { get; set; }
    }
}
