using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using WinS7Library.Files;
using WinS7Library.Interfaces;

namespace WinS7Library.Helper
{
    public class ProcessDataCsvExporter
    {
        protected CsvConfiguration CsvConfigCreate => new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = ";", Encoding = Encoding.UTF8 };
        protected CsvConfiguration CsvConfigAppend => new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = ";", Encoding = Encoding.UTF8, HasHeaderRecord = false };

        public void Create(object data, string path, string fileName)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string filePath = Path.Combine(path, fileName);

            if (File.Exists(filePath) == false)
            {
                GenerateCsv(data, filePath);

            }
            else
            {
                AppendCsv(data, filePath);
            }
        }

        private void GenerateCsv(object data, string filePath)
        {
            var records = new List<object>
            {
                new { Id = 1, Name = "Name" , BoolVar = true},
            };
           
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CsvConfigCreate))
            {
                csv.WriteRecords(records);
            }
        }

        private void AppendCsv(object data, string filePath)
        {
            var records = new List<object>
            {
                new { Id = 1, Name = "Name" , BoolVar = true},
            };

            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CsvConfigAppend))
            {
                csv.WriteRecords(records);
            }
        }
    }
}
