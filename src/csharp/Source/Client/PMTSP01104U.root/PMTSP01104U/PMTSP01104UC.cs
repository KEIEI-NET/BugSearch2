using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application;

namespace Broadleaf.Windows.Forms
{
    public partial class PMTSP01104UC : Form
    {
        private string _TSPSdRvDataPath = "";
        private int _SaveDistance = 0;
        /// <summary>
        /// TSPƒpƒX
        /// </summary>
        public string TSPDtPath
        {
            get { return _TSPSdRvDataPath; }
            set { _TSPSdRvDataPath = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int SaveDist
        {
            get { return _SaveDistance; }
            set { _SaveDistance = value; }
        }

        public PMTSP01104UC(string TSPSendDataPath, int SaveDistance)
        {
#if DEBUG
            MessageBox.Show("aaa");
#endif
            InitializeComponent();
            _SaveDistance = SaveDistance;
            _TSPSdRvDataPath = TSPSendDataPath;
            this.DialogResult = DialogResult.Cancel;
            this.TspDtPath_Edit.Text = TSPDtPath;
            this.SaveDistance_OptionSet.CheckedIndex = SaveDistance;

        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            TSPDtPath = this.TspDtPath_Edit.Text;
            SaveDist = this.SaveDistance_OptionSet.CheckedIndex;
        
            this.Close();
        }

        private void cancel_Button_Click(object sender, EventArgs e)
        {

            this.Close();
        }

    }

}