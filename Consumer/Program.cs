using System;
using System.Text;
using RabbitMQ.Client;

namespace Consumer {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(">>>> Customer");
            var connectionFactory = new ConnectionFactory();
            IConnection connection = connectionFactory.CreateConnection();
            IModel channel = connection.CreateModel();
            channel.QueueDeclare("hello-world-queue", false, false, false, null);
            BasicGetResult result = channel.BasicGet("hello-world-queue", true);
            if (result != null) {
                string message = Encoding.UTF8.GetString(result.Body);
                Console.WriteLine(message);
            }
            channel.Close();
            connection.Close();
        }
    }
}
