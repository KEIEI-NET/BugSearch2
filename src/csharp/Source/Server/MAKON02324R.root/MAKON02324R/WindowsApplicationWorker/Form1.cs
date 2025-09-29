using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Remoting;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

namespace WindowsApplicationWorker
{
    /// <summary>
    /// �e�X�g�pUI
    /// </summary>
	public partial class Form1 : Form
	{
        /// <summary>
        /// �e�X�g�pUI�t�H�[���̃R���X�g���N�^
        /// </summary>
		public Form1 ()
		{
			InitializeComponent();
		}

		private IStcDataRefListWorkDB iStcDataRefListWorkDB = null;

		private void Form1_Load ( object sender, EventArgs e )
		{
			RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile,false);
            iStcDataRefListWorkDB = MediationStcDataRefListWorkDB.GetStcDataRefListWorkDB();
		}

		private void Read_Click ( object sender, EventArgs e )
		{
			// �ϐ��錾
			DateTime start, end;

			start = DateTime.Now;
			string enterpriseCd = this.EnterPriseCode.Text;
			int secKind = Convert.ToInt32( this.SecKind.Text );
			string sectionCd = this.SectionCode.Text;
			int supFomal = Convert.ToInt32(this.SupFomal.Text);
			int slipNo = Convert.ToInt32(this.SlipNo.Text);

			object stcDataObj = null;

			object stcDtlDataObj = null;

			object stcExDataObj = null;

			// Read���s
			int status = iStcDataRefListWorkDB.Read(out stcDataObj, out stcDtlDataObj,
				enterpriseCd, supFomal, slipNo, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0);

			// Read����
            if (status != 0)
            {
                Text = "�Y���f�[�^����  status=" + status;
            }
            else
            {
				string stcDtCnt = "";
				string stcDtlDtCnt = "";
				string stcExDtCnt = "";


				if ( stcDataObj != null )
					stcDtCnt = ((ArrayList)stcDataObj).Count.ToString();
				else 
					stcDtCnt = "null";

				if ( stcDtlDataObj != null )
					stcDtlDtCnt = ((ArrayList)stcDtlDataObj).Count.ToString();
				else 
					stcDtlDtCnt = "null";

				if ( stcExDataObj != null )
					stcExDtCnt = ((ArrayList)stcExDataObj).Count.ToString();
				else 
					stcExDtCnt = "null";


				Text = string.Format("�Y���f�[�^�L��  �d��:{0}��, �d������:{1}��, �d���ڍ�:{2}�� ", stcDtCnt, stcDtlDtCnt, stcExDtCnt);
                Text = "�Y���f�[�^�L��  HIT " + ((ArrayList)stcDataObj).Count.ToString() + "��";

				g_StockSlip.DataSource = stcDataObj;
				g_StockDetail.DataSource = stcDtlDataObj;
				g_StockExplaData.DataSource = stcExDataObj;

            }

            end = DateTime.Now;
            timeLabel.Text = Convert.ToString((end - start).TotalSeconds);
		}



	}
}