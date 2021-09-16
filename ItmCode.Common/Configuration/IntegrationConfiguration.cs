using System;
using System.Collections.Generic;
using System.Text;

namespace ItmCode.Common.Configuration
{
    public class IntegrationConfiguration
    {

        public string EndpointUrl { get; set; }
        public string ClientId { get; set; }
        public string Secret { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Url { get; set; }
        public bool WhiteListRequired { get; set; }
    }
}
