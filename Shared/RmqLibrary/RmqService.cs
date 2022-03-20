using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RmqLibrary
{
    public class RmqService : IRmqService
    {
        private readonly IConfiguration _configuration;

        private ConnectionFactory _connectionFactory { get; set; }
        private IModel _channel { get; set; }
        public RmqService(IConfiguration configuration)
        {
            _configuration = configuration;
            var rabbitMqConn = _configuration.GetSection("RabbitMqConn").Value;
            if (!string.IsNullOrWhiteSpace(rabbitMqConn))
            {
                _connectionFactory = new ConnectionFactory() { Uri = new Uri(rabbitMqConn) };
                 var connection = _connectionFactory.CreateConnection();
                _channel = connection.CreateModel();
                _channel.QueueDeclare(queue: "User-Queue", durable: true, exclusive: false, autoDelete: false, arguments: null);
                _channel.QueueDeclare(queue: "Notify-Queue", durable: true, exclusive: false, autoDelete: false, arguments: null);
                _channel.ExchangeDeclare("Demo-Ex", "topic", true, false);
                _channel.QueueBind("User-Queue", "Demo-Ex", "User.*");
                _channel.QueueBind("Notify-Queue", "Demo-Ex", "Notify.Res.*");
                _channel.QueueBind("Notify-Queue", "Demo-Ex", "Notify.User.*");
            }

        }

        public void Publish(int mode,string routingKey)
        {
            var message = new { Name = "Producer", Message = "Hello" };

            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
                    _channel.BasicPublish("Demo-Ex", routingKey, null, body);    

        }

        public void Consume()
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"User Queue Event : {e.RoutingKey} - {e.RoutingKey} {message}");
            };
            _channel.BasicConsume("User-Queue", true, consumer);

            var consumer1 = new EventingBasicConsumer(_channel);

            consumer1.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();

                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"Res Queue Event : {e.RoutingKey} - {e.RoutingKey} {message}");
            };

            _channel.BasicConsume("Res-Queue", true, consumer1);



            var consumer2 = new EventingBasicConsumer(_channel);

            consumer2.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();

                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"Notify Queue Event : {e.RoutingKey} - {e.RoutingKey} {message}");
            };

            _channel.BasicConsume("Notify-Queue", true, consumer2);
        }
    }
}
