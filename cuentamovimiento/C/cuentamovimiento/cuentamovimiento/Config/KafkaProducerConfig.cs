namespace cuentamovimiento.Config
{

using Confluent.Kafka;
    using cuentamovimiento.Services;
    using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

public static  class KafkaProducerConfig
    {
        public static void AddKafkaProducer(this IServiceCollection services)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };

            services.AddSingleton(config);
            services.AddSingleton<IHostedService, KafkaProducerService>();
        }
    }

}
