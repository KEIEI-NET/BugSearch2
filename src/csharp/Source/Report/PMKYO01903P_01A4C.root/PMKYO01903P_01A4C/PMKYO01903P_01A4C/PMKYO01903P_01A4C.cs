//**********************************************************************//
// System			:	PM.NS   									    //
// Sub System		:													//
// Program name		:	�G���[�ڍ׈���t�H�[���N���X					//
//					:	PMKYO01903P_01A4C.DLL							//
// Name Space		:	Broadleaf.Application.UIData					//
// Programmer		:	�v��											//
// Date				:	2011.07.29										//
//----------------------------------------------------------------------//
// Update Note		:	2011.09.16 #25226 �d����������s���Ȃ��悤�ɏC��//
//----------------------------------------------------------------------//
//                 Copyright(c)2011 Broadleaf Co.,Ltd.                  //
//**********************************************************************//
using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Specialized;
using DataDynamics.ActiveReports;
using Broadleaf.Application.Common;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;
using System.Collections.Generic;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// �G���[�ڍ׈���t�H�[���N���X
	/// </summary>
	/// <remarks>
    /// <br>Note         : �G���[�ڍׂ̃t�H�[���N���X�ł��B</br>
	/// <br>Programmer   : �v��</br>
	/// <br>Date         : 2011.07.29</br>
	/// </remarks>
	public class PMKYO01903P_01A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
	{
		#region �� Constructor
		/// <summary>
        /// �G���[�ڍ׃t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note         : �G���[�ڍ׃t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer   : �v��</br>
        /// <br>Date         : 2011.07.29</br>
		/// </remarks>
		public PMKYO01903P_01A4C()
		{
			InitializeComponent();
		}
		#endregion �� Constructor

		#region �� Private Member
		private int _printCount;									    // ��������p�J�E���^
		private int					_extraCondHeadOutDiv;			    // ���o�����w�b�_�o�͋敪
		private StringCollection	_extraConditions;				    // ���o����
		private int					_pageFooterOutCode;				    // �t�b�^�[�o�͋敪
		private StringCollection	_pageFooters;					    // �t�b�^�[���b�Z�[�W
		private	SFCMN06002C			_printInfo;						    // ������N���X
		private string				_pageHeaderTitle;				    // �t�H�[���^�C�g��
		private string				_pageHeaderSortOderTitle;		    // �\�[�g��
		// �w�b�_�[�T�u���|�[�g�錾
		ListCommon_ExtraHeader _rptExtraHeader		= null;
		// �t�b�^�[���|�[�g�錾
        ListCommon_PageFooter _rptPageFooter = null;
        private Line line2;
        private PageHeader PageHeader;
        private TextBox tb_PrintDate;
        private Label Label_Page;
        private TextBox tb_PrintPage;
        private TextBox tb_PrintTime;
        private Label label1;
        private PageFooter PageFooter;
        private TextBox PageFooters1;
        private Label label10;
        private Line line3;
        private TextBox txt1;
        private TextBox txt2;
        private TextBox txt3;
        private TextBox txt4;
        private TextBox txt5;
        private TextBox txt6;
        private Label label_sectionCode;
        private Label label_date;
        private Label label_customerCode;
        private Label label_error;
        private Label label_no;
        private Label label_noFlg;
		// Dispose�`�F�b�N�p�t���O
		bool disposed = false;

		#endregion �� Private Member

		#region �� Dispose(override)
		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(!this.disposed)
			{
				try
				{
					if(disposing)
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
			set{ _pageHeaderSortOderTitle = value; }
		}

		/// <summary>
		/// ���o�����w�b�_�o�͋敪[0:���y�[�W,1:�擪�y�[�W�̂�]
		/// </summary>
		public int ExtraCondHeadOutDiv
		{
			set{ _extraCondHeadOutDiv = value; }
		}
		
		/// <summary>
		/// ���o�����w�b�_�[����
		/// </summary>
		public StringCollection ExtraConditions
		{
			set{ this._extraConditions = value; }
		}

		/// <summary>
		/// �t�b�^�[�o�͋敪
		/// </summary>
		public int PageFooterOutCode
		{
			set{ this._pageFooterOutCode = value; }
		}
		
		/// <summary>
		/// �t�b�^�o�͕�
		/// </summary>
		public StringCollection PageFooters
		{
			set{ this._pageFooters = value; }
		}

		/// <summary>
		/// �������
		/// </summary>
		public SFCMN06002C PrintInfo
		{
			set
			{
				this._printInfo			= value;
			}
		}

		/// <summary>
		/// ���̑��f�[�^
		/// </summary>
		public ArrayList OtherDataList
		{
			set	{ }
		}

		/// <summary>
		/// ���[�T�u�^�C�g��
		/// </summary>
		public string PageHeaderSubtitle
		{
			set{ this._pageHeaderTitle = value;}
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
        /// <br>Programmer	: �v��</br>
        /// <br>Date		: 2011.07.29</br>
		/// </remarks>
		private void SetOfReportMembersOutput()
		{
			this._printCount = 0;
        }
		#endregion �� ���|�[�g�v�f�o�͐ݒ�

		#endregion

		#region �� Control Event
		#region �� PMKYO01903P_01A4C_ReportStart Event
		/// <summary>
		/// PMKYO01903P_01A4C_ReportStart Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="eArgs">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: ���|�[�g�J�n���̃C�x���g�ł��B</br>
        /// <br>Programmer	: �v��</br>
		/// <br>Date		: 2011.07.29</br>
		/// </remarks>
		private void PMKYO01903P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
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
        /// <br>Programmer	: �v��</br>
		/// <br>Date		: 2011.07.29</br>
		/// </remarks>
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			// �쐬���t
            this.tb_PrintDate.Text = TDateTime.DateTimeToString("YYYY/MM/DD", DateTime.Now);
			// �쐬����
			this.tb_PrintTime.Text   = DateTime.Now.ToString("HH:mm");

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
		/// <br>Programmer	: �v��</br>
        /// <br>Date		: 2011.07.29</br>
		/// </remarks>
		private void Detail_BeforePrint ( object sender, System.EventArgs eArgs )
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
		/// <br>Programmer  : �v��</br>
        /// <br>Date		: 2011.07.29</br>
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

		#endregion �� Control Event

        #region �� ActiveReports Designer generated code
        private DataDynamics.ActiveReports.GroupHeader TitleHeader;
        private DataDynamics.ActiveReports.Detail Detail;
        private DataDynamics.ActiveReports.GroupFooter TitleFooter;
        /// <summary>
        /// InitializeComponent
        /// </summary>
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKYO01903P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.txt1 = new DataDynamics.ActiveReports.TextBox();
            this.txt2 = new DataDynamics.ActiveReports.TextBox();
            this.txt3 = new DataDynamics.ActiveReports.TextBox();
            this.txt4 = new DataDynamics.ActiveReports.TextBox();
            this.txt5 = new DataDynamics.ActiveReports.TextBox();
            this.txt6 = new DataDynamics.ActiveReports.TextBox();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.label_sectionCode = new DataDynamics.ActiveReports.Label();
            this.label_date = new DataDynamics.ActiveReports.Label();
            this.label_customerCode = new DataDynamics.ActiveReports.Label();
            this.label_error = new DataDynamics.ActiveReports.Label();
            this.label_no = new DataDynamics.ActiveReports.Label();
            this.label_noFlg = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label_Page = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.label1 = new DataDynamics.ActiveReports.Label();
            this.label10 = new DataDynamics.ActiveReports.Label();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.PageFooters1 = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_sectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_date)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_customerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_no)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_noFlg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_Page)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageFooters1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.txt1,
            this.txt2,
            this.txt3,
            this.txt4,
            this.txt5,
            this.txt6});
            this.Detail.Height = 0.325F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // txt1
            // 
            this.txt1.Border.BottomColor = System.Drawing.Color.Black;
            this.txt1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt1.Border.LeftColor = System.Drawing.Color.Black;
            this.txt1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt1.Border.RightColor = System.Drawing.Color.Black;
            this.txt1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt1.Border.TopColor = System.Drawing.Color.Black;
            this.txt1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt1.DataField = "noFlg";
            this.txt1.Height = 0.1875F;
            this.txt1.Left = 0.125F;
            this.txt1.Name = "txt1";
            this.txt1.Style = "ddo-char-set: 1; font-size: 10.5pt; ";
            this.txt1.Text = "����";
            this.txt1.Top = 0.0625F;
            this.txt1.Width = 0.6875F;
            // 
            // txt2
            // 
            this.txt2.Border.BottomColor = System.Drawing.Color.Black;
            this.txt2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt2.Border.LeftColor = System.Drawing.Color.Black;
            this.txt2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt2.Border.RightColor = System.Drawing.Color.Black;
            this.txt2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt2.Border.TopColor = System.Drawing.Color.Black;
            this.txt2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt2.DataField = "no";
            this.txt2.Height = 0.1875F;
            this.txt2.Left = 1.0625F;
            this.txt2.Name = "txt2";
            this.txt2.Style = "ddo-char-set: 1; font-size: 10.5pt; ";
            this.txt2.Text = "20000100";
            this.txt2.Top = 0.0625F;
            this.txt2.Width = 1.125F;
            // 
            // txt3
            // 
            this.txt3.Border.BottomColor = System.Drawing.Color.Black;
            this.txt3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt3.Border.LeftColor = System.Drawing.Color.Black;
            this.txt3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt3.Border.RightColor = System.Drawing.Color.Black;
            this.txt3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt3.Border.TopColor = System.Drawing.Color.Black;
            this.txt3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt3.DataField = "date";
            this.txt3.Height = 0.1875F;
            this.txt3.Left = 2.375F;
            this.txt3.Name = "txt3";
            this.txt3.Style = "ddo-char-set: 1; font-size: 10.5pt; ";
            this.txt3.Text = "2011/07/11";
            this.txt3.Top = 0.0625F;
            this.txt3.Width = 1.375F;
            // 
            // txt4
            // 
            this.txt4.Border.BottomColor = System.Drawing.Color.Black;
            this.txt4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt4.Border.LeftColor = System.Drawing.Color.Black;
            this.txt4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt4.Border.RightColor = System.Drawing.Color.Black;
            this.txt4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt4.Border.TopColor = System.Drawing.Color.Black;
            this.txt4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt4.DataField = "sectionInfo";
            this.txt4.Height = 0.1875F;
            this.txt4.Left = 3.8125F;
            this.txt4.Name = "txt4";
            this.txt4.Style = "ddo-char-set: 1; font-size: 10.5pt; white-space: nowrap; ";
            this.txt4.Text = "02 ���_�O�Q";
            this.txt4.Top = 0.0625F;
            this.txt4.Width = 1.875F;
            // 
            // txt5
            // 
            this.txt5.Border.BottomColor = System.Drawing.Color.Black;
            this.txt5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt5.Border.LeftColor = System.Drawing.Color.Black;
            this.txt5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt5.Border.RightColor = System.Drawing.Color.Black;
            this.txt5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt5.Border.TopColor = System.Drawing.Color.Black;
            this.txt5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt5.DataField = "customerInfo";
            this.txt5.Height = 0.1875F;
            this.txt5.Left = 5.75F;
            this.txt5.Name = "txt5";
            this.txt5.Style = "ddo-char-set: 1; font-size: 10.5pt; white-space: nowrap; ";
            this.txt5.Text = "200001 ���Ӑ�02";
            this.txt5.Top = 0.0625F;
            this.txt5.Width = 2.9375F;
            // 
            // txt6
            // 
            this.txt6.Border.BottomColor = System.Drawing.Color.Black;
            this.txt6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt6.Border.LeftColor = System.Drawing.Color.Black;
            this.txt6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt6.Border.RightColor = System.Drawing.Color.Black;
            this.txt6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt6.Border.TopColor = System.Drawing.Color.Black;
            this.txt6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txt6.DataField = "error";
            this.txt6.Height = 0.1875F;
            this.txt6.Left = 8.75F;
            this.txt6.Name = "txt6";
            this.txt6.Style = "ddo-char-set: 1; font-size: 10.5pt; white-space: nowrap; ";
            this.txt6.Text = "�O�񌎎��X�V���ȑO�ł�";
            this.txt6.Top = 0.0625F;
            this.txt6.Width = 2.3125F;
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line2,
            this.label_sectionCode,
            this.label_date,
            this.label_customerCode,
            this.label_error,
            this.label_no,
            this.label_noFlg});
            this.TitleHeader.Height = 0.325F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
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
            this.line2.Left = 0.05F;
            this.line2.LineWeight = 2F;
            this.line2.Name = "line2";
            this.line2.Top = 0.25F;
            this.line2.Width = 11.1F;
            this.line2.X1 = 0.05F;
            this.line2.X2 = 11.15F;
            this.line2.Y1 = 0.25F;
            this.line2.Y2 = 0.25F;
            // 
            // label_sectionCode
            // 
            this.label_sectionCode.Border.BottomColor = System.Drawing.Color.Black;
            this.label_sectionCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_sectionCode.Border.LeftColor = System.Drawing.Color.Black;
            this.label_sectionCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_sectionCode.Border.RightColor = System.Drawing.Color.Black;
            this.label_sectionCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_sectionCode.Border.TopColor = System.Drawing.Color.Black;
            this.label_sectionCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_sectionCode.Height = 0.188F;
            this.label_sectionCode.HyperLink = "";
            this.label_sectionCode.Left = 3.8125F;
            this.label_sectionCode.MultiLine = false;
            this.label_sectionCode.Name = "label_sectionCode";
            this.label_sectionCode.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.5pt; font-fam" +
                "ily: �l�r ����; vertical-align: top; ";
            this.label_sectionCode.Text = "���_";
            this.label_sectionCode.Top = 0.0625F;
            this.label_sectionCode.Width = 0.563F;
            // 
            // label_date
            // 
            this.label_date.Border.BottomColor = System.Drawing.Color.Black;
            this.label_date.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_date.Border.LeftColor = System.Drawing.Color.Black;
            this.label_date.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_date.Border.RightColor = System.Drawing.Color.Black;
            this.label_date.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_date.Border.TopColor = System.Drawing.Color.Black;
            this.label_date.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_date.Height = 0.188F;
            this.label_date.HyperLink = "";
            this.label_date.Left = 2.375F;
            this.label_date.MultiLine = false;
            this.label_date.Name = "label_date";
            this.label_date.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.5pt; font-fam" +
                "ily: �l�r ����; vertical-align: top; ";
            this.label_date.Text = "���t";
            this.label_date.Top = 0.0625F;
            this.label_date.Width = 0.563F;
            // 
            // label_customerCode
            // 
            this.label_customerCode.Border.BottomColor = System.Drawing.Color.Black;
            this.label_customerCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_customerCode.Border.LeftColor = System.Drawing.Color.Black;
            this.label_customerCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_customerCode.Border.RightColor = System.Drawing.Color.Black;
            this.label_customerCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_customerCode.Border.TopColor = System.Drawing.Color.Black;
            this.label_customerCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_customerCode.Height = 0.1875F;
            this.label_customerCode.HyperLink = "";
            this.label_customerCode.Left = 5.75F;
            this.label_customerCode.MultiLine = false;
            this.label_customerCode.Name = "label_customerCode";
            this.label_customerCode.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.5pt; font-fam" +
                "ily: �l�r ����; vertical-align: top; ";
            this.label_customerCode.Text = "���Ӑ�/�d����";
            this.label_customerCode.Top = 0.0625F;
            this.label_customerCode.Width = 1.5625F;
            // 
            // label_error
            // 
            this.label_error.Border.BottomColor = System.Drawing.Color.Black;
            this.label_error.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_error.Border.LeftColor = System.Drawing.Color.Black;
            this.label_error.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_error.Border.RightColor = System.Drawing.Color.Black;
            this.label_error.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_error.Border.TopColor = System.Drawing.Color.Black;
            this.label_error.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_error.Height = 0.1875F;
            this.label_error.HyperLink = "";
            this.label_error.Left = 8.75F;
            this.label_error.MultiLine = false;
            this.label_error.Name = "label_error";
            this.label_error.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.5pt; font-fam" +
                "ily: �l�r ����; vertical-align: top; ";
            this.label_error.Text = "�G���[���e";
            this.label_error.Top = 0.0625F;
            this.label_error.Width = 1.5F;
            // 
            // label_no
            // 
            this.label_no.Border.BottomColor = System.Drawing.Color.Black;
            this.label_no.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_no.Border.LeftColor = System.Drawing.Color.Black;
            this.label_no.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_no.Border.RightColor = System.Drawing.Color.Black;
            this.label_no.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_no.Border.TopColor = System.Drawing.Color.Black;
            this.label_no.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_no.Height = 0.1875F;
            this.label_no.HyperLink = "";
            this.label_no.Left = 1.0625F;
            this.label_no.MultiLine = false;
            this.label_no.Name = "label_no";
            this.label_no.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.5pt; font-fam" +
                "ily: �l�r ����; vertical-align: top; ";
            this.label_no.Text = "�`�[�ԍ�";
            this.label_no.Top = 0.0625F;
            this.label_no.Width = 0.75F;
            // 
            // label_noFlg
            // 
            this.label_noFlg.Border.BottomColor = System.Drawing.Color.Black;
            this.label_noFlg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_noFlg.Border.LeftColor = System.Drawing.Color.Black;
            this.label_noFlg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_noFlg.Border.RightColor = System.Drawing.Color.Black;
            this.label_noFlg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_noFlg.Border.TopColor = System.Drawing.Color.Black;
            this.label_noFlg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_noFlg.Height = 0.1875F;
            this.label_noFlg.HyperLink = "";
            this.label_noFlg.Left = 0.125F;
            this.label_noFlg.MultiLine = false;
            this.label_noFlg.Name = "label_noFlg";
            this.label_noFlg.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.5pt; font-fam" +
                "ily: �l�r ����; vertical-align: top; ";
            this.label_noFlg.Text = "�`�[";
            this.label_noFlg.Top = 0.0625F;
            this.label_noFlg.Width = 0.4375F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanShrink = true;
            this.TitleFooter.Height = 0F;
            this.TitleFooter.KeepTogether = true;
            this.TitleFooter.Name = "TitleFooter";
            this.TitleFooter.Visible = false;
            // 
            // PageHeader
            // 
            this.PageHeader.CanShrink = true;
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.tb_PrintDate,
            this.Label_Page,
            this.tb_PrintPage,
            this.tb_PrintTime,
            this.label1,
            this.label10,
            this.line3});
            this.PageHeader.Height = 0.4895833F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
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
            this.tb_PrintDate.Height = 0.25F;
            this.tb_PrintDate.Left = 8.4375F;
            this.tb_PrintDate.MultiLine = false;
            this.tb_PrintDate.Name = "tb_PrintDate";
            this.tb_PrintDate.OutputFormat = resources.GetString("tb_PrintDate.OutputFormat");
            this.tb_PrintDate.Style = "ddo-char-set: 1; font-size: 11.5pt; font-family: �l�r ����; vertical-align: top; ";
            this.tb_PrintDate.Text = "2011/07/19";
            this.tb_PrintDate.Top = 0.1875F;
            this.tb_PrintDate.Width = 0.9375F;
            // 
            // Label_Page
            // 
            this.Label_Page.Border.BottomColor = System.Drawing.Color.Black;
            this.Label_Page.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Page.Border.LeftColor = System.Drawing.Color.Black;
            this.Label_Page.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Page.Border.RightColor = System.Drawing.Color.Black;
            this.Label_Page.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Page.Border.TopColor = System.Drawing.Color.Black;
            this.Label_Page.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Page.Height = 0.25F;
            this.Label_Page.HyperLink = "";
            this.Label_Page.Left = 10.0625F;
            this.Label_Page.MultiLine = false;
            this.Label_Page.Name = "Label_Page";
            this.Label_Page.Style = "ddo-char-set: 1; font-size: 11.5pt; font-family: �l�r ����; vertical-align: top; ";
            this.Label_Page.Text = "�y�[�W:";
            this.Label_Page.Top = 0.1875F;
            this.Label_Page.Width = 0.625F;
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
            this.tb_PrintPage.Height = 0.25F;
            this.tb_PrintPage.Left = 10.6875F;
            this.tb_PrintPage.MultiLine = false;
            this.tb_PrintPage.Name = "tb_PrintPage";
            this.tb_PrintPage.OutputFormat = resources.GetString("tb_PrintPage.OutputFormat");
            this.tb_PrintPage.RightToLeft = true;
            this.tb_PrintPage.Style = "ddo-char-set: 1; text-align: right; font-size: 11.5pt; font-family: �l�r ����; vertic" +
                "al-align: top; ";
            this.tb_PrintPage.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.tb_PrintPage.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.tb_PrintPage.Text = "1";
            this.tb_PrintPage.Top = 0.1875F;
            this.tb_PrintPage.Width = 0.375F;
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
            this.tb_PrintTime.Height = 0.25F;
            this.tb_PrintTime.Left = 9.375F;
            this.tb_PrintTime.Name = "tb_PrintTime";
            this.tb_PrintTime.Style = "ddo-char-set: 1; font-size: 11.5pt; ";
            this.tb_PrintTime.Text = "16:11";
            this.tb_PrintTime.Top = 0.1875F;
            this.tb_PrintTime.Width = 0.5F;
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
            this.label1.Height = 0.25F;
            this.label1.HyperLink = "";
            this.label1.Left = 7.5625F;
            this.label1.MultiLine = false;
            this.label1.Name = "label1";
            this.label1.Style = "ddo-char-set: 1; font-size: 11.5pt; font-family: �l�r ����; vertical-align: top; ";
            this.label1.Text = "�쐬���t�F";
            this.label1.Top = 0.1875F;
            this.label1.Width = 0.875F;
            // 
            // label10
            // 
            this.label10.Border.BottomColor = System.Drawing.Color.Black;
            this.label10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Border.LeftColor = System.Drawing.Color.Black;
            this.label10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Border.RightColor = System.Drawing.Color.Black;
            this.label10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Border.TopColor = System.Drawing.Color.Black;
            this.label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label10.Height = 0.25F;
            this.label10.HyperLink = "";
            this.label10.Left = 0.25F;
            this.label10.MultiLine = false;
            this.label10.Name = "label10";
            this.label10.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-style: normal; font-" +
                "size: 14.25pt; font-family: �l�r ����; vertical-align: middle; ";
            this.label10.Text = "�G���[�ڍ�";
            this.label10.Top = 0.1875F;
            this.label10.Width = 1.8125F;
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
            this.line3.Left = 0.05F;
            this.line3.LineWeight = 1F;
            this.line3.Name = "line3";
            this.line3.Top = 0.4375F;
            this.line3.Width = 11.1F;
            this.line3.X1 = 0.05F;
            this.line3.X2 = 11.15F;
            this.line3.Y1 = 0.4375F;
            this.line3.Y2 = 0.4375F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.PageFooters1});
            this.PageFooter.Height = 0.01041667F;
            this.PageFooter.Name = "PageFooter";
            // 
            // PageFooters1
            // 
            this.PageFooters1.Border.BottomColor = System.Drawing.Color.Black;
            this.PageFooters1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters1.Border.LeftColor = System.Drawing.Color.Black;
            this.PageFooters1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters1.Border.RightColor = System.Drawing.Color.Black;
            this.PageFooters1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters1.Border.TopColor = System.Drawing.Color.Black;
            this.PageFooters1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PageFooters1.Height = 0.125F;
            this.PageFooters1.Left = 8.0625F;
            this.PageFooters1.MultiLine = false;
            this.PageFooters1.Name = "PageFooters1";
            this.PageFooters1.OutputFormat = resources.GetString("PageFooters1.OutputFormat");
            this.PageFooters1.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: �l�r ����; vertical-" +
                "align: top; ";
            this.PageFooters1.Text = null;
            this.PageFooters1.Top = 0F;
            this.PageFooters1.Width = 2.75F;
            // 
            // PMKYO01903P_01A4C
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
            this.PrintWidth = 11.25F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.TitleFooter);
            this.Sections.Add(this.PageFooter);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 16pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: Times New Roman; font-style: italic; font-variant: inherit; font-wei" +
                        "ght: bold; font-size: 14pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule("font-family: inherit; font-style: inherit; font-variant: inherit; font-weight: bo" +
                        "ld; font-size: 13pt; font-size-adjust: inherit; font-stretch: inherit; ", "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.PMKYO01903P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.txt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_sectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_date)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_customerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_no)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_noFlg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_Page)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageFooters1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion                 
	}
}