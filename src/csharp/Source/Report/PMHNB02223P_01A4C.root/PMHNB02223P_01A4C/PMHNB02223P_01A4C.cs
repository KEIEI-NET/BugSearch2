//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����s�����m�F�\
// �v���O�����T�v   : ����s�����m�F�\���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���痈
// �� �� ��  2009/04/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Collections.Specialized;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Drawing.Printing
{

    /// <summary>
    /// ����s�����m�F�\�f�U�C���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����s�����m�F�\�f�U�C���N���X�̊T�v�̐������s���܂��B</br>
    /// <br>Programmer : ���痈</br>
    /// <br>Date       : 2009.04.10</br>
    /// </remarks>
    public partial class PMHNB02223P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeCommon, IPrintActiveReportTypeList
    {

        //================================================================================
        //  Constructor
        //================================================================================
        #region �R���X�g���N�^�[
        /// <summary>
        /// ����s�����m�F�\������[ActiveReport�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����s�����m�F�\������[ActiveReport�N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.10</br>
        /// </remarks>
        public PMHNB02223P_01A4C()
        {
            //
            // ActiveReport �f�U�C�i �T�|�[�g�ɕK�v�ł��B
            //
            InitializeComponent();
        }
        #endregion

        //================================================================================
        //  �����ϐ�
        //================================================================================
        #region private member
        // ���_�\���L��
        private bool _isSection;

        // ���o�����w�b�_�o�͋敪
        private int _extraCondHeadOutDiv;

        // �\�[�g���^�C�g��
        private string _pageHeaderSortOderTitle;

        // ���o�����󎚍���
        private StringCollection _extraConditions;

        // �t�b�^�[�o�͗L��
        private int _pageFooterOutCode;

        // �t�b�^���b�Z�[�W1
        private StringCollection _pageFooters;

        // ������
        private SFCMN06002C _printInfo;

        // �֘A�f�[�^�I�u�W�F�N�g
        private ArrayList _otherDataList;

        // �w�i���������[�h(����)
        private int _watermarkMode = 0;

        // �������
        private int _printCount = 1;

        // ���o�����N���X
        private SalesStockInfoMainCndtn _extrInfo;

        #endregion

        //================================================================================
        //  �v���p�e�B
        //================================================================================
        #region public property

        #region IPrintActiveReportTypeList �����o
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

        /// <summary>�������</summary>
        /// <value>PrintInfo</value>               
        /// <remarks>��������Z�b�g�v���p�e�B </remarks> 
        public SFCMN06002C PrintInfo
        {
            set
            {
                this._printInfo = value;
                this._extrInfo = (SalesStockInfoMainCndtn)this._printInfo.jyoken;
            }
        }

        /// <summary>���̑��f�[�^</summary>
        /// <value>OtherDataList</value>               
        /// <remarks>���̑��f�[�^�Z�b�g�v���p�e�B </remarks> 
        public ArrayList OtherDataList
        {
            set
            {
                this._otherDataList = value;
                if (this._otherDataList != null)
                {
                    if (this._otherDataList.Count > 0)
                    {
                        this._isSection = (bool)this._otherDataList[0];
                    }
                }
            }
        }

        /// <summary>�T�u�w�b�_�^�C�g��</summary>
        /// <value>PageHeaderSubtitle</value>               
        /// <remarks>�T�u�w�b�_�^�C�g���Z�b�g�v���p�e�B </remarks> 
        public string PageHeaderSubtitle
        {
            set { }
        }
        #endregion

        #region IPrintActiveReportTypeCommon �����o
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
        #endregion
        #endregion

        //================================================================================
        //  �C�x���g
        //================================================================================
        #region event
        /// <summary>
        /// ���|�[�g�X�^�[�g�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="eArgs">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: ���|�[�g�̐����������J�n���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.04.10</br>
        /// </remarks>
        private void PMHNB02223P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
        {
            // �������������
            this._printCount = 0;

        }

        /// <summary>
        /// �y�[�W�w�b�_�t�H�[�}�b�g�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="eArgs">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �Z�N�V�����̃f�[�^�����[�h����A�����ꂽ��ɔ������܂��B</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.04.10</br>
        /// </remarks>
        private void pageHeader_Format(object sender, System.EventArgs eArgs)
        {

            //// �\�[�g��
            this.SORTTITLE.Text = this._pageHeaderSortOderTitle;

            // �쐬���t
            DateTime now = DateTime.Now;
            this.DATE.Text = TDateTime.DateTimeToString("YYYY/MM/DD", now);

            // �쐬����
            this.TIME.Text = TDateTime.DateTimeToString("HH:MM", now);
        }

        /// <summary>
        /// ���_�w�b�_�t�H�[�}�b�g�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="eArgs">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �Z�N�V�����̃f�[�^�����[�h����A�����ꂽ��ɔ������܂��B</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.04.10</br>
        /// </remarks>
        private void ExtraHeader_Format(object sender, System.EventArgs eArgs)
        {

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
            // �w�b�_�[�T�u���|�[�g�쐬
            ListCommon_ExtraHeader rpt = new ListCommon_ExtraHeader();

            // ���o�����󎚍��ڐݒ�
            rpt.ExtraConditions = this._extraConditions;

            this.Extra_SubReport.Report = rpt;

        }


        /// <summary>
        /// ���׃A�t�^�[�v�����g�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="eArgs">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : �Z�N�V�������y�[�W�ɕ`�悳�ꂽ��ɔ������܂��B</br>
        /// <br>Programmer  : ���痈</br>
        /// <br>Date        : 2009.04.10</br>
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

        #region Detail_Format�C�x���g
        /// <summary>
        /// �r���\����\�����䏈���@Detail_Format�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : line��visible���ǂ����B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private void Detail_Format(object sender, EventArgs e)
        {
            if (lineFlag.Text.Equals("true") || lineFlag.Text.Equals("True"))
            {
                this.line5.Visible = true;
            }
            else
            {
                this.line5.Visible = false;
            }
        }
        #endregion

        /// <summary>
        /// Detail_BeforePrint Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �Z�N�V�������y�[�W�ɕ`�悳���O�ɔ�������B</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.05.10</br>
        /// </remarks>
        private void Detail_BeforePrint(object sender, EventArgs e)
        {
            // Wordrap�v���p�e�B�ŕ��������r���[�ȂƂ���ŋ�؂��Ȃ��悤�ɂ��邽�߂̑Ή�
            PrintCommonLibrary.ConvertReportString(this.Detail);
        }

        #endregion

        // ===============================================================================
        // ActiveReports�f�U�C�i�Ő������ꂽ�R�[�h
        // ===============================================================================
        #region ActiveReports Designer generated code
        #endregion

    }
}
