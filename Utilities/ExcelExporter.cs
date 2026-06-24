using System;
using System.Data;
using System.IO;
using System.Text;

namespace SmartMedPharmacy.Utilities
{
    public static class ExcelExporter
    {
        public static void ExportToExcel(DataTable dt, string filePath, string sheetName)
        {
            try
            {
                StringBuilder html = new StringBuilder();
                
                html.AppendLine("<html xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\" xmlns=\"http://www.w3.org/TR/REC-html40\">");
                html.AppendLine("<head>");
                html.AppendLine("<meta http-equiv=Content-Type content=\"text/html; charset=utf-8\">");
                html.AppendLine("<style>");
                html.AppendLine("table { border-collapse: collapse; width: 100%; font-family: Calibri, sans-serif; }");
                html.AppendLine("th { background-color: #008080; color: white; font-weight: bold; border: 1px solid #ddd; padding: 8px; text-align: left; }");
                html.AppendLine("td { border: 1px solid #ddd; padding: 8px; }");
                html.AppendLine(".title { font-size: 16pt; font-weight: bold; color: #008080; padding-bottom: 10px; }");
                html.AppendLine("</style>");
                html.AppendLine("</head>");
                html.AppendLine("<body>");
                
                html.AppendLine($"<div class='title'>{sheetName}</div>");
                html.AppendLine($"<div style='margin-bottom:15px; font-size:10pt; color:#666;'>Generated on: {DateTime.Now.ToString("g")}</div>");
                
                html.AppendLine("<table>");
                
                // Header row
                html.AppendLine("<tr>");
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    html.AppendLine($"<th>{dt.Columns[c].ColumnName}</th>");
                }
                html.AppendLine("</tr>");
                
                // Data rows
                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    html.AppendLine("<tr>");
                    for (int c = 0; c < dt.Columns.Count; c++)
                    {
                        string cellValue = dt.Rows[r][c]?.ToString() ?? "";
                        if (decimal.TryParse(cellValue, out decimal numVal) && dt.Columns[c].DataType != typeof(string))
                        {
                            html.AppendLine($"<td style='mso-number-format:\"\\#\\,\\#\\#0\\.00\";'>{numVal}</td>");
                        }
                        else
                        {
                            html.AppendLine($"<td>{cellValue}</td>");
                        }
                    }
                    html.AppendLine("</tr>");
                }
                
                html.AppendLine("</table>");
                html.AppendLine("</body>");
                html.AppendLine("</html>");
                
                File.WriteAllText(filePath, html.ToString(), Encoding.UTF8);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error exporting to Excel: {ex.Message}", ex);
            }
        }
    }
}
