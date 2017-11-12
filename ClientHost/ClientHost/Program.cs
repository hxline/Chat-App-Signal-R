using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting client  http://localhost:8089");
            IHubProxy _hub;
            string url = @"http://localhost:8080/";
            var connection = new HubConnection(url);
            _hub = connection.CreateHubProxy("MyHub");
            connection.Start().Wait();

            _hub.On("addMessage", x => Console.WriteLine(x));

            string line = null;
            while ((line = System.Console.ReadLine()) != null)
            {
                _hub.Invoke("Send", line).Wait();
            }

            Console.Read();
        }
    }
}
