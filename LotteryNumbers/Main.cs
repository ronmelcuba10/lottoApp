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
            Enum.GetValues(typeof(Lotteries)).Cast<int>().ToList().ForEach(l => cbxLotteries.Items.Add(((Lotteries)l).ToString()));
            cbxLotteries.SelectedIndex = 0;
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
        }


        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            List<Lottery> lotteries = Enum.GetValues(typeof(Lotteries)).Cast<int>().Select(l => CreateLottery((int)l)).ToList();
            lotteries.ForEach( l => {
                using (WebClient wc = new WebClient())
                {
                    tslblLotteryName.Text = string.Format("Downloading winning numbers from {0}", l.Name);
                    wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
                    wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
                    wc.DownloadFileAsync( new Uri(l.Url), l.FilePath);
                }
            });
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
                case (int)Lotteries.Powerball:
                    return new PowerBall(AppDomain.CurrentDomain.BaseDirectory);
                case (int)Lotteries.MegaMillions:
                    return new MegaMillions(AppDomain.CurrentDomain.BaseDirectory);
                default:
                    return null;
            }
        }

        private void DgvDrawings_SelectionChanged(object sender, EventArgs e)
        {
            var rowsCount = dgvDrawings.SelectedRows.Count;
            if (rowsCount == 0 || rowsCount > 1) return;

            var row = dgvDrawings.SelectedRows[0];
            if (row == null) return;

            List<TextBox> textBoxes = new List<TextBox> {
                txtDate, txtNumber1, txtNumber2, txtNumber3, txtNumber4,
                txtNumber5, txtSpecialNumber, txtSpecialPlay};
            lottery.UpdateTextBoxes(row, textBoxes);
        }

        private void DgvDrawings_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null)
                return;

            if (e.Value.ToString() == lottery.DefaultNumber.ToString())
                e.CellStyle.SelectionBackColor = absentNumberColor;
        }

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

        private void Button1_Click(object sender, EventArgs e)
        {
            //lottery.Generate(1, (int)nudTotalDrawings.Value);
            lottery.Bind(dgvGenerated, bindingGenerated, lottery.Generate(1, (int)nudTotalDrawings.Value));                
        }
    }

    
}
