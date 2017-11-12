using System;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;

namespace ServerHost
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://192.168.10.62:5000";
            using (WebApp.Start(url))
            {
                Console.WriteLine("Server running on {0}", url);
                Console.ReadLine();
            }
        }
    }




}
