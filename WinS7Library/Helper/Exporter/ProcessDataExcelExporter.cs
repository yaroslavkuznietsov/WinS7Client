using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using WinS7Library.Files;
using WinS7Library.Model.Export;
using WinS7Library.Results;

namespace WinS7Library.Helper.Exporter
{
    public class ProcessDataExcelExporter
    {
        public Result Create(ProcessDataPc data, string path, string fileName)
        {
            string filePath = Path.Combine(path, fileName);

            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                if (File.Exists(filePath) == false)
                {
                    var bytes = GenerateExcel(data);

                    var fileContainer = new MemoryFileContainer(fileName, bytes);

                    fileContainer.SaveTo(filePath);
                }
                else
                {
                    var bytes = AppendExcel(data, filePath);

                    var fileContainer = new MemoryFileContainer(fileName, bytes);

                    fileContainer.SaveTo(filePath);
                }

                return Result.SuccessWithParameter(filePath);
            }
            catch (Exception e)
            {
                return Result.ErrorWithParameter(filePath, e.Message);
            }
        }

        private static byte[] GenerateExcel(ProcessDataPc data)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("ProcessData");

                //SetProcessDataHeader(worksheet);

                SetProcessData(worksheet, data);

                return excelPackage.GetAsByteArray();
            }
        }

        private static byte[] AppendExcel(ProcessDataPc data, string filePath) 
        {
            FileInfo file = new FileInfo(filePath);

            using (ExcelPackage excelPackage = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet;

                if (excelPackage.Workbook.Worksheets["ProcessData"] == null)
                {
                    worksheet = excelPackage.Workbook.Worksheets.Add("ProcessData");
                    //SetProcessDataHeader(worksheet);
                }
                else
                {
                    worksheet = excelPackage.Workbook.Worksheets["ProcessData"];
                }

                SetProcessData(worksheet, data);

                return excelPackage.GetAsByteArray();
            }
        }

        //obsolete up to set header from DataTable but left for a while as alternative brut force
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

        private static void SetProcessData(ExcelWorksheet worksheet, ProcessDataPc data)
        {
            var rowOffset = worksheet.Dimension == null ? 1 : worksheet.Dimension.End.Row + 1;
            var setHeader = rowOffset == 1;

            DataTable dataTable = DataTableConverter.CreateDataTable(new List<ProcessDataPc> { data, });

            worksheet.Cells[rowOffset, 1].LoadFromDataTable(dataTable, setHeader);

            SetDataStyle(worksheet);
        }

        private static void SetDataStyle(ExcelWorksheet worksheet)
        {
            var rowCount = worksheet.Dimension.Rows;
            var colCount = worksheet.Dimension.Columns;

            // header style
            worksheet.Cells[1, 1, rowCount, colCount].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            worksheet.Cells[1, 1, rowCount, colCount].AutoFitColumns();
            worksheet.Cells[1, 1, 1, colCount].Style.Font.Bold = true;

            Color evenRowColor = System.Drawing.ColorTranslator.FromHtml("#f4f4f4");    //gray f4f4f4 e9e9e9
            Color oddRowColor = System.Drawing.ColorTranslator.FromHtml("#b3cfb0");     //green

            //data style
            for (int i = 2; i <= rowCount; i++)
            {
                using (var range = worksheet.Cells[i, 1, i, colCount])
                {
                    if (i % 2 == 0)
                    {
                        range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(evenRowColor);

                        range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        range.Style.Border.Top.Color.SetColor(Color.Gray);
                        range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        range.Style.Border.Right.Color.SetColor(Color.Gray);
                        range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        range.Style.Border.Bottom.Color.SetColor(Color.Gray);
                        range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        range.Style.Border.Left.Color.SetColor(Color.Gray);
                    }
                    else
                    {
                        range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(oddRowColor);

                        range.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                        range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        range.Style.Border.Top.Color.SetColor(Color.Gray);
                        range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        range.Style.Border.Right.Color.SetColor(Color.Gray);
                        range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        range.Style.Border.Bottom.Color.SetColor(Color.Gray);
                        range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        range.Style.Border.Left.Color.SetColor(Color.Gray);
                    }
                }
            }

            worksheet.View.FreezePanes(2, 1);
        }
    }
}
