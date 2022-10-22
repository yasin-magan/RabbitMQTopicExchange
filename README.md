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

<h5> Two Importantant things to avoid when using Topic Exchange</h5>

  1. <p> when try binding key '#' to catch all the messages in the topic exchange, the the bevabior is typical Fanout Exchange (why not use Fanout Exchange) </p>
  2. <p> when none of the binding keys use wildcards the bevabior is typical Direct Exchange (why not use Direct Exchange)</p>

<h5> Project setup </h5>
1. for the the three solutions , install there packages
<code>
   I. install-package microsoft.entityframeworkcore.sqlserver
   II. install-package Microsoft.EntityFrameworkCore.InMemory
   II.   Install-Package RabbitMQ.Client
 </code>
2. Change the connection to your host and user name and password
 <code>
 factory.Uri = new Uri("amqp://user:password@localhost:5672");
  </code>
3. <p>Fireup the CargoShipment Solution,  then other two applictions</p>
4. <p> Post Product on the CargoShipment API and include the Address Malaysia e.g "Malaysia.Selangor"  then post the product </p>
5. <p> The middleWare Application will listen to the broker and upon receiving message will post the product to the respective courier delivery </p>
6. <p> On Cargoshipment.Currier project API click get all products , you will see the new product of Address Malaysia.* routing key added to the database </p>

