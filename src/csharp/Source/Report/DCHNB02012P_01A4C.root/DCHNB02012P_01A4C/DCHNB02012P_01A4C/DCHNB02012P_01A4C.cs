//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �󒍁E�ݏo�m�F�\
// �v���O�����T�v   : �󒍁E�ݏo�m�F�\�̈󎚂��s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2008/08/07  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 980035 ���� ��`
// �� �� ��  2008/09/29  �C�����e : ���[���C�A�E�g�̂ݕύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �� �� ��  2008/10/31  �C�����e : ���v���z�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �� �� ��  2009/03/30  �C�����e : ��Q�Ή�10230�A10231�A12395�A12397
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/05/07  �C�����e : MANTIS�y13230�z���Ŏ��̋��_�o�͕s����C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : caohh
// �� �� ��  2011/08/11  �C�����e : Redmine#23472�Ή��F�u����Łv���폜
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/12/02  �C�����e : Redmine#8316�Ή��F�ݏo�m�F�\/���z�̎Z�o���@�̕ύX
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Specialized;
using DataDynamics.ActiveReports;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;
using Broadleaf.Drawing.Printing;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// �󒍊m�F�\�i���v�^�C�v�j���[�N���X
	/// </summary>
    /// <br>Programer  : 980035 ���� ��`</br>
    /// <br>Date       : 2008.09.29 ���[���C�A�E�g�̂ݕύX</br>
    /// <br>UpdateNote : 2008/10/31 �Ɠc �M�u�@����ŁA���v���z�ǉ�</br>
    /// <br>UpdateNote : 2009/03/30 ��� �r���@��Q�Ή�10230�A10231�A12395�A12397</br>
    /// <br>UpdateNote : 2011/08/11 caohh�@#23472�Ή��F�u����Łv���폜</br>
    /// <br>UpdateNote : 2011/12/02 �����@#8316�Ή��F �ݏo�m�F�\/���z�̎Z�o���@�̕ύX</br>
    public class DCHNB02012P_01A4C : DataDynamics.ActiveReports.ActiveReport3, IPrintActiveReportTypeCommon, IPrintActiveReportTypeList	
	{
		//================================================================================
		//  �R���X�g���N�^�[
		//================================================================================
		#region �R���X�g���N�^�[
		/// <summary>
		/// �R���X�g���N�^�[
		/// </summary>
		public DCHNB02012P_01A4C()
		{
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

		//�e�����`�F�b�N�}�[�N�i�������j

		private string _grossMarginCheckExpra;
		
		// ���o�����󎚍���
		private StringCollection _extraConditions;

		//// �e���͈͊Y���`�F�b�N
		//private StringCollection _makegrossmargin;
		
		// �t�b�^�[�o�͗L��
		private int _pageFooterOutCode;
		
		// �t�b�^���b�Z�[�W1
		private StringCollection _pageFooters;
		
		// ������
		private SFCMN06002C _printInfo;

        // �������
		private ExtrInfo_DCHNB02013E _extraInfo;
		

		// �֘A�f�[�^�I�u�W�F�N�g
		private ArrayList _otherDataList;

		#region  �w�i���������[�h(����)
		private int _watermarkMode = 0;
		private DataDynamics.ActiveReports.TextBox DATE;
		private DataDynamics.ActiveReports.TextBox TIME;
		private DataDynamics.ActiveReports.Label lblTitle;
		private DataDynamics.ActiveReports.Label lblPage;
        private DataDynamics.ActiveReports.TextBox txtPageNo;
        private Line line1;
		private DataDynamics.ActiveReports.Label label2;
		private DataDynamics.ActiveReports.Label label6;
		private DataDynamics.ActiveReports.TextBox Extraction;
		private DataDynamics.ActiveReports.TextBox Extraction2;
		private DataDynamics.ActiveReports.TextBox SORTTITLE;
		private DataDynamics.ActiveReports.TextBox textBox27;
		private DataDynamics.ActiveReports.TextBox textBox28;
		private DataDynamics.ActiveReports.TextBox textBox29;
        private DataDynamics.ActiveReports.TextBox textBox30;
		private Line line51;
        private DataDynamics.ActiveReports.Label label9;
		private ReportHeader reportHeader1;
        private ReportFooter reportFooter1;
        private GroupHeader TitleHeader;
        private Line line46;
        private GroupFooter TitleFooter;
		private Line line53;
#endregion

        private DataDynamics.ActiveReports.Label label3;
        private DataDynamics.ActiveReports.Label label10;
        private DataDynamics.ActiveReports.Label label11;
        private DataDynamics.ActiveReports.Label label14;
        private DataDynamics.ActiveReports.Label Label23;
        private DataDynamics.ActiveReports.Label label19;
        private DataDynamics.ActiveReports.Label label20;
        private DataDynamics.ActiveReports.Label label26;
        private DataDynamics.ActiveReports.Label Label_GrossMarginRate;
        private DataDynamics.ActiveReports.Label Label_Cost;
        private DataDynamics.ActiveReports.Label label17;
        private DataDynamics.ActiveReports.Label label30;
        private DataDynamics.ActiveReports.Label Label_GrossMargin;
        private DataDynamics.ActiveReports.TextBox FrontEmployeeNm;
        private DataDynamics.ActiveReports.TextBox SalesTotalTaxExc;
        private DataDynamics.ActiveReports.TextBox GrossMarginRate;
        private DataDynamics.ActiveReports.TextBox TotalCost;
        private DataDynamics.ActiveReports.TextBox CustomerCode;
        private DataDynamics.ActiveReports.TextBox SalesDate;
        private DataDynamics.ActiveReports.TextBox SearchSlipDate;
        private DataDynamics.ActiveReports.TextBox CustomerSnm;
        private DataDynamics.ActiveReports.TextBox Tax;
        private DataDynamics.ActiveReports.TextBox SalesSlipNum;
        private DataDynamics.ActiveReports.TextBox SalesEmployeeNm;
        private DataDynamics.ActiveReports.TextBox SalesSlipName;
        private DataDynamics.ActiveReports.TextBox GrossMarginMarkSlip;
        private DataDynamics.ActiveReports.Label Label_Percentage;
        private DataDynamics.ActiveReports.TextBox SalesInputName;
        private DataDynamics.ActiveReports.TextBox GrossProfit;
        private DataDynamics.ActiveReports.TextBox textBox3;
        private DataDynamics.ActiveReports.TextBox TextBox4;
        private DataDynamics.ActiveReports.Label Label;
        private DataDynamics.ActiveReports.TextBox Section_SalesMoney;
        private DataDynamics.ActiveReports.TextBox Section_TotalCostSl;
        private DataDynamics.ActiveReports.TextBox Section_SalesGrossProfit;
        private DataDynamics.ActiveReports.TextBox Section_SalesGrossMarginRate;
        private DataDynamics.ActiveReports.Label Section_SalesPercentage;
        private DataDynamics.ActiveReports.TextBox Section_SalesGrossMarginMark;
        private GroupHeader Header1;
        private GroupFooter Footer1;
        private GroupHeader SectionHeader;
        private Line line43;
        private GroupFooter SectionFooter;
        private GroupHeader GrandTotalHeader;
        private GroupFooter GrandTotalFooter;
        private DataDynamics.ActiveReports.TextBox Footer1Field;
        private DataDynamics.ActiveReports.TextBox textBox48;
        private DataDynamics.ActiveReports.TextBox Footer1_SalesMoney;
        private DataDynamics.ActiveReports.TextBox Footer1_TotalCostSl;
        private DataDynamics.ActiveReports.Label label29;
        private DataDynamics.ActiveReports.TextBox Footer1_SalesGrossProfit;
        private DataDynamics.ActiveReports.TextBox Footer1_SalesGrossMarginRate;
        private DataDynamics.ActiveReports.Label Footer1_SalesPercentage;
        private DataDynamics.ActiveReports.TextBox Footer1_SalesGrossMarginMark;
        private DataDynamics.ActiveReports.TextBox textBox2;
        private DataDynamics.ActiveReports.TextBox textBox16;
        private DataDynamics.ActiveReports.Label label13;
        private DataDynamics.ActiveReports.TextBox Grand_SalesMoney;
        private DataDynamics.ActiveReports.TextBox Grand_TotalCostSl;
        private DataDynamics.ActiveReports.TextBox Grand_SalesGrossProfit;
        private DataDynamics.ActiveReports.TextBox Grand_SalesGrossMarginRate;
        private DataDynamics.ActiveReports.Label Grand_SalesPercentage;
        private DataDynamics.ActiveReports.TextBox Grand_SalesGrossMarginMark;
        private Line line4;
        private Line line8;
        private Line line9;
        private DataDynamics.ActiveReports.TextBox SalesTotalTaxExcPlusTax;
        private DataDynamics.ActiveReports.Label label7;
        private SubReport Footer_SubReport;
        private GroupHeader DateHeader;
        private GroupFooter DateFooter;
        private DataDynamics.ActiveReports.TextBox textBox5;
        private DataDynamics.ActiveReports.TextBox textBox11;
        private DataDynamics.ActiveReports.TextBox Date_SalesMoney;
        private DataDynamics.ActiveReports.TextBox Date_TotalCostSl;
        private DataDynamics.ActiveReports.Label label12;
        private DataDynamics.ActiveReports.TextBox Date_SalesGrossProfit;
        private DataDynamics.ActiveReports.TextBox Date_SalesGrossMarginRate;
        private DataDynamics.ActiveReports.Label Date_SalesPercentage;
        private DataDynamics.ActiveReports.TextBox Date_SalesGrossMarginMark;
        private Line line2;
        private DataDynamics.ActiveReports.TextBox Section_SalesTax;
        private DataDynamics.ActiveReports.TextBox Section_SalesTotalAll;
        private DataDynamics.ActiveReports.TextBox Footer1_SalesTax;
        private DataDynamics.ActiveReports.TextBox Date_SalesTax;
        private DataDynamics.ActiveReports.TextBox Date_SalesTotalAll;
        private DataDynamics.ActiveReports.TextBox Footer1_SalesTotalAll;
        private DataDynamics.ActiveReports.TextBox Grand_SalesTax;
        private DataDynamics.ActiveReports.TextBox Grand_SalesTotalAll;

		//TODO 2:TODO1�֘A
		//�������
		private int _printCount = 1;

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
		/// �e���e�����`�F�b�N�}�[�N�i�������j����
		/// </summary>
		public string PageHeaderSubtitle
		{
			set
			{
				this._grossMarginCheckExpra = value;
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
				this._printInfo = value;
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
				
		#endregion
		
		#region IPrintActiveReportTypeCommon �����o
		//TODO 4:TODO1�֘A
		/// <summary>�v���O���X�o�[�J�E���g�A�b�v�C�x���g</summary>
		public event ProgressBarUpEventHandler ProgressBarUpEvent;

		/// <summary>�w�i���������[�h</summary>
		/// <value>0�F�w�i����������, 1:�w�i�������L��</value>
		public int WatermarkMode
		{
			set{}
			get{return this._watermarkMode;}
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
		/// </remarks>
		private void DCHNB02012P_01A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
            // �����擾
			this._extraInfo = (ExtrInfo_DCHNB02013E)this._printInfo.jyoken;

			//TODO 3:TODO1�֘A
			// �������������
			this._printCount = 0;
			
			// �r���\���E��\������
			foreach (Section section in this.Sections)
			{
				Section targetSection = section; 
				//this.SetVisibleRuledLine(ref targetSection);
			}

            // �O���[�v������
            this.ChangeGroupOrder();

            // �����E�e���o�͐���
            this.ChangeCostPrt(); // ADD 2009/03/30

            // ���v�󎚐���
            this.ChangeSumRec();

            //�ۗ��BTODO�Q��
			// �����E�e���o�͐���
			//this.ChangeCostPrt();

            // 2008.11.28 30413 ���� ���Ő���̕ύX >>>>>>START
            // 2008.07.29 30413 ���� ���Ő���̒ǉ� >>>>>>START
            // ���Őݒ�
            if (this._extraInfo.NewPageType == 0)
            {
                // ���_��
                this.SectionHeader.NewPage = NewPage.Before;

                this.Header1.NewPage = NewPage.None;
            }
            else if (this._extraInfo.NewPageType == 1)
            {
                // ���v��
                //this.SectionHeader.NewPage = NewPage.Before;
                
                //this.Header1.NewPage = NewPage.Before;

                switch (this._extraInfo.SortOrder)
                {
                    case 0:  // �󒍓�+�`�[�ԍ�
                    case 1:  // �`�[�ԍ�
                        {
                            this.SectionHeader.NewPage = NewPage.None;

                            this.Header1.NewPage = NewPage.None;
                            break;
                        }
                    case 2:  // ���Ӑ�+�`�[�ԍ�
                    case 3:  // �S����+�`�[�ԍ�
                        {
                            this.SectionHeader.NewPage = NewPage.Before;

                            this.Header1.NewPage = NewPage.Before;
                            break;
                        }
                }
            }
            else
            {
                // ���y�[�W���Ȃ�
                this.SectionHeader.NewPage = NewPage.None;

                this.Header1.NewPage = NewPage.None;
            }
            // 2008.07.29 30413 ���� ���Ő���̒ǉ� <<<<<<END
            // 2008.11.28 30413 ���� ���Ő���̕ύX <<<<<<END
            
        }

		/// <summary>
		/// �y�[�W�w�b�_�t�H�[�}�b�g�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="eArgs">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �Z�N�V�����̃f�[�^�����[�h����A�����ꂽ��ɔ������܂��B</br>
		/// <br>Programmer	: 18012 Y.Sasaki</br>
		/// <br>Date		: 2005.11.09</br>
		/// </remarks>
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			// �\�[�g��
			this.SORTTITLE.Text = this._pageHeaderSortOderTitle;

			//�e�����}�[�N�i�������j
			this.Extraction2.Text = this._grossMarginCheckExpra;

			// �쐬���t
			DateTime now = DateTime.Now;
    		this.DATE.Text = TDateTime.DateTimeToString("YYYY/MM/DD", now);
			
			// �쐬����
            this.TIME.Text = TDateTime.DateTimeToString("HH:MM", now);

			// �w���o�����x
			for (int i = 0; i < this._extraConditions.Count; i++)
			{
				this.Extraction.Text = this._extraConditions[i];
			}

		}

        ///// <summary>
        ///// ���_�w�b�_�t�H�[�}�b�g�C�x���g
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="eArgs">�C�x���g�n���h��</param>
        ///// <remarks>
        ///// <br>Note		: �Z�N�V�����̃f�[�^�����[�h����A�����ꂽ��ɔ������܂��B</br>
        ///// <br>Programmer	: 18012 Y.Sasaki</br>
        ///// <br>Date		: 2005.11.09</br>
        ///// </remarks>
        //private void ExtraHeader_Format(object sender, System.EventArgs eArgs)
        //{
        //    // �w�b�_�o�͐���
        //    if (this._extraCondHeadOutDiv == 0)
        //    {
        //        // >>>>> 2006.08.21 Y.Sasaki CHG START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
        //        // ���y�[�W�o��
        //        this.ExtraHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
        //        //// ���y�[�W�o��
        //        //this.ExtraHeader.RepeatStyle = RepeatStyle.OnPage;
        //        // <<<<< 2006.08.21 Y.Sasaki CHG END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //
        //    } 
        //    else 
        //    {
        //        // �擪�y�[�W�̂�
        //        this.ExtraHeader.RepeatStyle = RepeatStyle.None;
        //    }
			
        //    // �w�b�_�[�T�u���|�[�g�쐬
        //    ListCommon_ExtraHeader rpt   = new ListCommon_ExtraHeader();

        //    //// ���o�����󎚍��ڐݒ�
        //    rpt.ExtraConditions         = this._extraConditions;
			
        //    //this.Header_SubReport.Report = rpt;
			
        //}

		/// <summary>
		/// �^�C�g���w�b�_�t�H�[�}�b�g�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="eArgs">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �Z�N�V�����̃f�[�^�����[�h����A�����ꂽ��ɔ������܂��B</br>
		/// <br>Programmer	: 18012 Y.Sasaki</br>
		/// <br>Date		: 2005.11.09</br>
		/// </remarks>
		private void TitleHeader_Format(object sender, System.EventArgs eArgs)
		{
		}

		/// <summary>
		/// �y�[�W�t�b�^�t�H�[�}�b�g�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="eArgs">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �Z�N�V�����̃f�[�^�����[�h����A�����ꂽ��ɔ������܂��B</br>
		/// <br>Programmer	: 18012 Y.Sasaki</br>
		/// <br>Date		: 2005.11.09</br>
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
		/// <param name="eArgs">�C�x���g�f�[�^</param>
		/// <remarks>
		/// <br>Note        : �Z�N�V�������y�[�W�ɕ`�悳�ꂽ��ɔ������܂��B</br>
		/// <br>Programmer  : 30191 Ai Mabuchi</br>
		/// <br>Date        : 2008.01.23</br>
		/// </remarks>
		private void Detail_AfterPrint(object sender, System.EventArgs eArgs)
		{
			//TODO 1�FDebug�̎������G���[���o��
			// ��������J�E���g�A�b�v
			this._printCount++;

			if (this.ProgressBarUpEvent != null)
			{
				this.ProgressBarUpEvent(this, this._printCount);
			}
		}
		#endregion
		
		// ===============================================================================
		// ActiveReports�f�U�C�i�Ő������ꂽ�R�[�h
		// ===============================================================================

		private void SectionFooter_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		private void ExtraFooter_Format(object sender, System.EventArgs eArgs)
		{
			
		}

		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.PageHeader PageHeader;
		private DataDynamics.ActiveReports.GroupHeader ExtraHeader;
		private DataDynamics.ActiveReports.Detail Detail;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		/// <summary>
		/// InitializeComponent
		/// </summary>
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCHNB02012P_01A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.SalesTotalTaxExcPlusTax = new DataDynamics.ActiveReports.TextBox();
            this.FrontEmployeeNm = new DataDynamics.ActiveReports.TextBox();
            this.SalesTotalTaxExc = new DataDynamics.ActiveReports.TextBox();
            this.GrossMarginRate = new DataDynamics.ActiveReports.TextBox();
            this.TotalCost = new DataDynamics.ActiveReports.TextBox();
            this.CustomerCode = new DataDynamics.ActiveReports.TextBox();
            this.SalesDate = new DataDynamics.ActiveReports.TextBox();
            this.SearchSlipDate = new DataDynamics.ActiveReports.TextBox();
            this.CustomerSnm = new DataDynamics.ActiveReports.TextBox();
            this.Tax = new DataDynamics.ActiveReports.TextBox();
            this.SalesSlipNum = new DataDynamics.ActiveReports.TextBox();
            this.SalesEmployeeNm = new DataDynamics.ActiveReports.TextBox();
            this.SalesSlipName = new DataDynamics.ActiveReports.TextBox();
            this.GrossMarginMarkSlip = new DataDynamics.ActiveReports.TextBox();
            this.Label_Percentage = new DataDynamics.ActiveReports.Label();
            this.SalesInputName = new DataDynamics.ActiveReports.TextBox();
            this.GrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.line51 = new DataDynamics.ActiveReports.Line();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.DATE = new DataDynamics.ActiveReports.TextBox();
            this.TIME = new DataDynamics.ActiveReports.TextBox();
            this.lblTitle = new DataDynamics.ActiveReports.Label();
            this.lblPage = new DataDynamics.ActiveReports.Label();
            this.txtPageNo = new DataDynamics.ActiveReports.TextBox();
            this.label9 = new DataDynamics.ActiveReports.Label();
            this.line53 = new DataDynamics.ActiveReports.Line();
            this.SORTTITLE = new DataDynamics.ActiveReports.TextBox();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Extraction = new DataDynamics.ActiveReports.TextBox();
            this.Extraction2 = new DataDynamics.ActiveReports.TextBox();
            this.label2 = new DataDynamics.ActiveReports.Label();
            this.line1 = new DataDynamics.ActiveReports.Line();
            this.textBox28 = new DataDynamics.ActiveReports.TextBox();
            this.textBox29 = new DataDynamics.ActiveReports.TextBox();
            this.textBox30 = new DataDynamics.ActiveReports.TextBox();
            this.textBox27 = new DataDynamics.ActiveReports.TextBox();
            this.label6 = new DataDynamics.ActiveReports.Label();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.reportHeader1 = new DataDynamics.ActiveReports.ReportHeader();
            this.reportFooter1 = new DataDynamics.ActiveReports.ReportFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.label3 = new DataDynamics.ActiveReports.Label();
            this.label10 = new DataDynamics.ActiveReports.Label();
            this.label11 = new DataDynamics.ActiveReports.Label();
            this.label14 = new DataDynamics.ActiveReports.Label();
            this.Label23 = new DataDynamics.ActiveReports.Label();
            this.label19 = new DataDynamics.ActiveReports.Label();
            this.label20 = new DataDynamics.ActiveReports.Label();
            this.label26 = new DataDynamics.ActiveReports.Label();
            this.Label_GrossMarginRate = new DataDynamics.ActiveReports.Label();
            this.Label_Cost = new DataDynamics.ActiveReports.Label();
            this.label17 = new DataDynamics.ActiveReports.Label();
            this.label30 = new DataDynamics.ActiveReports.Label();
            this.Label_GrossMargin = new DataDynamics.ActiveReports.Label();
            this.line46 = new DataDynamics.ActiveReports.Line();
            this.label7 = new DataDynamics.ActiveReports.Label();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox3 = new DataDynamics.ActiveReports.TextBox();
            this.TextBox4 = new DataDynamics.ActiveReports.TextBox();
            this.Label = new DataDynamics.ActiveReports.Label();
            this.Section_SalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.Section_TotalCostSl = new DataDynamics.ActiveReports.TextBox();
            this.Section_SalesGrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.Section_SalesGrossMarginRate = new DataDynamics.ActiveReports.TextBox();
            this.Section_SalesPercentage = new DataDynamics.ActiveReports.Label();
            this.Section_SalesGrossMarginMark = new DataDynamics.ActiveReports.TextBox();
            this.Header1 = new DataDynamics.ActiveReports.GroupHeader();
            this.Footer1 = new DataDynamics.ActiveReports.GroupFooter();
            this.Footer1Field = new DataDynamics.ActiveReports.TextBox();
            this.textBox48 = new DataDynamics.ActiveReports.TextBox();
            this.Footer1_SalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.Footer1_TotalCostSl = new DataDynamics.ActiveReports.TextBox();
            this.label29 = new DataDynamics.ActiveReports.Label();
            this.Footer1_SalesGrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.Footer1_SalesGrossMarginRate = new DataDynamics.ActiveReports.TextBox();
            this.Footer1_SalesPercentage = new DataDynamics.ActiveReports.Label();
            this.Footer1_SalesGrossMarginMark = new DataDynamics.ActiveReports.TextBox();
            this.line4 = new DataDynamics.ActiveReports.Line();
            this.Footer1_SalesTax = new DataDynamics.ActiveReports.TextBox();
            this.Footer1_SalesTotalAll = new DataDynamics.ActiveReports.TextBox();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.line43 = new DataDynamics.ActiveReports.Line();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.line8 = new DataDynamics.ActiveReports.Line();
            this.Section_SalesTax = new DataDynamics.ActiveReports.TextBox();
            this.Section_SalesTotalAll = new DataDynamics.ActiveReports.TextBox();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox2 = new DataDynamics.ActiveReports.TextBox();
            this.textBox16 = new DataDynamics.ActiveReports.TextBox();
            this.label13 = new DataDynamics.ActiveReports.Label();
            this.Grand_SalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.Grand_TotalCostSl = new DataDynamics.ActiveReports.TextBox();
            this.Grand_SalesGrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.Grand_SalesGrossMarginRate = new DataDynamics.ActiveReports.TextBox();
            this.Grand_SalesPercentage = new DataDynamics.ActiveReports.Label();
            this.Grand_SalesGrossMarginMark = new DataDynamics.ActiveReports.TextBox();
            this.line9 = new DataDynamics.ActiveReports.Line();
            this.Grand_SalesTax = new DataDynamics.ActiveReports.TextBox();
            this.Grand_SalesTotalAll = new DataDynamics.ActiveReports.TextBox();
            this.DateHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.DateFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.textBox5 = new DataDynamics.ActiveReports.TextBox();
            this.textBox11 = new DataDynamics.ActiveReports.TextBox();
            this.Date_SalesMoney = new DataDynamics.ActiveReports.TextBox();
            this.Date_TotalCostSl = new DataDynamics.ActiveReports.TextBox();
            this.label12 = new DataDynamics.ActiveReports.Label();
            this.Date_SalesGrossProfit = new DataDynamics.ActiveReports.TextBox();
            this.Date_SalesGrossMarginRate = new DataDynamics.ActiveReports.TextBox();
            this.Date_SalesPercentage = new DataDynamics.ActiveReports.Label();
            this.Date_SalesGrossMarginMark = new DataDynamics.ActiveReports.TextBox();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.Date_SalesTax = new DataDynamics.ActiveReports.TextBox();
            this.Date_SalesTotalAll = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.SalesTotalTaxExcPlusTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrontEmployeeNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesTotalTaxExc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchSlipDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerSnm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesSlipNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesEmployeeNm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesSlipName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginMarkSlip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_Percentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesInputName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TIME)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPageNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SORTTITLE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Extraction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Extraction2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_GrossMarginRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_Cost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_GrossMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_SalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_TotalCostSl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_SalesGrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_SalesGrossMarginRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_SalesPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_SalesGrossMarginMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer1Field)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer1_SalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer1_TotalCostSl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer1_SalesGrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer1_SalesGrossMarginRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer1_SalesPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer1_SalesGrossMarginMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer1_SalesTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer1_SalesTotalAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_SalesTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_SalesTotalAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grand_SalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grand_TotalCostSl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grand_SalesGrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grand_SalesGrossMarginRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grand_SalesPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grand_SalesGrossMarginMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grand_SalesTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grand_SalesTotalAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_SalesMoney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_TotalCostSl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_SalesGrossProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_SalesGrossMarginRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_SalesPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_SalesGrossMarginMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_SalesTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_SalesTotalAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.SalesTotalTaxExcPlusTax,
            this.FrontEmployeeNm,
            this.SalesTotalTaxExc,
            this.GrossMarginRate,
            this.TotalCost,
            this.CustomerCode,
            this.SalesDate,
            this.SearchSlipDate,
            this.CustomerSnm,
            this.Tax,
            this.SalesSlipNum,
            this.SalesEmployeeNm,
            this.SalesSlipName,
            this.GrossMarginMarkSlip,
            this.Label_Percentage,
            this.SalesInputName,
            this.GrossProfit,
            this.line51});
            this.Detail.Height = 0.2395833F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Format += new System.EventHandler(this.Detail_Format);
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            // 
            // SalesTotalTaxExcPlusTax
            // 
            this.SalesTotalTaxExcPlusTax.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesTotalTaxExcPlusTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesTotalTaxExcPlusTax.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesTotalTaxExcPlusTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesTotalTaxExcPlusTax.Border.RightColor = System.Drawing.Color.Black;
            this.SalesTotalTaxExcPlusTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesTotalTaxExcPlusTax.Border.TopColor = System.Drawing.Color.Black;
            this.SalesTotalTaxExcPlusTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesTotalTaxExcPlusTax.CanGrow = false;
            this.SalesTotalTaxExcPlusTax.DataField = "SalesTotalTaxExcPlusTax";
            this.SalesTotalTaxExcPlusTax.Height = 0.156F;
            this.SalesTotalTaxExcPlusTax.Left = 7.75F;
            this.SalesTotalTaxExcPlusTax.Name = "SalesTotalTaxExcPlusTax";
            this.SalesTotalTaxExcPlusTax.OutputFormat = resources.GetString("SalesTotalTaxExcPlusTax.OutputFormat");
            this.SalesTotalTaxExcPlusTax.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.SalesTotalTaxExcPlusTax.Text = "123,456,789";
            this.SalesTotalTaxExcPlusTax.Top = 0.0625F;
            this.SalesTotalTaxExcPlusTax.Width = 0.6875F;
            // 
            // FrontEmployeeNm
            // 
            this.FrontEmployeeNm.Border.BottomColor = System.Drawing.Color.Black;
            this.FrontEmployeeNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FrontEmployeeNm.Border.LeftColor = System.Drawing.Color.Black;
            this.FrontEmployeeNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FrontEmployeeNm.Border.RightColor = System.Drawing.Color.Black;
            this.FrontEmployeeNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FrontEmployeeNm.Border.TopColor = System.Drawing.Color.Black;
            this.FrontEmployeeNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.FrontEmployeeNm.CanGrow = false;
            this.FrontEmployeeNm.DataField = "FrontEmployeeNm";
            this.FrontEmployeeNm.Height = 0.156F;
            this.FrontEmployeeNm.Left = 4.8125F;
            this.FrontEmployeeNm.Name = "FrontEmployeeNm";
            this.FrontEmployeeNm.OutputFormat = resources.GetString("FrontEmployeeNm.OutputFormat");
            this.FrontEmployeeNm.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; white-space: nowrap; vertical-align: top; ";
            this.FrontEmployeeNm.Text = "��t�]�ƈ�����";
            this.FrontEmployeeNm.Top = 0.0625F;
            this.FrontEmployeeNm.Width = 0.8125F;
            // 
            // SalesTotalTaxExc
            // 
            this.SalesTotalTaxExc.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesTotalTaxExc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesTotalTaxExc.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesTotalTaxExc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesTotalTaxExc.Border.RightColor = System.Drawing.Color.Black;
            this.SalesTotalTaxExc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesTotalTaxExc.Border.TopColor = System.Drawing.Color.Black;
            this.SalesTotalTaxExc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesTotalTaxExc.CanGrow = false;
            this.SalesTotalTaxExc.DataField = "SalesTotalTaxExc";
            this.SalesTotalTaxExc.Height = 0.156F;
            this.SalesTotalTaxExc.Left = 6.4375F;
            this.SalesTotalTaxExc.Name = "SalesTotalTaxExc";
            this.SalesTotalTaxExc.OutputFormat = resources.GetString("SalesTotalTaxExc.OutputFormat");
            this.SalesTotalTaxExc.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.SalesTotalTaxExc.Text = "999,999,999";
            this.SalesTotalTaxExc.Top = 0.0625F;
            this.SalesTotalTaxExc.Width = 0.6875F;
            // 
            // GrossMarginRate
            // 
            this.GrossMarginRate.Border.BottomColor = System.Drawing.Color.Black;
            this.GrossMarginRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossMarginRate.Border.LeftColor = System.Drawing.Color.Black;
            this.GrossMarginRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossMarginRate.Border.RightColor = System.Drawing.Color.Black;
            this.GrossMarginRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossMarginRate.Border.TopColor = System.Drawing.Color.Black;
            this.GrossMarginRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossMarginRate.CanGrow = false;
            this.GrossMarginRate.DataField = "GrossMarginRate";
            this.GrossMarginRate.Height = 0.156F;
            this.GrossMarginRate.Left = 9.9375F;
            this.GrossMarginRate.Name = "GrossMarginRate";
            this.GrossMarginRate.OutputFormat = resources.GetString("GrossMarginRate.OutputFormat");
            this.GrossMarginRate.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: �l�r" +
                " �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.GrossMarginRate.Text = "-100.00";
            this.GrossMarginRate.Top = 0.0625F;
            this.GrossMarginRate.Width = 0.4375F;
            // 
            // TotalCost
            // 
            this.TotalCost.Border.BottomColor = System.Drawing.Color.Black;
            this.TotalCost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalCost.Border.LeftColor = System.Drawing.Color.Black;
            this.TotalCost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalCost.Border.RightColor = System.Drawing.Color.Black;
            this.TotalCost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalCost.Border.TopColor = System.Drawing.Color.Black;
            this.TotalCost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TotalCost.CanGrow = false;
            this.TotalCost.DataField = "TotalCost";
            this.TotalCost.Height = 0.156F;
            this.TotalCost.Left = 8.5625F;
            this.TotalCost.Name = "TotalCost";
            this.TotalCost.OutputFormat = resources.GetString("TotalCost.OutputFormat");
            this.TotalCost.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.TotalCost.Text = "12345678945";
            this.TotalCost.Top = 0.0625F;
            this.TotalCost.Width = 0.6875F;
            // 
            // CustomerCode
            // 
            this.CustomerCode.Border.BottomColor = System.Drawing.Color.Black;
            this.CustomerCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode.Border.LeftColor = System.Drawing.Color.Black;
            this.CustomerCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode.Border.RightColor = System.Drawing.Color.Black;
            this.CustomerCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode.Border.TopColor = System.Drawing.Color.Black;
            this.CustomerCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerCode.CanGrow = false;
            this.CustomerCode.DataField = "CustomerCode";
            this.CustomerCode.Height = 0.156F;
            this.CustomerCode.Left = 0F;
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.OutputFormat = resources.GetString("CustomerCode.OutputFormat");
            this.CustomerCode.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.CustomerCode.Text = "99999999";
            this.CustomerCode.Top = 0.0625F;
            this.CustomerCode.Width = 0.5F;
            // 
            // SalesDate
            // 
            this.SalesDate.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesDate.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesDate.Border.RightColor = System.Drawing.Color.Black;
            this.SalesDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesDate.Border.TopColor = System.Drawing.Color.Black;
            this.SalesDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesDate.CanGrow = false;
            this.SalesDate.DataField = "SalesDate";
            this.SalesDate.Height = 0.156F;
            this.SalesDate.Left = 2.0625F;
            this.SalesDate.Name = "SalesDate";
            this.SalesDate.OutputFormat = resources.GetString("SalesDate.OutputFormat");
            this.SalesDate.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; white-space: nowrap; vertical-align: top; ";
            this.SalesDate.Text = "99/99/99";
            this.SalesDate.Top = 0.0625F;
            this.SalesDate.Width = 0.5F;
            // 
            // SearchSlipDate
            // 
            this.SearchSlipDate.Border.BottomColor = System.Drawing.Color.Black;
            this.SearchSlipDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SearchSlipDate.Border.LeftColor = System.Drawing.Color.Black;
            this.SearchSlipDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SearchSlipDate.Border.RightColor = System.Drawing.Color.Black;
            this.SearchSlipDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SearchSlipDate.Border.TopColor = System.Drawing.Color.Black;
            this.SearchSlipDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SearchSlipDate.CanGrow = false;
            this.SearchSlipDate.DataField = "SearchSlipDate";
            this.SearchSlipDate.Height = 0.156F;
            this.SearchSlipDate.Left = 2.5625F;
            this.SearchSlipDate.Name = "SearchSlipDate";
            this.SearchSlipDate.OutputFormat = resources.GetString("SearchSlipDate.OutputFormat");
            this.SearchSlipDate.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; white-space: nowrap; vertical-align: top; ";
            this.SearchSlipDate.Text = "99/99/99";
            this.SearchSlipDate.Top = 0.0625F;
            this.SearchSlipDate.Width = 0.5F;
            // 
            // CustomerSnm
            // 
            this.CustomerSnm.Border.BottomColor = System.Drawing.Color.Black;
            this.CustomerSnm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerSnm.Border.LeftColor = System.Drawing.Color.Black;
            this.CustomerSnm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerSnm.Border.RightColor = System.Drawing.Color.Black;
            this.CustomerSnm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerSnm.Border.TopColor = System.Drawing.Color.Black;
            this.CustomerSnm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerSnm.CanGrow = false;
            this.CustomerSnm.DataField = "CustomerSnm";
            this.CustomerSnm.Height = 0.156F;
            this.CustomerSnm.Left = 0.5F;
            this.CustomerSnm.Name = "CustomerSnm";
            this.CustomerSnm.Style = "color: Black; ddo-char-set: 1; font-weight: normal; font-size: 8pt; white-space: " +
                "nowrap; vertical-align: top; ";
            this.CustomerSnm.Text = "���񂩂����񂩂����񂩂����񂩂����񂩂�";
            this.CustomerSnm.Top = 0.0625F;
            this.CustomerSnm.Width = 1.5625F;
            // 
            // Tax
            // 
            this.Tax.Border.BottomColor = System.Drawing.Color.Black;
            this.Tax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tax.Border.LeftColor = System.Drawing.Color.Black;
            this.Tax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tax.Border.RightColor = System.Drawing.Color.Black;
            this.Tax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tax.Border.TopColor = System.Drawing.Color.Black;
            this.Tax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Tax.CanGrow = false;
            this.Tax.DataField = "Tax";
            this.Tax.Height = 0.156F;
            this.Tax.Left = 7.125F;
            this.Tax.Name = "Tax";
            this.Tax.OutputFormat = resources.GetString("Tax.OutputFormat");
            this.Tax.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.Tax.Text = "1236547894";
            this.Tax.Top = 0.0625F;
            this.Tax.Visible = false;
            this.Tax.Width = 0.625F;
            // 
            // SalesSlipNum
            // 
            this.SalesSlipNum.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesSlipNum.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipNum.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesSlipNum.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipNum.Border.RightColor = System.Drawing.Color.Black;
            this.SalesSlipNum.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipNum.Border.TopColor = System.Drawing.Color.Black;
            this.SalesSlipNum.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipNum.CanGrow = false;
            this.SalesSlipNum.DataField = "SalesSlipNum";
            this.SalesSlipNum.Height = 0.156F;
            this.SalesSlipNum.Left = 3.0625F;
            this.SalesSlipNum.Name = "SalesSlipNum";
            this.SalesSlipNum.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.SalesSlipNum.Text = "999999999";
            this.SalesSlipNum.Top = 0.0625F;
            this.SalesSlipNum.Width = 0.5625F;
            // 
            // SalesEmployeeNm
            // 
            this.SalesEmployeeNm.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesEmployeeNm.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesEmployeeNm.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesEmployeeNm.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesEmployeeNm.Border.RightColor = System.Drawing.Color.Black;
            this.SalesEmployeeNm.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesEmployeeNm.Border.TopColor = System.Drawing.Color.Black;
            this.SalesEmployeeNm.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesEmployeeNm.CanGrow = false;
            this.SalesEmployeeNm.DataField = "SalesEmployeeNm";
            this.SalesEmployeeNm.Height = 0.156F;
            this.SalesEmployeeNm.Left = 4F;
            this.SalesEmployeeNm.Name = "SalesEmployeeNm";
            this.SalesEmployeeNm.Style = "color: Black; ddo-char-set: 1; font-weight: normal; font-size: 8pt; white-space: " +
                "nowrap; vertical-align: top; ";
            this.SalesEmployeeNm.Text = "�̔��]�ƈ�����";
            this.SalesEmployeeNm.Top = 0.0625F;
            this.SalesEmployeeNm.Width = 0.8125F;
            // 
            // SalesSlipName
            // 
            this.SalesSlipName.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesSlipName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipName.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesSlipName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipName.Border.RightColor = System.Drawing.Color.Black;
            this.SalesSlipName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipName.Border.TopColor = System.Drawing.Color.Black;
            this.SalesSlipName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesSlipName.CanGrow = false;
            this.SalesSlipName.DataField = "SalesSlipName";
            this.SalesSlipName.Height = 0.156F;
            this.SalesSlipName.Left = 3.625F;
            this.SalesSlipName.Name = "SalesSlipName";
            this.SalesSlipName.Style = "color: Black; ddo-char-set: 1; font-weight: normal; font-size: 8pt; white-space: " +
                "nowrap; vertical-align: top; ";
            this.SalesSlipName.Text = "�`�敪";
            this.SalesSlipName.Top = 0.0625F;
            this.SalesSlipName.Width = 0.375F;
            // 
            // GrossMarginMarkSlip
            // 
            this.GrossMarginMarkSlip.Border.BottomColor = System.Drawing.Color.Black;
            this.GrossMarginMarkSlip.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossMarginMarkSlip.Border.LeftColor = System.Drawing.Color.Black;
            this.GrossMarginMarkSlip.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossMarginMarkSlip.Border.RightColor = System.Drawing.Color.Black;
            this.GrossMarginMarkSlip.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossMarginMarkSlip.Border.TopColor = System.Drawing.Color.Black;
            this.GrossMarginMarkSlip.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossMarginMarkSlip.CanGrow = false;
            this.GrossMarginMarkSlip.DataField = "GrossMarginMarkSlip";
            this.GrossMarginMarkSlip.Height = 0.156F;
            this.GrossMarginMarkSlip.Left = 10.5F;
            this.GrossMarginMarkSlip.Name = "GrossMarginMarkSlip";
            this.GrossMarginMarkSlip.OutputFormat = resources.GetString("GrossMarginMarkSlip.OutputFormat");
            this.GrossMarginMarkSlip.Style = "color: Black; ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: �l�r " +
                "����; vertical-align: top; ";
            this.GrossMarginMarkSlip.Text = "��";
            this.GrossMarginMarkSlip.Top = 0.0625F;
            this.GrossMarginMarkSlip.Width = 0.1875F;
            // 
            // Label_Percentage
            // 
            this.Label_Percentage.Border.BottomColor = System.Drawing.Color.Black;
            this.Label_Percentage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Percentage.Border.LeftColor = System.Drawing.Color.Black;
            this.Label_Percentage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Percentage.Border.RightColor = System.Drawing.Color.Black;
            this.Label_Percentage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Percentage.Border.TopColor = System.Drawing.Color.Black;
            this.Label_Percentage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Percentage.Height = 0.156F;
            this.Label_Percentage.HyperLink = "";
            this.Label_Percentage.Left = 10.375F;
            this.Label_Percentage.Name = "Label_Percentage";
            this.Label_Percentage.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.Label_Percentage.Text = "��";
            this.Label_Percentage.Top = 0.0625F;
            this.Label_Percentage.Width = 0.125F;
            // 
            // SalesInputName
            // 
            this.SalesInputName.Border.BottomColor = System.Drawing.Color.Black;
            this.SalesInputName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesInputName.Border.LeftColor = System.Drawing.Color.Black;
            this.SalesInputName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesInputName.Border.RightColor = System.Drawing.Color.Black;
            this.SalesInputName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesInputName.Border.TopColor = System.Drawing.Color.Black;
            this.SalesInputName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SalesInputName.CanGrow = false;
            this.SalesInputName.DataField = "SalesInputName";
            this.SalesInputName.Height = 0.156F;
            this.SalesInputName.Left = 5.625F;
            this.SalesInputName.Name = "SalesInputName";
            this.SalesInputName.OutputFormat = resources.GetString("SalesInputName.OutputFormat");
            this.SalesInputName.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: normal; font-size: " +
                "8pt; white-space: nowrap; vertical-align: top; ";
            this.SalesInputName.Text = "������͎Җ���";
            this.SalesInputName.Top = 0.0625F;
            this.SalesInputName.Width = 0.8125F;
            // 
            // GrossProfit
            // 
            this.GrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.GrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.GrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.GrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.GrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.GrossProfit.CanGrow = false;
            this.GrossProfit.DataField = "GrossProfit";
            this.GrossProfit.Height = 0.156F;
            this.GrossProfit.Left = 9.25F;
            this.GrossProfit.Name = "GrossProfit";
            this.GrossProfit.OutputFormat = resources.GetString("GrossProfit.OutputFormat");
            this.GrossProfit.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: normal; font-size:" +
                " 8pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.GrossProfit.Text = "12345678945";
            this.GrossProfit.Top = 0.0625F;
            this.GrossProfit.Width = 0.6875F;
            // 
            // line51
            // 
            this.line51.Border.BottomColor = System.Drawing.Color.Black;
            this.line51.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line51.Border.LeftColor = System.Drawing.Color.Black;
            this.line51.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line51.Border.RightColor = System.Drawing.Color.Black;
            this.line51.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line51.Border.TopColor = System.Drawing.Color.Black;
            this.line51.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line51.Height = 0F;
            this.line51.Left = 0F;
            this.line51.LineWeight = 2F;
            this.line51.Name = "line51";
            this.line51.Top = 0F;
            this.line51.Width = 10.875F;
            this.line51.X1 = 0F;
            this.line51.X2 = 10.875F;
            this.line51.Y1 = 0F;
            this.line51.Y2 = 0F;
            // 
            // PageHeader
            // 
            this.PageHeader.CanShrink = true;
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.DATE,
            this.TIME,
            this.lblTitle,
            this.lblPage,
            this.txtPageNo,
            this.label9,
            this.line53,
            this.SORTTITLE});
            this.PageHeader.Height = 0.271F;
            this.PageHeader.Name = "PageHeader";
            this.PageHeader.Format += new System.EventHandler(this.PageHeader_Format);
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
            this.DATE.Height = 0.156F;
            this.DATE.Left = 8.5F;
            this.DATE.Name = "DATE";
            this.DATE.Style = "color: Black; ddo-char-set: 1; font-size: 8pt; font-family: �l�r ����; vertical-align" +
                ": top; ";
            this.DATE.Text = null;
            this.DATE.Top = 0.063F;
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
            this.TIME.Height = 0.125F;
            this.TIME.Left = 9.438F;
            this.TIME.Name = "TIME";
            this.TIME.Style = "color: Black; ddo-char-set: 1; font-size: 8pt; font-family: �l�r ����; vertical-align" +
                ": top; ";
            this.TIME.Text = null;
            this.TIME.Top = 0.063F;
            this.TIME.Width = 0.5F;
            // 
            // lblTitle
            // 
            this.lblTitle.Border.BottomColor = System.Drawing.Color.Black;
            this.lblTitle.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTitle.Border.LeftColor = System.Drawing.Color.Black;
            this.lblTitle.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTitle.Border.RightColor = System.Drawing.Color.Black;
            this.lblTitle.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTitle.Border.TopColor = System.Drawing.Color.Black;
            this.lblTitle.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblTitle.Height = 0.25F;
            this.lblTitle.HyperLink = null;
            this.lblTitle.Left = 0.25F;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Style = "color: Black; ddo-char-set: 128; font-weight: bold; font-style: italic; font-size" +
                ": 14.25pt; font-family: �l�r ����; vertical-align: top; ";
            this.lblTitle.Text = "�󒍊m�F�\�i���v�^�C�v�j";
            this.lblTitle.Top = 0F;
            this.lblTitle.Width = 2.5625F;
            // 
            // lblPage
            // 
            this.lblPage.Border.BottomColor = System.Drawing.Color.Black;
            this.lblPage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPage.Border.LeftColor = System.Drawing.Color.Black;
            this.lblPage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPage.Border.RightColor = System.Drawing.Color.Black;
            this.lblPage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPage.Border.TopColor = System.Drawing.Color.Black;
            this.lblPage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.lblPage.Height = 0.156F;
            this.lblPage.HyperLink = null;
            this.lblPage.Left = 9.938F;
            this.lblPage.Name = "lblPage";
            this.lblPage.Style = "color: Black; ddo-char-set: 1; font-size: 8pt; font-family: �l�r ����; vertical-align" +
                ": top; ";
            this.lblPage.Text = "�y�[�W�F";
            this.lblPage.Top = 0.063F;
            this.lblPage.Width = 0.5F;
            // 
            // txtPageNo
            // 
            this.txtPageNo.Border.BottomColor = System.Drawing.Color.Black;
            this.txtPageNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPageNo.Border.LeftColor = System.Drawing.Color.Black;
            this.txtPageNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPageNo.Border.RightColor = System.Drawing.Color.Black;
            this.txtPageNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPageNo.Border.TopColor = System.Drawing.Color.Black;
            this.txtPageNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.txtPageNo.Height = 0.156F;
            this.txtPageNo.Left = 10.438F;
            this.txtPageNo.Name = "txtPageNo";
            this.txtPageNo.Style = "color: Black; ddo-char-set: 1; text-align: right; font-size: 8pt; font-family: �l�r" +
                " ����; vertical-align: top; ";
            this.txtPageNo.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All;
            this.txtPageNo.SummaryType = DataDynamics.ActiveReports.SummaryType.PageCount;
            this.txtPageNo.Text = null;
            this.txtPageNo.Top = 0.0625F;
            this.txtPageNo.Width = 0.281F;
            // 
            // label9
            // 
            this.label9.Border.BottomColor = System.Drawing.Color.Black;
            this.label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Border.LeftColor = System.Drawing.Color.Black;
            this.label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Border.RightColor = System.Drawing.Color.Black;
            this.label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Border.TopColor = System.Drawing.Color.Black;
            this.label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label9.Height = 0.156F;
            this.label9.HyperLink = null;
            this.label9.Left = 7.9375F;
            this.label9.Name = "label9";
            this.label9.Style = "ddo-char-set: 1; font-size: 8pt; font-family: �l�r ����; ";
            this.label9.Text = "�쐬���t�F";
            this.label9.Top = 0.063F;
            this.label9.Width = 0.625F;
            // 
            // line53
            // 
            this.line53.Border.BottomColor = System.Drawing.Color.Black;
            this.line53.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line53.Border.LeftColor = System.Drawing.Color.Black;
            this.line53.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line53.Border.RightColor = System.Drawing.Color.Black;
            this.line53.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line53.Border.TopColor = System.Drawing.Color.Black;
            this.line53.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line53.Height = 0F;
            this.line53.Left = 0F;
            this.line53.LineWeight = 3F;
            this.line53.Name = "line53";
            this.line53.Top = 0.219F;
            this.line53.Width = 10.88F;
            this.line53.X1 = 0F;
            this.line53.X2 = 10.88F;
            this.line53.Y1 = 0.219F;
            this.line53.Y2 = 0.219F;
            // 
            // SORTTITLE
            // 
            this.SORTTITLE.Border.BottomColor = System.Drawing.Color.Black;
            this.SORTTITLE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SORTTITLE.Border.LeftColor = System.Drawing.Color.Black;
            this.SORTTITLE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SORTTITLE.Border.RightColor = System.Drawing.Color.Black;
            this.SORTTITLE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SORTTITLE.Border.TopColor = System.Drawing.Color.Black;
            this.SORTTITLE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.SORTTITLE.Height = 0.1875F;
            this.SORTTITLE.Left = 3.125F;
            this.SORTTITLE.Name = "SORTTITLE";
            this.SORTTITLE.Style = "color: Black; ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: �l�r " +
                "����; vertical-align: top; ";
            this.SORTTITLE.Text = null;
            this.SORTTITLE.Top = 0.063F;
            this.SORTTITLE.Width = 2.6875F;
            // 
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0.25F;
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
            this.Footer_SubReport.Height = 0.1875F;
            this.Footer_SubReport.Left = 0F;
            this.Footer_SubReport.Name = "Footer_SubReport";
            this.Footer_SubReport.Report = null;
            this.Footer_SubReport.Top = 0F;
            this.Footer_SubReport.Width = 10.8125F;
            // 
            // ExtraHeader
            // 
            this.ExtraHeader.CanShrink = true;
            this.ExtraHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Extraction,
            this.Extraction2,
            this.label2,
            this.line1});
            this.ExtraHeader.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All;
            this.ExtraHeader.Height = 0.4583333F;
            this.ExtraHeader.Name = "ExtraHeader";
            this.ExtraHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // Extraction
            // 
            this.Extraction.Border.BottomColor = System.Drawing.Color.Black;
            this.Extraction.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Extraction.Border.LeftColor = System.Drawing.Color.Black;
            this.Extraction.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Extraction.Border.RightColor = System.Drawing.Color.Black;
            this.Extraction.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Extraction.Border.TopColor = System.Drawing.Color.Black;
            this.Extraction.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Extraction.Height = 0.125F;
            this.Extraction.Left = 0F;
            this.Extraction.Name = "Extraction";
            this.Extraction.Style = "color: Black; text-align: left; font-size: 8pt; font-family: �l�r ����; vertical-alig" +
                "n: top; ";
            this.Extraction.Text = null;
            this.Extraction.Top = 0F;
            this.Extraction.Width = 10.75F;
            // 
            // Extraction2
            // 
            this.Extraction2.Border.BottomColor = System.Drawing.Color.Black;
            this.Extraction2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Extraction2.Border.LeftColor = System.Drawing.Color.Black;
            this.Extraction2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Extraction2.Border.RightColor = System.Drawing.Color.Black;
            this.Extraction2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Extraction2.Border.TopColor = System.Drawing.Color.Black;
            this.Extraction2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Extraction2.Height = 0.125F;
            this.Extraction2.Left = 1.4375F;
            this.Extraction2.Name = "Extraction2";
            this.Extraction2.Style = "color: Black; text-align: left; font-size: 8pt; font-family: �l�r ����; vertical-alig" +
                "n: top; ";
            this.Extraction2.Text = null;
            this.Extraction2.Top = 0.1875F;
            this.Extraction2.Width = 9.3125F;
            // 
            // label2
            // 
            this.label2.Border.BottomColor = System.Drawing.Color.Black;
            this.label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Border.LeftColor = System.Drawing.Color.Black;
            this.label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Border.RightColor = System.Drawing.Color.Black;
            this.label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Border.TopColor = System.Drawing.Color.Black;
            this.label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label2.Height = 0.125F;
            this.label2.HyperLink = null;
            this.label2.Left = 0F;
            this.label2.Name = "label2";
            this.label2.Style = "color: Black; ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: �l�r " +
                "����; vertical-align: top; ";
            this.label2.Text = "�e���`�F�b�N���X�g�͈�";
            this.label2.Top = 0.1875F;
            this.label2.Width = 1.375F;
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
            this.line1.Left = 0F;
            this.line1.LineWeight = 2F;
            this.line1.Name = "line1";
            this.line1.Top = 0.16F;
            this.line1.Width = 10.875F;
            this.line1.X1 = 0F;
            this.line1.X2 = 10.875F;
            this.line1.Y1 = 0.16F;
            this.line1.Y2 = 0.16F;
            // 
            // textBox28
            // 
            this.textBox28.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox28.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox28.Border.RightColor = System.Drawing.Color.Black;
            this.textBox28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox28.Border.TopColor = System.Drawing.Color.Black;
            this.textBox28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox28.DataField = "SectionGuideNm";
            this.textBox28.Height = 0.156F;
            this.textBox28.Left = 0.5F;
            this.textBox28.MultiLine = false;
            this.textBox28.Name = "textBox28";
            this.textBox28.Style = "ddo-char-set: 1; font-size: 8pt; font-family: �l�r ����; vertical-align: top; ";
            this.textBox28.Text = "��������������������";
            this.textBox28.Top = 0.0625F;
            this.textBox28.Width = 1.1875F;
            // 
            // textBox29
            // 
            this.textBox29.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox29.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox29.Border.RightColor = System.Drawing.Color.Black;
            this.textBox29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox29.Border.TopColor = System.Drawing.Color.Black;
            this.textBox29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox29.Height = 0.156F;
            this.textBox29.Left = 2F;
            this.textBox29.MultiLine = false;
            this.textBox29.Name = "textBox29";
            this.textBox29.Style = "color: Black; ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: �l�r " +
                "����; vertical-align: top; ";
            this.textBox29.Text = null;
            this.textBox29.Top = 0.0625F;
            this.textBox29.Width = 0.375F;
            // 
            // textBox30
            // 
            this.textBox30.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox30.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox30.Border.RightColor = System.Drawing.Color.Black;
            this.textBox30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox30.Border.TopColor = System.Drawing.Color.Black;
            this.textBox30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox30.Height = 0.156F;
            this.textBox30.Left = 2.375F;
            this.textBox30.MultiLine = false;
            this.textBox30.Name = "textBox30";
            this.textBox30.Style = "ddo-char-set: 1; font-size: 8pt; font-family: �l�r ����; vertical-align: top; ";
            this.textBox30.Text = null;
            this.textBox30.Top = 0.0625F;
            this.textBox30.Width = 2.25F;
            // 
            // textBox27
            // 
            this.textBox27.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox27.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox27.Border.RightColor = System.Drawing.Color.Black;
            this.textBox27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox27.Border.TopColor = System.Drawing.Color.Black;
            this.textBox27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox27.DataField = "SectionCode";
            this.textBox27.Height = 0.156F;
            this.textBox27.Left = 0.3125F;
            this.textBox27.MultiLine = false;
            this.textBox27.Name = "textBox27";
            this.textBox27.Style = "color: Black; ddo-char-set: 1; text-align: left; font-size: 8pt; font-family: �l�r " +
                "�S�V�b�N; vertical-align: top; ";
            this.textBox27.Text = "00";
            this.textBox27.Top = 0.0625F;
            this.textBox27.Width = 0.1875F;
            // 
            // label6
            // 
            this.label6.Border.BottomColor = System.Drawing.Color.Black;
            this.label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.LeftColor = System.Drawing.Color.Black;
            this.label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.RightColor = System.Drawing.Color.Black;
            this.label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Border.TopColor = System.Drawing.Color.Black;
            this.label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label6.Height = 0.156F;
            this.label6.HyperLink = null;
            this.label6.Left = 0F;
            this.label6.MultiLine = false;
            this.label6.Name = "label6";
            this.label6.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; font-family: �l�r ����; vertical-align: top; ";
            this.label6.Text = "���_";
            this.label6.Top = 0.0625F;
            this.label6.Width = 0.3125F;
            // 
            // ExtraFooter
            // 
            this.ExtraFooter.CanShrink = true;
            this.ExtraFooter.Height = 0F;
            this.ExtraFooter.KeepTogether = true;
            this.ExtraFooter.Name = "ExtraFooter";
            this.ExtraFooter.Format += new System.EventHandler(this.ExtraFooter_Format);
            // 
            // reportHeader1
            // 
            this.reportHeader1.Height = 0F;
            this.reportHeader1.Name = "reportHeader1";
            this.reportHeader1.Visible = false;
            // 
            // reportFooter1
            // 
            this.reportFooter1.Height = 0.08333334F;
            this.reportFooter1.KeepTogether = true;
            this.reportFooter1.Name = "reportFooter1";
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.label3,
            this.label10,
            this.label11,
            this.label14,
            this.Label23,
            this.label19,
            this.label20,
            this.label26,
            this.Label_GrossMarginRate,
            this.Label_Cost,
            this.label17,
            this.label30,
            this.Label_GrossMargin,
            this.line46,
            this.label7});
            this.TitleHeader.Height = 0.2916667F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            this.TitleHeader.Format += new System.EventHandler(this.TitleHeader_Format);
            // 
            // label3
            // 
            this.label3.Border.BottomColor = System.Drawing.Color.Black;
            this.label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Border.LeftColor = System.Drawing.Color.Black;
            this.label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Border.RightColor = System.Drawing.Color.Black;
            this.label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Border.TopColor = System.Drawing.Color.Black;
            this.label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label3.Height = 0.156F;
            this.label3.HyperLink = "";
            this.label3.Left = 0F;
            this.label3.Name = "label3";
            this.label3.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label3.Text = "���Ӑ�";
            this.label3.Top = 0.0625F;
            this.label3.Width = 0.4375F;
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
            this.label10.Height = 0.156F;
            this.label10.HyperLink = "";
            this.label10.Left = 4.8125F;
            this.label10.Name = "label10";
            this.label10.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label10.Text = "�󒍎�";
            this.label10.Top = 0.0625F;
            this.label10.Width = 0.5F;
            // 
            // label11
            // 
            this.label11.Border.BottomColor = System.Drawing.Color.Black;
            this.label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label11.Border.LeftColor = System.Drawing.Color.Black;
            this.label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label11.Border.RightColor = System.Drawing.Color.Black;
            this.label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label11.Border.TopColor = System.Drawing.Color.Black;
            this.label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label11.Height = 0.156F;
            this.label11.HyperLink = "";
            this.label11.Left = 4F;
            this.label11.Name = "label11";
            this.label11.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label11.Text = "�S����";
            this.label11.Top = 0.0625F;
            this.label11.Width = 0.4375F;
            // 
            // label14
            // 
            this.label14.Border.BottomColor = System.Drawing.Color.Black;
            this.label14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label14.Border.LeftColor = System.Drawing.Color.Black;
            this.label14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label14.Border.RightColor = System.Drawing.Color.Black;
            this.label14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label14.Border.TopColor = System.Drawing.Color.Black;
            this.label14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label14.Height = 0.156F;
            this.label14.HyperLink = "";
            this.label14.Left = 3.625F;
            this.label14.Name = "label14";
            this.label14.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; vertical-align: top; ";
            this.label14.Text = "�敪";
            this.label14.Top = 0.0625F;
            this.label14.Width = 0.375F;
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
            this.Label23.Height = 0.156F;
            this.Label23.HyperLink = "";
            this.Label23.Left = 2.0625F;
            this.Label23.Name = "Label23";
            this.Label23.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.Label23.Text = "�󒍓�";
            this.Label23.Top = 0.0625F;
            this.Label23.Width = 0.5F;
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
            this.label19.Height = 0.156F;
            this.label19.HyperLink = "";
            this.label19.Left = 2.5625F;
            this.label19.Name = "label19";
            this.label19.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label19.Text = "���͓�";
            this.label19.Top = 0.0625F;
            this.label19.Width = 0.5F;
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
            this.label20.Height = 0.156F;
            this.label20.HyperLink = "";
            this.label20.Left = 3.0625F;
            this.label20.Name = "label20";
            this.label20.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label20.Text = "�`�[�ԍ�";
            this.label20.Top = 0.0625F;
            this.label20.Width = 0.5625F;
            // 
            // label26
            // 
            this.label26.Border.BottomColor = System.Drawing.Color.Black;
            this.label26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label26.Border.LeftColor = System.Drawing.Color.Black;
            this.label26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label26.Border.RightColor = System.Drawing.Color.Black;
            this.label26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label26.Border.TopColor = System.Drawing.Color.Black;
            this.label26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label26.Height = 0.156F;
            this.label26.HyperLink = "";
            this.label26.Left = 5.625F;
            this.label26.Name = "label26";
            this.label26.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label26.Text = "���s��";
            this.label26.Top = 0.0625F;
            this.label26.Width = 0.5F;
            // 
            // Label_GrossMarginRate
            // 
            this.Label_GrossMarginRate.Border.BottomColor = System.Drawing.Color.Black;
            this.Label_GrossMarginRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_GrossMarginRate.Border.LeftColor = System.Drawing.Color.Black;
            this.Label_GrossMarginRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_GrossMarginRate.Border.RightColor = System.Drawing.Color.Black;
            this.Label_GrossMarginRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_GrossMarginRate.Border.TopColor = System.Drawing.Color.Black;
            this.Label_GrossMarginRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_GrossMarginRate.Height = 0.156F;
            this.Label_GrossMarginRate.HyperLink = "";
            this.Label_GrossMarginRate.Left = 9.9375F;
            this.Label_GrossMarginRate.Name = "Label_GrossMarginRate";
            this.Label_GrossMarginRate.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; white-space: nowrap; vertical-align: top; ";
            this.Label_GrossMarginRate.Text = "�e����";
            this.Label_GrossMarginRate.Top = 0.0625F;
            this.Label_GrossMarginRate.Width = 0.4375F;
            // 
            // Label_Cost
            // 
            this.Label_Cost.Border.BottomColor = System.Drawing.Color.Black;
            this.Label_Cost.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Cost.Border.LeftColor = System.Drawing.Color.Black;
            this.Label_Cost.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Cost.Border.RightColor = System.Drawing.Color.Black;
            this.Label_Cost.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Cost.Border.TopColor = System.Drawing.Color.Black;
            this.Label_Cost.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_Cost.Height = 0.156F;
            this.Label_Cost.HyperLink = "";
            this.Label_Cost.Left = 8.5625F;
            this.Label_Cost.Name = "Label_Cost";
            this.Label_Cost.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; white-space: nowrap; vertical-align: top; ";
            this.Label_Cost.Text = "����";
            this.Label_Cost.Top = 0.0625F;
            this.Label_Cost.Width = 0.6875F;
            // 
            // label17
            // 
            this.label17.Border.BottomColor = System.Drawing.Color.Black;
            this.label17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label17.Border.LeftColor = System.Drawing.Color.Black;
            this.label17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label17.Border.RightColor = System.Drawing.Color.Black;
            this.label17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label17.Border.TopColor = System.Drawing.Color.Black;
            this.label17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label17.Height = 0.156F;
            this.label17.HyperLink = "";
            this.label17.Left = 7.125F;
            this.label17.Name = "label17";
            this.label17.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; white-space: nowrap; vertical-align: top; ";
            this.label17.Text = "�����";
            this.label17.Top = 0.0625F;
            this.label17.Width = 0.625F;
            // 
            // label30
            // 
            this.label30.Border.BottomColor = System.Drawing.Color.Black;
            this.label30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label30.Border.LeftColor = System.Drawing.Color.Black;
            this.label30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label30.Border.RightColor = System.Drawing.Color.Black;
            this.label30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label30.Border.TopColor = System.Drawing.Color.Black;
            this.label30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label30.Height = 0.156F;
            this.label30.HyperLink = "";
            this.label30.Left = 6.4375F;
            this.label30.Name = "label30";
            this.label30.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; white-space: nowrap; vertical-align: top; ";
            this.label30.Text = "���z";
            this.label30.Top = 0.0625F;
            this.label30.Width = 0.6875F;
            // 
            // Label_GrossMargin
            // 
            this.Label_GrossMargin.Border.BottomColor = System.Drawing.Color.Black;
            this.Label_GrossMargin.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_GrossMargin.Border.LeftColor = System.Drawing.Color.Black;
            this.Label_GrossMargin.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_GrossMargin.Border.RightColor = System.Drawing.Color.Black;
            this.Label_GrossMargin.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_GrossMargin.Border.TopColor = System.Drawing.Color.Black;
            this.Label_GrossMargin.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label_GrossMargin.Height = 0.156F;
            this.Label_GrossMargin.HyperLink = "";
            this.Label_GrossMargin.Left = 9.25F;
            this.Label_GrossMargin.Name = "Label_GrossMargin";
            this.Label_GrossMargin.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; white-space: nowrap; vertical-align: top; ";
            this.Label_GrossMargin.Text = "�e��";
            this.Label_GrossMargin.Top = 0.0625F;
            this.Label_GrossMargin.Width = 0.6875F;
            // 
            // line46
            // 
            this.line46.Border.BottomColor = System.Drawing.Color.Black;
            this.line46.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line46.Border.LeftColor = System.Drawing.Color.Black;
            this.line46.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line46.Border.RightColor = System.Drawing.Color.Black;
            this.line46.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line46.Border.TopColor = System.Drawing.Color.Black;
            this.line46.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line46.Height = 0F;
            this.line46.Left = 0F;
            this.line46.LineWeight = 2F;
            this.line46.Name = "line46";
            this.line46.Top = 0F;
            this.line46.Width = 10.88F;
            this.line46.X1 = 0F;
            this.line46.X2 = 10.88F;
            this.line46.Y1 = 0F;
            this.line46.Y2 = 0F;
            // 
            // label7
            // 
            this.label7.Border.BottomColor = System.Drawing.Color.Black;
            this.label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Border.LeftColor = System.Drawing.Color.Black;
            this.label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Border.RightColor = System.Drawing.Color.Black;
            this.label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Border.TopColor = System.Drawing.Color.Black;
            this.label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label7.Height = 0.156F;
            this.label7.HyperLink = "";
            this.label7.Left = 7.75F;
            this.label7.Name = "label7";
            this.label7.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; white-space: nowrap; vertical-align: top; ";
            this.label7.Text = "���v���z";
            this.label7.Top = 0.0625F;
            this.label7.Width = 0.6875F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.Height = 0F;
            this.TitleFooter.Name = "TitleFooter";
            this.TitleFooter.Visible = false;
            this.TitleFooter.Format += new System.EventHandler(this.SectionFooter_Format);
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
            this.textBox3.Height = 0.1875F;
            this.textBox3.Left = 4.5F;
            this.textBox3.MultiLine = false;
            this.textBox3.Name = "textBox3";
            this.textBox3.OutputFormat = resources.GetString("textBox3.OutputFormat");
            this.textBox3.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10" +
                ".8pt; font-family: �l�r ����; white-space: nowrap; vertical-align: top; ";
            this.textBox3.Text = "���_�v";
            this.textBox3.Top = 0.0625F;
            this.textBox3.Width = 0.9375F;
            // 
            // TextBox4
            // 
            this.TextBox4.Border.BottomColor = System.Drawing.Color.Black;
            this.TextBox4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox4.Border.LeftColor = System.Drawing.Color.Black;
            this.TextBox4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox4.Border.RightColor = System.Drawing.Color.Black;
            this.TextBox4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox4.Border.TopColor = System.Drawing.Color.Black;
            this.TextBox4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TextBox4.DataField = "CntSales";
            this.TextBox4.Height = 0.125F;
            this.TextBox4.Left = 5.5F;
            this.TextBox4.MultiLine = false;
            this.TextBox4.Name = "TextBox4";
            this.TextBox4.OutputFormat = resources.GetString("TextBox4.OutputFormat");
            this.TextBox4.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.TextBox4.SummaryGroup = "SectionHeader";
            this.TextBox4.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.TextBox4.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.TextBox4.Text = "0";
            this.TextBox4.Top = 0.0625F;
            this.TextBox4.Width = 0.25F;
            // 
            // Label
            // 
            this.Label.Border.BottomColor = System.Drawing.Color.Black;
            this.Label.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.LeftColor = System.Drawing.Color.Black;
            this.Label.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.RightColor = System.Drawing.Color.Black;
            this.Label.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Border.TopColor = System.Drawing.Color.Black;
            this.Label.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label.Height = 0.125F;
            this.Label.HyperLink = "";
            this.Label.Left = 5.875F;
            this.Label.Name = "Label";
            this.Label.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.Label.Text = "��";
            this.Label.Top = 0.0625F;
            this.Label.Width = 0.1875F;
            // 
            // Section_SalesMoney
            // 
            this.Section_SalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_SalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_SalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.Section_SalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.Section_SalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesMoney.DataField = "SalesMoney";
            this.Section_SalesMoney.Height = 0.125F;
            this.Section_SalesMoney.Left = 6.3125F;
            this.Section_SalesMoney.MultiLine = false;
            this.Section_SalesMoney.Name = "Section_SalesMoney";
            this.Section_SalesMoney.OutputFormat = resources.GetString("Section_SalesMoney.OutputFormat");
            this.Section_SalesMoney.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.Section_SalesMoney.SummaryGroup = "SectionHeader";
            this.Section_SalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_SalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_SalesMoney.Text = "963258741258";
            this.Section_SalesMoney.Top = 0.0625F;
            this.Section_SalesMoney.Width = 0.813F;
            // 
            // Section_TotalCostSl
            // 
            this.Section_TotalCostSl.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_TotalCostSl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_TotalCostSl.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_TotalCostSl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_TotalCostSl.Border.RightColor = System.Drawing.Color.Black;
            this.Section_TotalCostSl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_TotalCostSl.Border.TopColor = System.Drawing.Color.Black;
            this.Section_TotalCostSl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_TotalCostSl.DataField = "TotalCostSl";
            this.Section_TotalCostSl.Height = 0.125F;
            this.Section_TotalCostSl.Left = 8.4375F;
            this.Section_TotalCostSl.MultiLine = false;
            this.Section_TotalCostSl.Name = "Section_TotalCostSl";
            this.Section_TotalCostSl.OutputFormat = resources.GetString("Section_TotalCostSl.OutputFormat");
            this.Section_TotalCostSl.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.Section_TotalCostSl.SummaryGroup = "SectionHeader";
            this.Section_TotalCostSl.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_TotalCostSl.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_TotalCostSl.Text = "-123456789012";
            this.Section_TotalCostSl.Top = 0.0625F;
            this.Section_TotalCostSl.Width = 0.813F;
            // 
            // Section_SalesGrossProfit
            // 
            this.Section_SalesGrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_SalesGrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesGrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_SalesGrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesGrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.Section_SalesGrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesGrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.Section_SalesGrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesGrossProfit.DataField = "SalesGrossProfit";
            this.Section_SalesGrossProfit.Height = 0.125F;
            this.Section_SalesGrossProfit.Left = 9.25F;
            this.Section_SalesGrossProfit.MultiLine = false;
            this.Section_SalesGrossProfit.Name = "Section_SalesGrossProfit";
            this.Section_SalesGrossProfit.OutputFormat = resources.GetString("Section_SalesGrossProfit.OutputFormat");
            this.Section_SalesGrossProfit.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.Section_SalesGrossProfit.SummaryGroup = "SectionHeader";
            this.Section_SalesGrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_SalesGrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_SalesGrossProfit.Text = "12345678945";
            this.Section_SalesGrossProfit.Top = 0.0625F;
            this.Section_SalesGrossProfit.Width = 0.688F;
            // 
            // Section_SalesGrossMarginRate
            // 
            this.Section_SalesGrossMarginRate.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_SalesGrossMarginRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesGrossMarginRate.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_SalesGrossMarginRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesGrossMarginRate.Border.RightColor = System.Drawing.Color.Black;
            this.Section_SalesGrossMarginRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesGrossMarginRate.Border.TopColor = System.Drawing.Color.Black;
            this.Section_SalesGrossMarginRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesGrossMarginRate.CanGrow = false;
            this.Section_SalesGrossMarginRate.Height = 0.125F;
            this.Section_SalesGrossMarginRate.Left = 9.9375F;
            this.Section_SalesGrossMarginRate.MultiLine = false;
            this.Section_SalesGrossMarginRate.Name = "Section_SalesGrossMarginRate";
            this.Section_SalesGrossMarginRate.OutputFormat = resources.GetString("Section_SalesGrossMarginRate.OutputFormat");
            this.Section_SalesGrossMarginRate.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.Section_SalesGrossMarginRate.Text = "-100.00";
            this.Section_SalesGrossMarginRate.Top = 0.0625F;
            this.Section_SalesGrossMarginRate.Width = 0.4375F;
            // 
            // Section_SalesPercentage
            // 
            this.Section_SalesPercentage.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_SalesPercentage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesPercentage.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_SalesPercentage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesPercentage.Border.RightColor = System.Drawing.Color.Black;
            this.Section_SalesPercentage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesPercentage.Border.TopColor = System.Drawing.Color.Black;
            this.Section_SalesPercentage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesPercentage.Height = 0.125F;
            this.Section_SalesPercentage.HyperLink = "";
            this.Section_SalesPercentage.Left = 10.375F;
            this.Section_SalesPercentage.Name = "Section_SalesPercentage";
            this.Section_SalesPercentage.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.Section_SalesPercentage.Text = "��";
            this.Section_SalesPercentage.Top = 0.0625F;
            this.Section_SalesPercentage.Width = 0.125F;
            // 
            // Section_SalesGrossMarginMark
            // 
            this.Section_SalesGrossMarginMark.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_SalesGrossMarginMark.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesGrossMarginMark.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_SalesGrossMarginMark.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesGrossMarginMark.Border.RightColor = System.Drawing.Color.Black;
            this.Section_SalesGrossMarginMark.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesGrossMarginMark.Border.TopColor = System.Drawing.Color.Black;
            this.Section_SalesGrossMarginMark.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesGrossMarginMark.CanGrow = false;
            this.Section_SalesGrossMarginMark.Height = 0.125F;
            this.Section_SalesGrossMarginMark.Left = 10.5F;
            this.Section_SalesGrossMarginMark.Name = "Section_SalesGrossMarginMark";
            this.Section_SalesGrossMarginMark.OutputFormat = resources.GetString("Section_SalesGrossMarginMark.OutputFormat");
            this.Section_SalesGrossMarginMark.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; font-family: �l�r ����; vertical-align: top; ";
            this.Section_SalesGrossMarginMark.Text = "��";
            this.Section_SalesGrossMarginMark.Top = 0.0625F;
            this.Section_SalesGrossMarginMark.Width = 0.1875F;
            // 
            // Header1
            // 
            this.Header1.CanShrink = true;
            this.Header1.Height = 0F;
            this.Header1.Name = "Header1";
            this.Header1.Visible = false;
            // 
            // Footer1
            // 
            this.Footer1.CanShrink = true;
            this.Footer1.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer1Field,
            this.textBox48,
            this.Footer1_SalesMoney,
            this.Footer1_TotalCostSl,
            this.label29,
            this.Footer1_SalesGrossProfit,
            this.Footer1_SalesGrossMarginRate,
            this.Footer1_SalesPercentage,
            this.Footer1_SalesGrossMarginMark,
            this.line4,
            this.Footer1_SalesTax,
            this.Footer1_SalesTotalAll});
            this.Footer1.Height = 0.3333333F;
            this.Footer1.KeepTogether = true;
            this.Footer1.Name = "Footer1";
            this.Footer1.BeforePrint += new System.EventHandler(this.Footer1_BeforePrint);
            // 
            // Footer1Field
            // 
            this.Footer1Field.Border.BottomColor = System.Drawing.Color.Black;
            this.Footer1Field.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1Field.Border.LeftColor = System.Drawing.Color.Black;
            this.Footer1Field.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1Field.Border.RightColor = System.Drawing.Color.Black;
            this.Footer1Field.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1Field.Border.TopColor = System.Drawing.Color.Black;
            this.Footer1Field.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1Field.Height = 0.1875F;
            this.Footer1Field.Left = 4.5F;
            this.Footer1Field.MultiLine = false;
            this.Footer1Field.Name = "Footer1Field";
            this.Footer1Field.OutputFormat = resources.GetString("Footer1Field.OutputFormat");
            this.Footer1Field.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10" +
                ".8pt; font-family: �l�r ����; white-space: nowrap; vertical-align: top; ";
            this.Footer1Field.Text = "�v";
            this.Footer1Field.Top = 0.0625F;
            this.Footer1Field.Width = 0.9375F;
            // 
            // textBox48
            // 
            this.textBox48.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox48.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox48.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox48.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox48.Border.RightColor = System.Drawing.Color.Black;
            this.textBox48.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox48.Border.TopColor = System.Drawing.Color.Black;
            this.textBox48.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox48.DataField = "CntSales";
            this.textBox48.Height = 0.125F;
            this.textBox48.Left = 5.5F;
            this.textBox48.MultiLine = false;
            this.textBox48.Name = "textBox48";
            this.textBox48.OutputFormat = resources.GetString("textBox48.OutputFormat");
            this.textBox48.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.textBox48.SummaryGroup = "Header1";
            this.textBox48.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox48.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox48.Text = "0";
            this.textBox48.Top = 0.0625F;
            this.textBox48.Width = 0.25F;
            // 
            // Footer1_SalesMoney
            // 
            this.Footer1_SalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.Footer1_SalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.Footer1_SalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.Footer1_SalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.Footer1_SalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesMoney.DataField = "SalesMoney";
            this.Footer1_SalesMoney.Height = 0.125F;
            this.Footer1_SalesMoney.Left = 6.3125F;
            this.Footer1_SalesMoney.MultiLine = false;
            this.Footer1_SalesMoney.Name = "Footer1_SalesMoney";
            this.Footer1_SalesMoney.OutputFormat = resources.GetString("Footer1_SalesMoney.OutputFormat");
            this.Footer1_SalesMoney.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.Footer1_SalesMoney.SummaryGroup = "Header1";
            this.Footer1_SalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Footer1_SalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Footer1_SalesMoney.Text = "963258741258";
            this.Footer1_SalesMoney.Top = 0.0625F;
            this.Footer1_SalesMoney.Width = 0.813F;
            // 
            // Footer1_TotalCostSl
            // 
            this.Footer1_TotalCostSl.Border.BottomColor = System.Drawing.Color.Black;
            this.Footer1_TotalCostSl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_TotalCostSl.Border.LeftColor = System.Drawing.Color.Black;
            this.Footer1_TotalCostSl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_TotalCostSl.Border.RightColor = System.Drawing.Color.Black;
            this.Footer1_TotalCostSl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_TotalCostSl.Border.TopColor = System.Drawing.Color.Black;
            this.Footer1_TotalCostSl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_TotalCostSl.DataField = "TotalCostSl";
            this.Footer1_TotalCostSl.Height = 0.125F;
            this.Footer1_TotalCostSl.Left = 8.4375F;
            this.Footer1_TotalCostSl.MultiLine = false;
            this.Footer1_TotalCostSl.Name = "Footer1_TotalCostSl";
            this.Footer1_TotalCostSl.OutputFormat = resources.GetString("Footer1_TotalCostSl.OutputFormat");
            this.Footer1_TotalCostSl.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.Footer1_TotalCostSl.SummaryGroup = "Header1";
            this.Footer1_TotalCostSl.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Footer1_TotalCostSl.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Footer1_TotalCostSl.Text = "-123456789012";
            this.Footer1_TotalCostSl.Top = 0.0625F;
            this.Footer1_TotalCostSl.Width = 0.813F;
            // 
            // label29
            // 
            this.label29.Border.BottomColor = System.Drawing.Color.Black;
            this.label29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label29.Border.LeftColor = System.Drawing.Color.Black;
            this.label29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label29.Border.RightColor = System.Drawing.Color.Black;
            this.label29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label29.Border.TopColor = System.Drawing.Color.Black;
            this.label29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label29.Height = 0.125F;
            this.label29.HyperLink = "";
            this.label29.Left = 5.875F;
            this.label29.Name = "label29";
            this.label29.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label29.Text = "��";
            this.label29.Top = 0.0625F;
            this.label29.Width = 0.1875F;
            // 
            // Footer1_SalesGrossProfit
            // 
            this.Footer1_SalesGrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.Footer1_SalesGrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesGrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.Footer1_SalesGrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesGrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.Footer1_SalesGrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesGrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.Footer1_SalesGrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesGrossProfit.DataField = "SalesGrossProfit";
            this.Footer1_SalesGrossProfit.Height = 0.125F;
            this.Footer1_SalesGrossProfit.Left = 9.25F;
            this.Footer1_SalesGrossProfit.MultiLine = false;
            this.Footer1_SalesGrossProfit.Name = "Footer1_SalesGrossProfit";
            this.Footer1_SalesGrossProfit.OutputFormat = resources.GetString("Footer1_SalesGrossProfit.OutputFormat");
            this.Footer1_SalesGrossProfit.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.Footer1_SalesGrossProfit.SummaryGroup = "Header1";
            this.Footer1_SalesGrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Footer1_SalesGrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Footer1_SalesGrossProfit.Text = "12345678945";
            this.Footer1_SalesGrossProfit.Top = 0.0625F;
            this.Footer1_SalesGrossProfit.Width = 0.688F;
            // 
            // Footer1_SalesGrossMarginRate
            // 
            this.Footer1_SalesGrossMarginRate.Border.BottomColor = System.Drawing.Color.Black;
            this.Footer1_SalesGrossMarginRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesGrossMarginRate.Border.LeftColor = System.Drawing.Color.Black;
            this.Footer1_SalesGrossMarginRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesGrossMarginRate.Border.RightColor = System.Drawing.Color.Black;
            this.Footer1_SalesGrossMarginRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesGrossMarginRate.Border.TopColor = System.Drawing.Color.Black;
            this.Footer1_SalesGrossMarginRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesGrossMarginRate.CanGrow = false;
            this.Footer1_SalesGrossMarginRate.Height = 0.125F;
            this.Footer1_SalesGrossMarginRate.Left = 9.9375F;
            this.Footer1_SalesGrossMarginRate.MultiLine = false;
            this.Footer1_SalesGrossMarginRate.Name = "Footer1_SalesGrossMarginRate";
            this.Footer1_SalesGrossMarginRate.OutputFormat = resources.GetString("Footer1_SalesGrossMarginRate.OutputFormat");
            this.Footer1_SalesGrossMarginRate.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.Footer1_SalesGrossMarginRate.Text = "-100.00";
            this.Footer1_SalesGrossMarginRate.Top = 0.0625F;
            this.Footer1_SalesGrossMarginRate.Width = 0.4375F;
            // 
            // Footer1_SalesPercentage
            // 
            this.Footer1_SalesPercentage.Border.BottomColor = System.Drawing.Color.Black;
            this.Footer1_SalesPercentage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesPercentage.Border.LeftColor = System.Drawing.Color.Black;
            this.Footer1_SalesPercentage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesPercentage.Border.RightColor = System.Drawing.Color.Black;
            this.Footer1_SalesPercentage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesPercentage.Border.TopColor = System.Drawing.Color.Black;
            this.Footer1_SalesPercentage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesPercentage.Height = 0.125F;
            this.Footer1_SalesPercentage.HyperLink = "";
            this.Footer1_SalesPercentage.Left = 10.375F;
            this.Footer1_SalesPercentage.Name = "Footer1_SalesPercentage";
            this.Footer1_SalesPercentage.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.Footer1_SalesPercentage.Text = "��";
            this.Footer1_SalesPercentage.Top = 0.0625F;
            this.Footer1_SalesPercentage.Width = 0.125F;
            // 
            // Footer1_SalesGrossMarginMark
            // 
            this.Footer1_SalesGrossMarginMark.Border.BottomColor = System.Drawing.Color.Black;
            this.Footer1_SalesGrossMarginMark.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesGrossMarginMark.Border.LeftColor = System.Drawing.Color.Black;
            this.Footer1_SalesGrossMarginMark.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesGrossMarginMark.Border.RightColor = System.Drawing.Color.Black;
            this.Footer1_SalesGrossMarginMark.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesGrossMarginMark.Border.TopColor = System.Drawing.Color.Black;
            this.Footer1_SalesGrossMarginMark.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesGrossMarginMark.CanGrow = false;
            this.Footer1_SalesGrossMarginMark.Height = 0.125F;
            this.Footer1_SalesGrossMarginMark.Left = 10.5F;
            this.Footer1_SalesGrossMarginMark.Name = "Footer1_SalesGrossMarginMark";
            this.Footer1_SalesGrossMarginMark.OutputFormat = resources.GetString("Footer1_SalesGrossMarginMark.OutputFormat");
            this.Footer1_SalesGrossMarginMark.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; font-family: �l�r ����; vertical-align: top; ";
            this.Footer1_SalesGrossMarginMark.Text = "��";
            this.Footer1_SalesGrossMarginMark.Top = 0.0625F;
            this.Footer1_SalesGrossMarginMark.Width = 0.1875F;
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
            this.line4.Width = 10.88F;
            this.line4.X1 = 0F;
            this.line4.X2 = 10.88F;
            this.line4.Y1 = 0F;
            this.line4.Y2 = 0F;
            // 
            // Footer1_SalesTax
            // 
            this.Footer1_SalesTax.Border.BottomColor = System.Drawing.Color.Black;
            this.Footer1_SalesTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesTax.Border.LeftColor = System.Drawing.Color.Black;
            this.Footer1_SalesTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesTax.Border.RightColor = System.Drawing.Color.Black;
            this.Footer1_SalesTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesTax.Border.TopColor = System.Drawing.Color.Black;
            this.Footer1_SalesTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesTax.DataField = "SalesTax";
            this.Footer1_SalesTax.Height = 0.125F;
            this.Footer1_SalesTax.Left = 7.125F;
            this.Footer1_SalesTax.MultiLine = false;
            this.Footer1_SalesTax.Name = "Footer1_SalesTax";
            this.Footer1_SalesTax.OutputFormat = resources.GetString("Footer1_SalesTax.OutputFormat");
            this.Footer1_SalesTax.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.Footer1_SalesTax.SummaryGroup = "Header1";
            this.Footer1_SalesTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Footer1_SalesTax.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Footer1_SalesTax.Text = "1236547894";
            this.Footer1_SalesTax.Top = 0.0625F;
            this.Footer1_SalesTax.Visible = false;
            this.Footer1_SalesTax.Width = 0.625F;
            // 
            // Footer1_SalesTotalAll
            // 
            this.Footer1_SalesTotalAll.Border.BottomColor = System.Drawing.Color.Black;
            this.Footer1_SalesTotalAll.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesTotalAll.Border.LeftColor = System.Drawing.Color.Black;
            this.Footer1_SalesTotalAll.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesTotalAll.Border.RightColor = System.Drawing.Color.Black;
            this.Footer1_SalesTotalAll.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesTotalAll.Border.TopColor = System.Drawing.Color.Black;
            this.Footer1_SalesTotalAll.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Footer1_SalesTotalAll.DataField = "SalesTotalAll";
            this.Footer1_SalesTotalAll.Height = 0.125F;
            this.Footer1_SalesTotalAll.Left = 7.75F;
            this.Footer1_SalesTotalAll.MultiLine = false;
            this.Footer1_SalesTotalAll.Name = "Footer1_SalesTotalAll";
            this.Footer1_SalesTotalAll.OutputFormat = resources.GetString("Footer1_SalesTotalAll.OutputFormat");
            this.Footer1_SalesTotalAll.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.Footer1_SalesTotalAll.SummaryGroup = "Header1";
            this.Footer1_SalesTotalAll.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Footer1_SalesTotalAll.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Footer1_SalesTotalAll.Text = "123,456,789";
            this.Footer1_SalesTotalAll.Top = 0.0625F;
            this.Footer1_SalesTotalAll.Width = 0.6875F;
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.line43,
            this.label6,
            this.textBox27,
            this.textBox28,
            this.textBox29,
            this.textBox30});
            this.SectionHeader.DataField = "SectionCode";
            this.SectionHeader.Height = 0.2604167F;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.SectionHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // line43
            // 
            this.line43.Border.BottomColor = System.Drawing.Color.Black;
            this.line43.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line43.Border.LeftColor = System.Drawing.Color.Black;
            this.line43.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line43.Border.RightColor = System.Drawing.Color.Black;
            this.line43.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line43.Border.TopColor = System.Drawing.Color.Black;
            this.line43.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.line43.Height = 0F;
            this.line43.Left = 0F;
            this.line43.LineWeight = 2F;
            this.line43.Name = "line43";
            this.line43.Top = 0F;
            this.line43.Width = 10.88F;
            this.line43.X1 = 0F;
            this.line43.X2 = 10.88F;
            this.line43.Y1 = 0F;
            this.line43.Y2 = 0F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox3,
            this.TextBox4,
            this.Label,
            this.Section_SalesMoney,
            this.Section_TotalCostSl,
            this.Section_SalesGrossProfit,
            this.Section_SalesGrossMarginRate,
            this.Section_SalesPercentage,
            this.Section_SalesGrossMarginMark,
            this.line8,
            this.Section_SalesTax,
            this.Section_SalesTotalAll});
            this.SectionFooter.Height = 0.3333333F;
            this.SectionFooter.KeepTogether = true;
            this.SectionFooter.Name = "SectionFooter";
            this.SectionFooter.BeforePrint += new System.EventHandler(this.SectionFooter_BeforePrint);
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
            this.line8.Width = 10.88F;
            this.line8.X1 = 0F;
            this.line8.X2 = 10.88F;
            this.line8.Y1 = 0F;
            this.line8.Y2 = 0F;
            // 
            // Section_SalesTax
            // 
            this.Section_SalesTax.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_SalesTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesTax.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_SalesTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesTax.Border.RightColor = System.Drawing.Color.Black;
            this.Section_SalesTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesTax.Border.TopColor = System.Drawing.Color.Black;
            this.Section_SalesTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesTax.DataField = "SalesTax";
            this.Section_SalesTax.Height = 0.125F;
            this.Section_SalesTax.Left = 7.125F;
            this.Section_SalesTax.MultiLine = false;
            this.Section_SalesTax.Name = "Section_SalesTax";
            this.Section_SalesTax.OutputFormat = resources.GetString("Section_SalesTax.OutputFormat");
            this.Section_SalesTax.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.Section_SalesTax.SummaryGroup = "SectionHeader";
            this.Section_SalesTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_SalesTax.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_SalesTax.Text = "1236547894";
            this.Section_SalesTax.Top = 0.0625F;
            this.Section_SalesTax.Visible = false;
            this.Section_SalesTax.Width = 0.625F;
            // 
            // Section_SalesTotalAll
            // 
            this.Section_SalesTotalAll.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_SalesTotalAll.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesTotalAll.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_SalesTotalAll.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesTotalAll.Border.RightColor = System.Drawing.Color.Black;
            this.Section_SalesTotalAll.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesTotalAll.Border.TopColor = System.Drawing.Color.Black;
            this.Section_SalesTotalAll.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_SalesTotalAll.DataField = "SalesTotalAll";
            this.Section_SalesTotalAll.Height = 0.125F;
            this.Section_SalesTotalAll.Left = 7.75F;
            this.Section_SalesTotalAll.MultiLine = false;
            this.Section_SalesTotalAll.Name = "Section_SalesTotalAll";
            this.Section_SalesTotalAll.OutputFormat = resources.GetString("Section_SalesTotalAll.OutputFormat");
            this.Section_SalesTotalAll.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.Section_SalesTotalAll.SummaryGroup = "SectionHeader";
            this.Section_SalesTotalAll.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_SalesTotalAll.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_SalesTotalAll.Text = "123,456,789";
            this.Section_SalesTotalAll.Top = 0.0625F;
            this.Section_SalesTotalAll.Width = 0.6875F;
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
            this.textBox2,
            this.textBox16,
            this.label13,
            this.Grand_SalesMoney,
            this.Grand_TotalCostSl,
            this.Grand_SalesGrossProfit,
            this.Grand_SalesGrossMarginRate,
            this.Grand_SalesPercentage,
            this.Grand_SalesGrossMarginMark,
            this.line9,
            this.Grand_SalesTax,
            this.Grand_SalesTotalAll});
            this.GrandTotalFooter.Height = 0.3125F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
            this.GrandTotalFooter.BeforePrint += new System.EventHandler(this.GrandTotalFooter_BeforePrint);
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
            this.textBox2.Left = 4.5F;
            this.textBox2.MultiLine = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.OutputFormat = resources.GetString("textBox2.OutputFormat");
            this.textBox2.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10" +
                ".8pt; font-family: �l�r ����; white-space: nowrap; vertical-align: top; ";
            this.textBox2.Text = "�����v";
            this.textBox2.Top = 0.0625F;
            this.textBox2.Width = 0.9375F;
            // 
            // textBox16
            // 
            this.textBox16.Border.BottomColor = System.Drawing.Color.Black;
            this.textBox16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox16.Border.LeftColor = System.Drawing.Color.Black;
            this.textBox16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox16.Border.RightColor = System.Drawing.Color.Black;
            this.textBox16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox16.Border.TopColor = System.Drawing.Color.Black;
            this.textBox16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.textBox16.DataField = "CntSales";
            this.textBox16.Height = 0.125F;
            this.textBox16.Left = 5.5F;
            this.textBox16.MultiLine = false;
            this.textBox16.Name = "textBox16";
            this.textBox16.OutputFormat = resources.GetString("textBox16.OutputFormat");
            this.textBox16.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.textBox16.SummaryGroup = "GrandTotalHeader";
            this.textBox16.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox16.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox16.Text = "0";
            this.textBox16.Top = 0.0625F;
            this.textBox16.Width = 0.25F;
            // 
            // label13
            // 
            this.label13.Border.BottomColor = System.Drawing.Color.Black;
            this.label13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Border.LeftColor = System.Drawing.Color.Black;
            this.label13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Border.RightColor = System.Drawing.Color.Black;
            this.label13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Border.TopColor = System.Drawing.Color.Black;
            this.label13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label13.Height = 0.125F;
            this.label13.HyperLink = "";
            this.label13.Left = 5.875F;
            this.label13.Name = "label13";
            this.label13.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label13.Text = "��";
            this.label13.Top = 0.0625F;
            this.label13.Width = 0.1875F;
            // 
            // Grand_SalesMoney
            // 
            this.Grand_SalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.Grand_SalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.Grand_SalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.Grand_SalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.Grand_SalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesMoney.DataField = "SalesMoney";
            this.Grand_SalesMoney.Height = 0.125F;
            this.Grand_SalesMoney.Left = 6.3125F;
            this.Grand_SalesMoney.MultiLine = false;
            this.Grand_SalesMoney.Name = "Grand_SalesMoney";
            this.Grand_SalesMoney.OutputFormat = resources.GetString("Grand_SalesMoney.OutputFormat");
            this.Grand_SalesMoney.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.Grand_SalesMoney.SummaryGroup = "GrandTotalHeader";
            this.Grand_SalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Grand_SalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Grand_SalesMoney.Text = "963258741258";
            this.Grand_SalesMoney.Top = 0.0625F;
            this.Grand_SalesMoney.Width = 0.813F;
            // 
            // Grand_TotalCostSl
            // 
            this.Grand_TotalCostSl.Border.BottomColor = System.Drawing.Color.Black;
            this.Grand_TotalCostSl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_TotalCostSl.Border.LeftColor = System.Drawing.Color.Black;
            this.Grand_TotalCostSl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_TotalCostSl.Border.RightColor = System.Drawing.Color.Black;
            this.Grand_TotalCostSl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_TotalCostSl.Border.TopColor = System.Drawing.Color.Black;
            this.Grand_TotalCostSl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_TotalCostSl.DataField = "TotalCostSl";
            this.Grand_TotalCostSl.Height = 0.125F;
            this.Grand_TotalCostSl.Left = 8.4375F;
            this.Grand_TotalCostSl.MultiLine = false;
            this.Grand_TotalCostSl.Name = "Grand_TotalCostSl";
            this.Grand_TotalCostSl.OutputFormat = resources.GetString("Grand_TotalCostSl.OutputFormat");
            this.Grand_TotalCostSl.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.Grand_TotalCostSl.SummaryGroup = "GrandTotalHeader";
            this.Grand_TotalCostSl.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Grand_TotalCostSl.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Grand_TotalCostSl.Text = "-123456789012";
            this.Grand_TotalCostSl.Top = 0.0625F;
            this.Grand_TotalCostSl.Width = 0.813F;
            // 
            // Grand_SalesGrossProfit
            // 
            this.Grand_SalesGrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.Grand_SalesGrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesGrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.Grand_SalesGrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesGrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.Grand_SalesGrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesGrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.Grand_SalesGrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesGrossProfit.DataField = "SalesGrossProfit";
            this.Grand_SalesGrossProfit.Height = 0.125F;
            this.Grand_SalesGrossProfit.Left = 9.25F;
            this.Grand_SalesGrossProfit.MultiLine = false;
            this.Grand_SalesGrossProfit.Name = "Grand_SalesGrossProfit";
            this.Grand_SalesGrossProfit.OutputFormat = resources.GetString("Grand_SalesGrossProfit.OutputFormat");
            this.Grand_SalesGrossProfit.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.Grand_SalesGrossProfit.SummaryGroup = "GrandTotalHeader";
            this.Grand_SalesGrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Grand_SalesGrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Grand_SalesGrossProfit.Text = "12345678945";
            this.Grand_SalesGrossProfit.Top = 0.0625F;
            this.Grand_SalesGrossProfit.Width = 0.688F;
            // 
            // Grand_SalesGrossMarginRate
            // 
            this.Grand_SalesGrossMarginRate.Border.BottomColor = System.Drawing.Color.Black;
            this.Grand_SalesGrossMarginRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesGrossMarginRate.Border.LeftColor = System.Drawing.Color.Black;
            this.Grand_SalesGrossMarginRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesGrossMarginRate.Border.RightColor = System.Drawing.Color.Black;
            this.Grand_SalesGrossMarginRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesGrossMarginRate.Border.TopColor = System.Drawing.Color.Black;
            this.Grand_SalesGrossMarginRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesGrossMarginRate.CanGrow = false;
            this.Grand_SalesGrossMarginRate.Height = 0.125F;
            this.Grand_SalesGrossMarginRate.Left = 9.9375F;
            this.Grand_SalesGrossMarginRate.MultiLine = false;
            this.Grand_SalesGrossMarginRate.Name = "Grand_SalesGrossMarginRate";
            this.Grand_SalesGrossMarginRate.OutputFormat = resources.GetString("Grand_SalesGrossMarginRate.OutputFormat");
            this.Grand_SalesGrossMarginRate.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.Grand_SalesGrossMarginRate.Text = "-100.00";
            this.Grand_SalesGrossMarginRate.Top = 0.0625F;
            this.Grand_SalesGrossMarginRate.Width = 0.4375F;
            // 
            // Grand_SalesPercentage
            // 
            this.Grand_SalesPercentage.Border.BottomColor = System.Drawing.Color.Black;
            this.Grand_SalesPercentage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesPercentage.Border.LeftColor = System.Drawing.Color.Black;
            this.Grand_SalesPercentage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesPercentage.Border.RightColor = System.Drawing.Color.Black;
            this.Grand_SalesPercentage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesPercentage.Border.TopColor = System.Drawing.Color.Black;
            this.Grand_SalesPercentage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesPercentage.Height = 0.125F;
            this.Grand_SalesPercentage.HyperLink = "";
            this.Grand_SalesPercentage.Left = 10.375F;
            this.Grand_SalesPercentage.Name = "Grand_SalesPercentage";
            this.Grand_SalesPercentage.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.Grand_SalesPercentage.Text = "��";
            this.Grand_SalesPercentage.Top = 0.0625F;
            this.Grand_SalesPercentage.Width = 0.125F;
            // 
            // Grand_SalesGrossMarginMark
            // 
            this.Grand_SalesGrossMarginMark.Border.BottomColor = System.Drawing.Color.Black;
            this.Grand_SalesGrossMarginMark.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesGrossMarginMark.Border.LeftColor = System.Drawing.Color.Black;
            this.Grand_SalesGrossMarginMark.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesGrossMarginMark.Border.RightColor = System.Drawing.Color.Black;
            this.Grand_SalesGrossMarginMark.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesGrossMarginMark.Border.TopColor = System.Drawing.Color.Black;
            this.Grand_SalesGrossMarginMark.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesGrossMarginMark.CanGrow = false;
            this.Grand_SalesGrossMarginMark.Height = 0.125F;
            this.Grand_SalesGrossMarginMark.Left = 10.5F;
            this.Grand_SalesGrossMarginMark.Name = "Grand_SalesGrossMarginMark";
            this.Grand_SalesGrossMarginMark.OutputFormat = resources.GetString("Grand_SalesGrossMarginMark.OutputFormat");
            this.Grand_SalesGrossMarginMark.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; font-family: �l�r ����; vertical-align: top; ";
            this.Grand_SalesGrossMarginMark.Text = "��";
            this.Grand_SalesGrossMarginMark.Top = 0.0625F;
            this.Grand_SalesGrossMarginMark.Width = 0.1875F;
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
            this.line9.Height = 0F;
            this.line9.Left = 0F;
            this.line9.LineWeight = 2F;
            this.line9.Name = "line9";
            this.line9.Top = 0F;
            this.line9.Width = 10.88F;
            this.line9.X1 = 0F;
            this.line9.X2 = 10.88F;
            this.line9.Y1 = 0F;
            this.line9.Y2 = 0F;
            // 
            // Grand_SalesTax
            // 
            this.Grand_SalesTax.Border.BottomColor = System.Drawing.Color.Black;
            this.Grand_SalesTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesTax.Border.LeftColor = System.Drawing.Color.Black;
            this.Grand_SalesTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesTax.Border.RightColor = System.Drawing.Color.Black;
            this.Grand_SalesTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesTax.Border.TopColor = System.Drawing.Color.Black;
            this.Grand_SalesTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesTax.DataField = "SalesTax";
            this.Grand_SalesTax.Height = 0.125F;
            this.Grand_SalesTax.Left = 7.125F;
            this.Grand_SalesTax.MultiLine = false;
            this.Grand_SalesTax.Name = "Grand_SalesTax";
            this.Grand_SalesTax.OutputFormat = resources.GetString("Grand_SalesTax.OutputFormat");
            this.Grand_SalesTax.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.Grand_SalesTax.SummaryGroup = "GrandTotalHeader";
            this.Grand_SalesTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Grand_SalesTax.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Grand_SalesTax.Text = "1236547894";
            this.Grand_SalesTax.Top = 0.0625F;
            this.Grand_SalesTax.Visible = false;
            this.Grand_SalesTax.Width = 0.625F;
            // 
            // Grand_SalesTotalAll
            // 
            this.Grand_SalesTotalAll.Border.BottomColor = System.Drawing.Color.Black;
            this.Grand_SalesTotalAll.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesTotalAll.Border.LeftColor = System.Drawing.Color.Black;
            this.Grand_SalesTotalAll.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesTotalAll.Border.RightColor = System.Drawing.Color.Black;
            this.Grand_SalesTotalAll.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesTotalAll.Border.TopColor = System.Drawing.Color.Black;
            this.Grand_SalesTotalAll.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Grand_SalesTotalAll.DataField = "SalesTotalAll";
            this.Grand_SalesTotalAll.Height = 0.125F;
            this.Grand_SalesTotalAll.Left = 7.75F;
            this.Grand_SalesTotalAll.MultiLine = false;
            this.Grand_SalesTotalAll.Name = "Grand_SalesTotalAll";
            this.Grand_SalesTotalAll.OutputFormat = resources.GetString("Grand_SalesTotalAll.OutputFormat");
            this.Grand_SalesTotalAll.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.Grand_SalesTotalAll.SummaryGroup = "GrandTotalHeader";
            this.Grand_SalesTotalAll.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Grand_SalesTotalAll.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Grand_SalesTotalAll.Text = "123,456,789";
            this.Grand_SalesTotalAll.Top = 0.0625F;
            this.Grand_SalesTotalAll.Width = 0.6875F;
            // 
            // DateHeader
            // 
            this.DateHeader.CanShrink = true;
            this.DateHeader.DataField = "SalesDate";
            this.DateHeader.Height = 0F;
            this.DateHeader.KeepTogether = true;
            this.DateHeader.Name = "DateHeader";
            this.DateHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage;
            // 
            // DateFooter
            // 
            this.DateFooter.CanShrink = true;
            this.DateFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.textBox5,
            this.textBox11,
            this.Date_SalesMoney,
            this.Date_TotalCostSl,
            this.label12,
            this.Date_SalesGrossProfit,
            this.Date_SalesGrossMarginRate,
            this.Date_SalesPercentage,
            this.Date_SalesGrossMarginMark,
            this.line2,
            this.Date_SalesTax,
            this.Date_SalesTotalAll});
            this.DateFooter.Height = 0.3229167F;
            this.DateFooter.KeepTogether = true;
            this.DateFooter.Name = "DateFooter";
            this.DateFooter.BeforePrint += new System.EventHandler(this.DateFooter_BeforePrint);
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
            this.textBox5.Height = 0.1875F;
            this.textBox5.Left = 4.5F;
            this.textBox5.MultiLine = false;
            this.textBox5.Name = "textBox5";
            this.textBox5.OutputFormat = resources.GetString("textBox5.OutputFormat");
            this.textBox5.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10" +
                ".8pt; font-family: �l�r ����; white-space: nowrap; vertical-align: top; ";
            this.textBox5.Text = "�󒍓��v";
            this.textBox5.Top = 0.0625F;
            this.textBox5.Width = 0.9375F;
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
            this.textBox11.DataField = "CntSales";
            this.textBox11.Height = 0.125F;
            this.textBox11.Left = 5.5F;
            this.textBox11.MultiLine = false;
            this.textBox11.Name = "textBox11";
            this.textBox11.OutputFormat = resources.GetString("textBox11.OutputFormat");
            this.textBox11.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.textBox11.SummaryGroup = "DateHeader";
            this.textBox11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.textBox11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.textBox11.Text = "0";
            this.textBox11.Top = 0.0625F;
            this.textBox11.Width = 0.25F;
            // 
            // Date_SalesMoney
            // 
            this.Date_SalesMoney.Border.BottomColor = System.Drawing.Color.Black;
            this.Date_SalesMoney.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesMoney.Border.LeftColor = System.Drawing.Color.Black;
            this.Date_SalesMoney.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesMoney.Border.RightColor = System.Drawing.Color.Black;
            this.Date_SalesMoney.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesMoney.Border.TopColor = System.Drawing.Color.Black;
            this.Date_SalesMoney.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesMoney.DataField = "SalesMoney";
            this.Date_SalesMoney.Height = 0.125F;
            this.Date_SalesMoney.Left = 6.3125F;
            this.Date_SalesMoney.MultiLine = false;
            this.Date_SalesMoney.Name = "Date_SalesMoney";
            this.Date_SalesMoney.OutputFormat = resources.GetString("Date_SalesMoney.OutputFormat");
            this.Date_SalesMoney.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.Date_SalesMoney.SummaryGroup = "DateHeader";
            this.Date_SalesMoney.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Date_SalesMoney.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Date_SalesMoney.Text = "963258741258";
            this.Date_SalesMoney.Top = 0.0625F;
            this.Date_SalesMoney.Width = 0.813F;
            // 
            // Date_TotalCostSl
            // 
            this.Date_TotalCostSl.Border.BottomColor = System.Drawing.Color.Black;
            this.Date_TotalCostSl.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_TotalCostSl.Border.LeftColor = System.Drawing.Color.Black;
            this.Date_TotalCostSl.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_TotalCostSl.Border.RightColor = System.Drawing.Color.Black;
            this.Date_TotalCostSl.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_TotalCostSl.Border.TopColor = System.Drawing.Color.Black;
            this.Date_TotalCostSl.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_TotalCostSl.DataField = "TotalCostSl";
            this.Date_TotalCostSl.Height = 0.125F;
            this.Date_TotalCostSl.Left = 8.4375F;
            this.Date_TotalCostSl.MultiLine = false;
            this.Date_TotalCostSl.Name = "Date_TotalCostSl";
            this.Date_TotalCostSl.OutputFormat = resources.GetString("Date_TotalCostSl.OutputFormat");
            this.Date_TotalCostSl.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.Date_TotalCostSl.SummaryGroup = "DateHeader";
            this.Date_TotalCostSl.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Date_TotalCostSl.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Date_TotalCostSl.Text = "-123456789012";
            this.Date_TotalCostSl.Top = 0.0625F;
            this.Date_TotalCostSl.Width = 0.813F;
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
            this.label12.Height = 0.125F;
            this.label12.HyperLink = "";
            this.label12.Left = 5.875F;
            this.label12.Name = "label12";
            this.label12.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; white-space: nowrap; vertical-align: top; ";
            this.label12.Text = "��";
            this.label12.Top = 0.0625F;
            this.label12.Width = 0.1875F;
            // 
            // Date_SalesGrossProfit
            // 
            this.Date_SalesGrossProfit.Border.BottomColor = System.Drawing.Color.Black;
            this.Date_SalesGrossProfit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesGrossProfit.Border.LeftColor = System.Drawing.Color.Black;
            this.Date_SalesGrossProfit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesGrossProfit.Border.RightColor = System.Drawing.Color.Black;
            this.Date_SalesGrossProfit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesGrossProfit.Border.TopColor = System.Drawing.Color.Black;
            this.Date_SalesGrossProfit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesGrossProfit.DataField = "SalesGrossProfit";
            this.Date_SalesGrossProfit.Height = 0.125F;
            this.Date_SalesGrossProfit.Left = 9.25F;
            this.Date_SalesGrossProfit.MultiLine = false;
            this.Date_SalesGrossProfit.Name = "Date_SalesGrossProfit";
            this.Date_SalesGrossProfit.OutputFormat = resources.GetString("Date_SalesGrossProfit.OutputFormat");
            this.Date_SalesGrossProfit.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.Date_SalesGrossProfit.SummaryGroup = "DateHeader";
            this.Date_SalesGrossProfit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Date_SalesGrossProfit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Date_SalesGrossProfit.Text = "12345678945";
            this.Date_SalesGrossProfit.Top = 0.0625F;
            this.Date_SalesGrossProfit.Width = 0.688F;
            // 
            // Date_SalesGrossMarginRate
            // 
            this.Date_SalesGrossMarginRate.Border.BottomColor = System.Drawing.Color.Black;
            this.Date_SalesGrossMarginRate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesGrossMarginRate.Border.LeftColor = System.Drawing.Color.Black;
            this.Date_SalesGrossMarginRate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesGrossMarginRate.Border.RightColor = System.Drawing.Color.Black;
            this.Date_SalesGrossMarginRate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesGrossMarginRate.Border.TopColor = System.Drawing.Color.Black;
            this.Date_SalesGrossMarginRate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesGrossMarginRate.CanGrow = false;
            this.Date_SalesGrossMarginRate.Height = 0.125F;
            this.Date_SalesGrossMarginRate.Left = 9.9375F;
            this.Date_SalesGrossMarginRate.MultiLine = false;
            this.Date_SalesGrossMarginRate.Name = "Date_SalesGrossMarginRate";
            this.Date_SalesGrossMarginRate.OutputFormat = resources.GetString("Date_SalesGrossMarginRate.OutputFormat");
            this.Date_SalesGrossMarginRate.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.Date_SalesGrossMarginRate.Text = "-100.00";
            this.Date_SalesGrossMarginRate.Top = 0.0625F;
            this.Date_SalesGrossMarginRate.Width = 0.4375F;
            // 
            // Date_SalesPercentage
            // 
            this.Date_SalesPercentage.Border.BottomColor = System.Drawing.Color.Black;
            this.Date_SalesPercentage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesPercentage.Border.LeftColor = System.Drawing.Color.Black;
            this.Date_SalesPercentage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesPercentage.Border.RightColor = System.Drawing.Color.Black;
            this.Date_SalesPercentage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesPercentage.Border.TopColor = System.Drawing.Color.Black;
            this.Date_SalesPercentage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesPercentage.Height = 0.125F;
            this.Date_SalesPercentage.HyperLink = "";
            this.Date_SalesPercentage.Left = 10.375F;
            this.Date_SalesPercentage.Name = "Date_SalesPercentage";
            this.Date_SalesPercentage.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.Date_SalesPercentage.Text = "��";
            this.Date_SalesPercentage.Top = 0.0625F;
            this.Date_SalesPercentage.Width = 0.125F;
            // 
            // Date_SalesGrossMarginMark
            // 
            this.Date_SalesGrossMarginMark.Border.BottomColor = System.Drawing.Color.Black;
            this.Date_SalesGrossMarginMark.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesGrossMarginMark.Border.LeftColor = System.Drawing.Color.Black;
            this.Date_SalesGrossMarginMark.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesGrossMarginMark.Border.RightColor = System.Drawing.Color.Black;
            this.Date_SalesGrossMarginMark.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesGrossMarginMark.Border.TopColor = System.Drawing.Color.Black;
            this.Date_SalesGrossMarginMark.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesGrossMarginMark.CanGrow = false;
            this.Date_SalesGrossMarginMark.Height = 0.125F;
            this.Date_SalesGrossMarginMark.Left = 10.5F;
            this.Date_SalesGrossMarginMark.Name = "Date_SalesGrossMarginMark";
            this.Date_SalesGrossMarginMark.OutputFormat = resources.GetString("Date_SalesGrossMarginMark.OutputFormat");
            this.Date_SalesGrossMarginMark.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 8p" +
                "t; font-family: �l�r ����; vertical-align: top; ";
            this.Date_SalesGrossMarginMark.Text = "��";
            this.Date_SalesGrossMarginMark.Top = 0.0625F;
            this.Date_SalesGrossMarginMark.Width = 0.1875F;
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
            this.line2.Width = 10.875F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.875F;
            this.line2.Y1 = 0F;
            this.line2.Y2 = 0F;
            // 
            // Date_SalesTax
            // 
            this.Date_SalesTax.Border.BottomColor = System.Drawing.Color.Black;
            this.Date_SalesTax.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesTax.Border.LeftColor = System.Drawing.Color.Black;
            this.Date_SalesTax.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesTax.Border.RightColor = System.Drawing.Color.Black;
            this.Date_SalesTax.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesTax.Border.TopColor = System.Drawing.Color.Black;
            this.Date_SalesTax.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesTax.DataField = "SalesTax";
            this.Date_SalesTax.Height = 0.125F;
            this.Date_SalesTax.Left = 7.125F;
            this.Date_SalesTax.MultiLine = false;
            this.Date_SalesTax.Name = "Date_SalesTax";
            this.Date_SalesTax.OutputFormat = resources.GetString("Date_SalesTax.OutputFormat");
            this.Date_SalesTax.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.Date_SalesTax.SummaryGroup = "DateHeader";
            this.Date_SalesTax.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Date_SalesTax.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Date_SalesTax.Text = "1236547894";
            this.Date_SalesTax.Top = 0.0625F;
            this.Date_SalesTax.Visible = false;
            this.Date_SalesTax.Width = 0.625F;
            // 
            // Date_SalesTotalAll
            // 
            this.Date_SalesTotalAll.Border.BottomColor = System.Drawing.Color.Black;
            this.Date_SalesTotalAll.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesTotalAll.Border.LeftColor = System.Drawing.Color.Black;
            this.Date_SalesTotalAll.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesTotalAll.Border.RightColor = System.Drawing.Color.Black;
            this.Date_SalesTotalAll.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesTotalAll.Border.TopColor = System.Drawing.Color.Black;
            this.Date_SalesTotalAll.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Date_SalesTotalAll.DataField = "SalesTotalAll";
            this.Date_SalesTotalAll.Height = 0.125F;
            this.Date_SalesTotalAll.Left = 7.75F;
            this.Date_SalesTotalAll.MultiLine = false;
            this.Date_SalesTotalAll.Name = "Date_SalesTotalAll";
            this.Date_SalesTotalAll.OutputFormat = resources.GetString("Date_SalesTotalAll.OutputFormat");
            this.Date_SalesTotalAll.Style = "color: Black; ddo-char-set: 1; text-align: right; font-weight: bold; font-size: 8" +
                "pt; font-family: �l�r �S�V�b�N; white-space: nowrap; vertical-align: top; ";
            this.Date_SalesTotalAll.SummaryGroup = "DateHeader";
            this.Date_SalesTotalAll.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Date_SalesTotalAll.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Date_SalesTotalAll.Text = "123,456,789";
            this.Date_SalesTotalAll.Top = 0.0625F;
            this.Date_SalesTotalAll.Width = 0.6875F;
            // 
            // DCHNB02012P_01A4C
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
            this.PageSettings.PaperWidth = 8.267716F;
            this.PrintWidth = 10.88F;
            this.Sections.Add(this.reportHeader1);
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.Header1);
            this.Sections.Add(this.DateHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.DateFooter);
            this.Sections.Add(this.Footer1);
            this.Sections.Add(this.SectionFooter);
            this.Sections.Add(this.GrandTotalFooter);
            this.Sections.Add(this.TitleFooter);
            this.Sections.Add(this.ExtraFooter);
            this.Sections.Add(this.PageFooter);
            this.Sections.Add(this.reportFooter1);
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet"), "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet1"), "Heading1", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet2"), "Heading2", "Normal"));
            this.StyleSheet.Add(new DDCssLib.StyleSheetRule(resources.GetString("$this.StyleSheet3"), "Heading3", "Normal"));
            this.ReportStart += new System.EventHandler(this.DCHNB02012P_01A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.SalesTotalTaxExcPlusTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrontEmployeeNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesTotalTaxExc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchSlipDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerSnm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesSlipNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesEmployeeNm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesSlipName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossMarginMarkSlip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_Percentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SalesInputName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DATE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TIME)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPageNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SORTTITLE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Extraction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Extraction2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_GrossMarginRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_Cost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label_GrossMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_SalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_TotalCostSl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_SalesGrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_SalesGrossMarginRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_SalesPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_SalesGrossMarginMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer1Field)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer1_SalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer1_TotalCostSl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer1_SalesGrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer1_SalesGrossMarginRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer1_SalesPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer1_SalesGrossMarginMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer1_SalesTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Footer1_SalesTotalAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_SalesTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_SalesTotalAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grand_SalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grand_TotalCostSl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grand_SalesGrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grand_SalesGrossMarginRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grand_SalesPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grand_SalesGrossMarginMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grand_SalesTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grand_SalesTotalAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_SalesMoney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_TotalCostSl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_SalesGrossProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_SalesGrossMarginRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_SalesPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_SalesGrossMarginMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_SalesTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Date_SalesTotalAll)).EndInit();
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
		/// <param name="sections">�ΏۃI�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note		: �Z�N�V�����̃f�[�^�����[�h����A�����ꂽ��ɔ������܂��B</br>
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


        /// <summary>
        /// ���v�󎚂�DataField�ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note		: �\�[�g���̏��v�ɂ���DataField��ݒ肵�܂��B</br>
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2008.07.29</br>
        /// </remarks>
        private void ChangeGroupOrder()
        {

            switch (this._extraInfo.SortOrder)
            {
                case 0:  // �󒍓�+�`�[�ԍ�
                    {
                        this.Header1.DataField = "";
                        this.Footer1Field.Text = "";

                        break;
                    }

                case 1:  // �`�[�ԍ�
                    {
                        this.Header1.DataField = "";
                        this.Footer1Field.Text = "";

                        break;
                    }
                case 2:  // ���Ӑ�+�`�[�ԍ�
                    {
                        this.Header1.DataField = "CustomerCode";
                        // 2008.09.29 980035 ���� ��` �C�� >>>>>>START
                        //this.Footer1Field.Text = "�y���Ӑ�v�z";
                        this.Footer1Field.Text = "���Ӑ�v";
                        // 2008.09.29 980035 ���� ��` �C�� <<<<<<END

                        break;
                    }
                case 3:  // �S����+�`�[�ԍ�
                    {
                        this.Header1.DataField = "SalesEmployeeNm";
                        // 2008.09.29 980035 ���� ��` �C�� >>>>>>START
                        //this.Footer1Field.Text = "�y�S���Ҍv�z";
                        this.Footer1Field.Text = "�S���Ҍv";
                        // 2008.09.29 980035 ���� ��` �C�� <<<<<<END

                        break;
                    }
            }
        }

        // --- ADD 2009/03/30 -------------------------------->>>>>
        /// <summary>
        /// �����E�e���󎚐��䏈��
        /// </summary>
        private void ChangeCostPrt()
        {
            switch (this._extraInfo.CostOut)
            {
                case 0:  // �󎚂��Ȃ�
                    {
                        // �����^�C�g����
                        // �������z
                        this.Label_Cost.Visible = false;
                        // �e��(����)
                        this.Label_GrossMargin.Visible = false;
                        // �e����(����)
                        this.Label_GrossMarginRate.Visible = false;

                        // �������ו�
                        // �������z
                        this.TotalCost.Visible = false;
                        // �e��(����)
                        this.GrossProfit.Visible = false;
                        // �e����(����)
                        this.GrossMarginRate.Visible = false;
                        // �p�[�Z���g(���x���\��)
                        this.Label_Percentage.Visible = false;
                        // �e�����̃}�[�N
                        this.GrossMarginMarkSlip.Visible = false;

                        // �����󒍓��v��(Date)
                        this.Date_TotalCostSl.Visible = false;
                        this.Date_SalesGrossProfit.Visible = false;
                        this.Date_SalesGrossMarginRate.Visible = false;
                        this.Date_SalesPercentage.Visible = false;
                        this.Date_SalesGrossMarginMark.Visible = false;

                        // �������v��(Footer1)
                        this.Footer1_TotalCostSl.Visible = false;
                        this.Footer1_SalesGrossProfit.Visible = false;
                        this.Footer1_SalesGrossMarginRate.Visible = false;
                        this.Footer1_SalesPercentage.Visible = false;
                        this.Footer1_SalesGrossMarginMark.Visible = false;

                        // �������_�v��
                        this.Section_TotalCostSl.Visible = false;
                        this.Section_SalesGrossProfit.Visible = false;
                        this.Section_SalesGrossMarginRate.Visible = false;
                        this.Section_SalesPercentage.Visible = false;
                        this.Section_SalesGrossMarginMark.Visible = false;

                        // ���������v��
                        this.Grand_TotalCostSl.Visible = false;
                        this.Grand_SalesGrossProfit.Visible = false;
                        this.Grand_SalesGrossMarginRate.Visible = false;
                        this.Grand_SalesPercentage.Visible = false;
                        this.Grand_SalesGrossMarginMark.Visible = false;

                        break;
                    }

                case 1:  // �󎚂���
                    {
                        // �����^�C�g����
                        // �������z
                        this.Label_Cost.Visible = true;
                        // �e��(����)
                        this.Label_GrossMargin.Visible = true;
                        // �e����(����)
                        this.Label_GrossMarginRate.Visible = true;


                        // �������ו�
                        // �������z
                        this.TotalCost.Visible = true;
                        // �e��(����)
                        this.GrossProfit.Visible = true;
                        // �e����(����)
                        this.GrossMarginRate.Visible = true;
                        // �p�[�Z���g(���x���\��)
                        this.Label_Percentage.Visible = true;
                        // �e�����̃}�[�N
                        this.GrossMarginMarkSlip.Visible = true;

                        // �����󒍕�(Date)
                        this.Date_TotalCostSl.Visible = true;
                        this.Date_SalesGrossProfit.Visible = true;
                        this.Date_SalesGrossMarginRate.Visible = true;
                        this.Date_SalesPercentage.Visible = true;
                        this.Date_SalesGrossMarginMark.Visible = true;

                        // �������v��(Footer1)
                        this.Footer1_TotalCostSl.Visible = true;
                        this.Footer1_SalesGrossProfit.Visible = true;
                        this.Footer1_SalesGrossMarginRate.Visible = true;
                        this.Footer1_SalesPercentage.Visible = true;
                        this.Footer1_SalesGrossMarginMark.Visible = true;

                        // �������_�v��
                        this.Section_TotalCostSl.Visible = true;
                        this.Section_SalesGrossProfit.Visible = true;
                        this.Section_SalesGrossMarginRate.Visible = true;
                        this.Section_SalesPercentage.Visible = true;
                        this.Section_SalesGrossMarginMark.Visible = true;

                        // ���������v��
                        this.Grand_TotalCostSl.Visible = true;
                        this.Grand_SalesGrossProfit.Visible = true;
                        this.Grand_SalesGrossMarginRate.Visible = true;
                        this.Grand_SalesPercentage.Visible = true;
                        this.Grand_SalesGrossMarginMark.Visible = true;

                        break;
                    }
            }
        }
        // --- ADD 2009/03/30 --------------------------------<<<<<

        /// <summary>
        /// ���v�󎚐��䏈��
        /// </summary>
        /// <remarks>
        /// <br>Note		: �\�[�g���̏��v�ɂ��Ĉ󎚂�ݒ肵�܂��B</br>
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2008.07.29</br>
        /// </remarks>
        private void ChangeSumRec()
        {
            switch (this._extraInfo.SortOrder)
            {
                case 0:  // �󒍓�+�`�[�ԍ�
                    {
                        this.Header1.Visible = false;
                        this.Footer1.Visible = false;   // 

                        break;
                    }

                case 1:  // �`�[�ԍ�
                    {
                        this.Header1.Visible = false;
                        this.Footer1.Visible = false;   // 

                        break;
                    }
                case 2:  // ���Ӑ�+�`�[�ԍ�
                    {
                        this.Header1.Visible = true;
                        this.Footer1.Visible = true;   // ���Ӑ�

                        break;
                    }
                case 3:  // �S����+�`�[�ԍ�
                    {
                        this.Header1.Visible = true;
                        this.Footer1.Visible = true;   // �S���Ҍv

                        break;
                    }
            }

            // --- ADD 2009/03/30 -------------------------------->>>>>
            // �󒍓��v�̈󎚐���
            if (this._extraInfo.PrintDailyFooter == 0)
            {
                this.DateFooter.Visible = false;
            }
            else
            {
                this.DateFooter.Visible = true;
            }
            // --- ADD 2009/03/30 --------------------------------<<<<<
        }


		//TODO�F07.10.31
		// ���o�������ȉ����ڂ��I������Ă����������󎚂Ƃ��������B
		//���Ƃ��Ǝ󒍏o�ו\�t�N���X�Ɉȉ��̒��o�����͖������߂��̂܂܂̐ݒ肾�ƈ󎚂���Ȃ��B
		//�}�X�^�ݒ�̕��Œ��o�����Ɏg�p�����\��������̂ŁA�Ƃ肠�����ȉ��̃��\�b�h�͕ۗ��B
 #if false
		/// <summary>
        /// �����E�e���󎚐��䏈��
		/// </summary>
        private void ChangeCostPrt()
        {
            switch (this._extraInfo.CostOut)
            {

                case 0:  // �󎚂��Ȃ�
                    {
						//�w�������z�x
						this.label13.Visible = false;
						//�w�e�����x(�`�[)
						this.lblGrossMarginRate.Visible = false;

						//�e����(�`�[)
						this.GrossMarginRate.Visible = false;
						//�e�����`�F�b�N�L��(�`�[)
						this.GrossMarginMarkSlip.Visible = false;

						//�������z
						this.CostRF.Visible = false;
					
                        break;
                    }

				case 1:  // �󎚂���
                    {
						//�w�������z�x
						this.label13.Visible = true;
                        //�w�e�����x(�`�[)
						this.lblGrossMarginRate.Visible = true;
                        
                        //�e����(�`�[)
                        this.GrossMarginRate.Visible = true;
                        //�e�����`�F�b�N�L��(�`�[)
                        this.GrossMarginMarkSlip.Visible = true;
                        //�������z
                        this.CostRF.Visible = true;

						this.ALLSUMCOST.Visible = true;
                        

                        break;
                    }
            }

        }
#endif

        #region �����v�̑e�������o��
        /// <summary>
        /// �����v�̑e�������o�͏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: �����v�̊e�e�������o�͂��܂��B</br>
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2008.07.28</br>
        /// </remarks>
        private void GrandTotalFooter_BeforePrint(object sender, EventArgs e)
        {
            string grossMarginRate = "";
            string grossMarginMark = "";

            // ����̑e������ݒ�
            grossMarginRate = this.Grand_SalesGrossMarginRate.Text;
            grossMarginMark = this.Grand_SalesGrossMarginMark.Text;
            // �e�����ݒ�
            SetGrossMargin(this.Grand_SalesMoney.Text, this.Grand_TotalCostSl.Text, ref grossMarginRate, ref grossMarginMark);
            this.Grand_SalesGrossMarginRate.Text = grossMarginRate;
            this.Grand_SalesGrossMarginMark.Text = grossMarginMark;

            // --- DEL 2009/03/30 -------------------------------->>>>>
            //// �ԕi�̑e������ݒ�
            //grossMarginRate = this.Grand_ReturnGrossMarginRate.Text;
            //grossMarginMark = this.Grand_ReturnGrossMarginMark.Text;
            //// �e�����ݒ�
            //SetGrossMargin(this.Grand_ReturnSalesMoney.Text, this.Grand_SalesReturnCost.Text, ref grossMarginRate, ref grossMarginMark);
            //this.Grand_ReturnGrossMarginRate.Text = grossMarginRate;
            //this.Grand_ReturnGrossMarginMark.Text = grossMarginMark;

            //// �l�����̑e������ݒ�
            //grossMarginRate = this.Grand_DistGrossMarginRate.Text;
            //grossMarginMark = this.Grand_DistGrossMarginMark.Text;
            //// �e�����ݒ�
            //SetGrossMargin(this.Grand_DistSalesMoney.Text, this.Grand_DistCost.Text, ref grossMarginRate, ref grossMarginMark);
            //this.Grand_DistGrossMarginRate.Text = grossMarginRate;
            //this.Grand_DistGrossMarginMark.Text = grossMarginMark;

            //// ������̑e������ݒ�
            //grossMarginRate = this.Grand_TotalGrossMarginRate.Text;
            //grossMarginMark = this.Grand_TotalGrossMarginMark.Text;
            //// �e�����ݒ�
            //SetGrossMargin(this.Grand_SalesMoney.Text, this.Grand_TotalCost.Text, ref grossMarginRate, ref grossMarginMark);
            //this.Grand_TotalGrossMarginRate.Text = grossMarginRate;
            //this.Grand_TotalGrossMarginMark.Text = grossMarginMark;
            // --- DEL 2009/03/30 --------------------------------<<<<<
        }
        #endregion

        #region ���_�v�̑e�������o��
        /// <summary>
        /// ���_�v�̑e�������o�͂��鏈��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: ���_�v�̊e�e�������o�͂��܂��B</br>
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2008.07.28</br>
        /// </remarks>
        private void SectionFooter_BeforePrint(object sender, EventArgs e)
        {
            string grossMarginRate = "";
            string grossMarginMark = "";

            // ����̑e������ݒ�
            grossMarginRate = this.Section_SalesGrossMarginRate.Text;
            grossMarginMark = this.Section_SalesGrossMarginMark.Text;
            // �e�����ݒ�
            SetGrossMargin(this.Section_SalesMoney.Text, this.Section_TotalCostSl.Text, ref grossMarginRate, ref grossMarginMark);
            this.Section_SalesGrossMarginRate.Text = grossMarginRate;
            this.Section_SalesGrossMarginMark.Text = grossMarginMark;

            // --- DEL 2009/03/30 -------------------------------->>>>>
            //// �ԕi�̑e������ݒ�
            //grossMarginRate = this.Section_ReturnGrossMarginRate.Text;
            //grossMarginMark = this.Section_ReturnGrossMarginMark.Text;
            //// �e�����ݒ�
            //SetGrossMargin(this.Section_ReturnSalesMoney.Text, this.Section_SalesReturnCost.Text, ref grossMarginRate, ref grossMarginMark);
            //this.Section_ReturnGrossMarginRate.Text = grossMarginRate;
            //this.Section_ReturnGrossMarginMark.Text = grossMarginMark;

            //// �l�����̑e������ݒ�
            //grossMarginRate = this.Section_DistGrossMarginRate.Text;
            //grossMarginMark = this.Section_DistGrossMarginMark.Text;
            //// �e�����ݒ�
            //SetGrossMargin(this.Section_DistSalesMoney.Text, this.Section_DistCost.Text, ref grossMarginRate, ref grossMarginMark);
            //this.Section_DistGrossMarginRate.Text = grossMarginRate;
            //this.Section_DistGrossMarginMark.Text = grossMarginMark;

            //// ������̑e������ݒ�
            //grossMarginRate = this.Section_TotalGrossMarginRate.Text;
            //grossMarginMark = this.Section_TotalGrossMarginMark.Text;
            //// �e�����ݒ�
            //SetGrossMargin(this.Section_SalesMoney.Text, this.Section_TotalCost.Text, ref grossMarginRate, ref grossMarginMark);
            //this.Section_TotalGrossMarginRate.Text = grossMarginRate;
            //this.Section_TotalGrossMarginMark.Text = grossMarginMark;
            // --- DEL 2009/03/30 --------------------------------<<<<<
        }
        #endregion

        #region Footer1�̑e�������o��
        /// <summary>
        /// Footer1�̑e�������o�͏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: Footer1�̊e�e�������o�͂��܂��B</br>
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2008.07.28</br>
        /// </remarks>
        private void Footer1_BeforePrint(object sender, EventArgs e)
        {
            string grossMarginRate = "";
            string grossMarginMark = "";

            // ����̑e������ݒ�
            grossMarginRate = this.Footer1_SalesGrossMarginRate.Text;
            grossMarginMark = this.Footer1_SalesGrossMarginMark.Text;
            // �e�����ݒ�
            SetGrossMargin(this.Footer1_SalesMoney.Text, this.Footer1_TotalCostSl.Text, ref grossMarginRate, ref grossMarginMark);
            this.Footer1_SalesGrossMarginRate.Text = grossMarginRate;
            this.Footer1_SalesGrossMarginMark.Text = grossMarginMark;

            // --- DEL 2009/03/30 -------------------------------->>>>>
            //// �ԕi�̑e������ݒ�
            //grossMarginRate = this.Footer1_ReturnGrossMarginRate.Text;
            //grossMarginMark = this.Footer1_ReturnGrossMarginMark.Text;
            //// �e�����ݒ�
            //SetGrossMargin(this.Footer1_ReturnSalesMoney.Text, this.Footer1_SalesReturnCost.Text, ref grossMarginRate, ref grossMarginMark);
            //this.Footer1_ReturnGrossMarginRate.Text = grossMarginRate;
            //this.Footer1_ReturnGrossMarginMark.Text = grossMarginMark;

            //// �l�����̑e������ݒ�
            //grossMarginRate = this.Footer1_DistGrossMarginRate.Text;
            //grossMarginMark = this.Footer1_DistGrossMarginMark.Text;
            //// �e�����ݒ�
            //SetGrossMargin(this.Footer1_DistSalesMoney.Text, this.Footer1_DistCost.Text, ref grossMarginRate, ref grossMarginMark);
            //this.Footer1_DistGrossMarginRate.Text = grossMarginRate;
            //this.Footer1_DistGrossMarginMark.Text = grossMarginMark;

            //// ������̑e������ݒ�
            //grossMarginRate = this.Footer1_TotalGrossMarginRate.Text;
            //grossMarginMark = this.Footer1_TotalGrossMarginMark.Text;
            //// �e�����ݒ�
            //SetGrossMargin(this.Footer1_SalesMoney.Text, this.Footer1_TotalCost.Text, ref grossMarginRate, ref grossMarginMark);
            //this.Footer1_TotalGrossMarginRate.Text = grossMarginRate;
            //this.Footer1_TotalGrossMarginMark.Text = grossMarginMark;
            // --- DEL 2009/03/30 --------------------------------<<<<<
        }
        #endregion

        #region DateFooter�̑e�������o��
        /// <summary>
        /// DateFooter�̑e�������o�͏���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: DateFooter�̊e�e�������o�͂��܂��B</br>
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2008.12.09</br>
        /// </remarks>
        private void DateFooter_BeforePrint(object sender, EventArgs e)
        {
            string grossMarginRate = "";
            string grossMarginMark = "";

            // ����̑e������ݒ�
            grossMarginRate = this.Date_SalesGrossMarginRate.Text;
            grossMarginMark = this.Date_SalesGrossMarginMark.Text;
            // �e�����ݒ�
            SetGrossMargin(this.Date_SalesMoney.Text, this.Date_TotalCostSl.Text, ref grossMarginRate, ref grossMarginMark);
            this.Date_SalesGrossMarginRate.Text = grossMarginRate;
            this.Date_SalesGrossMarginMark.Text = grossMarginMark;

            // --- DEL 2009/03/30 -------------------------------->>>>>
            //// �ԕi�̑e������ݒ�
            //grossMarginRate = this.Date_ReturnGrossMarginRate.Text;
            //grossMarginMark = this.Date_ReturnGrossMarginMark.Text;
            //// �e�����ݒ�
            //SetGrossMargin(this.Date_ReturnSalesMoney.Text, this.Date_SalesReturnCost.Text, ref grossMarginRate, ref grossMarginMark);
            //this.Date_ReturnGrossMarginRate.Text = grossMarginRate;
            //this.Date_ReturnGrossMarginMark.Text = grossMarginMark;

            //// �l�����̑e������ݒ�
            //grossMarginRate = this.Date_DistGrossMarginRate.Text;
            //grossMarginMark = this.Date_DistGrossMarginMark.Text;
            //// �e�����ݒ�
            //SetGrossMargin(this.Date_DistSalesMoney.Text, this.Date_DistCost.Text, ref grossMarginRate, ref grossMarginMark);
            //this.Date_DistGrossMarginRate.Text = grossMarginRate;
            //this.Date_DistGrossMarginMark.Text = grossMarginMark;

            //// ������̑e������ݒ�
            //grossMarginRate = this.Date_TotalGrossMarginRate.Text;
            //grossMarginMark = this.Date_TotalGrossMarginMark.Text;
            //// �e�����ݒ�
            //SetGrossMargin(this.Date_SalesMoney.Text, this.Date_TotalCost.Text, ref grossMarginRate, ref grossMarginMark);
            //this.Date_TotalGrossMarginRate.Text = grossMarginRate;
            //this.Date_TotalGrossMarginMark.Text = grossMarginMark;
            // --- DEL 2009/03/30 --------------------------------<<<<<
        }
        #endregion

        /// <summary>
        /// �e�����̐ݒ菈��
        /// </summary>
        /// <param name="money">���z</param>
        /// <param name="cost">����</param>
        /// <param name="grossMarginRate">�e����</param>
        /// <param name="grossMarginMark">�e���`�F�b�N�}�[�N</param>
        /// <remarks>
        /// <br>Note		: ���z�ƌ�������e������ݒ肵�܂��B</br>
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2008.07.28</br>
        /// </remarks>
        private void SetGrossMargin(string money, string cost, ref string grossMarginRate, ref string grossMarginMark)
        {
            double rate = new double();

            // �����񏉊���
            grossMarginRate = "";
            grossMarginMark = "";

            // �J���}�̏���
            money = money.Replace(",", "");         // ���z
            cost = cost.Replace(",", "");           // ����

            // ���z�ƌ�����"0"�̏ꍇ�A�e������"0.00"��Ԃ�
            if ((money == "0") && (cost == "0"))
            {
                rate = 0.00;
                grossMarginRate = "0.00";
            }
            // ���z��"0"�A������0�ȏ�̏ꍇ�A�e������"0.00"��Ԃ�
            else if ((money == "0") && (Int64.Parse(cost) >= 0))
            {
                rate = 0.00;
                grossMarginRate = "0.00";
            }
            // ��L�ȊO�̏ꍇ�A�e�������v�Z����
            else
            {
                rate = ((double.Parse(money) - double.Parse(cost)) / double.Parse(money) * 100);
                grossMarginRate = String.Format("{0:F2}", rate);
            }
            
            // �e���}�[�N�̐ݒ�
            if (rate < this._extraInfo.GrsProfitCheckLower)
            {
                grossMarginMark = this._extraInfo.GrossMargin1Mark;
            }
            else if (rate < this._extraInfo.GrsProfitCheckBest)//add 2011/12/02 ���� Redmine #8316
            //else if ((rate >= this._extraInfo.GrsProfitCheckLower) && (rate <= this._extraInfo.GrossMarginBest2))//del 2011/12/02 ���� Redmine #8316
            {
                grossMarginMark = this._extraInfo.GrossMargin2Mark;
            }
            else if (rate < this._extraInfo.GrsProfitCheckUpper)//add 2011/12/02 ���� Redmine #8316
            //else if ((rate >= this._extraInfo.GrsProfitCheckBest) && (rate <= this._extraInfo.GrossMarginUpper2))//del 2011/12/02 ���� Redmine #8316
            {
                grossMarginMark = this._extraInfo.GrossMargin3Mark;
            }
            else
            {
                grossMarginMark = this._extraInfo.GrossMargin4Mark;
            }
        }

        #endregion

        // --- ADD 2008/10/31 --------------------------------------------------------->>>>>
        /// <summary>
        /// Detail�����ݒ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Detail_Format(object sender, EventArgs e)
        {
            /* ------ DEL caohh 2011/08/11 ------->>>>>
            // �����0�͈󎚂��Ȃ�
            if (this.Tax.Text == "0")
            {
                this.Tax.Visible = false;
            }
            else
            {
                this.Tax.Visible = true;
            }
            ------ DEL caohh 2011/08/11 -------<<<<<*/
        }

        // --- ADD 2008/10/31 ---------------------------------------------------------<<<<<
    }
}
