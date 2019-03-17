using System;
using Xan.TotalWarhammerMaxLevel.Generator.Tsv;
using Xan.TotalWarhammerMaxLevel.Generator.Xml;

namespace Xan.TotalWarhammerMaxLevel.Generator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var db = new Database(@"e:\games\steam\steamapps\common\Total War WARHAMMER II\assembly_kit\raw_data\db\");
            var modGenerator = new ModGenerator(db, Environment.CurrentDirectory);

            modGenerator.Generate();

            Console.WriteLine("Finished, press any key to exit ...");
            Console.Read();
        }
    }
}
