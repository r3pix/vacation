using System;
using System.Collections.Generic;
using System.Text;

namespace ItmCode.Common.Configuration
{
    public class EmailConfiguration
    {
        public bool EnableSSL { get; set; }
        public string Host { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
    }
}
