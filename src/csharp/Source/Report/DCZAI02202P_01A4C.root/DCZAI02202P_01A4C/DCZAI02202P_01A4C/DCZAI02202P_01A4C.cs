//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �݌ɓ��o�Ɋm�F�\
// �v���O�����T�v   : �݌ɓ��o�Ɋm�F�\�̈�����s���B
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��؁@���b
// �� �� ��  2007/09/19  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2008/12/15  �C�����e : ���ɋ��z�A�o�ɋ��z�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/01/08  �C�����e : �P������ɒP���A�o�ɒP���ɕ���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/01/23  �C�����e : �`�[�敪���݌ɓ��o�ɏƉ�ɍ��킹�ďC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/04/06  �C�����e : �e�w�b�_��GroupKeepTogether��FirstDetail�ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/04/07  �C�����e : �s��Ή�[12856][12997]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2009/09/07  �C�����e : PM.NS-2-B �ێ�˗��@ ����t�H�[�}�b�g�s��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10600008-00 �쐬�S�� : yangmj
// �C �� ��  2010/11/15  �C�����e : �@�\���ǂp�S
//----------------------------------------------------------------------------//
using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Specialized;

using DataDynamics.ActiveReports;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;

using System.Collections.Generic;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// �݌Ɏ󕥊m�F�\����t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note         : �݌Ɏ󕥊m�F�\�̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer   : 22018 ��؁@���b</br>
    /// <br>Date         : 2007.09.19</br>
    /// <br></br>
    /// <br>UpdateNote   : 2008/12/15 �Ɠc �M�u�@���ɋ��z�A�o�ɋ��z�ǉ�</br>
    /// <br>               2009/01/08 �Ɠc �M�u�@�P������ɒP���A�o�ɒP���ɕ���</br>
    /// <br>             : 2009/01/23 �Ɠc �M�u�@�s��Ή�[6581]�A�`�[�敪���݌ɓ��o�ɏƉ�ɍ��킹�ďC��</br>
    /// <br>             : 2009/04/06 ��� �r���@�s��Ή�[13149]�A�e�w�b�_��GroupKeepTogether��FirstDetail�ɏC��</br>
    /// <br>             : 2009/04/07 �Ɠc �M�u�@�s��Ή�[12856][12997]</br>
    /// <br>             : 2009/09/07 �������@PM.NS-2-B �ێ�˗��@ ����t�H�[�}�b�g�s��Ή�</br>
    /// <br>UpdateNote�@ : 2010/11/15 yangmj�@�@�\���ǂp�S</br>
    /// </remarks>
    public class DCZAI02202P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        #region �� Constructor
        /// <summary>
        /// �݌Ɏ󕥊m�F�\�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note         : �݌Ɏ󕥊m�F�\�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer   : 22018�@��؁@���b</br>
        /// <br>Date         : 2007.09.19</br>
        /// </remarks>
        public DCZAI02202P_01A4C ()
        {
            InitializeComponent();

            /* --- DEL 2009/01/23 �s��Ή�[6581] -------------------------------------->>>>>
            // ���א����󎚂���`�[�敪�̃��X�g
            _stockAcPaySlipOfArrivalList = new List<int>();
            //10:�d��
            //11:����
            //31:�ړ�����
            _stockAcPaySlipOfArrivalList.AddRange( new int[] { 10, 11, 31 } );

            // �o�א����󎚂���`�[�敪�̃��X�g
            _stockAcPaySlipOfShipmentList = new List<int>();
            //12:��v��
            //20:����
            //21:���v��
            //22:�o��
            //23:����
            //30:�ړ��o��
            //40:����
            //41:����
            //50:�I��
            _stockAcPaySlipOfShipmentList.AddRange( new int[] { 12, 20, 21, 22, 23, 30, 40, 41, 50 } );
               --- DEL 2009/01/23 �s��Ή�[6581] --------------------------------------<<<<< */
            // --- ADD 2009/01/23 �s��Ή�[6581] -------------------------------------->>>>>
            // ���א����󎚂���`�[�敪�̃��X�g
            // 10�F�d���A11�F���ׁA13�F�݌Ɏd���A31�F�ړ����ׁA40�F�����A42�F�}�X�^�����e�A50�F�I���A60�F�g���A61�F�����A70�F��[����
            _stockAcPaySlipOfArrivalList = new List<int>();
            _stockAcPaySlipOfArrivalList.AddRange(new int[] { 10, 11, 13, 31, 40, 42, 50, 60, 61, 70 });
            // �o�א����󎚂���`�[�敪�̃��X�g
            // 12�F��v��A20�F����A21�F���v��A22�F�o�ׁA23�F���؁A30�F�ړ��o�ׁA41�F�����A71�F��[�o��
            _stockAcPaySlipOfShipmentList = new List<int>();
            _stockAcPaySlipOfShipmentList.AddRange(new int[] { 12, 20, 21, 22, 23, 30, 41, 71 });
            // --- ADD 2009/01/23 �s��Ή�[6581] --------------------------------------<<<<<
        }
        #endregion �� Constructor

        #region �� Private Member
        private int _printCount;									// ��������p�J�E���^

        private int _extraCondHeadOutDiv;			                // ���o�����w�b�_�o�͋敪
        private StringCollection _extraConditions;				    // ���o����
        private int _pageFooterOutCode;				                // �t�b�^�[�o�͋敪
        private StringCollection _pageFooters;					    // �t�b�^�[���b�Z�[�W
        private SFCMN06002C _printInfo;						        // ������N���X
        private string _pageHeaderTitle;				            // �t�H�[���^�C�g��
        private string _pageHeaderSortOderTitle;		            // �\�[�g��

        //private string _beforeSectionCode;              // ADD 2008/07/02 �� DEL 2009/04/07 �s��Ή�[12997]

        private StockAcPayListCndtn _stockAcPayListCndtn;			// ���o�����N���X

        private List<int> _stockAcPaySlipOfArrivalList;
        private List<int> _stockAcPaySlipOfShipmentList;

        // �w�b�_�[�T�u���|�[�g�錾
        ListCommon_ExtraHeader _rptExtraHeader = null;
        // �t�b�^�[���|�[�g�錾
        ListCommon_PageFooter _rptPageFooter = null;
        private Line line3;
        private TextBox AcPayOtherPartyCd;
        private TextBox AcPayOtherPartyNm;
        private TextBox Sl_SalesDate;
        private Line line4;
        private TextBox Gds_GoodsMakerCd;
        private TextBox Gds_MakerName;
        private Label Lb_AcPayOtherParty;
        private Label Lb_ListPriceTaxExcFl;
        private Label Lb_SalesUnPrcTaxExcFl;
        private TextBox AcPaySlipNum;
        private TextBox AcPaySlipNm;
        private Label Lb_WarehouseName;
        private Label Lb_IoGoodsDay;
        private Label Lb_AcPaySlipNum;
        private TextBox Wh_WarehouseName;
        private TextBox Wh_WarehouseCode;
        private TextBox AcPayTransNm;
        private TextBox StockUnitPriceFl;
        private Line line2;
        private Label Lb_AcPaySlipNm;
        private Label Lb_AcPayTransNm;
        private GroupHeader MakerHeader;
        private GroupFooter MakerFooter;
        private Line line5;
        private TextBox AcPaySlipCd;
        private Line line6;
        private Line line7;
        private TextBox StockPrice;
        private TextBox SalesMoney;
        private Label Lb_StockPrice;
        private Label Lb_SalesMoney;
        private TextBox SalesUnPrcTaxExcFl;
        private Label label1;
        private TextBox textBox2;
        private TextBox textBox60;
        private TextBox WhArrivalCnt;
        private TextBox WhShipmentCnt;
        private TextBox WhStockPrice;
        private TextBox WhSalesMoney;
        private TextBox textBox1;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label tb_HeaderSortOderTitle;
        private Label label4;
        private TextBox Sl_AcPayHistDateTimeView;
        private TextBox Sl_ShelfNo;
        private Label label5;
        private TextBox WhCnt;
        private TextBox AllCnt;
        private TextBox textBox11;
        private TextBox Gds_ArrivalCnt;
        private TextBox Gds_ShipmentCnt;
        private TextBox Gds_Cnt;
        private TextBox textBox15;
        private TextBox textBox17;
        private Line line8;
        private Label Lb_StockTotal;
        private TextBox Gds_StockTotal;
        private TextBox textBox6;
        private TextBox textBox8;
        private TextBox textBox9;
        private TextBox textBox7;

        // Dispose�`�F�b�N�p�t���O
        bool disposed = false;

        #endregion �� Private Member

        #region �� Dispose(override)
        /// <summary>
        /// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
        /// </summary>
        protected override void Dispose ( bool disposing )
        {
            if ( !this.disposed ) {
                try {
                    if ( disposing ) {
                        // �w�b�_�p�T�u���|�[�g�㏈�����s
                        if ( this._rptExtraHeader != null ) {
                            this._rptExtraHeader.Dispose();
                        }

                        // �t�b�^�p�T�u���|�[�g�㏈�����s
                        if ( this._rptPageFooter != null ) {
                            this._rptPageFooter.Dispose();
                        }
                    }

                    this.disposed = true;
                }
                finally {
                    base.Dispose(disposing);
                }
            }
        }
        #endregion �� Dispose(override)

        #region �� IPrintActiveReportTypeList �����o
        #region �� Public Property
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
                this._stockAcPayListCndtn = ( StockAcPayListCndtn ) this._printInfo.jyoken;
            }
        }

        /// <summary>
        /// ���̑��f�[�^
        /// </summary>
        public ArrayList OtherDataList
        {
            set { }
        }

        /// <summary>
        /// ���[�T�u�^�C�g��
        /// </summary>
        public string PageHeaderSubtitle
        {
            set { this._pageHeaderTitle = value; }
        }

        /// <summary>
        /// ��������J�E���g�A�b�v�C�x���g
        /// </summary>
        public event ProgressBarUpEventHandler ProgressBarUpEvent;
        #endregion �� Public Property
        #endregion �� IPrintActiveReportTypeList �����o

        #region �� IPrintActiveReportTypeCommon �����o
        #region �� Public Property
        /// <summary>
        /// �w�i���ߐݒ�l�v���p�e�B
        /// </summary>
        public int WatermarkMode
        {
            get
            {
                // TODO:  DCZAI02103P_01A4C.WatermarkMode getter ������ǉ����܂��B
                return 0;
            }
            set
            {
                // TODO:  DCZAI02103P_01A4C.WatermarkMode setter ������ǉ����܂��B
            }
        }
        #endregion �� Public Property
        #endregion �� IPrintActiveReportTypeCommon �����o

        #region �� Private Method
        #region �� ���|�[�g�v�f�o�͐ݒ�
        /// <summary>
        /// ���|�[�g�v�f�o�͐ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���|�[�g�̗v�f�iHeader�AFooter�AText�j�̏o�͐ݒ�</br>
        /// <br>Programmer	: 22018 ��؁@���b</br>
        /// <br>Date		: 2007.09.19</br>
        /// <br>UpdateNote : 2010/11/15 yangmj�@�@�\���ǂp�S</br>
        /// </remarks>
        private void SetOfReportMembersOutput ()
        {
            this._printCount = 0;
            // �󎚐ݒ� --------------------------------------------------------------------------------------

            // ���ڂ̖��̂��Z�b�g
            tb_ReportTitle.Text = this._pageHeaderTitle;				// �T�u�^�C�g��

            // TODO : ���ו��̈�����ڂ̗L���A�^�C�g���ݒ�Ȃǂ��s���B


            //// ���_�v���o�͂��邩���Ȃ�����I������
            //// ���_�L���𔻒f
            //if ( this._stockAcPayListCndtn.IsOptSection ) {
            //    // �S�Ђ��`�F�b�N����Ă��鎞�A�܂��͋��_�I���̃`�F�b�N�����u1�v�ȉ��̎��́A���_�v���R�[�h�͏o�͂��Ȃ�
            //    if ( ( this._stockAcPayListCndtn.SectionCodes.Length < 2 ) ||
            //        this._stockAcPayListCndtn.IsSelectAllSection ) {
            //        SectionHeader.DataField = "";
            //        SectionHeader.Visible = false;
            //        SectionFooter.Visible = false;
            //    }
            //    else {
            //        SectionHeader.DataField = DCZAI02145EA.ct_Col_Sort_SectionCode;
            //        SectionHeader.Visible = true;
            //        SectionFooter.Visible = true;
            //    }
            //}
            //else {
            //    // ���_��
            //    SectionHeader.DataField = "";
            //    SectionHeader.Visible = false;
            //    SectionFooter.Visible = false;
            //}
            // ---ADD 2010/11/15 ------------------------>>>>>
            if (this._stockAcPayListCndtn.GroupCnt == 0)
            {
                this.GoodsFooter.Visible = false;
            }
            else
            {
                this.GoodsFooter.Visible = true;
            }
            // ---ADD 2010/11/15 ------------------------<<<<<
        }
        /// <summary>
        /// �͈͌����̎擾����
        /// </summary>
        /// <returns>�͈͌����iex.�S���`�U���Ȃ�΂R�j</returns>
        private int GetMonthRange ( DateTime stYearMonth, DateTime edYearMonth )
        {
            int stMonth = stYearMonth.Month;
            int edMonth = edYearMonth.Month;

            if ( edYearMonth.Year > stYearMonth.Year ) {
                edMonth += 12;
            }

            return ( edMonth - stMonth + 1 );
        }
        /// <summary>
        /// ���^�C�g���擾
        /// </summary>
        /// <param name="stYearMonth"></param>
        /// <param name="index"></param>
        /// <returns>���^�C�g��(ex.�P��,�Q���c)</returns>
        private string GetMonthTitle ( DateTime stYearMonth, int index )
        {
            int month = stYearMonth.Month + index;

            if ( month > 12 ) month -= 12;

            return ( month.ToString() + "��" );
        }
        #endregion �� ���|�[�g�v�f�o�͐ݒ�


        #region �� �O���[�v�T�v���X�֌W
        #region �� �O���[�v�T�v���X���f
        /// <summary>
        /// �O���[�v�T�v���X���f
        /// </summary>
        private void CheckGroupSuppression ()
        {
            // TODO : �O���[�v�T�v���X�������L�q����B
            //        ��̓I�ȏ����菇�́A�@if�őO�sKEY�Ɣ�r���A�����Ȃ獀��.Visible=false�Ƃ���B
            //        �Ō�ɁA����s��KEY��ޔ�����B
        }
        #endregion
        #endregion
        #endregion

        #region �� Control Event

        #region �� DCZAI02103P_01A4C_ReportStart Event
        /// <summary>
        /// DCZAI02103P_01A4C_ReportStart Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="eArgs">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���|�[�g�J�n���̃C�x���g�ł��B</br>
        /// <br>Programmer	: 22018 ��؁@���b</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
        private void DCZAI02103P_01A4C_ReportStart ( object sender, System.EventArgs eArgs )
        {
            SetOfReportMembersOutput();
        }
        #endregion

        #region �� DCZAI02103P_01A4C_PageEnd Event
        /// <summary>
        /// DCZAI02103P_01A4C_PageEnd Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="eArgs">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: DCZAI02103P_01A4C_PageEnd Event</br>
        /// <br>Programmer	: 22018 ��؁@���b</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
        private void DCZAI02103P_01A4C_PageEnd ( object sender, System.EventArgs eArgs )
        {
            // TODO : �O�s�̑ޔ�field���N���A����B�i����擪�s�̓T�v���X��������j
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
        /// <br>Programmer	: 22018 ��؁@���b</br>
        /// <br>Date		: 2007.09.19</br>
        /// <br>UpdateNote : 2010/11/15 yangmj�@�@�\���ǂp�S</br>
        /// </remarks>
        private void PageHeader_Format ( object sender, System.EventArgs eArgs )
        {
            // �쐬���t
            this.tb_PrintDate.Text = TDateTime.DateTimeToString(StockAcPayListCndtn.ct_DateFomat, DateTime.Now);
            // �쐬����
            this.tb_PrintTime.Text = DateTime.Now.ToString("HH:mm");

            // ---ADD 2010/11/15 ------------------------>>>>>
            if (this._stockAcPayListCndtn.Sort == 0)
            {
                this.tb_HeaderSortOderTitle.Text = "[�\�[�g��:�q�Ɂ��i�ԁ����[�J�[��]";
            }
            else
            {
                this.tb_HeaderSortOderTitle.Text = "[�\�[�g��:�q�Ɂ����[�J�[���i�ԏ�]";
            }
            // ---ADD 2010/11/15 ------------------------<<<<<

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
        /// <br>Programmer	: 22018 ��؁@���b</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
        private void ExtraHeader_Format ( object sender, System.EventArgs eArgs )
        {
            // ���o�����ݒ�
            // �w�b�_�o�͐���
            if ( this._extraCondHeadOutDiv == 0 ) {
                // ���y�[�W�o��
                this.ExtraHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
            }
            else {
                // �擪�y�[�W�̂�
                this.ExtraHeader.RepeatStyle = RepeatStyle.None;
            }

            // �C���X�^���X���쐬����Ă��Ȃ���΍쐬
            if ( this._rptExtraHeader == null ) {
                this._rptExtraHeader = new ListCommon_ExtraHeader();
            }
            else {
                // �C���X�^���X���쐬����Ă���΁A�f�[�^�\�[�X������������
                // (�o�C���h����f�[�^�\�[�X�������f�[�^�ł����Ă��A��x���������Ă����Ȃ��Ƃ��܂��������Ȃ��B
                this._rptExtraHeader.DataSource = null;
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// ���_�I�v�V�����L������
            //string sectionTitle = string.Format( "{0}���_�F", this._stockAcPayListCndtn.MainExtractTitle );
            //if ( this._stockAcPayListCndtn.IsOptSection )
            //{
            //    if ( this._stockAcPayListCndtn.IsSelectAllSection )
            //    {
            //        this._rptExtraHeader.SectionCondition.Text = string.Format( "{0}{1}", sectionTitle, "�S��" );
            //    }
            //    else
            //    {
            //        this._rptExtraHeader.SectionCondition.Text = string.Format( "{0}{1}", sectionTitle, this.tb_MainSectionName.Text );
            //    }

            //} 
            //else 
            //{
            //    this._rptExtraHeader.SectionCondition.Text = "";
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // ���o�����󎚍��ڐݒ�
            this._rptExtraHeader.ExtraConditions = this._extraConditions;

            this.Header_SubReport.Report = this._rptExtraHeader;
        }
        #endregion

        #region �� Detail_Format Event
        /// <summary>
        /// Detail_Format Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="eArgs">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: Detail�O���[�v�̃t�H�[�}�b�g�C�x���g�B</br>
        /// <br>Programmer	: 22018 ��؁@���b</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
        private void Detail_Format ( object sender, System.EventArgs eArgs )
        {
        }
        #endregion

        #region �� Detail_BeforePrint Event
        /// <summary>
        /// Detail_BeforePrint Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="eArgs">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �Z�N�V�������y�[�W�ɕ`�悳���O�ɔ�������B</br>
        /// <br>Programmer	: 22018 ��؁@���b</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
        private void Detail_BeforePrint ( object sender, System.EventArgs eArgs )
        {
            // ���ڂ̈󎚁E��󎚐���
            this.SetFieldsVisibleInDetail();

            // �O���[�v�T�v���X�̔��f
            this.CheckGroupSuppression();
            // Wordrap�v���p�e�B�ŕ��������r���[�ȂƂ���ŋ�؂��Ȃ��悤�ɂ��邽�߂̑Ή�
            PrintCommonLibrary.ConvertReportString(this.Detail);

            // ADD 2008/09/26 �s��Ή�[5574]---------->>>>>
            // ����敪
            if (this.AcPayTransNm.Value.ToString().Equals("�ʏ�"))
            {
                this.AcPayTransNm.Value = "�ʏ�`�[";   // LITERAL:
            }
            // ADD 2008/09/26 �s��Ή�[5574]----------<<<<<
            // ADD 2008/09/26 �s��Ή�[5569]---------->>>>>
            // ���o�ɐ�
            int AcPayOtherPartyCdNumber = -1;
            if (int.TryParse(this.AcPayOtherPartyCd.Value.ToString(), out AcPayOtherPartyCdNumber))
            {
                if (AcPayOtherPartyCdNumber.Equals(0)) this.AcPayOtherPartyCd.Value = string.Empty;
            }
            // ADD 2008/09/26 �s��Ή�[5569]----------<<<<<
        }

        /// <summary>
        /// ���ڂ̈󎚁E��󎚐���
        /// </summary>
        private void SetFieldsVisibleInDetail ()
        {
            // �`�[�敪�擾
            int acPaySlipCd = GetValueFromTextBox( AcPaySlipCd );

            // ���א��̈󎚗L��
            if ( _stockAcPaySlipOfArrivalList.Contains( acPaySlipCd ) )
            {
                ArrivalCnt.Visible = true;
                StockPrice.Visible = true;          //ADD 2008/12/15
                StockUnitPriceFl.Visible = true;    //ADD 2009/01/08
                textBox6.Visible = true;            //ADD 2010/11/15
                textBox9.Visible = true;            //ADD 2010/11/15
            }
            else
            {
                ArrivalCnt.Visible = false;
                StockPrice.Visible = false;         //ADD 2008/12/15
                StockUnitPriceFl.Visible = false;   //ADD 2009/01/08
                textBox6.Visible = false;           //ADD 2010/11/15
                textBox9.Visible = false;           //ADD 2010/11/15
            }

            // �o�א��̈󎚗L��
            if ( _stockAcPaySlipOfShipmentList.Contains( acPaySlipCd ) )
            {
                ShipmentCnt.Visible = true;
                SalesMoney.Visible = true;          //ADD 2008/12/15
                SalesUnPrcTaxExcFl.Visible = true;  //ADD 2009/01/08
                textBox7.Visible = true;            //ADD 2010/11/15
                textBox8.Visible = true;            //ADD 2010/11/15
            }
            else
            {
                ShipmentCnt.Visible = false;
                SalesMoney.Visible = false;         //ADD 2008/12/15
                SalesUnPrcTaxExcFl.Visible = false; //ADD 2009/01/08
                textBox7.Visible = false;           //ADD 2010/11/15
                textBox8.Visible = false;           //ADD 2010/11/15
            }
        }
        /// <summary>
        /// �e�L�X�g�{�b�N�X���琔�l���擾
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns></returns>
        private int GetValueFromTextBox ( TextBox textBox )
        {
            try
            {
                return Int32.Parse( textBox.Text.Replace(",","").Trim() );
            }
            catch
            {
                return 0;
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
        /// <br>Programmer  : 22018 ��؁@���b</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
        private void Detail_AfterPrint ( object sender, System.EventArgs eArgs )
        {
            // ��������J�E���g�A�b�v
            this._printCount++;
#if DEBUG
            return;
#endif
            if ( this.ProgressBarUpEvent != null ) {
                this.ProgressBarUpEvent(this, this._printCount);
            }

        }
        #endregion

        #region �� DailyFooter_Format Event
        /// <summary>
        /// DailyFooter_Format Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="eArgs">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: DailyFooter_Format Event</br>
        /// <br>Programmer	: 22018 ��؁@���b</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
        private void DailyFooter_Format ( object sender, System.EventArgs eArgs )
        {
            // TODO : �O�sKEY�ޔ����N���A�i�����ׂ̓T�v���X�����j
        }
        #endregion

        #region �� PageFooter_Format Event
        /// <summary>
        /// PageFooter_Format Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="eArgs">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: PageFooter�O���[�v�̃t�H�[�}�b�g�C�x���g�B</br>
        /// <br>Programmer	: 22018 ��؁@���b</br>
        /// <br>Date		: 2007.09.19</br>
        /// </remarks>
        private void PageFooter_Format ( object sender, System.EventArgs eArgs )
        {
            // �t�b�^�[�o�͂���H
            if ( this._pageFooterOutCode == 0 ) {
                // �C���X�^���X���쐬����Ă��Ȃ���΍쐬
                if ( _rptPageFooter == null ) {
                    _rptPageFooter = new ListCommon_PageFooter();
                }
                else {
                    // �C���X�^���X���쐬����Ă���΁A�f�[�^�\�[�X������������
                    // (�o�C���h����f�[�^�\�[�X�������f�[�^�ł����Ă��A��x���������Ă����Ȃ��Ƃ��܂��������Ȃ��B
                    _rptPageFooter.DataSource = null;
                }

                // �t�b�^�[�󎚍��ڐݒ�
                if ( this._pageFooters[0] != null ) {
                    _rptPageFooter.PrintFooter1 = this._pageFooters[0];
                }
                if ( this._pageFooters[1] != null ) {
                    _rptPageFooter.PrintFooter2 = this._pageFooters[1];
                }

                this.Footer_SubReport.Report = _rptPageFooter;
            }
        }
        #endregion

        #endregion �� Control Event

		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.PageHeader PageHeader;
		private DataDynamics.ActiveReports.Label Label3;
		private DataDynamics.ActiveReports.TextBox tb_PrintDate;
		private DataDynamics.ActiveReports.Label Label2;
		private DataDynamics.ActiveReports.TextBox tb_PrintPage;
		private DataDynamics.ActiveReports.Line Line1;
		private DataDynamics.ActiveReports.TextBox tb_PrintTime;
		private DataDynamics.ActiveReports.Label tb_ReportTitle;
		private DataDynamics.ActiveReports.GroupHeader ExtraHeader;
		private DataDynamics.ActiveReports.SubReport Header_SubReport;
		private DataDynamics.ActiveReports.GroupHeader TitleHeader;
		private DataDynamics.ActiveReports.Label Lb_GoodsNo;
		private DataDynamics.ActiveReports.Line Line42;
        private DataDynamics.ActiveReports.Label Lb_GoodsName;
        private DataDynamics.ActiveReports.Label Lb_MakerName;
		private DataDynamics.ActiveReports.Label Lb_ShipmentCnt;
        private DataDynamics.ActiveReports.Label Lb_SalesUnitCost;
		private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
		private DataDynamics.ActiveReports.GroupHeader WarehouseHeader;
        private DataDynamics.ActiveReports.GroupHeader GoodsHeader;
		private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.TextBox Gds_GoodsNo;
        private DataDynamics.ActiveReports.TextBox Gds_GoodsName;
        private DataDynamics.ActiveReports.TextBox ListPriceTaxExcFl;
		private DataDynamics.ActiveReports.TextBox ShipmentCnt;
        private DataDynamics.ActiveReports.TextBox ArrivalCnt;
        private DataDynamics.ActiveReports.GroupFooter GoodsFooter;
        private DataDynamics.ActiveReports.GroupFooter WarehouseFooter;
        private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
		private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.Line Line41;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.SubReport Footer_SubReport;
        /// <summary>
        /// 
        /// </summary>
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCZAI02202P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.ListPriceTaxExcFl = new DataDynamics.ActiveReports.TextBox();
            this.ArrivalCnt = new DataDynamics.ActiveReports.TextBox();
            this.AcPaySlipNum = new DataDynamics.ActiveReports.TextBox();
            this.AcPaySlipNm = new DataDynamics.ActiveReports.TextBox();
            this.Sl_SalesDate = new DataDynamics.ActiveReports.TextBox();
            this.AcPayOtherPartyNm = new DataDynamics.ActiveReports.TextBox();
            this.AcPayOtherPartyCd = new DataDynamics.ActiveReports.TextBox();
            this.AcPayTransNm = new DataDynamics.ActiveReports.TextBox();
            this.StockUnitPriceFl = new DataDynamics.ActiveReports.TextBox();
            this.AcPaySlipCd = new DataDynamics.ActiveReports.TextBox();
            this.line7 = new DataDynamics.ActiveReports.Line();
            this.StockPrice = new DataDynamics.ActiveReports.TextBox();
            this.SalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.SalesUnPrcTaxExcFl = new DataDynamics.ActiveReports.TextBox();
            this.ShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.Sl_AcPayHistDateTimeView = new DataDynamics.ActiveReports.TextBox();
            this.Sl_ShelfNo = new DataDynamics.ActiveReports.TextBox();
            this.textBox6 = new DataDynamics.ActiveReports.TextBox();
            this.textBox7 = new DataDynamics.ActiveReports.TextBox();
            this.textBox8 = new DataDynamics.ActiveReports.TextBox();
            this.textBox9 = new DataDynamics.ActiveReports.TextBox();
            this.Gds_GoodsNo = new DataDynamics.ActiveReports.TextBox();
            this.Gds_GoodsName = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.tb_HeaderSortOderTitle = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Line42 = new DataDynamics.ActiveReports.Line();
            this.Lb_SalesUnPrcTaxExcFl = new DataDynamics.ActiveReports.Label();
            this.Lb_StockPrice = new DataDynamics.ActiveReports.Label();
            this.Lb_SalesMoney = new DataDynamics.ActiveReports.Label();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.Lb_WarehouseName = new DataDynamics.ActiveReports.Label();
            this.Lb_MakerName = new DataDynamics.ActiveReports.Label();
            this.Lb_GoodsNo = new DataDynamics.ActiveReports.Label();
            this.Lb_GoodsName = new DataDynamics.ActiveReports.Label();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.Lb_IoGoodsDay = new DataDynamics.ActiveReports.Label();
            this.Lb_AcPaySlipNum = new DataDynamics.ActiveReports.Label();
            this.Lb_AcPaySlipNm = new DataDynamics.ActiveReports.Label();
            this.Lb_AcPayTransNm = new DataDynamics.ActiveReports.Label();
            this.Lb_AcPayOtherParty = new DataDynamics.ActiveReports.Label();
            this.Lb_ShipmentCnt = new DataDynamics.ActiveReports.Label();
            this.Lb_SalesUnitCost = new DataDynamics.ActiveReports.Label();
            this.Lb_ListPriceTaxExcFl = new DataDynamics.ActiveReports.Label();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.Lb_StockTotal = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.textBox4 = new DataDynamics.ActiveReports.TextBox();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.AllCnt = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.Wh_WarehouseName = new DataDynamics.ActiveReports.TextBox();
            this.Wh_WarehouseCode = new DataDynamics.ActiveReports.TextBox();
            this.WarehouseFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.textBox60 = new DataDynamics.ActiveReports.TextBox();
            this.WhArrivalCnt = new DataDynamics.ActiveReports.TextBox();
            this.WhShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.WhStockPrice = new DataDynamics.ActiveReports.TextBox();
            this.WhSalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.WhCnt = new DataDynamics.ActiveReports.TextBox();
            this.GoodsHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.Gds_GoodsMakerCd = new DataDynamics.ActiveReports.TextBox();
            this.Gds_MakerName = new DataDynamics.ActiveReports.TextBox();
            this.Gds_StockTotal = new DataDynamics.ActiveReports.TextBox();
            this.GoodsFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Gds_ArrivalCnt = new DataDynamics.ActiveReports.TextBox();
            this.Gds_ShipmentCnt = new DataDynamics.ActiveReports.TextBox();
            this.textBox11 = new DataDynamics.ActiveReports.TextBox();
            this.Gds_Cnt = new DataDynamics.ActiveReports.TextBox();
            this.textBox15 = new DataDynamics.ActiveReports.TextBox();
            this.textBox17 = new DataDynamics.ActiveReports.TextBox();
            this.line8 = new DataDynamics.ActiveReports.Line();
            this.MakerHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.MakerFooter = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.ListPriceTaxExcFl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrivalCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcPaySlipNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcPaySlipNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sl_SalesDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcPayOtherPartyNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcPayOtherPartyCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcPayTransNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockUnitPriceFl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcPaySlipCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesUnPrcTaxExcFl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sl_AcPayHistDateTimeView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sl_ShelfNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gds_GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gds_GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_HeaderSortOderTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalesUnPrcTaxExcFl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_StockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_WarehouseName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MakerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_IoGoodsDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AcPaySlipNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AcPaySlipNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AcPayTransNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AcPayOtherParty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalesUnitCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ListPriceTaxExcFl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_StockTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AllCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_WarehouseName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_WarehouseCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox60)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WhArrivalCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WhShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WhStockPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WhSalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WhCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gds_GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gds_MakerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gds_StockTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gds_ArrivalCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gds_ShipmentCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gds_Cnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.ListPriceTaxExcFl,
            this.ArrivalCnt,
            this.AcPaySlipNum,
            this.AcPaySlipNm,
            this.Sl_SalesDate,
            this.AcPayOtherPartyNm,
            this.AcPayOtherPartyCd,
            this.AcPayTransNm,
            this.StockUnitPriceFl,
            this.AcPaySlipCd,
            this.line7,
            this.StockPrice,
            this.SalesMoney,
            this.SalesUnPrcTaxExcFl,
            this.ShipmentCnt,
            this.Sl_AcPayHistDateTimeView,
            this.Sl_ShelfNo,
            this.textBox6,
            this.textBox7,
            this.textBox8,
            this.textBox9});
            this.Detail.Height = 0.3541667F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // ListPriceTaxExcFl
            // 
            this.ListPriceTaxExcFl.Border.BottomColor = System.Drawing.Color.Black;
            this.ListPriceTaxExcFl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPriceTaxExcFl.Border.LeftColor = System.Drawing.Color.Black;
            this.ListPriceTaxExcFl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPriceTaxExcFl.Border.RightColor = System.Drawing.Color.Black;
            this.ListPriceTaxExcFl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPriceTaxExcFl.Border.TopColor = System.Drawing.Color.Black;
            this.ListPriceTaxExcFl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ListPriceTaxExcFl.DataField = "ListPriceTaxExcFl";
            this.ListPriceTaxExcFl.Height = 0.125F;
            this.ListPriceTaxExcFl.Left = 7.274F;
            this.ListPriceTaxExcFl.MultiLine = false;
            this.ListPriceTaxExcFl.Name = "ListPriceTaxExcFl";
            this.ListPriceTaxExcFl.OutputFormat = resources.GetString("ListPriceTaxExcFl.OutputFormat");
            this.ListPriceTaxExcFl.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: �l�r �S�V�b�N; verti" +
                "cal-align: top; ";
            this.ListPriceTaxExcFl.Text = "1,234,567";
            this.ListPriceTaxExcFl.Top = 0.031F;
            this.ListPriceTaxExcFl.Width = 0.5625F;
            // 
            // ArrivalCnt
            // 
            this.ArrivalCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.ArrivalCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.ArrivalCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt.Border.RightColor = System.Drawing.Color.Black;
            this.ArrivalCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt.Border.TopColor = System.Drawing.Color.Black;
            this.ArrivalCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ArrivalCnt.DataField = "ArrivalCnt";
            this.ArrivalCnt.Height = 0.125F;
            this.ArrivalCnt.Left = 5.26475F;
            this.ArrivalCnt.MultiLine = false;
            this.ArrivalCnt.Name = "ArrivalCnt";
            this.ArrivalCnt.OutputFormat = resources.GetString("ArrivalCnt.OutputFormat");
            this.ArrivalCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: �l�r �S�V�b�N; verti" +
                "cal-align: top; ";
            this.ArrivalCnt.Text = "123,456.00111";
            this.ArrivalCnt.Top = 0.031F;
            this.ArrivalCnt.Width = 0.663F;
            // 
            // AcPaySlipNum
            // 
            this.AcPaySlipNum.Border.BottomColor = System.Drawing.Color.Black;
            this.AcPaySlipNum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcPaySlipNum.Border.LeftColor = System.Drawing.Color.Black;
            this.AcPaySlipNum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcPaySlipNum.Border.RightColor = System.Drawing.Color.Black;
            this.AcPaySlipNum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcPaySlipNum.Border.TopColor = System.Drawing.Color.Black;
            this.AcPaySlipNum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcPaySlipNum.DataField = "AcPaySlipNum";
            this.AcPaySlipNum.Height = 0.125F;
            this.AcPaySlipNum.Left = 1.085333F;
            this.AcPaySlipNum.MultiLine = false;
            this.AcPaySlipNum.Name = "AcPaySlipNum";
            this.AcPaySlipNum.OutputFormat = resources.GetString("AcPaySlipNum.OutputFormat");
            this.AcPaySlipNum.RightToLeft = true;
            this.AcPaySlipNum.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: �l�r �S�V�b�N; vertic" +
                "al-align: top; ";
            this.AcPaySlipNum.Text = "123456789";
            this.AcPaySlipNum.Top = 0.031F;
            this.AcPaySlipNum.Width = 0.5F;
            // 
            // AcPaySlipNm
            // 
            this.AcPaySlipNm.Border.BottomColor = System.Drawing.Color.Black;
            this.AcPaySlipNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcPaySlipNm.Border.LeftColor = System.Drawing.Color.Black;
            this.AcPaySlipNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcPaySlipNm.Border.RightColor = System.Drawing.Color.Black;
            this.AcPaySlipNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcPaySlipNm.Border.TopColor = System.Drawing.Color.Black;
            this.AcPaySlipNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcPaySlipNm.DataField = "AcPaySlipNm";
            this.AcPaySlipNm.Height = 0.125F;
            this.AcPaySlipNm.Left = 2.100833F;
            this.AcPaySlipNm.MultiLine = false;
            this.AcPaySlipNm.Name = "AcPaySlipNm";
            this.AcPaySlipNm.OutputFormat = resources.GetString("AcPaySlipNm.OutputFormat");
            this.AcPaySlipNm.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: �l�r ����; vertical" +
                "-align: top; ";
            this.AcPaySlipNm.Text = "������������";
            this.AcPaySlipNm.Top = 0.031F;
            this.AcPaySlipNm.Width = 0.625F;
            // 
            // Sl_SalesDate
            // 
            this.Sl_SalesDate.Border.BottomColor = System.Drawing.Color.Black;
            this.Sl_SalesDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sl_SalesDate.Border.LeftColor = System.Drawing.Color.Black;
            this.Sl_SalesDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sl_SalesDate.Border.RightColor = System.Drawing.Color.Black;
            this.Sl_SalesDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sl_SalesDate.Border.TopColor = System.Drawing.Color.Black;
            this.Sl_SalesDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sl_SalesDate.DataField = "IoGoodsDay";
            this.Sl_SalesDate.Height = 0.125F;
            this.Sl_SalesDate.Left = 0.125F;
            this.Sl_SalesDate.MultiLine = false;
            this.Sl_SalesDate.Name = "Sl_SalesDate";
            this.Sl_SalesDate.OutputFormat = resources.GetString("Sl_SalesDate.OutputFormat");
            this.Sl_SalesDate.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: �l�r ����; vertical" +
                "-align: top; ";
            this.Sl_SalesDate.Text = "99/99/99";
            this.Sl_SalesDate.Top = 0.031F;
            this.Sl_SalesDate.Width = 0.4375F;
            // 
            // AcPayOtherPartyNm
            // 
            this.AcPayOtherPartyNm.Border.BottomColor = System.Drawing.Color.Black;
            this.AcPayOtherPartyNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcPayOtherPartyNm.Border.LeftColor = System.Drawing.Color.Black;
            this.AcPayOtherPartyNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcPayOtherPartyNm.Border.RightColor = System.Drawing.Color.Black;
            this.AcPayOtherPartyNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcPayOtherPartyNm.Border.TopColor = System.Drawing.Color.Black;
            this.AcPayOtherPartyNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcPayOtherPartyNm.DataField = "AcPayOtherPartyNm";
            this.AcPayOtherPartyNm.Height = 0.125F;
            this.AcPayOtherPartyNm.Left = 3.760417F;
            this.AcPayOtherPartyNm.MultiLine = false;
            this.AcPayOtherPartyNm.Name = "AcPayOtherPartyNm";
            this.AcPayOtherPartyNm.OutputFormat = resources.GetString("AcPayOtherPartyNm.OutputFormat");
            this.AcPayOtherPartyNm.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: �l�r ����; vertical" +
                "-align: top; ";
            this.AcPayOtherPartyNm.Text = "�������������F�����������������������ĂƂȂɂʂ˂̂�";
            this.AcPayOtherPartyNm.Top = 0.031F;
            this.AcPayOtherPartyNm.Width = 1.5F;
            // 
            // AcPayOtherPartyCd
            // 
            this.AcPayOtherPartyCd.Border.BottomColor = System.Drawing.Color.Black;
            this.AcPayOtherPartyCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcPayOtherPartyCd.Border.LeftColor = System.Drawing.Color.Black;
            this.AcPayOtherPartyCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcPayOtherPartyCd.Border.RightColor = System.Drawing.Color.Black;
            this.AcPayOtherPartyCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcPayOtherPartyCd.Border.TopColor = System.Drawing.Color.Black;
            this.AcPayOtherPartyCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcPayOtherPartyCd.DataField = "AcPayOtherPartyCd";
            this.AcPayOtherPartyCd.Height = 0.125F;
            this.AcPayOtherPartyCd.Left = 3.340833F;
            this.AcPayOtherPartyCd.MultiLine = false;
            this.AcPayOtherPartyCd.Name = "AcPayOtherPartyCd";
            this.AcPayOtherPartyCd.OutputFormat = resources.GetString("AcPayOtherPartyCd.OutputFormat");
            this.AcPayOtherPartyCd.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: �l�r �S�V�b�N; vertic" +
                "al-align: top; ";
            this.AcPayOtherPartyCd.Text = "12�F1234";
            this.AcPayOtherPartyCd.Top = 0.031F;
            this.AcPayOtherPartyCd.Width = 0.4375F;
            // 
            // AcPayTransNm
            // 
            this.AcPayTransNm.Border.BottomColor = System.Drawing.Color.Black;
            this.AcPayTransNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcPayTransNm.Border.LeftColor = System.Drawing.Color.Black;
            this.AcPayTransNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcPayTransNm.Border.RightColor = System.Drawing.Color.Black;
            this.AcPayTransNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcPayTransNm.Border.TopColor = System.Drawing.Color.Black;
            this.AcPayTransNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcPayTransNm.DataField = "AcPayTransNm";
            this.AcPayTransNm.Height = 0.125F;
            this.AcPayTransNm.Left = 2.760417F;
            this.AcPayTransNm.MultiLine = false;
            this.AcPayTransNm.Name = "AcPayTransNm";
            this.AcPayTransNm.OutputFormat = resources.GetString("AcPayTransNm.OutputFormat");
            this.AcPayTransNm.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: �l�r ����; vertical" +
                "-align: top; ";
            this.AcPayTransNm.Text = "����������";
            this.AcPayTransNm.Top = 0.031F;
            this.AcPayTransNm.Width = 0.5625F;
            // 
            // StockUnitPriceFl
            // 
            this.StockUnitPriceFl.Border.BottomColor = System.Drawing.Color.Black;
            this.StockUnitPriceFl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPriceFl.Border.LeftColor = System.Drawing.Color.Black;
            this.StockUnitPriceFl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPriceFl.Border.RightColor = System.Drawing.Color.Black;
            this.StockUnitPriceFl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPriceFl.Border.TopColor = System.Drawing.Color.Black;
            this.StockUnitPriceFl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockUnitPriceFl.DataField = "StockUnitPriceFl";
            this.StockUnitPriceFl.Height = 0.125F;
            this.StockUnitPriceFl.Left = 7.846F;
            this.StockUnitPriceFl.MultiLine = false;
            this.StockUnitPriceFl.Name = "StockUnitPriceFl";
            this.StockUnitPriceFl.OutputFormat = resources.GetString("StockUnitPriceFl.OutputFormat");
            this.StockUnitPriceFl.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: �l�r �S�V�b�N; verti" +
                "cal-align: top; ";
            this.StockUnitPriceFl.Text = "1,234,567.00";
            this.StockUnitPriceFl.Top = 0.031F;
            this.StockUnitPriceFl.Width = 0.6875F;
            // 
            // AcPaySlipCd
            // 
            this.AcPaySlipCd.Border.BottomColor = System.Drawing.Color.Black;
            this.AcPaySlipCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcPaySlipCd.Border.LeftColor = System.Drawing.Color.Black;
            this.AcPaySlipCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcPaySlipCd.Border.RightColor = System.Drawing.Color.Black;
            this.AcPaySlipCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcPaySlipCd.Border.TopColor = System.Drawing.Color.Black;
            this.AcPaySlipCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AcPaySlipCd.DataField = "AcPaySlipCd";
            this.AcPaySlipCd.Height = 0.125F;
            this.AcPaySlipCd.Left = 1.9375F;
            this.AcPaySlipCd.MultiLine = false;
            this.AcPaySlipCd.Name = "AcPaySlipCd";
            this.AcPaySlipCd.OutputFormat = resources.GetString("AcPaySlipCd.OutputFormat");
            this.AcPaySlipCd.Style = "color: Gray; ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: �l�r" +
                " ����; vertical-align: top; ";
            this.AcPaySlipCd.Text = "00";
            this.AcPaySlipCd.Top = 0.1875F;
            this.AcPaySlipCd.Visible = false;
            this.AcPaySlipCd.Width = 0.53125F;
            // 
            // line7
            // 
            this.line7.Border.BottomColor = System.Drawing.Color.Black;
            this.line7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line7.Border.LeftColor = System.Drawing.Color.Black;
            this.line7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line7.Border.RightColor = System.Drawing.Color.Black;
            this.line7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line7.Border.TopColor = System.Drawing.Color.Black;
            this.line7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line7.Height = 0F;
            this.line7.Left = 0F;
            this.line7.LineWeight = 1F;
            this.line7.Name = "line7";
            this.line7.Top = 0F;
            this.line7.Width = 10.8F;
            this.line7.X1 = 0F;
            this.line7.X2 = 10.8F;
            this.line7.Y1 = 0F;
            this.line7.Y2 = 0F;
            // 
            // StockPrice
            // 
            this.StockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.StockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.StockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.StockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.StockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.StockPrice.DataField = "StockPrice";
            this.StockPrice.Height = 0.125F;
            this.StockPrice.Left = 9.219166F;
            this.StockPrice.MultiLine = false;
            this.StockPrice.Name = "StockPrice";
            this.StockPrice.OutputFormat = resources.GetString("StockPrice.OutputFormat");
            this.StockPrice.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: �l�r �S�V�b�N; verti" +
                "cal-align: top; ";
            this.StockPrice.Text = "123,456,7891";
            this.StockPrice.Top = 0.031F;
            this.StockPrice.Width = 0.75F;
            // 
            // SalesMoney
            // 
            this.SalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.SalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.SalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesMoney.DataField = "SalesMoney";
            this.SalesMoney.Height = 0.125F;
            this.SalesMoney.Left = 10.01083F;
            this.SalesMoney.MultiLine = false;
            this.SalesMoney.Name = "SalesMoney";
            this.SalesMoney.OutputFormat = resources.GetString("SalesMoney.OutputFormat");
            this.SalesMoney.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: �l�r �S�V�b�N; verti" +
                "cal-align: top; ";
            this.SalesMoney.Text = "123,456,7891";
            this.SalesMoney.Top = 0.031F;
            this.SalesMoney.Width = 0.75F;
            // 
            // SalesUnPrcTaxExcFl
            // 
            this.SalesUnPrcTaxExcFl.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesUnPrcTaxExcFl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnPrcTaxExcFl.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesUnPrcTaxExcFl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnPrcTaxExcFl.Border.RightColor = System.Drawing.Color.Black;
            this.SalesUnPrcTaxExcFl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnPrcTaxExcFl.Border.TopColor = System.Drawing.Color.Black;
            this.SalesUnPrcTaxExcFl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesUnPrcTaxExcFl.DataField = "SalesUnPrcTaxExcFl";
            this.SalesUnPrcTaxExcFl.Height = 0.125F;
            this.SalesUnPrcTaxExcFl.Left = 8.531666F;
            this.SalesUnPrcTaxExcFl.MultiLine = false;
            this.SalesUnPrcTaxExcFl.Name = "SalesUnPrcTaxExcFl";
            this.SalesUnPrcTaxExcFl.OutputFormat = resources.GetString("SalesUnPrcTaxExcFl.OutputFormat");
            this.SalesUnPrcTaxExcFl.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: �l�r �S�V�b�N; verti" +
                "cal-align: top; ";
            this.SalesUnPrcTaxExcFl.Text = "1,234,567.00";
            this.SalesUnPrcTaxExcFl.Top = 0.031F;
            this.SalesUnPrcTaxExcFl.Width = 0.6875F;
            // 
            // ShipmentCnt
            // 
            this.ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ShipmentCnt.DataField = "ShipmentCnt";
            this.ShipmentCnt.Height = 0.125F;
            this.ShipmentCnt.Left = 5.974F;
            this.ShipmentCnt.MultiLine = false;
            this.ShipmentCnt.Name = "ShipmentCnt";
            this.ShipmentCnt.OutputFormat = resources.GetString("ShipmentCnt.OutputFormat");
            this.ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: �l�r �S�V�b�N; verti" +
                "cal-align: top; ";
            this.ShipmentCnt.Text = "123,456.00111";
            this.ShipmentCnt.Top = 0.031F;
            this.ShipmentCnt.Width = 0.663F;
            // 
            // Sl_AcPayHistDateTimeView
            // 
            this.Sl_AcPayHistDateTimeView.Border.BottomColor = System.Drawing.Color.Black;
            this.Sl_AcPayHistDateTimeView.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sl_AcPayHistDateTimeView.Border.LeftColor = System.Drawing.Color.Black;
            this.Sl_AcPayHistDateTimeView.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sl_AcPayHistDateTimeView.Border.RightColor = System.Drawing.Color.Black;
            this.Sl_AcPayHistDateTimeView.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sl_AcPayHistDateTimeView.Border.TopColor = System.Drawing.Color.Black;
            this.Sl_AcPayHistDateTimeView.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sl_AcPayHistDateTimeView.DataField = "AcPayHistDateTimeView";
            this.Sl_AcPayHistDateTimeView.Height = 0.125F;
            this.Sl_AcPayHistDateTimeView.Left = 0.6320834F;
            this.Sl_AcPayHistDateTimeView.MultiLine = false;
            this.Sl_AcPayHistDateTimeView.Name = "Sl_AcPayHistDateTimeView";
            this.Sl_AcPayHistDateTimeView.Style = "ddo-char-set: 1; font-size: 7pt; ";
            this.Sl_AcPayHistDateTimeView.Text = "99/99/99";
            this.Sl_AcPayHistDateTimeView.Top = 0.031F;
            this.Sl_AcPayHistDateTimeView.Width = 0.438F;
            // 
            // Sl_ShelfNo
            // 
            this.Sl_ShelfNo.Border.BottomColor = System.Drawing.Color.Black;
            this.Sl_ShelfNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sl_ShelfNo.Border.LeftColor = System.Drawing.Color.Black;
            this.Sl_ShelfNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sl_ShelfNo.Border.RightColor = System.Drawing.Color.Black;
            this.Sl_ShelfNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sl_ShelfNo.Border.TopColor = System.Drawing.Color.Black;
            this.Sl_ShelfNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Sl_ShelfNo.DataField = "ShelfNo";
            this.Sl_ShelfNo.Height = 0.125F;
            this.Sl_ShelfNo.Left = 1.640417F;
            this.Sl_ShelfNo.Name = "Sl_ShelfNo";
            this.Sl_ShelfNo.Style = "ddo-char-set: 1; font-size: 7pt; font-family: �l�r �S�V�b�N; ";
            this.Sl_ShelfNo.Text = "12345678";
            this.Sl_ShelfNo.Top = 0.031F;
            this.Sl_ShelfNo.Width = 0.44F;
            // 
            // textBox6
            // 
            this.textBox6.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.RightColor = System.Drawing.Color.Black;
            this.textBox6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.Border.TopColor = System.Drawing.Color.Black;
            this.textBox6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox6.DataField = "Bracker";
            this.textBox6.Height = 0.125F;
            this.textBox6.Left = 5.907F;
            this.textBox6.Name = "textBox6";
            this.textBox6.Style = "ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: �l�r �S�V�b�N; ";
            this.textBox6.Text = ")";
            this.textBox6.Top = 0.031F;
            this.textBox6.Width = 0.054F;
            // 
            // textBox7
            // 
            this.textBox7.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox7.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox7.Border.RightColor = System.Drawing.Color.Black;
            this.textBox7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox7.Border.TopColor = System.Drawing.Color.Black;
            this.textBox7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox7.DataField = "Bracker";
            this.textBox7.Height = 0.125F;
            this.textBox7.Left = 6.616F;
            this.textBox7.Name = "textBox7";
            this.textBox7.Style = "ddo-char-set: 1; text-align: left; font-size: 7pt; font-family: �l�r �S�V�b�N; ";
            this.textBox7.Text = ")";
            this.textBox7.Top = 0.031F;
            this.textBox7.Width = 0.054F;
            // 
            // textBox8
            // 
            this.textBox8.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.Border.RightColor = System.Drawing.Color.Black;
            this.textBox8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.Border.TopColor = System.Drawing.Color.Black;
            this.textBox8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox8.DataField = "BrackerPrice";
            this.textBox8.Height = 0.125F;
            this.textBox8.Left = 10.73958F;
            this.textBox8.Name = "textBox8";
            this.textBox8.Style = "ddo-char-set: 1; font-size: 7pt; font-family: �l�r �S�V�b�N; ";
            this.textBox8.Text = ")";
            this.textBox8.Top = 0.031F;
            this.textBox8.Width = 0.054F;
            // 
            // textBox9
            // 
            this.textBox9.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.Border.RightColor = System.Drawing.Color.Black;
            this.textBox9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.Border.TopColor = System.Drawing.Color.Black;
            this.textBox9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox9.DataField = "BrackerPrice";
            this.textBox9.Height = 0.125F;
            this.textBox9.Left = 9.948333F;
            this.textBox9.Name = "textBox9";
            this.textBox9.Style = "ddo-char-set: 1; font-size: 7pt; font-family: �l�r �S�V�b�N; ";
            this.textBox9.Text = ")";
            this.textBox9.Top = 0.031F;
            this.textBox9.Width = 0.054F;
            // 
            // Gds_GoodsNo
            // 
            this.Gds_GoodsNo.Border.BottomColor = System.Drawing.Color.Black;
            this.Gds_GoodsNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gds_GoodsNo.Border.LeftColor = System.Drawing.Color.Black;
            this.Gds_GoodsNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gds_GoodsNo.Border.RightColor = System.Drawing.Color.Black;
            this.Gds_GoodsNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gds_GoodsNo.Border.TopColor = System.Drawing.Color.Black;
            this.Gds_GoodsNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gds_GoodsNo.DataField = "GoodsNo";
            this.Gds_GoodsNo.Height = 0.15625F;
            this.Gds_GoodsNo.Left = 1.5F;
            this.Gds_GoodsNo.MultiLine = false;
            this.Gds_GoodsNo.Name = "Gds_GoodsNo";
            this.Gds_GoodsNo.OutputFormat = resources.GetString("Gds_GoodsNo.OutputFormat");
            this.Gds_GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: �l�r ����; vertical" +
                "-align: top; ";
            this.Gds_GoodsNo.Text = "123456789012345678901234";
            this.Gds_GoodsNo.Top = 0.03125F;
            this.Gds_GoodsNo.Width = 1.4375F;
            // 
            // Gds_GoodsName
            // 
            this.Gds_GoodsName.Border.BottomColor = System.Drawing.Color.Black;
            this.Gds_GoodsName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gds_GoodsName.Border.LeftColor = System.Drawing.Color.Black;
            this.Gds_GoodsName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gds_GoodsName.Border.RightColor = System.Drawing.Color.Black;
            this.Gds_GoodsName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gds_GoodsName.Border.TopColor = System.Drawing.Color.Black;
            this.Gds_GoodsName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gds_GoodsName.DataField = "GoodsName";
            this.Gds_GoodsName.Height = 0.15625F;
            this.Gds_GoodsName.Left = 2.9375F;
            this.Gds_GoodsName.MultiLine = false;
            this.Gds_GoodsName.Name = "Gds_GoodsName";
            this.Gds_GoodsName.OutputFormat = resources.GetString("Gds_GoodsName.OutputFormat");
            this.Gds_GoodsName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: �l�r ����; vertical" +
                "-align: top; ";
            this.Gds_GoodsName.Text = "1234567890123456789012345678901234567890";
            this.Gds_GoodsName.Top = 0.03125F;
            this.Gds_GoodsName.Width = 2.25F;
            // 
            // PageHeader
            // 
            this.PageHeader.CanShrink = true;
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label3,
            this.tb_PrintDate,
            this.Label2,
            this.tb_PrintPage,
            this.Line1,
            this.tb_PrintTime,
            this.tb_ReportTitle,
            this.tb_HeaderSortOderTitle});
            this.PageHeader.Height = 0.2708333F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            // 
            // Label3
            // 
            this.Label3.Border.BottomColor = System.Drawing.Color.Black;
            this.Label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.LeftColor = System.Drawing.Color.Black;
            this.Label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.RightColor = System.Drawing.Color.Black;
            this.Label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Border.TopColor = System.Drawing.Color.Black;
            this.Label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label3.Height = 0.15625F;
            this.Label3.HyperLink = "";
            this.Label3.Left = 7.9375F;
            this.Label3.MultiLine = false;
            this.Label3.Name = "Label3";
            this.Label3.Style = "ddo-char-set: 1; font-size: 8pt; font-family: �l�r ����; vertical-align: top; ";
            this.Label3.Text = "�쐬���t�F";
            this.Label3.Top = 0.0625F;
            this.Label3.Width = 0.625F;
            // 
            // tb_PrintDate
            // 
            this.tb_PrintDate.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_PrintDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintDate.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_PrintDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintDate.Border.RightColor = System.Drawing.Color.Black;
            this.tb_PrintDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintDate.Border.TopColor = System.Drawing.Color.Black;
            this.tb_PrintDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintDate.CanShrink = true;
            this.tb_PrintDate.Height = 0.15625F;
            this.tb_PrintDate.Left = 8.5F;
            this.tb_PrintDate.MultiLine = false;
            this.tb_PrintDate.Name = "tb_PrintDate";
            this.tb_PrintDate.OutputFormat = resources.GetString("tb_PrintDate.OutputFormat");
            this.tb_PrintDate.Style = "ddo-char-set: 1; font-size: 8pt; font-family: �l�r ����; vertical-align: top; ";
            this.tb_PrintDate.Text = "����17�N11�� 5��";
            this.tb_PrintDate.Top = 0.0625F;
            this.tb_PrintDate.Width = 0.9375F;
            // 
            // Label2
            // 
            this.Label2.Border.BottomColor = System.Drawing.Color.Black;
            this.Label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.LeftColor = System.Drawing.Color.Black;
            this.Label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.RightColor = System.Drawing.Color.Black;
            this.Label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Border.TopColor = System.Drawing.Color.Black;
            this.Label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label2.Height = 0.15625F;
            this.Label2.HyperLink = "";
            this.Label2.Left = 9.9375F;
            this.Label2.MultiLine = false;
            this.Label2.Name = "Label2";
            this.Label2.Style = "ddo-char-set: 1; font-size: 8pt; font-family: �l�r ����; vertical-align: top; ";
            this.Label2.Text = "�y�[�W�F";
            this.Label2.Top = 0.0625F;
            this.Label2.Width = 0.5F;
            // 
            // tb_PrintPage
            // 
            this.tb_PrintPage.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_PrintPage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintPage.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_PrintPage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintPage.Border.RightColor = System.Drawing.Color.Black;
            this.tb_PrintPage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintPage.Border.TopColor = System.Drawing.Color.Black;
            this.tb_PrintPage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintPage.CanShrink = true;
            this.tb_PrintPage.Height = 0.15625F;
            this.tb_PrintPage.Left = 10.4375F;
            this.tb_PrintPage.MultiLine = false;
            this.tb_PrintPage.Name = "tb_PrintPage";
            this.tb_PrintPage.OutputFormat = resources.GetString("tb_PrintPage.OutputFormat");
            this.tb_PrintPage.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: �l�r ����; vertical-" +
                "align: top; ";
            this.tb_PrintPage.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.tb_PrintPage.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.tb_PrintPage.Text = "123";
            this.tb_PrintPage.Top = 0.0625F;
            this.tb_PrintPage.Width = 0.28125F;
            // 
            // Line1
            // 
            this.Line1.Border.BottomColor = System.Drawing.Color.Black;
            this.Line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.LeftColor = System.Drawing.Color.Black;
            this.Line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.RightColor = System.Drawing.Color.Black;
            this.Line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Border.TopColor = System.Drawing.Color.Black;
            this.Line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line1.Height = 0F;
            this.Line1.Left = 0F;
            this.Line1.LineWeight = 3F;
            this.Line1.Name = "Line1";
            this.Line1.Top = 0.2085F;
            this.Line1.Width = 10.8F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 10.8F;
            this.Line1.Y1 = 0.2085F;
            this.Line1.Y2 = 0.2085F;
            // 
            // tb_PrintTime
            // 
            this.tb_PrintTime.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_PrintTime.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintTime.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_PrintTime.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintTime.Border.RightColor = System.Drawing.Color.Black;
            this.tb_PrintTime.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintTime.Border.TopColor = System.Drawing.Color.Black;
            this.tb_PrintTime.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_PrintTime.Height = 0.125F;
            this.tb_PrintTime.Left = 9.4375F;
            this.tb_PrintTime.Name = "tb_PrintTime";
            this.tb_PrintTime.Style = "ddo-char-set: 1; font-size: 8pt; ";
            this.tb_PrintTime.Text = "11��20��";
            this.tb_PrintTime.Top = 0.0625F;
            this.tb_PrintTime.Width = 0.5F;
            // 
            // tb_ReportTitle
            // 
            this.tb_ReportTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_ReportTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_ReportTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_ReportTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_ReportTitle.Border.RightColor = System.Drawing.Color.Black;
            this.tb_ReportTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_ReportTitle.Border.TopColor = System.Drawing.Color.Black;
            this.tb_ReportTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_ReportTitle.Height = 0.21875F;
            this.tb_ReportTitle.HyperLink = "";
            this.tb_ReportTitle.Left = 0.21875F;
            this.tb_ReportTitle.MultiLine = false;
            this.tb_ReportTitle.Name = "tb_ReportTitle";
            this.tb_ReportTitle.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: �l�r ����; vertical-align: middle; ";
            this.tb_ReportTitle.Text = "�݌ɓ��o�Ɋm�F�\";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 2.41F;
            // 
            // tb_HeaderSortOderTitle
            // 
            this.tb_HeaderSortOderTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_HeaderSortOderTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_HeaderSortOderTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_HeaderSortOderTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_HeaderSortOderTitle.Border.RightColor = System.Drawing.Color.Black;
            this.tb_HeaderSortOderTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_HeaderSortOderTitle.Border.TopColor = System.Drawing.Color.Black;
            this.tb_HeaderSortOderTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_HeaderSortOderTitle.Height = 0.156F;
            this.tb_HeaderSortOderTitle.HyperLink = "";
            this.tb_HeaderSortOderTitle.Left = 2.75F;
            this.tb_HeaderSortOderTitle.MultiLine = false;
            this.tb_HeaderSortOderTitle.Name = "tb_HeaderSortOderTitle";
            this.tb_HeaderSortOderTitle.Style = "ddo-char-set: 1; text-align: left; font-weight: normal; font-style: normal; font-" +
                "size: 8pt; font-family: �l�r ����; vertical-align: top; ";
            this.tb_HeaderSortOderTitle.Text = "�\�[�g��:�q�Ɂ��i�ԁ����[�J�[";
            this.tb_HeaderSortOderTitle.Top = 0.06275F;
            this.tb_HeaderSortOderTitle.Width = 2.41F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.2388889F;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
            // 
            // Footer_SubReport
            // 
            this.Footer_SubReport.Border.BottomColor = System.Drawing.Color.Black;
            this.Footer_SubReport.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer_SubReport.Border.LeftColor = System.Drawing.Color.Black;
            this.Footer_SubReport.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer_SubReport.Border.RightColor = System.Drawing.Color.Black;
            this.Footer_SubReport.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer_SubReport.Border.TopColor = System.Drawing.Color.Black;
            this.Footer_SubReport.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer_SubReport.CloseBorder = false;
            this.Footer_SubReport.Height = 0.239F;
            this.Footer_SubReport.Left = 0F;
            this.Footer_SubReport.Name = "Footer_SubReport";
            this.Footer_SubReport.Report = null;
            this.Footer_SubReport.Top = 0F;
            this.Footer_SubReport.Width = 10.8F;
            // 
            // ExtraHeader
            // 
            this.ExtraHeader.CanShrink = true;
            this.ExtraHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Header_SubReport});
            this.ExtraHeader.Height = 1.34375F;
            this.ExtraHeader.Name = "ExtraHeader";
            this.ExtraHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.ExtraHeader.Format += new System.EventHandler(this.ExtraHeader_Format);
            // 
            // Header_SubReport
            // 
            this.Header_SubReport.Border.BottomColor = System.Drawing.Color.Black;
            this.Header_SubReport.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Header_SubReport.Border.LeftColor = System.Drawing.Color.Black;
            this.Header_SubReport.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Header_SubReport.Border.RightColor = System.Drawing.Color.Black;
            this.Header_SubReport.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Header_SubReport.Border.TopColor = System.Drawing.Color.Black;
            this.Header_SubReport.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Header_SubReport.CloseBorder = false;
            this.Header_SubReport.Height = 0.5F;
            this.Header_SubReport.Left = 0F;
            this.Header_SubReport.Name = "Header_SubReport";
            this.Header_SubReport.Report = null;
            this.Header_SubReport.Top = 0F;
            this.Header_SubReport.Width = 10.8F;
            // 
            // ExtraFooter
            // 
            this.ExtraFooter.CanShrink = true;
            this.ExtraFooter.Height = 0F;
            this.ExtraFooter.KeepTogether = true;
            this.ExtraFooter.Name = "ExtraFooter";
            this.ExtraFooter.Visible = false;
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line42,
            this.Lb_SalesUnPrcTaxExcFl,
            this.Lb_StockPrice,
            this.Lb_SalesMoney,
            this.label1,
            this.Lb_WarehouseName,
            this.Lb_MakerName,
            this.Lb_GoodsNo,
            this.Lb_GoodsName,
            this.line2,
            this.Lb_IoGoodsDay,
            this.Lb_AcPaySlipNum,
            this.Lb_AcPaySlipNm,
            this.Lb_AcPayTransNm,
            this.Lb_AcPayOtherParty,
            this.Lb_ShipmentCnt,
            this.Lb_SalesUnitCost,
            this.Lb_ListPriceTaxExcFl,
            this.label4,
            this.label5,
            this.Lb_StockTotal});
            this.TitleHeader.Height = 0.54375F;
            this.TitleHeader.KeepTogether = true;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // Line42
            // 
            this.Line42.Border.BottomColor = System.Drawing.Color.Black;
            this.Line42.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line42.Border.LeftColor = System.Drawing.Color.Black;
            this.Line42.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line42.Border.RightColor = System.Drawing.Color.Black;
            this.Line42.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line42.Border.TopColor = System.Drawing.Color.Black;
            this.Line42.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line42.Height = 0F;
            this.Line42.Left = 0F;
            this.Line42.LineWeight = 2F;
            this.Line42.Name = "Line42";
            this.Line42.Top = 0F;
            this.Line42.Width = 10.8F;
            this.Line42.X1 = 0F;
            this.Line42.X2 = 10.8F;
            this.Line42.Y1 = 0F;
            this.Line42.Y2 = 0F;
            // 
            // Lb_SalesUnPrcTaxExcFl
            // 
            this.Lb_SalesUnPrcTaxExcFl.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_SalesUnPrcTaxExcFl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesUnPrcTaxExcFl.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_SalesUnPrcTaxExcFl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesUnPrcTaxExcFl.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_SalesUnPrcTaxExcFl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesUnPrcTaxExcFl.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_SalesUnPrcTaxExcFl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesUnPrcTaxExcFl.Height = 0.156F;
            this.Lb_SalesUnPrcTaxExcFl.HyperLink = "";
            this.Lb_SalesUnPrcTaxExcFl.Left = 7.846F;
            this.Lb_SalesUnPrcTaxExcFl.MultiLine = false;
            this.Lb_SalesUnPrcTaxExcFl.Name = "Lb_SalesUnPrcTaxExcFl";
            this.Lb_SalesUnPrcTaxExcFl.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: �l�r ����; vertical-align: top; ";
            this.Lb_SalesUnPrcTaxExcFl.Text = "���ɒP��";
            this.Lb_SalesUnPrcTaxExcFl.Top = 0.344F;
            this.Lb_SalesUnPrcTaxExcFl.Width = 0.6875F;
            // 
            // Lb_StockPrice
            // 
            this.Lb_StockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_StockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_StockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_StockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_StockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockPrice.Height = 0.156F;
            this.Lb_StockPrice.HyperLink = "";
            this.Lb_StockPrice.Left = 9.219166F;
            this.Lb_StockPrice.MultiLine = false;
            this.Lb_StockPrice.Name = "Lb_StockPrice";
            this.Lb_StockPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: �l�r ����; vertical-align: top; ";
            this.Lb_StockPrice.Text = "���ɋ��z";
            this.Lb_StockPrice.Top = 0.344F;
            this.Lb_StockPrice.Width = 0.75F;
            // 
            // Lb_SalesMoney
            // 
            this.Lb_SalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_SalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_SalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_SalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_SalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesMoney.Height = 0.156F;
            this.Lb_SalesMoney.HyperLink = "";
            this.Lb_SalesMoney.Left = 10.01083F;
            this.Lb_SalesMoney.MultiLine = false;
            this.Lb_SalesMoney.Name = "Lb_SalesMoney";
            this.Lb_SalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: �l�r ����; vertical-align: top; ";
            this.Lb_SalesMoney.Text = "�o�ɋ��z";
            this.Lb_SalesMoney.Top = 0.344F;
            this.Lb_SalesMoney.Width = 0.75F;
            // 
            // label1
            // 
            this.label1.Border.BottomColor = System.Drawing.Color.Black;
            this.label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.LeftColor = System.Drawing.Color.Black;
            this.label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.RightColor = System.Drawing.Color.Black;
            this.label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Border.TopColor = System.Drawing.Color.Black;
            this.label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label1.Height = 0.156F;
            this.label1.HyperLink = "";
            this.label1.Left = 8.531666F;
            this.label1.MultiLine = false;
            this.label1.Name = "label1";
            this.label1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: �l�r ����; vertical-align: top; ";
            this.label1.Text = "�o�ɒP��";
            this.label1.Top = 0.344F;
            this.label1.Width = 0.6875F;
            // 
            // Lb_WarehouseName
            // 
            this.Lb_WarehouseName.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_WarehouseName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_WarehouseName.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_WarehouseName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_WarehouseName.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_WarehouseName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_WarehouseName.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_WarehouseName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_WarehouseName.Height = 0.15625F;
            this.Lb_WarehouseName.HyperLink = "";
            this.Lb_WarehouseName.Left = 0F;
            this.Lb_WarehouseName.MultiLine = false;
            this.Lb_WarehouseName.Name = "Lb_WarehouseName";
            this.Lb_WarehouseName.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: �l�r ����; vertical-align: top; ";
            this.Lb_WarehouseName.Text = "�q��";
            this.Lb_WarehouseName.Top = 0.031F;
            this.Lb_WarehouseName.Width = 2.625F;
            // 
            // Lb_MakerName
            // 
            this.Lb_MakerName.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_MakerName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MakerName.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_MakerName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MakerName.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_MakerName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MakerName.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_MakerName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_MakerName.Height = 0.15625F;
            this.Lb_MakerName.HyperLink = "";
            this.Lb_MakerName.Left = 0.0625F;
            this.Lb_MakerName.MultiLine = false;
            this.Lb_MakerName.Name = "Lb_MakerName";
            this.Lb_MakerName.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: �l�r ����; vertical-align: top; ";
            this.Lb_MakerName.Text = "���[�J�[";
            this.Lb_MakerName.Top = 0.1875F;
            this.Lb_MakerName.Width = 1.4375F;
            // 
            // Lb_GoodsNo
            // 
            this.Lb_GoodsNo.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_GoodsNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsNo.Height = 0.15625F;
            this.Lb_GoodsNo.HyperLink = "";
            this.Lb_GoodsNo.Left = 1.5F;
            this.Lb_GoodsNo.MultiLine = false;
            this.Lb_GoodsNo.Name = "Lb_GoodsNo";
            this.Lb_GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: �l�r ����; vertical-align: top; ";
            this.Lb_GoodsNo.Text = "�i��";
            this.Lb_GoodsNo.Top = 0.1875F;
            this.Lb_GoodsNo.Width = 1.4375F;
            // 
            // Lb_GoodsName
            // 
            this.Lb_GoodsName.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_GoodsName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsName.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_GoodsName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsName.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_GoodsName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsName.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_GoodsName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_GoodsName.Height = 0.15625F;
            this.Lb_GoodsName.HyperLink = "";
            this.Lb_GoodsName.Left = 2.9375F;
            this.Lb_GoodsName.MultiLine = false;
            this.Lb_GoodsName.Name = "Lb_GoodsName";
            this.Lb_GoodsName.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: �l�r ����; vertical-align: top; ";
            this.Lb_GoodsName.Text = "�i��";
            this.Lb_GoodsName.Top = 0.1875F;
            this.Lb_GoodsName.Width = 2.25F;
            // 
            // line2
            // 
            this.line2.Border.BottomColor = System.Drawing.Color.Black;
            this.line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.LeftColor = System.Drawing.Color.Black;
            this.line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.RightColor = System.Drawing.Color.Black;
            this.line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Border.TopColor = System.Drawing.Color.Black;
            this.line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line2.Height = 0F;
            this.line2.Left = 0F;
            this.line2.LineWeight = 2F;
            this.line2.Name = "line2";
            this.line2.Top = 0.19F;
            this.line2.Width = 10.8F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.8F;
            this.line2.Y1 = 0.19F;
            this.line2.Y2 = 0.19F;
            // 
            // Lb_IoGoodsDay
            // 
            this.Lb_IoGoodsDay.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_IoGoodsDay.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_IoGoodsDay.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_IoGoodsDay.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_IoGoodsDay.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_IoGoodsDay.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_IoGoodsDay.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_IoGoodsDay.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_IoGoodsDay.Height = 0.15625F;
            this.Lb_IoGoodsDay.HyperLink = "";
            this.Lb_IoGoodsDay.Left = 0.125F;
            this.Lb_IoGoodsDay.MultiLine = false;
            this.Lb_IoGoodsDay.Name = "Lb_IoGoodsDay";
            this.Lb_IoGoodsDay.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: �l�r ����; vertical-align: top; ";
            this.Lb_IoGoodsDay.Text = "���o�ד�";
            this.Lb_IoGoodsDay.Top = 0.344F;
            this.Lb_IoGoodsDay.Width = 0.475F;
            // 
            // Lb_AcPaySlipNum
            // 
            this.Lb_AcPaySlipNum.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_AcPaySlipNum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AcPaySlipNum.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_AcPaySlipNum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AcPaySlipNum.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_AcPaySlipNum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AcPaySlipNum.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_AcPaySlipNum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AcPaySlipNum.Height = 0.15625F;
            this.Lb_AcPaySlipNum.HyperLink = "";
            this.Lb_AcPaySlipNum.Left = 1.085333F;
            this.Lb_AcPaySlipNum.MultiLine = false;
            this.Lb_AcPaySlipNum.Name = "Lb_AcPaySlipNum";
            this.Lb_AcPaySlipNum.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: �l�r ����; vertical-align: top; ";
            this.Lb_AcPaySlipNum.Text = "�`�[�ԍ�";
            this.Lb_AcPaySlipNum.Top = 0.344F;
            this.Lb_AcPaySlipNum.Width = 0.5F;
            // 
            // Lb_AcPaySlipNm
            // 
            this.Lb_AcPaySlipNm.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_AcPaySlipNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AcPaySlipNm.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_AcPaySlipNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AcPaySlipNm.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_AcPaySlipNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AcPaySlipNm.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_AcPaySlipNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AcPaySlipNm.Height = 0.15625F;
            this.Lb_AcPaySlipNm.HyperLink = "";
            this.Lb_AcPaySlipNm.Left = 2.100833F;
            this.Lb_AcPaySlipNm.MultiLine = false;
            this.Lb_AcPaySlipNm.Name = "Lb_AcPaySlipNm";
            this.Lb_AcPaySlipNm.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: �l�r ����; vertical-align: top; ";
            this.Lb_AcPaySlipNm.Text = "�`�[�敪";
            this.Lb_AcPaySlipNm.Top = 0.344F;
            this.Lb_AcPaySlipNm.Width = 0.625F;
            // 
            // Lb_AcPayTransNm
            // 
            this.Lb_AcPayTransNm.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_AcPayTransNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AcPayTransNm.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_AcPayTransNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AcPayTransNm.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_AcPayTransNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AcPayTransNm.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_AcPayTransNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AcPayTransNm.Height = 0.15625F;
            this.Lb_AcPayTransNm.HyperLink = "";
            this.Lb_AcPayTransNm.Left = 2.760417F;
            this.Lb_AcPayTransNm.MultiLine = false;
            this.Lb_AcPayTransNm.Name = "Lb_AcPayTransNm";
            this.Lb_AcPayTransNm.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: �l�r ����; vertical-align: top; ";
            this.Lb_AcPayTransNm.Text = "����敪";
            this.Lb_AcPayTransNm.Top = 0.344F;
            this.Lb_AcPayTransNm.Width = 0.5625F;
            // 
            // Lb_AcPayOtherParty
            // 
            this.Lb_AcPayOtherParty.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_AcPayOtherParty.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AcPayOtherParty.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_AcPayOtherParty.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AcPayOtherParty.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_AcPayOtherParty.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AcPayOtherParty.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_AcPayOtherParty.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_AcPayOtherParty.Height = 0.15625F;
            this.Lb_AcPayOtherParty.HyperLink = "";
            this.Lb_AcPayOtherParty.Left = 3.340833F;
            this.Lb_AcPayOtherParty.MultiLine = false;
            this.Lb_AcPayOtherParty.Name = "Lb_AcPayOtherParty";
            this.Lb_AcPayOtherParty.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: �l�r ����; vertical-align: top; ";
            this.Lb_AcPayOtherParty.Text = "���o�ɐ�";
            this.Lb_AcPayOtherParty.Top = 0.344F;
            this.Lb_AcPayOtherParty.Width = 1.56F;
            // 
            // Lb_ShipmentCnt
            // 
            this.Lb_ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ShipmentCnt.Height = 0.15625F;
            this.Lb_ShipmentCnt.HyperLink = "";
            this.Lb_ShipmentCnt.Left = 5.37075F;
            this.Lb_ShipmentCnt.MultiLine = false;
            this.Lb_ShipmentCnt.Name = "Lb_ShipmentCnt";
            this.Lb_ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: �l�r ����; vertical-align: top; ";
            this.Lb_ShipmentCnt.Text = "���ɐ�";
            this.Lb_ShipmentCnt.Top = 0.344F;
            this.Lb_ShipmentCnt.Width = 0.557F;
            // 
            // Lb_SalesUnitCost
            // 
            this.Lb_SalesUnitCost.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_SalesUnitCost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesUnitCost.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_SalesUnitCost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesUnitCost.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_SalesUnitCost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesUnitCost.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_SalesUnitCost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_SalesUnitCost.Height = 0.15625F;
            this.Lb_SalesUnitCost.HyperLink = "";
            this.Lb_SalesUnitCost.Left = 5.9485F;
            this.Lb_SalesUnitCost.MultiLine = false;
            this.Lb_SalesUnitCost.Name = "Lb_SalesUnitCost";
            this.Lb_SalesUnitCost.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: �l�r ����; vertical-align: top; ";
            this.Lb_SalesUnitCost.Text = "�o�ɐ�";
            this.Lb_SalesUnitCost.Top = 0.344F;
            this.Lb_SalesUnitCost.Width = 0.6875F;
            // 
            // Lb_ListPriceTaxExcFl
            // 
            this.Lb_ListPriceTaxExcFl.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_ListPriceTaxExcFl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ListPriceTaxExcFl.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_ListPriceTaxExcFl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ListPriceTaxExcFl.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_ListPriceTaxExcFl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ListPriceTaxExcFl.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_ListPriceTaxExcFl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_ListPriceTaxExcFl.Height = 0.15625F;
            this.Lb_ListPriceTaxExcFl.HyperLink = "";
            this.Lb_ListPriceTaxExcFl.Left = 7.274F;
            this.Lb_ListPriceTaxExcFl.MultiLine = false;
            this.Lb_ListPriceTaxExcFl.Name = "Lb_ListPriceTaxExcFl";
            this.Lb_ListPriceTaxExcFl.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 8pt; font-fam" +
                "ily: �l�r ����; vertical-align: top; ";
            this.Lb_ListPriceTaxExcFl.Text = "�W�����i";
            this.Lb_ListPriceTaxExcFl.Top = 0.34375F;
            this.Lb_ListPriceTaxExcFl.Width = 0.5625F;
            // 
            // label4
            // 
            this.label4.Border.BottomColor = System.Drawing.Color.Black;
            this.label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.LeftColor = System.Drawing.Color.Black;
            this.label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.RightColor = System.Drawing.Color.Black;
            this.label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Border.TopColor = System.Drawing.Color.Black;
            this.label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label4.Height = 0.156F;
            this.label4.HyperLink = null;
            this.label4.Left = 0.6320834F;
            this.label4.Name = "label4";
            this.label4.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label4.Text = "���͓�";
            this.label4.Top = 0.344F;
            this.label4.Width = 0.4F;
            // 
            // label5
            // 
            this.label5.Border.BottomColor = System.Drawing.Color.Black;
            this.label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.LeftColor = System.Drawing.Color.Black;
            this.label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.RightColor = System.Drawing.Color.Black;
            this.label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Border.TopColor = System.Drawing.Color.Black;
            this.label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label5.Height = 0.156F;
            this.label5.HyperLink = null;
            this.label5.Left = 1.640417F;
            this.label5.Name = "label5";
            this.label5.Style = "ddo-char-set: 1; font-weight: bold; font-size: 8pt; ";
            this.label5.Text = "�I��";
            this.label5.Top = 0.344F;
            this.label5.Width = 0.44F;
            // 
            // Lb_StockTotal
            // 
            this.Lb_StockTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.Lb_StockTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.Lb_StockTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockTotal.Border.RightColor = System.Drawing.Color.Black;
            this.Lb_StockTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockTotal.Border.TopColor = System.Drawing.Color.Black;
            this.Lb_StockTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Lb_StockTotal.Height = 0.145F;
            this.Lb_StockTotal.HyperLink = null;
            this.Lb_StockTotal.Left = 5.42775F;
            this.Lb_StockTotal.MultiLine = false;
            this.Lb_StockTotal.Name = "Lb_StockTotal";
            this.Lb_StockTotal.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; ";
            this.Lb_StockTotal.Text = "�O�����c";
            this.Lb_StockTotal.Top = 0.194F;
            this.Lb_StockTotal.Width = 0.5F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanShrink = true;
            this.TitleFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line41});
            this.TitleFooter.Height = 0F;
            this.TitleFooter.KeepTogether = true;
            this.TitleFooter.Name = "TitleFooter";
            this.TitleFooter.Visible = false;
            // 
            // Line41
            // 
            this.Line41.Border.BottomColor = System.Drawing.Color.Black;
            this.Line41.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line41.Border.LeftColor = System.Drawing.Color.Black;
            this.Line41.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line41.Border.RightColor = System.Drawing.Color.Black;
            this.Line41.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line41.Border.TopColor = System.Drawing.Color.Black;
            this.Line41.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line41.Height = 0F;
            this.Line41.Left = 0F;
            this.Line41.LineWeight = 2F;
            this.Line41.Name = "Line41";
            this.Line41.Top = 0F;
            this.Line41.Width = 10.8F;
            this.Line41.X1 = 0F;
            this.Line41.X2 = 10.8F;
            this.Line41.Y1 = 0F;
            this.Line41.Y2 = 0F;
            // 
            // GrandTotalHeader
            // 
            this.GrandTotalHeader.CanShrink = true;
            this.GrandTotalHeader.Height = 0F;
            this.GrandTotalHeader.Name = "GrandTotalHeader";
            this.GrandTotalHeader.Visible = false;
            // 
            // GrandTotalFooter
            // 
            this.GrandTotalFooter.CanShrink = true;
            this.GrandTotalFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line5,
            this.textBox2,
            this.textBox1,
            this.textBox3,
            this.textBox4,
            this.textBox5,
            this.AllCnt});
            this.GrandTotalFooter.Height = 0.3333333F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
            this.GrandTotalFooter.Format += new System.EventHandler(this.GrandTotalFooter_Format);
            // 
            // line5
            // 
            this.line5.Border.BottomColor = System.Drawing.Color.Black;
            this.line5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Border.LeftColor = System.Drawing.Color.Black;
            this.line5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Border.RightColor = System.Drawing.Color.Black;
            this.line5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Border.TopColor = System.Drawing.Color.Black;
            this.line5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line5.Height = 0F;
            this.line5.Left = 0F;
            this.line5.LineWeight = 2F;
            this.line5.Name = "line5";
            this.line5.Top = 0F;
            this.line5.Width = 10.8F;
            this.line5.X1 = 0F;
            this.line5.X2 = 10.8F;
            this.line5.Y1 = 0F;
            this.line5.Y2 = 0F;
            // 
            // textBox2
            // 
            this.textBox2.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.RightColor = System.Drawing.Color.Black;
            this.textBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Border.TopColor = System.Drawing.Color.Black;
            this.textBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox2.Height = 0.1875F;
            this.textBox2.Left = 4.416F;
            this.textBox2.MultiLine = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: �l�r ����; vertical-align: top; ";
            this.textBox2.Text = "�����v";
            this.textBox2.Top = 0.03F;
            this.textBox2.Width = 0.8F;
            // 
            // textBox1
            // 
            this.textBox1.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.RightColor = System.Drawing.Color.Black;
            this.textBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.Border.TopColor = System.Drawing.Color.Black;
            this.textBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox1.DataField = "ArrivalCnt";
            this.textBox1.Height = 0.125F;
            this.textBox1.Left = 5.24025F;
            this.textBox1.MultiLine = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.OutputFormat = resources.GetString("textBox1.OutputFormat");
            this.textBox1.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.textBox1.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox1.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox1.Text = "12,345,678.00";
            this.textBox1.Top = 0.0625F;
            this.textBox1.Width = 0.6875F;
            // 
            // textBox3
            // 
            this.textBox3.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.RightColor = System.Drawing.Color.Black;
            this.textBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.Border.TopColor = System.Drawing.Color.Black;
            this.textBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox3.DataField = "ShipmentCnt";
            this.textBox3.Height = 0.125F;
            this.textBox3.Left = 5.9485F;
            this.textBox3.MultiLine = false;
            this.textBox3.Name = "textBox3";
            this.textBox3.OutputFormat = resources.GetString("textBox3.OutputFormat");
            this.textBox3.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.textBox3.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox3.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox3.Text = "12,345,678.00";
            this.textBox3.Top = 0.0625F;
            this.textBox3.Width = 0.6875F;
            // 
            // textBox4
            // 
            this.textBox4.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.RightColor = System.Drawing.Color.Black;
            this.textBox4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.Border.TopColor = System.Drawing.Color.Black;
            this.textBox4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox4.DataField = "StockPrice";
            this.textBox4.Height = 0.125F;
            this.textBox4.Left = 9.219166F;
            this.textBox4.MultiLine = false;
            this.textBox4.Name = "textBox4";
            this.textBox4.OutputFormat = resources.GetString("textBox4.OutputFormat");
            this.textBox4.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.textBox4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox4.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox4.Text = "12,345,678,901";
            this.textBox4.Top = 0.0625F;
            this.textBox4.Width = 0.75F;
            // 
            // textBox5
            // 
            this.textBox5.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.RightColor = System.Drawing.Color.Black;
            this.textBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.Border.TopColor = System.Drawing.Color.Black;
            this.textBox5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox5.DataField = "SalesMoney";
            this.textBox5.Height = 0.125F;
            this.textBox5.Left = 10.01083F;
            this.textBox5.MultiLine = false;
            this.textBox5.Name = "textBox5";
            this.textBox5.OutputFormat = resources.GetString("textBox5.OutputFormat");
            this.textBox5.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.textBox5.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.textBox5.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.textBox5.Text = "12,345,678,901";
            this.textBox5.Top = 0.0625F;
            this.textBox5.Width = 0.75F;
            // 
            // AllCnt
            // 
            this.AllCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.AllCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AllCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.AllCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AllCnt.Border.RightColor = System.Drawing.Color.Black;
            this.AllCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AllCnt.Border.TopColor = System.Drawing.Color.Black;
            this.AllCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AllCnt.Height = 0.125F;
            this.AllCnt.Left = 6.643F;
            this.AllCnt.MultiLine = false;
            this.AllCnt.Name = "AllCnt";
            this.AllCnt.OutputFormat = resources.GetString("AllCnt.OutputFormat");
            this.AllCnt.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: �l�r �S�V�b�N; ";
            this.AllCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.AllCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal;
            this.AllCnt.Text = "12,345,678.00111";
            this.AllCnt.Top = 0.063F;
            this.AllCnt.Width = 0.81F;
            // 
            // WarehouseHeader
            // 
            this.WarehouseHeader.CanShrink = true;
            this.WarehouseHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line3,
            this.Wh_WarehouseName,
            this.Wh_WarehouseCode});
            this.WarehouseHeader.DataField = "WarehouseCode";
            this.WarehouseHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.WarehouseHeader.Height = 0.21875F;
            this.WarehouseHeader.KeepTogether = true;
            this.WarehouseHeader.Name = "WarehouseHeader";
            this.WarehouseHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.WarehouseHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            this.WarehouseHeader.Format += new System.EventHandler(this.WarehouseHeader_Format);
            // 
            // line3
            // 
            this.line3.Border.BottomColor = System.Drawing.Color.Black;
            this.line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.LeftColor = System.Drawing.Color.Black;
            this.line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.RightColor = System.Drawing.Color.Black;
            this.line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Border.TopColor = System.Drawing.Color.Black;
            this.line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line3.Height = 0F;
            this.line3.Left = 0F;
            this.line3.LineWeight = 2F;
            this.line3.Name = "line3";
            this.line3.Top = 0F;
            this.line3.Width = 10.8F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.8F;
            this.line3.Y1 = 0F;
            this.line3.Y2 = 0F;
            // 
            // Wh_WarehouseName
            // 
            this.Wh_WarehouseName.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_WarehouseName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_WarehouseName.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_WarehouseName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_WarehouseName.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_WarehouseName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_WarehouseName.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_WarehouseName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_WarehouseName.DataField = "WarehouseName";
            this.Wh_WarehouseName.Height = 0.15625F;
            this.Wh_WarehouseName.Left = 0.3125F;
            this.Wh_WarehouseName.MultiLine = false;
            this.Wh_WarehouseName.Name = "Wh_WarehouseName";
            this.Wh_WarehouseName.OutputFormat = resources.GetString("Wh_WarehouseName.OutputFormat");
            this.Wh_WarehouseName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: �l�r ����; vertical" +
                "-align: top; ";
            this.Wh_WarehouseName.Text = "�����������������������������������Ă�";
            this.Wh_WarehouseName.Top = 0.03125F;
            this.Wh_WarehouseName.Width = 2.3125F;
            // 
            // Wh_WarehouseCode
            // 
            this.Wh_WarehouseCode.Border.BottomColor = System.Drawing.Color.Black;
            this.Wh_WarehouseCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_WarehouseCode.Border.LeftColor = System.Drawing.Color.Black;
            this.Wh_WarehouseCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_WarehouseCode.Border.RightColor = System.Drawing.Color.Black;
            this.Wh_WarehouseCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_WarehouseCode.Border.TopColor = System.Drawing.Color.Black;
            this.Wh_WarehouseCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Wh_WarehouseCode.DataField = "WarehouseCode";
            this.Wh_WarehouseCode.Height = 0.15625F;
            this.Wh_WarehouseCode.Left = 0F;
            this.Wh_WarehouseCode.MultiLine = false;
            this.Wh_WarehouseCode.Name = "Wh_WarehouseCode";
            this.Wh_WarehouseCode.OutputFormat = resources.GetString("Wh_WarehouseCode.OutputFormat");
            this.Wh_WarehouseCode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: �l�r �S�V�b�N; vertic" +
                "al-align: top; ";
            this.Wh_WarehouseCode.Text = "1234";
            this.Wh_WarehouseCode.Top = 0.03125F;
            this.Wh_WarehouseCode.Width = 0.3125F;
            // 
            // WarehouseFooter
            // 
            this.WarehouseFooter.CanShrink = true;
            this.WarehouseFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line6,
            this.textBox60,
            this.WhArrivalCnt,
            this.WhShipmentCnt,
            this.WhStockPrice,
            this.WhSalesMoney,
            this.WhCnt});
            this.WarehouseFooter.Height = 0.3333333F;
            this.WarehouseFooter.KeepTogether = true;
            this.WarehouseFooter.Name = "WarehouseFooter";
            this.WarehouseFooter.Format += new System.EventHandler(this.WarehouseFooter_Format);
            // 
            // line6
            // 
            this.line6.Border.BottomColor = System.Drawing.Color.Black;
            this.line6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Border.LeftColor = System.Drawing.Color.Black;
            this.line6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Border.RightColor = System.Drawing.Color.Black;
            this.line6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Border.TopColor = System.Drawing.Color.Black;
            this.line6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line6.Height = 0F;
            this.line6.Left = 0F;
            this.line6.LineWeight = 2F;
            this.line6.Name = "line6";
            this.line6.Top = 0F;
            this.line6.Width = 10.8F;
            this.line6.X1 = 0F;
            this.line6.X2 = 10.8F;
            this.line6.Y1 = 0F;
            this.line6.Y2 = 0F;
            // 
            // textBox60
            // 
            this.textBox60.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox60.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox60.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox60.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox60.Border.RightColor = System.Drawing.Color.Black;
            this.textBox60.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox60.Border.TopColor = System.Drawing.Color.Black;
            this.textBox60.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox60.Height = 0.1875F;
            this.textBox60.Left = 4.416F;
            this.textBox60.MultiLine = false;
            this.textBox60.Name = "textBox60";
            this.textBox60.OutputFormat = resources.GetString("textBox60.OutputFormat");
            this.textBox60.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: �l�r ����; vertical-align: top; ";
            this.textBox60.Text = "�q�Ɍv";
            this.textBox60.Top = 0.03F;
            this.textBox60.Width = 0.8F;
            // 
            // WhArrivalCnt
            // 
            this.WhArrivalCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.WhArrivalCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WhArrivalCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.WhArrivalCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WhArrivalCnt.Border.RightColor = System.Drawing.Color.Black;
            this.WhArrivalCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WhArrivalCnt.Border.TopColor = System.Drawing.Color.Black;
            this.WhArrivalCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WhArrivalCnt.DataField = "ArrivalCnt";
            this.WhArrivalCnt.Height = 0.125F;
            this.WhArrivalCnt.Left = 5.24025F;
            this.WhArrivalCnt.MultiLine = false;
            this.WhArrivalCnt.Name = "WhArrivalCnt";
            this.WhArrivalCnt.OutputFormat = resources.GetString("WhArrivalCnt.OutputFormat");
            this.WhArrivalCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.WhArrivalCnt.SummaryGroup = "WarehouseHeader";
            this.WhArrivalCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.WhArrivalCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.WhArrivalCnt.Text = "12,345,678.00";
            this.WhArrivalCnt.Top = 0.0625F;
            this.WhArrivalCnt.Width = 0.6875F;
            // 
            // WhShipmentCnt
            // 
            this.WhShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.WhShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WhShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.WhShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WhShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.WhShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WhShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.WhShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WhShipmentCnt.DataField = "ShipmentCnt";
            this.WhShipmentCnt.Height = 0.125F;
            this.WhShipmentCnt.Left = 5.9485F;
            this.WhShipmentCnt.MultiLine = false;
            this.WhShipmentCnt.Name = "WhShipmentCnt";
            this.WhShipmentCnt.OutputFormat = resources.GetString("WhShipmentCnt.OutputFormat");
            this.WhShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.WhShipmentCnt.SummaryGroup = "WarehouseHeader";
            this.WhShipmentCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.WhShipmentCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.WhShipmentCnt.Text = "12,345,678.00";
            this.WhShipmentCnt.Top = 0.0625F;
            this.WhShipmentCnt.Width = 0.6875F;
            // 
            // WhStockPrice
            // 
            this.WhStockPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.WhStockPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WhStockPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.WhStockPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WhStockPrice.Border.RightColor = System.Drawing.Color.Black;
            this.WhStockPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WhStockPrice.Border.TopColor = System.Drawing.Color.Black;
            this.WhStockPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WhStockPrice.DataField = "StockPrice";
            this.WhStockPrice.Height = 0.125F;
            this.WhStockPrice.Left = 9.219166F;
            this.WhStockPrice.MultiLine = false;
            this.WhStockPrice.Name = "WhStockPrice";
            this.WhStockPrice.OutputFormat = resources.GetString("WhStockPrice.OutputFormat");
            this.WhStockPrice.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.WhStockPrice.SummaryGroup = "WarehouseHeader";
            this.WhStockPrice.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.WhStockPrice.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.WhStockPrice.Text = "12,345,678,901";
            this.WhStockPrice.Top = 0.0625F;
            this.WhStockPrice.Width = 0.75F;
            // 
            // WhSalesMoney
            // 
            this.WhSalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.WhSalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WhSalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.WhSalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WhSalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.WhSalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WhSalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.WhSalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WhSalesMoney.DataField = "SalesMoney";
            this.WhSalesMoney.Height = 0.125F;
            this.WhSalesMoney.Left = 10.01083F;
            this.WhSalesMoney.MultiLine = false;
            this.WhSalesMoney.Name = "WhSalesMoney";
            this.WhSalesMoney.OutputFormat = resources.GetString("WhSalesMoney.OutputFormat");
            this.WhSalesMoney.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.WhSalesMoney.SummaryGroup = "WarehouseHeader";
            this.WhSalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.WhSalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.WhSalesMoney.Text = "12,345,678,901";
            this.WhSalesMoney.Top = 0.0625F;
            this.WhSalesMoney.Width = 0.75F;
            // 
            // WhCnt
            // 
            this.WhCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.WhCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WhCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.WhCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WhCnt.Border.RightColor = System.Drawing.Color.Black;
            this.WhCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WhCnt.Border.TopColor = System.Drawing.Color.Black;
            this.WhCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.WhCnt.Height = 0.125F;
            this.WhCnt.Left = 6.643F;
            this.WhCnt.MultiLine = false;
            this.WhCnt.Name = "WhCnt";
            this.WhCnt.OutputFormat = resources.GetString("WhCnt.OutputFormat");
            this.WhCnt.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: �l�r �S�V�b�N; ";
            this.WhCnt.SummaryGroup = "WarehouseHeader";
            this.WhCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.WhCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.WhCnt.Text = "12,345,678.00";
            this.WhCnt.Top = 0.0625F;
            this.WhCnt.Width = 0.81F;
            // 
            // GoodsHeader
            // 
            this.GoodsHeader.CanShrink = true;
            this.GoodsHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line4,
            this.Gds_GoodsMakerCd,
            this.Gds_MakerName,
            this.Gds_GoodsNo,
            this.Gds_GoodsName,
            this.Gds_StockTotal});
            this.GoodsHeader.DataField = "GoodsNoMaker";
            this.GoodsHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.GoodsHeader.Height = 0.2291667F;
            this.GoodsHeader.KeepTogether = true;
            this.GoodsHeader.Name = "GoodsHeader";
            this.GoodsHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // line4
            // 
            this.line4.Border.BottomColor = System.Drawing.Color.Black;
            this.line4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Border.LeftColor = System.Drawing.Color.Black;
            this.line4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Border.RightColor = System.Drawing.Color.Black;
            this.line4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Border.TopColor = System.Drawing.Color.Black;
            this.line4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line4.Height = 0F;
            this.line4.Left = 0F;
            this.line4.LineWeight = 2F;
            this.line4.Name = "line4";
            this.line4.Top = 0F;
            this.line4.Width = 10.8F;
            this.line4.X1 = 0F;
            this.line4.X2 = 10.8F;
            this.line4.Y1 = 0F;
            this.line4.Y2 = 0F;
            // 
            // Gds_GoodsMakerCd
            // 
            this.Gds_GoodsMakerCd.Border.BottomColor = System.Drawing.Color.Black;
            this.Gds_GoodsMakerCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gds_GoodsMakerCd.Border.LeftColor = System.Drawing.Color.Black;
            this.Gds_GoodsMakerCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gds_GoodsMakerCd.Border.RightColor = System.Drawing.Color.Black;
            this.Gds_GoodsMakerCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gds_GoodsMakerCd.Border.TopColor = System.Drawing.Color.Black;
            this.Gds_GoodsMakerCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gds_GoodsMakerCd.DataField = "GoodsMakerCd";
            this.Gds_GoodsMakerCd.Height = 0.15625F;
            this.Gds_GoodsMakerCd.Left = 0.0625F;
            this.Gds_GoodsMakerCd.MultiLine = false;
            this.Gds_GoodsMakerCd.Name = "Gds_GoodsMakerCd";
            this.Gds_GoodsMakerCd.OutputFormat = resources.GetString("Gds_GoodsMakerCd.OutputFormat");
            this.Gds_GoodsMakerCd.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: �l�r �S�V�b�N; vertic" +
                "al-align: top; ";
            this.Gds_GoodsMakerCd.Text = "1234";
            this.Gds_GoodsMakerCd.Top = 0.03125F;
            this.Gds_GoodsMakerCd.Width = 0.3125F;
            // 
            // Gds_MakerName
            // 
            this.Gds_MakerName.Border.BottomColor = System.Drawing.Color.Black;
            this.Gds_MakerName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gds_MakerName.Border.LeftColor = System.Drawing.Color.Black;
            this.Gds_MakerName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gds_MakerName.Border.RightColor = System.Drawing.Color.Black;
            this.Gds_MakerName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gds_MakerName.Border.TopColor = System.Drawing.Color.Black;
            this.Gds_MakerName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gds_MakerName.DataField = "MakerName";
            this.Gds_MakerName.Height = 0.15625F;
            this.Gds_MakerName.Left = 0.375F;
            this.Gds_MakerName.MultiLine = false;
            this.Gds_MakerName.Name = "Gds_MakerName";
            this.Gds_MakerName.OutputFormat = resources.GetString("Gds_MakerName.OutputFormat");
            this.Gds_MakerName.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: �l�r ����; vertical" +
                "-align: top; ";
            this.Gds_MakerName.Text = "��������������������";
            this.Gds_MakerName.Top = 0.03125F;
            this.Gds_MakerName.Width = 1.125F;
            // 
            // Gds_StockTotal
            // 
            this.Gds_StockTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.Gds_StockTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gds_StockTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.Gds_StockTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gds_StockTotal.Border.RightColor = System.Drawing.Color.Black;
            this.Gds_StockTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gds_StockTotal.Border.TopColor = System.Drawing.Color.Black;
            this.Gds_StockTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gds_StockTotal.DataField = "StockTotal";
            this.Gds_StockTotal.Height = 0.156F;
            this.Gds_StockTotal.Left = 5.25975F;
            this.Gds_StockTotal.MultiLine = false;
            this.Gds_StockTotal.Name = "Gds_StockTotal";
            this.Gds_StockTotal.OutputFormat = resources.GetString("Gds_StockTotal.OutputFormat");
            this.Gds_StockTotal.Style = "ddo-char-set: 1; text-align: right; font-size: 7pt; font-family: �l�r �S�V�b�N; ";
            this.Gds_StockTotal.Text = "11.123,456.00";
            this.Gds_StockTotal.Top = 0.03125F;
            this.Gds_StockTotal.Width = 0.668F;
            // 
            // GoodsFooter
            // 
            this.GoodsFooter.CanShrink = true;
            this.GoodsFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Gds_ArrivalCnt,
            this.Gds_ShipmentCnt,
            this.textBox11,
            this.Gds_Cnt,
            this.textBox15,
            this.textBox17,
            this.line8});
            this.GoodsFooter.Height = 0.3541667F;
            this.GoodsFooter.KeepTogether = true;
            this.GoodsFooter.Name = "GoodsFooter";
            this.GoodsFooter.Visible = false;
            this.GoodsFooter.Format += new System.EventHandler(this.GoodsFooter_Format);
            // 
            // Gds_ArrivalCnt
            // 
            this.Gds_ArrivalCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Gds_ArrivalCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gds_ArrivalCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Gds_ArrivalCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gds_ArrivalCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Gds_ArrivalCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gds_ArrivalCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Gds_ArrivalCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gds_ArrivalCnt.DataField = "ArrivalCnt";
            this.Gds_ArrivalCnt.Height = 0.125F;
            this.Gds_ArrivalCnt.Left = 5.24025F;
            this.Gds_ArrivalCnt.MultiLine = false;
            this.Gds_ArrivalCnt.Name = "Gds_ArrivalCnt";
            this.Gds_ArrivalCnt.OutputFormat = resources.GetString("Gds_ArrivalCnt.OutputFormat");
            this.Gds_ArrivalCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.Gds_ArrivalCnt.SummaryGroup = "GoodsHeader";
            this.Gds_ArrivalCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gds_ArrivalCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gds_ArrivalCnt.Text = "12,345,678.00";
            this.Gds_ArrivalCnt.Top = 0.0625F;
            this.Gds_ArrivalCnt.Width = 0.6875F;
            // 
            // Gds_ShipmentCnt
            // 
            this.Gds_ShipmentCnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Gds_ShipmentCnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gds_ShipmentCnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Gds_ShipmentCnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gds_ShipmentCnt.Border.RightColor = System.Drawing.Color.Black;
            this.Gds_ShipmentCnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gds_ShipmentCnt.Border.TopColor = System.Drawing.Color.Black;
            this.Gds_ShipmentCnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gds_ShipmentCnt.DataField = "ShipmentCnt";
            this.Gds_ShipmentCnt.Height = 0.125F;
            this.Gds_ShipmentCnt.Left = 5.9485F;
            this.Gds_ShipmentCnt.MultiLine = false;
            this.Gds_ShipmentCnt.Name = "Gds_ShipmentCnt";
            this.Gds_ShipmentCnt.OutputFormat = resources.GetString("Gds_ShipmentCnt.OutputFormat");
            this.Gds_ShipmentCnt.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.Gds_ShipmentCnt.SummaryGroup = "GoodsHeader";
            this.Gds_ShipmentCnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gds_ShipmentCnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gds_ShipmentCnt.Text = "12,345,678.00";
            this.Gds_ShipmentCnt.Top = 0.0625F;
            this.Gds_ShipmentCnt.Width = 0.6875F;
            // 
            // textBox11
            // 
            this.textBox11.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox11.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox11.Border.RightColor = System.Drawing.Color.Black;
            this.textBox11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox11.Border.TopColor = System.Drawing.Color.Black;
            this.textBox11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox11.Height = 0.1875F;
            this.textBox11.Left = 4.416F;
            this.textBox11.MultiLine = false;
            this.textBox11.Name = "textBox11";
            this.textBox11.OutputFormat = resources.GetString("textBox11.OutputFormat");
            this.textBox11.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: �l�r ����; vertical-align: top; ";
            this.textBox11.Text = "��  �v";
            this.textBox11.Top = 0.03F;
            this.textBox11.Width = 0.8F;
            // 
            // Gds_Cnt
            // 
            this.Gds_Cnt.Border.BottomColor = System.Drawing.Color.Black;
            this.Gds_Cnt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gds_Cnt.Border.LeftColor = System.Drawing.Color.Black;
            this.Gds_Cnt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gds_Cnt.Border.RightColor = System.Drawing.Color.Black;
            this.Gds_Cnt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gds_Cnt.Border.TopColor = System.Drawing.Color.Black;
            this.Gds_Cnt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Gds_Cnt.Height = 0.125F;
            this.Gds_Cnt.Left = 6.643F;
            this.Gds_Cnt.MultiLine = false;
            this.Gds_Cnt.Name = "Gds_Cnt";
            this.Gds_Cnt.OutputFormat = resources.GetString("Gds_Cnt.OutputFormat");
            this.Gds_Cnt.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 7pt; font-famil" +
                "y: �l�r �S�V�b�N; ";
            this.Gds_Cnt.SummaryGroup = "GoodsHeader";
            this.Gds_Cnt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Gds_Cnt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Gds_Cnt.Text = "12,345,678.00";
            this.Gds_Cnt.Top = 0.0625F;
            this.Gds_Cnt.Width = 0.81F;
            // 
            // textBox15
            // 
            this.textBox15.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox15.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox15.Border.RightColor = System.Drawing.Color.Black;
            this.textBox15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox15.Border.TopColor = System.Drawing.Color.Black;
            this.textBox15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox15.DataField = "StockPrice";
            this.textBox15.Height = 0.125F;
            this.textBox15.Left = 9.219166F;
            this.textBox15.MultiLine = false;
            this.textBox15.Name = "textBox15";
            this.textBox15.OutputFormat = resources.GetString("textBox15.OutputFormat");
            this.textBox15.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.textBox15.SummaryGroup = "GoodsHeader";
            this.textBox15.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox15.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox15.Text = "12,345,678,901";
            this.textBox15.Top = 0.0625F;
            this.textBox15.Width = 0.75F;
            // 
            // textBox17
            // 
            this.textBox17.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox17.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox17.Border.RightColor = System.Drawing.Color.Black;
            this.textBox17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox17.Border.TopColor = System.Drawing.Color.Black;
            this.textBox17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox17.DataField = "SalesMoney";
            this.textBox17.Height = 0.125F;
            this.textBox17.Left = 10.01083F;
            this.textBox17.MultiLine = false;
            this.textBox17.Name = "textBox17";
            this.textBox17.OutputFormat = resources.GetString("textBox17.OutputFormat");
            this.textBox17.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.textBox17.SummaryGroup = "GoodsHeader";
            this.textBox17.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox17.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox17.Text = "12,345,678,901";
            this.textBox17.Top = 0.0625F;
            this.textBox17.Width = 0.75F;
            // 
            // line8
            // 
            this.line8.Border.BottomColor = System.Drawing.Color.Black;
            this.line8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line8.Border.LeftColor = System.Drawing.Color.Black;
            this.line8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line8.Border.RightColor = System.Drawing.Color.Black;
            this.line8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line8.Border.TopColor = System.Drawing.Color.Black;
            this.line8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line8.Height = 0F;
            this.line8.Left = 0F;
            this.line8.LineWeight = 2F;
            this.line8.Name = "line8";
            this.line8.Top = 0F;
            this.line8.Width = 10.8F;
            this.line8.X1 = 0F;
            this.line8.X2 = 10.8F;
            this.line8.Y1 = 0F;
            this.line8.Y2 = 0F;
            // 
            // MakerHeader
            // 
            this.MakerHeader.DataField = "GoodsMakerCd";
            this.MakerHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail;
            this.MakerHeader.Height = 0F;
            this.MakerHeader.Name = "MakerHeader";
            this.MakerHeader.Tag = "�����[�J�[�E���i�Ńu���C�N������ׁA���[�J�[�O���[�v��ݒ肵�܂�";
            // 
            // MakerFooter
            // 
            this.MakerFooter.Height = 0F;
            this.MakerFooter.Name = "MakerFooter";
            // 
            // DCZAI02202P_01A4C
            // 
            this.MasterReport = false;
            this.PageSettings.DefaultPaperSize = false;
            this.PageSettings.Margins.Bottom = 0.2F;
            this.PageSettings.Margins.Left = 0.2F;
            this.PageSettings.Margins.Right = 0.2F;
            this.PageSettings.Margins.Top = 0.2F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
            this.PageSettings.PaperHeight = 11.69291F;
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.PageSettings.PaperWidth = 8.268056F;
            this.PrintWidth = 10.8125F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.WarehouseHeader);
            this.Sections.Add(this.MakerHeader);
            this.Sections.Add(this.GoodsHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.GoodsFooter);
            this.Sections.Add(this.MakerFooter);
            this.Sections.Add(this.WarehouseFooter);
            this.Sections.Add(this.GrandTotalFooter);
            this.Sections.Add(this.TitleFooter);
            this.Sections.Add(this.ExtraFooter);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            this.PageEnd += new System.EventHandler(this.DCZAI02103P_01A4C_PageEnd);
            this.ReportStart += new System.EventHandler(this.DCZAI02103P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.ListPriceTaxExcFl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ArrivalCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcPaySlipNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcPaySlipNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sl_SalesDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcPayOtherPartyNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcPayOtherPartyCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcPayTransNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockUnitPriceFl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcPaySlipCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesUnPrcTaxExcFl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sl_AcPayHistDateTimeView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sl_ShelfNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gds_GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gds_GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_HeaderSortOderTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalesUnPrcTaxExcFl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_StockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_WarehouseName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_MakerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_IoGoodsDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AcPaySlipNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AcPaySlipNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AcPayTransNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_AcPayOtherParty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_SalesUnitCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_ListPriceTaxExcFl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lb_StockTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AllCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_WarehouseName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wh_WarehouseCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox60)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WhArrivalCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WhShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WhStockPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WhSalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WhCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gds_GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gds_MakerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gds_StockTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gds_ArrivalCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gds_ShipmentCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gds_Cnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

        //--- ADD 2008/07/02 ---------->>>>>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WarehouseHeader_Format(object sender, EventArgs e)
        {
            /* ---DEL 2009/04/07 �s��Ή�[12997] ------------------------------>>>>>
            // ����(���_)
            if (this._stockAcPayListCndtn.ChangePage == 0)
            {
                if (this._beforeSectionCode == null)
                {
                    this._beforeSectionCode = this.Wh_SectionCode.Text;
                    this.WarehouseHeader.NewPage = NewPage.Before;
                }
                else if (this._beforeSectionCode == this.Wh_SectionCode.Text)
                {
                    this.WarehouseHeader.NewPage = NewPage.None;
                }
                else
                {
                    this._beforeSectionCode = this.Wh_SectionCode.Text;
                    this.WarehouseHeader.NewPage = NewPage.Before;
                }
            }
            // ����(�q��)
            else if (this._stockAcPayListCndtn.ChangePage == 1)
            {
                this.WarehouseHeader.NewPage = NewPage.Before;
            }
            // ����(���Ȃ�)
            else if (this._stockAcPayListCndtn.ChangePage == 2)
            {
                this.WarehouseHeader.NewPage = NewPage.None;
            }
               ---DEL 2009/04/07 �s��Ή�[12997] ------------------------------<<<<< */
            // ---ADD 2009/04/07 �s��Ή�[12997] ------------------------------>>>>>
            // ����(�q��)
            if (this._stockAcPayListCndtn.ChangePage == 1)
            {
                this.WarehouseHeader.NewPage = NewPage.Before;
            }
            // ����(���Ȃ�)
            else if (this._stockAcPayListCndtn.ChangePage == 2)
            {
                this.WarehouseHeader.NewPage = NewPage.None;
            }
            // ---ADD 2009/04/07 �s��Ή�[12997] ------------------------------<<<<<
        }

        // ---ADD 2010/11/15 ------------------------>>>>>
        /// <summary>
        /// ���v�\���ݒ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoodsFooter_Format(object sender, EventArgs e)
        {
            string gds_ArrivalCnt = this.Gds_ArrivalCnt.Text;
            gds_ArrivalCnt = gds_ArrivalCnt.Replace(",", "");

            string gds_ShipmentCnt = this.Gds_ShipmentCnt.Text;
            gds_ShipmentCnt = gds_ShipmentCnt.Replace(",", "");
            this.Gds_Cnt.Text = "(" + (double.Parse(gds_ArrivalCnt) - double.Parse(gds_ShipmentCnt)).ToString("#,##0.00") + ")";
        }

        /// <summary>
        /// �q�ɕ\���ݒ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WarehouseFooter_Format(object sender, EventArgs e)
        {
            string whArrivalCnt = this.WhArrivalCnt.Text;
            whArrivalCnt = whArrivalCnt.Replace(",", "");

            string whShipmentCnt = this.WhShipmentCnt.Text;
            whShipmentCnt = whShipmentCnt.Replace(",", "");

            this.WhCnt.Text = "(" + (double.Parse(whArrivalCnt) - double.Parse(whShipmentCnt)).ToString("#,##0.00") + ")";
        }

        /// <summary>
        /// �����v�\���ݒ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrandTotalFooter_Format(object sender, EventArgs e)
        {
            string arrivalCnt = this.textBox1.Text;
            arrivalCnt = arrivalCnt.Replace(",", "");

            string shipmentCnt = this.textBox3.Text;
            shipmentCnt = shipmentCnt.Replace(",", "");

            this.AllCnt.Text = "(" + (double.Parse(arrivalCnt) - double.Parse(shipmentCnt)).ToString("#,##0.00") + ")";

        }
        // ---ADD 2010/11/15 ------------------------<<<<<

        //--- ADD 2008/07/02 ---------->>>>>
    }
}
