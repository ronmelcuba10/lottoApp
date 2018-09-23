using System;
using System.Collections.Generic;
using System.IO;

namespace LotteryNumbers
{
    public static class FileHandler
    {
        public static string Extension = ".lot";

        public static List<string> LoadLines( string filePath)
        {
            try
            {
                var logFile = File.ReadAllLines(filePath);
                return new List<string>(logFile);
            }
            catch (Exception ex)
            {
                return new List<string>();
            }
        }
    }
}
