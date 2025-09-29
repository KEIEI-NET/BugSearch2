//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �^���ʏo�בΉ��\
// �v���O�����T�v   : �^���ʏo�בΉ��\���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2010/04/22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// Update Note : 2010.05.19 zhangsf Redmine #7784�̑Ή�
//             : �E�^���ʏo�בΉ��\�^�e��C��
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
    /// PMSYA02203P_01A4C���[�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: ���ɂȂ�</br>
    /// <br>Programmer	: ���C��</br>
    /// <br>Date		: 2010/04/22</br>
    /// </remarks>
    public partial class PMSYA02203P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeCommon, IPrintActiveReportTypeList
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
        private ModelShipRsltListCndtn _extrInfo;

        // �y�[�W
        private int page = 0;

        #endregion

        /// <summary>
        /// ProgressBarUpEvent
        /// </summary>
        public event ProgressBarUpEventHandler ProgressBarUpEvent;

        /// <summary>
        /// PMSYA02203P_01A4C���[�R���X�g���N�^
        /// </summary>
        public PMSYA02203P_01A4C()
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
        /// <br>Date		: 2010/04/22</br>
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
        /// <br>Date		: 2010/04/22</br>
        /// </remarks>
        private void PMSYA02203P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
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
        /// <br>Date		: 2010/04/22</br>
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
        /// <br>Date		: 2010/04/22</br>
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
                _extrInfo = (ModelShipRsltListCndtn)this._printInfo.jyoken;
            }
        }

        #endregion

        /// <summary>
        /// ���|�[�g�v�f�o�͐ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���|�[�g�̗v�f�iHeader�AFooter�AText�j�̏o�͐ݒ�</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010/04/22</br>																
        /// </remarks>																
        private void SetOfReportMembersOutput()
        {
            // ����
            if ((int)this._extrInfo.NewPageDiv == 0)
            {
                FullModelHeader.NewPage = NewPage.None;
                SectionHeader.NewPage = NewPage.None;
            }
            else if ((int)this._extrInfo.NewPageDiv == 1)
            {
                //�S�ЈȊO�̏ꍇ
                if ((int)_extrInfo.GroupBySectionDiv != 0)
                {
                    FullModelHeader.NewPage = NewPage.None;
                    SectionHeader.NewPage = NewPage.Before;
                }
                else
                {
                    FullModelHeader.NewPage = NewPage.None;
                    SectionHeader.NewPage = NewPage.None;
                }
            }
            else
            {
                FullModelHeader.NewPage = NewPage.Before;
                SectionHeader.NewPage = NewPage.None;
            }
        }

        /// <summary>
        /// Detail_Format �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="eArgs">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���׃Z�N�V�����̃t�H�[�}�b�g�C�x���g�ł��B</br>
        /// <br>Programmer : ���C��</br>
        /// <br>Date       : 2010/04/22</br>		
        /// </remarks>
        private void Detail_Format(object sender, System.EventArgs eArgs)
        {
            DataView dv = this.DataSource as DataView;
            DataTable data = dv.Table;

            string bLGoodsCode = string.Empty;
            string makerCode = string.Empty;
            string resultsAddUpSecCdRF = string.Empty;
            string makerCodeRF = string.Empty;
            string modelCodeRF = string.Empty;
            string modelSubCodeRF = string.Empty;
            string fullModelRF = string.Empty;

            foreach (DataRow row in data.Rows)
            {
                if (page == this.PageNumber
                    && bLGoodsCode == (string)row["BLGoodsCodeRF"]
                    && makerCode == (string)row["GoodsMakerCd1RF"]
                    && resultsAddUpSecCdRF == (string)row["ResultsAddUpSecCdRF"]
                    && makerCodeRF == (string)row["MakerCodeRF"]
                    && modelCodeRF == (string)row["ModelCodeRF"]
                    && modelSubCodeRF == (string)row["ModelSubCodeRF"]
                    && fullModelRF == (string)row["FullModelRF"])
                {
                    row["BLGoodsCodeRF"] = string.Empty;
                    row["BLGoodsHalfNameRF"] = string.Empty;
                    row["GoodsMakerCd1RF"] = string.Empty;
                    row["GoodsMakerName1RF"] = string.Empty;
                }
                else
                {
                    bLGoodsCode = (string)row["BLGoodsCodeRF"];
                    makerCode = (string)row["GoodsMakerCd1RF"];
                    resultsAddUpSecCdRF = (string)row["ResultsAddUpSecCdRF"];
                    makerCodeRF = (string)row["MakerCodeRF"];
                    modelCodeRF = (string)row["ModelCodeRF"];
                    modelSubCodeRF = (string)row["ModelSubCodeRF"];
                    fullModelRF = (string)row["FullModelRF"];
                    page = this.PageNumber;
                }
            }
        }

        // ADD 2010.05.19 zhangsf FOR Redmine #7784 *-------------------->>>
        /// <summary>
        /// Detail_BeforePrint �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="eArgs">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���׃Z�N�V�����̃t�H�[�}�b�g�C�x���g�ł��B</br>
        /// <br>Programmer : zhangsf</br>
        /// <br>Date       : 2010/05/19</br>		
        /// </remarks>
        private void Detail_BeforePrint(object sender, EventArgs e)
        {
            if (detail==null)
                return;

            // ���[�J�[�R�[�h�̈�
            if (tb_GoodsMakerCd1.Text == "0000")
                tb_GoodsMakerCd1.Text = "";

            // ���݌ɐ��̈�
            if (tb_SupplierStock.Text == "0.00")
            {
                // �󎚔���t���O
                bool blnNotprint = true;

                // ���݌ɐ��󎚏������f
                if (_extraConditions != null && tb_WarehouseShelfNo.Text != null)
                {
                    if (tb_WarehouseShelfNo.Text.Trim() != "")
                    {
                        foreach (string strCdn in _extraConditions)
                        {
                            if (strCdn.IndexOf("�q��") > 0)
                            {
                                blnNotprint = false;
                            }
                        }
                    }
                }
                // �󎚂��Ȃ�
                if (blnNotprint)
                    tb_SupplierStock.Text = "";
            }
        }
        // ADD 2010.05.19 zhangsf FOR Redmine #7784 <<<--------------------*
    }
}
