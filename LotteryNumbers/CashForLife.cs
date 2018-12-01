using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryNumbers
{
    public class CashForLife : Lottery
    {
        private readonly PatternSection[] cash4LifePattern;
        private const int numberMax = 60;
        private const int specialNumberMax = 4;
        private const int historicNumMax = 60;
        private const int historicSpecialNumMax = 4;

        public CashForLife(string appPath) : base(appPath)
        {
            Name = EnumLotteries.Cash4Life.ToString();
            FilePath = Path.Combine(appPath, FileName);
            ColumnSpecs.OverrideColumnName(ColumnHeader.SpecialNumber, "Cash Ball");
            Url = "http://www.flalottery.com/exptkt/c4l.htm";
            cash4LifePattern = new PatternSection[] {
                PatternSection.str, PatternSection.month, PatternSection.day, PatternSection.year,
                PatternSection.number, PatternSection.number, PatternSection.number, PatternSection.number,
                PatternSection.number, PatternSection.specialnumber};
            UpdateIndexes(cash4LifePattern);
            NumberMax = numberMax;
            SpecialNumberMax = specialNumberMax;
            SpecialPlayIndex = 7;
            HistoricNumMax = historicNumMax;
            HistoricSpecialNumMax = historicSpecialNumMax;
            HiddenColumns = new List<int>() { SpecialPlayIndex };
        }
    }
}
