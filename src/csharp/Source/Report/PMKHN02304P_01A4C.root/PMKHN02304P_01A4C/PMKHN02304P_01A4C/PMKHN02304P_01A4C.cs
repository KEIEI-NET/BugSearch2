//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �������i���i����
// �v���O�����T�v   : �������i���i�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���痈
// �� �� ��  2009/04/27  �C�����e : �V�K�쐬
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

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// PMKHN02304P_01A4C �̊T�v�̐����ł��B
    /// </summary>
    public partial class PMKHN02304P_01A4C : ActiveReport3, IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        #region �� Private Member

        private int _printCount;								// ��������p�J�E���^
        private int _extraCondHeadOutDiv;			            // ���o�����w�b�_�o�͋敪
        private StringCollection _extraConditions;				// ���o����
        private int _pageFooterOutCode;				            // �t�b�^�[�o�͋敪
        private StringCollection _pageFooters;					// �t�b�^�[���b�Z�[�W
        private SFCMN06002C _printInfo;						    // ������N���X
        private ArrayList _otherDataList;
        private string _pageHeaderSubtitle;
        private string _pageHeaderSortOderTitle;		        // �\�[�g��
        //private int _prevMakerCode;
        //private string _prevAfWarehouseCode;
        private GoodsInfoCndtn _goodsInfoCndtn;     // ���o�����N���X
        ListCommon_ExtraHeader _rptExtraHeader = null;          // �w�b�_�[�T�u���|�[�g�錾
        //ListCommon_PageFooter _rptPageFooter = null;            // �t�b�^�[���|�[�g�錾

        #endregion �� Private Member


        #region �� Constructor
        /// <summary>
        /// �������i���i��������N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �������i���i��������N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009/04/28</br>
        /// </remarks>
        public PMKHN02304P_01A4C()
        {
            InitializeComponent();
        }

        #endregion �� Constructor


        # region �� IPrintActiveReportTypeList �C���^�[�t�F�[�X
        /// <summary>
        /// �y�[�W�w�b�_�\�[�g���^�C�g������
        /// </summary>
        public string PageHeaderSortOderTitle
        {
            set { _pageHeaderSortOderTitle = value; }
        }

        /// <summary>
        /// ���o�����w�b�_�o�͋敪[0:���y�[�W,1:�擪�y�[�W�̂�]
        /// </summary>
        public int ExtraCondHeadOutDiv
        {
            set { _extraCondHeadOutDiv = value; }
        }

        /// <summary>
        /// ���o�����w�b�_�[����
        /// </summary>
        public StringCollection ExtraConditions
        {
            set { this._extraConditions = value; }
        }

        /// <summary>
        /// �t�b�^�[�o�͋敪
        /// </summary>
        public int PageFooterOutCode
        {
            set { this._pageFooterOutCode = value; }
        }

        /// <summary>
        /// �t�b�^�o�͕�
        /// </summary>
        public StringCollection PageFooters
        {
            set { this._pageFooters = value; }
        }

        /// <summary>
        /// �������
        /// </summary>
        public SFCMN06002C PrintInfo
        {
            set
            {
                this._printInfo = value;
                this._goodsInfoCndtn = (GoodsInfoCndtn)this._printInfo.jyoken;
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
            }
        }

        /// <summary>
        /// ���[�T�u�^�C�g��
        /// </summary>
        public string PageHeaderSubtitle
        {
            set { this._pageHeaderSubtitle = value; }
        }

        /// <summary>
        /// ��������J�E���g�A�b�v�C�x���g
        /// </summary>
        public event ProgressBarUpEventHandler ProgressBarUpEvent;
        # endregion �� IPrintActiveReportTypeList �C���^�[�t�F�[�X


        # region �� IPrintActiveReportTypeCommon �C���^�[�t�F�[�X
        /// <summary>
        /// �w�i���ߐݒ�l�v���p�e�B
        /// </summary>
        public int WatermarkMode
        {
            get { return 0; }
            set { }
        }
        # endregion �� IPrintActiveReportTypeCommon �C���^�[�t�F�[�X


        #region �� Private Method
        /// <summary>
        /// ���|�[�g�v�f�o�͐ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���|�[�g�̗v�f�iHeader�AFooter�AText�j�̏o�͐ݒ�</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009/04/28</br>
        /// </remarks>
        private void SetOfReportMembersOutput()
        {
            this._printCount = 0;

            //// ����
            //if (this._goodsInfoCndtn.NewPage == 0)
            //{
            //    this.MakerHeader.NewPage = NewPage.None;
            //    this.MakerHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
            //}
            //else
            //{
            //    this.MakerHeader.NewPage = NewPage.Before;
            //    this.MakerHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
            //}

            //// ��[�����i������
            //if (this._goodsInfoCndtn.ReplenishNoneGoods == 0)
            //{
            //    this.SupplierCd.Visible = false;
            //}
            //else
            //{
            //    this.SupplierCd.Visible = true;
            //}
        }
        #endregion �� Private Method


        #region �� Control Events
        /// <summary>
        /// ReportStart �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: ���|�[�g�̊J�n���ɔ������܂��B</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009/04/28</br>
        /// </remarks>
        private void MAZAI02062P_01A4C_ReportStart(object sender, EventArgs e)
        {
            SetOfReportMembersOutput();
        }

        /// <summary>
        /// Format �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: PageHeader�Z�N�V�����Ǎ����ɔ������܂��B</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009/04/28</br>
        /// </remarks>
        private void PageHeader_Format(object sender, EventArgs e)
        {
            // �쐬���t
            this.PrintDate.Text = TDateTime.DateTimeToString("YYYY/MM/DD", DateTime.Now);
            // �쐬����
            this.PrintTime.Text = DateTime.Now.ToString("HH:mm");
        }

        /// <summary>
        /// Format �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: ExtraHeader�Z�N�V�����Ǎ����ɔ������܂��B</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009/04/28</br>
        /// </remarks>
        private void ExtraHeader_Format(object sender, EventArgs e)
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


        /// <summary>
        /// Format �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: PageFooter�Z�N�V�����Ǎ����ɔ������܂��B</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009/04/28</br>
        /// </remarks>
        private void PageFooter_Format(object sender, EventArgs e)
        {
            //// �t�b�^�[�o�͂���H
            //if (this._pageFooterOutCode == 0)
            //{
            //    this.line6.Visible = true;
            //    this.Footer1_TextBox.Visible = true;
            //    this.Footer2_TextBox.Visible = true;

            //    // �t�b�^�[���|�[�g�쐬
            //    if (this._rptPageFooter == null)
            //    {
            //        this._rptPageFooter = new ListCommon_PageFooter();
            //    }

            //    // �t�b�^�[�󎚍��ڐݒ�
            //    if (this._pageFooters[0] != null)
            //    {
            //        this._rptPageFooter.PrintFooter1 = this._pageFooters[0];
            //    }
            //    if (this._pageFooters[1] != null)
            //    {
            //        this._rptPageFooter.PrintFooter2 = this._pageFooters[1];
            //    }

            //    // �T�u���|�[�g���g���ƁA�����I�Ɍr����10.8�ɂȂ�̂Ŏg�p���Ȃ�
            //    this.Footer1_TextBox.Text = this._pageFooters[0];
            //    this.Footer2_TextBox.Text = this._pageFooters[1];
            //}
            //else
            //{
            //    this.line6.Visible = false;
            //    this.Footer1_TextBox.Visible = false;
            //    this.Footer2_TextBox.Visible = false;
            //}
        }

        /// <summary>
        /// AfterPrint �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: Detail�Z�N�V�����Ǎ���ɔ������܂��B</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009/04/28</br>
        /// </remarks>
        private void Detail_AfterPrint(object sender, EventArgs e)
        {
            // ��������J�E���g�A�b�v
            this._printCount++;

            if (this.ProgressBarUpEvent != null)
            {
                this.ProgressBarUpEvent(this, this._printCount);
            }
        }

        /// <summary>
        /// Detail_BeforePrint Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="eArgs">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �Z�N�V�������y�[�W�ɕ`�悳���O�ɔ�������B</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009/04/28</br>
        /// </remarks>
        private void Detail_BeforePrint(object sender, EventArgs e)
        {
            // Wordrap�v���p�e�B�ŕ��������r���[�ȂƂ���ŋ�؂��Ȃ��悤�ɂ��邽�߂̑Ή�
            PrintCommonLibrary.ConvertReportString(this.Detail);
        }

        /// <summary>
        /// Detail_Format Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="eArgs">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �Z�N�V�������y�[�W�ɕ`�悳���O�ɔ�������B</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009/04/28</br>
        /// </remarks>
        private void Detail_Format(object sender, EventArgs e)
        {
            ////�d����
            //string suppliercd = this.SupplierCd.Text;
            //try
            //{
            //    int newSuppliercd = Convert.ToInt32(suppliercd);
            //    if (newSuppliercd >= 0)
            //    {
            //        this.SupplierCd.Text = newSuppliercd.ToString("d06");
            //    }
            //    else
            //    {
            //        this.SupplierCd.Text = "-" + Math.Abs(newSuppliercd).ToString("d05");
            //    }
            //}
            //catch
            //{

            //}

            ////Ұ��
            //string goodsMakerCd = this.GoodsMakerCd.Text;
            //try
            //{
            //    int newGoodsMakerCd = Convert.ToInt32(goodsMakerCd);
            //    if (newGoodsMakerCd >= 0)
            //    {
            //        this.GoodsMakerCd.Text = newGoodsMakerCd.ToString("d04");
            //    }
            //    else
            //    {
            //        this.GoodsMakerCd.Text = "-" + Math.Abs(newGoodsMakerCd).ToString("d03");
            //    }
            //}
            //catch
            //{

            //}


            ////BL����
            //string bLGoodsCode = this.BLGoodsCode.Text;
            //try
            //{
            //    int newBLGoodsCode = Convert.ToInt32(bLGoodsCode);
            //    if (newBLGoodsCode >= 0)
            //    {
            //        this.BLGoodsCode.Text = newBLGoodsCode.ToString("d05");
            //    }
            //    else
            //    {
            //        this.BLGoodsCode.Text = "-" + Math.Abs(newBLGoodsCode).ToString("d04");
            //    }
            //}
            //catch
            //{

            //}


            ////�艿
            //string price = this.Price.Text;
            //try
            //{
            //    double newPrice = Math.Truncate(Convert.ToDouble(price));

            //    this.Price.Text = NumberFormat(newPrice);

            //}
            //catch
            //{

            //}


            ////�d����
            //string saleRate = this.SaleRate.Text;
            //try
            //{
            //    double newSaleRate = Convert.ToDouble(saleRate);

            //    this.SaleRate.Text = newSaleRate.ToString("0.00");

            //}
            //catch
            //{

            //}


            ////����
            //string salesUnitCost = this.SalesUnitCost.Text;
            //try
            //{
            //    double newSalesUnitCost = Math.Truncate(Convert.ToDouble(salesUnitCost));

            //    this.SalesUnitCost.Text = NumberFormat(newSalesUnitCost);

            //}
            //catch
            //{

            //}
        }


        /// <summary>
        /// �����̃t�H�[�}�b�g
        /// </summary>
        /// <param name="number">����</param>
        /// <remarks>
        /// <br>Note		: �����̃t�H�[�}�b�g(999,999,999)��ϊ�����</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.05.12</br>
        /// </remarks>
        private string NumberFormat(double number)
        {
            string ret;
            if (Math.Abs(number) > 999)
            {
                ret = string.Format("{0:0,0}", number);
            }
            else
            {
                ret = number.ToString();
            }
            return ret;
        }

        #endregion �� Control Events

    }
}
