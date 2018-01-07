namespace Tools
{
    using AzureDatabase.Graph;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("          \\,,,/");
            Console.WriteLine("          (o o)");
            Console.WriteLine(" -----oOOo-(3)-oOOo-----");
            Console.WriteLine("");
            Console.WriteLine(" hacked by moonchoi");
            Console.WriteLine("");            

            string endpointUri = "https://[cosmosdbID].documents.azure.com:443/";
            string authKey = "[key]";
            string databaseId = "graphdb";
            string graphId = "Persons";

            Gremlin gremlin = new Gremlin(endpointUri, authKey, databaseId);

            try
            {
                Console.WriteLine("connection test...");
                Task<List<dynamic>> task = Task.Run(async () => await gremlin.GremlinQuery<dynamic>(graphId, "g.V()"));
                var test = task.Result;
                Console.WriteLine("connected!");
            }
            catch
            {
                Console.WriteLine("check your endpointURI, authKey, databaseId");
                return;
            }

            Console.Write("gremlin>");

            string strLine = string.Empty;
            while (true)
            {
                string line = Console.ReadLine();
                
                try
                {

                    Task<List<dynamic>> task = Task.Run(async () => await gremlin.GremlinQuery<dynamic>(graphId, line));
                    var result = task.Result;
                    string strJson = JsonConvert.SerializeObject(result);
                        
                    Console.WriteLine(strJson);
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.Write("gremlin>");
                line = "";
                
            }
            
        }
    }
}
