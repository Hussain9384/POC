using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RmqLibrary
{
    public class Worker : IWorker
    {
        private readonly IRmqService _rmqService;
        private readonly IConfiguration _configuration;

        public Worker(IConfiguration configuration,IRmqService rmqService)
        {
            _configuration = configuration;
            _rmqService = rmqService;
            //_rmqService = rmqService;
        }

        public Task DoWork(CancellationToken cancellationToken)
        {
            //IModel _channel = null;
            //var rabbitMqConn = _configuration.GetSection("RabbitMqConn").Value;
            //if (!string.IsNullOrWhiteSpace(rabbitMqConn))
            //{
            //    ConnectionFactory _connectionFactory = new ConnectionFactory() { Uri = new Uri(rabbitMqConn) }; //"amqp://guest:guest@localhost:5672"
            //    var connection = _connectionFactory.CreateConnection();
            //    _channel = connection.CreateModel();
            //    _channel.QueueDeclare(queue: "Demo-Queue", durable: true, exclusive: false, autoDelete: false, arguments: null);
            //    var consumer = new EventingBasicConsumer(_channel);
            //    consumer.Received += (sender, e) =>
            //    {
            //        var body = e.Body.ToArray();
            //        var message = Encoding.UTF8.GetString(body);
            //        Console.WriteLine("Consumer :" + message);
            //    };

            //    _channel.BasicConsume("Demo-Queue", true, consumer);
            //}


            _rmqService.Consume();
            return Task.CompletedTask;
        }
    }
}
