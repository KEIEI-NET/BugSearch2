using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �s�r�o����M�����y�o�l���z
    /// </summary>
    /// <remarks>
    /// <br>Note		: </br>
    /// <br>Programmer	: ����</br>
    /// <br>Date		: 2020/12/01</br>
    /// <br></br>
    /// </remarks>
    public partial class PMTSP01103UA : Form
    {
        #region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PMTSP01103UA()
        {
            InitializeComponent();
        }

        #endregion

        #region �t�B�[���h
        private TspSendController TspController = null;
        private Process extProcess = null;
        private Thread extThread = null;
        string NotePadProgram = "";

        // �萔
        private const string AssmblyID = "PMTSP01103U";
        private const string AssmblyTitle = "�s�r�o���M����";

        // ��ʂa�i�ڍ׉�ʁj
        private PMTSP01103UB PMTSP01103UB_Form = null;

        #endregion

        #region �v���p�e�B

        #endregion

        #region �p�u���b�N���\�b�h
        #endregion

        #region �v���C�x�C�g���\�b�h

        #endregion

        #region �R���g���[���C�x���g

        /// <summary>
        /// Form.Load �C�x���g
        /// </summary>
        private void PMTSP01103UA_Load(object sender, EventArgs e)
        {
            TspController = new TspSendController();
            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            // �c�[���{�^��
            this.Toolbar.ImageListSmall = IconResourceManagement.ImageList24;
            this.Toolbar.Tools["exit"].SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.CLOSE;
            this.Toolbar.Tools["send"].SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.DEMANDPROP;
            this.Toolbar.Tools["detail"].SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.MODIFY;
            this.Toolbar.Tools["delete"].SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.DELETE;
            this.Toolbar.Tools["log"].SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.AMBIGUOUSSEARCH;
            this.Toolbar.Tools["setting"].SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.SETUP1;
            // �c�[���{�^���𖳌��ɂ���
            this.Toolbar.Tools["exit"].SharedProps.Enabled = false;
            this.Toolbar.Tools["send"].SharedProps.Enabled = false;
            this.Toolbar.Tools["log"].SharedProps.Enabled = false;
            this.Toolbar.Tools["setting"].SharedProps.Enabled = false;
            this.Toolbar.Tools["detail"].SharedProps.Enabled = false;
            this.Toolbar.Tools["delete"].SharedProps.Enabled = false;
            this.Toolbar.Tools["filter"].SharedProps.Enabled = false;
            
            this.Stat0Cnt_label.Text = "0��";
            this.Stat1Cnt_label.Text = "0��";
            this.Stat2Cnt_label.Text = "0��";
            this.lastdate_label.Text = "--/--/-- --:--:--";

            Infragistics.Win.UltraWinToolbars.ComboBoxTool combo =
              (Infragistics.Win.UltraWinToolbars.ComboBoxTool)Toolbar.Tools.GetItem(Toolbar.Tools.IndexOf("filter"));
            combo.SelectedIndex = 0;

            NotePadProgram = @"NOTEPAD.EXE";
            // �^�C�}�[ ON
            timer1.Enabled = true;
        }

        /// <summary>
        /// �N���㏈��
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            // �^�C�}�[ OFF
            timer1.Enabled = false;
            if (TspController.TspInfo.TSPSdRvDataPath == "")
            {
                MessageBox.Show("���M�t�H���_���ݒ肳��Ă��܂���B\n���M�t�H���_�̐ݒ���s���Ă��������B", AssmblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                // �c�[���{�^���𖳌��ɂ���
                this.Toolbar.Tools["exit"].SharedProps.Enabled = true;
                this.Toolbar.Tools["setting"].SharedProps.Enabled = true;

                return;
            }

            if (Directory.Exists(TspController.TspInfo.TSPSdRvDataPath) == false)
            {
                MessageBox.Show("���M�t�H���_�����݂��܂���B\n���M�t�H���_�̐ݒ���s���Ă��������B", AssmblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                // �c�[���{�^���𖳌��ɂ���
                this.Toolbar.Tools["exit"].SharedProps.Enabled = true;
                this.Toolbar.Tools["setting"].SharedProps.Enabled = true;
                TspController.WriteErrorLog("�������f\r\n");
                TspController.CloseErrorLog();
                return;
            }

            if (TspController.OpenErrorLog() == -1)
            {
                MessageBox.Show("���̒[���ő��M���̈דǍ��݂ł��܂���ł����B", AssmblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                // �c�[���{�^���𖳌��ɂ���
                this.Toolbar.Tools["exit"].SharedProps.Enabled = true;
                return;
            }
            TspController.WriteErrorLog("�ꊇ���M�N��");

            if (TspController.ReadTSPList() > 0)
            {
                TSPCustGrid.DataSource = TspController.TSPCustomerList;
                TSPCustGrid_InitializeLayout();
            }
            else
            {
                MessageBox.Show("���M�擾�Ӑ悪���݂��܂���B\nTSP�A�g�}�X�^�̐ݒ���s���ĉ������B", AssmblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                // �c�[���{�^���𖳌��ɂ���
                this.Toolbar.Tools["exit"].SharedProps.Enabled = true;
                TspController.WriteErrorLog("�������f\r\n");
                TspController.CloseErrorLog();
                return;

            }
            // ����M�f�[�^������
            if (TspController.Start_EnterpriseCD != "")
            {
                int iStat = 0;
                //TSP-SEND�t�H���_�̑Ώۃf�[�^�Ǎ���
                toolStripStatusLabel1.Text = "���M�t�H���_��ǂݍ��ݒ��c";
                toolStripProgressBar1.PerformStep();
                this.Refresh();
                //TSP-SEND�t�H���_�Ǎ���
                iStat = TspController.SearchTspSdRvDt(TspController.TspInfo.TSPSdRvDataPath, TspSendTableCls.SDR_TABLENAME);
                if (iStat == -1)
                {
                    MessageBox.Show("���M�f�[�^�Ǎ��ݒ��ɃG���[���������܂����B\n�ڍׂ̓G���[���O���Q�Ƃ��Ă��������B", AssmblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Toolbar.Tools["exit"].SharedProps.Enabled = true;
                    this.Toolbar.Tools["log"].SharedProps.Enabled = true;
                    toolStripStatusLabel1.Text = "�������f";
                    TspController.WriteErrorLog("�������f\r\n");
                    TspController.CloseErrorLog();
                    return;
                }

                //�폜�t�H���_�������ꍇ�͏������Ȃ�
                if (Directory.Exists(TspController.TspInfo.TSPSdRvDataPath + @"\TRASH") == true)
                {
                    //TRASH�t�H���_�Ǎ��݁@�@�@�@
                    iStat = TspController.SearchTspSdRvDt(TspController.TspInfo.TSPSdRvDataPath + @"\TRASH", TspSendTableCls.TRASH_TABLENAME);
                    if (iStat == -1)
                    {
                        MessageBox.Show("�폜�f�[�^�Ǎ��ݒ��ɃG���[���������܂����B\n�ڍׂ̓G���[���O���Q�Ƃ��Ă��������B", AssmblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Toolbar.Tools["exit"].SharedProps.Enabled = true;
                        this.Toolbar.Tools["log"].SharedProps.Enabled = true;
                        toolStripStatusLabel1.Text = "�������f";
                        TspController.WriteErrorLog("�������f\r\n");
                        TspController.CloseErrorLog();
                        return;
                    }
                }
                //�X�V�`�F�b�N
                toolStripStatusLabel1.Text = "�X�V���e���`�F�b�N���Ă��܂��c";
                toolStripProgressBar1.PerformStep();
                this.Refresh();
                iStat = TspController.Check();
                if (iStat == -1)
                {
                    MessageBox.Show("�X�V���e���`�F�b�N���ɃG���[���������܂����B\n�ڍׂ̓G���[���O���Q�Ƃ��Ă��������B", AssmblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Toolbar.Tools["exit"].SharedProps.Enabled = true;
                    this.Toolbar.Tools["log"].SharedProps.Enabled = true;
                    toolStripStatusLabel1.Text = "�������f";
                    TspController.WriteErrorLog("�������f\r\n");
                    TspController.CloseErrorLog();
                    return;
                }

                //�폜�f�[�^�`�F�b�N
                iStat = TspController.TrashDelete();
                if (iStat == -1)
                {
                    MessageBox.Show("�폜�f�[�^���������ɃG���[���������܂����B\n�ڍׂ̓G���[���O���Q�Ƃ��Ă��������B", AssmblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Toolbar.Tools["exit"].SharedProps.Enabled = true;
                    this.Toolbar.Tools["log"].SharedProps.Enabled = true;
                    toolStripStatusLabel1.Text = "�������f";
                    TspController.WriteErrorLog("�������f\r\n");
                    TspController.CloseErrorLog();
                    return;
                }
                TspController.WriteErrorLog("�N���������I��\r\n");
                TspController.CloseErrorLog();

                toolStripProgressBar1.PerformStep();
                toolStripStatusLabel1.Text = "���M�{�^���Ńf�[�^���M�ł��܂��B";

                // �񓚃f�[�^�O���b�h�̃f�[�^�\�[�X��ݒ�
                SdRvDtGrid.DataSource = TspController.TspSendData.SdrvView;
                TSPSdRvDtGrid_InitializeLayout();
                TspController.TspSendData.SetRowFilter(TspController.Start_EnterpriseCD);

                SlipCountRefresh();
            }

            // �c�[���{�^����L���ɂ���
            this.Toolbar.Tools["exit"].SharedProps.Enabled = true;
            this.Toolbar.Tools["send"].SharedProps.Enabled = true;
            this.Toolbar.Tools["log"].SharedProps.Enabled = true;
            this.Toolbar.Tools["setting"].SharedProps.Enabled = true;
            this.Toolbar.Tools["filter"].SharedProps.Enabled = true;

            // �c�[���{�^���𖳌��ɂ���
            this.Toolbar.Tools["detail"].SharedProps.Enabled = false;
            this.Toolbar.Tools["delete"].SharedProps.Enabled = false;
            if (TSPCustGrid.ActiveRow != null) TSPCustGrid.ActiveRow.Selected = true;
            

        }

        private void SlipCountRefresh()
        {
            TspController.GetSlipCnt();
            this.Stat0Cnt_label.Text = String.Format("{0}��", TspController.Stat0Cnt);
            this.Stat1Cnt_label.Text = String.Format("{0}��", TspController.Stat1Cnt);
            this.Stat2Cnt_label.Text = String.Format("{0}��", TspController.Stat2Cnt);
            if (TspController.TspInfo.LastDate == DateTime.MinValue)
            {
                this.lastdate_label.Text = "--/--/-- --:--:--";
            }
            else
            {
                this.lastdate_label.Text = (TspController.TspInfo.LastDate.ToShortDateString() + " " + TspController.TspInfo.LastDate.ToShortTimeString());
            }

        }

        private void send_Button_Click()
        {
            if (TspController.OpenErrorLog() == -1) 
            {
                MessageBox.Show("���̒[���ŏ������̈ב��M�o���܂���ł����B\n���΂炭���Ă���ēx�������s���Ă��������B", AssmblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TspController.WriteErrorLog("�蓮���M�J�n");
            PMTSP01103UC form = null;
            form = new PMTSP01103UC(ref this.TspController, FormStartPosition.CenterParent);
            form.ShowDialog();
            TspController.WriteErrorLog("�I��\r\n");
            TspController.CloseErrorLog();

            string epcode = (string)this.TSPCustGrid.ActiveRow.Cells[TspCustomer.CUST_SfEnterpriseCode].Value;
            SlipCountRefresh();

        }

        private void setting_Button_Click()
        {
            TspController.TspInfo.Setting();
        }

        private void detail_Button_Click()
        {
            if (SdRvDtGrid.ActiveRow == null) return;
            TspSdRvDtl[] dtl;
            dtl = (TspSdRvDtl[])this.SdRvDtGrid.ActiveRow.Cells[TspSendTableCls.DTL_DataClass].Value;
            TspSdRvDt dt;
            dt = (TspSdRvDt)this.SdRvDtGrid.ActiveRow.Cells[TspSendTableCls.SDR_DataClass].Value;
            this.PMTSP01103UB_Form = new PMTSP01103UB(dt,dtl);
            this.PMTSP01103UB_Form.ShowDialog();
        }

        private void delete_Button_Click()
        {
            if (TspController.OpenErrorLog() == -1)
            {
                MessageBox.Show("���̒[���ŏ������̈׍폜�ł��܂���ł����B\n���΂炭���Ă���ēx�������s���Ă��������B", AssmblyTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TspSdRvDt tspdt = (TspSdRvDt)this.SdRvDtGrid.ActiveRow.Cells[TspSendTableCls.SDR_DataClass].Value;
            TspController.Delete((DataRowView)this.SdRvDtGrid.ActiveRow.ListObject);
            SdRvDtGrid.Refresh();
            SlipCountRefresh();

            TspController.CloseErrorLog();

        }

        private void exit_Button_Click()
        {
            this.Close();
        }

        private void log_Button_Click()
        {

            extThread = new Thread(new ThreadStart(ProcessWorker));
            extThread.Start();
        }


        //�O���v���Z�X���N�����邽�߂̃X���b�h
        private void ProcessWorker()
        {
            //�O���v���Z�X�̋N��
            try
            {
                extProcess = new Process();
                extProcess.StartInfo.FileName = NotePadProgram;//�N������t�@�C����
                extProcess.StartInfo.Arguments = TspController.LogFilePath;
                extProcess.Start();

                //�X���b�h���I�������܂őҋ@
                while (!extProcess.HasExited)
                {
                    Thread.Sleep(100);
                }
            }
            catch
            {
            }
            finally
            {
            }
        }

        private void TSPCustGrid_AfterRowActivate(object sender, EventArgs e)
        {
            if (TSPCustGrid.ActiveRow == null) return;
            int[] arg = { 0, 1, 9 };
            string epcode;
            epcode = (string)this.TSPCustGrid.ActiveRow.Cells[TspCustomer.CUST_SfEnterpriseCode].Value;
            Infragistics.Win.UltraWinToolbars.ComboBoxTool combo =
              (Infragistics.Win.UltraWinToolbars.ComboBoxTool)Toolbar.Tools.GetItem(Toolbar.Tools.IndexOf("filter"));
            if (combo.SelectedIndex == 0)
            {
                TspController.TspSendData.SetRowFilter(epcode);
            }
            else
            {
                TspController.TspSendData.SetRowFilter(epcode, arg);
            }
            SlipCountRefresh();

        }

        private void SdRvFilterCombo_SelectedIndexChanged(int SelectedIndex)
        {
            if (TSPCustGrid.ActiveRow == null) return;
            string epcode;
            int[] arg = { 0, 1, 9 };

            switch (SelectedIndex)
            {
                case 0:
                    {
                        epcode = (string)this.TSPCustGrid.ActiveRow.Cells[TspCustomer.CUST_SfEnterpriseCode].Value;
                        TspController.TspSendData.SetRowFilter(epcode);
                        break;
                    }
                case 1:
                    {
                        epcode = (string)this.TSPCustGrid.ActiveRow.Cells[TspCustomer.CUST_SfEnterpriseCode].Value;
                        TspController.TspSendData.SetRowFilter(epcode, arg);
                        break;
                    }
            }
        }


        private void PMTSP01103UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            //���M�������̏ꍇ�͏I���������s��Ȃ�
            if (this.Toolbar.Tools["send"].SharedProps.Enabled == false) return;

            if (TspController.OpenErrorLog() == -1) return;
            //�폜
            TspController.AutoDelete();
            TspController.CloseErrorLog();

        }
        #endregion



        #region ���Ӑ�O���b�h������
        /// <summary>
        /// 
        /// </summary>
        private void TSPCustGrid_InitializeLayout()
        {
            Infragistics.Win.UltraWinGrid.UltraGrid grid = TSPCustGrid;
            //�o���h���擾
            Infragistics.Win.UltraWinGrid.UltraGridBand band = grid.DisplayLayout.Bands[0];

            //�񕝎�������
            grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
            for (int ix = 0; ix < band.Columns.Count; ix++)
            {
                // ��̕\���^��\���i�f�t�H���g�j
                switch (band.Columns[ix].Key)
                {
                    case TspCustomer.CUST_PmCustomerCode:	//�ʐM���
                    case TspCustomer.CUST_PmCustomerName:	//���l
#if DEBUG
                    case TspCustomer.CUST_PmEnterpriseCode:	//PM��ƃR�[�h
                    case TspCustomer.CUST_SfEnterpriseCode:	//SF��ƃR�[�h
#endif
                        band.Columns[ix].Hidden = false;
                        break;
                    default:
                        band.Columns[ix].Hidden = true;
                        break;
                }

            }
            //��
            band.Columns[TspCustomer.CUST_PmCustomerCode].Width = 160;	//���Ӑ�R�[�h
            band.Columns[TspCustomer.CUST_PmCustomerName].Width = 280;	//���Ӑ於��
            // �\����
            band.Columns[TspCustomer.CUST_PmCustomerCode].Header.VisiblePosition = 0;	//���Ӑ�R�[�h
            band.Columns[TspCustomer.CUST_PmCustomerName].Header.VisiblePosition = 1;	//���Ӑ於��
            // �\���ʒu
            band.Columns[TspCustomer.CUST_PmCustomerCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;	//���Ӑ�R�[�h
            band.Columns[TspCustomer.CUST_PmCustomerName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;	//���Ӑ於��

        }
        #endregion

        #region ���M�f�[�^�O���b�h������

        private void TSPSdRvDtGrid_InitializeLayout()
        {

            Infragistics.Win.UltraWinGrid.UltraGrid grid = SdRvDtGrid;

            //�o���h���擾
            Infragistics.Win.UltraWinGrid.UltraGridBand band = grid.DisplayLayout.Bands[0];

            //�񕝎�������
            grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;

            for (int ix = 0; ix < band.Columns.Count; ix++)
            {
                // ��̕\���^��\���i�f�t�H���g�j
                switch (band.Columns[ix].Key)
                {
                    case TspSendTableCls.SDR_CommConditionDivCd:	//�ʐM���
                    case TspSendTableCls.SDR_InstSlipNoStr:	//�w�����ԍ�
                    case TspSendTableCls.SDR_PmSlipKind:	//PM���i���i�J�i�j
                    case TspSendTableCls.SDR_PmSlipNo:	//PM�`�[�ԍ�
                    case TspSendTableCls.SDR_AcceptAnOrderDate:	//�󒍓�
                    case TspSendTableCls.SDR_TspTotalSlipPrice:	//���v���z
                    case TspSendTableCls.SDR_PmComment:	//���l
#if DEBUG
                    case TspSendTableCls.SDR_PmEnterpriseCode://PM��ƃR�[�h
                    case TspSendTableCls.SDR_SfEnterpriseCode://SF��ƃR�[�h
                    case TspSendTableCls.SDR_TspCommNo://SF��ƃR�[�h
#endif
                        band.Columns[ix].Hidden = false;
                        break;
                    default:
                        band.Columns[ix].Hidden = true;
                        break;
                }

            }
            band.Columns[TspSendTableCls.SDR_CommConditionDivCd].Width = 70;	//�ʐM���
            band.Columns[TspSendTableCls.SDR_InstSlipNoStr].Width = 90;	//�w�����ԍ�
            band.Columns[TspSendTableCls.SDR_PmSlipKind].Width = 70;	//PM�`�[���
            band.Columns[TspSendTableCls.SDR_PmSlipNo].Width = 70;	//PM�`�[�ԍ�
            band.Columns[TspSendTableCls.SDR_AcceptAnOrderDate].Width = 90;	//�󒍓�
            band.Columns[TspSendTableCls.SDR_TspTotalSlipPrice].Width = 80;	//���v���z
            band.Columns[TspSendTableCls.SDR_PmComment].Width = 300;	//���l

            // �\����
            band.Columns[TspSendTableCls.SDR_CommConditionDivCd].Header.VisiblePosition = 0;	//�ʐM���
            band.Columns[TspSendTableCls.SDR_InstSlipNoStr].Header.VisiblePosition = 1;	//�w�����ԍ�
            band.Columns[TspSendTableCls.SDR_PmSlipKind].Header.VisiblePosition = 2;	//PM�`�[���
            band.Columns[TspSendTableCls.SDR_PmSlipNo].Header.VisiblePosition = 3;	//PM�`�[�ԍ�
            band.Columns[TspSendTableCls.SDR_AcceptAnOrderDate].Header.VisiblePosition = 4;	//�󒍓�
            band.Columns[TspSendTableCls.SDR_TspTotalSlipPrice].Header.VisiblePosition = 5;	//���v���z
            band.Columns[TspSendTableCls.SDR_PmComment].Header.VisiblePosition = 6;	//���l

            // ����
            band.Columns[TspSendTableCls.SDR_TspTotalSlipPrice].Format = "#,##0;-#,##0;";	//���v���z

            // �\���ʒu
            band.Columns[TspSendTableCls.SDR_CommConditionDivCd].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;	//�ʐM���
            band.Columns[TspSendTableCls.SDR_InstSlipNoStr].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;	///�w�����ԍ�
            band.Columns[TspSendTableCls.SDR_PmSlipKind].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;	//PM�`�[���
            band.Columns[TspSendTableCls.SDR_PmSlipNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;	//PM�`�[�ԍ�
            band.Columns[TspSendTableCls.SDR_AcceptAnOrderDate].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;	//�󒍓�
            band.Columns[TspSendTableCls.SDR_TspTotalSlipPrice].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;	//���v���z
            band.Columns[TspSendTableCls.SDR_PmComment].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;	//���l

            // �l���X�g�����������A�O���b�h�֒ǉ����܂��B
            grid.DisplayLayout.ValueLists.Clear();
            Infragistics.Win.ValueList vl1 = grid.DisplayLayout.ValueLists.Add();
            vl1.ValueListItems.Add(0, "�����M");
            vl1.ValueListItems.Add(1, "���M��");
            vl1.ValueListItems.Add(2, "������");
            vl1.ValueListItems.Add(4, "�폜��");
            vl1.ValueListItems.Add(9, "���M�װ");
            band.Columns[TspSendTableCls.SDR_CommConditionDivCd].ValueList = vl1;

            Infragistics.Win.ValueList vl2 = grid.DisplayLayout.ValueLists.Add();
            vl2.ValueListItems.Add(10, "����");
            vl2.ValueListItems.Add(11, "�C��");
            vl2.ValueListItems.Add(20, "�ԕi");
            vl2.ValueListItems.Add(21, "�C��");
            band.Columns[TspSendTableCls.SDR_PmSlipKind].ValueList = vl2;

            // �L�[����}�b�s���O��ǉ�
            grid.KeyActionMappings.Add(
                new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                    Keys.Enter,	//Enter�L�[
                    Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab,
                    0,
                    Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                    Infragistics.Win.SpecialKeys.All,
                    0)
                );

        }

        #endregion

        private void SdRvDtGrid_Enter(object sender, EventArgs e)
        {
            if (this.Toolbar.Tools["send"].SharedProps.Enabled == false)
            {
                // �c�[���{�^���𖳌��ɂ���
                this.Toolbar.Tools["detail"].SharedProps.Enabled = false;
                this.Toolbar.Tools["delete"].SharedProps.Enabled = false;
            }
            else
            {
                // �c�[���{�^����L���ɂ���
                this.Toolbar.Tools["detail"].SharedProps.Enabled = true;
                this.Toolbar.Tools["delete"].SharedProps.Enabled = true;
            }
        }

        private void SdRvDtGrid_Leave(object sender, EventArgs e)
        {
            // �c�[���{�^���𖳌��ɂ���
            this.Toolbar.Tools["detail"].SharedProps.Enabled = false;
            this.Toolbar.Tools["delete"].SharedProps.Enabled = false;

        }

        private void SdRvDtGrid_DblClick(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if (e.Row == null) return;

            if (SdRvDtGrid.ActiveRow == null) return;
            TspSdRvDtl[] dtl;
            dtl = (TspSdRvDtl[])this.SdRvDtGrid.ActiveRow.Cells[TspSendTableCls.DTL_DataClass].Value;
            TspSdRvDt dt;
            dt = (TspSdRvDt)this.SdRvDtGrid.ActiveRow.Cells[TspSendTableCls.SDR_DataClass].Value;
            this.PMTSP01103UB_Form = new PMTSP01103UB(dt, dtl);
            this.PMTSP01103UB_Form.ShowDialog();


        }

        private void Toolbar_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "send":	//�I��
                    send_Button_Click();
                    break;

                case "setting"://�ݒ�
                    setting_Button_Click();
                    break;

                case "detail":	//�ڍ�
                    detail_Button_Click();
                    break;

                case "delete":	//�폜
                    delete_Button_Click();
                    break;

                case "exit":	//�I��
                    exit_Button_Click();
                    break;

                case "log":	//���O
                    log_Button_Click();
                    break;

            }

        }

        private void Toolbar_ToolValueChanged(object sender, Infragistics.Win.UltraWinToolbars.ToolEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "filter":	//�I��

                    Infragistics.Win.UltraWinToolbars.ComboBoxTool combo =
                      (Infragistics.Win.UltraWinToolbars.ComboBoxTool)e.Tool;
                    SdRvFilterCombo_SelectedIndexChanged(combo.SelectedIndex);
                    break;
            }
        }
    }
}