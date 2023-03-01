using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.IO;
using WinS7Library.Files;
using WinS7Library.Interfaces;

namespace WinS7Library.Helper
{
    public class ProcessDataExcelExporter : IProcessDataExporter
    {
        public IFileContainer Create(object data, string path, string fileName)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string filePath = Path.Combine(path, fileName);

            if (File.Exists(filePath) == false)
            {
                var bytes = GenerateExcel(data);

                return new MemoryFileContainer(fileName, bytes);
            }
            else
            {
                var bytes = AppendExcel(data, filePath);

                return new MemoryFileContainer(fileName, bytes);
            }
        }

        private static byte[] GenerateExcel(object data)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("ProcessData");

                SetProcessDataHeader(worksheet);

                SetProcessData(worksheet);

                return excelPackage.GetAsByteArray();
            }
        }

        private static byte[] AppendExcel(object data, string filePath) 
        {
            FileInfo file = new FileInfo(filePath);

            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet;

                if (excelPackage.Workbook.Worksheets["ProcessData"] == null)
                {
                    worksheet = excelPackage.Workbook.Worksheets.Add("ProcessData");
                    SetProcessDataHeader(worksheet);
                }
                else
                {
                    worksheet = excelPackage.Workbook.Worksheets["ProcessData"];
                }

                SetProcessData(worksheet);

                return excelPackage.GetAsByteArray();
            }
        }

        private static void SetProcessDataHeader(ExcelWorksheet worksheet)
        {
            var col = 0;

            col++;
            worksheet.Cells[1, col].Value = "Datum/Uhrzeit";
            col++;
            worksheet.Cells[1, col].Value = "Produktname";
            col++;
            worksheet.Cells[1, col].Value = "DMX-Code 1";
        }

        private static void SetProcessData(ExcelWorksheet worksheet)
        {
            var rowOffset = worksheet.Dimension.End.Row + 1;

            var col = 0;

            col++;
            worksheet.Cells[rowOffset, col].Value = $"{DateTime.Now:yyyy-MM-dd+HH:mm:ss}";  //2023-02-27+07:34:35
            col++;
            worksheet.Cells[rowOffset, col].Value = "29050 BMW G70 Topf HA";
            col++;
            worksheet.Cells[rowOffset, col].Value = "HHAR0120301#Df#121912#T05223#S0008022#N01#LA6402119";

            SetDataStyle(worksheet);
        }

        private static void SetDataStyle(ExcelWorksheet worksheet)
        {
            var rowCount = worksheet.Dimension.Rows;
            var colCount = worksheet.Dimension.Columns;
            worksheet.Cells[1, 1, rowCount, colCount].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            worksheet.Cells[1, 1, rowCount, colCount].AutoFitColumns();
        }
    }
}
