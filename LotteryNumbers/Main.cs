using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LotteryNumbers
{
    public partial class FrmMain : Form
    {
        private Lottery lottery;
        private BindingSource bindingSource;
        private BindingSource bindingGenerated;
        private readonly Color absentNumberColor = Color.DarkSlateBlue;
        private readonly Color presentNumberColor = SystemColors.Control;
        private List<Task> tasks;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            bindingSource = new BindingSource();
            bindingGenerated = new BindingSource();
            tasks = new List<Task>();
            InitializeLotteries();
        }



        private void InitializeLotteries()
        {
            //Enum.GetValues(typeof(Lotteries)).Cast<int>().ToList().ForEach(l => cbxLotteries.Items.Add(((Lotteries)l).ToString()));
            cbxLotteries.DataSource = Enum.GetValues(typeof(EnumLotteries));
            cbxFilter.DataSource = Enum.GetValues(typeof(EnumFilterOptions));
            cbxLotteries.SelectedIndex = 0;
            cbxFilter.SelectedIndex = 0;
            LoadAndBindNumbers();
            cbxLotteries.SelectedValueChanged += CbxLotteries_SelectedIndexChanged;
        }

        private void LoadAndBindNumbers()
        {
            tslblLotteryName.Text = string.Format("Loading {0}'s numbers from file", cbxLotteries.SelectedText);
            lottery = CreateLottery(cbxLotteries.SelectedIndex);
            toolStripProgressBar.Value = 0;
            lottery.LoadNumbers(toolStripProgressBar);
            lottery.Bind(dgvDrawings, bindingSource);
            gbxSpecialNumber.Text = lottery.ColumnSpecs.GetColumSpec(ColumnHeader.SpecialNumber.ToString()).Header;
            gbxSpecialPlay.Text = lottery.ColumnSpecs.GetColumSpec(ColumnHeader.SpecialPlay.ToString()).Header;
            tslblLotteryName.Text = string.Empty;
            toolStripProgressBar.Value = 0;
            UpdateNumberOccurrences();
        }


        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            Lottery lot = CreateLottery((int)cbxLotteries.SelectedIndex);
            using (WebClient wc = new WebClient())
            {
                tslblLotteryName.Text = string.Format("Downloading winning numbers from {0}", lot.Name);
                wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
                wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
                wc.DownloadFileAsync( new Uri(lot.Url), lot.FilePath);
            }
        }

        private void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            toolStripProgressBar.Value = 0;
            tslblLotteryName.Text = "Files updated succefully";
        }

        void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            toolStripProgressBar.Value = e.ProgressPercentage;
        }

        private void CbxLotteries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lottery == null)
                return;

            LoadAndBindNumbers();
            dgvDrawings.Rows[0].Selected = true;
        }


        private Lottery CreateLottery(int index)
        {
            switch (index)
            {
                case (int)EnumLotteries.Powerball:
                    return new PowerBall(AppDomain.CurrentDomain.BaseDirectory);
                case (int)EnumLotteries.MegaMillions:
                    return new MegaMillions(AppDomain.CurrentDomain.BaseDirectory);
                default:
                    return null;
            }
        }




        #region CONTROLS EVENTS

        /// <summary>
        /// Updates the textboxes with the numbers selected from the grid's row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvDrawings_SelectionChanged(object sender, EventArgs e)
        {
            // gets the grid row
            var rowsCount = dgvDrawings.SelectedRows.Count;
            if (rowsCount == 0 || rowsCount > 1) return;

            var row = dgvDrawings.SelectedRows[0];
            if (row == null) return;

            // List of text boxes to be updated
            List<TextBox> textBoxes = new List<TextBox> {
                txtDate, txtNumber1, txtNumber2, txtNumber3, txtNumber4,
                txtNumber5, txtSpecialNumber, txtSpecialPlay};

            // Updates the textboxes using the grid's row values
            lottery.UpdateTextBoxes(row, textBoxes);
        }

        /// <summary>
        /// Used to color the background of the cell when the number is the default number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DgvDrawings_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null)
                return;

            if (e.Value.ToString() == lottery.DefaultNumber.ToString())
                e.CellStyle.SelectionBackColor = absentNumberColor;
        }

        /// <summary>
        /// Update the background color of the textbox depending of the number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_TextChanged(object sender, EventArgs e)
        {
            TextBox txtB = (TextBox)sender;

            if (string.IsNullOrEmpty(txtB.Text.Trim()))
                return;

            txtB.BackColor = txtB.Text == lottery.DefaultNumber.ToString() ? absentNumberColor : presentNumberColor;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Task.WaitAll(tasks.ToArray());
        }

        
        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            lottery.Bind(dgvGenerated, bindingGenerated, lottery.Generate(1, (int)nudTotalDrawings.Value));                
        }

        private void CbxLeastFirst_CheckedChanged(object sender, EventArgs e)
        {
            UpdateNumberOccurrences();
        }

        private void CbxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lottery == null || lottery.Drawings.Count == 0)
                return;

            switch (cbxFilter.SelectedIndex)
            {
                case (int)EnumFilterOptions.All:
                    cbxFilterOptions.DataSource = null;
                    cbxFilterOptions.Enabled = false;
                    break;
                case (int)EnumFilterOptions.ByMonth:
                    cbxFilterOptions.Enabled = true;
                    cbxFilterOptions.DataSource = Enum.GetValues(typeof(EnumMonthsFilter));
                    cbxFilterOptions.SelectedIndex = 0;
                    break;
                case (int)EnumFilterOptions.ByYear:
                    cbxFilterOptions.Enabled = true;
                    int year = DateTime.Today.Year;
                    cbxFilterOptions.DataSource = Enumerable.Range(year - 10, 11).ToList();
                    cbxFilterOptions.SelectedIndex = 0;
                    break;
                default:
                    cbxFilterOptions.Enabled = true;
                    cbxFilterOptions.DataSource = Enum.GetValues(typeof(EnumMonthTerms));
                    cbxFilterOptions.SelectedIndex = 0;
                    break;
            }
        }

        #endregion

        private void CbxFilterOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateNumberOccurrences();
        }

        /// <summary>
        /// Show the list of numbers ordered and filtered, according the controls setting
        /// </summary>
        public void UpdateNumberOccurrences()
        {
            Func<Numbers, bool> condition;

            // Get the condition to filer the drawings
            switch (cbxFilter.SelectedIndex)
            {
                case (int)EnumFilterOptions.ByMonth:
                    condition = num => num.GetDate().Month == cbxFilterOptions.SelectedIndex + 1;
                    break;
                case (int)EnumFilterOptions.ByTheLastTerm:
                    condition = num => DateTime.Compare(num.GetDate(), GetDateToCompareTo()) > 0;
                    break;
                case (int)EnumFilterOptions.ByYear:
                    condition = num => num.GetDate().Year == (int)cbxFilterOptions.SelectedItem;
                    break;
                default:
                    condition = null;
                    break;
            }

            dgvNumberOccurrences.DataSource = lottery.GetNumbersFilterdOrdered(cbxLeastFirst.Checked, cbxByNumber.Checked, condition);
        }

        /// <summary>
        /// Returns the date from when the numbers are meet the filter option condition
        /// </summary>
        /// <returns>The date</returns>
        private DateTime GetDateToCompareTo()
        {
            switch ((EnumMonthTerms)cbxFilterOptions.SelectedIndex)
            {
                case EnumMonthTerms.LastMonth:
                    return new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-1);
                case EnumMonthTerms.Last2Months:
                    return new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-2);
                case EnumMonthTerms.Last3Months:
                    return new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-3);
                case EnumMonthTerms.LastYear:
                    return new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddYears(-1);
                default:
                    return new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddYears(-2);
            }
        }
    }


}
