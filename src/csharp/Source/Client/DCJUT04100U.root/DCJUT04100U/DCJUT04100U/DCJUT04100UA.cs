using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 
    /// </summary>
	public partial class DCJUT04100UA : Form
	{
        /// <summary>
        /// 
        /// </summary>
		public DCJUT04100UA()
		{
			InitializeComponent();
		}

        private DCJUT04110UA _acptAnOdrRemainRef;

		private void OrderRemainReferenceForm_FormClosed( object sender, FormClosedEventArgs e )
		{
			this.Close();
		}

		private void DCHAT04100UA_Load( object sender, EventArgs e )
		{
            this._acptAnOdrRemainRef = new DCJUT04110UA();
			this._acptAnOdrRemainRef.TopLevel = false;
			this._acptAnOdrRemainRef.FormBorderStyle = FormBorderStyle.None;
			this._acptAnOdrRemainRef.Show();
			this._acptAnOdrRemainRef.Dock = DockStyle.Fill;
			this._acptAnOdrRemainRef.FormClosed += new FormClosedEventHandler(this.OrderRemainReferenceForm_FormClosed);
			this.Controls.Add(this._acptAnOdrRemainRef);
		}
	}
}