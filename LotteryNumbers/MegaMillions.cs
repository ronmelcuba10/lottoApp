using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LotteryNumbers
{
    class MegaMillions : Lottery
    {
        private readonly PatternSection[] megaballPattern;
        private const int numberMax = 70;
        private const int specialNumberMax = 25;

        public MegaMillions(string appPath) : base(appPath)
        {
            Name = Lotteries.MegaMillions.ToString();
            FilePath = System.IO.Path.Combine(appPath, FileName);
            ColumnSpecs.OverrideColumnName(ColumnHeader.SpecialNumber, "Mega Ball");
            ColumnSpecs.OverrideColumnName(ColumnHeader.SpecialPlay, "Megaplier");
            Url = "https://txlottery.org/export/sites/lottery/Games/Mega_Millions/Winning_Numbers/megamillions.csv";
            megaballPattern = new PatternSection[] {
                PatternSection.str, PatternSection.month, PatternSection.day, PatternSection.year,
                PatternSection.number, PatternSection.number, PatternSection.number, PatternSection.number,
                PatternSection.number, PatternSection.specialnumber, PatternSection.plays};
            UpdateIndexes(megaballPattern);
            NumberMax = numberMax;
            SpecialNumberMax = specialNumberMax;
            SpecialPlayIndex = 7;
        }

    }
}
