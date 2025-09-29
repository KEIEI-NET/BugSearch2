//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���q�ʏo�׎��ѕ\
// �v���O�����T�v   : ���q�ʏo�׎��ѕ\���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2009/09/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2009/10/13  �C�����e : �e���� =�i�e�� �� ������z�j*100��ύX����
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

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// PMSYA02003P_01A4C���[�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: ���ɂȂ�</br>
    /// <br>Programmer	: ����</br>
    /// <br>Date		: 2009.09.15</br>
    /// </remarks>
    public partial class PMSYA02003P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeCommon, IPrintActiveReportTypeList
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
        private CarShipRsltListCndtn _extrInfo;

        #endregion

        /// <summary>
        /// ProgressBarUpEvent
        /// </summary>
        public event ProgressBarUpEventHandler ProgressBarUpEvent;

        /// <summary>
        /// PMSYA02003P_01A4C���[�R���X�g���N�^
        /// </summary>
        public PMSYA02003P_01A4C()
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
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.09.15</br>
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
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        private void PMSYA02003P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
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
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        private void PageHeader_Format(object sender, EventArgs eArgs)
        {
            // �쐬���t
            DateTime now = DateTime.Now;
            this.tb_PrintDate.Text = now.ToString("yyyy/MM/dd");
            this.tb_PrintTime.Text = now.ToString("HH:mm");
            if ((int)_extrInfo.DetailDataValue == 0)
            {
                this.SortTitle.Text = "[���גP�ʁF�i��]";
            }
            else if ((int)_extrInfo.DetailDataValue == 1)
            {
                this.SortTitle.Text = "[���גP�ʁFBL����]";
            }
            else if ((int)_extrInfo.DetailDataValue == 2)
            {
                this.SortTitle.Text = "[���גP�ʁF��ٰ�ߺ���]";
            }
        }

        /// <summary>
        /// ���o�f�[�^�t�H�[�}�b�g����
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>
        /// <param name="eArgs">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note		: ���o�f�[�^�t�H�[�}�b�g���������܂��B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
         private void ExtraHeader_Format ( object sender, System.EventArgs eArgs )
        {
            // ���o�����ݒ�
            // �w�b�_�o�͐���
            if ( this._extraCondHeadOutDiv == 0 )
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
            if ( this._rptExtraHeader == null )
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
                _extrInfo = (CarShipRsltListCndtn)this._printInfo.jyoken;
            }
        }

        #endregion

        /// <summary>
        /// ���|�[�g�v�f�o�͐ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���|�[�g�̗v�f�iHeader�AFooter�AText�j�̏o�͐ݒ�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.09.15</br>																
        /// </remarks>																
        private void SetOfReportMembersOutput()
        {
            // ����
            if ((int)this._extrInfo.NewPageDiv == 0)
            {
                MngNoHeader.NewPage = NewPage.None;
            }
            else
            {
                MngNoHeader.NewPage = NewPage.Before;
            }

        }

        /// <summary>
        /// �y�[�W�w�b�_�t�H�[�}�b�g�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �Z�N�V�����̃f�[�^�����[�h����A�����ꂽ��ɔ������܂��B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        private void detail_Format(object sender, EventArgs e)
        {
            // [���גP�ʁF�i��]
            if ((int)_extrInfo.DetailDataValue == 0)
            {
                this.tb_BLGoodsCode.Visible = true;
                this.tb_BLGoodsHalfName.Visible = false;
                this.tb_BLGroupCode.Visible = false;
                this.tb_BLGroupKanaName.Visible = false;
                this.tb_GoodsNo.Visible = true;
                this.tb_GoodsNameKana.Visible = true;
                this.tb_GoodsMakerCd.Visible = true;
                // ��ʂ̖��גP�ʁu�i�ԁv�ݒ莞�́A���i���̃J�i(���i����)���Z�b�g����
                this.tb_GoodsNameKana.DataField = "GoodsNameKanaRF";
            }
            // [���גP�ʁFBL����]
            else if ((int)_extrInfo.DetailDataValue == 1)
            {
                this.tb_BLGoodsCode.Visible = true;
                this.tb_BLGoodsHalfName.Visible = true;
                this.tb_BLGroupCode.Visible = false;
                this.tb_BLGroupKanaName.Visible = false;
                this.tb_GoodsNo.Visible = false;
                this.tb_GoodsNameKana.Visible = false;
                this.tb_GoodsMakerCd.Visible = false;
            }
            // [���גP�ʁF��ٰ�ߺ���]
            else if ((int)_extrInfo.DetailDataValue == 2)
            {
                this.tb_BLGoodsCode.Visible = false;
                this.tb_BLGoodsHalfName.Visible = false;
                this.tb_BLGroupCode.Visible = true;
                this.tb_BLGroupKanaName.Visible = true;
                this.tb_GoodsNo.Visible = false;
                this.tb_GoodsNameKana.Visible = false;
                this.tb_GoodsMakerCd.Visible = false;
            }

            // �i�ԏo�͋敪
            if ((int)this._extrInfo.GoodsNoPrint == 0)
            {
                this.tb_GoodsNo.Visible = false;
            }
            else
            {
                this.tb_GoodsNo.Visible = true;
            }

            // �����E�e���o��
            if ((int)this._extrInfo.CostGrossPrint == 0)
            {
                this.tb_GrossProfit.Visible = false;
                this.tb_GrossPiv.Visible = false;
            }
            else
            {
                this.tb_GrossProfit.Visible = true;
                this.tb_GrossPiv.Visible = true;
            }
        }

        /// <summary>
        /// �y�[�W�w�b�_�t�H�[�}�b�g�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �Z�N�V�����̃f�[�^�����[�h����A�����ꂽ��ɔ������܂��B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        private void TitleHeader_Format(object sender, EventArgs e)
        {
            // [���גP�ʁF�i��]
            if ((int)_extrInfo.DetailDataValue == 0)
            {
                this.lb_GroupCd.Visible = false;
                this.lb_blCd.Visible = true;
                this.lb_goodsNm.Visible = true;
                this.lb_GoodsNo.Visible = true;
                this.lb_maker.Visible = true;
            }
            // [���גP�ʁFBL����]
            else if ((int)_extrInfo.DetailDataValue == 1)
            {
                this.lb_GroupCd.Visible = false;
                this.lb_blCd.Visible = true;
                this.lb_goodsNm.Visible = false;
                this.lb_GoodsNo.Visible = false;
                this.lb_maker.Visible = false;

            }
            // [���גP�ʁF��ٰ�ߺ���]
            else if ((int)_extrInfo.DetailDataValue == 2)
            {
                this.lb_GroupCd.Visible = true;
                this.lb_blCd.Visible = false;
                this.lb_goodsNm.Visible = false;
                this.lb_GoodsNo.Visible = false;
                this.lb_maker.Visible = false;
            }

            // �i�ԏo�͋敪
            if ((int)this._extrInfo.GoodsNoPrint == 0)
            {
                this.lb_GoodsNo.Visible = false;
            }
            else
            {
                this.lb_GoodsNo.Visible = true;
            }

            // �����E�e���o��
            if ((int)this._extrInfo.CostGrossPrint == 0)
            {
                this.lb_GrossProfit.Visible = false;
                this.lb_GrossPiv.Visible = false;
            }
            else
            {
                this.lb_GrossProfit.Visible = true;
                this.lb_GrossPiv.Visible = true;
            }

        }

        /// <summary>
        /// �y�[�W�w�b�_�t�H�[�}�b�g�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �Z�N�V�����̃f�[�^�����[�h����A�����ꂽ��ɔ������܂��B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        private void BLGroupCodeHeader_Format(object sender, EventArgs e)
        {
            // [���גP�ʁF��ٰ�ߺ���]
            if ((int)_extrInfo.DetailDataValue == 2)
            {
                this.BLGroupCodeHeader.Visible = false;
            }
            else
            {
                this.BLGroupCodeHeader.Visible = true;
            }
        }

        /// <summary>
        /// �y�[�W�w�b�_�t�H�[�}�b�g�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �Z�N�V�����̃f�[�^�����[�h����A�����ꂽ��ɔ������܂��B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        private void BLGoodsCdFooter_Format(object sender, EventArgs e)
        {
            // [���גP�ʁF�i��]
            if ((int)_extrInfo.DetailDataValue == 0)
            {
                this.BLGoodsCdFooter.Visible = true;
            }
            // [���גP�ʁFBL����][���גP�ʁF��ٰ�ߺ���]
            else 
            {
                this.BLGoodsCdFooter.Visible = false;
            }

            //�e����
            // �[������
            double grosspiv_blcode = 0;
            if ((Convert.ToDouble(tb_SalesMoneyTaxExc_blcode.Text)) != 0)
            {
                // --- UPD 2009/10/13 ------>>>>>
                // �e�����@�i�e�� �� ������z�j*100�@
                //  grosspiv_blcode = (Convert.ToDouble(tb_GrossProfit_blcode.Text)) / (Convert.ToDouble(tb_SalesMoneyTaxExc_blcode.Text));
                grosspiv_blcode = ((Convert.ToDouble(tb_GrossProfit_blcode.Text)) / (Convert.ToDouble(tb_SalesMoneyTaxExc_blcode.Text))) * 100;
                // --- UPD 2009/10/13 ------<<<<<
            }
            tb_GrossPiv_blcode.Text = grosspiv_blcode.ToString("f2");

            // �����E�e���o��
            if ((int)this._extrInfo.CostGrossPrint == 0)
            {
                this.tb_GrossProfit_blcode.Visible = false;
                this.tb_GrossPiv_blcode.Visible = false;
            }
            else
            {
                this.tb_GrossProfit_blcode.Visible = true;
                this.tb_GrossPiv_blcode.Visible = true;
            }
        }

        /// <summary>
        /// �y�[�W�w�b�_�t�H�[�}�b�g�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �Z�N�V�����̃f�[�^�����[�h����A�����ꂽ��ɔ������܂��B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        private void BLGroupCodeFooter_Format(object sender, EventArgs e)
        {
            // [���גP�ʁF��ٰ�ߺ���]
            if ((int)_extrInfo.DetailDataValue == 2)
            {
                this.BLGroupCodeFooter.Visible = false;
                this.line_blgroup.Visible = false;
            }
            // [���גP�ʁFBL����]
            else if ((int)_extrInfo.DetailDataValue == 1)
            {
                this.BLGroupCodeFooter.Visible = true;
                this.line_blgroup.Visible = true;
            }
            // [���גP�ʁF�i��]
            else if ((int)_extrInfo.DetailDataValue == 0)
            {
                this.BLGroupCodeFooter.Visible = true;
                this.line_blgroup.Visible = false;
            }

            //�e����
            // �[������
            double grosspiv_groupcd = 0;
            if ((Convert.ToDouble(tb_SalesMoneyTaxExc_groupcd.Text)) != 0)
            {
                // --- UPD 2009/10/13 ------>>>>>
                // �e�����@�i�e�� �� ������z�j*100�@
                //  grosspiv_groupcd = (Convert.ToDouble(tb_GrossProfit_groupcd.Text)) / (Convert.ToDouble(tb_SalesMoneyTaxExc_groupcd.Text));
                grosspiv_groupcd = ((Convert.ToDouble(tb_GrossProfit_groupcd.Text)) / (Convert.ToDouble(tb_SalesMoneyTaxExc_groupcd.Text))) * 100;
                // --- UPD 2009/10/13 ------<<<<<
            }
            tb_GrossPiv_groupcd.Text = grosspiv_groupcd.ToString("f2");

            // �����E�e���o��
            if ((int)this._extrInfo.CostGrossPrint == 0)
            {
                this.tb_GrossProfit_groupcd.Visible = false;
                this.tb_GrossPiv_groupcd.Visible = false;
            }
            else
            {
                this.tb_GrossProfit_groupcd.Visible = true;
                this.tb_GrossPiv_groupcd.Visible = true;
            }
        }

        /// <summary>
        /// �y�[�W�w�b�_�t�H�[�}�b�g�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �Z�N�V�����̃f�[�^�����[�h����A�����ꂽ��ɔ������܂��B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        private void MngNoFooter_Format(object sender, EventArgs e)
        {
            // [���גP�ʁF��ٰ�ߺ���]
            if ((int)_extrInfo.DetailDataValue == 2)
            {
                this.line_car.Visible = true;
            }
            // [���גP�ʁFBL����]
            else if ((int)_extrInfo.DetailDataValue == 1)
            {
                this.line_car.Visible = false;
            }
            // [���גP�ʁF�i��]
            else if ((int)_extrInfo.DetailDataValue == 0)
            {
                this.line_car.Visible = false;
            }
            //�e����
            // �[������
            double grosspiv_car = 0;
            if ((Convert.ToDouble(tb_SalesMoneyTaxExc_car.Text)) != 0)
            {
                // --- UPD 2009/10/13 ------>>>>>
                // �e�����@�i�e�� �� ������z�j*100�@
                //  grosspiv_car = (Convert.ToDouble(tb_GrossProfit_car.Text)) / (Convert.ToDouble(tb_SalesMoneyTaxExc_car.Text));
                grosspiv_car = ((Convert.ToDouble(tb_GrossProfit_car.Text)) / (Convert.ToDouble(tb_SalesMoneyTaxExc_car.Text))) * 100;
                // --- UPD 2009/10/13 ------<<<<<
            }
            tb_GrossPiv_car.Text = grosspiv_car.ToString("f2");

            // �����E�e���o��
            if ((int)this._extrInfo.CostGrossPrint == 0)
            {
                this.tb_GrossProfit_car.Visible = false;
                this.tb_GrossPiv_car.Visible = false;
            }
            else
            {
                this.tb_GrossProfit_car.Visible = true;
                this.tb_GrossPiv_car.Visible = true;
            }
        }

        /// <summary>
        /// �y�[�W�w�b�_�t�H�[�}�b�g�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �Z�N�V�����̃f�[�^�����[�h����A�����ꂽ��ɔ������܂��B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        private void CustomerFooter_Format(object sender, EventArgs e)
        {
            //�e����
            // �[������
            double grosspiv_customer = 0;
            if ((Convert.ToDouble(tb_SalesMoneyTaxExc_customer.Text)) != 0)
            {
                // --- UPD 2009/10/13 ------>>>>>
                // �e�����@�i�e�� �� ������z�j*100�@
                //  grosspiv_customer = (Convert.ToDouble(tb_GrossProfit_customer.Text)) / (Convert.ToDouble(tb_SalesMoneyTaxExc_customer.Text));
                grosspiv_customer = ((Convert.ToDouble(tb_GrossProfit_customer.Text)) / (Convert.ToDouble(tb_SalesMoneyTaxExc_customer.Text))) * 100;
                // --- UPD 2009/10/13 ------<<<<<
            }
            tb_GrossPiv_customer.Text = grosspiv_customer.ToString("f2");

            // �����E�e���o��
            if ((int)this._extrInfo.CostGrossPrint == 0)
            {
                this.tb_GrossProfit_customer.Visible = false;
                this.tb_GrossPiv_customer.Visible = false;
            }
            else
            {
                this.tb_GrossProfit_customer.Visible = true;
                this.tb_GrossPiv_customer.Visible = true;
            }
        }

        /// <summary>
        /// �y�[�W�w�b�_�t�H�[�}�b�g�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �Z�N�V�����̃f�[�^�����[�h����A�����ꂽ��ɔ������܂��B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        private void SectionFooter_Format(object sender, EventArgs e)
        {
            //�e����
            // �[������
            double grosspiv_sec = 0;
            if ((Convert.ToDouble(tb_SalesMoneyTaxExc_sec.Text)) != 0)
            {
                // --- UPD 2009/10/13 ------>>>>>
                // �e�����@�i�e�� �� ������z�j*100�@
                //  grosspiv_sec = (Convert.ToDouble(tb_GrossProfit_sec.Text)) / (Convert.ToDouble(tb_SalesMoneyTaxExc_sec.Text));
                grosspiv_sec = ((Convert.ToDouble(tb_GrossProfit_sec.Text)) / (Convert.ToDouble(tb_SalesMoneyTaxExc_sec.Text))) * 100;
                // --- UPD 2009/10/13 ------<<<<<
            }
            tb_GrossPiv_sec.Text = grosspiv_sec.ToString("f2");

            // �����E�e���o��
            if ((int)this._extrInfo.CostGrossPrint == 0)
            {
                this.tb_GrossProfit_sec.Visible = false;
                this.tb_GrossPiv_sec.Visible = false;
            }
            else
            {
                this.tb_GrossProfit_sec.Visible = true;
                this.tb_GrossPiv_sec.Visible = true;
            }
        }

        /// <summary>
        /// �y�[�W�w�b�_�t�H�[�}�b�g�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �Z�N�V�����̃f�[�^�����[�h����A�����ꂽ��ɔ������܂��B</br>
        /// <br>Programmer	: ����</br>
        /// <br>Date		: 2009.09.15</br>
        /// </remarks>
        private void TotalFooter_Format(object sender, EventArgs e)
        {
            //�e����
            // �[������
            double grosspiv_all = 0;
            if ((Convert.ToDouble(tb_SalesMoneyTaxExc_all.Text)) != 0)
            {
                // --- UPD 2009/10/13 ------>>>>>
                // �e�����@�i�e�� �� ������z�j*100�@
                //  grosspiv_all = (Convert.ToDouble(tb_GrossProfit_all.Text)) / (Convert.ToDouble(tb_SalesMoneyTaxExc_all.Text));
                grosspiv_all = ((Convert.ToDouble(tb_GrossProfit_all.Text)) / (Convert.ToDouble(tb_SalesMoneyTaxExc_all.Text))) * 100;
                // --- UPD 2009/10/13 ------<<<<<
            }
            tb_GrossPiv_all.Text = grosspiv_all.ToString("f2");

            // �����E�e���o��
            if ((int)this._extrInfo.CostGrossPrint == 0)
            {
                this.tb_GrossProfit_all.Visible = false;
                this.tb_GrossPiv_all.Visible = false;
            }
            else
            {
                this.tb_GrossProfit_all.Visible = true;
                this.tb_GrossPiv_all.Visible = true;
            }
        }
    }
}
