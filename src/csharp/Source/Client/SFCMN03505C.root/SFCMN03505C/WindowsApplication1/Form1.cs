using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Runtime.InteropServices;

namespace Broadleaf.Windows.Forms
{

    public partial class Form1 : Form
    {

        FelicaAcs _felicaAcs = new FelicaAcs();
        public Form1()
        {
            InitializeComponent();
        }

        // ���O�o��
        private void AddLogMsg(string msg)
        {
            LogMsgBox.AppendText(DateTime.Now.ToString() + " : " + msg + "\n");
            LogMsgBox.ScrollToCaret();
        }


        // ���C�u����������
        private void ultraButton1_Click(object sender, EventArgs e)
        {
            if (_felicaAcs.InitializeLibrary())
                AddLogMsg("���C�u�����̏������ɐ���");
            else
            {
                AddLogMsg("���C�u�����̏������Ɏ��s");
                AddLogMsg(_felicaAcs.FelicaLastErrType.ToString());
                AddLogMsg(_felicaAcs.RwLastErrType.ToString());
                AddLogMsg(_felicaAcs.LastErrMsg);
            }
        }

        // ���[�_�[���C�^�[�I�[�v��
        private void ultraButton3_Click(object sender, EventArgs e)
        {
            if (_felicaAcs.OpenReaderWriterAuto())
                AddLogMsg("�I�[�v���ɐ���");
            else
            {
                AddLogMsg("�I�[�v���Ɏ��s");
                AddLogMsg(_felicaAcs.FelicaLastErrType.ToString());
                AddLogMsg(_felicaAcs.RwLastErrType.ToString());
                AddLogMsg(_felicaAcs.LastErrMsg);
            }
        }

        // �|�[�����O(IDm�擾)
        private void ultraButton2_Click(object sender, EventArgs e)
        {
            UInt64 cardIdm, cardPmm;
            if (_felicaAcs.PollingAndGetCardInformation(Convert.ToUInt16(FelicaSystemCodes.Common), out cardIdm,out cardPmm))
            {
                AddLogMsg("�|�[�����O�ɐ���");
                AddLogMsg("IDm : " + cardIdm.ToString());
                AddLogMsg("Pmm : " + cardPmm.ToString());
            }
            else
            {
                AddLogMsg("�|�[�����O�Ɏ��s");
                AddLogMsg(_felicaAcs.FelicaLastErrType.ToString());
                AddLogMsg(_felicaAcs.RwLastErrType.ToString());
                AddLogMsg(_felicaAcs.LastErrMsg);
            }
        }

        // ����A���|�[�����O
        private void timer1_Tick(object sender, EventArgs e)
        {
            UInt64 cardIdm, cardPmm;
            if (_felicaAcs.PollingAndGetCardInformation(Convert.ToUInt16(FelicaSystemCodes.Common), out cardIdm, out cardPmm))
            {
                AddLogMsg("�|�[�����O�ɐ���");
                AddLogMsg("IDm : " + cardIdm.ToString());
                AddLogMsg("Pmm : " + cardPmm.ToString());
                timer1.Enabled = false;
            }
            else
            {
                AddLogMsg("�A���|�[�����O���E�E�E");
            }
        }

        // �A���|�[�����O�J�n
        private void ultraButton4_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        // FeliCaAcs�̘A���|�[�����O�Ăяo��
        private void ultraButton5_Click(object sender, EventArgs e)
        {
            AddLogMsg("�A���|�[�����O�J�n");
            // �R�[���o�b�N�f���Q�[�g�ɓo�^
            _felicaAcs.CallBackDelegate = new FelicaAcs.PollingCallBackDelegate(PollingSuccessCallBack);
            // �A���|�[�����O�J�n
            _felicaAcs.StartPolling(tNedit1.GetInt(), tNedit2.GetInt());
        }

        // �A���|�[�����O�R�[���o�b�N
        private bool PollingSuccessCallBack(UInt64 idm, UInt64 pmm, bool result)
        {
            if (result)
            {
                AddLogMsg("�|�[�����O�ɐ���");
                AddLogMsg("IDm : " + idm.ToString());
                AddLogMsg("Pmm : " + pmm.ToString());
            }
            else
            {
                AddLogMsg("�|�[�����O�Ɏ��s");
                AddLogMsg(_felicaAcs.FelicaLastErrType.ToString());
                AddLogMsg(_felicaAcs.RwLastErrType.ToString());
                AddLogMsg(_felicaAcs.LastErrMsg);
            }
            return result;
        }

        // �A���|�[�����O�I��
        private void ultraButton6_Click(object sender, EventArgs e)
        {
            AddLogMsg("�A���|�[�����O�I��");
            _felicaAcs.StopPolling();
        }

        // IDm�擾�޲�۸ޕ\��
        private void IDmGetDlg_Click(object sender, EventArgs e)
        {
            UInt64 idm = 0;
            DialogResult ret = new DialogResult();
            SFCMN03505CE idmDlg = new SFCMN03505CE();
            idmDlg.PollingInterval = tNedit1.GetInt();
            idmDlg.PollingRetryCnt = tNedit2.GetInt();
            idmDlg.ShowErrMsg = ultraCheckEditor1.Checked;
            ret = idmDlg.ShowFeliCaReadForm(ref idm, this);

            if (ret == DialogResult.OK)
            {
                AddLogMsg("�|�[�����O�ɐ���");
                AddLogMsg("IDm : " + idm.ToString());
            }
            else if (ret == DialogResult.Abort)
            {
                AddLogMsg("�|�[�����O�Ɏ��s");
                AddLogMsg(idmDlg.FelicaLastErrType.ToString());
                AddLogMsg(idmDlg.RwLastErrType.ToString());
            }
        }
     }
}