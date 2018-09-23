using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace LotteryNumbers
{
    public abstract class Lottery
    {
        private const int defaultNum = -1;

        public string Name { get; set; }
        public string Url { get; set; }
        public string FileName  => Name + FileHandler.Extension;
        public string FilePath { get; set; }
        public string Error { get; set; }
        public Drawings Drawings { get; set; }
        public Dictionary<string,string> Headers { get; set; }
        //public List
        public PatternSection[] Pattern { get; set; }
        public int DefaultNumber => defaultNum;
        public bool AllowRepeatedNums { get; set; }
        public int NumberMax { get; set; }
        public int SpecialNumberMax { get; set; }
        public HashSet<int> NumbersIndexes { get; set; }
        public int SpecialNumberIndex { get; set; }
        public int SpecialPlayIndex { get; set; }
        public int DayIndex { get; private set; }
        public int MonthIndex { get; private set; }
        public int YearIndex { get; private set; }
        public ColumnSpecs ColumnSpecs { get; set; }

        protected Lottery(string appPath)
        {
            FilePath = Path.Combine(appPath, FileName);
            Headers = new Dictionary<string, string>();
            AllowRepeatedNums = false;
            Error = string.Empty;
            NumbersIndexes = new HashSet<int>();
            Drawings = new Drawings();
            NumberMax = DefaultNumber;
            SpecialNumberMax = DefaultNumber;
            SpecialNumberIndex = DefaultNumber;
            SpecialPlayIndex = DefaultNumber;
            ColumnSpecs = new ColumnSpecs();
        }

        protected void UpdateIndexes(PatternSection[] pattern)
        {
            this.Pattern = pattern;
            int index = 0;
            Array.ForEach(pattern, p => UpdateIndex(index++));
        }

        public void UpdateIndex(int patternIndex)
        {
            switch (Pattern[patternIndex])
            {
                case PatternSection.day:
                    DayIndex = patternIndex;
                    break;
                case PatternSection.month:
                    MonthIndex = patternIndex;
                    break;
                case PatternSection.year:
                    YearIndex = patternIndex;
                    break;
                case PatternSection.specialnumber:
                    SpecialNumberIndex = patternIndex;
                    break;
                case PatternSection.plays:
                    SpecialPlayIndex = patternIndex;
                    break;
                case PatternSection.number:
                    NumbersIndexes.Add(patternIndex);
                    break;
                default:
                    break;
            }
        }

        public virtual Numbers BuildNumbers(string line)
        {
            try
            {
                string[] str = line.Split(',');
                int day = int.Parse(str[DayIndex]);
                int month = int.Parse(str[MonthIndex]);
                int year = int.Parse(str[YearIndex]);
                DateTime date = new DateTime(year, month, day);
                if (year < 1000) throw new Exception(year.ToString() + "  " + line );

                int specialNumber = SpecialNumberIndex != DefaultNumber ? int.Parse(str[SpecialNumberIndex]) : DefaultNumber;
                int specialPlay = SpecialPlayIndex != DefaultNumber && SpecialPlayIndex < str.Length ? int.Parse(str[SpecialPlayIndex]) : DefaultNumber;
                int[] numbers = NumbersIndexes.ToList().Select(ni => int.Parse(str[ni])).ToArray();
                return new Numbers(date, numbers, specialNumber, specialPlay);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            return null;
        }


        public virtual bool LoadNumbers()
        {
            List<string> numbers = FileHandler.LoadLines(FilePath);

            if (numbers.Count == 0)
                return false;
            int i = 0;

            foreach (var n in numbers)
            {
                var num = BuildNumbers(n);
                if (num == null)
                {
                    Drawings.Clear();
                    break;
                }
                Drawings.Add(num);
                i++;
            }
            return Drawings.Count > 0;
        }

        public void Bind(DataGridView dgv, BindingSource bd)
        {
            bd.DataSource = Drawings;
            dgv.DataSource = bd;
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                ColumnSpec cs = ColumnSpecs.GetColumSpec(column.Name);
                column.HeaderText = cs.Header;
                //column.Width = cs.Width;
            }





        }

    }

    public enum Lotteries
    {
        Powerball,
        MegaMillions
    }


}

    
