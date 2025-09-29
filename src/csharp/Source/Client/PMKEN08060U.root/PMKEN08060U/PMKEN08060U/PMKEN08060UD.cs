using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Broadleaf.Library.Windows.Forms
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class FrmPartsInfo : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public FrmPartsInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public string Year
        {
            set
            {
                txtYear.Text = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string SpecialNote
        {
            set
            {
                txtSpecialNote.Text = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PartsNo
        {
            set
            {
                txtPartsNo.Text = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Standard
        {
            set
            {
                txtStandard.Text = value;
            }
        }

        private void FORMPARTSINFO_Shown(object sender, EventArgs e)
        {
            //Owner.Focus();
        }
    }
}