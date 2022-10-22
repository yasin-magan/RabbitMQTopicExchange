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
</code>
  
 <p> Declare resources here,  events .....</p>
 <code>
channel.Close();
connection.Close();
</code>

<h3> Two Importantant things to avoid when using Topic Exchange</h3>

  1. <p> when try binding key '#' to catch all the messages in the topic exchange, the the bevabior is typical Fanout Exchange (why not use Fanout Exchange) </p>
  2. <p> when none of the binding keys use wildcards the bevabior is typical Direct Exchange (why not use Direct Exchange)</p>

