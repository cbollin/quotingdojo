using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System;
using DBConnection;

namespace dojo1
{
    public class Program
    {
        public static void Create()
        {
            // Console.WriteLine("Creating A New User");
            // Console.Write("Enter name: ");
            // string NAME = Console.ReadLine();
            // Console.Write("Enter quote: ");
            // string Quote = Console.ReadLine();
            // string query = $"INSERT INTO users (NAME, Quote, created_at) VALUES('{NAME}', '{Quote}', NOW())";
            // DbConnector.ExecuteQuery(query);
        }

        public static void Read()
        {
            // List<Dictionary<string, object>> myresults = DbConnector.ExecuteQuery("SELECT * FROM users");
            // foreach (Dictionary<string, object> item in myresults)
            // {
            //     Console.WriteLine(item["id"] + " " + item["NAME"] + " " + item["Quote"] +  " " + item["created_at"]);
            // }
        }

        public static void Update()
        {
            Console.WriteLine("Enter ID of user you wish to update:  ");
            string userId = Console.ReadLine();
            int user_id = Int32.Parse(userId);
            Console.WriteLine("Update user's first name: ");
            string NAME = Console.ReadLine();
            Console.WriteLine("Update user's quote: ");
            string Quote = Console.ReadLine();
            string query = $"UPDATE users SET Name = '{NAME}', Quote = '{Quote}', updated_at = NOW() WHERE id = {user_id}";
            DbConnector.ExecuteQuery(query);
            Console.WriteLine($"{NAME}'s info has been updated!");
        }

        public static void Destroy()
        {
            Console.WriteLine("Enter ID of user you wish to delete:  ");
            string userId = Console.ReadLine();
            int user_id = Int32.Parse(userId);
            string query = $"DELETE FROM users WHERE id = {user_id}";
            DbConnector.ExecuteQuery(query);
            Console.WriteLine($"A user has been deleted!");
        }
        public static void Main(string[] args)
        {
            // Create();
            // Read();
            // Update();
            // Destroy();

            IWebHost host = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();
            host.Run();
        }
    }
}