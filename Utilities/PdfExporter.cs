using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace SmartMedPharmacy.Utilities
{
    public static class PdfExporter
    {
        public static void ExportToPdf(DataTable dt, string filePath, string reportTitle)
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter writer = new StreamWriter(fs, Encoding.ASCII))
                    {
                        List<long> offsets = new List<long>();
                        
                        // Header
                        writer.Write("%PDF-1.4\n");
                        writer.Flush();
                        
                        // Object 1: Catalog
                        offsets.Add(fs.Position);
                        writer.Write("1 0 obj\n< /Type /Catalog /Pages 2 0 R >\nendobj\n");
                        writer.Flush();
                        
                        // Object 2: Pages
                        offsets.Add(fs.Position);
                        writer.Write("2 0 obj\n< /Type /Pages /Kids [3 0 R] /Count 1 >\nendobj\n");
                        writer.Flush();
                        
                        // Object 3: Page (A4 is 595 x 842 points)
                        offsets.Add(fs.Position);
                        writer.Write("3 0 obj\n< /Type /Page /Parent 2 0 R /MediaBox [0 0 595.275 841.889] /Contents 4 0 R /Resources << /Font << /F1 5 0 R >> >> >\nendobj\n");
                        writer.Flush();
                        
                        // Prepare Content Stream
                        StringBuilder sbContent = new StringBuilder();
                        sbContent.Append("BT\n");
                        sbContent.Append("/F1 16 Tf\n70 800 Td\n(" + EscapePdfText(reportTitle) + ") Tj\nET\n");
                        
                        sbContent.Append("BT\n");
                        sbContent.Append("/F1 10 Tf\n70 770 Td\n(Date: " + DateTime.Now.ToString("g") + ") Tj\nET\n");
                        
                        // Calculate layout details
                        int startY = 730;
                        int startX = 50;
                        int totalWidth = 500;
                        int colCount = Math.Max(1, dt.Columns.Count);
                        int charWidthFactor = 5; // Courier font width estimation factor
                        int colWidthChars = (totalWidth / colCount) / charWidthFactor;

                        sbContent.Append("BT\n");
                        sbContent.Append("/F1 10 Tf\n");
                        sbContent.Append(string.Format("{0} {1} Td\n", startX, startY));
                        
                        StringBuilder headerRow = new StringBuilder();
                        for (int c = 0; c < dt.Columns.Count; c++)
                        {
                            string colName = dt.Columns[c].ColumnName;
                            headerRow.Append(PadRightString(colName, colWidthChars));
                        }
                        sbContent.Append(" (" + EscapePdfText(headerRow.ToString()) + ") Tj\n");
                        sbContent.Append("ET\n");
                        
                        // Draw line
                        startY -= 10;
                        sbContent.Append(string.Format("1 w\n{0} {1} m\n{2} {1} l\nS\n", startX, startY, startX + totalWidth));
                        
                        // Rows
                        int currentY = startY - 20;
                        for (int r = 0; r < dt.Rows.Count; r++)
                        {
                            if (currentY < 50) break; // Page boundary check
                            
                            sbContent.Append("BT\n");
                            sbContent.Append("/F1 9 Tf\n");
                            sbContent.Append(string.Format("{0} {1} Td\n", startX, currentY));
                            
                            StringBuilder rowText = new StringBuilder();
                            for (int c = 0; c < dt.Columns.Count; c++)
                            {
                                string cellVal = dt.Rows[r][c] == null ? "" : dt.Rows[r][c].ToString();
                                DateTime parsedDate;
                                if (dt.Columns[c].DataType == typeof(DateTime) && DateTime.TryParse(cellVal, out parsedDate))
                                {
                                    cellVal = parsedDate.ToString("yyyy-MM-dd");
                                }
                                rowText.Append(PadRightString(cellVal, colWidthChars));
                            }
                            
                            sbContent.Append(" (" + EscapePdfText(rowText.ToString()) + ") Tj\n");
                            sbContent.Append("ET\n");
                            currentY -= 20;
                        }
                        
                        byte[] streamBytes = Encoding.ASCII.GetBytes(sbContent.ToString());
                        
                        // Object 4: Content Stream
                        offsets.Add(fs.Position);
                        writer.Write(string.Format("4 0 obj\n<< /Length {0} >>\nstream\n", streamBytes.Length));
                        writer.Flush();
                        fs.Write(streamBytes, 0, streamBytes.Length);
                        writer.Write("\nendstream\nendobj\n");
                        writer.Flush();
                        
                        // Object 5: Font
                        offsets.Add(fs.Position);
                        writer.Write("5 0 obj\n<< /Type /Font /Subtype /Type1 /BaseFont /Courier >>\nendobj\n");
                        writer.Flush();
                        
                        // Cross-reference table
                        long xrefOffset = fs.Position;
                        writer.Write("xref\n0 6\n0000000000 65535 f \n");
                        for (int i = 0; i < offsets.Count; i++)
                        {
                            writer.Write(offsets[i].ToString("D10") + " 00000 n \n");
                        }
                        
                        // Trailer
                        writer.Write(string.Format("trailer\n<< /Size 6 /Root 1 0 R >>\nstartxref\n{0}\n%%EOF\n", xrefOffset));
                        writer.Flush();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(string.Format("Error exporting report to PDF: {0}", ex.Message), ex);
            }
        }
        
        private static string EscapePdfText(string text)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;
            return text.Replace("(", "\\(").Replace(")", "\\)").Replace("\\", "\\\\");
        }
        
        private static string PadRightString(string val, int length)
        {
            if (val.Length >= length) return val.Substring(0, length);
            return val.PadRight(length);
        }
    }
}
