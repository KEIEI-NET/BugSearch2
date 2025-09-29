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

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// �d����ϯ�ؽĈ���t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �d����ϯ�ؽẴt�H�[���N���X�ł��B</br>
    /// <br>Programmer	: 30413 ����</br>
    /// <br>Date		: 2008.12.17</br>
    /// <br></br>
    /// </remarks>
    public class PMUOE02074P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
    {
        #region �� Constructor
		/// <summary>
        /// �d����ϯ�ؽăt�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note		: �d����ϯ�ؽăt�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2008.12.17</br>
        /// </remarks>
        public PMUOE02074P_01A4C()
		{
            InitializeComponent();
		}
		#endregion �� Constructor
                
        #region �� Private Member
        private int _printCount;									// ��������p�J�E���^

        private string _pageHeaderSortOderTitle;		            // �\�[�g��
        private int _extraCondHeadOutDiv;			                // ���o�����w�b�_�o�͋敪
        private StringCollection _extraConditions;				    // ���o����
        private int _pageFooterOutCode;				                // �t�b�^�[�o�͋敪
        private StringCollection _pageFooters;					    // �t�b�^�[���b�Z�[�W
        private SFCMN06002C _printInfo;						        // ������N���X
        private string _pageHeaderSubtitle;			                // �t�H�[���T�u�^�C�g��
        private ArrayList _otherDataList;					        // ���̑��f�[�^
        private SupplierUnmOrderCndtn _supplierUnmOrderCndtn;		// ���o�����N���X
        
        private DataSet _outputDs;						            // ����pDataSet

        private const string ct_CollectTable = SupplierUnmResult.Col_Tbl_Result_SupplierUnm;    // �d����ϯ�ؽăe�[�u������

        // �w�b�_�[�T�u���|�[�g�錾
        ListCommon_ExtraHeader _rptExtraHeader = null;
        // �t�b�^�[���|�[�g�錾
        ListCommon_PageFooter _rptPageFooter = null;
        private PageHeader PageHeader;
        private PageFooter PageFooter;
        private GroupHeader ExtraHeader;
        private GroupFooter ExtraFooter;
        private GroupHeader TitleHeader;
        private GroupFooter TitleFooter;
        private Label tb_ReportTitle;
        private Label Label3;
        private TextBox tb_PrintDate;
        private Label Label2;
        private TextBox tb_PrintPage;
        private Line Line1;
        private TextBox tb_PrintTime;
        private SubReport Header_SubReport;
        private GroupHeader SectionHeader;
        private GroupFooter SectionFooter;
        private Detail Detail;
        private Label SupplierCd_Title;
        private Label AnswerListPrice_Title;
        private Label AnswerSalesUnitCost_Title;
        private Label UOESalesOrderNo_Title;
        private Label GoodsNo_Title;
        private Label QTY_Title;
        private Label BoCode_Title;
        private Label SystemDivCd_Print_Title;
        private Label Contents_Title;
        private Label SalesDate_Title;
        private TextBox SectionCode;
        private TextBox SectionGuideSnm;
        private TextBox GoodsNo;
        private TextBox GoodsName;
        private TextBox SupplierCd;
        private TextBox QTY;
        private TextBox BoCode;
        private TextBox AnswerListPrice;
        private TextBox AnswerSalesUnitCost;
        private TextBox UOESalesOrderNo;
        private TextBox SystemDivCd_Print;
        private TextBox Contents;
        private TextBox SalesDate_Print;
        private Label GoodsName_Title;
        private Line line2;
        private Line line3;
        private SubReport Footer_SubReport;
        private TextBox SupplierSnm;


        // Dispose�`�F�b�N�p�t���O
        bool disposed = false;
        #endregion �� Private Member

        #region �� Dispose(override)
        /// <summary>
        /// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                try
                {
                    if (disposing)
                    {
                        // �w�b�_�p�T�u���|�[�g�㏈�����s
                        if (this._rptExtraHeader != null)
                        {
                            this._rptExtraHeader.Dispose();
                        }

                        // �t�b�^�p�T�u���|�[�g�㏈�����s
                        if (this._rptPageFooter != null)
                        {
                            this._rptPageFooter.Dispose();
                        }
                    }

                    this.disposed = true;
                }
                finally
                {
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
                this._supplierUnmOrderCndtn = (SupplierUnmOrderCndtn)this._printInfo.jyoken;
                this._outputDs = (DataSet)this._printInfo.rdData;
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
                    ;
                }
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
                return 0;
            }
            set
            {
                
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
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2008.12.17</br>
        /// </remarks>
        private void SetOfReportMembersOutput()
        {
            this._printCount = 0;

            // ���ڂ̖��̂��Z�b�g
            tb_ReportTitle.Text = this._pageHeaderSubtitle;		   // �T�u�^�C�g��
            
        }
        #endregion �� ���|�[�g�v�f�o�͐ݒ�

        #endregion

        #region �� Control Event

        #region �� PMUOE02074P_01A4C_ReportStart Event
        /// <summary>
        /// PMUOE02074P_01A4C_ReportStart Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���|�[�g�J�n���̃C�x���g�ł��B</br>
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2008.12.17</br>
        /// </remarks>
        private void PMUOE02074P_01A4C_ReportStart(object sender, EventArgs e)
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
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2008.12.17</br>
        /// </remarks>
        private void PageHeader_Format(object sender, System.EventArgs eArgs)
        {
            // �쐬���t
            this.tb_PrintDate.Text = TDateTime.DateTimeToString("YYYY/MM/DD", DateTime.Now);
            // �쐬����
            this.tb_PrintTime.Text = DateTime.Now.ToString("HH:mm");
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
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2008.12.17</br>
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

            // ���_�̈�
            this._rptExtraHeader.SectionCondition.Text = "���_�F" + this.SectionCode.Value + " " + this.SectionGuideSnm.Text;            

            // ���o�����󎚍��ڐݒ�
            this._rptExtraHeader.ExtraConditions = this._extraConditions;

            this.Header_SubReport.Report = this._rptExtraHeader;
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
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2008.12.17</br>
        /// </remarks>
        private void Detail_BeforePrint(object sender, System.EventArgs eArgs)
        {
            // Wordrap�v���p�e�B�ŕ��������r���[�ȂƂ���ŋ�؂��Ȃ��悤�ɂ��邽�߂̑Ή�
            PrintCommonLibrary.ConvertReportString(this.Detail);
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
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2008.12.17</br>
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

        #region �� PageFooter_Format Event
        /// <summary>
        /// PageFooter_Format Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="eArgs">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: PageFooter�O���[�v�̃t�H�[�}�b�g�C�x���g�B</br>
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2008.12.17</br>
        /// </remarks>
        private void PageFooter_Format(object sender, System.EventArgs eArgs)
        {
            // �t�b�^�[�o�͂���H
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

        
        #endregion �� Control Event

        #region ActiveReports Designer generated code
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PMUOE02074P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.GoodsNo = new DataDynamics.ActiveReports.TextBox();
            this.GoodsName = new DataDynamics.ActiveReports.TextBox();
            this.SupplierCd = new DataDynamics.ActiveReports.TextBox();
            this.QTY = new DataDynamics.ActiveReports.TextBox();
            this.BoCode = new DataDynamics.ActiveReports.TextBox();
            this.AnswerListPrice = new DataDynamics.ActiveReports.TextBox();
            this.AnswerSalesUnitCost = new DataDynamics.ActiveReports.TextBox();
            this.UOESalesOrderNo = new DataDynamics.ActiveReports.TextBox();
            this.SystemDivCd_Print = new DataDynamics.ActiveReports.TextBox();
            this.Contents = new DataDynamics.ActiveReports.TextBox();
            this.SalesDate_Print = new DataDynamics.ActiveReports.TextBox();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.SupplierSnm = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SupplierCd_Title = new DataDynamics.ActiveReports.Label();
            this.AnswerListPrice_Title = new DataDynamics.ActiveReports.Label();
            this.AnswerSalesUnitCost_Title = new DataDynamics.ActiveReports.Label();
            this.UOESalesOrderNo_Title = new DataDynamics.ActiveReports.Label();
            this.GoodsNo_Title = new DataDynamics.ActiveReports.Label();
            this.QTY_Title = new DataDynamics.ActiveReports.Label();
            this.BoCode_Title = new DataDynamics.ActiveReports.Label();
            this.SystemDivCd_Print_Title = new DataDynamics.ActiveReports.Label();
            this.Contents_Title = new DataDynamics.ActiveReports.Label();
            this.SalesDate_Title = new DataDynamics.ActiveReports.Label();
            this.GoodsName_Title = new DataDynamics.ActiveReports.Label();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SectionCode = new DataDynamics.ActiveReports.TextBox();
            this.SectionGuideSnm = new DataDynamics.ActiveReports.TextBox();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QTY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerListPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerSalesUnitCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESalesOrderNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SystemDivCd_Print)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Contents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesDate_Print)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerListPrice_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerSalesUnitCost_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESalesOrderNo_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QTY_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoCode_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SystemDivCd_Print_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Contents_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesDate_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.GoodsNo,
            this.GoodsName,
            this.SupplierCd,
            this.QTY,
            this.BoCode,
            this.AnswerListPrice,
            this.AnswerSalesUnitCost,
            this.UOESalesOrderNo,
            this.SystemDivCd_Print,
            this.Contents,
            this.SalesDate_Print,
            this.line2,
            this.SupplierSnm});
            this.Detail.Height = 0.2708333F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // GoodsNo
            // 
            this.GoodsNo.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo.DataField = "GoodsNo";
            this.GoodsNo.Height = 0.125F;
            this.GoodsNo.Left = 3.25F;
            this.GoodsNo.MultiLine = false;
            this.GoodsNo.Name = "GoodsNo";
            this.GoodsNo.OutputFormat = resources.GetString("GoodsNo.OutputFormat");
            this.GoodsNo.Style = "ddo-char-set: 128; text-align: left; font-size: 7.5pt; font-family: �l�r ����; vertic" +
                "al-align: top; ";
            this.GoodsNo.Text = "123456789012345678901234";
            this.GoodsNo.Top = 0F;
            this.GoodsNo.Width = 1.3125F;
            // 
            // GoodsName
            // 
            this.GoodsName.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName.DataField = "GoodsName";
            this.GoodsName.Height = 0.125F;
            this.GoodsName.Left = 4.625F;
            this.GoodsName.MultiLine = false;
            this.GoodsName.Name = "GoodsName";
            this.GoodsName.OutputFormat = resources.GetString("GoodsName.OutputFormat");
            this.GoodsName.Style = "ddo-char-set: 128; text-align: left; font-size: 7.5pt; font-family: �l�r ����; vertic" +
                "al-align: top; ";
            this.GoodsName.Text = "��������������������";
            this.GoodsName.Top = 0F;
            this.GoodsName.Width = 1.125F;
            // 
            // SupplierCd
            // 
            this.SupplierCd.Border.BottomColor = System.Drawing.Color.Black;
            this.SupplierCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd.Border.LeftColor = System.Drawing.Color.Black;
            this.SupplierCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd.Border.RightColor = System.Drawing.Color.Black;
            this.SupplierCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd.Border.TopColor = System.Drawing.Color.Black;
            this.SupplierCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd.DataField = "SupplierCd";
            this.SupplierCd.Height = 0.125F;
            this.SupplierCd.Left = 0F;
            this.SupplierCd.MultiLine = false;
            this.SupplierCd.Name = "SupplierCd";
            this.SupplierCd.OutputFormat = resources.GetString("SupplierCd.OutputFormat");
            this.SupplierCd.Style = "ddo-char-set: 128; text-align: left; font-size: 7.5pt; font-family: �l�r �S�V�b�N; vert" +
                "ical-align: top; ";
            this.SupplierCd.Text = "123456";
            this.SupplierCd.Top = 0F;
            this.SupplierCd.Width = 0.375F;
            // 
            // QTY
            // 
            this.QTY.Border.BottomColor = System.Drawing.Color.Black;
            this.QTY.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.QTY.Border.LeftColor = System.Drawing.Color.Black;
            this.QTY.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.QTY.Border.RightColor = System.Drawing.Color.Black;
            this.QTY.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.QTY.Border.TopColor = System.Drawing.Color.Black;
            this.QTY.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.QTY.DataField = "QTY";
            this.QTY.Height = 0.125F;
            this.QTY.Left = 5.8125F;
            this.QTY.MultiLine = false;
            this.QTY.Name = "QTY";
            this.QTY.OutputFormat = resources.GetString("QTY.OutputFormat");
            this.QTY.Style = "ddo-char-set: 128; text-align: right; font-size: 7.5pt; font-family: �l�r �S�V�b�N; ver" +
                "tical-align: top; ";
            this.QTY.Text = "12,345";
            this.QTY.Top = 0F;
            this.QTY.Width = 0.375F;
            // 
            // BoCode
            // 
            this.BoCode.Border.BottomColor = System.Drawing.Color.Black;
            this.BoCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BoCode.Border.LeftColor = System.Drawing.Color.Black;
            this.BoCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BoCode.Border.RightColor = System.Drawing.Color.Black;
            this.BoCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BoCode.Border.TopColor = System.Drawing.Color.Black;
            this.BoCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BoCode.DataField = "BoCode";
            this.BoCode.Height = 0.125F;
            this.BoCode.Left = 6.25F;
            this.BoCode.MultiLine = false;
            this.BoCode.Name = "BoCode";
            this.BoCode.OutputFormat = resources.GetString("BoCode.OutputFormat");
            this.BoCode.Style = "ddo-char-set: 128; text-align: right; font-size: 7.5pt; font-family: �l�r ����; verti" +
                "cal-align: top; ";
            this.BoCode.Text = "X";
            this.BoCode.Top = 0F;
            this.BoCode.Width = 0.1875F;
            // 
            // AnswerListPrice
            // 
            this.AnswerListPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.AnswerListPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerListPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.AnswerListPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerListPrice.Border.RightColor = System.Drawing.Color.Black;
            this.AnswerListPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerListPrice.Border.TopColor = System.Drawing.Color.Black;
            this.AnswerListPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerListPrice.DataField = "AnswerListPrice";
            this.AnswerListPrice.Height = 0.125F;
            this.AnswerListPrice.Left = 6.5F;
            this.AnswerListPrice.MultiLine = false;
            this.AnswerListPrice.Name = "AnswerListPrice";
            this.AnswerListPrice.OutputFormat = resources.GetString("AnswerListPrice.OutputFormat");
            this.AnswerListPrice.Style = "ddo-char-set: 128; text-align: right; font-size: 7.5pt; font-family: �l�r �S�V�b�N; ver" +
                "tical-align: top; ";
            this.AnswerListPrice.Text = "1,234,567,890";
            this.AnswerListPrice.Top = 0F;
            this.AnswerListPrice.Width = 0.75F;
            // 
            // AnswerSalesUnitCost
            // 
            this.AnswerSalesUnitCost.Border.BottomColor = System.Drawing.Color.Black;
            this.AnswerSalesUnitCost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerSalesUnitCost.Border.LeftColor = System.Drawing.Color.Black;
            this.AnswerSalesUnitCost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerSalesUnitCost.Border.RightColor = System.Drawing.Color.Black;
            this.AnswerSalesUnitCost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerSalesUnitCost.Border.TopColor = System.Drawing.Color.Black;
            this.AnswerSalesUnitCost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerSalesUnitCost.DataField = "AnswerSalesUnitCost";
            this.AnswerSalesUnitCost.Height = 0.125F;
            this.AnswerSalesUnitCost.Left = 7.3125F;
            this.AnswerSalesUnitCost.MultiLine = false;
            this.AnswerSalesUnitCost.Name = "AnswerSalesUnitCost";
            this.AnswerSalesUnitCost.OutputFormat = resources.GetString("AnswerSalesUnitCost.OutputFormat");
            this.AnswerSalesUnitCost.Style = "ddo-char-set: 128; text-align: right; font-size: 7.5pt; font-family: �l�r �S�V�b�N; ver" +
                "tical-align: top; ";
            this.AnswerSalesUnitCost.Text = "1,234,567,890.00";
            this.AnswerSalesUnitCost.Top = 0F;
            this.AnswerSalesUnitCost.Width = 0.9375F;
            // 
            // UOESalesOrderNo
            // 
            this.UOESalesOrderNo.Border.BottomColor = System.Drawing.Color.Black;
            this.UOESalesOrderNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESalesOrderNo.Border.LeftColor = System.Drawing.Color.Black;
            this.UOESalesOrderNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESalesOrderNo.Border.RightColor = System.Drawing.Color.Black;
            this.UOESalesOrderNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESalesOrderNo.Border.TopColor = System.Drawing.Color.Black;
            this.UOESalesOrderNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESalesOrderNo.DataField = "UOESalesOrderNo";
            this.UOESalesOrderNo.Height = 0.125F;
            this.UOESalesOrderNo.Left = 8.3125F;
            this.UOESalesOrderNo.MultiLine = false;
            this.UOESalesOrderNo.Name = "UOESalesOrderNo";
            this.UOESalesOrderNo.OutputFormat = resources.GetString("UOESalesOrderNo.OutputFormat");
            this.UOESalesOrderNo.Style = "ddo-char-set: 128; text-align: right; font-size: 7.5pt; font-family: �l�r �S�V�b�N; ver" +
                "tical-align: top; ";
            this.UOESalesOrderNo.Text = "123456";
            this.UOESalesOrderNo.Top = 0F;
            this.UOESalesOrderNo.Width = 0.5F;
            // 
            // SystemDivCd_Print
            // 
            this.SystemDivCd_Print.Border.BottomColor = System.Drawing.Color.Black;
            this.SystemDivCd_Print.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SystemDivCd_Print.Border.LeftColor = System.Drawing.Color.Black;
            this.SystemDivCd_Print.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SystemDivCd_Print.Border.RightColor = System.Drawing.Color.Black;
            this.SystemDivCd_Print.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SystemDivCd_Print.Border.TopColor = System.Drawing.Color.Black;
            this.SystemDivCd_Print.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SystemDivCd_Print.DataField = "SystemDivCd_Print";
            this.SystemDivCd_Print.Height = 0.125F;
            this.SystemDivCd_Print.Left = 8.875F;
            this.SystemDivCd_Print.MultiLine = false;
            this.SystemDivCd_Print.Name = "SystemDivCd_Print";
            this.SystemDivCd_Print.OutputFormat = resources.GetString("SystemDivCd_Print.OutputFormat");
            this.SystemDivCd_Print.Style = "ddo-char-set: 128; text-align: left; font-size: 7.5pt; font-family: �l�r ����; vertic" +
                "al-align: top; ";
            this.SystemDivCd_Print.Text = "�m�m�m";
            this.SystemDivCd_Print.Top = 0F;
            this.SystemDivCd_Print.Width = 0.5F;
            // 
            // Contents
            // 
            this.Contents.Border.BottomColor = System.Drawing.Color.Black;
            this.Contents.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Contents.Border.LeftColor = System.Drawing.Color.Black;
            this.Contents.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Contents.Border.RightColor = System.Drawing.Color.Black;
            this.Contents.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Contents.Border.TopColor = System.Drawing.Color.Black;
            this.Contents.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Contents.DataField = "Contents";
            this.Contents.Height = 0.125F;
            this.Contents.Left = 9.4375F;
            this.Contents.MultiLine = false;
            this.Contents.Name = "Contents";
            this.Contents.OutputFormat = resources.GetString("Contents.OutputFormat");
            this.Contents.Style = "ddo-char-set: 128; text-align: left; font-size: 7.5pt; font-family: �l�r ����; vertic" +
                "al-align: top; ";
            this.Contents.Text = "�`�[�ԍ����ݒ�(Ұ��̫۰)";
            this.Contents.Top = 0F;
            this.Contents.Width = 1.3125F;
            // 
            // SalesDate_Print
            // 
            this.SalesDate_Print.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesDate_Print.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesDate_Print.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesDate_Print.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesDate_Print.Border.RightColor = System.Drawing.Color.Black;
            this.SalesDate_Print.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesDate_Print.Border.TopColor = System.Drawing.Color.Black;
            this.SalesDate_Print.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesDate_Print.DataField = "SalesDate_Print";
            this.SalesDate_Print.Height = 0.125F;
            this.SalesDate_Print.Left = 2.625F;
            this.SalesDate_Print.MultiLine = false;
            this.SalesDate_Print.Name = "SalesDate_Print";
            this.SalesDate_Print.OutputFormat = resources.GetString("SalesDate_Print.OutputFormat");
            this.SalesDate_Print.Style = "ddo-char-set: 128; text-align: left; font-size: 7.5pt; font-family: �l�r ����; vertic" +
                "al-align: top; ";
            this.SalesDate_Print.Text = "9999/99/99";
            this.SalesDate_Print.Top = 0F;
            this.SalesDate_Print.Width = 0.5625F;
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
            this.line2.LineWeight = 1F;
            this.line2.Name = "line2";
            this.line2.Top = 0F;
            this.line2.Width = 10.8F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.8F;
            this.line2.Y1 = 0F;
            this.line2.Y2 = 0F;
            // 
            // SupplierSnm
            // 
            this.SupplierSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.SupplierSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.SupplierSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierSnm.Border.RightColor = System.Drawing.Color.Black;
            this.SupplierSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierSnm.Border.TopColor = System.Drawing.Color.Black;
            this.SupplierSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierSnm.DataField = "SupplierSnm";
            this.SupplierSnm.Height = 0.125F;
            this.SupplierSnm.Left = 0.4375F;
            this.SupplierSnm.MultiLine = false;
            this.SupplierSnm.Name = "SupplierSnm";
            this.SupplierSnm.OutputFormat = resources.GetString("SupplierSnm.OutputFormat");
            this.SupplierSnm.Style = "ddo-char-set: 128; text-align: left; font-size: 7.5pt; font-family: �l�r ����; vertic" +
                "al-align: top; ";
            this.SupplierSnm.Text = "�����������������������������������Ă�";
            this.SupplierSnm.Top = 0F;
            this.SupplierSnm.Width = 2.125F;
            // 
            // PageHeader
            // 
            this.PageHeader.CanShrink = true;
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.tb_ReportTitle,
            this.Label3,
            this.tb_PrintDate,
            this.Label2,
            this.tb_PrintPage,
            this.Line1,
            this.tb_PrintTime});
            this.PageHeader.Height = 0.2916667F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
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
            this.tb_ReportTitle.Height = 0.25F;
            this.tb_ReportTitle.HyperLink = "";
            this.tb_ReportTitle.Left = 0.25F;
            this.tb_ReportTitle.MultiLine = false;
            this.tb_ReportTitle.Name = "tb_ReportTitle";
            this.tb_ReportTitle.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: �l�r ����; vertical-align: middle; ";
            this.tb_ReportTitle.Text = "�d���A���}�b�`���X�g";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 2.75F;
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
            this.tb_PrintTime.Style = "ddo-char-set: 1; font-size: 8pt; font-family: �l�r ����; ";
            this.tb_PrintTime.Text = "11��20��";
            this.tb_PrintTime.Top = 0.0625F;
            this.tb_PrintTime.Width = 0.5F;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.2395833F;
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
            this.ExtraHeader.Height = 0.1979167F;
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
            this.Header_SubReport.Height = 0.1875F;
            this.Header_SubReport.Left = 0F;
            this.Header_SubReport.Name = "Header_SubReport";
            this.Header_SubReport.Report = null;
            this.Header_SubReport.Top = 0F;
            this.Header_SubReport.Width = 10.8125F;
            // 
            // ExtraFooter
            // 
            this.ExtraFooter.Height = 0F;
            this.ExtraFooter.Name = "ExtraFooter";
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SupplierCd_Title,
            this.AnswerListPrice_Title,
            this.AnswerSalesUnitCost_Title,
            this.UOESalesOrderNo_Title,
            this.GoodsNo_Title,
            this.QTY_Title,
            this.BoCode_Title,
            this.SystemDivCd_Print_Title,
            this.Contents_Title,
            this.SalesDate_Title,
            this.GoodsName_Title,
            this.line3});
            this.TitleHeader.Height = 0.28125F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // SupplierCd_Title
            // 
            this.SupplierCd_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.SupplierCd_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.SupplierCd_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd_Title.Border.RightColor = System.Drawing.Color.Black;
            this.SupplierCd_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd_Title.Border.TopColor = System.Drawing.Color.Black;
            this.SupplierCd_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SupplierCd_Title.Height = 0.125F;
            this.SupplierCd_Title.HyperLink = "";
            this.SupplierCd_Title.Left = 0F;
            this.SupplierCd_Title.MultiLine = false;
            this.SupplierCd_Title.Name = "SupplierCd_Title";
            this.SupplierCd_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7.5pt; font-fa" +
                "mily: �l�r ����; vertical-align: top; ";
            this.SupplierCd_Title.Text = "�d����";
            this.SupplierCd_Title.Top = 0F;
            this.SupplierCd_Title.Width = 0.375F;
            // 
            // AnswerListPrice_Title
            // 
            this.AnswerListPrice_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.AnswerListPrice_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerListPrice_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.AnswerListPrice_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerListPrice_Title.Border.RightColor = System.Drawing.Color.Black;
            this.AnswerListPrice_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerListPrice_Title.Border.TopColor = System.Drawing.Color.Black;
            this.AnswerListPrice_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerListPrice_Title.Height = 0.125F;
            this.AnswerListPrice_Title.HyperLink = "";
            this.AnswerListPrice_Title.Left = 6.5F;
            this.AnswerListPrice_Title.MultiLine = false;
            this.AnswerListPrice_Title.Name = "AnswerListPrice_Title";
            this.AnswerListPrice_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.5pt; font-f" +
                "amily: �l�r ����; vertical-align: top; ";
            this.AnswerListPrice_Title.Text = "�W�����i";
            this.AnswerListPrice_Title.Top = 0F;
            this.AnswerListPrice_Title.Width = 0.75F;
            // 
            // AnswerSalesUnitCost_Title
            // 
            this.AnswerSalesUnitCost_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.AnswerSalesUnitCost_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerSalesUnitCost_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.AnswerSalesUnitCost_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerSalesUnitCost_Title.Border.RightColor = System.Drawing.Color.Black;
            this.AnswerSalesUnitCost_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerSalesUnitCost_Title.Border.TopColor = System.Drawing.Color.Black;
            this.AnswerSalesUnitCost_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AnswerSalesUnitCost_Title.Height = 0.125F;
            this.AnswerSalesUnitCost_Title.HyperLink = "";
            this.AnswerSalesUnitCost_Title.Left = 7.3125F;
            this.AnswerSalesUnitCost_Title.MultiLine = false;
            this.AnswerSalesUnitCost_Title.Name = "AnswerSalesUnitCost_Title";
            this.AnswerSalesUnitCost_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.5pt; font-f" +
                "amily: �l�r ����; vertical-align: top; ";
            this.AnswerSalesUnitCost_Title.Text = "���P��";
            this.AnswerSalesUnitCost_Title.Top = 0F;
            this.AnswerSalesUnitCost_Title.Width = 0.9375F;
            // 
            // UOESalesOrderNo_Title
            // 
            this.UOESalesOrderNo_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.UOESalesOrderNo_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESalesOrderNo_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.UOESalesOrderNo_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESalesOrderNo_Title.Border.RightColor = System.Drawing.Color.Black;
            this.UOESalesOrderNo_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESalesOrderNo_Title.Border.TopColor = System.Drawing.Color.Black;
            this.UOESalesOrderNo_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.UOESalesOrderNo_Title.Height = 0.125F;
            this.UOESalesOrderNo_Title.HyperLink = "";
            this.UOESalesOrderNo_Title.Left = 8.3125F;
            this.UOESalesOrderNo_Title.MultiLine = false;
            this.UOESalesOrderNo_Title.Name = "UOESalesOrderNo_Title";
            this.UOESalesOrderNo_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.5pt; font-f" +
                "amily: �l�r ����; vertical-align: top; ";
            this.UOESalesOrderNo_Title.Text = "�����ԍ�";
            this.UOESalesOrderNo_Title.Top = 0F;
            this.UOESalesOrderNo_Title.Width = 0.5F;
            // 
            // GoodsNo_Title
            // 
            this.GoodsNo_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsNo_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsNo_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_Title.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsNo_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_Title.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsNo_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsNo_Title.Height = 0.125F;
            this.GoodsNo_Title.HyperLink = "";
            this.GoodsNo_Title.Left = 3.25F;
            this.GoodsNo_Title.MultiLine = false;
            this.GoodsNo_Title.Name = "GoodsNo_Title";
            this.GoodsNo_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7.5pt; font-fa" +
                "mily: �l�r ����; vertical-align: top; ";
            this.GoodsNo_Title.Text = "�i��";
            this.GoodsNo_Title.Top = 0F;
            this.GoodsNo_Title.Width = 0.4375F;
            // 
            // QTY_Title
            // 
            this.QTY_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.QTY_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.QTY_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.QTY_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.QTY_Title.Border.RightColor = System.Drawing.Color.Black;
            this.QTY_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.QTY_Title.Border.TopColor = System.Drawing.Color.Black;
            this.QTY_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.QTY_Title.Height = 0.125F;
            this.QTY_Title.HyperLink = "";
            this.QTY_Title.Left = 5.8125F;
            this.QTY_Title.MultiLine = false;
            this.QTY_Title.Name = "QTY_Title";
            this.QTY_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.5pt; font-f" +
                "amily: �l�r ����; vertical-align: top; ";
            this.QTY_Title.Text = "����";
            this.QTY_Title.Top = 0F;
            this.QTY_Title.Width = 0.375F;
            // 
            // BoCode_Title
            // 
            this.BoCode_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.BoCode_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BoCode_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.BoCode_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BoCode_Title.Border.RightColor = System.Drawing.Color.Black;
            this.BoCode_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BoCode_Title.Border.TopColor = System.Drawing.Color.Black;
            this.BoCode_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BoCode_Title.Height = 0.125F;
            this.BoCode_Title.HyperLink = "";
            this.BoCode_Title.Left = 6.25F;
            this.BoCode_Title.MultiLine = false;
            this.BoCode_Title.Name = "BoCode_Title";
            this.BoCode_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7.5pt; font-f" +
                "amily: �l�r ����; vertical-align: top; ";
            this.BoCode_Title.Text = "BO";
            this.BoCode_Title.Top = 0F;
            this.BoCode_Title.Width = 0.1875F;
            // 
            // SystemDivCd_Print_Title
            // 
            this.SystemDivCd_Print_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.SystemDivCd_Print_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SystemDivCd_Print_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.SystemDivCd_Print_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SystemDivCd_Print_Title.Border.RightColor = System.Drawing.Color.Black;
            this.SystemDivCd_Print_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SystemDivCd_Print_Title.Border.TopColor = System.Drawing.Color.Black;
            this.SystemDivCd_Print_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SystemDivCd_Print_Title.Height = 0.125F;
            this.SystemDivCd_Print_Title.HyperLink = "";
            this.SystemDivCd_Print_Title.Left = 8.875F;
            this.SystemDivCd_Print_Title.MultiLine = false;
            this.SystemDivCd_Print_Title.Name = "SystemDivCd_Print_Title";
            this.SystemDivCd_Print_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7.5pt; font-fa" +
                "mily: �l�r ����; vertical-align: top; ";
            this.SystemDivCd_Print_Title.Text = "���ы敪";
            this.SystemDivCd_Print_Title.Top = 0F;
            this.SystemDivCd_Print_Title.Width = 0.5F;
            // 
            // Contents_Title
            // 
            this.Contents_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.Contents_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Contents_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.Contents_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Contents_Title.Border.RightColor = System.Drawing.Color.Black;
            this.Contents_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Contents_Title.Border.TopColor = System.Drawing.Color.Black;
            this.Contents_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Contents_Title.Height = 0.125F;
            this.Contents_Title.HyperLink = "";
            this.Contents_Title.Left = 9.4375F;
            this.Contents_Title.MultiLine = false;
            this.Contents_Title.Name = "Contents_Title";
            this.Contents_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7.5pt; font-fa" +
                "mily: �l�r ����; vertical-align: top; ";
            this.Contents_Title.Text = "���e";
            this.Contents_Title.Top = 0F;
            this.Contents_Title.Width = 0.4375F;
            // 
            // SalesDate_Title
            // 
            this.SalesDate_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesDate_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesDate_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesDate_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesDate_Title.Border.RightColor = System.Drawing.Color.Black;
            this.SalesDate_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesDate_Title.Border.TopColor = System.Drawing.Color.Black;
            this.SalesDate_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesDate_Title.Height = 0.125F;
            this.SalesDate_Title.HyperLink = "";
            this.SalesDate_Title.Left = 2.625F;
            this.SalesDate_Title.MultiLine = false;
            this.SalesDate_Title.Name = "SalesDate_Title";
            this.SalesDate_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7.5pt; font-fa" +
                "mily: �l�r ����; vertical-align: top; ";
            this.SalesDate_Title.Text = "������";
            this.SalesDate_Title.Top = 0F;
            this.SalesDate_Title.Width = 0.5625F;
            // 
            // GoodsName_Title
            // 
            this.GoodsName_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsName_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsName_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_Title.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsName_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_Title.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsName_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsName_Title.Height = 0.125F;
            this.GoodsName_Title.HyperLink = "";
            this.GoodsName_Title.Left = 4.625F;
            this.GoodsName_Title.MultiLine = false;
            this.GoodsName_Title.Name = "GoodsName_Title";
            this.GoodsName_Title.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7.5pt; font-fa" +
                "mily: �l�r ����; vertical-align: top; ";
            this.GoodsName_Title.Text = "�i��";
            this.GoodsName_Title.Top = 0F;
            this.GoodsName_Title.Width = 0.4375F;
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
            this.line3.LineWeight = 1F;
            this.line3.Name = "line3";
            this.line3.Top = 0F;
            this.line3.Width = 10.8F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.8F;
            this.line3.Y1 = 0F;
            this.line3.Y2 = 0F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.Height = 0F;
            this.TitleFooter.Name = "TitleFooter";
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SectionCode,
            this.SectionGuideSnm});
            this.SectionHeader.DataField = "SectionCode";
            this.SectionHeader.Height = 0.15625F;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.SectionHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // SectionCode
            // 
            this.SectionCode.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode.Border.RightColor = System.Drawing.Color.Black;
            this.SectionCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode.Border.TopColor = System.Drawing.Color.Black;
            this.SectionCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionCode.DataField = "SectionCode";
            this.SectionCode.Height = 0.125F;
            this.SectionCode.Left = 0F;
            this.SectionCode.MultiLine = false;
            this.SectionCode.Name = "SectionCode";
            this.SectionCode.OutputFormat = resources.GetString("SectionCode.OutputFormat");
            this.SectionCode.Style = "ddo-char-set: 128; text-align: left; font-size: 7.5pt; font-family: �l�r �S�V�b�N; vert" +
                "ical-align: top; ";
            this.SectionCode.Text = "00";
            this.SectionCode.Top = 0F;
            this.SectionCode.Visible = false;
            this.SectionCode.Width = 0.1875F;
            // 
            // SectionGuideSnm
            // 
            this.SectionGuideSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.SectionGuideSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.SectionGuideSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideSnm.Border.RightColor = System.Drawing.Color.Black;
            this.SectionGuideSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideSnm.Border.TopColor = System.Drawing.Color.Black;
            this.SectionGuideSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SectionGuideSnm.DataField = "SectionGuideSnm";
            this.SectionGuideSnm.Height = 0.125F;
            this.SectionGuideSnm.Left = 0.25F;
            this.SectionGuideSnm.MultiLine = false;
            this.SectionGuideSnm.Name = "SectionGuideSnm";
            this.SectionGuideSnm.Style = "text-align: left; font-size: 7.5pt; font-family: �l�r ����; vertical-align: top; ";
            this.SectionGuideSnm.Text = "���_�R�S�T�U�V�W�X�O";
            this.SectionGuideSnm.Top = 0F;
            this.SectionGuideSnm.Visible = false;
            this.SectionGuideSnm.Width = 1.125F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Height = 0F;
            this.SectionFooter.Name = "SectionFooter";
            // 
            // PMUOE02074P_01A4C
            // 
            this.MasterReport = false;
            this.PageSettings.Margins.Bottom = 0.2F;
            this.PageSettings.Margins.Left = 0.2F;
            this.PageSettings.Margins.Right = 0.2F;
            this.PageSettings.Margins.Top = 0.2F;
            this.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape;
            this.PageSettings.PaperHeight = 11.69F;
            this.PageSettings.PaperWidth = 8.27F;
            this.PrintWidth = 10.8F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.SectionFooter);
            this.Sections.Add(this.TitleFooter);
            this.Sections.Add(this.ExtraFooter);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" +
                        "l; font-size: 10pt; color: Black; ddo-char-set: 204; ", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" +
                        "lic; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.PMUOE02074P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QTY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerListPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerSalesUnitCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESalesOrderNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SystemDivCd_Print)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Contents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesDate_Print)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerListPrice_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AnswerSalesUnitCost_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESalesOrderNo_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsNo_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QTY_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoCode_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SystemDivCd_Print_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Contents_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesDate_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsName_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionGuideSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion
    }
}
