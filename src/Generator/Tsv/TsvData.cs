using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Xan.TotalWarhammerMaxLevel.Generator.Tsv
{
    public class TsvData : List<string[]>
    {
        public string TableName { get; set; }

        public string Value { get; set; } = "2";

        public void Save(string directoryName)
        {
            var path = Path.Combine(directoryName, $"{TableName}_tables.tsv");
            using (var streamWriter = new StreamWriter(path, false, Encoding.UTF8))
            {
                streamWriter.WriteLine($"{TableName}_tables");
                streamWriter.WriteLine(Value);

                var config = new Configuration
                {
                    Delimiter = "\t"
                };
                var csv = new CsvWriter(streamWriter, config);
                foreach (var line in this)
                {
                    foreach (var field in line)
                    {
                        csv.WriteField(field);
                    }
                    csv.NextRecord();
                }
            }
        }
    }
}
