using System;
using System.Collections;
using System.Collections.Generic;

namespace ItmCode.Common.Configuration
{
    public class Queue
    {
        public string Name { get; set; }
        public HashSet<string> RoutingKeys { get; set; }
    }

    public class RabbitMqQueuesConfiguration
    {
        // public string BusinessObjects { get; set; }
        // public string Clients { get; set; }
        //  public string Devices { get; set; }
        //  public string SimCards { get; set; }

        public bool AutoDelete { get; set; }
        public string DeadLetterExchange { get; set; }
        public bool Durable { get; set; }
        public string ExchangeName { get; set; }
        public Queue[] Queues { get; set; }
        public bool RequeueFailedMessages { get; set; }
        public string Type { get; set; }
    }
}