namespace cuentamovimiento.Config
{

using Confluent.Kafka;
    using cuentamovimiento.Services;
    using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

public static class KafkaConsumerConfig
    {
        public static void AddKafkaConsumer(this IServiceCollection services)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "grupoId",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            services.AddSingleton(config);
            services.AddHostedService<KafkaConsumerService>();
        }
    }

}
