using System;
using System.Collections;
using System.Data;
using System.Collections.Specialized;
using DataDynamics.ActiveReports;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Drawing.Printing;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Text;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// ���Ӑ挳���t�H�[������N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���Ӑ挳���̈�����s���܂��B</br>
	/// <br>Programmer : 20081 �D�c �E�l</br>
	/// <br>Date       : 2007.11.14</br>
    /// <br>Programmer : 30009 �a�J ���</br>
    /// <br>Date       : 2009.01.21</br>
    /// <br>Note       : PM.NS�p�ɏC��</br>
    /// <br>Note       : ��DC��PM�ŕύX���K�v�ȕ����̂ݏC�����܂����B��</br>
    /// <br>Note       : ��PM�ŕs�v�ȏ����������Ă���肪�Ȃ���΂��̂܂܂ɂ��Ă���܂���</br>
    /// <br>Update Note: 2009/03/09 30452 ��� �r��</br>
    /// <br>            �E�t�H�[�}�b�g�C��</br>
    /// <br>UpdateNote : 2015/09/21 �c�v�t</br>
    /// <br>�Ǘ��ԍ�   : 11170168-00</br>
    /// <br>           : Redmine#47031 ���Ӑ挳���̖��ו��ɓ��Ӑ�q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή�</br>
    /// </remarks>
	public class PMHNB02193P_02A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeCommon,IPrintActiveReportTypeList	
	{
		//================================================================================
		//  �R���X�g���N�^�[
		//================================================================================
		#region �R���X�g���N�^�[
		public PMHNB02193P_02A4C()
		{
			InitializeComponent();
		
			// ���Ӑ挳���A�N�Z�X�N���X
			this._csLedgerDmdAcs = new CsLedgerDmdAcs();
		}
		#endregion

		//================================================================================
		//  �����ϐ�
		//================================================================================
		#region private member
		// ���_���󎚗L��
		private bool _isSectionPrint = false;

		// ���_�^�C�g�����󎚗L��
		private bool _isSectionTitlePrint = false;
		
		// ���o�����w�b�_�o�͋敪
		private int _extraCondHeadOutDiv;
		
		// �\�[�g���^�C�g��
		private string _pageHeaderSortOderTitle;
		
		// �T�u�^�C�g��
		private string _pageHeaderSubTitle;
		
		// ���o�����󎚍���
		private StringCollection _extraConditions;
		
		// �t�b�^�[�o�͗L��
		private int _pageFooterOutCode;
		
		// �t�b�^���b�Z�[�W1
		private StringCollection _pageFooters;
		
		// ������
		private SFCMN06002C _printInfo;

		// ���o�����N���X
		private LedgerCmnCndtn _ledgerCmnCndtn         = null;
		
		// ���Ӑ挳���A�N�Z�X�N���X
		private CsLedgerDmdAcs _csLedgerDmdAcs = null;
		
		// �֘A�f�[�^�I�u�W�F�N�g
		private ArrayList _otherDataList;

		// �������
		private int _printCount = 1;
		
		// �w�i����������
		private int _waterMarkMode = 0;
		
		//-----------------------------------------//
		// �����g�p�����o�ϐ�                      //
		//-----------------------------------------//
		// �������׎擾�pKEY���ڊi�[�p�ϐ�
        private int _keyAddUpSecCode = 0;
		private int _keyCustomerCode   = 0;
		private int _keyAddUpdate      = 0;
        // �������׎擾�pKEY���ڊi�[�p�ϐ�(�c���Z�o�p)
        private int _keyAddUpSecCodeB = 0;
        private int _keyCustomerCodeB = 0;
        private int _keyAddUpdateB = 0;

		private DCKAU02622P_01_Detail _detailRpt = null;
        private GroupHeader SectionHeader;
        private GroupFooter SectionFooter;
        private Label Label1;
        private Label Label3;
        private TextBox DATE;
        private TextBox TIME;
        private Label Label2;
        private TextBox PAGE;
        private TextBox ClaimSnm;
        private TextBox PrintAddUpDate;
        private TextBox AddUpSecName;
        private Label Label21;
        private Label Label22;
        private Label Label23;
        private Label Label24;
        private Label Label25;
        private Label Label26;
        private Label Label27;
        private TextBox LastTimeDemand;
        private TextBox ThisTimeDmdNrml;
        private TextBox ThisTimeTtlBlcDmd;
        private TextBox ThisTimeSales;
        private TextBox ThisRgdsDis;
        private TextBox OfsThisTimeSales;
        private TextBox OfsThisSalesTax;
        private TextBox ClaimCode;
        private Label Label6;
        private Label Label7;
        private TextBox ThisSalesTaxTotal;
        private TextBox AfCalDemandPrice;
        private TextBox TextBox;
        private TextBox AddUpSecCode;
        private Line line19;
        private Line line3;
        private Line line5;
        private Line line6;
        private Line line7;
        private Line line8;
        private Line line9;
        private Line line10;
        private Line line11;
        private Line line12;
        private Line line1;
        private GroupHeader CustomerHeader;
        private GroupFooter CustomerFooter;
        private Line line2;
        private Line line4;
        private TextBox KeyAddUpDate;
        private TextBox KeyAddUpSecCode;
        private TextBox KeyCustomerCode;
        private Label Label14;
        private Label Label15;
        private Label SlitTitle;
        private Line line13;
        private TextBox TextBox33;
        private TextBox TextBox32;
        private Label label4;
        private Label label5;
        private Label Label32;
        private Label Label34;
        private TextBox TextBox47;
        private TextBox TextBox48;
        private TextBox textBox1;
        private Label label8;
        private Line line14;

		// �S�̍��ڕ\���ݒ�f�[�^
		private AlItmDspNm _alItmDspNm = null;

		#endregion

		//================================================================================
		//  �v���p�e�B
		//================================================================================
		#region public property
		#region IPrintActiveReportTypeList �����o

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
		/// ���o�����w�b�_�o�͋敪[0:���y�[�W,1:�擪�y�[�W�̂�]
		/// </summary>
		public int ExtraCondHeadOutDiv
		{
			set{this._extraCondHeadOutDiv = value;}
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
		/// �������
		/// </summary>
		public SFCMN06002C PrintInfo
		{
			set
			{
				this._printInfo     = value;
				this._ledgerCmnCndtn = this._printInfo.jyoken as LedgerCmnCndtn;
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
						this._isSectionPrint = (bool)this._otherDataList[0];
						this._isSectionTitlePrint = (bool)this._otherDataList[1];

						foreach (object obj in this._otherDataList)
						{
							Type t = obj.GetType();

							// �S�̍��ڕ\���ݒ�f�[�^ 
							if (t.Equals(typeof(AlItmDspNm)))
							{
								this._alItmDspNm = obj as AlItmDspNm;
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// �y�[�W�w�b�_�T�u�^�C�g��
		/// </summary>
		public string PageHeaderSubtitle
		{
			set{this._pageHeaderSubTitle = value;}
		}
		#endregion
		
		#region	IPrintActiveReportTypeCommon �����o 	 
		public int WatermarkMode 
		{
			set{}
			get{return this._waterMarkMode;}
		}
		
		public event ProgressBarUpEventHandler ProgressBarUpEvent;
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
		/// <br>Programmer	: 20081 �D�c �E�l</br>
        /// <br>Date		: 2007.11.14</br>
		/// </remarks>
        private void PMHNB02193P_02A4C_ReportStart(object sender, EventArgs e)
        {
            // �������������
            this._printCount = 0;

            // �r���\���E��\������
            foreach (Section section in this.Sections)
            {
                Section targetSection = section;
                this.SetVisibleRuledLine(ref targetSection);
            }
        }

		/// <summary>
		/// ���Ӑ�w�b�_�t�H�[�}�b�g�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="eArgs">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �Z�N�V�����̃f�[�^�����[�h����A�����ꂽ��ɔ������܂��B</br>
		/// <br>Programmer	: 20081 �D�c �E�l</br>
        /// <br>Date		: 2007.11.14</br>
		/// </remarks>
		private void CustomerHeader_Format(object sender, System.EventArgs eArgs)
		{
            if (PrintAddUpDate.Value != null)
            {
                int _printAddUpDate = (int)PrintAddUpDate.Value;

                DateTime dt = TDateTime.LongDateToDateTime(_printAddUpDate);
                this.PrintAddUpDate.Text = dt.Year.ToString() + "�N" + dt.Month.ToString() + "��" + dt.Day.ToString() + "��";
            }
		}
		
		/// <summary>
		/// ���׃t�H�[�}�b�g�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="eArgs">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �Z�N�V�����̃f�[�^�����[�h����A�����ꂽ��ɔ������܂��B</br>
		/// <br>Programmer	: 20081 �D�c �E�l</br>
        /// <br>Date		: 2007.11.14</br>
        /// <br>UpdateNote  : 2015/09/21 �c�v�t</br>
        /// <br>            : Redmine#47031 ���Ӑ挳���̖��ו��ɓ��Ӑ�q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή�</br> 
		/// </remarks>
		private void Detail_Format(object sender, System.EventArgs eArgs)
		{
            // ---------- DEL 2015/09/21 �c�v�t For Redmine#47031 ���Ӑ挳���̖��ו��ɓ��Ӑ�q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή� ---------->>>>>
            //string filter = String.Format("{0} = {1} AND {2} = {3} AND {4} = {5} AND {6} = {7}", CsLedgerDmdAcs.Ct_CsLedger_ClaimCode, this._keyCustomerCode,
            //    CsLedgerDmdAcs.Ct_CsLedger_AddUpSecCode, this._keyAddUpSecCode,
            // ---------- DEL 2015/09/21 �c�v�t For Redmine#47031 ���Ӑ挳���̖��ו��ɓ��Ӑ�q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή� ----------<<<<<
            string filter = String.Format("{0} = {1} AND {2} = {3} AND {4} = {5} ", CsLedgerDmdAcs.Ct_CsLedger_ClaimCode, this._keyCustomerCode,   // ADD 2015/09/21 �c�v�t For Redmine#47031 ���Ӑ挳���̖��ו��ɓ��Ӑ�q�̖��ׂ��󎚂���Ȃ��̏�Q�Ή�
                CsLedgerDmdAcs.Ct_CsLedger_AddUpDate, this._keyAddUpdate,
                CsLedgerDmdAcs.Ct_CsLedger_PrtDiv, 1);

            string sort = CsLedgerDmdAcs.Ct_CsLedger_ClaimCode + "," +
                          CsLedgerDmdAcs.Ct_CsLedger_CustomerCode + "," +
                          CsLedgerDmdAcs.Ct_CsLedger_AddUpDate + "," +
                          CsLedgerDmdAcs.Ct_CsLedger_BalanseCode + "," +
                          CsLedgerDmdAcs.Ct_CsLedger_AddUpADate + "," +
                          CsLedgerDmdAcs.Ct_CsLedger_RecordCode + "," +
                          CsLedgerDmdAcs.Ct_CsLedger_SlipNo;

            DataView dv = new DataView(this._csLedgerDmdAcs.CsLedgerSlipDataTable, filter, sort, DataViewRowState.CurrentRows);

   			// ���׃��|�[�g�쐬
			if (this._detailRpt == null)
			{
				this._detailRpt = new DCKAU02622P_01_Detail();
			}
			else
			{
				this._detailRpt.DataSource = null;
			}

            //2009.01.21 UPD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //if ((this.KeyAddUpSecCode.Text != _keyAddUpSecCodeB.ToString("000000"))
            //   && (this.KeyCustomerCode.Text != _keyCustomerCodeB.ToString("000000000")) && (TStrConv.StrToIntDef(this.KeyAddUpDate.Text, 0) != _keyAddUpdateB))
            if ((this.KeyAddUpSecCode.Text != _keyAddUpSecCodeB.ToString("000000"))
               || (this.KeyCustomerCode.Text != _keyCustomerCodeB.ToString("000000000")) || (TStrConv.StrToIntDef(this.KeyAddUpDate.Text, 0) != _keyAddUpdateB))
            //2009.01.21 UPD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            {
                this._keyAddUpSecCodeB = this._keyAddUpSecCode;
                this._keyCustomerCodeB = this._keyCustomerCode;
                this._keyAddUpdateB = this._keyAddUpdate;
                this._detailRpt._keyLastTimeDemand = TStrConv.StrToIntDef(LastTimeDemand.Value.ToString(), 0);
            }
	
			// ���_���󎚗L��
			this._detailRpt.IsSectionPrint = this._isSectionPrint;

            // �f�[�^�o�C���h
            this._detailRpt.DataSource = dv;

            // �T�u���|�[�g�Ƀo�C���h
            this.Detail_SubReport.Report = this._detailRpt;
		}
		
		/// <summary>
		/// �y�[�W�t�b�^�t�H�[�}�b�g�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="eArgs">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �Z�N�V�����̃f�[�^�����[�h����A�����ꂽ��ɔ������܂��B</br>
		/// <br>Programmer	: 20081 �D�c �E�l</br>
        /// <br>Date		: 2007.11.14</br>
		/// </remarks>
		private void PageFooter_Format(object sender, System.EventArgs eArgs)
		{
			// �t�b�^�[�o�͂���H
			if (this._pageFooterOutCode == 0)
			{
				// �t�b�^�[���|�[�g�쐬
				ListCommon_PageFooter rpt = new ListCommon_PageFooter();
			
				// �t�b�^�[�󎚍��ڐݒ�
				if (this._pageFooters[0] != null)
				{
					rpt.PrintFooter1 = this._pageFooters[0];
				}
				if (this._pageFooters[1] != null)
				{
					rpt.PrintFooter2 = this._pageFooters[1];
				}
			
				this.Footer_SubReport.Report = rpt;
			}
		}
		
		/// <summary>
		/// ���׃A�t�^�[�v�����g�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�\�[�X</param>
		/// <param name="e">�C�x���g�f�[�^</param>
		/// <remarks>
		/// <br>Note        : �Z�N�V�������y�[�W�ɕ`�悳�ꂽ��ɔ������܂��B</br>
		/// <br>Programmer  : 20081 �D�c �E�l</br>
        /// <br>Date        : 2007.11.14</br>
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
		/// ���|�[�g�G���h�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�\�[�X</param>
		/// <param name="e">�C�x���g�f�[�^</param>
		/// <remarks>
		/// <br>Note        : ���|�[�g�����ׂẴy�[�W�̏���������������ɔ������܂��B</br>
		/// <br>Programmer  : 20081 �D�c �E�l</br>
        /// <br>Date        : 2007.11.14</br>
		/// </remarks>
        private void PMHNB02193P_02A4C_ReportEnd(object sender, EventArgs e)
        {
            this._detailRpt.Document.Dispose();
            this._detailRpt.Dispose();
            this._detailRpt = null;
        }

		#endregion
		
		// ===============================================================================
		// ActiveReports�f�U�C�i�Ő������ꂽ�R�[�h
		// ===============================================================================
		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.PageHeader PageHeader;
        private DataDynamics.ActiveReports.GroupHeader AddUpDateHeader;
        private DataDynamics.ActiveReports.GroupHeader TitleHeader;
		private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.SubReport Detail_SubReport;
        private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.GroupFooter AddUpDateFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.SubReport Footer_SubReport;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMHNB02193P_02A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.Detail_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Label1 = new DataDynamics.ActiveReports.Label();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.DATE = new DataDynamics.ActiveReports.TextBox();
            this.TIME = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.PAGE = new DataDynamics.ActiveReports.TextBox();
            this.KeyAddUpDate = new DataDynamics.ActiveReports.TextBox();
            this.KeyAddUpSecCode = new DataDynamics.ActiveReports.TextBox();
            this.KeyCustomerCode = new DataDynamics.ActiveReports.TextBox();
            this.SlitTitle = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.AddUpDateHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.AddUpDateFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.ClaimSnm = new DataDynamics.ActiveReports.TextBox();
            this.PrintAddUpDate = new DataDynamics.ActiveReports.TextBox();
            this.AddUpSecName = new DataDynamics.ActiveReports.TextBox();
            this.Label21 = new DataDynamics.ActiveReports.Label();
            this.Label22 = new DataDynamics.ActiveReports.Label();
            this.Label23 = new DataDynamics.ActiveReports.Label();
            this.Label24 = new DataDynamics.ActiveReports.Label();
            this.Label25 = new DataDynamics.ActiveReports.Label();
            this.Label26 = new DataDynamics.ActiveReports.Label();
            this.Label27 = new DataDynamics.ActiveReports.Label();
            this.LastTimeDemand = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimeDmdNrml = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimeTtlBlcDmd = new DataDynamics.ActiveReports.TextBox();
            this.ThisTimeSales = new DataDynamics.ActiveReports.TextBox();
            this.ThisRgdsDis = new DataDynamics.ActiveReports.TextBox();
            this.OfsThisTimeSales = new DataDynamics.ActiveReports.TextBox();
            this.OfsThisSalesTax = new DataDynamics.ActiveReports.TextBox();
            this.ClaimCode = new DataDynamics.ActiveReports.TextBox();
            this.Label6 = new DataDynamics.ActiveReports.Label();
            this.Label7 = new DataDynamics.ActiveReports.Label();
            this.ThisSalesTaxTotal = new DataDynamics.ActiveReports.TextBox();
            this.AfCalDemandPrice = new DataDynamics.ActiveReports.TextBox();
            this.TextBox = new DataDynamics.ActiveReports.TextBox();
            this.AddUpSecCode = new DataDynamics.ActiveReports.TextBox();
            this.line19 = new DataDynamics.ActiveReports.Line();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.line5 = new DataDynamics.ActiveReports.Line();
            this.line6 = new DataDynamics.ActiveReports.Line();
            this.line7 = new DataDynamics.ActiveReports.Line();
            this.line8 = new DataDynamics.ActiveReports.Line();
            this.line9 = new DataDynamics.ActiveReports.Line();
            this.line10 = new DataDynamics.ActiveReports.Line();
            this.line11 = new DataDynamics.ActiveReports.Line();
            this.line12 = new DataDynamics.ActiveReports.Line();
            this.line1 = new DataDynamics.ActiveReports.Line();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.Label14 = new DataDynamics.ActiveReports.Label();
            this.Label15 = new DataDynamics.ActiveReports.Label();
            this.line13 = new DataDynamics.ActiveReports.Line();
            this.TextBox33 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox32 = new DataDynamics.ActiveReports.TextBox();
            this.label4 = new DataDynamics.ActiveReports.Label();
            this.label5 = new DataDynamics.ActiveReports.Label();
            this.Label32 = new DataDynamics.ActiveReports.Label();
            this.Label34 = new DataDynamics.ActiveReports.Label();
            this.TextBox47 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox48 = new DataDynamics.ActiveReports.TextBox();
            this.textBox1 = new DataDynamics.ActiveReports.TextBox();
            this.label8 = new DataDynamics.ActiveReports.Label();
            this.line14 = new DataDynamics.ActiveReports.Line();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.CustomerHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.CustomerFooter = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TIME)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PAGE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeyAddUpDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeyAddUpSecCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeyCustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlitTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClaimSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintAddUpDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpSecName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastTimeDemand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeDmdNrml)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeTtlBlcDmd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisRgdsDis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisTimeSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisSalesTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClaimCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisSalesTaxTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfCalDemandPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpSecCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Detail_SubReport});
            this.Detail.Height = 0.4166667F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            // 
            // Detail_SubReport
            // 
            this.Detail_SubReport.Border.BottomColor = System.Drawing.Color.Black;
            this.Detail_SubReport.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Detail_SubReport.Border.LeftColor = System.Drawing.Color.Black;
            this.Detail_SubReport.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Detail_SubReport.Border.RightColor = System.Drawing.Color.Black;
            this.Detail_SubReport.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Detail_SubReport.Border.TopColor = System.Drawing.Color.Black;
            this.Detail_SubReport.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Detail_SubReport.CloseBorder = false;
            this.Detail_SubReport.Height = 0.394F;
            this.Detail_SubReport.Left = 0F;
            this.Detail_SubReport.Name = "Detail_SubReport";
            this.Detail_SubReport.Report = null;
            this.Detail_SubReport.Top = 0F;
            this.Detail_SubReport.Width = 10.8F;
            // 
            // PageHeader
            // 
            this.PageHeader.CanShrink = true;
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label1,
            this.Label3,
            this.DATE,
            this.TIME,
            this.Label2,
            this.PAGE,
            this.KeyAddUpDate,
            this.KeyAddUpSecCode,
            this.KeyCustomerCode,
            this.SlitTitle});
            this.PageHeader.Height = 0.271F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            // 
            // Label1
            // 
            this.Label1.Border.BottomColor = System.Drawing.Color.Black;
            this.Label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.LeftColor = System.Drawing.Color.Black;
            this.Label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.RightColor = System.Drawing.Color.Black;
            this.Label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Border.TopColor = System.Drawing.Color.Black;
            this.Label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label1.Height = 0.25F;
            this.Label1.HyperLink = "";
            this.Label1.Left = 0.125F;
            this.Label1.Name = "Label1";
            this.Label1.Style = "font-weight: bold; font-style: italic; font-size: 14.25pt; vertical-align: top; ";
            this.Label1.Text = "���Ӑ挳���i�`�[�j";
            this.Label1.Top = 0F;
            this.Label1.Width = 2.1875F;
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
            this.Label3.Height = 0.156F;
            this.Label3.HyperLink = "";
            this.Label3.Left = 7.8125F;
            this.Label3.MultiLine = false;
            this.Label3.Name = "Label3";
            this.Label3.Style = "ddo-char-set: 1; font-size: 8pt; font-family: �l�r ����; vertical-align: top; ";
            this.Label3.Text = "�쐬���t�F";
            this.Label3.Top = 0.0625F;
            this.Label3.Width = 0.625F;
            // 
            // DATE
            // 
            this.DATE.Border.BottomColor = System.Drawing.Color.Black;
            this.DATE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DATE.Border.LeftColor = System.Drawing.Color.Black;
            this.DATE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DATE.Border.RightColor = System.Drawing.Color.Black;
            this.DATE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DATE.Border.TopColor = System.Drawing.Color.Black;
            this.DATE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DATE.CanShrink = true;
            this.DATE.Height = 0.156F;
            this.DATE.Left = 8.375F;
            this.DATE.MultiLine = false;
            this.DATE.Name = "DATE";
            this.DATE.OutputFormat = resources.GetString("DATE.OutputFormat");
            this.DATE.Style = "ddo-char-set: 1; font-size: 8pt; font-family: �l�r ����; vertical-align: top; ";
            this.DATE.Text = null;
            this.DATE.Top = 0.0625F;
            this.DATE.Width = 0.938F;
            // 
            // TIME
            // 
            this.TIME.Border.BottomColor = System.Drawing.Color.Black;
            this.TIME.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TIME.Border.LeftColor = System.Drawing.Color.Black;
            this.TIME.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TIME.Border.RightColor = System.Drawing.Color.Black;
            this.TIME.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TIME.Border.TopColor = System.Drawing.Color.Black;
            this.TIME.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TIME.Height = 0.156F;
            this.TIME.Left = 9.3125F;
            this.TIME.Name = "TIME";
            this.TIME.Style = "font-size: 8pt; ";
            this.TIME.Text = null;
            this.TIME.Top = 0.0625F;
            this.TIME.Width = 0.5F;
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
            this.Label2.Height = 0.156F;
            this.Label2.HyperLink = "";
            this.Label2.Left = 9.8125F;
            this.Label2.MultiLine = false;
            this.Label2.Name = "Label2";
            this.Label2.Style = "font-size: 8pt; font-family: �l�r ����; vertical-align: top; ";
            this.Label2.Text = "�y�[�W�F";
            this.Label2.Top = 0.0625F;
            this.Label2.Width = 0.5F;
            // 
            // PAGE
            // 
            this.PAGE.Border.BottomColor = System.Drawing.Color.Black;
            this.PAGE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PAGE.Border.LeftColor = System.Drawing.Color.Black;
            this.PAGE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PAGE.Border.RightColor = System.Drawing.Color.Black;
            this.PAGE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PAGE.Border.TopColor = System.Drawing.Color.Black;
            this.PAGE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PAGE.CanShrink = true;
            this.PAGE.Height = 0.156F;
            this.PAGE.Left = 10.3125F;
            this.PAGE.MultiLine = false;
            this.PAGE.Name = "PAGE";
            this.PAGE.OutputFormat = resources.GetString("PAGE.OutputFormat");
            this.PAGE.Style = "text-align: right; font-size: 8.25pt; font-family: �l�r ����; vertical-align: top; ";
            this.PAGE.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.PAGE.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.PAGE.Text = null;
            this.PAGE.Top = 0.0625F;
            this.PAGE.Width = 0.281F;
            // 
            // KeyAddUpDate
            // 
            this.KeyAddUpDate.Border.BottomColor = System.Drawing.Color.Black;
            this.KeyAddUpDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.KeyAddUpDate.Border.LeftColor = System.Drawing.Color.Black;
            this.KeyAddUpDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.KeyAddUpDate.Border.RightColor = System.Drawing.Color.Black;
            this.KeyAddUpDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.KeyAddUpDate.Border.TopColor = System.Drawing.Color.Black;
            this.KeyAddUpDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.KeyAddUpDate.DataField = "AddUpDateInt";
            this.KeyAddUpDate.Height = 0.1479167F;
            this.KeyAddUpDate.Left = 3.31F;
            this.KeyAddUpDate.Name = "KeyAddUpDate";
            this.KeyAddUpDate.Style = "";
            this.KeyAddUpDate.Text = null;
            this.KeyAddUpDate.Top = 0.0625F;
            this.KeyAddUpDate.Visible = false;
            this.KeyAddUpDate.Width = 0.9375F;
            // 
            // KeyAddUpSecCode
            // 
            this.KeyAddUpSecCode.Border.BottomColor = System.Drawing.Color.Black;
            this.KeyAddUpSecCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.KeyAddUpSecCode.Border.LeftColor = System.Drawing.Color.Black;
            this.KeyAddUpSecCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.KeyAddUpSecCode.Border.RightColor = System.Drawing.Color.Black;
            this.KeyAddUpSecCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.KeyAddUpSecCode.Border.TopColor = System.Drawing.Color.Black;
            this.KeyAddUpSecCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.KeyAddUpSecCode.DataField = "AddUpSecCode";
            this.KeyAddUpSecCode.Height = 0.1479167F;
            this.KeyAddUpSecCode.Left = 4.32F;
            this.KeyAddUpSecCode.Name = "KeyAddUpSecCode";
            this.KeyAddUpSecCode.Style = "font-size: 10pt; ";
            this.KeyAddUpSecCode.Text = null;
            this.KeyAddUpSecCode.Top = 0.0625F;
            this.KeyAddUpSecCode.Visible = false;
            this.KeyAddUpSecCode.Width = 0.9375F;
            // 
            // KeyCustomerCode
            // 
            this.KeyCustomerCode.Border.BottomColor = System.Drawing.Color.Black;
            this.KeyCustomerCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.KeyCustomerCode.Border.LeftColor = System.Drawing.Color.Black;
            this.KeyCustomerCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.KeyCustomerCode.Border.RightColor = System.Drawing.Color.Black;
            this.KeyCustomerCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.KeyCustomerCode.Border.TopColor = System.Drawing.Color.Black;
            this.KeyCustomerCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.KeyCustomerCode.DataField = "ClaimCode";
            this.KeyCustomerCode.Height = 0.1479167F;
            this.KeyCustomerCode.Left = 5.33F;
            this.KeyCustomerCode.Name = "KeyCustomerCode";
            this.KeyCustomerCode.Style = "font-size: 10pt; ";
            this.KeyCustomerCode.Text = null;
            this.KeyCustomerCode.Top = 0.0625F;
            this.KeyCustomerCode.Visible = false;
            this.KeyCustomerCode.Width = 0.9375F;
            // 
            // SlitTitle
            // 
            this.SlitTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.SlitTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlitTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.SlitTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlitTitle.Border.RightColor = System.Drawing.Color.Black;
            this.SlitTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlitTitle.Border.TopColor = System.Drawing.Color.Black;
            this.SlitTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SlitTitle.DataField = "SlitTitle";
            this.SlitTitle.Height = 0.25F;
            this.SlitTitle.HyperLink = "";
            this.SlitTitle.Left = 1.88F;
            this.SlitTitle.Name = "SlitTitle";
            this.SlitTitle.Style = "font-weight: bold; font-style: italic; font-size: 14.25pt; vertical-align: top; ";
            this.SlitTitle.Text = "";
            this.SlitTitle.Top = 0F;
            this.SlitTitle.Width = 1.313F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.3020833F;
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
            this.Footer_SubReport.Height = 0.2401575F;
            this.Footer_SubReport.Left = 0F;
            this.Footer_SubReport.Name = "Footer_SubReport";
            this.Footer_SubReport.Report = null;
            this.Footer_SubReport.Top = 0F;
            this.Footer_SubReport.Width = 10.79922F;
            // 
            // AddUpDateHeader
            // 
            this.AddUpDateHeader.CanShrink = true;
            this.AddUpDateHeader.DataField = "AddUpDateInt";
            this.AddUpDateHeader.Height = 0F;
            this.AddUpDateHeader.Name = "AddUpDateHeader";
            // 
            // AddUpDateFooter
            // 
            this.AddUpDateFooter.Height = 0F;
            this.AddUpDateFooter.Name = "AddUpDateFooter";
            this.AddUpDateFooter.Visible = false;
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanGrow = false;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.ClaimSnm,
            this.PrintAddUpDate,
            this.AddUpSecName,
            this.Label21,
            this.Label22,
            this.Label23,
            this.Label24,
            this.Label25,
            this.Label26,
            this.Label27,
            this.LastTimeDemand,
            this.ThisTimeDmdNrml,
            this.ThisTimeTtlBlcDmd,
            this.ThisTimeSales,
            this.ThisRgdsDis,
            this.OfsThisTimeSales,
            this.OfsThisSalesTax,
            this.ClaimCode,
            this.Label6,
            this.Label7,
            this.ThisSalesTaxTotal,
            this.AfCalDemandPrice,
            this.TextBox,
            this.AddUpSecCode,
            this.line19,
            this.line3,
            this.line5,
            this.line6,
            this.line7,
            this.line8,
            this.line9,
            this.line10,
            this.line11,
            this.line12,
            this.line1,
            this.line2,
            this.line4,
            this.Label14,
            this.Label15,
            this.line13,
            this.TextBox33,
            this.TextBox32,
            this.label4,
            this.label5,
            this.Label32,
            this.Label34,
            this.TextBox47,
            this.TextBox48,
            this.textBox1,
            this.label8,
            this.line14});
            this.TitleHeader.Height = 1.541667F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.TitleHeader.Format += new System.EventHandler(this.CustomerHeader_Format);
            // 
            // ClaimSnm
            // 
            this.ClaimSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.ClaimSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ClaimSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.ClaimSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ClaimSnm.Border.RightColor = System.Drawing.Color.Black;
            this.ClaimSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ClaimSnm.Border.TopColor = System.Drawing.Color.Black;
            this.ClaimSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ClaimSnm.DataField = "ClaimSnm";
            this.ClaimSnm.Height = 0.1377953F;
            this.ClaimSnm.Left = 1.4375F;
            this.ClaimSnm.MultiLine = false;
            this.ClaimSnm.Name = "ClaimSnm";
            this.ClaimSnm.Style = "font-size: 8pt; ";
            this.ClaimSnm.Text = "�P�Q�R�S�T�U�V�W�X�O�P�Q�R�S�T�U�V�W�X�O�P�Q�R�S�T�U�V�W�X�O";
            this.ClaimSnm.Top = 0.3125F;
            this.ClaimSnm.Width = 3.375F;
            // 
            // PrintAddUpDate
            // 
            this.PrintAddUpDate.Border.BottomColor = System.Drawing.Color.Black;
            this.PrintAddUpDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintAddUpDate.Border.LeftColor = System.Drawing.Color.Black;
            this.PrintAddUpDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintAddUpDate.Border.RightColor = System.Drawing.Color.Black;
            this.PrintAddUpDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintAddUpDate.Border.TopColor = System.Drawing.Color.Black;
            this.PrintAddUpDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrintAddUpDate.DataField = "PrintAddUpDate";
            this.PrintAddUpDate.Height = 0.188F;
            this.PrintAddUpDate.Left = 8.981F;
            this.PrintAddUpDate.MultiLine = false;
            this.PrintAddUpDate.Name = "PrintAddUpDate";
            this.PrintAddUpDate.Style = "text-align: right; font-size: 8pt; vertical-align: middle; ";
            this.PrintAddUpDate.Text = null;
            this.PrintAddUpDate.Top = 0.875F;
            this.PrintAddUpDate.Width = 1F;
            // 
            // AddUpSecName
            // 
            this.AddUpSecName.Border.BottomColor = System.Drawing.Color.Black;
            this.AddUpSecName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecName.Border.LeftColor = System.Drawing.Color.Black;
            this.AddUpSecName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecName.Border.RightColor = System.Drawing.Color.Black;
            this.AddUpSecName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecName.Border.TopColor = System.Drawing.Color.Black;
            this.AddUpSecName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecName.DataField = "AddUpSecName";
            this.AddUpSecName.Height = 0.1574803F;
            this.AddUpSecName.Left = 1.458F;
            this.AddUpSecName.MultiLine = false;
            this.AddUpSecName.Name = "AddUpSecName";
            this.AddUpSecName.Style = "font-size: 8pt; ";
            this.AddUpSecName.Text = "���_��";
            this.AddUpSecName.Top = 0.125F;
            this.AddUpSecName.Width = 1.177165F;
            // 
            // Label21
            // 
            this.Label21.Border.BottomColor = System.Drawing.Color.Black;
            this.Label21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label21.Border.LeftColor = System.Drawing.Color.Black;
            this.Label21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label21.Border.RightColor = System.Drawing.Color.Black;
            this.Label21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label21.Border.TopColor = System.Drawing.Color.Black;
            this.Label21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label21.Height = 0.252F;
            this.Label21.HyperLink = "";
            this.Label21.Left = 0.125F;
            this.Label21.Name = "Label21";
            this.Label21.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; vertical-align: middle;" +
                " ";
            this.Label21.Text = "�O��c��";
            this.Label21.Top = 0.563F;
            this.Label21.Width = 0.921F;
            // 
            // Label22
            // 
            this.Label22.Border.BottomColor = System.Drawing.Color.Black;
            this.Label22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label22.Border.LeftColor = System.Drawing.Color.Black;
            this.Label22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label22.Border.RightColor = System.Drawing.Color.Black;
            this.Label22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label22.Border.TopColor = System.Drawing.Color.Black;
            this.Label22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label22.Height = 0.252F;
            this.Label22.HyperLink = "";
            this.Label22.Left = 1.063F;
            this.Label22.Name = "Label22";
            this.Label22.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; vertical-align: middle;" +
                " ";
            this.Label22.Text = "��������z";
            this.Label22.Top = 0.563F;
            this.Label22.Width = 0.921F;
            // 
            // Label23
            // 
            this.Label23.Border.BottomColor = System.Drawing.Color.Black;
            this.Label23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label23.Border.LeftColor = System.Drawing.Color.Black;
            this.Label23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label23.Border.RightColor = System.Drawing.Color.Black;
            this.Label23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label23.Border.TopColor = System.Drawing.Color.Black;
            this.Label23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label23.Height = 0.252F;
            this.Label23.HyperLink = "";
            this.Label23.Left = 2.04F;
            this.Label23.Name = "Label23";
            this.Label23.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; vertical-align: middle;" +
                " ";
            this.Label23.Text = "�J�z�c��";
            this.Label23.Top = 0.563F;
            this.Label23.Width = 0.921F;
            // 
            // Label24
            // 
            this.Label24.Border.BottomColor = System.Drawing.Color.Black;
            this.Label24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label24.Border.LeftColor = System.Drawing.Color.Black;
            this.Label24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label24.Border.RightColor = System.Drawing.Color.Black;
            this.Label24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label24.Border.TopColor = System.Drawing.Color.Black;
            this.Label24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label24.Height = 0.252F;
            this.Label24.HyperLink = "";
            this.Label24.Left = 2.99F;
            this.Label24.Name = "Label24";
            this.Label24.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; vertical-align: middle;" +
                " ";
            this.Label24.Text = "���񔄏�z";
            this.Label24.Top = 0.563F;
            this.Label24.Width = 0.921F;
            // 
            // Label25
            // 
            this.Label25.Border.BottomColor = System.Drawing.Color.Black;
            this.Label25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label25.Border.LeftColor = System.Drawing.Color.Black;
            this.Label25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label25.Border.RightColor = System.Drawing.Color.Black;
            this.Label25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label25.Border.TopColor = System.Drawing.Color.Black;
            this.Label25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label25.Height = 0.252F;
            this.Label25.HyperLink = "";
            this.Label25.Left = 3.958F;
            this.Label25.Name = "Label25";
            this.Label25.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; vertical-align: middle;" +
                " ";
            this.Label25.Text = "�ԕi�E�l��";
            this.Label25.Top = 0.563F;
            this.Label25.Width = 0.921F;
            // 
            // Label26
            // 
            this.Label26.Border.BottomColor = System.Drawing.Color.Black;
            this.Label26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label26.Border.LeftColor = System.Drawing.Color.Black;
            this.Label26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label26.Border.RightColor = System.Drawing.Color.Black;
            this.Label26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label26.Border.TopColor = System.Drawing.Color.Black;
            this.Label26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label26.Height = 0.252F;
            this.Label26.HyperLink = "";
            this.Label26.Left = 4.938F;
            this.Label26.Name = "Label26";
            this.Label26.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; vertical-align: middle;" +
                " ";
            this.Label26.Text = "������z";
            this.Label26.Top = 0.563F;
            this.Label26.Width = 0.921F;
            // 
            // Label27
            // 
            this.Label27.Border.BottomColor = System.Drawing.Color.Black;
            this.Label27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label27.Border.LeftColor = System.Drawing.Color.Black;
            this.Label27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label27.Border.RightColor = System.Drawing.Color.Black;
            this.Label27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label27.Border.TopColor = System.Drawing.Color.Black;
            this.Label27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label27.Height = 0.252F;
            this.Label27.HyperLink = "";
            this.Label27.Left = 5.885F;
            this.Label27.Name = "Label27";
            this.Label27.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; vertical-align: middle;" +
                " ";
            this.Label27.Text = "�����";
            this.Label27.Top = 0.563F;
            this.Label27.Width = 0.921F;
            // 
            // LastTimeDemand
            // 
            this.LastTimeDemand.Border.BottomColor = System.Drawing.Color.Black;
            this.LastTimeDemand.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimeDemand.Border.LeftColor = System.Drawing.Color.Black;
            this.LastTimeDemand.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimeDemand.Border.RightColor = System.Drawing.Color.Black;
            this.LastTimeDemand.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimeDemand.Border.TopColor = System.Drawing.Color.Black;
            this.LastTimeDemand.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.LastTimeDemand.DataField = "LastTimeDemand";
            this.LastTimeDemand.Height = 0.2007874F;
            this.LastTimeDemand.Left = 0.125F;
            this.LastTimeDemand.Name = "LastTimeDemand";
            this.LastTimeDemand.OutputFormat = resources.GetString("LastTimeDemand.OutputFormat");
            this.LastTimeDemand.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8.25pt; font-" +
                "family: �l�r �S�V�b�N; vertical-align: middle; ";
            this.LastTimeDemand.Text = "123,456,789,012";
            this.LastTimeDemand.Top = 0.875F;
            this.LastTimeDemand.Width = 0.9217521F;
            // 
            // ThisTimeDmdNrml
            // 
            this.ThisTimeDmdNrml.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisTimeDmdNrml.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeDmdNrml.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisTimeDmdNrml.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeDmdNrml.Border.RightColor = System.Drawing.Color.Black;
            this.ThisTimeDmdNrml.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeDmdNrml.Border.TopColor = System.Drawing.Color.Black;
            this.ThisTimeDmdNrml.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeDmdNrml.DataField = "ThisTimeDmdNrml";
            this.ThisTimeDmdNrml.Height = 0.2007874F;
            this.ThisTimeDmdNrml.Left = 1.063F;
            this.ThisTimeDmdNrml.Name = "ThisTimeDmdNrml";
            this.ThisTimeDmdNrml.OutputFormat = resources.GetString("ThisTimeDmdNrml.OutputFormat");
            this.ThisTimeDmdNrml.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8.25pt; font-" +
                "family: �l�r �S�V�b�N; vertical-align: middle; ";
            this.ThisTimeDmdNrml.Text = "123,456,789,012";
            this.ThisTimeDmdNrml.Top = 0.875F;
            this.ThisTimeDmdNrml.Width = 0.9212598F;
            // 
            // ThisTimeTtlBlcDmd
            // 
            this.ThisTimeTtlBlcDmd.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisTimeTtlBlcDmd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeTtlBlcDmd.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisTimeTtlBlcDmd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeTtlBlcDmd.Border.RightColor = System.Drawing.Color.Black;
            this.ThisTimeTtlBlcDmd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeTtlBlcDmd.Border.TopColor = System.Drawing.Color.Black;
            this.ThisTimeTtlBlcDmd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeTtlBlcDmd.DataField = "ThisTimeTtlBlcDmd";
            this.ThisTimeTtlBlcDmd.Height = 0.2007874F;
            this.ThisTimeTtlBlcDmd.Left = 2.04F;
            this.ThisTimeTtlBlcDmd.Name = "ThisTimeTtlBlcDmd";
            this.ThisTimeTtlBlcDmd.OutputFormat = resources.GetString("ThisTimeTtlBlcDmd.OutputFormat");
            this.ThisTimeTtlBlcDmd.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8.25pt; font-" +
                "family: �l�r �S�V�b�N; vertical-align: middle; ";
            this.ThisTimeTtlBlcDmd.Text = "123,456,789,012";
            this.ThisTimeTtlBlcDmd.Top = 0.875F;
            this.ThisTimeTtlBlcDmd.Width = 0.9212598F;
            // 
            // ThisTimeSales
            // 
            this.ThisTimeSales.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisTimeSales.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeSales.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisTimeSales.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeSales.Border.RightColor = System.Drawing.Color.Black;
            this.ThisTimeSales.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeSales.Border.TopColor = System.Drawing.Color.Black;
            this.ThisTimeSales.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisTimeSales.DataField = "ThisTimeSales";
            this.ThisTimeSales.Height = 0.2007874F;
            this.ThisTimeSales.Left = 2.99F;
            this.ThisTimeSales.Name = "ThisTimeSales";
            this.ThisTimeSales.OutputFormat = resources.GetString("ThisTimeSales.OutputFormat");
            this.ThisTimeSales.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8.25pt; font-" +
                "family: �l�r �S�V�b�N; vertical-align: middle; ";
            this.ThisTimeSales.Text = "123,456,789,012";
            this.ThisTimeSales.Top = 0.875F;
            this.ThisTimeSales.Width = 0.9212598F;
            // 
            // ThisRgdsDis
            // 
            this.ThisRgdsDis.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisRgdsDis.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisRgdsDis.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisRgdsDis.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisRgdsDis.Border.RightColor = System.Drawing.Color.Black;
            this.ThisRgdsDis.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisRgdsDis.Border.TopColor = System.Drawing.Color.Black;
            this.ThisRgdsDis.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisRgdsDis.DataField = "ThisRgdsDis";
            this.ThisRgdsDis.Height = 0.2007874F;
            this.ThisRgdsDis.Left = 3.958F;
            this.ThisRgdsDis.Name = "ThisRgdsDis";
            this.ThisRgdsDis.OutputFormat = resources.GetString("ThisRgdsDis.OutputFormat");
            this.ThisRgdsDis.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8.25pt; font-" +
                "family: �l�r �S�V�b�N; vertical-align: middle; ";
            this.ThisRgdsDis.Text = "123,456,789,012";
            this.ThisRgdsDis.Top = 0.875F;
            this.ThisRgdsDis.Width = 0.9212598F;
            // 
            // OfsThisTimeSales
            // 
            this.OfsThisTimeSales.Border.BottomColor = System.Drawing.Color.Black;
            this.OfsThisTimeSales.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisTimeSales.Border.LeftColor = System.Drawing.Color.Black;
            this.OfsThisTimeSales.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisTimeSales.Border.RightColor = System.Drawing.Color.Black;
            this.OfsThisTimeSales.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisTimeSales.Border.TopColor = System.Drawing.Color.Black;
            this.OfsThisTimeSales.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisTimeSales.DataField = "OfsThisTimeSales";
            this.OfsThisTimeSales.Height = 0.2007874F;
            this.OfsThisTimeSales.Left = 4.938F;
            this.OfsThisTimeSales.Name = "OfsThisTimeSales";
            this.OfsThisTimeSales.OutputFormat = resources.GetString("OfsThisTimeSales.OutputFormat");
            this.OfsThisTimeSales.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8.25pt; font-" +
                "family: �l�r �S�V�b�N; vertical-align: middle; ";
            this.OfsThisTimeSales.Text = "123,456,789,012";
            this.OfsThisTimeSales.Top = 0.875F;
            this.OfsThisTimeSales.Width = 0.9212598F;
            // 
            // OfsThisSalesTax
            // 
            this.OfsThisSalesTax.Border.BottomColor = System.Drawing.Color.Black;
            this.OfsThisSalesTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisSalesTax.Border.LeftColor = System.Drawing.Color.Black;
            this.OfsThisSalesTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisSalesTax.Border.RightColor = System.Drawing.Color.Black;
            this.OfsThisSalesTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisSalesTax.Border.TopColor = System.Drawing.Color.Black;
            this.OfsThisSalesTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.OfsThisSalesTax.DataField = "OfsThisSalesTax";
            this.OfsThisSalesTax.Height = 0.2007874F;
            this.OfsThisSalesTax.Left = 5.885F;
            this.OfsThisSalesTax.Name = "OfsThisSalesTax";
            this.OfsThisSalesTax.OutputFormat = resources.GetString("OfsThisSalesTax.OutputFormat");
            this.OfsThisSalesTax.Style = "ddo-char-set: 1; text-align: right; font-weight: normal; font-size: 8.25pt; font-" +
                "family: �l�r �S�V�b�N; vertical-align: middle; ";
            this.OfsThisSalesTax.Text = "123,456,789,012";
            this.OfsThisSalesTax.Top = 0.875F;
            this.OfsThisSalesTax.Width = 0.9212598F;
            // 
            // ClaimCode
            // 
            this.ClaimCode.Border.BottomColor = System.Drawing.Color.Black;
            this.ClaimCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ClaimCode.Border.LeftColor = System.Drawing.Color.Black;
            this.ClaimCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ClaimCode.Border.RightColor = System.Drawing.Color.Black;
            this.ClaimCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ClaimCode.Border.TopColor = System.Drawing.Color.Black;
            this.ClaimCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ClaimCode.DataField = "ClaimCode";
            this.ClaimCode.Height = 0.125F;
            this.ClaimCode.Left = 0.625F;
            this.ClaimCode.MultiLine = false;
            this.ClaimCode.Name = "ClaimCode";
            this.ClaimCode.OutputFormat = resources.GetString("ClaimCode.OutputFormat");
            this.ClaimCode.Style = "text-align: left; font-size: 8pt; ";
            this.ClaimCode.Text = null;
            this.ClaimCode.Top = 0.3125F;
            this.ClaimCode.Width = 0.75F;
            // 
            // Label6
            // 
            this.Label6.Border.BottomColor = System.Drawing.Color.Black;
            this.Label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.LeftColor = System.Drawing.Color.Black;
            this.Label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.RightColor = System.Drawing.Color.Black;
            this.Label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Border.TopColor = System.Drawing.Color.Black;
            this.Label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label6.Height = 0.252F;
            this.Label6.HyperLink = "";
            this.Label6.Left = 6.844F;
            this.Label6.Name = "Label6";
            this.Label6.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; vertical-align: middle;" +
                " ";
            this.Label6.Text = "�ō�����z";
            this.Label6.Top = 0.563F;
            this.Label6.Width = 0.921F;
            // 
            // Label7
            // 
            this.Label7.Border.BottomColor = System.Drawing.Color.Black;
            this.Label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label7.Border.LeftColor = System.Drawing.Color.Black;
            this.Label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label7.Border.RightColor = System.Drawing.Color.Black;
            this.Label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label7.Border.TopColor = System.Drawing.Color.Black;
            this.Label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label7.Height = 0.252F;
            this.Label7.HyperLink = "";
            this.Label7.Left = 7.813F;
            this.Label7.Name = "Label7";
            this.Label7.Style = "text-align: center; font-weight: bold; font-size: 8.25pt; vertical-align: middle;" +
                " ";
            this.Label7.Text = "����c��";
            this.Label7.Top = 0.563F;
            this.Label7.Width = 0.921F;
            // 
            // ThisSalesTaxTotal
            // 
            this.ThisSalesTaxTotal.Border.BottomColor = System.Drawing.Color.Black;
            this.ThisSalesTaxTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisSalesTaxTotal.Border.LeftColor = System.Drawing.Color.Black;
            this.ThisSalesTaxTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisSalesTaxTotal.Border.RightColor = System.Drawing.Color.Black;
            this.ThisSalesTaxTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisSalesTaxTotal.Border.TopColor = System.Drawing.Color.Black;
            this.ThisSalesTaxTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.ThisSalesTaxTotal.DataField = "ThisSalesTaxTotal";
            this.ThisSalesTaxTotal.Height = 0.2007874F;
            this.ThisSalesTaxTotal.Left = 6.844F;
            this.ThisSalesTaxTotal.Name = "ThisSalesTaxTotal";
            this.ThisSalesTaxTotal.OutputFormat = resources.GetString("ThisSalesTaxTotal.OutputFormat");
            this.ThisSalesTaxTotal.Style = "text-align: right; font-weight: normal; font-size: 8.25pt; font-family: �l�r �S�V�b�N; " +
                "vertical-align: middle; ";
            this.ThisSalesTaxTotal.Text = "123,456,789,012";
            this.ThisSalesTaxTotal.Top = 0.875F;
            this.ThisSalesTaxTotal.Width = 0.9212598F;
            // 
            // AfCalDemandPrice
            // 
            this.AfCalDemandPrice.Border.BottomColor = System.Drawing.Color.Black;
            this.AfCalDemandPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfCalDemandPrice.Border.LeftColor = System.Drawing.Color.Black;
            this.AfCalDemandPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfCalDemandPrice.Border.RightColor = System.Drawing.Color.Black;
            this.AfCalDemandPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfCalDemandPrice.Border.TopColor = System.Drawing.Color.Black;
            this.AfCalDemandPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AfCalDemandPrice.DataField = "AfCalDemandPrice";
            this.AfCalDemandPrice.Height = 0.2007874F;
            this.AfCalDemandPrice.Left = 7.813F;
            this.AfCalDemandPrice.Name = "AfCalDemandPrice";
            this.AfCalDemandPrice.OutputFormat = resources.GetString("AfCalDemandPrice.OutputFormat");
            this.AfCalDemandPrice.Style = "text-align: right; font-weight: normal; font-size: 8.25pt; font-family: �l�r �S�V�b�N; " +
                "vertical-align: middle; ";
            this.AfCalDemandPrice.Text = "123,456,789,012";
            this.AfCalDemandPrice.Top = 0.875F;
            this.AfCalDemandPrice.Width = 0.9212598F;
            // 
            // TextBox
            // 
            this.TextBox.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox.Height = 0.252F;
            this.TextBox.Left = 9.06F;
            this.TextBox.Name = "TextBox";
            this.TextBox.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; vertical-a" +
                "lign: middle; ";
            this.TextBox.Text = "����";
            this.TextBox.Top = 0.563F;
            this.TextBox.Width = 0.921F;
            // 
            // AddUpSecCode
            // 
            this.AddUpSecCode.Border.BottomColor = System.Drawing.Color.Black;
            this.AddUpSecCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecCode.Border.LeftColor = System.Drawing.Color.Black;
            this.AddUpSecCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecCode.Border.RightColor = System.Drawing.Color.Black;
            this.AddUpSecCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecCode.Border.TopColor = System.Drawing.Color.Black;
            this.AddUpSecCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.AddUpSecCode.DataField = "AddUpSecCode";
            this.AddUpSecCode.Height = 0.125F;
            this.AddUpSecCode.Left = 0.646F;
            this.AddUpSecCode.MultiLine = false;
            this.AddUpSecCode.Name = "AddUpSecCode";
            this.AddUpSecCode.Style = "text-align: left; font-size: 8pt; ";
            this.AddUpSecCode.Text = null;
            this.AddUpSecCode.Top = 0.125F;
            this.AddUpSecCode.Width = 0.75F;
            // 
            // line19
            // 
            this.line19.Border.BottomColor = System.Drawing.Color.Black;
            this.line19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line19.Border.LeftColor = System.Drawing.Color.Black;
            this.line19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line19.Border.RightColor = System.Drawing.Color.Black;
            this.line19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line19.Border.TopColor = System.Drawing.Color.Black;
            this.line19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line19.Height = 0F;
            this.line19.Left = 0.125F;
            this.line19.LineWeight = 1F;
            this.line19.Name = "line19";
            this.line19.Top = 0.56F;
            this.line19.Width = 8.6875F;
            this.line19.X1 = 0.125F;
            this.line19.X2 = 8.8125F;
            this.line19.Y1 = 0.56F;
            this.line19.Y2 = 0.56F;
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
            this.line3.Height = 0.565F;
            this.line3.Left = 1.0625F;
            this.line3.LineWeight = 1F;
            this.line3.Name = "line3";
            this.line3.Top = 0.56F;
            this.line3.Width = 0F;
            this.line3.X1 = 1.0625F;
            this.line3.X2 = 1.0625F;
            this.line3.Y1 = 0.56F;
            this.line3.Y2 = 1.125F;
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
            this.line5.Height = 0.565F;
            this.line5.Left = 2F;
            this.line5.LineWeight = 1F;
            this.line5.Name = "line5";
            this.line5.Top = 0.56F;
            this.line5.Width = 0F;
            this.line5.X1 = 2F;
            this.line5.X2 = 2F;
            this.line5.Y1 = 0.56F;
            this.line5.Y2 = 1.125F;
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
            this.line6.Height = 0.565F;
            this.line6.Left = 3F;
            this.line6.LineWeight = 1F;
            this.line6.Name = "line6";
            this.line6.Top = 0.56F;
            this.line6.Width = 0F;
            this.line6.X1 = 3F;
            this.line6.X2 = 3F;
            this.line6.Y1 = 0.56F;
            this.line6.Y2 = 1.125F;
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
            this.line7.Height = 0.565F;
            this.line7.Left = 3.94F;
            this.line7.LineWeight = 1F;
            this.line7.Name = "line7";
            this.line7.Top = 0.56F;
            this.line7.Width = 0F;
            this.line7.X1 = 3.94F;
            this.line7.X2 = 3.94F;
            this.line7.Y1 = 0.56F;
            this.line7.Y2 = 1.125F;
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
            this.line8.Height = 0.565F;
            this.line8.Left = 4.9375F;
            this.line8.LineWeight = 1F;
            this.line8.Name = "line8";
            this.line8.Top = 0.56F;
            this.line8.Width = 0F;
            this.line8.X1 = 4.9375F;
            this.line8.X2 = 4.9375F;
            this.line8.Y1 = 0.56F;
            this.line8.Y2 = 1.125F;
            // 
            // line9
            // 
            this.line9.Border.BottomColor = System.Drawing.Color.Black;
            this.line9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.Border.LeftColor = System.Drawing.Color.Black;
            this.line9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.Border.RightColor = System.Drawing.Color.Black;
            this.line9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.Border.TopColor = System.Drawing.Color.Black;
            this.line9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line9.Height = 0.565F;
            this.line9.Left = 5.875F;
            this.line9.LineWeight = 1F;
            this.line9.Name = "line9";
            this.line9.Top = 0.56F;
            this.line9.Width = 0F;
            this.line9.X1 = 5.875F;
            this.line9.X2 = 5.875F;
            this.line9.Y1 = 0.56F;
            this.line9.Y2 = 1.125F;
            // 
            // line10
            // 
            this.line10.Border.BottomColor = System.Drawing.Color.Black;
            this.line10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line10.Border.LeftColor = System.Drawing.Color.Black;
            this.line10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line10.Border.RightColor = System.Drawing.Color.Black;
            this.line10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line10.Border.TopColor = System.Drawing.Color.Black;
            this.line10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line10.Height = 0.565F;
            this.line10.Left = 6.875F;
            this.line10.LineWeight = 1F;
            this.line10.Name = "line10";
            this.line10.Top = 0.56F;
            this.line10.Width = 0F;
            this.line10.X1 = 6.875F;
            this.line10.X2 = 6.875F;
            this.line10.Y1 = 0.56F;
            this.line10.Y2 = 1.125F;
            // 
            // line11
            // 
            this.line11.Border.BottomColor = System.Drawing.Color.Black;
            this.line11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line11.Border.LeftColor = System.Drawing.Color.Black;
            this.line11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line11.Border.RightColor = System.Drawing.Color.Black;
            this.line11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line11.Border.TopColor = System.Drawing.Color.Black;
            this.line11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line11.Height = 0.565F;
            this.line11.Left = 7.8125F;
            this.line11.LineWeight = 1F;
            this.line11.Name = "line11";
            this.line11.Top = 0.56F;
            this.line11.Width = 0F;
            this.line11.X1 = 7.8125F;
            this.line11.X2 = 7.8125F;
            this.line11.Y1 = 0.56F;
            this.line11.Y2 = 1.125F;
            // 
            // line12
            // 
            this.line12.Border.BottomColor = System.Drawing.Color.Black;
            this.line12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line12.Border.LeftColor = System.Drawing.Color.Black;
            this.line12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line12.Border.RightColor = System.Drawing.Color.Black;
            this.line12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line12.Border.TopColor = System.Drawing.Color.Black;
            this.line12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line12.Height = 0.565F;
            this.line12.Left = 8.8125F;
            this.line12.LineWeight = 1F;
            this.line12.Name = "line12";
            this.line12.Top = 0.56F;
            this.line12.Width = 0F;
            this.line12.X1 = 8.8125F;
            this.line12.X2 = 8.8125F;
            this.line12.Y1 = 0.56F;
            this.line12.Y2 = 1.125F;
            // 
            // line1
            // 
            this.line1.Border.BottomColor = System.Drawing.Color.Black;
            this.line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.LeftColor = System.Drawing.Color.Black;
            this.line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.RightColor = System.Drawing.Color.Black;
            this.line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Border.TopColor = System.Drawing.Color.Black;
            this.line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line1.Height = 0F;
            this.line1.Left = 0.125F;
            this.line1.LineWeight = 1F;
            this.line1.Name = "line1";
            this.line1.Top = 1.125F;
            this.line1.Width = 8.6875F;
            this.line1.X1 = 0.125F;
            this.line1.X2 = 8.8125F;
            this.line1.Y1 = 1.125F;
            this.line1.Y2 = 1.125F;
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
            this.line2.Height = 0.565F;
            this.line2.Left = 0.125F;
            this.line2.LineWeight = 1F;
            this.line2.Name = "line2";
            this.line2.Top = 0.56F;
            this.line2.Width = 0F;
            this.line2.X1 = 0.125F;
            this.line2.X2 = 0.125F;
            this.line2.Y1 = 0.56F;
            this.line2.Y2 = 1.125F;
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
            this.line4.LineWeight = 3F;
            this.line4.Name = "line4";
            this.line4.Top = 0F;
            this.line4.Width = 10.8125F;
            this.line4.X1 = 0F;
            this.line4.X2 = 10.8125F;
            this.line4.Y1 = 0F;
            this.line4.Y2 = 0F;
            // 
            // Label14
            // 
            this.Label14.Border.BottomColor = System.Drawing.Color.Black;
            this.Label14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label14.Border.LeftColor = System.Drawing.Color.Black;
            this.Label14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label14.Border.RightColor = System.Drawing.Color.Black;
            this.Label14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label14.Border.TopColor = System.Drawing.Color.Black;
            this.Label14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label14.Height = 0.125F;
            this.Label14.HyperLink = "";
            this.Label14.Left = 0.125F;
            this.Label14.Name = "Label14";
            this.Label14.Style = "font-size: 8pt; ";
            this.Label14.Text = "���_�@�F";
            this.Label14.Top = 0.125F;
            this.Label14.Width = 0.5F;
            // 
            // Label15
            // 
            this.Label15.Border.BottomColor = System.Drawing.Color.Black;
            this.Label15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label15.Border.LeftColor = System.Drawing.Color.Black;
            this.Label15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label15.Border.RightColor = System.Drawing.Color.Black;
            this.Label15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label15.Border.TopColor = System.Drawing.Color.Black;
            this.Label15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label15.Height = 0.125F;
            this.Label15.HyperLink = "";
            this.Label15.Left = 0.125F;
            this.Label15.Name = "Label15";
            this.Label15.Style = "font-size: 8pt; ";
            this.Label15.Text = "���Ӑ�F";
            this.Label15.Top = 0.3125F;
            this.Label15.Width = 0.5F;
            // 
            // line13
            // 
            this.line13.Border.BottomColor = System.Drawing.Color.Black;
            this.line13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line13.Border.LeftColor = System.Drawing.Color.Black;
            this.line13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line13.Border.RightColor = System.Drawing.Color.Black;
            this.line13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line13.Border.TopColor = System.Drawing.Color.Black;
            this.line13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line13.Height = 0F;
            this.line13.Left = 0.125F;
            this.line13.LineWeight = 1F;
            this.line13.Name = "line13";
            this.line13.Top = 0.875F;
            this.line13.Width = 8.6875F;
            this.line13.X1 = 0.125F;
            this.line13.X2 = 8.8125F;
            this.line13.Y1 = 0.875F;
            this.line13.Y2 = 0.875F;
            // 
            // TextBox33
            // 
            this.TextBox33.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox33.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox33.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox33.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox33.Height = 0.2007874F;
            this.TextBox33.Left = 5.625F;
            this.TextBox33.Name = "TextBox33";
            this.TextBox33.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; vertical-align: top; ";
            this.TextBox33.Text = "�c��";
            this.TextBox33.Top = 1.25F;
            this.TextBox33.Width = 0.938F;
            // 
            // TextBox32
            // 
            this.TextBox32.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox32.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox32.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox32.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox32.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox32.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox32.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox32.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox32.Height = 0.2007874F;
            this.TextBox32.Left = 2.813F;
            this.TextBox32.Name = "TextBox32";
            this.TextBox32.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; vertical-align: top; ";
            this.TextBox32.Text = "�����";
            this.TextBox32.Top = 1.25F;
            this.TextBox32.Width = 0.9212598F;
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
            this.label4.Height = 0.2007874F;
            this.label4.HyperLink = "";
            this.label4.Left = 0.125F;
            this.label4.Name = "label4";
            this.label4.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; vertical-align: top; ";
            this.label4.Text = "���t";
            this.label4.Top = 1.25F;
            this.label4.Width = 0.6220472F;
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
            this.label5.Height = 0.2007874F;
            this.label5.HyperLink = "";
            this.label5.Left = 0.875F;
            this.label5.Name = "label5";
            this.label5.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; vertical-align: top; ";
            this.label5.Text = "�`�[�ԍ�";
            this.label5.Top = 1.25F;
            this.label5.Width = 0.6102362F;
            // 
            // Label32
            // 
            this.Label32.Border.BottomColor = System.Drawing.Color.Black;
            this.Label32.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label32.Border.LeftColor = System.Drawing.Color.Black;
            this.Label32.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label32.Border.RightColor = System.Drawing.Color.Black;
            this.Label32.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label32.Border.TopColor = System.Drawing.Color.Black;
            this.Label32.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label32.Height = 0.125F;
            this.Label32.HyperLink = "";
            this.Label32.Left = 1.5F;
            this.Label32.Name = "Label32";
            this.Label32.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; vertical-align: top; ";
            this.Label32.Text = "�敪";
            this.Label32.Top = 1.25F;
            this.Label32.Width = 0.3125F;
            // 
            // Label34
            // 
            this.Label34.Border.BottomColor = System.Drawing.Color.Black;
            this.Label34.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label34.Border.LeftColor = System.Drawing.Color.Black;
            this.Label34.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label34.Border.RightColor = System.Drawing.Color.Black;
            this.Label34.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label34.Border.TopColor = System.Drawing.Color.Black;
            this.Label34.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label34.Height = 0.2007874F;
            this.Label34.HyperLink = "";
            this.Label34.Left = 1.875F;
            this.Label34.Name = "Label34";
            this.Label34.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; vertical-align: top; ";
            this.Label34.Text = "������z";
            this.Label34.Top = 1.25F;
            this.Label34.Width = 0.9212598F;
            // 
            // TextBox47
            // 
            this.TextBox47.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox47.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox47.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox47.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox47.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox47.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox47.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox47.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox47.Height = 0.2007874F;
            this.TextBox47.Left = 3.75F;
            this.TextBox47.Name = "TextBox47";
            this.TextBox47.Style = "text-align: right; font-weight: bold; font-size: 8.25pt; vertical-align: top; ";
            this.TextBox47.Text = "�����z";
            this.TextBox47.Top = 1.25F;
            this.TextBox47.Width = 0.9212598F;
            // 
            // TextBox48
            // 
            this.TextBox48.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox48.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox48.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox48.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox48.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox48.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox48.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox48.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox48.Height = 0.1875F;
            this.TextBox48.Left = 7.813F;
            this.TextBox48.Name = "TextBox48";
            this.TextBox48.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; vertical-align: top; ";
            this.TextBox48.Text = "��  �l";
            this.TextBox48.Top = 1.25F;
            this.TextBox48.Width = 0.9375F;
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
            this.textBox1.Height = 0.125F;
            this.textBox1.Left = 4.75F;
            this.textBox1.Name = "textBox1";
            this.textBox1.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; vertical-align: top; ";
            this.textBox1.Text = "��`����";
            this.textBox1.Top = 1.25F;
            this.textBox1.Width = 0.75F;
            // 
            // label8
            // 
            this.label8.Border.BottomColor = System.Drawing.Color.Black;
            this.label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Border.LeftColor = System.Drawing.Color.Black;
            this.label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Border.RightColor = System.Drawing.Color.Black;
            this.label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Border.TopColor = System.Drawing.Color.Black;
            this.label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label8.Height = 0.1875F;
            this.label8.HyperLink = "";
            this.label8.Left = 6.594F;
            this.label8.Name = "label8";
            this.label8.Style = "text-align: left; font-weight: bold; font-size: 8.25pt; vertical-align: top; ";
            this.label8.Text = "�����`�[�ԍ�";
            this.label8.Top = 1.25F;
            this.label8.Width = 0.9375F;
            // 
            // line14
            // 
            this.line14.Border.BottomColor = System.Drawing.Color.Black;
            this.line14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line14.Border.LeftColor = System.Drawing.Color.Black;
            this.line14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line14.Border.RightColor = System.Drawing.Color.Black;
            this.line14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line14.Border.TopColor = System.Drawing.Color.Black;
            this.line14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line14.Height = 0F;
            this.line14.Left = 0F;
            this.line14.LineWeight = 1F;
            this.line14.Name = "line14";
            this.line14.Top = 1.5F;
            this.line14.Width = 10.75F;
            this.line14.X1 = 0F;
            this.line14.X2 = 10.75F;
            this.line14.Y1 = 1.5F;
            this.line14.Y2 = 1.5F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanShrink = true;
            this.TitleFooter.Height = 0F;
            this.TitleFooter.KeepTogether = true;
            this.TitleFooter.Name = "TitleFooter";
            // 
            // SectionHeader
            // 
            this.SectionHeader.DataField = "AddUpSecCode";
            this.SectionHeader.Height = 0F;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            // 
            // SectionFooter
            // 
            this.SectionFooter.Height = 0F;
            this.SectionFooter.Name = "SectionFooter";
            // 
            // CustomerHeader
            // 
            this.CustomerHeader.DataField = "ClaimCode";
            this.CustomerHeader.Height = 0F;
            this.CustomerHeader.Name = "CustomerHeader";
            this.CustomerHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.CustomerHeader.Format += new System.EventHandler(this.CustomerHeader_Format);
            // 
            // CustomerFooter
            // 
            this.CustomerFooter.Height = 0F;
            this.CustomerFooter.Name = "CustomerFooter";
            // 
            // PMHNB02193P_02A4C
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
            this.PrintWidth = 10.8F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.AddUpDateHeader);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.CustomerHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.TitleFooter);
            this.Sections.Add(this.CustomerFooter);
            this.Sections.Add(this.SectionFooter);
            this.Sections.Add(this.AddUpDateFooter);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            this.ReportEnd += new System.EventHandler(this.PMHNB02193P_02A4C_ReportEnd);
            this.ReportStart += new System.EventHandler(this.PMHNB02193P_02A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TIME)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PAGE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeyAddUpDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeyAddUpSecCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeyCustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlitTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClaimSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintAddUpDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpSecName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastTimeDemand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeDmdNrml)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeTtlBlcDmd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisTimeSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisRgdsDis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisTimeSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OfsThisSalesTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClaimCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThisSalesTaxTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfCalDemandPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpSecCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

		// ===============================================================================
		// �����g�p�֐�
		// ===============================================================================
		#region private methods		
		/// <summary>
		/// �r���\����\�����䏈��
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="eArgs">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �Z�N�V�����̃f�[�^�����[�h����A�����ꂽ��ɔ������܂��B</br>
		/// <br>Programmer	: 20081 �D�c �E�l</br>
        /// <br>Date		: 2007.11.14</br>
		/// </remarks>
		private void SetVisibleRuledLine(ref Section sections)
		{
			// �r���L������
			bool isRuledLine = (this._printInfo.frycd == 1);
			

			for (int i = 0; i < sections.Controls.Count; i++)
			{
				if (sections.Controls[i] is Line)
				{
					Line line = (Line)sections.Controls[i];
					
					// �\����\���Ώۂ̌r����
					if (line.Name.IndexOf("RuledLine") != -1)
					{
						line.Visible = isRuledLine; 
					}
				}
			}
		}
		#endregion

        private void PageHeader_Format(object sender, EventArgs e)
        {
            // KEY���ڕۑ�
            this._keyAddUpdate = TStrConv.StrToIntDef(this.KeyAddUpDate.Text, 0);
            this._keyAddUpSecCode = TStrConv.StrToIntDef(this.KeyAddUpSecCode.Text, 0);
            this._keyCustomerCode = TStrConv.StrToIntDef(this.KeyCustomerCode.Text, 0);

            DateTime now = DateTime.Now;

            this.DATE.Text = TDateTime.DateTimeToString("YYYY/MM/DD", now);

            // �쐬����
            this.TIME.Text = now.ToString("HH:mm");
        }

	}
}
