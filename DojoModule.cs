using Nancy;
using System;
using System.Collections.Generic;
using DBConnection;

namespace dojo1
{
    
    public class DojoModule : NancyModule
    {  
        public DojoModule()
        {
            Get("/", args => 
            {
                return View["dojo.sshtml"];
            });

            Post("/quotes", args =>
            {
                Console.WriteLine("****************************");
                Console.WriteLine("quotes route check");
                Console.WriteLine("****************************");

                string NAME = Request.Form["NAME"];
                string Quote = Request.Form["Quote"];
                Console.WriteLine("****************************");
                Console.WriteLine("Creating A New User");
                Console.WriteLine("****************************");
                
                string query = $"INSERT INTO users (NAME, Quote, created_at) VALUES('{NAME}', '{Quote}', NOW())";
                DbConnector.ExecuteQuery(query);

                return Response.AsRedirect("/quotes");
        });

            Get("/quotes", args =>
            {
                ViewBag.NAME = "";
                ViewBag.Quote = "";
                ViewBag.created_at = "";
                ViewBag.MyMessageToUsers = "Hello from me.";

                List<Dictionary<string, object>> myresults = DbConnector.ExecuteQuery("SELECT * FROM users");
                foreach (Dictionary<string, object> item in myresults)
                {
                    Console.WriteLine(item["id"] + " " + item["NAME"] + " " + item["Quote"] +  " " + item["created_at"]);
                    @ViewBag.NAME += item["NAME"];
                }

                return View["quotes.sshtml", myresults];
            });
        }
    }
}