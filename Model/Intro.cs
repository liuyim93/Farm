﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Intro
    {
        public int IntroID { get; set; }
        public string Detail { get; set; }
        public int IntroTypeID { get; set; }
        public DateTime LoadTime { get; set; }
        public string IntroType { get; set; }
    }
}
