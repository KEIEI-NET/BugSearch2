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
	/// ���j���[����ݒ�i����j�t�H�[���N���X
	/// </summary>
	/// <remarks>
    /// <br>Note         : ���j���[����ݒ�i����j�̃t�H�[���N���X�ł��B</br>
	/// <br>Programmer   : 30747 �O�� �L��</br>
	/// <br>Date         : 2013/02/15</br>
	/// <br></br>
	/// </remarks>
	public class PMKHN02203P_01A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
	{
		#region �� Constructor
		/// <summary>
        /// ���j���[����ݒ�i����j�t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note         : ���j���[����ݒ�i����j�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer   : 30747 �O�� �L��</br>
        /// <br>Date         : 2013/02/15</br>
		/// </remarks>
		public PMKHN02203P_01A4C()
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
        private Label label_title1;
        private TextBox detail1;
        private TextBox detail2;
        private Label label_title2;
        private Label label_title3;
        private GroupHeader ExtraHeader;
        private GroupFooter ExtraFooter;
        private Label label_sort;
        private Label label12;
        private TextBox detail3;
        private GroupHeader groupHeader1;
        private GroupFooter groupFooter1;
        private Line line2;
        private SubReport Header_SubReport;
        private TextBox systemname;
        private TextBox rolegroupcode;
        private TextBox rolegroupname;
        private TextBox employeecode;
        private TextBox employeename;
        private GroupHeader groupHeader2;
        private GroupFooter groupFooter2;

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
				// TODO:  PMKHN02203P_01A4C.WatermarkMode getter ������ǉ����܂��B
				return 0;
			}
			set
			{
				// TODO:  PMKHN02203P_01A4C.WatermarkMode setter ������ǉ����܂��B
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
        /// <br>Programmer	: 30747 �O�� �L��</br>
        /// <br>Date		: 2013/02/15</br>
		/// </remarks>
		private void SetOfReportMembersOutput()
		{
			this._printCount = 0;
			// �󎚐ݒ� --------------------------------------------------------------------------------------
			
			// ���ڂ̖��̂��Z�b�g
			tb_ReportTitle.Text	= this._pageHeaderTitle;				// �T�u�^�C�g��

            switch(this._pageHeaderSortOderTitle)
            {
                case "0":
                {
                    label_sort.Text = "�o�͏��F���[�� - �V�X�e���@�\ - �]�ƈ�";
                    label_title1.Text = "���[��";
                    label_title2.Text = "�V�X�e���@�\";
                    label_title3.Text = "�]�ƈ�";
                    groupHeader1.DataField = "rolegroupcode";
                    groupHeader2.DataField = "systemname";
                    break;
                }
                case "1":
                {
                    label_sort.Text = "�o�͏��F�V�X�e���@�\ - ���[�� - �]�ƈ�";
                    label_title1.Text = "�V�X�e���@�\";
                    label_title2.Text = "���[��";
                    label_title3.Text = "�]�ƈ�";
                    groupHeader1.DataField = "systemname";
                    groupHeader2.DataField = "rolegroupcode";
                    break;
                }
                default:
                {
                    label_sort.Text = "�o�͏��F�]�ƈ� - �V�X�e���@�\ - ���[��";
                    label_title1.Text = "�]�ƈ�";
                    label_title2.Text = "�V�X�e���@�\";
                    label_title3.Text = "���[��";
                    groupHeader1.DataField = "employeename";
                    groupHeader2.DataField = "systemname";
                    break;
                }
            }

            // TODO : ���ו��̈�����ڂ̗L���A�^�C�g���ݒ�Ȃǂ��s���B

            
        }
        /// <summary>
        /// �͈͌����̎擾����
        /// </summary>
        /// <returns>�͈͌����iex.�S���`�U���Ȃ�΂R�j</returns>
        private int GetMonthRange(DateTime stYearMonth, DateTime edYearMonth)
        {
            int stMonth = stYearMonth.Month;
            int edMonth = edYearMonth.Month;

            if (edYearMonth.Year > stYearMonth.Year) {
                edMonth += 12;
            }

            return (edMonth - stMonth + 1);
        }
		#endregion �� ���|�[�g�v�f�o�͐ݒ�


		#region �� �O���[�v�T�v���X�֌W
		#region �� �O���[�v�T�v���X���f
		/// <summary>
		/// �O���[�v�T�v���X���f
		/// </summary>
		private void CheckGroupSuppression()
		{
            // TODO : �O���[�v�T�v���X�������L�q����B
            //        ��̓I�ȏ����菇�́A�@if�őO�sKEY�Ɣ�r���A�����Ȃ獀��.Visible=false�Ƃ���B
            //        �Ō�ɁA����s��KEY��ޔ�����B
		}
		#endregion
		#endregion
		#endregion

		#region �� Control Event

		#region �� PMKHN02203P_01A4C_ReportStart Event
		/// <summary>
		/// PMKHN02203P_01A4C_ReportStart Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="eArgs">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: ���|�[�g�J�n���̃C�x���g�ł��B</br>
        /// <br>Programmer	: 30747 �O�� �L��</br>
		/// <br>Date		: 2013/02/15</br>
		/// </remarks>
		private void PMKHN02203P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
			SetOfReportMembersOutput();
		}
		#endregion

		#region �� PMKHN02203P_01A4C_PageEnd Event
		/// <summary>
		/// PMKHN02203P_01A4C_PageEnd Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="eArgs">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: PMKHN02203P_01A4C_PageEnd Event</br>
        /// <br>Programmer	: 30747 �O�� �L��</br>
		/// <br>Date		: 2013/02/15</br>
		/// </remarks>
		private void PMKHN02203P_01A4C_PageEnd(object sender, System.EventArgs eArgs)
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
        /// <br>Programmer	: 30747 �O�� �L��</br>
		/// <br>Date		: 2013/02/15</br>
		/// </remarks>
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			// �쐬���t
            this.tb_PrintDate.Text = TDateTime.DateTimeToString("YYYY/MM/DD", DateTime.Now);
			// �쐬����
			this.tb_PrintTime.Text   = DateTime.Now.ToString("HH:mm");

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
        /// <br>Programmer	: 30747 �O�� �L��</br>
		/// <br>Date		: 2013/02/15</br>
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
			if ( this._rptExtraHeader == null)
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
		#endregion

		#region �� Detail_Format Event
		/// <summary>
		/// Detail_Format Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="eArgs">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: Detail�O���[�v�̃t�H�[�}�b�g�C�x���g�B</br>
		/// <br>Programmer	: 30747 �O�� �L��</br>
		/// <br>Date		: 2013/02/15</br>
		/// </remarks>
		private void Detail_Format(object sender, System.EventArgs eArgs)
		{
            switch (this._pageHeaderSortOderTitle)
            {
                case "0":   // ���[�� - �V�X�e���@�\ - �]�ƈ�
                    {
                        if (string.IsNullOrEmpty(employeecode.Text))
                        {
                            detail3.Text = employeecode.Text.Trim().PadLeft(4, ' ') + "  " + employeename.Text;
                        }
                        else
                        {
                            detail3.Text = employeecode.Text.Trim().PadLeft(4, '0') + "  " + employeename.Text;
                        }
                        break;
                    }
                case "1":   // �V�X�e���@�\ - ���[�� - �]�ƈ�
                    {
                        if (string.IsNullOrEmpty(employeecode.Text))
                        {
                            detail3.Text = employeecode.Text.Trim().PadLeft(4, ' ') + "  " + employeename.Text;
                        }
                        else
                        {
                            detail3.Text = employeecode.Text.Trim().PadLeft(4, '0') + "  " + employeename.Text;
                        }
                        break;
                    }
                default:    // �]�ƈ� - �V�X�e���@�\ - ���[��
                    {
                        detail3.Text = rolegroupcode.Text.Trim().PadLeft(6, ' ') + "  " + rolegroupname.Text;
                        break;
                    }
            }
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
		/// <br>Programmer	: 30747 �O�� �L��</br>
        /// <br>Date		: 2013/02/15</br>
		/// </remarks>
		private void Detail_BeforePrint ( object sender, System.EventArgs eArgs )
		{
			// �O���[�v�T�v���X�̔��f
			this.CheckGroupSuppression();
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
		/// <br>Programmer  : 30747 �O�� �L��</br>
        /// <br>Date		: 2013/02/15</br>
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

		#region �� DailyFooter_Format Event
		/// <summary>
		/// DailyFooter_Format Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="eArgs">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: DailyFooter_Format Event</br>
		/// <br>Programmer	: 30747 �O�� �L��</br>
        /// <br>Date		: 2013/02/15</br>
		/// </remarks>
		private void DailyFooter_Format(object sender, System.EventArgs eArgs)
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
		/// <br>Programmer	: 30747 �O�� �L��</br>
        /// <br>Date		: 2013/02/15</br>
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
        
        #region �� PageFooter_AfterPrint Event
        /// <summary>
        /// PageFooter_AfterPrint Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �Z�N�V�������y�[�W�ɕ`�悳�ꂽ��ɔ������܂��B</br>
        /// <br>Programmer	: 30747 �O�� �L��</br>
        /// <br>Date		: 2013/02/15</br>
        /// </remarks>
        private void PageFooter_AfterPrint(object sender, EventArgs e)
        {
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
        private DataDynamics.ActiveReports.GroupHeader TitleHeader;
        private DataDynamics.ActiveReports.Line Line5;
        private DataDynamics.ActiveReports.Detail Detail;
        private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.SubReport Footer_SubReport;
        /// <summary>
        /// 
        /// </summary>
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN02203P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.systemname = new DataDynamics.ActiveReports.TextBox();
            this.detail3 = new DataDynamics.ActiveReports.TextBox();
            this.rolegroupcode = new DataDynamics.ActiveReports.TextBox();
            this.rolegroupname = new DataDynamics.ActiveReports.TextBox();
            this.employeecode = new DataDynamics.ActiveReports.TextBox();
            this.employeename = new DataDynamics.ActiveReports.TextBox();
            this.detail2 = new DataDynamics.ActiveReports.TextBox();
            this.detail1 = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.label_sort = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.label_title3 = new DataDynamics.ActiveReports.Label();
            this.Line5 = new DataDynamics.ActiveReports.Line();
            this.label_title1 = new DataDynamics.ActiveReports.Label();
            this.label_title2 = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.groupHeader1 = new DataDynamics.ActiveReports.GroupHeader();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.groupFooter1 = new DataDynamics.ActiveReports.GroupFooter();
            this.groupHeader2 = new DataDynamics.ActiveReports.GroupHeader();
            this.groupFooter2 = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.systemname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detail3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolegroupcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolegroupname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeecode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeename)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detail2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detail1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_sort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_title3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_title1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_title2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.systemname,
            this.detail3,
            this.rolegroupcode,
            this.rolegroupname,
            this.employeecode,
            this.employeename});
            this.Detail.Height = 0.13F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // systemname
            // 
            this.systemname.Border.BottomColor = System.Drawing.Color.Black;
            this.systemname.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.systemname.Border.LeftColor = System.Drawing.Color.Black;
            this.systemname.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.systemname.Border.RightColor = System.Drawing.Color.Black;
            this.systemname.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.systemname.Border.TopColor = System.Drawing.Color.Black;
            this.systemname.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.systemname.DataField = "systemname";
            this.systemname.Height = 0.125F;
            this.systemname.Left = 2.5F;
            this.systemname.MultiLine = false;
            this.systemname.Name = "systemname";
            this.systemname.OutputFormat = resources.GetString("systemname.OutputFormat");
            this.systemname.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: �l�r ����; vertical" +
                "-align: top; ";
            this.systemname.Text = "��\��";
            this.systemname.Top = 0F;
            this.systemname.Visible = false;
            this.systemname.Width = 1.125F;
            // 
            // detail3
            // 
            this.detail3.Border.BottomColor = System.Drawing.Color.Black;
            this.detail3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.detail3.Border.LeftColor = System.Drawing.Color.Black;
            this.detail3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.detail3.Border.RightColor = System.Drawing.Color.Black;
            this.detail3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.detail3.Border.TopColor = System.Drawing.Color.Black;
            this.detail3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.detail3.Height = 0.125F;
            this.detail3.Left = 6.1875F;
            this.detail3.MultiLine = false;
            this.detail3.Name = "detail3";
            this.detail3.OutputFormat = resources.GetString("detail3.OutputFormat");
            this.detail3.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: �l�r ����; vertical" +
                "-align: top; ";
            this.detail3.Text = "��������������������";
            this.detail3.Top = 0F;
            this.detail3.Width = 4F;
            // 
            // rolegroupcode
            // 
            this.rolegroupcode.Border.BottomColor = System.Drawing.Color.Black;
            this.rolegroupcode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.rolegroupcode.Border.LeftColor = System.Drawing.Color.Black;
            this.rolegroupcode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.rolegroupcode.Border.RightColor = System.Drawing.Color.Black;
            this.rolegroupcode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.rolegroupcode.Border.TopColor = System.Drawing.Color.Black;
            this.rolegroupcode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.rolegroupcode.DataField = "rolegroupcode";
            this.rolegroupcode.Height = 0.125F;
            this.rolegroupcode.Left = 0.125F;
            this.rolegroupcode.MultiLine = false;
            this.rolegroupcode.Name = "rolegroupcode";
            this.rolegroupcode.OutputFormat = resources.GetString("rolegroupcode.OutputFormat");
            this.rolegroupcode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: �l�r ����; vertical" +
                "-align: top; ";
            this.rolegroupcode.Text = "��\��";
            this.rolegroupcode.Top = 0F;
            this.rolegroupcode.Visible = false;
            this.rolegroupcode.Width = 1.125F;
            // 
            // rolegroupname
            // 
            this.rolegroupname.Border.BottomColor = System.Drawing.Color.Black;
            this.rolegroupname.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.rolegroupname.Border.LeftColor = System.Drawing.Color.Black;
            this.rolegroupname.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.rolegroupname.Border.RightColor = System.Drawing.Color.Black;
            this.rolegroupname.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.rolegroupname.Border.TopColor = System.Drawing.Color.Black;
            this.rolegroupname.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.rolegroupname.DataField = "rolegroupname";
            this.rolegroupname.Height = 0.125F;
            this.rolegroupname.Left = 1.3125F;
            this.rolegroupname.MultiLine = false;
            this.rolegroupname.Name = "rolegroupname";
            this.rolegroupname.OutputFormat = resources.GetString("rolegroupname.OutputFormat");
            this.rolegroupname.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: �l�r ����; vertical" +
                "-align: top; ";
            this.rolegroupname.Text = "��\��";
            this.rolegroupname.Top = 0F;
            this.rolegroupname.Visible = false;
            this.rolegroupname.Width = 1.125F;
            // 
            // employeecode
            // 
            this.employeecode.Border.BottomColor = System.Drawing.Color.Black;
            this.employeecode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employeecode.Border.LeftColor = System.Drawing.Color.Black;
            this.employeecode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employeecode.Border.RightColor = System.Drawing.Color.Black;
            this.employeecode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employeecode.Border.TopColor = System.Drawing.Color.Black;
            this.employeecode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employeecode.DataField = "employeecode";
            this.employeecode.Height = 0.125F;
            this.employeecode.Left = 3.75F;
            this.employeecode.MultiLine = false;
            this.employeecode.Name = "employeecode";
            this.employeecode.OutputFormat = resources.GetString("employeecode.OutputFormat");
            this.employeecode.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: �l�r ����; vertical" +
                "-align: top; ";
            this.employeecode.Text = "��\��";
            this.employeecode.Top = 0F;
            this.employeecode.Visible = false;
            this.employeecode.Width = 1.125F;
            // 
            // employeename
            // 
            this.employeename.Border.BottomColor = System.Drawing.Color.Black;
            this.employeename.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employeename.Border.LeftColor = System.Drawing.Color.Black;
            this.employeename.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employeename.Border.RightColor = System.Drawing.Color.Black;
            this.employeename.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employeename.Border.TopColor = System.Drawing.Color.Black;
            this.employeename.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.employeename.DataField = "employeename";
            this.employeename.Height = 0.125F;
            this.employeename.Left = 4.9375F;
            this.employeename.MultiLine = false;
            this.employeename.Name = "employeename";
            this.employeename.OutputFormat = resources.GetString("employeename.OutputFormat");
            this.employeename.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: �l�r ����; vertical" +
                "-align: top; ";
            this.employeename.Text = "��\��";
            this.employeename.Top = 0F;
            this.employeename.Visible = false;
            this.employeename.Width = 1.125F;
            // 
            // detail2
            // 
            this.detail2.Border.BottomColor = System.Drawing.Color.Black;
            this.detail2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.detail2.Border.LeftColor = System.Drawing.Color.Black;
            this.detail2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.detail2.Border.RightColor = System.Drawing.Color.Black;
            this.detail2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.detail2.Border.TopColor = System.Drawing.Color.Black;
            this.detail2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.detail2.Height = 0.125F;
            this.detail2.Left = 2.9375F;
            this.detail2.MultiLine = false;
            this.detail2.Name = "detail2";
            this.detail2.OutputFormat = resources.GetString("detail2.OutputFormat");
            this.detail2.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: �l�r ����; vertical" +
                "-align: top; ";
            this.detail2.Text = "������������������������������������������������������������";
            this.detail2.Top = 0F;
            this.detail2.Width = 4F;
            // 
            // detail1
            // 
            this.detail1.Border.BottomColor = System.Drawing.Color.Black;
            this.detail1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.detail1.Border.LeftColor = System.Drawing.Color.Black;
            this.detail1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.detail1.Border.RightColor = System.Drawing.Color.Black;
            this.detail1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.detail1.Border.TopColor = System.Drawing.Color.Black;
            this.detail1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.detail1.Height = 0.125F;
            this.detail1.Left = 0.0625F;
            this.detail1.MultiLine = false;
            this.detail1.Name = "detail1";
            this.detail1.OutputFormat = resources.GetString("detail1.OutputFormat");
            this.detail1.Style = "ddo-char-set: 128; text-align: left; font-size: 8pt; font-family: �l�r ����; vertical" +
                "-align: top; ";
            this.detail1.Text = "��������������������";
            this.detail1.Top = 0F;
            this.detail1.Width = 4F;
            // 
            // PageHeader
            // 
            this.PageHeader.CanShrink = true;
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label12,
            this.Label3,
            this.tb_PrintDate,
            this.Label2,
            this.tb_PrintPage,
            this.Line1,
            this.tb_PrintTime,
            this.tb_ReportTitle,
            this.label_sort});
            this.PageHeader.Height = 0.46875F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
            // 
            // label12
            // 
            this.label12.Border.BottomColor = System.Drawing.Color.Black;
            this.label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Border.LeftColor = System.Drawing.Color.Black;
            this.label12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Border.RightColor = System.Drawing.Color.Black;
            this.label12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Border.TopColor = System.Drawing.Color.Black;
            this.label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label12.Height = 0.15F;
            this.label12.HyperLink = "";
            this.label12.Left = 0.0625F;
            this.label12.MultiLine = false;
            this.label12.Name = "label12";
            this.label12.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: �l�r ����; vertical-align: top; ";
            this.label12.Text = "�Ɩ����j���[�ɕ\������Ȃ��ݒ�ɂȂ��Ă�����̂��o�͂���܂�";
            this.label12.Top = 0.27F;
            this.label12.Width = 4.5F;
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
            this.Line1.Top = 0.4375F;
            this.Line1.Width = 10.8125F;
            this.Line1.X1 = 0F;
            this.Line1.X2 = 10.8125F;
            this.Line1.Y1 = 0.4375F;
            this.Line1.Y2 = 0.4375F;
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
            this.tb_ReportTitle.Height = 0.25F;
            this.tb_ReportTitle.HyperLink = "";
            this.tb_ReportTitle.Left = 0.25F;
            this.tb_ReportTitle.MultiLine = false;
            this.tb_ReportTitle.Name = "tb_ReportTitle";
            this.tb_ReportTitle.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: �l�r ����; vertical-align: middle; ";
            this.tb_ReportTitle.Text = "���j���[����ݒ�";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 1.6875F;
            // 
            // label_sort
            // 
            this.label_sort.Border.BottomColor = System.Drawing.Color.Black;
            this.label_sort.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_sort.Border.LeftColor = System.Drawing.Color.Black;
            this.label_sort.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_sort.Border.RightColor = System.Drawing.Color.Black;
            this.label_sort.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_sort.Border.TopColor = System.Drawing.Color.Black;
            this.label_sort.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_sort.Height = 0.125F;
            this.label_sort.HyperLink = "";
            this.label_sort.Left = 2.125F;
            this.label_sort.MultiLine = false;
            this.label_sort.Name = "label_sort";
            this.label_sort.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: �l�r ����; vertical-align: top; ";
            this.label_sort.Text = "�o�͏��F���[�� - �V�X�e���@�\ - �]�ƈ�";
            this.label_sort.Top = 0.0625F;
            this.label_sort.Width = 3.25F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.3125F;
            this.PageFooter.Name = "PageFooter";
            this.PageFooter.Format += new System.EventHandler(this.PageFooter_Format);
            this.PageFooter.AfterPrint += new System.EventHandler(this.PageFooter_AfterPrint);
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
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label_title3,
            this.Line5,
            this.label_title1,
            this.label_title2});
            this.TitleHeader.Height = 0.5F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // label_title3
            // 
            this.label_title3.Border.BottomColor = System.Drawing.Color.Black;
            this.label_title3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_title3.Border.LeftColor = System.Drawing.Color.Black;
            this.label_title3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_title3.Border.RightColor = System.Drawing.Color.Black;
            this.label_title3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_title3.Border.TopColor = System.Drawing.Color.Black;
            this.label_title3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_title3.Height = 0.1875F;
            this.label_title3.HyperLink = "";
            this.label_title3.Left = 6.1875F;
            this.label_title3.MultiLine = false;
            this.label_title3.Name = "label_title3";
            this.label_title3.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: �l�r ����; vertical-align: top; ";
            this.label_title3.Text = "�]�ƈ�";
            this.label_title3.Top = 0.25F;
            this.label_title3.Width = 1.3125F;
            // 
            // Line5
            // 
            this.Line5.Border.BottomColor = System.Drawing.Color.Black;
            this.Line5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5.Border.LeftColor = System.Drawing.Color.Black;
            this.Line5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5.Border.RightColor = System.Drawing.Color.Black;
            this.Line5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5.Border.TopColor = System.Drawing.Color.Black;
            this.Line5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line5.Height = 0F;
            this.Line5.Left = 0F;
            this.Line5.LineWeight = 2F;
            this.Line5.Name = "Line5";
            this.Line5.Top = 0F;
            this.Line5.Width = 10.8F;
            this.Line5.X1 = 0F;
            this.Line5.X2 = 10.8F;
            this.Line5.Y1 = 0F;
            this.Line5.Y2 = 0F;
            // 
            // label_title1
            // 
            this.label_title1.Border.BottomColor = System.Drawing.Color.Black;
            this.label_title1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_title1.Border.LeftColor = System.Drawing.Color.Black;
            this.label_title1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_title1.Border.RightColor = System.Drawing.Color.Black;
            this.label_title1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_title1.Border.TopColor = System.Drawing.Color.Black;
            this.label_title1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_title1.Height = 0.125F;
            this.label_title1.HyperLink = "";
            this.label_title1.Left = 0.0625F;
            this.label_title1.MultiLine = false;
            this.label_title1.Name = "label_title1";
            this.label_title1.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: �l�r ����; vertical-align: top; ";
            this.label_title1.Text = "���[���O���[�v";
            this.label_title1.Top = 0.0625F;
            this.label_title1.Width = 1.375F;
            // 
            // label_title2
            // 
            this.label_title2.Border.BottomColor = System.Drawing.Color.Black;
            this.label_title2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_title2.Border.LeftColor = System.Drawing.Color.Black;
            this.label_title2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_title2.Border.RightColor = System.Drawing.Color.Black;
            this.label_title2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_title2.Border.TopColor = System.Drawing.Color.Black;
            this.label_title2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label_title2.Height = 0.15F;
            this.label_title2.HyperLink = "";
            this.label_title2.Left = 2.9375F;
            this.label_title2.MultiLine = false;
            this.label_title2.Name = "label_title2";
            this.label_title2.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 8pt; font-fami" +
                "ly: �l�r ����; vertical-align: top; ";
            this.label_title2.Text = "�V�X�e���@�\";
            this.label_title2.Top = 0.125F;
            this.label_title2.Width = 1.14F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.CanShrink = true;
            this.TitleFooter.Height = 0F;
            this.TitleFooter.KeepTogether = true;
            this.TitleFooter.Name = "TitleFooter";
            this.TitleFooter.Visible = false;
            // 
            // ExtraHeader
            // 
            this.ExtraHeader.CanShrink = true;
            this.ExtraHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Header_SubReport});
            this.ExtraHeader.Height = 0.5F;
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
            // groupHeader1
            // 
            this.groupHeader1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.detail1,
            this.line2});
            this.groupHeader1.Height = 0.13F;
            this.groupHeader1.Name = "groupHeader1";
            this.groupHeader1.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            this.groupHeader1.Format += new System.EventHandler(this.groupHeader1_Format);
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
            this.line2.Top = 0F;
            this.line2.Width = 10.8125F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.8125F;
            this.line2.Y1 = 0F;
            this.line2.Y2 = 0F;
            // 
            // groupFooter1
            // 
            this.groupFooter1.Height = 0F;
            this.groupFooter1.Name = "groupFooter1";
            // 
            // groupHeader2
            // 
            this.groupHeader2.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.detail2});
            this.groupHeader2.Height = 0.13F;
            this.groupHeader2.Name = "groupHeader2";
            this.groupHeader2.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            this.groupHeader2.Format += new System.EventHandler(this.groupHeader2_Format);
            // 
            // groupFooter2
            // 
            this.groupFooter2.Height = 0F;
            this.groupFooter2.Name = "groupFooter2";
            // 
            // PMKHN02203P_01A4C
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
            this.Sections.Add(this.groupHeader1);
            this.Sections.Add(this.groupHeader2);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.groupFooter2);
            this.Sections.Add(this.groupFooter1);
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
            this.PageEnd += new System.EventHandler(this.PMKHN02203P_01A4C_PageEnd);
            this.ReportStart += new System.EventHandler(this.PMKHN02203P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.systemname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detail3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolegroupcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolegroupname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeecode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeename)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detail2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detail1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_sort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_title3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_title1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label_title2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

         private void groupHeader1_Format(object sender, EventArgs e)
         {
             switch (this._pageHeaderSortOderTitle)
             {
                 case "0":   // ���[�� - �V�X�e���@�\ - �]�ƈ�
                     {
                         detail1.Text = rolegroupcode.Text.Trim().PadLeft(6, ' ') + "  " + rolegroupname.Text;
                         break;
                     }
                 case "1":   // �V�X�e���@�\ - ���[�� - �]�ƈ�
                     {
                         detail1.Text = systemname.Text;
                         break;
                     }
                 default:    // �]�ƈ� - �V�X�e���@�\ - ���[��
                     {
                         if (string.IsNullOrEmpty(employeecode.Text))
                         {
                             detail1.Text = employeecode.Text.Trim().PadLeft(4, ' ') + "  " + employeename.Text;
                         }
                         else
                         {
                             detail1.Text = employeecode.Text.Trim().PadLeft(4, '0') + "  " + employeename.Text;
                         }
                         break;
                     }
             }
         }

         private void groupHeader2_Format(object sender, EventArgs e)
         {
             switch (this._pageHeaderSortOderTitle)
             {
                 case "0":   // ���[�� - �V�X�e���@�\ - �]�ƈ�
                     {
                         detail2.Text = systemname.Text;
                         break;
                     }
                 case "1":   // �V�X�e���@�\ - ���[�� - �]�ƈ�
                     {
                         detail2.Text = rolegroupcode.Text.Trim().PadLeft(6, ' ') + "  " + rolegroupname.Text;
                         break;
                     }
                 default:    // �]�ƈ� - �V�X�e���@�\ - ���[��
                     {
                         detail2.Text = systemname.Text;
                         break;
                     }
             }
         }


        
	}
}
