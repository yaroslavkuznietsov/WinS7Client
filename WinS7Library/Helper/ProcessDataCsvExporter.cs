using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using WinS7Library.Model.Export;

namespace WinS7Library.Helper
{
    /// <summary>
    /// Implementation based on CsvHelper NuGet Package
    /// https://joshclose.github.io/CsvHelper/
    /// </summary>
    public class ProcessDataCsvExporter
    {
        protected CsvConfiguration CsvConfigCreate => 
            new CsvConfiguration(CultureInfo.CurrentCulture) 
            { 
                Delimiter = ";",
                Encoding = Encoding.UTF8,
            };
        protected CsvConfiguration CsvConfigAppend => 
            new CsvConfiguration(CultureInfo.CurrentCulture) 
            { 
                Delimiter = ";",
                Encoding = Encoding.UTF8,
                HasHeaderRecord = false,
            };

        public void Create<T>( T data, string path, string fileName)
        {
            var type = typeof(T);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string filePath = Path.Combine(path, fileName);

            if (File.Exists(filePath) == false || type == typeof(ProcessDataSqlDb))
            {
                GenerateCsv(data, filePath);
            }
            else
            {
                AppendCsv(data, filePath);
            }
        }

        private void GenerateCsv<T>(T data, string filePath)
        {
            var records = new List<T>
            {
                data,
            };
           
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CsvConfigCreate))
            {
                csv.WriteRecords(records);
            }
        }

        private void AppendCsv<T>(T data, string filePath)
        {
            var records = new List<T>
            {
                data,
            };

            using (var stream = File.Open(filePath, FileMode.Append))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer, CsvConfigAppend))
            {
                csv.WriteRecords(records);
            }
        }
    }
}
