using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://wylxhthv:9gEUm_Hi-PGavdDsheGhvL106sliPAi5@shark.rmq.cloudamqp.com/wylxhthv ");

using var connection = factory.CreateConnection();
var channel = connection.CreateModel();

channel.ExchangeDeclare("logs-direct", durable: true, type: ExchangeType.Direct);


Enum.GetNames(typeof(LogNames)).ToList().ForEach(x =>
{
    var routeKey = $"route-{x}";
    var queueName = $"direct-queue-{x}";

    channel.QueueDeclare(queueName, true, false, false);
    channel.QueueBind(queueName, "logs-direct", routeKey, null);
});

Enumerable.Range(1, 50).ToList().ForEach(x =>
{
    LogNames log = (LogNames)new Random().Next(1, 5);
    string message = $"log-type: {log}";

    var messageBody = Encoding.UTF8.GetBytes(message);
    var routeKey = $"route-{log}";

    channel.BasicPublish("logs-direct", routeKey, null, messageBody);
    Console.WriteLine($"Log gönderildi: {message}");
});


public enum LogNames
{
    Critical = 1,
    Error = 2,
    Warning = 3,
    Info = 4
}


//Eren Çiçek
//Bu proje serisi RabbitMQ mesaj kuyruk sistemini daha iyi anlamak için yapılmıştır