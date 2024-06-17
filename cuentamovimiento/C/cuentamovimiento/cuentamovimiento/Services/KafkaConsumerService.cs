namespace cuentamovimiento.Services
{
    using Confluent.Kafka;
    using Microsoft.Extensions.Hosting;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class KafkaConsumerService : BackgroundService
    {
        private readonly ConsumerConfig _config;

        public KafkaConsumerService(ConsumerConfig config)
        {
            _config = config;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Run(() =>
            {
                using var consumer = new ConsumerBuilder<Ignore, string>(_config).Build();
                consumer.Subscribe("miTema");

                while (!stoppingToken.IsCancellationRequested)
                {
                    var consumeResult = consumer.Consume(stoppingToken);
                    Console.WriteLine($"Mensaje recibido: {consumeResult.Message.Value}");
                }

                consumer.Close();
            }, stoppingToken);
        }
    }

























}
