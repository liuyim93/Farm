using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ImageType
    {
        public int ImgTypeID { get; set; }
        public string TypeName { get; set; }
        public int IsShow { get; set; }
        public int ParentID { get; set; }
        public string Remark { get; set; }
        public int Rank { get; set; }
    }
}
