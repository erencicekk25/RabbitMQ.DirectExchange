﻿using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://wylxhthv:9gEUm_Hi-PGavdDsheGhvL106sliPAi5@shark.rmq.cloudamqp.com/wylxhthv ");

using var connection = factory.CreateConnection();
var channel = connection.CreateModel();

channel.BasicQos(0, 1, false);
var consumer = new EventingBasicConsumer(channel);

var queueName = "direct-queue-Critical";
channel.BasicConsume(queueName, false, consumer);

Console.WriteLine("Loglar dinleniyor...");

consumer.Received += (object sender, BasicDeliverEventArgs e) =>
{
    var message = Encoding.UTF8.GetString(e.Body.ToArray());
    Console.WriteLine($"Gelen mesaj: {message}");

    File.AppendAllText("log-critical.txt", message + "\n");
    channel.BasicAck(e.DeliveryTag, false);
};
Console.ReadLine();

//Eren Çiçek
//Bu proje serisi RabbitMQ mesaj kuyruk sistemini daha iyi anlamak için yapılmıştır.