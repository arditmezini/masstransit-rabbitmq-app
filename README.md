# A Broker Service RabbitMQ with MassTransit and Log4Net

This project is composed by a Console Application and Window Service.

### Console Application
 The console app is used to send the commands to the RabbitMQ Server.
 
### Windows Service
 The windows service build with TopShelf consumes the commands from the RabbitMQ Server.
 
#### To test the full cycle, you need:
 1. Have installed [Erlang](https://www.erlang.org/downloads "Erlang") and [RabbitMQ](https://www.rabbitmq.com/download.html "RabbitMQ")
 2. The configuration for RabbitMQ server are in the Common project, file appsettings.json.
