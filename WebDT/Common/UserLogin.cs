﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDT.Common
{
    [Serializable]
    public class UserLogin
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
    }
}