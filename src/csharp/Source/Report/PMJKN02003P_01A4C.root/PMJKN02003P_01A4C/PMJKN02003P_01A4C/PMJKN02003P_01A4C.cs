//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���R�����^���}�X�^
// �v���O�����T�v   : ���R�����^���}�X�^���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2010/04/27  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;
using System.Collections.Specialized;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// PMJKN02003P_01A4C���[�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: ���ɂȂ�</br>
    /// <br>Programmer	: ���C��</br>
    /// <br>Date		: 2010/04/27</br>
    /// </remarks>
    public partial class PMJKN02003P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeCommon, IPrintActiveReportTypeList
    {
        #region Private Members
        // �������
        private int _printCount = 0;

        // �w�i���������[�h(����)
        private int _watermarkMode = 0;

        // ���o�����w�b�_�o�͋敪
        private int _extraCondHeadOutDiv;

        // �֘A�f�[�^�I�u�W�F�N�g
        private ArrayList _otherDataList;

        // ���o�����󎚍���
        private StringCollection _extraConditions;

        // ���_�\���L��
        private bool _isSection;

        // �t�b�^�[�o�͗L��
        private int _pageFooterOutCode;

        // �t�b�^���b�Z�[�W1
        private StringCollection _pageFooters;

        // �\�[�g���^�C�g��
        private string _pageHeaderSortOderTitle;

        // Extra SubReport
        ListCommon_ExtraHeader _rptExtraHeader = new ListCommon_ExtraHeader();

        // ������
        private SFCMN06002C _printInfo;

        // �\�������N���X
        private FreeSearchModelPrint _extrInfo;

        #endregion

        /// <summary>
        /// ProgressBarUpEvent
        /// </summary>
        public event ProgressBarUpEventHandler ProgressBarUpEvent;

        /// <summary>
        /// PMJKN02003P_01A4C���[�R���X�g���N�^
        /// </summary>
        public PMJKN02003P_01A4C()
        {
            InitializeComponent();
        }


        /// <summary>
        /// ���׃A�t�^�[�v�����g�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="eArgs">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note		: �Z�N�V�������y�[�W�ɕ`�悳�ꂽ��ɔ������܂��B</br>
        /// <br>Programmer	: ���C��</br>
        /// <br>Date		: 2010/04/27</br>
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

        /// <summary>
        /// ���|�[�g�X�^�[�g�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="eArgs">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: ���|�[�g�̐����������J�n���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: ���C��</br>
        /// <br>Date		: 2010/04/27</br>
        /// </remarks>
        private void PMJKN02003P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
        {
            // ���|�[�g�v�f�o�͐ݒ�	
            SetOfReportMembersOutput();
        }

        /// <summary>
        /// �y�[�W�w�b�_�t�H�[�}�b�g�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="eArgs">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �Z�N�V�����̃f�[�^�����[�h����A�����ꂽ��ɔ������܂��B</br>
        /// <br>Programmer	: ���C��</br>
        /// <br>Date		: 2010/04/27</br>
        /// </remarks>
        private void PageHeader_Format(object sender, EventArgs eArgs)
        {
            // �쐬���t
            DateTime now = DateTime.Now;
            this.tb_PrintDate.Text = now.ToString("yyyy/MM/dd");
            this.tb_PrintTime.Text = now.ToString("HH:mm");
        }

        /// <summary>
        /// ���o�f�[�^�t�H�[�}�b�g����
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="eArgs">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note		: ���o�f�[�^�t�H�[�}�b�g���������܂��B</br>
        /// <br>Programmer	: ���C��</br>
        /// <br>Date		: 2010/04/27</br>
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

        #region IPrintActiveReportTypeCommon �����o

        /// <summary>�w�i���������[�h</summary>
        /// <value>0�F�w�i����������, 1:�w�i�������L��</value>
        public int WatermarkMode
        {
            set { }
            get { return this._watermarkMode; }
        }

        #endregion

        #region IPrintActiveReportTypeList �����o

        /// <summary>
        /// ���o�����w�b�_�o�͋敪[0:���y�[�W,1:�擪�y�[�W�̂�]
        /// </summary>
        public int ExtraCondHeadOutDiv
        {
            set { this._extraCondHeadOutDiv = value; }
        }

        /// <summary>
        /// ���o�����w�b�_�[����
        /// </summary>
        public StringCollection ExtraConditions
        {
            set
            {
                this._extraConditions = value;
            }
        }

        /// <summary>
        /// ���̑��f�[�^
        /// </summary>
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

        /// <summary>
        /// �t�b�^�[�o�͋敪
        /// </summary>
        public int PageFooterOutCode
        {
            set
            {
                this._pageFooterOutCode = value;
            }
        }

        /// <summary>
        /// �t�b�^�o�͕�
        /// </summary>
        public StringCollection PageFooters
        {
            set
            {
                this._pageFooters = value;
            }
        }

        /// <summary>
        /// �y�[�W�w�b�_�\�[�g���^�C�g������
        /// </summary>
        public string PageHeaderSortOderTitle
        {
            set
            {
                this._pageHeaderSortOderTitle = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PageHeaderSubtitle
        {
            set { }
        }

        /// <summary>
        /// �������
        /// </summary>
        public SFCMN06002C PrintInfo
        {
            set
            {
                this._printInfo = value;
                _extrInfo = (FreeSearchModelPrint)this._printInfo.jyoken;
            }
        }

        #endregion

        /// <summary>
        /// ���|�[�g�v�f�o�͐ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���|�[�g�̗v�f�iHeader�AFooter�AText�j�̏o�͐ݒ�</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010/04/27</br>																
        /// </remarks>																
        private void SetOfReportMembersOutput()
        {
            // ����
            if ((int)this._extrInfo.NewPageDiv == 0)
            {
                CarModelHeader.NewPage = NewPage.None;
            }
            else if ((int)this._extrInfo.NewPageDiv == 1)
            {
                CarModelHeader.NewPage = NewPage.Before;
            }
        }        
    }
}
