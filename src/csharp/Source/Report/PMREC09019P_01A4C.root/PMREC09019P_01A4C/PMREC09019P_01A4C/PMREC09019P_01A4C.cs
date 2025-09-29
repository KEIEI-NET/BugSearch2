//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���R�����h�ݒ�}�X�^��� �e���v���[�g�N���X
// �v���O�����T�v   : ���R�����h�ݒ�}�X�^������s��
//----------------------------------------------------------------------------//
//                (c)Copyright 2014 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�               �쐬�S�� : �� �B
// �� �� ��  2015/02/23   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
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
using System.Text;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// ���R�����h�ݒ�}�X�^����e���v���[�g�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: ���R�����h�ݒ�}�X�^����e���v���[�g�N���X�B</br>
    /// <br>Programmer	: �� �B</br>
    /// <br>Date		: 2015/02/23</br>
    /// <br></br>
    /// </remarks>
    public partial class PMREC09019P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        #region �� Constructor
        /// <summary>
        /// ���R�����h�ݒ�}�X�^����e���v���[�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���R�����h�ݒ�}�X�^����e���v���[�g�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer	: �� �B</br>
        /// <br>Date		: 2015/02/23</br>
        /// </remarks>
        public PMREC09019P_01A4C()
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
        private SearchCondition _inventoryDataDspParam;
        // �w�i���������[�h(����)
        private int _watermarkMode = 0;

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
                this._inventoryDataDspParam = (SearchCondition)this._printInfo.jyoken;
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
        /// <br>Programmer	: �� �B</br>
        /// <br>Date		: 2015/02/23</br>
        /// <br></br>
        /// </remarks>
        private void SetOfReportMembersOutput()
        {
            this._printCount = 0;
            /*
            if (this._inventoryDataDspParam.GoodsMakerCd == 0)
            {
                this.lb_MakerNameDsp.Text = "�S���[�J�[";
            }
            else
            {
                //this.lb_MakerNameDsp.Text = this._inventoryDataDspParam.GoodsMakerName; // DEL 2014/03/26 �� �B Redmine#42247
                this.lb_MakerNameDsp.Text = SubStringOfByte(this._inventoryDataDspParam.GoodsMakerName, 10); // ADD 2014/03/26 �� �B Redmine#42247
            }

            // �\���^�C�v
            if (this._inventoryDataDspParam.ListTypeDiv == 2)
            {
                // �\���^�C�v�F�ő�
                // �I�����z�F��\��
                this.lb_InventoryMony.Visible = false;
                this.tb_InventoryMony.Visible = false;
                // �ő�I�����z�F�\��
                this.lb_MaxInventoryMony.Visible = true;
                this.tb_MaxInventoryMony.Visible = true;
                // ���z�F�\��
                this.lb_Balance.Visible = true;
                this.tb_Balance.Visible = true;
            }
            else
            {
                // �\���^�C�v�F�ő�ȊO
                // �I�����z�F�\��
                this.lb_InventoryMony.Visible = true;
                this.tb_InventoryMony.Visible = true;
                // �ő�I�����z�F��\��
                this.lb_MaxInventoryMony.Visible = false;
                this.tb_MaxInventoryMony.Visible = false;
                // ���z�F��\��
                this.lb_Balance.Visible = false;
                this.tb_Balance.Visible = false;
            }
             */ 
        }

        //----- ADD 2014/03/26 �� �B Redmine#42247 ---------->>>>>
        /// <summary>
        /// ��������ɂ��A�w��o�C�g���̖ڕW������̎擾
        /// </summary>
        /// <param name="orgString">��������</param>
        /// <param name="byteCount">�w��o�C�g��</param>
        /// <returns>�ڕW������</returns>
        /// <remarks>
        /// <br>Note		: ��������ɂ��A�w��o�C�g���̖ڕW������̎擾</br>
        /// <br>Programmer	: �� �B</br>
        /// <br>Date		: 2014/03/26</br>
        /// </remarks>
        private string SubStringOfByte(string orgString, int byteCount)
        {
            if (byteCount <= 0)
            {
                return string.Empty;
            }

            Encoding encoding = Encoding.Default;

            string resultString = string.Empty;

            // ���炩���߁u�������v���w�肵�Đ؂蔲���Ă���
            // (���̒i�K��byte����<������>�`2*<������>�̊ԂɂȂ�)
            orgString = orgString.PadRight(byteCount).Substring(0, byteCount);

            int count;

            for (int i = orgString.Length; i >= 0; i--)
            {
                // �u�������v�����炷
                resultString = orgString.Substring(0, i);

                // �o�C�g�����擾���Ĕ���
                count = encoding.GetByteCount(resultString);
                if (count <= byteCount) break;
            }

            // �I�[�̋󔒂͍폜
            return resultString;

        }
        //----- ADD 2014/03/26 �� �B Redmine#42247 ----------<<<<<
        #endregion �� ���|�[�g�v�f�o�͐ݒ�
        #endregion

        #region �� Control Event

        #region �� PMREC09019P_01A4C_ReportStart Event
        /// <summary>
        /// PMREC09019P_01A4C_ReportStart Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="eArgs">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���|�[�g�J�n���̃C�x���g�ł��B</br>
        /// <br>Programmer	: �� �B</br>
        /// <br>Date		: 2015/02/23</br>
        /// </remarks>
        private void PMREC09019P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
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
        /// <br>Programmer	: �� �B</br>
        /// <br>Date		: 2015/02/23</br>
        /// </remarks>
        private void PageHeader_Format(object sender, System.EventArgs eArgs)
        {
            // �쐬���t
            DateTime now = DateTime.Now;
            // �쐬���t
            this.tb_PrintDate.Text = TDateTime.DateTimeToString("YYYY/MM/DD", now);
            // �쐬����
            this.tb_PrintTime.Text = TDateTime.DateTimeToString("HH:MM", now);
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
        /// <br>Programmer	: �� �B</br>
        /// <br>Date		: 2015/02/23</br>
        /// </remarks>
        private void ExtraHeader_Format(object sender, System.EventArgs eArgs)
        {
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
        /// <br>Programmer	: �� �B</br>
        /// <br>Date		: 2015/02/23</br>
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
        /// <br>Programmer  : �� �B</br>                                   
        /// <br>Date        : 2015/02/23</br>
        /// </remarks>
        private void Detail_BeforePrint(object sender, EventArgs e)
        {
            // Wordrap�v���p�e�B�ŕ��������r���[�ȂƂ���ŋ�؂��Ȃ��悤�ɂ��邽�߂̑Ή�
            PrintCommonLibrary.ConvertReportString(this.Detail);            
        }
        #endregion �� Detail_BeforePrint Event

        #region �� Detail_Format Event
        /// <summary>
        /// Detail_Format �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="eArgs">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : ���׃Z�N�V�����̃t�H�[�}�b�g�C�x���g�ł��B</br>
        /// <br>Programmer  : �� �B</br>                                   
        /// <br>Date        : 2015/02/23</br>
        /// </remarks>
        private void Detail_Format(object sender, System.EventArgs eArgs)
        {
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
            string goodscomment = string.Empty;
            string goodscomment2 = string.Empty;
            int num = sjisEnc.GetByteCount(this.goodscomment.Text);
            if (num > 60)
            {
                goodscomment = this.ByteSubstring(this.goodscomment.Text, 0, 60);
                if (num > 120)
                {
                    goodscomment2 = this.ByteSubstring(this.goodscomment.Text, 60, 60);
                }
                else
                {
                    goodscomment2 = this.ByteSubstring(this.goodscomment.Text, 60, 60);
                }
            }
            else
            {
                goodscomment = this.goodscomment.Text;
            }

            this.goodscomment.Text  = goodscomment;
            this.goodscomment2.Text = goodscomment2;

            /*
            // �A�C�e�������uZ,ZZZ,ZZ9�v�𒴂���ꍇ�A�u*********�v���������
            if (this.tb_ItemCnt.Value.ToString().Length > 9)
            {
                this.tb_ItemCnt.Text = "*********";
            }
            // �I�����z���uZ,ZZZ,ZZZ,ZZ9�v�𒴂���ꍇ�A�u*************�v���������
            if (this.tb_InventoryMony.Value.ToString().Length > 13)
            {
                this.tb_InventoryMony.Text = "*************";
            }
            // �ő�I�����z���uZ,ZZZ,ZZZ,ZZ9�v�𒴂���ꍇ�A�u*************�v���������
            if (this.tb_MaxInventoryMony.Value.ToString().Length > 13)
            {
                this.tb_MaxInventoryMony.Text = "*************";
            }
            // ���z���uZ,ZZZ,ZZZ,ZZ9�v�𒴂���ꍇ�A�u*************�v���������
            if (this.tb_Balance.Value.ToString().Length > 13)
            {
                this.tb_Balance.Text = "*************";
            }
             */ 
        }
        public string ByteSubstring(string value, int startindex, int length)
        {
            string ret = "";          // �؂�o����������
            int start = 0;
            Encoding sjis = Encoding.GetEncoding("Shift-JIS");

            if (startindex < 0) { startindex = 0; }
            if (length < 0) { length = 0; }

            // �J�n�ʒu���擾
            if (startindex == 0)
            {
                // �擪���w�肳�ꂽ
                start = 0;
            }
            else
            {
                // �擪�ȊO���w�肳�ꂽ
                int bytecnt = 0;
                for (int i = 0; i < value.Length; i++)
                {
                    // �擪����̃o�C�g�����擾
                    bytecnt += sjis.GetByteCount(value.Substring(i, 1));
                    if (bytecnt >= startindex)
                    {
                        // �擪����̃o�C�g�����J�n�ʒu�ȏ�ɂȂ镶���̎��̕������J�n�ʒu
                        start = i + 1;
                        break;
                    }
                }
            }

            // �w�肳�ꂽ�J�n�ʒu�������̓r���������ꍇ�A�؏o���T�C�Y���}�C�i�X�P�I
            if (length > 0)
            {
                if (sjis.GetByteCount(value.Substring(0, start)) > startindex)
                {
                    length--;
                }
            }

            // ���肵���J�n�ʒu����1�������擾���A�w��o�C�g���𒴂���܂Ŏ擾
            for (int i = 0; i < value.Length; i++)
            {
                if (i >= start)
                {
                    if ((sjis.GetByteCount(ret + value.Substring(i, 1)) <= length) || (length == 0))
                    {
                        ret += value.Substring(i, 1);
                    }
                }
            }
            return ret;
        }
        #endregion �� Detail_Format Event

        #region �� �t�b�^�[�f�[�^�A����A�`��O(PageFooter_Format)
        /// <summary>
        /// �t�b�^�[�f�[�^�A����A�`��O
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="eArgs">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �Z�N�V�����̃f�[�^�����[�h����A�����ꂽ��A�`��O�ɔ������܂��B</br>
        /// <br>Programmer  : �� �B</br>                                   
        /// <br>Date        : 2014/02/23</br>
        /// </remarks>
        private void pageFooter_Format(object sender, EventArgs e)
        {
            if (this._pageFooters == null)
            {
                return;
            }

            // �t�b�^�[�o��
            if (this._pageFooterOutCode == 0)
            {
                // �t�b�^�[�󎚍��ڐݒ�
                //this.line3.Visible = true;

                if (this._pageFooters[0] != null)
                {
                    this.tb_FooterStr1.Text = this._pageFooters[0];
                }
                if (this._pageFooters[1] != null)
                {
                    this.tb_FooterStr2.Text = this._pageFooters[1];
                }
            }
        }
        #endregion // �t�b�^�[�f�[�^�A����A�`��O(PageFooter_Format)

        #endregion �� Control Event

    }
}
