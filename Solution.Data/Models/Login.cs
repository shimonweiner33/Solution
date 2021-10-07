using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.Data.Models
{
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
