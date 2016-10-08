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
                @ViewBag.quotes = "";
                List<Dictionary<string, object>> myresults = DbConnector.ExecuteQuery("SELECT * FROM users");
                myresults.Reverse();
                foreach (Dictionary<string, object> item in myresults)
                {
                    @ViewBag.quotes += "<p>" + item["Quote"] + " " + "<br>" + "-" + item["NAME"] + " " + item["created_at"] + "</p>" + "<hr>";
                }

                return View["quotes.sshtml", myresults];
            });
        }
    }
}