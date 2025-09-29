//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����A�g�e�L�X�g�o��
// �v���O�����T�v   : ����A�g�e�L�X�g�o�͒��[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570219-00     �쐬�S�� : �c����
// �� �� ��  2019/12/02      �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using Broadleaf.Drawing.Printing;
using System.Collections.Specialized;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// PMSDC02012P_01A4C���[�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: ���ɂȂ�</br>
    /// <br>Programmer	: �c����</br>
    /// <br>Date		: 2019/12/02</br>
    /// </remarks> 
    public partial class PMSDC02012P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        #region ��Constructor
        /// <summary>
        /// SE����f�[�^�e�L�X�g������[ActiveReport�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note        : SE����f�[�^�e�L�X�g������[ActiveReport�N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2019/12/02</br>
        /// </remarks>
        public PMSDC02012P_01A4C()
        {
            //
            // ActiveReport �f�U�C�i �T�|�[�g�ɕK�v�ł��B
            //
            InitializeComponent();
        }
        #endregion�@��Constructor

        #region  ��Private Members
        private int _printCount;						// ��������p�J�E���^

        private int _extraCondHeadOutDiv;			    // ���o�����w�b�_�o�͋敪
        private StringCollection _extraConditions;		// ���o����
        private int _pageFooterOutCode;				    // �t�b�^�[�o�͋敪
        private StringCollection _pageFooters;			// �t�b�^�[���b�Z�[�W
        private SFCMN06002C _printInfo;					// ������N���X
        private string _pageHeaderTitle;				// �t�H�[���^�C�g��
        private string _pageHeaderSortOderTitle;		// �\�[�g��

        // �w�b�_�[�T�u���|�[�g�쐬
        ListCommon_ExtraHeader _rptExtraHeader = null;
        // �t�b�^�[���|�[�g�錾
        ListCommon_PageFooter _rptPageFooter = null;
        // ���C���T�\���t���O
        private bool _isLine5ShowFlg = true;
        // ���C���V�\���t���O
        private bool _isLine7ShowFlg = true; 
        #endregion�@��Private Members

        #region �� IPrintActiveReportTypeList �����o
        #region �� Public Property

        /// <summary> ���o�����w�b�_�o�͋敪[0:���y�[�W,1:�擪�y�[�W�̂�]</summary>
        /// <value>ExtraCondHeadOutDiv</value>               
        /// <remarks>���o�����w�b�_�o�͋敪[0:���y�[�W,1:�擪�y�[�W�̂�]�Z�b�g�v���p�e�B </remarks> 
        public int ExtraCondHeadOutDiv
        {
            set { this._extraCondHeadOutDiv = value; }
        }

        /// <summary> ���o�����w�b�_�[����</summary>
        /// <value>ExtraConditions</value>               
        /// <remarks>���o�����w�b�_�[���ڃZ�b�g�v���p�e�B </remarks> 
        public StringCollection ExtraConditions
        {
            set
            {
                this._extraConditions = value;
            }
        }

        /// <summary>���̑��f�[�^</summary>
        /// <value>OtherDataList</value>               
        /// <remarks>���̑��f�[�^�Z�b�g�v���p�e�B </remarks> 
        public ArrayList OtherDataList
        {
            set
            {
            }
        }

        /// <summary> �t�b�^�[�o�͋敪</summary>
        /// <value>PageFooterOutCode</value>               
        /// <remarks>�t�b�^�[�o�͋敪�Z�b�g�v���p�e�B </remarks> 
        public int PageFooterOutCode
        {
            set
            {
                this._pageFooterOutCode = value;
            }
        }

        /// <summary> �t�b�^�o�͕�</summary>
        /// <value>PageFooters</value>               
        /// <remarks>�t�b�^�o�͕��Z�b�g�v���p�e�B </remarks> 
        public StringCollection PageFooters
        {
            set
            {
                this._pageFooters = value;
            }
        }

        /// <summary> �y�[�W�w�b�_�\�[�g���^�C�g������</summary>
        /// <value>PageHeaderSortOderTitle</value>               
        /// <remarks>�y�[�W�w�b�_�\�[�g���^�C�g�����ڃZ�b�g�v���p�e�B </remarks> 
        public string PageHeaderSortOderTitle
        {
            set
            {
                this._pageHeaderSortOderTitle = value;
            }
        }

        /// <summary>�T�u�w�b�_�^�C�g��</summary>
        /// <value>PageHeaderSubtitle</value>               
        /// <remarks>�T�u�w�b�_�^�C�g���Z�b�g�v���p�e�B </remarks> 
        public string PageHeaderSubtitle
        {
            set { this._pageHeaderTitle = value; }
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

        /// <summary>�v���O���X�o�[�J�E���g�A�b�v�C�x���g
        /// <value>ProgressBarUpEventHandler</value>               
        /// </summary>
        public event ProgressBarUpEventHandler ProgressBarUpEvent;
        #endregion �� Public Property
        #endregion �� IPrintActiveReportTypeList �����o

        #region �� IPrintActiveReportTypeCommon �����o
        #region �� Public Property
        /// <summary>�w�i���������[�h</summary>
        /// <value>0�F�w�i����������, 1:�w�i�������L��</value>
        public int WatermarkMode
        {
            set { }
            get { return 0; }
        }
        #endregion �� Public Property
        #endregion �� IPrintActiveReportTypeCommon �����o

        #region �� PageHeader_Format Event
        /// <summary>
        /// PageHeader_Format Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �Z�N�V�����̃f�[�^�����[�h����A�����ꂽ��ɔ������܂��B</br>
        /// <br>Programmer  : �c����</br>                                   
        /// <br>Date        : 2019/12/02</br>                                       
        /// </remarks>
        private void PageHeader_Format(object sender, EventArgs e)
        {
            //���݂̎������擾
            DateTime now = DateTime.Now;
            // �쐬���t
            this.DATE.Text = TDateTime.DateTimeToString("YYYY/MM/DD", now);

            // �쐬����
            this.TIME.Text = TDateTime.DateTimeToString("HH:MM", now);

            if (this._extraConditions.Count == 0)
            {
                this.PageHeader.Height = float.Parse("0.25");
            }
            else
            {
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

                this.Extra_SubReport.Report = _rptExtraHeader;

            }
        }
        #endregion�@�� PageHeader_Format Event

        #region �� Detail_BeforePrint Event
        /// <summary>
        /// Detail_BeforePrint Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �Z�N�V�������y�[�W�ɕ`�悳���O�ɔ�������B</br>
        /// <br>Programmer  : �c����</br>                                   
        /// <br>Date        : 2019/12/02</br>  
        /// </remarks>
        private void Detail_BeforePrint(object sender, EventArgs e)
        {
            // Wordrap�v���p�e�B�ŕ��������r���[�ȂƂ���ŋ�؂��Ȃ��悤�ɂ��邽�߂̑Ή�
            PrintCommonLibrary.ConvertReportString(this.Detail);
        }
        #endregion

        #region �� Detail_AfterPrint Event
        /// <summary>
        /// Detail_AfterPrint Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �Z�N�V�������y�[�W�ɕ`�悳���㔭������B</br>
        /// <br>Programmer  : �c����</br>                                   
        /// <br>Date        : 2019/12/02</br>
        /// </remarks>
        private void Detail_AfterPrint(object sender, EventArgs e)
        {
            // ��������J�E���g�A�b�v
            this._printCount++;

            if (this.ProgressBarUpEvent != null)
            {
                this.ProgressBarUpEvent(this, this._printCount);
            }
            if ((this._printCount % 34) != 0)
            {
                _isLine5ShowFlg = true;
            }
        }
        #endregion

        #region �� PMSDC02012P_01A4C_ReportStart Event
        /// <summary>
        /// PMSDC02012P_01A4C_ReportStart Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���|�[�g�J�n���̃C�x���g�ł��B</br>
        /// <br>Programmer  : �c����</br>                                   
        /// <br>Date        : 2019/12/02</br>  
        /// </remarks>
        private void PMSDC02012P_01A4C_ReportStart(object sender, EventArgs e)
        {
            SetOfReportMembersOutput();
        }
        #endregion

        #region �� PageFooter_Format Event
        /// <summary>
        /// PageFooter_Format Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: PageFooter�O���[�v�̃t�H�[�}�b�g�C�x���g�B</br>
        /// <br>Programmer  : �c����</br>                                   
        /// <br>Date        : 2019/12/02</br>  
        /// </remarks>
        private void PageFooter_Format(object sender, EventArgs e)
        {
            if (this._pageFooterOutCode == 0)
            {
                // �C���X�^���X���쐬����Ă��Ȃ���΍쐬
                if (_rptPageFooter == null)
                {
                    _rptPageFooter = new ListCommon_PageFooter();
                }
                else
                {
                    // �C���X�^���X���쐬����Ă���΁A�f�[�^�\�[�X������������
                    // (�o�C���h����f�[�^�\�[�X�������f�[�^�ł����Ă��A��x���������Ă����Ȃ��Ƃ��܂��������Ȃ��B
                    _rptPageFooter.DataSource = null;
                }

                // �t�b�^�[�󎚍��ڐݒ�
                if (this._pageFooters[0] != null)
                {
                    _rptPageFooter.PrintFooter1 = this._pageFooters[0];
                }
                if (this._pageFooters[1] != null)
                {
                    _rptPageFooter.PrintFooter2 = this._pageFooters[1];
                }

                this.Footer_SubReport.Report = _rptPageFooter;
            }
        }
        #endregion

        #region �� Private Method
        /// <summary>
        /// ���|�[�g�v�f�o�͐ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���|�[�g�̗v�f�iHeader�AFooter�AText�j�̏o�͐ݒ�</br>
        /// <br>Programmer  : �c����</br>                                   
        /// <br>Date        : 2019/12/02</br>  
        /// </remarks>
        private void SetOfReportMembersOutput()
        {
            this._printCount = 0;
            // �󎚐ݒ� --------------------------------------------------------------------------------------

            // ���ڂ̖��̂��Z�b�g
            //tb_ReportTitle.Text = this._pageHeaderTitle;				// �T�u�^�C�g��
        }

        /// <summary>
        /// PageFooter_Format Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: PageFooter�O���[�v�̃t�H�[�}�b�g�C�x���g�B</br>
        /// <br>Programmer  : �c����</br>                                   
        /// <br>Date        : 2019/12/02</br>  
        /// </remarks>
        private void PageFooter_Format_1(object sender, EventArgs e)
        {
            if (this._pageFooterOutCode == 0)
            {
                // �C���X�^���X���쐬����Ă��Ȃ���΍쐬
                if (_rptPageFooter == null)
                {
                    _rptPageFooter = new ListCommon_PageFooter();
                }
                else
                {
                    // �C���X�^���X���쐬����Ă���΁A�f�[�^�\�[�X������������
                    // (�o�C���h����f�[�^�\�[�X�������f�[�^�ł����Ă��A��x���������Ă����Ȃ��Ƃ��܂��������Ȃ��B
                    _rptPageFooter.DataSource = null;
                }

                // �t�b�^�[�󎚍��ڐݒ�
                if (this._pageFooters[0] != null)
                {
                    _rptPageFooter.PrintFooter1 = this._pageFooters[0];
                }
                if (this._pageFooters[1] != null)
                {
                    _rptPageFooter.PrintFooter2 = this._pageFooters[1];
                }

                this.Footer_SubReport.Report = _rptPageFooter;
            }
        }
        #endregion

        #region �� SectionCodeHeader_Format Event
        /// <summary>
        /// SectionCodeHeader_Format Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �Z�N�V�������y�[�W�ɕ`�悳��鎞�ɔ�������B</br>
        /// <br>Programmer  : �c����</br>                                   
        /// <br>Date        : 2019/12/02</br>  
        /// </remarks>
        private void SectionCodeHeader_Format(object sender, EventArgs e)
        {
            _isLine5ShowFlg = false;            
        }
        #endregion

        #region �� SectionCodeFooter_BeforePrint Event
        /// <summary>
        /// SectionCodeFooter_BeforePrint Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �Z�N�V�������y�[�W�ɕ`�悳���O�ɔ�������B</br>
        /// <br>Programmer  : �c����</br>                                   
        /// <br>Date        : 2019/12/02</br>  
        /// </remarks>
        private void SectionCodeFooter_BeforePrint(object sender, EventArgs e)
        {
            if (_isLine5ShowFlg)
            {
                line5.Visible = true;
            }
            else
            {
                line5.Visible = false;
            }             
        }
        #endregion

        #region �� TitleHeader_Format Event
        /// <summary>
        /// TitleHeader_Format Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �Z�N�V�������y�[�W�ɕ`�悳��鎞�ɔ�������B</br>
        /// <br>Programmer  : �c����</br>                                   
        /// <br>Date        : 2019/12/02</br>  
        /// </remarks>
        private void TitleHeader_Format(object sender, EventArgs e)
        {
            _isLine7ShowFlg = false;
        }
        #endregion

        #region �� SectionCodeHeader_AfterPrint Event
        /// <summary>
        /// SectionCodeHeader_AfterPrint Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �Z�N�V�������y�[�W�ɕ`�悳����ɔ�������B</br>
        /// <br>Programmer  : �c����</br>                                   
        /// <br>Date        : 2019/12/02</br>      
        /// </remarks>
        private void SectionCodeHeader_AfterPrint(object sender, EventArgs e)
        {
            _isLine7ShowFlg = true;
        }
        #endregion

        #region �� GrandFooter_BeforePrint Event
        /// <summary>
        /// GrandFooter_BeforePrint Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �Z�N�V�������y�[�W�ɕ`�悳���O�ɔ�������B</br>
        /// <br>Programmer  : �c����</br>                                   
        /// <br>Date        : 2019/12/02</br>         
        /// </remarks>
        private void GrandFooter_BeforePrint(object sender, EventArgs e)
        {
            if (_isLine7ShowFlg)
            {
                line7.Visible = true;
            }
            else
            {
                line7.Visible = false;
            }
        }
        #endregion

    }
}
