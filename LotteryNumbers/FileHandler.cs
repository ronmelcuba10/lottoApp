using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LotteryNumbers
{
    public static class FileHandler
    {
        public static string Extension = ".lot";

        public static List<string> LoadLines( string filePath)
        {
            try
            {
                string[] logFile = File.ReadAllLines(filePath);
                if (logFile[0].Contains("DOCTYPE"))
                {
                    logFile = ExtractLines(logFile);
                }
                return new List<string>(logFile);
            }
            catch (Exception ex)
            {
                return new List<string>();
            }
        }

        private static string[] ExtractLines(string[] logFile)
        {
            List<DatesDrawings> list = new List<DatesDrawings>();
            var index = 0;

            while (index < logFile.Length)
            {
                if (logFile[index].Trim() == "<td height=9 colspan=4></td>")
                {
                    index++;
                    if (logFile[index].Trim() == "<td></td>")
                    {
                        index++;
                        continue;
                    }

                    while (logFile[index].Trim() != "</tr>")
                    {
                        string drawingline = "CashForLife,";
                        string dateStr = ExtractStringFromLine(logFile[index]);
                        DateTime.TryParse(dateStr, out DateTime date);
                        drawingline += string.Join(",", new List<int>() {date.Month, date.Day, date.Year}) + ",";
                        index += 2;
                        for (var i = 0; i < 5; i++)
                        {
                            drawingline += ExtractStringFromLine(logFile[index]) + ",";
                            index += 4;
                        }
                        drawingline += ExtractStringFromLine(logFile[index], true);
                        list.Add(new DatesDrawings()
                        {
                            DateTime = date,
                            DrawingStr = drawingline
                        });
                        index += 4;
                    }
                }
                index++;
            }

            return list.OrderBy(l => l.DateTime).Select(l => l.DrawingStr).ToArray();
        }

        private static string ExtractStringFromLine(string line, bool cashball=false)
        {
            string str = cashball ? "<b>" : "\"helvetica\">";
            string[] splittingString = new string[] { str };
            return line.Split(splittingString, StringSplitOptions.None)[1]
                .Split('<')[0];
        }

    }


    class DatesDrawings
    {
        public DateTime DateTime { get; set; }
        public string DrawingStr { get; set; }
    }
}
