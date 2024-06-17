namespace cuentamovimiento.Services
{
    using Confluent.Kafka;
    using Microsoft.Extensions.Hosting;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class KafkaProducerService : IHostedService
    {
        private readonly IProducer<Null, string> _producer;

        public KafkaProducerService(ProducerConfig config)
        {
            _producer = new ProducerBuilder<Null, string>(config).Build();
        }

        public async Task ProduceAsync(string topic, string message)
        {
            await _producer.ProduceAsync(topic, new Message<Null, string> { Value = message });
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Implementa lógica de inicio si es necesario
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            // Implementa lógica de parada si es necesario
            return Task.CompletedTask;
        }
    }

}
