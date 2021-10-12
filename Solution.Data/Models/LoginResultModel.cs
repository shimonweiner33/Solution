﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.Data.Models
{
    public class LoginResultModel
    {
        public Member Member { get; set; }
        //public ExtendMember Member { get; set; }
        public bool IsUserAuth { get; set; }
        public string Error { get; set; }

        public LoginResultModel()
        {
            IsUserAuth = false;
        }
    }
}
