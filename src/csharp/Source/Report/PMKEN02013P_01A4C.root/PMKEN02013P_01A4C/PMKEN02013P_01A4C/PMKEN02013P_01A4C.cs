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
	/// �D�ǐݒ�}�X�^����t�H�[���N���X
	/// </summary>
	/// <remarks>
    /// <br>Note         : �D�ǐݒ�}�X�^�̃t�H�[���N���X�ł��B</br>
	/// <br>Programmer   : 30462 �s�V �m��</br>
	/// <br>Date         : 2008.11.13</br>
	/// <br></br>
	/// </remarks>
	public class PMKEN02013P_01A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList, IPrintActiveReportTypeCommon
	{
		#region �� Constructor
		/// <summary>
        /// �D�ǐݒ�}�X�^�t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note         : �D�ǐݒ�}�X�^�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer   : 30462 �s�V �m��</br>
        /// <br>Date         : 2008.11.13</br>
		/// </remarks>
		public PMKEN02013P_01A4C()
		{
			InitializeComponent();
		}
		#endregion �� Constructor

		#region �� Private Member
		private int _printCount;									    // ��������p�J�E���^
        private int _printCountp;									    // �y�[�W����������p�J�E���^

		private int					_extraCondHeadOutDiv;			    // ���o�����w�b�_�o�͋敪
		private StringCollection	_extraConditions;				    // ���o����
		private int					_pageFooterOutCode;				    // �t�b�^�[�o�͋敪
		private StringCollection	_pageFooters;					    // �t�b�^�[���b�Z�[�W
		private	SFCMN06002C			_printInfo;						    // ������N���X
		private string				_pageHeaderTitle;				    // �t�H�[���^�C�g��
		private string				_pageHeaderSortOderTitle;		    // �\�[�g��

        private PrmSettingPrintOrderCndtn _prmSettingPrintOrderCndtn;                   // ���o�����N���X

        private string _beforeSection = string.Empty;

        private string _beforeGoodsMGroup = string.Empty;                      // �O��l(�O���[�v�T�v���X�p)
        private string _beforeTbsPartsCode = string.Empty;

		// �w�b�_�[�T�u���|�[�g�錾
		ListCommon_ExtraHeader _rptExtraHeader		= null;
		// �t�b�^�[���|�[�g�錾
        ListCommon_PageFooter _rptPageFooter = null;
        
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
                this._prmSettingPrintOrderCndtn = (PrmSettingPrintOrderCndtn)this._printInfo.jyoken;
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
				// TODO:  DCZAI02163P_01A4C.WatermarkMode getter ������ǉ����܂��B
				return 0;
			}
			set
			{
				// TODO:  DCZAI02163P_01A4C.WatermarkMode setter ������ǉ����܂��B
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
        /// <br>Programmer	: 30462 �s�V �m��</br>
        /// <br>Date		: 2008.11.13</br>
		/// </remarks>
		private void SetOfReportMembersOutput()
		{
			this._printCount = 0;
            this._printCountp = 0;
			// �󎚐ݒ� --------------------------------------------------------------------------------------
			
			// ���ڂ̖��̂��Z�b�g
			tb_ReportTitle.Text	= this._pageHeaderTitle;				// �T�u�^�C�g��

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

		#region �� DCZAI02163P_01A4C_ReportStart Event
		/// <summary>
		/// DCZAI02163P_01A4C_ReportStart Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="eArgs">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: ���|�[�g�J�n���̃C�x���g�ł��B</br>
        /// <br>Programmer	: 30462 �s�V �m��</br>
		/// <br>Date		: 2008.11.13</br>
		/// </remarks>
		private void DCZAI02163P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
			SetOfReportMembersOutput();
		}
		#endregion

		#region �� DCZAI02163P_01A4C_PageEnd Event
		/// <summary>
		/// DCZAI02163P_01A4C_PageEnd Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="eArgs">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: DCZAI02163P_01A4C_PageEnd Event</br>
        /// <br>Programmer	: 30462 �s�V �m��</br>
		/// <br>Date		: 2008.11.13</br>
		/// </remarks>
		private void DCZAI02163P_01A4C_PageEnd(object sender, System.EventArgs eArgs)
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
        /// <br>Programmer	: 30462 �s�V �m��</br>
		/// <br>Date		: 2008.11.13</br>
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
        /// <br>Programmer	: 30462 �s�V �m��</br>
		/// <br>Date		: 2008.11.13</br>
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

            string str_Section = string.Empty;
            str_Section = "���_�F" + this.tb_SectionCode.Value + " " + this.tb_SectionGuideSnm.Value;
            if (!this._beforeSection.Equals(str_Section))
            {
                this._extraConditions.Remove(this._beforeSection);
		        this._beforeSection = str_Section;
                this._extraConditions.Add(str_Section);			
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
		/// <br>Programmer	: 30462 �s�V �m��</br>
		/// <br>Date		: 2008.11.13</br>
		/// </remarks>
		private void Detail_Format(object sender, System.EventArgs eArgs)
		{
            // ���i������
            if (this.GoodsMGroup.Value.Equals(0))
            {
                this.GoodsMGroup.Value = "";
            }

            // BL����
            if (this.TbsPartsCode.Value.Equals(0))
            {
                this.TbsPartsCode.Value = "";
            }

            // Ұ������
            if (this.PartsMakerCd.Value.Equals(0))
            {
                this.PartsMakerCd.Value = "";
            }

            // �d����
            if (this.SupplierCd.Value.Equals(0))
            {
                this.SupplierCd.Value = "";
            }       
            
            // �D�Ǖ\���敪
            if (this.PrimeDisplayCode.Value.Equals(0))
            {
                this.PrimeDisplayCode.Value = "�\����";  
            }
            else if (this.PrimeDisplayCode.Value.Equals(1))
            {
                this.PrimeDisplayCode.Value = "���i&����";
            }
            else if (this.PrimeDisplayCode.Value.Equals(2))
            {
                this.PrimeDisplayCode.Value = "���i";
            }
            else
            {
                this.PrimeDisplayCode.Value = "";
            }
       
            // �O���[�v������
            if (this.GoodsMGroup.Text == this._beforeGoodsMGroup)
            {
                this.GoodsMGroup.Visible = false;
                this.GoodsMGroupName.Visible = false;
                if (this.TbsPartsCode.Text == this._beforeTbsPartsCode)
                {
                    this.TbsPartsCode.Visible = false;
                    this.BLGoodsHalfName.Visible = false;
                }
                else
                {
                    this.TbsPartsCode.Visible = true;
                    this.BLGoodsHalfName.Visible = true;
                }
            }
            else
            {
                this.GoodsMGroup.Visible = true;
                this.GoodsMGroupName.Visible = true;
                this.TbsPartsCode.Visible = true;
                this.BLGoodsHalfName.Visible = true;
            }


            this._beforeGoodsMGroup = this.GoodsMGroup.Text;
            this._beforeTbsPartsCode = this.TbsPartsCode.Text;


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
		/// <br>Programmer	: 30462 �s�V �m��</br>
        /// <br>Date		: 2008.11.13</br>
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
		/// <br>Programmer  : 30462 �s�V �m��</br>
        /// <br>Date		: 2008.11.13</br>
		/// </remarks>
		private void Detail_AfterPrint(object sender, System.EventArgs eArgs)
		{
			// ��������J�E���g�A�b�v
			this._printCount++;

            if (this.ProgressBarUpEvent != null)
            {
                this.ProgressBarUpEvent(this, this._printCount);
            }

            this._printCountp++;
            // 36���ׂŉ��y�[�W���邽��
            if (this._printCountp == 35)
            {
                this._printCountp = 0;

                // �O��l���N���A
                _beforeGoodsMGroup = string.Empty;
                _beforeTbsPartsCode = string.Empty;
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
		/// <br>Programmer	: 30462 �s�V �m��</br>
        /// <br>Date		: 2008.11.13</br>
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
		/// <br>Programmer	: 30462 �s�V �m��</br>
        /// <br>Date		: 2008.11.13</br>
		/// </remarks>
		private void PageFooter_Format(object sender, System.EventArgs eArgs)
		{
            // 2009.03.17 30413 ���� �t�b�^�[���̈󎚕ύX >>>>>>START
            //// �t�b�^�[�o�͂���H
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
            // 2009.03.17 30413 ���� �t�b�^�[���̈󎚕ύX <<<<<<END
        }
		#endregion

        #region �� SectionHeader_AfterPrint Event
        /// <summary>
        /// SectionHeader_AfterPrint Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �Z�N�V�������y�[�W�ɕ`�悳�ꂽ��ɔ������܂��B</br>
        /// <br>Programmer	: 30462 �s�V �m��</br>
        /// <br>Date		: 2008.11.13</br>
        /// </remarks>
        private void SectionHeader_AfterPrint(object sender, EventArgs e)
        {
            // �O��l���N���A
            _beforeGoodsMGroup = string.Empty;
            _beforeTbsPartsCode = string.Empty;
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
        /// <br>Programmer	: 30462 �s�V �m��</br>
        /// <br>Date		: 2008.11.13</br>
        /// </remarks>
        private void PageFooter_AfterPrint(object sender, EventArgs e)
        {
                this._printCountp = 0;
        }
        #endregion
		#endregion �� Control Event

		#region ActiveReports Designer generated code
        private TextBox PartsMakerCd;
        private TextBox MakerShortName;
        private TextBox TbsPartsCode;
        private TextBox BLGoodsHalfName;
        private Line line2;
        private GroupHeader SectionHeader;
        private GroupFooter SectionFooter;
        private TextBox tb_SectionGuideSnm;
        private Line line3;
        private TextBox MakerDispOrder;
        private TextBox SupplierCd;
        private TextBox SupplierSnm;
        private TextBox PrmSetDtlName1;
        private TextBox GoodsMGroup;
        private TextBox GoodsMGroupName;
        private Label label16;
        private Label label18;
        private TextBox PrmSetDtlName2;
        private TextBox PrimeDisplayCode;
        private Label label19;
        private Label label20;
        private Label label21;
        private Label label23;
        private Label label24;
        private Label label25;
        private TextBox tb_SectionCode;

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
        private DataDynamics.ActiveReports.Line Line5;
        private DataDynamics.ActiveReports.Detail Detail;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKEN02013P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.PartsMakerCd = new DataDynamics.ActiveReports.TextBox();
            this.MakerShortName = new DataDynamics.ActiveReports.TextBox();
            this.TbsPartsCode = new DataDynamics.ActiveReports.TextBox();
            this.BLGoodsHalfName = new DataDynamics.ActiveReports.TextBox();
            this.line3 = new DataDynamics.ActiveReports.Line();
            this.MakerDispOrder = new DataDynamics.ActiveReports.TextBox();
            this.SupplierCd = new DataDynamics.ActiveReports.TextBox();
            this.SupplierSnm = new DataDynamics.ActiveReports.TextBox();
            this.PrmSetDtlName1 = new DataDynamics.ActiveReports.TextBox();
            this.GoodsMGroup = new DataDynamics.ActiveReports.TextBox();
            this.GoodsMGroupName = new DataDynamics.ActiveReports.TextBox();
            this.PrmSetDtlName2 = new DataDynamics.ActiveReports.TextBox();
            this.PrimeDisplayCode = new DataDynamics.ActiveReports.TextBox();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.Label3 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label2 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Line5 = new DataDynamics.ActiveReports.Line();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.label16 = new DataDynamics.ActiveReports.Label();
            this.label18 = new DataDynamics.ActiveReports.Label();
            this.label19 = new DataDynamics.ActiveReports.Label();
            this.label20 = new DataDynamics.ActiveReports.Label();
            this.label21 = new DataDynamics.ActiveReports.Label();
            this.label23 = new DataDynamics.ActiveReports.Label();
            this.label24 = new DataDynamics.ActiveReports.Label();
            this.label25 = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.tb_SectionGuideSnm = new DataDynamics.ActiveReports.TextBox();
            this.tb_SectionCode = new DataDynamics.ActiveReports.TextBox();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            ((System.ComponentModel.ISupportInitialize)(this.PartsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerShortName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TbsPartsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsHalfName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerDispOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrmSetDtlName1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMGroupName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrmSetDtlName2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrimeDisplayCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SectionGuideSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SectionCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.PartsMakerCd,
            this.MakerShortName,
            this.TbsPartsCode,
            this.BLGoodsHalfName,
            this.line3,
            this.MakerDispOrder,
            this.SupplierCd,
            this.SupplierSnm,
            this.PrmSetDtlName1,
            this.GoodsMGroup,
            this.GoodsMGroupName,
            this.PrmSetDtlName2,
            this.PrimeDisplayCode});
            this.Detail.Height = 0.2473958F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // PartsMakerCd
            // 
            this.PartsMakerCd.Border.BottomColor = System.Drawing.Color.Black;
            this.PartsMakerCd.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartsMakerCd.Border.LeftColor = System.Drawing.Color.Black;
            this.PartsMakerCd.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartsMakerCd.Border.RightColor = System.Drawing.Color.Black;
            this.PartsMakerCd.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartsMakerCd.Border.TopColor = System.Drawing.Color.Black;
            this.PartsMakerCd.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PartsMakerCd.DataField = "PartsMakerCd";
            this.PartsMakerCd.Height = 0.15F;
            this.PartsMakerCd.Left = 2.551136F;
            this.PartsMakerCd.MultiLine = false;
            this.PartsMakerCd.Name = "PartsMakerCd";
            this.PartsMakerCd.OutputFormat = resources.GetString("PartsMakerCd.OutputFormat");
            this.PartsMakerCd.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: �l�r �S�V�b�N; vertical" +
                "-align: top; ";
            this.PartsMakerCd.Text = "12345";
            this.PartsMakerCd.Top = 0.02083331F;
            this.PartsMakerCd.Width = 0.3125F;
            // 
            // MakerShortName
            // 
            this.MakerShortName.Border.BottomColor = System.Drawing.Color.Black;
            this.MakerShortName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerShortName.Border.LeftColor = System.Drawing.Color.Black;
            this.MakerShortName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerShortName.Border.RightColor = System.Drawing.Color.Black;
            this.MakerShortName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerShortName.Border.TopColor = System.Drawing.Color.Black;
            this.MakerShortName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerShortName.DataField = "MakerShortName";
            this.MakerShortName.Height = 0.15F;
            this.MakerShortName.Left = 2.860795F;
            this.MakerShortName.MultiLine = false;
            this.MakerShortName.Name = "MakerShortName";
            this.MakerShortName.OutputFormat = resources.GetString("MakerShortName.OutputFormat");
            this.MakerShortName.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: �l�r ����; vertical-a" +
                "lign: top; ";
            this.MakerShortName.Text = "��������������������";
            this.MakerShortName.Top = 0.02083331F;
            this.MakerShortName.Width = 1.1875F;
            // 
            // TbsPartsCode
            // 
            this.TbsPartsCode.Border.BottomColor = System.Drawing.Color.Black;
            this.TbsPartsCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TbsPartsCode.Border.LeftColor = System.Drawing.Color.Black;
            this.TbsPartsCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TbsPartsCode.Border.RightColor = System.Drawing.Color.Black;
            this.TbsPartsCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TbsPartsCode.Border.TopColor = System.Drawing.Color.Black;
            this.TbsPartsCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TbsPartsCode.DataField = "TbsPartsCode";
            this.TbsPartsCode.Height = 0.15F;
            this.TbsPartsCode.Left = 1.556818F;
            this.TbsPartsCode.MultiLine = false;
            this.TbsPartsCode.Name = "TbsPartsCode";
            this.TbsPartsCode.OutputFormat = resources.GetString("TbsPartsCode.OutputFormat");
            this.TbsPartsCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: �l�r �S�V�b�N; vertical" +
                "-align: top; ";
            this.TbsPartsCode.Text = "12345";
            this.TbsPartsCode.Top = 0.02083331F;
            this.TbsPartsCode.Width = 0.3125F;
            // 
            // BLGoodsHalfName
            // 
            this.BLGoodsHalfName.Border.BottomColor = System.Drawing.Color.Black;
            this.BLGoodsHalfName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsHalfName.Border.LeftColor = System.Drawing.Color.Black;
            this.BLGoodsHalfName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsHalfName.Border.RightColor = System.Drawing.Color.Black;
            this.BLGoodsHalfName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsHalfName.Border.TopColor = System.Drawing.Color.Black;
            this.BLGoodsHalfName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.BLGoodsHalfName.DataField = "BLGoodsHalfName";
            this.BLGoodsHalfName.Height = 0.15F;
            this.BLGoodsHalfName.Left = 1.866477F;
            this.BLGoodsHalfName.MultiLine = false;
            this.BLGoodsHalfName.Name = "BLGoodsHalfName";
            this.BLGoodsHalfName.OutputFormat = resources.GetString("BLGoodsHalfName.OutputFormat");
            this.BLGoodsHalfName.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: �l�r ����; vertical-a" +
                "lign: top; ";
            this.BLGoodsHalfName.Text = "����������";
            this.BLGoodsHalfName.Top = 0.02083331F;
            this.BLGoodsHalfName.Width = 0.6249999F;
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
            this.line3.Top = 0.1875F;
            this.line3.Width = 10.8F;
            this.line3.X1 = 0F;
            this.line3.X2 = 10.8F;
            this.line3.Y1 = 0.1875F;
            this.line3.Y2 = 0.1875F;
            // 
            // MakerDispOrder
            // 
            this.MakerDispOrder.Border.BottomColor = System.Drawing.Color.Black;
            this.MakerDispOrder.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerDispOrder.Border.LeftColor = System.Drawing.Color.Black;
            this.MakerDispOrder.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerDispOrder.Border.RightColor = System.Drawing.Color.Black;
            this.MakerDispOrder.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerDispOrder.Border.TopColor = System.Drawing.Color.Black;
            this.MakerDispOrder.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MakerDispOrder.DataField = "MakerDispOrder";
            this.MakerDispOrder.Height = 0.15F;
            this.MakerDispOrder.Left = 4.107955F;
            this.MakerDispOrder.MultiLine = false;
            this.MakerDispOrder.Name = "MakerDispOrder";
            this.MakerDispOrder.OutputFormat = resources.GetString("MakerDispOrder.OutputFormat");
            this.MakerDispOrder.Style = "ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: �l�r �S�V�b�N; vertica" +
                "l-align: top; ";
            this.MakerDispOrder.Text = "99";
            this.MakerDispOrder.Top = 0.02083331F;
            this.MakerDispOrder.Width = 0.1875F;
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
            this.SupplierCd.Height = 0.15F;
            this.SupplierCd.Left = 4.355113F;
            this.SupplierCd.MultiLine = false;
            this.SupplierCd.Name = "SupplierCd";
            this.SupplierCd.OutputFormat = resources.GetString("SupplierCd.OutputFormat");
            this.SupplierCd.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: �l�r �S�V�b�N; vertical" +
                "-align: top; ";
            this.SupplierCd.Text = "123456";
            this.SupplierCd.Top = 0.02083331F;
            this.SupplierCd.Width = 0.3749999F;
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
            this.SupplierSnm.Height = 0.15F;
            this.SupplierSnm.Left = 4.727273F;
            this.SupplierSnm.MultiLine = false;
            this.SupplierSnm.Name = "SupplierSnm";
            this.SupplierSnm.OutputFormat = resources.GetString("SupplierSnm.OutputFormat");
            this.SupplierSnm.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: �l�r ����; vertical-a" +
                "lign: top; ";
            this.SupplierSnm.Text = "��������������������";
            this.SupplierSnm.Top = 0.02083331F;
            this.SupplierSnm.Width = 1.1875F;
            // 
            // PrmSetDtlName1
            // 
            this.PrmSetDtlName1.Border.BottomColor = System.Drawing.Color.Black;
            this.PrmSetDtlName1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrmSetDtlName1.Border.LeftColor = System.Drawing.Color.Black;
            this.PrmSetDtlName1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrmSetDtlName1.Border.RightColor = System.Drawing.Color.Black;
            this.PrmSetDtlName1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrmSetDtlName1.Border.TopColor = System.Drawing.Color.Black;
            this.PrmSetDtlName1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrmSetDtlName1.DataField = "PrmSetDtlName1";
            this.PrmSetDtlName1.Height = 0.15F;
            this.PrmSetDtlName1.Left = 5.943182F;
            this.PrmSetDtlName1.MultiLine = false;
            this.PrmSetDtlName1.Name = "PrmSetDtlName1";
            this.PrmSetDtlName1.OutputFormat = resources.GetString("PrmSetDtlName1.OutputFormat");
            this.PrmSetDtlName1.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: �l�r ����; vertical-a" +
                "lign: top; ";
            this.PrmSetDtlName1.Text = "������������������������������������";
            this.PrmSetDtlName1.Top = 0.02083331F;
            this.PrmSetDtlName1.Width = 2.0625F;
            // 
            // GoodsMGroup
            // 
            this.GoodsMGroup.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsMGroup.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMGroup.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsMGroup.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMGroup.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsMGroup.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMGroup.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsMGroup.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMGroup.DataField = "GoodsMGroup";
            this.GoodsMGroup.Height = 0.15F;
            this.GoodsMGroup.Left = 0F;
            this.GoodsMGroup.MultiLine = false;
            this.GoodsMGroup.Name = "GoodsMGroup";
            this.GoodsMGroup.OutputFormat = resources.GetString("GoodsMGroup.OutputFormat");
            this.GoodsMGroup.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: �l�r �S�V�b�N; vertical" +
                "-align: top; ";
            this.GoodsMGroup.Text = "12345";
            this.GoodsMGroup.Top = 0.02083331F;
            this.GoodsMGroup.Width = 0.3125F;
            // 
            // GoodsMGroupName
            // 
            this.GoodsMGroupName.Border.BottomColor = System.Drawing.Color.Black;
            this.GoodsMGroupName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMGroupName.Border.LeftColor = System.Drawing.Color.Black;
            this.GoodsMGroupName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMGroupName.Border.RightColor = System.Drawing.Color.Black;
            this.GoodsMGroupName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMGroupName.Border.TopColor = System.Drawing.Color.Black;
            this.GoodsMGroupName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GoodsMGroupName.DataField = "GoodsMGroupName";
            this.GoodsMGroupName.Height = 0.15F;
            this.GoodsMGroupName.Left = 0.3096592F;
            this.GoodsMGroupName.MultiLine = false;
            this.GoodsMGroupName.Name = "GoodsMGroupName";
            this.GoodsMGroupName.OutputFormat = resources.GetString("GoodsMGroupName.OutputFormat");
            this.GoodsMGroupName.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: �l�r ����; vertical-a" +
                "lign: top; ";
            this.GoodsMGroupName.Text = "��������������������";
            this.GoodsMGroupName.Top = 0.02083331F;
            this.GoodsMGroupName.Width = 1.1875F;
            // 
            // PrmSetDtlName2
            // 
            this.PrmSetDtlName2.Border.BottomColor = System.Drawing.Color.Black;
            this.PrmSetDtlName2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrmSetDtlName2.Border.LeftColor = System.Drawing.Color.Black;
            this.PrmSetDtlName2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrmSetDtlName2.Border.RightColor = System.Drawing.Color.Black;
            this.PrmSetDtlName2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrmSetDtlName2.Border.TopColor = System.Drawing.Color.Black;
            this.PrmSetDtlName2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrmSetDtlName2.DataField = "PrmSetDtlName2";
            this.PrmSetDtlName2.Height = 0.15F;
            this.PrmSetDtlName2.Left = 8.034091F;
            this.PrmSetDtlName2.MultiLine = false;
            this.PrmSetDtlName2.Name = "PrmSetDtlName2";
            this.PrmSetDtlName2.OutputFormat = resources.GetString("PrmSetDtlName2.OutputFormat");
            this.PrmSetDtlName2.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: �l�r ����; vertical-a" +
                "lign: top; ";
            this.PrmSetDtlName2.Text = "������������������������������������";
            this.PrmSetDtlName2.Top = 0.02083331F;
            this.PrmSetDtlName2.Width = 2.0625F;
            // 
            // PrimeDisplayCode
            // 
            this.PrimeDisplayCode.Border.BottomColor = System.Drawing.Color.Black;
            this.PrimeDisplayCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrimeDisplayCode.Border.LeftColor = System.Drawing.Color.Black;
            this.PrimeDisplayCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrimeDisplayCode.Border.RightColor = System.Drawing.Color.Black;
            this.PrimeDisplayCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrimeDisplayCode.Border.TopColor = System.Drawing.Color.Black;
            this.PrimeDisplayCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.PrimeDisplayCode.DataField = "PrimeDisplayCode";
            this.PrimeDisplayCode.Height = 0.15F;
            this.PrimeDisplayCode.Left = 10.09375F;
            this.PrimeDisplayCode.MultiLine = false;
            this.PrimeDisplayCode.Name = "PrimeDisplayCode";
            this.PrimeDisplayCode.OutputFormat = resources.GetString("PrimeDisplayCode.OutputFormat");
            this.PrimeDisplayCode.Style = "ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: �l�r ����; vertical-a" +
                "lign: top; ";
            this.PrimeDisplayCode.Text = "���i&����";
            this.PrimeDisplayCode.Top = 0.02083331F;
            this.PrimeDisplayCode.Width = 0.5625002F;
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
            this.tb_ReportTitle});
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
            this.tb_ReportTitle.Text = "�D�ǐݒ�}�X�^���";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 2.78125F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.2708333F;
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
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line5,
            this.line2,
            this.label16,
            this.label18,
            this.label19,
            this.label20,
            this.label21,
            this.label23,
            this.label24,
            this.label25});
            this.TitleHeader.Height = 0.2669271F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
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
            this.line2.Top = 0.2291667F;
            this.line2.Width = 10.8F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.8F;
            this.line2.Y1 = 0.2291667F;
            this.line2.Y2 = 0.2291667F;
            // 
            // label16
            // 
            this.label16.Border.BottomColor = System.Drawing.Color.Black;
            this.label16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label16.Border.LeftColor = System.Drawing.Color.Black;
            this.label16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label16.Border.RightColor = System.Drawing.Color.Black;
            this.label16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label16.Border.TopColor = System.Drawing.Color.Black;
            this.label16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label16.Height = 0.15F;
            this.label16.HyperLink = "";
            this.label16.Left = 0F;
            this.label16.MultiLine = false;
            this.label16.Name = "label16";
            this.label16.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": �l�r ����; vertical-align: top; ";
            this.label16.Text = "���i������";
            this.label16.Top = 0.0625F;
            this.label16.Width = 1.0625F;
            // 
            // label18
            // 
            this.label18.Border.BottomColor = System.Drawing.Color.Black;
            this.label18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label18.Border.LeftColor = System.Drawing.Color.Black;
            this.label18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label18.Border.RightColor = System.Drawing.Color.Black;
            this.label18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label18.Border.TopColor = System.Drawing.Color.Black;
            this.label18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label18.Height = 0.15F;
            this.label18.HyperLink = "";
            this.label18.Left = 1.5625F;
            this.label18.MultiLine = false;
            this.label18.Name = "label18";
            this.label18.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": �l�r ����; vertical-align: top; ";
            this.label18.Text = "BL����";
            this.label18.Top = 0.0625F;
            this.label18.Width = 0.875F;
            // 
            // label19
            // 
            this.label19.Border.BottomColor = System.Drawing.Color.Black;
            this.label19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label19.Border.LeftColor = System.Drawing.Color.Black;
            this.label19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label19.Border.RightColor = System.Drawing.Color.Black;
            this.label19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label19.Border.TopColor = System.Drawing.Color.Black;
            this.label19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label19.Height = 0.15F;
            this.label19.HyperLink = "";
            this.label19.Left = 2.551136F;
            this.label19.MultiLine = false;
            this.label19.Name = "label19";
            this.label19.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": �l�r ����; vertical-align: top; ";
            this.label19.Text = "Ұ��";
            this.label19.Top = 0.0625F;
            this.label19.Width = 1.0625F;
            // 
            // label20
            // 
            this.label20.Border.BottomColor = System.Drawing.Color.Black;
            this.label20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label20.Border.LeftColor = System.Drawing.Color.Black;
            this.label20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label20.Border.RightColor = System.Drawing.Color.Black;
            this.label20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label20.Border.TopColor = System.Drawing.Color.Black;
            this.label20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label20.Height = 0.15F;
            this.label20.HyperLink = "";
            this.label20.Left = 3.982955F;
            this.label20.MultiLine = false;
            this.label20.Name = "label20";
            this.label20.Style = "ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8pt; font-famil" +
                "y: �l�r ����; vertical-align: top; ";
            this.label20.Text = "����";
            this.label20.Top = 0.0625F;
            this.label20.Width = 0.3124999F;
            // 
            // label21
            // 
            this.label21.Border.BottomColor = System.Drawing.Color.Black;
            this.label21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label21.Border.LeftColor = System.Drawing.Color.Black;
            this.label21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label21.Border.RightColor = System.Drawing.Color.Black;
            this.label21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label21.Border.TopColor = System.Drawing.Color.Black;
            this.label21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label21.Height = 0.15F;
            this.label21.HyperLink = "";
            this.label21.Left = 4.355113F;
            this.label21.MultiLine = false;
            this.label21.Name = "label21";
            this.label21.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": �l�r ����; vertical-align: top; ";
            this.label21.Text = "�d����";
            this.label21.Top = 0.0625F;
            this.label21.Width = 0.875F;
            // 
            // label23
            // 
            this.label23.Border.BottomColor = System.Drawing.Color.Black;
            this.label23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label23.Border.LeftColor = System.Drawing.Color.Black;
            this.label23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label23.Border.RightColor = System.Drawing.Color.Black;
            this.label23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label23.Border.TopColor = System.Drawing.Color.Black;
            this.label23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label23.Height = 0.15F;
            this.label23.HyperLink = "";
            this.label23.Left = 5.943182F;
            this.label23.MultiLine = false;
            this.label23.Name = "label23";
            this.label23.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": �l�r ����; vertical-align: top; ";
            this.label23.Text = "�ڸ�";
            this.label23.Top = 0.0625F;
            this.label23.Width = 0.875F;
            // 
            // label24
            // 
            this.label24.Border.BottomColor = System.Drawing.Color.Black;
            this.label24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label24.Border.LeftColor = System.Drawing.Color.Black;
            this.label24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label24.Border.RightColor = System.Drawing.Color.Black;
            this.label24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label24.Border.TopColor = System.Drawing.Color.Black;
            this.label24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label24.Height = 0.15F;
            this.label24.HyperLink = "";
            this.label24.Left = 8.034091F;
            this.label24.MultiLine = false;
            this.label24.Name = "label24";
            this.label24.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": �l�r ����; vertical-align: top; ";
            this.label24.Text = "���";
            this.label24.Top = 0.0625F;
            this.label24.Width = 0.875F;
            // 
            // label25
            // 
            this.label25.Border.BottomColor = System.Drawing.Color.Black;
            this.label25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label25.Border.LeftColor = System.Drawing.Color.Black;
            this.label25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label25.Border.RightColor = System.Drawing.Color.Black;
            this.label25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label25.Border.TopColor = System.Drawing.Color.Black;
            this.label25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label25.Height = 0.15F;
            this.label25.HyperLink = "";
            this.label25.Left = 10.09375F;
            this.label25.MultiLine = false;
            this.label25.Name = "label25";
            this.label25.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8pt; font-family" +
                ": �l�r ����; vertical-align: top; ";
            this.label25.Text = "�D�Ǖ\���敪";
            this.label25.Top = 0.0625F;
            this.label25.Width = 0.71F;
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
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.tb_SectionGuideSnm,
            this.tb_SectionCode});
            this.SectionHeader.DataField = "SectionCode";
            this.SectionHeader.Height = 0F;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.SectionHeader.AfterPrint += new System.EventHandler(this.SectionHeader_AfterPrint);
            // 
            // tb_SectionGuideSnm
            // 
            this.tb_SectionGuideSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_SectionGuideSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SectionGuideSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_SectionGuideSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SectionGuideSnm.Border.RightColor = System.Drawing.Color.Black;
            this.tb_SectionGuideSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SectionGuideSnm.Border.TopColor = System.Drawing.Color.Black;
            this.tb_SectionGuideSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SectionGuideSnm.CanShrink = true;
            this.tb_SectionGuideSnm.DataField = "SectionGuideSnm";
            this.tb_SectionGuideSnm.Height = 0.15F;
            this.tb_SectionGuideSnm.Left = 0F;
            this.tb_SectionGuideSnm.MultiLine = false;
            this.tb_SectionGuideSnm.Name = "tb_SectionGuideSnm";
            this.tb_SectionGuideSnm.Style = "ddo-char-set: 128; font-size: 8pt; font-family: �l�r ����; vertical-align: top; ";
            this.tb_SectionGuideSnm.Text = null;
            this.tb_SectionGuideSnm.Top = 0F;
            this.tb_SectionGuideSnm.Visible = false;
            this.tb_SectionGuideSnm.Width = 0.75F;
            // 
            // tb_SectionCode
            // 
            this.tb_SectionCode.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_SectionCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SectionCode.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_SectionCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SectionCode.Border.RightColor = System.Drawing.Color.Black;
            this.tb_SectionCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SectionCode.Border.TopColor = System.Drawing.Color.Black;
            this.tb_SectionCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SectionCode.CanShrink = true;
            this.tb_SectionCode.DataField = "SectionCode";
            this.tb_SectionCode.Height = 0.15F;
            this.tb_SectionCode.Left = 1F;
            this.tb_SectionCode.MultiLine = false;
            this.tb_SectionCode.Name = "tb_SectionCode";
            this.tb_SectionCode.Style = "ddo-char-set: 128; font-size: 8pt; font-family: �l�r ����; vertical-align: top; ";
            this.tb_SectionCode.Text = null;
            this.tb_SectionCode.Top = 0F;
            this.tb_SectionCode.Visible = false;
            this.tb_SectionCode.Width = 0.75F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Height = 0F;
            this.SectionFooter.KeepTogether = true;
            this.SectionFooter.Name = "SectionFooter";
            // 
            // PMKEN02013P_01A4C
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
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.SectionFooter);
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
            this.PageEnd += new System.EventHandler(this.DCZAI02163P_01A4C_PageEnd);
            this.ReportStart += new System.EventHandler(this.DCZAI02163P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.PartsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerShortName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TbsPartsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsHalfName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerDispOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrmSetDtlName1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMGroupName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrmSetDtlName2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrimeDisplayCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SectionGuideSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SectionCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion

        
	}
}
