using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module1313
{
    public class Client
    {
        public int Id { get; }
        public string Name { get; set; }
        public string ServiceType { get; set; }

        public Client(int id, string name, string serviceType)
        {
            Id = id;
            Name = name;
            ServiceType = serviceType;
        }

        public override string ToString()
        {
            return $"Client ID: {Id}, Name: {Name}, Service: {ServiceType}";
        }
    }
    class BankQueueSystem
    {
        private Queue<Client> queue = new Queue<Client>();
        private int nextId = 1;

        public void AddClientToQueue(string name, string serviceType)
        {
            var client = new Client(nextId++, name, serviceType);
            queue.Enqueue(client);
            Console.WriteLine($"Added to queue: {client}");
        }

        public void ServeClient()
        {
            if (queue.Count > 0)
            {
                var client = queue.Dequeue();
                Console.WriteLine($"Now serving: {client}");
            }
            else
            {
                Console.WriteLine("No clients in the queue.");
            }
        }

        public void DisplayQueue()
        {
            if (queue.Count == 0)
            {
                Console.WriteLine("Queue is empty.");
                return;
            }

            Console.WriteLine("Current queue:");
            foreach (var client in queue)
            {
                Console.WriteLine(client);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var bankQueueSystem = new BankQueueSystem();

            while (true)
            {
                Console.WriteLine("1. Add client to queue");
                Console.WriteLine("2. Serve client");
                Console.WriteLine("3. Display queue");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");

                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.Write("Enter client name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter service type: ");
                        string serviceType = Console.ReadLine();
                        bankQueueSystem.AddClientToQueue(name, serviceType);
                        break;

                    case 2:
                        bankQueueSystem.ServeClient();
                        break;

                    case 3:
                        bankQueueSystem.DisplayQueue();
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
            Console.ReadKey();
        }
    }

}