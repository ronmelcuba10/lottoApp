using System;

namespace LotteryNumbers
{
    public class Numbers
    {
        protected DateTime date;
        protected int[] numbers;
        protected int specialNumber;
        protected int specialPlay;

        public Numbers() { }

        public Numbers(DateTime date, int[] numbers, int sN = -1, int sP = -1)
        {
            this.date = date;
            this.numbers = numbers;
            specialNumber = sN;
            specialPlay = sP;
        }


        public DateTime Date => date;
        public int Number1 => GetNumber(0);
        public int Number2 => GetNumber(1);
        public int Number3 => GetNumber(2);
        public int Number4 => GetNumber(3);
        public int Number5 => GetNumber(4);
        public int Number6 => GetNumber(5);
        public int SpecialNumber => specialNumber;
        public int SpecialPlay => specialPlay;


        private int GetNumber(int index)
        {
            return numbers.Length > index ? numbers[index] : -1;
        }


    }
}