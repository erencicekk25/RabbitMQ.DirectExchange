# RabbitMQ.DirectExchange
🐇Merhabalar bu projede RabbitMQ mesaj kuyruk sisteminde Direct Exchange'i  .Net 7 Console App üzerinden inceledik.


## Çalıştırma

RabbitMQ bağlantı adresi koda gömülü değil, `RABBITMQ_URI` ortam değişkeninden okunuyor. Değişken tanımlı değilse yerelde çalışan bir RabbitMQ sunucusuna (`amqp://guest:guest@localhost:5672`) bağlanılır.

```bash
# Yerelde RabbitMQ ayağa kaldırmak için
docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management

# CloudAMQP gibi uzak bir sunucu kullanacaksanız
export RABBITMQ_URI="amqps://kullanici:parola@sunucu/vhost"   # PowerShell: $env:RABBITMQ_URI="..."
```
