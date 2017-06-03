using System.Text;
using RabbitMQ.Client;
using System;

namespace Producer {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(">>>> Producer");
            var connectionFactory = new ConnectionFactory();
            IConnection connection = connectionFactory.CreateConnection();
            IModel channel = connection.CreateModel();
            channel.QueueDeclare("hello-world-queue", false, false, false, null);
            byte[] message = Encoding.UTF8.GetBytes("Producer's message ok!");
            channel.BasicPublish(string.Empty, "hello-world-queue", null, message);
            channel.Close();
            connection.Close();
        }
    }
}
