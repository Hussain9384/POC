using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RmqLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RmqController : ControllerBase
    {
        private readonly IRmqService _rmqService;
        private IConfiguration _configuration { set; get; }
        public RmqController(IConfiguration configuration , IRmqService rmqService)
        {
            _configuration = configuration;
            _rmqService = rmqService;
        }

        [HttpGet("Publish")]
        public bool Publish(int input,string routingKey)
        {

            //IModel _channel = null;
            //var rabbitMqConn = _configuration.GetSection("RabbitMqConn").Value;
            //if (!string.IsNullOrWhiteSpace(rabbitMqConn))
            //{
            //    ConnectionFactory _connectionFactory = new ConnectionFactory() { Uri = new Uri(rabbitMqConn) }; //"amqp://guest:guest@localhost:5672"
            //    var connection = _connectionFactory.CreateConnection();
            //    _channel = connection.CreateModel();
            //    _channel.QueueDeclare(queue: "Demo-Queue", durable: true, exclusive: false, autoDelete: false, arguments: null);

            //    var message = new { Name = "Producer", Message = "Hello" };

            //    var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            //    _channel.BasicPublish("", "Demo-Queue", null, body);

            //}
            _rmqService.Publish(input, routingKey);

            return true;
        }

        [HttpGet("Consume")]
        public bool Consume()
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

            return true;

        }

    }
}
