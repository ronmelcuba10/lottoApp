using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LotteryNumbers
{
    class PowerBall : Lottery
    {
        private readonly PatternSection[] powerballPattern; 

        public PowerBall(string appPath) :base(appPath)
        {
            Name = Lotteries.Powerball.ToString();
            FilePath = Path.Combine(appPath,FileName);
            ColumnSpecs.OverrideColumnName(ColumnHeader.SpecialNumber, "Power Ball");
            ColumnSpecs.OverrideColumnName(ColumnHeader.SpecialPlay, "Power Play");
            Url = "https://txlottery.org/export/sites/lottery/Games/Powerball/Winning_Numbers/powerball.csv";
            powerballPattern = new PatternSection[] {
                PatternSection.str, PatternSection.month, PatternSection.day, PatternSection.year,
                PatternSection.number, PatternSection.number, PatternSection.number, PatternSection.number,
                PatternSection.number, PatternSection.specialnumber, PatternSection.plays};
            UpdateIndexes(powerballPattern);
            NumberMax = 69;
            SpecialNumberMax = 26;
        }

    }
}
