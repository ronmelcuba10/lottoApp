﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

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
        public List<int> HiddenColumns { get; set; }
        public int HistoricNumMax { get; set; }
        public int HistoricSpecialNumMax { get; set; }




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
            HiddenColumns = new List<int>();
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
                return new Numbers(date, numbers, DefaultNumber, specialNumber, specialPlay);
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            return null;
        }


        public virtual bool LoadNumbers(ToolStripProgressBar tspb)
        {
            List<string> numbers = FileHandler.LoadLines(FilePath);
            if (numbers.Count == 0)
                return false;
            int i = 0;
            int total = numbers.Count;

            foreach (var n in numbers)
            {
                tspb.Value = (int)((double)i / total * 100);

                var num = BuildNumbers(n);
                if (num == null)
                {
                    Drawings.Clear();
                    break;
                }
                Drawings.Add(num);
                i++;
            }
            Drawings.Reverse();
            return Drawings.Count > 0;
        }

        public void Bind(DataGridView dgv, BindingSource bds, Drawings drawings = null)
        {
            bds.DataSource = drawings ?? Drawings;
            //if (drawings != null)
            //    HiddenColumns.Add(SpecialPlayIndex);
            dgv.DataSource = bds;
            
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                ColumnSpec cs = ColumnSpecs.GetColumSpec(column.Name);
                column.HeaderText = cs.Header;

                column.HeaderCell.Style.Alignment = cs.Header == ColumnHeader.Date.ToString() 
                    ? DataGridViewContentAlignment.MiddleLeft 
                    : DataGridViewContentAlignment.MiddleCenter;

                column.DefaultCellStyle.Alignment = cs.Header == Constants.NUMBER_HEADER 
                    ? DataGridViewContentAlignment.MiddleCenter 
                    : DataGridViewContentAlignment.MiddleLeft;
            }
            foreach (DataGridViewColumn dgvColumn in dgv.Columns)
            {
                dgvColumn.Visible = true;
            }

            HiddenColumns.ForEach(hc => dgv.Columns[hc].Visible = false);
        }

        public void UpdateTextBoxes(DataGridViewRow row, List<TextBox> textBoxes)
        {
            textBoxes.ForEach( txtb => txtb.Text = row.Cells[txtb.Name.Remove(0, 3)].Value.ToString());
        }


        public List<NumberOccurrence> GetNumbersFilteredOrdered(
            bool leastFirst,
            bool byNumbers,
            Func<Drawings, bool, bool, List<NumberOccurrence>> selectedNumbers,
            Func<Numbers, bool> condition = null)
        {
            if (condition == null)
            {
                return selectedNumbers(Drawings, leastFirst, byNumbers);
            }

            Drawings drw = new Drawings();
            drw.AddRange(Drawings.Where(d => condition(d)));
            return selectedNumbers(drw, leastFirst, byNumbers);
        }


        public List<NumberOccurrence> GetRegularNumbersFilterdOrdered(
            bool leastFirst, bool byNumbers, Func<Numbers,bool> condition = null)
        {
            return GetNumbersFilteredOrdered(leastFirst, byNumbers, GetNumbersOrdered, condition);
        }


        public List<NumberOccurrence> GetSpecialNumbersFilterdOrdered(
            bool leastFirst, bool byNumbers, Func<Numbers, bool> condition = null)
        {
            return GetNumbersFilteredOrdered(leastFirst, byNumbers, GetSpecialNumbersOrdered, condition);
        }




        public Drawings Generate(int filterIndex, int quantity)
        {
            Drawings drawings = new Drawings();
            for (int i = 0; i < quantity; i++)
            {
                while (true)
                {
                    Numbers num = new Numbers(DefaultNumber).Generate(5, NumberMax, SpecialNumberMax, DefaultNumber, AllowRepeatedNums);
                    if (!Drawings.Any(n => n.SameNumCombination(num)))
                    {
                        drawings.Add(num);
                        break;
                    }
                }
            }
            return drawings;
        }


        public List<NumberOccurrence> GetNumbersOrdered(Drawings drawings, bool leastFirst, bool byNumbers)
        {
            int[] nums = new int[HistoricNumMax];
            void lambda(Numbers number) => number.NumsSet().ToList().ForEach(n => nums[n - 1]++);
            return GetAnyNumbersOrdered(drawings, leastFirst, byNumbers, lambda, nums, HistoricNumMax);



            //// gets all the ocurrences of all the numbers
            //drawings.ForEach( d => {
            //    d.NumsSet().ToList().ForEach( n => nums[n - 1]++);
            //});

            //NumberOccurrenceCollection noC = new NumberOccurrenceCollection();
            //for (int i = 0; i < HistoricNumMax; i++)
            //    noC.Add(new NumberOccurrence(i + 1, nums[i]));

            //return leastFirst 
            //    ? noC.OrderBy(n => byNumbers ? n.Number : n.Occurrence).ToList() 
            //    : noC.OrderByDescending(n => byNumbers ? n.Number : n.Occurrence).ToList();
        }


        public List<NumberOccurrence> GetSpecialNumbersOrdered(Drawings drawings, bool leastFirst, bool byNumbers)
        {
            int[] nums = new int[HistoricSpecialNumMax];
            void lambda(Numbers number) => nums[number.SpecialNumber - 1]++;
            return GetAnyNumbersOrdered(drawings, leastFirst, byNumbers, lambda, nums, HistoricSpecialNumMax);


            //int[] nums = new int[HistoricSpecialNumMax];
            //// gets all the ocurrences of all the spacial numbers
            //drawings.ForEach(d => nums[d.SpecialNumber - 1]++);

            //NumberOccurrenceCollection noC = new NumberOccurrenceCollection();
            //for (int i = 0; i < HistoricSpecialNumMax; i++)
            //    noC.Add(new NumberOccurrence(i + 1, nums[i]));

            //return leastFirst
            //    ? noC.OrderBy(n => byNumbers ? n.Number : n.Occurrence).ToList()
            //    : noC.OrderByDescending(n => byNumbers ? n.Number : n.Occurrence).ToList();


        }

        public List<NumberOccurrence> GetAnyNumbersOrdered(Drawings drawings, bool leastFirst, bool byNumbers, Action<Numbers> action, int[] nums, int maxNum)
        {
            // gets all the ocurrences of all the numbers
            drawings.ForEach(action);

            NumberOccurrenceCollection noC = new NumberOccurrenceCollection();
            for (int i = 0; i < maxNum; i++)
                noC.Add(new NumberOccurrence(i + 1, nums[i]));

            return leastFirst
                ? noC.OrderBy(n => byNumbers ? n.Number : n.Occurrence).ToList()
                : noC.OrderByDescending(n => byNumbers ? n.Number : n.Occurrence).ToList();
        }



    }


}

    
