using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Broadleaf.Application;
using Broadleaf.Application.Controller;


namespace Broadleaf.Windows.Forms
{
	public partial class PMTSP01103UC : Form
	{
		#region �R���X�g���N�^
		
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
        public PMTSP01103UC(ref TspSendController tspController, FormStartPosition Position)
		{
			InitializeComponent();
            TspController = tspController;
            this.StartPosition = Position;

		}

		#endregion

		#region �t�B�[���h
        // �萔
        private const string AssmblyID = "PMTSP01103U";
        private const string AssmblyTitle = "�s�r�o���M����";
		/// <summary>
		/// ���M�f�[�^
		/// </summary>

        private TspSendController TspController = null;
        
        #endregion

		#region �v���p�e�B

		#endregion

		#region �E�R���g���[���C�x���g

		private void PMTSP01103UB_Load(object sender, EventArgs e)
		{
			send_timer.Enabled = true;
		}

        private void send_timer_Tick(object sender, EventArgs e)
        {
            int iStat;
            send_timer.Enabled = false;
            this.Refresh();
            //TSP-SEND�t�H���_�̓Ǎ���
            iStat = TspController.SearchTspSdRvDt(TspController.TspInfo.TSPSdRvDataPath, TspSendTableCls.SDR_TABLENAME);
            if (iStat == -1)
            {
                ErrorSet(); 
                return;
            }
            this.Refresh();
            //�폜�t�H���_�������ꍇ�͏������Ȃ�
            if (Directory.Exists(TspController.TspInfo.TSPSdRvDataPath + @"\TRASH") == true)
            {
                //TRASH�t�H���_�i�폜�f�[�^�j�̓Ǎ��݁@�@�@�@
                iStat = TspController.SearchTspSdRvDt(TspController.TspInfo.TSPSdRvDataPath + @"\TRASH", TspSendTableCls.TRASH_TABLENAME);
                if (iStat == -1)
                {
                    ErrorSet();
                    return;
                }
                this.Refresh();
            }
            //�X�e�[�^�X�擾
            iStat = TspController.Check();
            if (iStat == -1)
            {
                ErrorSet();
                return;
            }
            this.Refresh();
            //���M
            iStat = TspController.Send();
            if (iStat == -1)
            {
                ErrorSet();
                return;
            }
            TspController.TspInfo.LastDate = System.DateTime.Now;
            this.Refresh();
            //�폜
            iStat = TspController.TrashDelete();
            if (iStat == -1)
            {
                ErrorSet();
                return;
            }
            this.Refresh();

            this.DialogResult = DialogResult.OK;
        }

        private void ErrorSet()
        {
            this.pBWait.Visible = false;
            this.label1.Text = "���M���ɃG���[���������܂����B";
            this.label2.Text = "�ڍׂ̓G���[���O���Q�Ƃ��Ă��������B";
            this.cancel_Button.Visible = true;
        }

		private void cancel_Button_Click(object sender, EventArgs e)
		{
			//this._msg = "���M�����𒆒f���܂����B";
            this.DialogResult = DialogResult.OK;
		}

		#endregion
	}
}