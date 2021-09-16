using System;
using System.Collections.Generic;
using System.Text;

namespace ItmCode.Common.Configuration
{
    public class ContractDocumentsConfiguration
    {
        public string TemplatePath { get; set; }
        public string FinalPath { get; set; }
        public string NewSubscriptionTemplateName { get; set; }
        public string SubscriptionTransferTemplateName { get; set; }
        public string LimitChangeTemplateName { get; set; }
        public string AccessoryOrderTemplateName { get; set; }
        public string ExceedanceRemissionTemplateName { get; set; }

    }
}


