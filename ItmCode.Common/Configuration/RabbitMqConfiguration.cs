using System;

namespace ItmCode.Common.Configuration
{
    public class RabbitMqConfiguration
    {
        public string CurrentUserId { get; set; }
        public bool Disabled { get; set; }
        public string HostName { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
    }
}