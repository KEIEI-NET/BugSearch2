//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   �d���摍���}�X�^�ꗗ�\ �e���v���[�g�N���X       //
//                  :   PMKAK09013P_01A4C.DLL                           //
// Name Space       :   Broadleaf.Drawing.Printing                      //
// Programmer       :   FSI�����@�v                                     //
// Date             :   2012/09/07                                      //
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//----------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.                 //
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
    /// �d���摍���}�X�^�ꗗ�\���X�g�e���v���[�g�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �d���摍���}�X�^���X�g�e���v���[�g�N���X�B</br>
    /// <br>Programmer	: FSI�����@�v</br>
    /// <br>Date		: 2012/09/07</br>
    /// <br></br>
    /// </remarks>
    public partial class PMKAK09013P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        #region �� Constructor
        /// <summary>
        /// �d���摍���}�X�^�}�X�^���X�g�e���v���[�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: �d���摍���}�X�^�}�X�^���X�g�e���v���[�g�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer	: FSI�����@�v</br>
        /// <br>Date		: 2012/09/07</br>
        /// </remarks>
        public PMKAK09013P_01A4C()
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
        // �w�b�_�[�T�u���|�[�g�錾
        ListCommon_ExtraHeader _rptExtraHeader = null;
        // �w�i���������[�h(����)
        private int _watermarkMode = 0;

        // �������_�R�[�h�\���t���O
        private bool _isSumSectionCd = true;

        // �����d����R�[�h�\���t���O
        private bool _isSumSupplierCd = true;

        // DataSource�Q�Ɨp
        DataTable _printDataTable;

        // �������_�R�[�h��r�p�o�b�t�@
        string _sumSectionCode;

        // �����d����R�[�h��r�p�o�b�t�@
        int _sumSupplierCode;

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
        /// <br>Programmer	: FSI�����@�v</br>
        /// <br>Date		: 2012/09/07</br>
        /// <br></br>
        /// </remarks>
        private void SetOfReportMembersOutput()
        {
            this._printCount = 0;
            // �󎚐ݒ� --------------------------------------------------------------------------------------

            // ���ڂ̖��̂��Z�b�g
            tb_ReportTitle.Text = this._printInfo.prpnm;
        }

        #endregion �� ���|�[�g�v�f�o�͐ݒ�
        #endregion �� Private Method

        #region �� Control Event

        #region �� PMKAK09013P_01A4C_ReportStart Event
        /// <summary>
        /// PMKAK09013P_01A4C_ReportStart Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="eArgs">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���|�[�g�J�n���̃C�x���g�ł��B</br>
        /// <br>Programmer	: FSI�����@�v</br>
        /// <br>Date		: 2012/09/07</br>
        /// </remarks>
        private void PMKAK09013P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
        {
            SetOfReportMembersOutput();

            // �r���̈󎚔���ׁ̈ADataSource���擾
            DataView dv = (DataView)this.DataSource;
            _printDataTable = dv.Table;
            DataRow dr = _printDataTable.Rows[0];

            // �擪���R�[�h�̑������_�R�[�h�A�����d����R�[�h���擾
            _sumSectionCode = (string)dr[PMKAK09015EA.ct_Col_SumSectionCd];
            _sumSupplierCode = (int)dr[PMKAK09015EA.ct_Col_SumSupplierCd];
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
        /// <br>Programmer	: FSI�����@�v</br>
        /// <br>Date		: 2012/09/07</br>
        /// </remarks>
        private void PageHeader_Format(object sender, System.EventArgs eArgs)
        {
            // �쐬���t
            DateTime now = DateTime.Now;
            // �쐬���t
            this.tb_PrintDate.Text = TDateTime.DateTimeToString("YYYY/MM/DD", now);
            // �쐬����
            this.tb_PrintTime.Text = TDateTime.DateTimeToString("HH:MM", now);
            // �\�[�g���\��������΂�����

            // �����d����R�[�h�\���t���O�𗧂Ă�
            this._isSumSupplierCd = true;
            // �������_�R�[�h�\���t���O�𗧂Ă�
            this._isSumSectionCd = true;
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
        /// <br>Programmer	: FSI�����@�v</br>
        /// <br>Date		: 2012/09/07</br>
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

            // ���o�����r���󎚔���
            if (this._extraConditions.Count > 0)
            {
                // ���o�������w�肳�ꂽ�ꍇ�͈�
                line6.Visible = true;
            }
            else
            {
                // ���o�������w��ł���Έ󎚂���
                line6.Visible = false;
            }
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
        /// <br>Programmer	: FSI�����@�v</br>
        /// <br>Date		: 2012/09/07</br>
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
        /// <br>Programmer  : FSI�����@�v</br>                                   
        /// <br>Date        : 2012/09/07</br>                                       
        /// </remarks>
        private void Detail_BeforePrint(object sender, EventArgs e)
        {
            #region [�r���̈󎚐���]

            // �r����Detail�Z�N�V�����ɒ�`����Ă���
            // �r���Ƃ��Ĉ󎚂���̂́Aline4�Aline3�Aline2��line�R���g���[��
            //  line4:�������_�R�[�h�A�������_���e�L�X�g�{�b�N�X�̉��Ɉ�
            //  line3:�����d����R�[�h�A�����d���於�e�L�X�g�{�b�N�X�̉��Ɉ�
            //  line2:���_�R�[�h�`�d���於�e�L�X�g�{�b�N�X�̉��Ɉ�
            // �@�@�@ line2�͏�Ɉ󎚂���

            // line3�Aline4�̈󎚐���
            if (_printCount == (_printDataTable.Rows.Count - 1))
            {
                // ��������p�J�E���^��DataSource�̌����ɓ��B������A���ׂĈ�
                line3.Visible = true;
                line4.Visible = true;
            }
            else
            {
                // Detail�Z�N�V�����ɕ`�悳��鎟�̃f�[�^��DataSource����擾
                DataRow dr = _printDataTable.Rows[_printCount + 1];

                // line3�̐���
                // �������_�R�[�h�A�����d����R�[�h���擾���A�ω����邩�m�F
                int supplierCode = (int)dr[PMKAK09015EA.ct_Col_SumSupplierCd];
                string sectionCode = (string)dr[PMKAK09015EA.ct_Col_SumSectionCd];
                if (_sumSupplierCode != supplierCode)
                {
                    // �����d���悪�ω�����ꍇ�́Aline3����
                    line3.Visible = true;

                    _sumSupplierCode = supplierCode;
                }
                else
                {
                    // �����d���悪�ω����Ȃ��ꍇ�́A����ɑ������_���ω����邩�m�F
                    if (_sumSectionCode != sectionCode)
                    {
                        // �������_���ω�����ꍇ�́Aline3����
                        line3.Visible = true;
                    }
                    else
                    {
                        // �������_���ω����Ȃ��ꍇ�́Aline3���󎚂��Ȃ�
                        line3.Visible = false;
                    }
                }

                // line4�̐���
                // �������_���ω����邩�m�F
                if (_sumSectionCode != sectionCode)
                {
                    // �������_���ω�����ꍇ�́Aline4����
                    line4.Visible = true;

                    _sumSectionCode = sectionCode;
                }
                else
                {
                    // �������_���ω����Ȃ��ꍇ�́Aline4���󎚂��Ȃ�
                    line4.Visible = false;
                }
            }
            #endregion [�r���̈󎚐���]

            #region [�������_�A�����d����󎚐���]

            // �����������_��\�������Ȃ��Ή�
            if (this._isSumSectionCd)
            {
                // ���s�͕\�������Ȃ�
                this._isSumSectionCd = false;
            }
            else
            {
                // �������_�R�[�h�A�������_���͋�ɂ���
                textBox_SumSectionCd.Text = string.Empty;
                textBox_SumSectionGuideSnm.Text = string.Empty;
            }

            // ���������d�����\�������Ȃ��Ή�
            if (this._isSumSupplierCd)
            {
                // ���s�͕\�������Ȃ�
                this._isSumSupplierCd = false;
            }
            else
            {
                // �����d����R�[�h�A�����d���於�͋�ɂ���
                textBox_SumSupplierCd.Text = string.Empty;
                textBox_SumSupplierNm1.Text = string.Empty;
                textBox_SumSupplierNm2.Text = string.Empty;
            }

            #endregion [�������_�A�����d����󎚐���]

            // Wordrap�v���p�e�B�ŕ��������r���[�ȂƂ���ŋ�؂��Ȃ��悤�ɂ��邽�߂̑Ή�
            PrintCommonLibrary.ConvertReportString(this.Detail);
        }
        #endregion �� Detail_BeforePrint Event

        #region �� groupHeader1_Format Event
        /// <summary>
        /// groupHeader1_Format �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : �O���[�v�Z�N�V����(�������_�R�[�h)�t�H�[�}�b�g�C�x���g�ł��B</br>
        /// <br>Programmer  : FSI�����@�v</br>                                   
        /// <br>Date        : 2012/09/07</br> 	
        /// </remarks>
        private void groupHeader1_Format(object sender, EventArgs e)
        {
            // �������_�R�[�h�\���t���O�𗧂Ă�
            this._isSumSectionCd = true;

            // �����d����R�[�h�\���t���O�𗧂Ă�
            this._isSumSupplierCd = true;

        }
        #endregion �� groupHeader1_Format Event

        #region �� groupHeader2_Format Event
        /// <summary>
        /// groupHeader2_Format �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : �O���[�v�Z�N�V����(�����d����R�[�h)�t�H�[�}�b�g�C�x���g�ł��B</br>
        /// <br>Programmer  : FSI�����@�v</br>                                   
        /// <br>Date        : 2012/09/07</br> 	
        /// </remarks>
        private void groupHeader2_Format(object sender, EventArgs e)
        {
            // �����d����R�[�h�\���t���O�𗧂Ă�
            this._isSumSupplierCd = true;
        }
        #endregion �� groupHeader2_Format Event

        #endregion �� Control Event
    }
}
