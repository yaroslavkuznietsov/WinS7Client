using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
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

        //obsolete up to set header from DataTable but left for a while
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

            worksheet.Cells[1, 1, rowCount, colCount].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            worksheet.Cells[1, 1, rowCount, colCount].AutoFitColumns();
            worksheet.Cells[1, 1, 1, colCount].Style.Font.Bold = true;

            //worksheet.Cells[2, 1, 2, colCount].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //worksheet.Cells[2, 1, 2, colCount].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
            //worksheet.Cells[3, 1, 3, colCount].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //worksheet.Cells[3, 1, 3, colCount].Style.Fill.BackgroundColor.SetColor(Color.White);

            //worksheet.Cells[2, 1, 2, colCount].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.LightGray);
            //worksheet.Cells[2, 1, 3, colCount].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.LightGray);

            worksheet.View.FreezePanes(2, 1);
        }
    }
}
