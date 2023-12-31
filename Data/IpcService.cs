﻿using OfficeOpenXml;
using OfficeOpenXml.Drawing.Controls;
using System.Drawing.Text;

namespace BlazorApp.Data
{
    public class IpcService
    {
        //Read an excel file
        public List<IPC> GetIPCs()
        {
            //reading data from the file
            List<IPC> IPCs = new List<IPC>();
            string filePath = "C://Users//Zhaklin//Desktop//itility assignment//testcase_smart_applicator_V8.2_020823.xlsx";

            FileInfo fileInfo = new FileInfo(filePath);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using(ExcelPackage excelPackage = new ExcelPackage(fileInfo)) 
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.FirstOrDefault();
                int totalColumn = worksheet.Dimension.End.Column;
                int totalRow = worksheet.Dimension.End.Row;

                for(int row = 2; row <= totalRow; row++)
                {
                    IPC ipc = new IPC();
                    for (int col = 1; col <= totalColumn; col++)
                    {
                        string? row_col = worksheet.Cells[row, col].Value.ToString();
                        if (col == 1) ipc.Ipc = worksheet.Cells[row, col].Value.ToString();
                        if (col == 2) ipc.DataFactory = int.TryParse(row_col, out int result) ? result : 0;
                        //TODO: fix the date type error
                        //if (col == 3) ipc.Date = worksheet.Cells[row, col].Value.ToString("dd. MM. yyyy");
                        int rounded = (int)Math.Round(ipc.AvgValue, 0);
                        if (col == 4) rounded = int.TryParse(row_col, out int result) ? result : 0;
                        if (col == 5) ipc.MinValue = int.TryParse(row_col, out int result) ? result : 0;
                        if (col == 6) ipc.MaxValue = int.TryParse(row_col, out int result) ? result : 0;
                        if (col == 7) ipc.MetricId = worksheet.Cells[row, col].Value.ToString();
                        if (col == 8) ipc.CpuMHz = int.TryParse(row_col, out int result) ? result : 0;
                    }
                    IPCs.Add(ipc);
                }
            }
            return IPCs;
        }
    }
}
