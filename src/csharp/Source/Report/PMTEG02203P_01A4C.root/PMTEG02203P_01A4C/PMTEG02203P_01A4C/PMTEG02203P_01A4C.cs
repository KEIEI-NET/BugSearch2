//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   ��`���ψꗗ�\ �e���v���[�g�N���X               //
//                  :   PMTEG02203P_01A4C.DLL                           //
// Name Space       :   Broadleaf.Drawing.Printing                      //
// Programmer       :   ���R                                            //
// Date             :   2010.05.05                                      //
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//----------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.                 //
//**********************************************************************//
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using System.Collections.Specialized;
using System.Data;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// ��`���ψꗗ�\�e���v���[�g�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: ��`���ψꗗ�\�e���v���[�g�N���X�B</br>
    /// <br>Programmer	: ���R</br>
    /// <br>Date		: 2010.05.05</br>
    /// <br></br>
    /// </remarks>
    public partial class PMTEG02203P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        #region �� Constructor
        /// <summary>
        /// ��`���ψꗗ�\�e���v���[�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��`���ψꗗ�\�e���v���[�g�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2010.05.05</br>
        /// </remarks>
        public PMTEG02203P_01A4C()
        {
            InitializeComponent();
        }
        #endregion �� Constructor

        #region �� Private Member
        // ��������p�J�E���^
        private int _printCount;
        // ���o�����w�b�_�o�͋敪
        private int _extraCondHeadOutDiv;
        // ���o����	
        private StringCollection _extraConditions;
        // �t�b�^�[�o�͋敪	
        private int _pageFooterOutCode;
        // �t�b�^�[���b�Z�[�W	
        private StringCollection _pageFooters;
        // ������N���X			
        private SFCMN06002C _printInfo;
        // �\�[�g��			
        private string _pageHeaderSortOderTitle;
        // ���o�����N���X
        private TegataKessaiReport _tegataKessaiReport;
        // �w�b�_�[�T�u���|�[�g�錾
        ListCommon_ExtraHeader _rptExtraHeader = null;
        // �w�i���������[�h(����)
        private int _watermarkMode = 0;
        // �y�[�W
        int page = 0;

        /// <summary>������</summary>
        private const string STR_DEPOSITDATE = "������";
        /// <summary>������</summary>
        private const string STR_PAYMENTDATE = "�x����";

        #endregion �� Private Member

        #region �� IPrintActiveReportTypeList �����o
        #region �� Public Property
        /// <summary> �y�[�W�w�b�_�\�[�g���^�C�g������</summary>
        /// <value>PageHeaderSortOderTitle</value>               
        /// <remarks>�y�[�W�w�b�_�\�[�g���^�C�g�����ڃZ�b�g�v���p�e�B </remarks> 
        public string PageHeaderSortOderTitle
        {
            set { _pageHeaderSortOderTitle = value; }
        }

        /// <summary> ���o�����w�b�_�o�͋敪[0:���y�[�W,1:�擪�y�[�W�̂�]</summary>
        /// <value>ExtraCondHeadOutDiv</value>               
        /// <remarks>���o�����w�b�_�o�͋敪[0:���y�[�W,1:�擪�y�[�W�̂�]�Z�b�g�v���p�e�B </remarks> 
        public int ExtraCondHeadOutDiv
        {
            set { _extraCondHeadOutDiv = value; }
        }

        /// <summary> ���o�����w�b�_�[����</summary>
        /// <value>ExtraConditions</value>               
        /// <remarks>���o�����w�b�_�[���ڃZ�b�g�v���p�e�B </remarks> 
        public StringCollection ExtraConditions
        {
            set { this._extraConditions = value; }
        }

        /// <summary> �t�b�^�[�o�͋敪</summary>
        /// <value>PageFooterOutCode</value>               
        /// <remarks>�t�b�^�[�o�͋敪�Z�b�g�v���p�e�B </remarks> 
        public int PageFooterOutCode
        {
            set { this._pageFooterOutCode = value; }
        }

        /// <summary> �t�b�^�o�͕�</summary>
        /// <value>PageFooters</value>               
        /// <remarks>�t�b�^�o�͕��Z�b�g�v���p�e�B </remarks> 
        public StringCollection PageFooters
        {
            set { this._pageFooters = value; }
        }

        /// <summary>�������</summary>
        /// <value>PrintInfo</value>               
        /// <remarks>��������Z�b�g�v���p�e�B </remarks> 
        public SFCMN06002C PrintInfo
        {
            set
            {
                this._printInfo = value;
                this._tegataKessaiReport = (TegataKessaiReport)this._printInfo.jyoken;
            }
        }

        /// <summary>���̑��f�[�^</summary>
        /// <value>OtherDataList</value>               
        /// <remarks>���̑��f�[�^�Z�b�g�v���p�e�B </remarks> 
        public ArrayList OtherDataList
        {
            set { }
        }

        /// <summary>�T�u�w�b�_�^�C�g��</summary>
        /// <value>PageHeaderSubtitle</value>               
        /// <remarks>�T�u�w�b�_�^�C�g���Z�b�g�v���p�e�B </remarks> 
        public string PageHeaderSubtitle
        {
            set { }
        }

        #endregion �� Public Property
        #endregion �� IPrintActiveReportTypeList �����o

        #region ��IPrintActiveReportTypeCommon �����o
        /// <summary>�v���O���X�o�[�J�E���g�A�b�v�C�x���g</summary>
        public event ProgressBarUpEventHandler ProgressBarUpEvent;

        /// <summary>�w�i���������[�h</summary>
        /// <value>0�F�w�i����������, 1:�w�i�������L��</value>
        /// <remarks>�w�i���������[�h�Z�b�g���͎擾�v���p�e�B </remarks> 
        public int WatermarkMode
        {
            set { }
            get { return this._watermarkMode; }
        }
        #endregion ��IPrintActiveReportTypeCommon �����o

        #region �� Private Method
        #region �� ���|�[�g�v�f�o�͐ݒ�
        /// <summary>
        /// ���|�[�g�v�f�o�͐ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���|�[�g�̗v�f�iHeader�AFooter�AText�j�̏o�͐ݒ�</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2010.05.05</br>
        /// <br></br>
        /// </remarks>
        private void SetOfReportMembersOutput()
        {
            this._printCount = 0;
            // �󎚐ݒ� --------------------------------------------------------------------------------------

            // ���ڂ̖��̂��Z�b�g
            tb_ReportTitle.Text = GetReportTitle(this._tegataKessaiReport.DraftDivide); 

        }
        /// <summary>
        /// ���ڂ̖��̐ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���ڂ̖��̂��Z�b�g</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2010.05.05</br>
        /// <br></br>
        /// </remarks>
        private String GetReportTitle(int draftDivide)
        {
            string printName = string.Empty;
            if (0 == draftDivide)
            {
                printName = "����`���ψꗗ�\";
            }
            else
            {
                printName = "�x����`���ψꗗ�\";
            }
            return printName;

        }
        #endregion �� ���|�[�g�v�f�o�͐ݒ�
        #endregion

        #region �� Control Event

        #region �� PMTEG02203P_01A4C_ReportStart Event
        /// <summary>
        /// PMTEG02203P_01A4C_ReportStart Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="eArgs">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���|�[�g�J�n���̃C�x���g�ł��B</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2010.05.05</br>
        /// </remarks>
        private void PMTEG02203P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
        {
            SetOfReportMembersOutput();
        }
        #endregion

        #region �� PageHeader_Format Event
        /// <summary>
        /// PageHeader_Format Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="eArgs">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �Z�N�V�����̃f�[�^�����[�h����A�����ꂽ��ɔ������܂��B</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2010.05.05</br>
        /// </remarks>
        private void PageHeader_Format(object sender, System.EventArgs eArgs)
        {
            // �쐬���t
            DateTime now = DateTime.Now;
            // �쐬���t
            this.tb_PrintDate.Text = TDateTime.DateTimeToString("YYYY/MM/DD", now);
            // �쐬����
            this.tb_PrintTime.Text = TDateTime.DateTimeToString("HH:MM", now);
            // ����`
            if (this._tegataKessaiReport.DraftDivide == 0)
            {
                if (this._tegataKessaiReport.SortOrder == 0)
                    // ��s/�x�X�|�������|�������|��`�ԍ�
                    this.Lb_SortOrder.Text = " ��s/�x�X�|�������|�������|��`�ԍ� ��";
                else
                    // �������|��s/�x�X�|�������|��`�ԍ�
                    this.Lb_SortOrder.Text = " �������|��s/�x�X�|�������|��`�ԍ� ��";
            }
            // �x����`
            else
            {
                if (this._tegataKessaiReport.SortOrder == 0)
                    // ��s/�x�X�|�x�����|�������|��`�ԍ�
                    this.Lb_SortOrder.Text = " ��s/�x�X�|�x�����|�������|��`�ԍ� ��";
                else
                    // �������|��s/�x�X�|�x�����|��`�ԍ�
                    this.Lb_SortOrder.Text = " �������|��s/�x�X�|�x�����|��`�ԍ� ��";
            }
        }
        #endregion

        #region �� ExtraHeader_Format Event
        /// <summary>
        /// ExtraHeader_Format Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="eArgs">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ExtraHeader�O���[�v�̃t�H�[�}�b�g�C�x���g�B</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2010.05.05</br>
        /// </remarks>
        private void ExtraHeader_Format(object sender, System.EventArgs eArgs)
        {
            // ���o�����ݒ�
            // �w�b�_�o�͐���
            if (this._extraCondHeadOutDiv == 0)
            {
                // ���y�[�W�o��
                this.ExtraHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
            }
            else
            {
                // �擪�y�[�W�̂�
                this.ExtraHeader.RepeatStyle = RepeatStyle.None;
            }

            // �C���X�^���X���쐬����Ă��Ȃ���΍쐬
            if (this._rptExtraHeader == null)
            {
                this._rptExtraHeader = new ListCommon_ExtraHeader();
            }
            else
            {
                // �C���X�^���X���쐬����Ă���΁A�f�[�^�\�[�X������������
                // (�o�C���h����f�[�^�\�[�X�������f�[�^�ł����Ă��A��x���������Ă����Ȃ��Ƃ��܂��������Ȃ��B
                this._rptExtraHeader.DataSource = null;
            }

            // ���o�����󎚍��ڐݒ�
            this._rptExtraHeader.ExtraConditions = this._extraConditions;

            this.Header_SubReport.Report = this._rptExtraHeader;
        }
        #endregion

        #region �� Detail_AfterPrint Event
        /// <summary>
        /// Detail_AfterPrint Event
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="eArgs">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : �Z�N�V�������y�[�W�ɕ`�悳�ꂽ��ɔ������܂��B</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2010.05.05</br>
        /// </remarks>
        private void Detail_AfterPrint(object sender, System.EventArgs eArgs)
        {
            // ��������J�E���g�A�b�v
            this._printCount++;

            if (this.ProgressBarUpEvent != null)
            {
                this.ProgressBarUpEvent(this, this._printCount);
            }
        }
        #endregion

        #region �� Detail_BeforePrint Event
        /// <summary>
        /// Detail_BeforePrint�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note		: �Z�N�V�������y�[�W�ɕ`�悳���O�ɔ������܂��B</br>
        /// <br>Programmer  : ���R</br>                                   
        /// <br>Date        : 2010.05.05</br>                                       
        /// </remarks>
        private void Detail_BeforePrint(object sender, EventArgs e)
        {
            // Wordrap�v���p�e�B�ŕ��������r���[�ȂƂ���ŋ�؂��Ȃ��悤�ɂ��邽�߂̑Ή�
            PrintCommonLibrary.ConvertReportString(this.Detail);
        }
        #endregion �� Detail_BeforePrint Event
        #endregion �� Control Event

        /// <summary>
        /// TitleHeader_Format �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="eArgs">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �^�C�g���w�b�_�Z�N�V�����̃t�H�[�}�b�g�C�x���g�ł��B</br>
        /// <br>Programmer  : ���R</br>                                   
        /// <br>Date        : 2010.05.05</br> 	
        /// </remarks>
        private void TitleHeader_Format(object sender, System.EventArgs eArgs)
        {
            //TitleHeader�̓�����/�x�����̐ݒ�
            string dateStr = null;
            // ����`
            if (this._tegataKessaiReport.DraftDivide == 0)
                dateStr = STR_DEPOSITDATE;
            // �x����`
            else
                dateStr = STR_PAYMENTDATE;
            this.Lb_DepositDate.Text = dateStr;

        }

        /// <summary>
        /// Detail_Format �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="eArgs">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���׃Z�N�V�����̃t�H�[�}�b�g�C�x���g�ł��B</br>
        /// <br>Programmer  : ���R</br>                                   
        /// <br>Date        : 2010.05.05</br> 	
        /// </remarks>
        private void Detail_Format(object sender, System.EventArgs eArgs)
        {
            DataView dv = this.DataSource as DataView;
            DataTable data = dv.Table;
            int rowIndex = 0;
            string bankAndBranchNm = string.Empty;
            foreach (DataRow row in data.Rows)
            {

                if (page == this.PageNumber
                    && bankAndBranchNm == (string)row["BankAndBranchNm"] && ((rowIndex % 54) != 0))
                {

                    row["BankAndBranchNm"] = string.Empty;
                }
                else
                {
                    bankAndBranchNm = (string)row["BankAndBranchNm"];
                    page = this.PageNumber;
                }
                rowIndex++;
            }

        }

    }
}
