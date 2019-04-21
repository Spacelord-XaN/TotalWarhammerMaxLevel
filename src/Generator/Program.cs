using System;
using System.IO;
using System.Linq;
using Xan.TotalWarhammerMaxLevel.Generator.Tsv;
using Xan.TotalWarhammerMaxLevel.Generator.Xml;

namespace Xan.TotalWarhammerMaxLevel.Generator
{
    public class Program
    {
        private const string _generateCommand = "generate";
        private const string _infoCommand = "info";
        private const string _helpCommand = "help";

        public static void Main(string[] args)
        {
            var command = args.Length > 0 ? args[0] : _helpCommand;
            var assemblyKitPath = args.Length > 1 ? args[1] : "";

            if (command == _helpCommand)
            {
                Console.WriteLine("Usage: command [path_to_assembly_kit]");
                Console.WriteLine(_generateCommand);
                Console.WriteLine(_infoCommand);
                Console.Read();
                return;
            }

            if (!Directory.Exists(assemblyKitPath))
            {
                Console.WriteLine($"Path to assebmly kit {assemblyKitPath} does not exist");
                Console.Read();
                return;
            }

            var db = new Database(assemblyKitPath);
            if (command == _generateCommand)
            {
                var modGenerator = new ModGenerator(db, Environment.CurrentDirectory);
                modGenerator.Generate();
                Console.WriteLine("Generated mod");
                return;
            }
            if (command == _infoCommand)
            {
                var map = db.GetMaxLevelPerAgentTypeDetailed();
                foreach (var agentType in map)
                {
                    Console.WriteLine($"========== {agentType.Key} ==========");
                    foreach (var points in agentType.Value.OrderBy(x => x.Key))
                    {
                        Console.Write($"{points.Key} count: {points.Value.Count}");
                        if (points.Value.Count == 1)
                        {
                            Console.Write($" - {points.Value.First().key}");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }

                Console.WriteLine("Finished, press any key to exit ...");
                Console.Read();
            }

            Console.WriteLine("Something in the args wasn't good");
        }
    }
}
