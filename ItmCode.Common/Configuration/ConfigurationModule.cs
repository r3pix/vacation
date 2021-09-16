using Autofac;
using Microsoft.Extensions.Configuration;

namespace ItmCode.Common.Configuration
{
    public class ConfigurationModule : Module
    {
        private readonly IConfiguration _configuration;

        public ConfigurationModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            //builder.Register(_ => _configuration.GetSection("JwtConfiguration").Get<JwtConfiguration>()).AsSelf().SingleInstance();
            //builder.Register(_ => _configuration.GetSection("DefaultValues").Get<DefaultValuesConfiguration>()).AsSelf().SingleInstance();
            //builder.Register(_ => _configuration.GetSection("IdentityRoles").Get<IdentityRoles>()).AsSelf().SingleInstance();
            //builder.Register(_ => _configuration.GetSection("Environment").Get<EnvironmentConfiguration>()).AsSelf().SingleInstance();
            //builder.Register(_ => _configuration.GetSection("OrderTypesIds").Get<OrderTypesIdsConfiguration>()).AsSelf().SingleInstance();
            //builder.Register(_ => _configuration.GetSection("EmailServer").Get<EmailConfiguration>()).AsSelf().SingleInstance();
            //builder.Register(_ => _configuration.GetSection("CreateAccountOptions").Get<CreateAccountOptions>()).AsSelf().SingleInstance();
            //builder.Register(_ => _configuration.GetSection("HangfireJobs").Get<HangfireJobsConfig>()).AsSelf().SingleInstance();
            builder.Register(_ => _configuration.GetSection("Gus").Get<GusConfiguration>()).AsSelf().SingleInstance();
            builder.Register(_ => _configuration.GetSection("Weight").Get<WeightConfiguration>()).AsSelf().SingleInstance();
            builder.Register(_ => _configuration.GetSection("FileUpload").Get<FileConfiguration>()).AsSelf().SingleInstance();
            builder.Register(_ => _configuration.GetSection("Integration").Get<IntegrationConfiguration>()).AsSelf().SingleInstance();
            builder.Register(_ => _configuration.GetSection("PDFDocument").Get<PDFDocumentsConfiguration>()).AsSelf().SingleInstance();

            //builder.Register(_ => _configuration.GetSection("CSV").Get<CsvColumnConfiguration>()).AsSelf().SingleInstance();

            //builder.Register(_ => _configuration.GetSection("Itms").Get<ItmsConfiguration>()).AsSelf().SingleInstance();
            //builder.Register(_ => _configuration.GetSection("Itms").GetSection("RabbitMqQueues").Get<RabbitMqQueuesConfiguration>())
            //    .AsSelf().SingleInstance();
            //builder.Register(_ => _configuration.GetSection("Itms").GetSection("RabbitMqConfig").Get<RabbitMqConfig>())
            //    .AsSelf().SingleInstance();
            //builder.Register(_ => _configuration.GetSection("Itms").GetSection("RabbitMqQueuesNames").Get<RabbitMqQueuesNamesConfiguration>())
            //    .AsSelf().SingleInstance();
        }
    }
}