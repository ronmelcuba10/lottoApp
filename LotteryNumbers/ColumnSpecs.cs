using System.Collections.Generic;

namespace LotteryNumbers
{
    public class ColumnSpecs : Dictionary<string,ColumnSpec>
    {
        public ColumnSpecs():base()
        {
            Add(ColumnHeader.Date.ToString(), new ColumnSpec(ColumnHeader.Date.ToString(), 200));
            Add(ColumnHeader.SpecialNumber.ToString(), new ColumnSpec(ColumnHeader.SpecialNumber.ToString(), 200));
            Add(ColumnHeader.SpecialPlay.ToString(), new ColumnSpec(ColumnHeader.SpecialPlay.ToString(), 200));
            Add(ColumnHeader.Number.ToString(), new ColumnSpec(Constants.NUMBER_HEADER, 20));
        }

        public ColumnSpec GetColumSpec(string keyStr)
        {
            if (keyStr == ColumnHeader.SpecialNumber.ToString() 
                || keyStr == ColumnHeader.Date.ToString()
                || keyStr == ColumnHeader.SpecialPlay.ToString())
                return this[keyStr];

            return this[ColumnHeader.Number.ToString()];
        }

        public void OverrideColumnName(ColumnHeader ch, string name)
        {
            if (ch == ColumnHeader.Number)
                return;
            this[ch.ToString()].Header = name;
        }

    }

    public class ColumnSpec
    {
        public ColumnSpec(string header, int width)
        {
            Header = header;
            Width = width;
        }

        public string Header { get; set; }
        public int Width { get; set; }
    }


    public enum ColumnHeader
    {
        Date,
        Number,
        SpecialNumber,
        SpecialPlay,
    }

}
