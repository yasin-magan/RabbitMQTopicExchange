# RabbitMQ Topic Exchange Implementation in .NET 6
<p> Topic Exchange are ideal to use in scenarios whereby  some background task will permformed based on the message received as well as logging events or any messaging that involve categorization</p>
<p> To enable RabbitMQ Management </p>
<code>
 
  rabbitmq-plugins enable rabbitmq_management
  </code>
  
<p> Cennection Code</p>
<code>
var factory = new ConnectionFactory();
factory.Uri = new Uri("amqp://user:password@localhost:5672");
var connection = factory.CreateConnection();
var channel = connection.CreateModel();

// declare resources here,  events .....
 
channel.Close();
connection.Close();
  </code>

