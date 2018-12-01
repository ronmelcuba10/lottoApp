using System;
using System.Collections.Generic;
using System.Threading;

namespace LotteryNumbers
{

    public class Numbers
    {
        protected DateTime date;
        protected int[] numbers;
        protected int specialNumber;
        protected int specialPlay;
        private readonly int defaultNum;


        public Numbers(int dN)
        {
            numbers = new int[6];
            defaultNum = dN;
        }



        public Numbers(DateTime date, int[] numbers, int dN, int sN = -1, int sP = -1)
        {
            this.date = date;
            this.numbers = numbers;
            specialNumber = sN;
            specialPlay = sP;
            defaultNum = dN;
        }


        public string Date => date.ToString("ddd MM/dd/yyyy");
        public int Number1 => GetNumber(0);
        public int Number2 => GetNumber(1);
        public int Number3 => GetNumber(2);
        public int Number4 => GetNumber(3);
        public int Number5 => GetNumber(4);
        public int SpecialNumber => specialNumber;
        public int SpecialPlay => specialPlay;


        private int GetNumber(int index)
        {
            return numbers.Length > index ? numbers[index] : defaultNum;
        }


        public Numbers Generate(int numQty, int maxNum, int maxSpecNum, int maxSpecPlay, bool allowRepeatedNums)
        {
            date = DateTime.Today;
            if (numQty > numbers.Length)
                return null;
            for (int i = 0; i < numbers.Length; i++)
            {
                int thisNum;
                while (true)
                {
                    thisNum = ThreadSafeRandom.ThisThreadsRandom.Next(maxNum + 1);
                    if (allowRepeatedNums || !NumsSet().Contains(thisNum))
                        break;
                }
                numbers[i] = i < numQty ? thisNum : defaultNum;
            }
            specialNumber = ThreadSafeRandom.ThisThreadsRandom.Next(maxSpecNum + 1);
            specialPlay = ThreadSafeRandom.ThisThreadsRandom.Next(maxSpecPlay + 1);
            return this;
        }

        public bool SameNumCombination(Numbers num)
        {
            HashSet<int> numsSet = NumsSet();
            numsSet.ExceptWith(num.NumsSet());
            return numsSet.Count == 0 && num.SpecialNumber == SpecialNumber;
        }


        public HashSet<int> NumsSet()
        {
            return new HashSet<int>(numbers);
        }

        public DateTime GetDate() => date;

    }


    public static class ThreadSafeRandom
    {
        [ThreadStatic] private static Random Local;

        public static Random ThisThreadsRandom
        {
            get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
        }
    }
}