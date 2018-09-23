using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace LotteryNumbers
{
    public partial class FrmMain : Form
    {
        private Lottery lottery;
        private BindingSource bindingSource;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            bindingSource = new BindingSource();
            InitializeLotteries();
        }



        private void InitializeLotteries()
        {
            Enum.GetValues(typeof(Lotteries)).Cast<int>().ToList().ForEach(l => cbxLotteries.Items.Add(((Lotteries)l).ToString()));
            cbxLotteries.SelectedIndex = 0;
            LoadAndBindNumbers();
        }

        private void LoadAndBindNumbers()
        {
            lottery.LoadNumbers();
            lottery.Bind(dgvDrawings, bindingSource);
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
        }

        void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            toolStripProgressBar.Value = e.ProgressPercentage;
        }

        private void CbxLotteries_SelectedIndexChanged(object sender, EventArgs e)
        {
            lottery = CreateLottery(cbxLotteries.SelectedIndex);
            LoadAndBindNumbers();
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

        }

        
    }

    
}
