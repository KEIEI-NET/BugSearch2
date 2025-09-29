//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d��������ѕ\
// �v���O�����T�v   : �d��������ѕ\���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���痈
// �� �� ��  2009/05/10  �C�����e : �V�K�쐬
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
    /// �d��������ѕ\�f�U�C���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d��������ѕ\�f�U�C���N���X�̊T�v�̐������s���܂��B</br>
    /// <br>Programmer : ���痈</br>
    /// <br>Date       : 2009.05.13</br>
    /// </remarks>
    public partial class PMKOU02063P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeCommon, IPrintActiveReportTypeList
    {

        //================================================================================
        //  Constructor
        //================================================================================
        #region �R���X�g���N�^�[
        /// <summary>
        /// �d��������ѕ\������[ActiveReport�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d��������ѕ\������[ActiveReport�N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public PMKOU02063P_01A4C()
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
        private StockSalesResultInfoMainCndtn _extrInfo;

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
                this._extrInfo = (StockSalesResultInfoMainCndtn)this._printInfo.jyoken;
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
        /// <br>Date		: 2009.05.13</br>
        /// </remarks>
        private void PMKOU02063P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
        {
            SetOfReportMembersOutput();
        }

        /// <summary>
        /// ���|�[�g�v�f�o�͐ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���|�[�g�̗v�f�iHeader�AFooter�AText�j�̏o�͐ݒ�</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.05.13</br>
        /// </remarks>
        private void SetOfReportMembersOutput()
        {
            // �������������
            this._printCount = 0;

            //����
            if (this._extrInfo.NewPageType == 0)
            {
                this.SectionHeader.DataField = "SectionCode";
                this.SectionHeader.NewPage = NewPage.Before;
                this.SectionHeader.RepeatStyle = RepeatStyle.OnPage;

                this.groupHeader3.DataField = "";
                this.groupHeader3.NewPage = NewPage.None;
                this.groupHeader3.RepeatStyle = RepeatStyle.None;
            }
            else if (this._extrInfo.NewPageType == 1)
            {
                this.SectionHeader.DataField = "SectionCode";
                this.SectionHeader.NewPage = NewPage.None;
                this.SectionHeader.RepeatStyle = RepeatStyle.OnPage;

                this.groupHeader3.DataField = "";
                this.groupHeader3.NewPage = NewPage.None;
                this.groupHeader3.RepeatStyle = RepeatStyle.None;
            }

        }

        /// <summary>
        /// �y�[�W�w�b�_�t�H�[�}�b�g�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="eArgs">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �Z�N�V�����̃f�[�^�����[�h����A�����ꂽ��ɔ������܂��B</br>
        /// <br>Programmer	: ���痈</br>
        /// <br>Date		: 2009.05.13</br>
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
        /// <br>Date		: 2009.05.13</br>
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
        /// <br>Date        : 2009.05.13</br>
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
        /// <br>Date       : 2008.12.10</br>
        /// </remarks>
        private void Detail_Format(object sender, EventArgs e)
        {
            //if (lineFlag.Text.Equals("true") || lineFlag.Text.Equals("True"))
            //{
            //    this.line5.Visible = true;
            //}
            //else
            //{
            //    this.line5.Visible = false;
            //}
        }
        #endregion

        private void DailyFooter_Format(object sender, EventArgs e)
        {
            long saleData = Convert.ToInt64(this.textBox13.Text);
            if (saleData == 0)
            {
                this.textBox13.Visible = false;
                this.textBox16.Visible = false;
                this.textBox8.Visible = false;
            }
            else
            {
                this.textBox13.Visible = true;
                this.textBox16.Visible = true;
                this.textBox8.Visible = true;
            }
            long stockData = Convert.ToInt64(this.textBox14.Text);
            long grpMoney = saleData - stockData;
            decimal tmpPct = new decimal(0.00);
            if (saleData != 0)
            {
                tmpPct = decimal.Round(((Convert.ToDecimal(grpMoney) / Convert.ToDecimal(saleData)) * 100), 2, MidpointRounding.AwayFromZero);
            }
            this.textBox13.Text = NumberFormat(saleData);
            this.textBox14.Text = NumberFormat(stockData);
            this.textBox16.Text = NumberFormat(grpMoney);
            this.textBox8.Text = Convert.ToString(tmpPct);
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
        private string NumberFormat(long number)
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

        #endregion

        /// <summary>
        /// ���_�v�����@SectionFooter_Format�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���_�v�������s���B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.06.04</br>
        /// </remarks>
        private void SectionFooter_Format(object sender, EventArgs e)
        {
            //�d��
            long saleSalesData = Convert.ToInt64(this.textBox15.Text);
            ////if (saleSalesData == 0)
            if (1 == _extrInfo.SalesType)
            {
                this.textBox15.Visible = false;
                this.textBox17.Visible = false;
                this.textBox18.Visible = false;
            }
            else
            {
                this.textBox15.Visible = true;
                this.textBox17.Visible = true;
                this.textBox18.Visible = true;
            }
            long stockSalesData = Convert.ToInt64(this.textBox28.Text);
            long grpSalesMoney = saleSalesData - stockSalesData;
            decimal tmpSalesPct = new decimal(0.00);
            if (saleSalesData != 0)
            {
                tmpSalesPct = decimal.Round(((Convert.ToDecimal(grpSalesMoney) / Convert.ToDecimal(saleSalesData)) * 100), 2, MidpointRounding.AwayFromZero);
            }
            this.textBox15.Text = NumberFormat(saleSalesData);
            this.textBox28.Text = NumberFormat(stockSalesData);
            this.textBox17.Text = NumberFormat(grpSalesMoney);
            if (saleSalesData == 0)
            {
                this.textBox18.Text = Convert.ToString("0.00");
            }
            else
            {
                this.textBox18.Text = Convert.ToString(tmpSalesPct);
            }

            //�ԕi
            long saleRetGdsData = Convert.ToInt64(this.textBox19.Text);
            //if (saleRetGdsData == 0)
            if (1 == _extrInfo.SalesType)
            {
                this.textBox19.Visible = false;
                this.textBox22.Visible = false;
                this.textBox25.Visible = false;
            }
            else
            {
                this.textBox19.Visible = true;
                this.textBox22.Visible = true;
                this.textBox25.Visible = true;
            }
            long stockRetGdsData = Convert.ToInt64(this.textBox29.Text);
            long grpRetGdsMoney = saleRetGdsData - stockRetGdsData;
            decimal tmpRetGdsPct = new decimal(0.00);
            if (saleRetGdsData != 0)
            {
                tmpRetGdsPct = decimal.Round(((Convert.ToDecimal(grpRetGdsMoney) / Convert.ToDecimal(saleRetGdsData)) * 100), 2, MidpointRounding.AwayFromZero);
            }
            this.textBox19.Text = NumberFormat(saleRetGdsData);
            this.textBox29.Text = NumberFormat(stockRetGdsData);
            this.textBox22.Text = NumberFormat(grpRetGdsMoney);
            if (saleRetGdsData == 0)
            {
                this.textBox25.Text = Convert.ToString("0.00");
            }
            else
            {
                this.textBox25.Text = Convert.ToString(tmpRetGdsPct);
            }

            //�l��
            long saleDistData = Convert.ToInt64(this.textBox20.Text);
            //if (saleDistData == 0)
            if (1 == _extrInfo.SalesType)
            {
                this.textBox20.Visible = false;
                this.textBox23.Visible = false;
                this.textBox26.Visible = false;
            }
            else
            {
                this.textBox20.Visible = true;
                this.textBox23.Visible = true;
                this.textBox26.Visible = true;
            }
            long stockDistData = Convert.ToInt64(this.textBox30.Text);
            long grpDistMoney = saleDistData - stockDistData;
            decimal tmpDistPct = new decimal(0.00);
            if (saleDistData != 0)
            {
                tmpDistPct = decimal.Round(((Convert.ToDecimal(grpDistMoney) / Convert.ToDecimal(saleDistData)) * 100), 2, MidpointRounding.AwayFromZero);
            }
            this.textBox20.Text = NumberFormat(saleDistData);
            this.textBox30.Text = NumberFormat(stockDistData);
            this.textBox23.Text = NumberFormat(grpDistMoney);
            if (saleDistData == 0)
            {
                this.textBox26.Text = Convert.ToString("0.00");
            }
            else
            {
                this.textBox26.Text = Convert.ToString(tmpDistPct);
            }

            //���v
            long saleTotalData = Convert.ToInt64(this.textBox21.Text);
            //if (saleTotalData == 0)
            if (1 == _extrInfo.SalesType)
            {
                this.textBox21.Visible = false;
                this.textBox24.Visible = false;
                this.textBox27.Visible = false;
            }
            else
            {
                this.textBox21.Visible = true;
                this.textBox24.Visible = true;
                this.textBox27.Visible = true;
            }
            long stockTotalData = Convert.ToInt64(this.textBox31.Text);
            long grpTotalMoney = saleTotalData - stockTotalData;
            decimal tmpTotalPct = new decimal(0.00);
            if (saleTotalData != 0)
            {
                tmpTotalPct = decimal.Round(((Convert.ToDecimal(grpTotalMoney) / Convert.ToDecimal(saleTotalData)) * 100), 2, MidpointRounding.AwayFromZero);
            }
            this.textBox21.Text = NumberFormat(saleTotalData);
            this.textBox31.Text = NumberFormat(stockTotalData);
            this.textBox24.Text = NumberFormat(grpTotalMoney);
            if (saleTotalData == 0)
            {
                this.textBox27.Text = Convert.ToString("0.00");
            }
            else
            {
                this.textBox27.Text = Convert.ToString(tmpTotalPct);
            }
        }


        /// <summary>
        /// �����v�����@GrandTotalFooter_Format�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �����v�������s���B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.06.04</br>
        /// </remarks>
        private void GrandTotalFooter_Format(object sender, EventArgs e)
        {
            //�d��
            long saleSalesData = Convert.ToInt64(this.textBox37.Text);
            //if (saleSalesData == 0)
            if (1 == _extrInfo.SalesType)
            {
                this.textBox37.Visible = false;
                this.textBox45.Visible = false;
                this.textBox46.Visible = false;
            }
            else
            {
                this.textBox37.Visible = true;
                this.textBox45.Visible = true;
                this.textBox46.Visible = true;
            }
            long stockSalesData = Convert.ToInt64(this.textBox53.Text);
            long grpSalesMoney = saleSalesData - stockSalesData;
            decimal tmpSalesPct = new decimal(0.00);
            if (saleSalesData != 0)
            {
                tmpSalesPct = decimal.Round(((Convert.ToDecimal(grpSalesMoney) / Convert.ToDecimal(saleSalesData)) * 100), 2, MidpointRounding.AwayFromZero);
            }
            this.textBox37.Text = NumberFormat(saleSalesData);
            this.textBox53.Text = NumberFormat(stockSalesData);
            this.textBox45.Text = NumberFormat(grpSalesMoney);
            if (saleSalesData == 0)
            {
                this.textBox46.Text = Convert.ToString("0.00");
            }
            else
            {
                this.textBox46.Text = Convert.ToString(tmpSalesPct);
            }

            //�ԕi
            long saleRetGdsData = Convert.ToInt64(this.textBox38.Text);
            //if (saleRetGdsData == 0)
            if (1 == _extrInfo.SalesType)
            {
                this.textBox38.Visible = false;
                this.textBox44.Visible = false;
                this.textBox47.Visible = false;
            }
            else
            {
                this.textBox38.Visible = true;
                this.textBox44.Visible = true;
                this.textBox47.Visible = true;
            }
            long stockRetGdsData = Convert.ToInt64(this.textBox52.Text);
            long grpRetGdsMoney = saleRetGdsData - stockRetGdsData;
            decimal tmpRetGdsPct = new decimal(0.00);
            if (saleRetGdsData != 0)
            {
                tmpRetGdsPct = decimal.Round(((Convert.ToDecimal(grpRetGdsMoney) / Convert.ToDecimal(saleRetGdsData)) * 100), 2, MidpointRounding.AwayFromZero);
            }
            this.textBox38.Text = NumberFormat(saleRetGdsData);
            this.textBox52.Text = NumberFormat(stockRetGdsData);
            this.textBox44.Text = NumberFormat(grpRetGdsMoney);
            if (saleRetGdsData == 0)
            {
                this.textBox47.Text = Convert.ToString("0.00");
            }
            else
            {
                this.textBox47.Text = Convert.ToString(tmpRetGdsPct);
            }

            //�l��
            long saleDistData = Convert.ToInt64(this.textBox39.Text);
            //if (saleDistData == 0)
            if (1 == _extrInfo.SalesType)
            {
                this.textBox39.Visible = false;
                this.textBox43.Visible = false;
                this.textBox48.Visible = false;
            }
            else
            {
                this.textBox39.Visible = true;
                this.textBox43.Visible = true;
                this.textBox48.Visible = true;
            }
            long stockDistData = Convert.ToInt64(this.textBox51.Text);
            long grpDistMoney = saleDistData - stockDistData;
            decimal tmpDistPct = new decimal(0.00);
            if (saleDistData != 0)
            {
                tmpDistPct = decimal.Round(((Convert.ToDecimal(grpDistMoney) / Convert.ToDecimal(saleDistData)) * 100), 2, MidpointRounding.AwayFromZero);
            }
            this.textBox39.Text = NumberFormat(saleDistData);
            this.textBox51.Text = NumberFormat(stockDistData);
            this.textBox43.Text = NumberFormat(grpDistMoney);
            if (saleDistData == 0)
            {
                this.textBox48.Text = Convert.ToString("0.00");
            }
            else
            {
                this.textBox48.Text = Convert.ToString(tmpDistPct);
            }

            //���v
            long saleTotalData = Convert.ToInt64(this.textBox41.Text);
            //if (saleTotalData == 0)
            if (1 == _extrInfo.SalesType)
            {
                this.textBox41.Visible = false;
                this.textBox42.Visible = false;
                this.textBox49.Visible = false;
            }
            else
            {
                this.textBox41.Visible = true;
                this.textBox42.Visible = true;
                this.textBox49.Visible = true;
            }
            long stockTotalData = Convert.ToInt64(this.textBox50.Text);
            long grpTotalMoney = saleTotalData - stockTotalData;
            decimal tmpTotalPct = new decimal(0.00);
            if (saleTotalData != 0)
            {
                tmpTotalPct = decimal.Round(((Convert.ToDecimal(grpTotalMoney) / Convert.ToDecimal(saleTotalData)) * 100), 2, MidpointRounding.AwayFromZero);
            }
            this.textBox41.Text = NumberFormat(saleTotalData);
            this.textBox50.Text = NumberFormat(stockTotalData);
            this.textBox42.Text = NumberFormat(grpTotalMoney);
            if (saleTotalData == 0)
            {
                this.textBox49.Text = Convert.ToString("0.00");
            }
            else
            {
                this.textBox49.Text = Convert.ToString(tmpTotalPct);
            }
        }

        /// <summary>
        /// Detail_BeforePrint�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : Detail_BeforePrint���s���B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.06.04</br>
        /// </remarks>
        private void Detail_BeforePrint(object sender, EventArgs e)
        {
            // Wordrap�v���p�e�B�ŕ��������r���[�ȂƂ���ŋ�؂��Ȃ��悤�ɂ��邽�߂̑Ή�
            PrintCommonLibrary.ConvertReportString(this.Detail);
        }



        // ===============================================================================
        // ActiveReports�f�U�C�i�Ő������ꂽ�R�[�h
        // ===============================================================================
        #region ActiveReports Designer generated code
        #endregion

    }
}
