using System.IO;

namespace LotteryNumbers
{
    class PowerBall : Lottery
    {
        private readonly PatternSection[] powerballPattern;
        private const int numberMax = 69;
        private const int specialNumberMax = 26;
        private const int historicNumMax = 69;

        public PowerBall(string appPath) :base(appPath)
        {
            Name = EnumLotteries.Powerball.ToString();
            FilePath = Path.Combine(appPath,FileName);
            ColumnSpecs.OverrideColumnName(ColumnHeader.SpecialNumber, "Power Ball");
            ColumnSpecs.OverrideColumnName(ColumnHeader.SpecialPlay, "Power Play");
            Url = "https://txlottery.org/export/sites/lottery/Games/Powerball/Winning_Numbers/powerball.csv";
            powerballPattern = new PatternSection[] {
                PatternSection.str, PatternSection.month, PatternSection.day, PatternSection.year,
                PatternSection.number, PatternSection.number, PatternSection.number, PatternSection.number,
                PatternSection.number, PatternSection.specialnumber, PatternSection.plays};
            UpdateIndexes(powerballPattern);
            NumberMax = numberMax;
            SpecialNumberMax = specialNumberMax;
            SpecialPlayIndex = 10;
            HistoricNumMax = historicNumMax;
        }

    }
}
