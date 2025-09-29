using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

using DataDynamics.ActiveReports;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
    /// �����m�F�\(����ʏW�v)����t�H�[���N���X
	/// </summary>
	/// <remarks>
    /// <br>Note		: �����m�F�\(����ʏW�v)�̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer	: 980035  ���� ��`</br>
	/// <br>Date		: 2007.11.14</br>
    /// <br>UpdateNote  : 2008.01.30 980035 ���� ��`</br>
    /// <br>                DC.NS�Ή��i�s��C���j</br>
    /// <br>UpdateNote  : 2008.03.03 980035 ���� ��`</br>
    /// <br>                �s��C��</br>
    /// <br>UpdateNote  : 2008.07.09 30413 ����</br>
    /// <br>                PM.NS�Ή�</br>
    /// <br>UpdateNote  : 2008/10/09 30462 �s�V �m���@�o�O�C��</br>
    /// <br>                [6362]���Ӑ�̃t�H�[�}�b�g��ǉ�</br>
    /// <br>UpdateNote  : 2009/01/07 30413 ����</br>
    /// <br>                ��QID:9653�Ή�</br>
    /// <br>Update Note : 2009/03/26 30452 ��� �r��</br>
    /// <br>             �E��Q�Ή�11523,11661</br>
    /// <br>Update Note : 2009/11/20 30517 �Ė� �x��</br>
    /// <br>             �E1�s�\���Ή�</br>
    /// <br>Update Note : 2010/05/26 22018 ��� ���b</br>
    /// <br>             �E�����l�����ڂ̍폜�ɂ��index�̈������s���ɂȂ��Ă���׏C���B</br>
    /// <br>Update Note : 2011/10/27 ������</br>
    /// <br>             �@��Q�� #26259�Ή�</br>
    /// <br>Update Note : 2012/12/14 ���j��</br>
    ///	<br>			  2013/01/16�z�M���ARedmine#33271 �󎚐���̋敪�̒ǉ�</br> 
    /// <br>UpdateNote  : 2013/01/05 zhuhh</br>
    /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
    /// <br>            : redmine #33796 ���Ő����ǉ�����</br>
    /// </remarks>
	public class MAHNB02012P_04A4C : DataDynamics.ActiveReports.ActiveReport3,IPrintActiveReportTypeList,IPrintActiveReportTypeCommon
	{
		#region �� Constructor
		/// <summary>
        /// �����m�F�\(����ʏW�v)�t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note		: �����m�F�\(����ʏW�v)�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer	: 980035  ���� ��`</br>
        /// <br>Date		: 2007.11.14</br>
        /// </remarks>
		public MAHNB02012P_04A4C()
		{
			InitializeComponent();
		}
		#endregion �� Constructor

		#region �� Private Member
		private string				 _pageHeaderSortOderTitle;		// �\�[�g��
		private int					 _extraCondHeadOutDiv;			// ���o�����w�b�_�o�͋敪
		private StringCollection	 _extraConditions;				// ���o����
		private int					 _pageFooterOutCode;			// �t�b�^�[�o�͋敪
		private StringCollection	 _pageFooters;					// �t�b�^�[���b�Z�[�W
		private	SFCMN06002C			 _printInfo;					// ������N���X
		private string				 _pageHeaderSubtitle;			// �t�H�[���T�u�^�C�g��
		private ArrayList			 _otherDataList;				// ���̑��f�[�^
        private ArrayList            _depositKindCd;                // ��������v���p�e�B
        private SortedList           _depositKindNm;                // ��������v���p�e�B

		private	DepositMainCndtn	 _depositMainCndtn;				// ���o�����N���X

		// ���̑��f�[�^�i�[����
        // 2008.07.23 30413 ���� ���v�^�C�g���ƒS���҃^�C�g�����폜 >>>>>>START
        //private string _sumTitle;						// ���v�^�C�g��
        //private string				 _agentKindTitle;				// �S���҃^�C�g��
        // 2008.07.23 30413 ���� ���v�^�C�g���ƒS���҃^�C�g�����폜 <<<<<<END
        
        private string _detailAddupSecNameTtl;		// ���׋��_���̃^�C�g��

        // 2008.07.11 30413 ���� ���햼�̂��擾 >>>>>>START
        private Dictionary<int, string> _dicKindName;
        // 2008.07.11 30413 ���� ���햼�̂��擾 <<<<<<END

		private int					 _printCount;					// �y�[�W���J�E���g�p
	
		// �w�b�_�[�T�u���|�[�g�쐬
		ListCommon_ExtraHeader _rptExtraHeader  = null;
		// �t�b�^�[���|�[�g�쐬
        ListCommon_PageFooter _rptPageFooter = null;
        private TextBox tb_AddUpSecCode;
        private TextBox Deposit;
        private TextBox CustomerCode;
        private TextBox CustomerName;
        private TextBox DepositKind01;
        private TextBox DepositKind02;
        private TextBox DepositKind04;
        private TextBox DepositKind03;
        private TextBox DepositKind05;
        private TextBox DepositKind09;
        private TextBox DepositKind06;
        private TextBox DepositKind07;
        private TextBox DepositKind08;
        private Label Label104;
        private Label Label105;
        private Label DepositKind01_Title;
        private Label DepositKind02_Title;
        private Label DepositKind04_Title;
        private Label DepositKind03_Title;
        private Label DepositKind05_Title;
        private Label DepositKind09_Title;
        private Label DepositKind06_Title;
        private Label DepositKind07_Title;
        private Label DepositKind08_Title;
        private Label DepositKind10_Title;
        private TextBox Total_DepositKind01;
        private TextBox Total_Deposit;
        private TextBox Total_DepositKind02;
        private TextBox Total_DepositKind04;
        private TextBox Total_DepositKind03;
        private TextBox Total_DepositKind05;
        private TextBox Total_DepositKind09;
        private TextBox Total_DepositKind06;
        private Label Label109;
        private TextBox Total_DepositKind07;
        private TextBox Total_DepositKind08;
        private TextBox Section_DepositKind01;
        private TextBox Section_Deposit;
        private TextBox Section_DepositKind02;
        private TextBox Section_DepositKind04;
        private TextBox Section_DepositKind03;
        private TextBox Section_DepositKind05;
        private TextBox Section_DepositKind09;
        private TextBox Section_DepositKind06;
        private TextBox MONEYKINDNAME13;
        private TextBox Section_DepositKind07;
        private TextBox Section_DepositKind08;
        private Label label15;
        private Line TitleHeader_Line1;
        private Label DepositKind11_Title;
        private TextBox DepositKind11;
        private TextBox Total_DepositKind11;
        private TextBox Section_DepositKind11;
        private Line line2;

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
		#endregion

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
				this._printInfo = value;
				this._depositMainCndtn = (DepositMainCndtn)this._printInfo.jyoken;
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
					if ( this._otherDataList.Count > 0 )
					{
                        // 2008.07.23 30413 ���� ���̑��f�[�^�̎擾��ύX >>>>>>START
                        //this._sumTitle = this._otherDataList[0].ToString();
                        //this._agentKindTitle		= this._otherDataList[1].ToString();
                        //this._detailAddupSecNameTtl = this._otherDataList[2].ToString();
                        //this._depositKindCd         = (ArrayList)this._otherDataList[3];
                        //this._depositKindNm         = (SortedList)this._otherDataList[4];
                        this._detailAddupSecNameTtl = this._otherDataList[0].ToString();
                        this._depositKindCd = (ArrayList)this._otherDataList[1];
                        this._depositKindNm = (SortedList)this._otherDataList[2];

                        this._dicKindName = (Dictionary<int, string>)this._otherDataList[3];        // ���햼��
                        // 2008.07.23 30413 ���� ���̑��f�[�^�̎擾��ύX <<<<<<END
					}
				}
			}
		}

		/// <summary>
		/// ���[�T�u�^�C�g��
		/// </summary>
		public string PageHeaderSubtitle
		{
			set{ this._pageHeaderSubtitle = value;}
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
				// TODO:  MAHNB02012P_03A4C.WatermarkMode getter ������ǉ����܂��B
				return 0;
			}
			set
			{
				// TODO:  MAHNB02012P_03A4C.WatermarkMode setter ������ǉ����܂��B
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
		/// <br>Note        : ���|�[�g�̗v�f�iHeader�AFooter�AText�j�̏o�͐ݒ�</br>
        /// <br>Programmer	: 980035  ���� ��`</br>
        /// <br>Date		: 2007.11.14</br>
        /// <br>UpdateNote  : 2013/01/05 zhuhh</br>
        /// <br>�Ǘ��ԍ�    : 10806793-00 2013/03/13�z�M��</br>
        /// <br>            : redmine #33796 ���Ő����ǉ�����</br>
        /// </remarks>
		private void SetOfReportMembersOutput()
		{
			// �󎚐ݒ� --------------------------------------------------------------------------------------
            // --- DEL 2009/03/27 -------------------------------->>>>>
            //// ���_�v���o�͂��邩���Ȃ�����I������
            //// ���_�L���𔻒f
            //if ( this._depositMainCndtn.IsOptSection )
            //{
            //    // �S�Ђ��`�F�b�N����Ă��鎞�A�܂��͋��_�I���̃`�F�b�N�����u1�v�ȉ��̎��́A���_�v���R�[�h�͏o�͂��Ȃ�
            //    //// 2008.01.30 �C�� >>>>>>>>>>>>>>>>>>>>
            //    ////if ( ( this._depositMainCndtn.DepositAddupSecCodeList.Length < 2 ) || 
            //    ////    this._depositMainCndtn.IsSelectAllSection )
            //    //if ((this._depositMainCndtn.DepositAddupSecCodeList.Length < 2) &&
            //    //    (this._depositMainCndtn.IsSelectAllSection == false))
            //    //// 2008.01.30 �C�� <<<<<<<<<<<<<<<<<<<<
            //    //{
            //    // 2008.07.23 30413 ���� ���_���̉��y�[�W���s�����߃R�����g�� >>>>>>START
            //        //SectionHeader.DataField = "";
            //        //SectionHeader.Visible = false;
            //        //SectionFooter.Visible = false;
            //    // 2008.07.23 30413 ���� ���_���̉��y�[�W���s�����߃R�����g�� <<<<<<END
            //    //}
            //    //else
            //    //{
            //    //    SectionHeader.DataField = MAHNB02014EA.ct_Col_AddUpSecCode;
            //    //    SectionHeader.Visible = true;
            //    //    SectionFooter.Visible = true;
            //    //}

            //    //// �S�Ђ��`�F�b�N����Ă��Ă���Ƃ��́A���_���́i����)�͏o�͂���
            //    //if ( this._depositMainCndtn.IsSelectAllSection )
            //    //{
            //    //    tb_AddUpSecName_Detail.Visible = true;
            //    //}
            //    //else
            //    //{
            //    //    tb_AddUpSecName_Detail.Visible = false;
            //    //}

            //    // 2008.07.23 30413 ���� ���_���̉��y�[�W�������ǉ� >>>>>>START
            //    if ((this._depositMainCndtn.DepositAddupSecCodeList.Length < 2) &&
            //            (this._depositMainCndtn.IsSelectAllSection == false))
            //    {
            //        SectionHeader.DataField = "";
            //        SectionHeader.Visible = false;
            //        SectionFooter.Visible = false;
            //    }
            //    else
            //    {
            //        SectionHeader.DataField = MAHNB02014EA.ct_Col_AddUpSecCode;
            //        SectionHeader.Visible = true;
            //        SectionFooter.Visible = true;
            //    }
            //    // 2008.07.23 30413 ���� ���_���̉��y�[�W�������ǉ� <<<<<<END
            //}
            //else
            //{
            //    // ���_��
            //    SectionHeader.DataField = "";
            //    SectionHeader.Visible = false;
            //    SectionFooter.Visible = false;
            //    //tb_AddUpSecName_Title.Visible = false;
            //    //tb_AddUpSecName_Detail.Visible = false;
            //}
            // --- DEL 2009/03/27 --------------------------------<<<<<

            tb_ReportTitle.Text			= this._pageHeaderSubtitle;				// �T�u�^�C�g��
			tb_SortOrderName.Text		= this._pageHeaderSortOderTitle;		// �\�[�g����
			//tb_EmployeeTitle.Text		= this._agentKindTitle;					// �S���҃^�C�g��
			//tb_AddUpSecName_Title.Text	= this._detailAddupSecNameTtl;			// ���׋��_���̃^�C�g��

            // 2008.07.18 30413 ���� ���햼�̂̃^�C�g���Ɩ���/���v�̈󎚐ݒ���폜 >>>>>>START
            //string field = "DepositKind_No";
            //int cnt = 0;
            //for (int ix = 0; ix < 9; ix++)
            //{
            //    if (ix < this._depositKindCd.Count)
            //    {
            //        if ((int)this._depositKindCd[ix] != -1)
            //        {
            //            string title = this._depositKindNm[this._depositKindCd[ix]].ToString();
            //            cnt++;
            //            switch (cnt)
            //            {
            //                case 1: { this.DepositKind01_Title.Text = title; this.DepositKind01.DataField = field + (ix + 1).ToString(); this.Section_DepositKind01.DataField = field + (ix + 1).ToString(); this.Total_DepositKind01.DataField = field + (ix + 1).ToString(); break; }
            //                case 2: { this.DepositKind02_Title.Text = title; this.DepositKind02.DataField = field + (ix + 1).ToString(); this.Section_DepositKind02.DataField = field + (ix + 1).ToString(); this.Total_DepositKind02.DataField = field + (ix + 1).ToString(); break; }
            //                case 3: { this.DepositKind03_Title.Text = title; this.DepositKind03.DataField = field + (ix + 1).ToString(); this.Section_DepositKind03.DataField = field + (ix + 1).ToString(); this.Total_DepositKind03.DataField = field + (ix + 1).ToString(); break; }
            //                case 4: { this.DepositKind04_Title.Text = title; this.DepositKind04.DataField = field + (ix + 1).ToString(); this.Section_DepositKind04.DataField = field + (ix + 1).ToString(); this.Total_DepositKind04.DataField = field + (ix + 1).ToString(); break; }
            //                case 5: { this.DepositKind05_Title.Text = title; this.DepositKind05.DataField = field + (ix + 1).ToString(); this.Section_DepositKind05.DataField = field + (ix + 1).ToString(); this.Total_DepositKind05.DataField = field + (ix + 1).ToString(); break; }
            //                case 6: { this.DepositKind06_Title.Text = title; this.DepositKind06.DataField = field + (ix + 1).ToString(); this.Section_DepositKind06.DataField = field + (ix + 1).ToString(); this.Total_DepositKind06.DataField = field + (ix + 1).ToString(); break; }
            //                case 7: { this.DepositKind07_Title.Text = title; this.DepositKind07.DataField = field + (ix + 1).ToString(); this.Section_DepositKind07.DataField = field + (ix + 1).ToString(); this.Total_DepositKind07.DataField = field + (ix + 1).ToString(); break; }
            //                case 8: { this.DepositKind08_Title.Text = title; this.DepositKind08.DataField = field + (ix + 1).ToString(); this.Section_DepositKind08.DataField = field + (ix + 1).ToString(); this.Total_DepositKind08.DataField = field + (ix + 1).ToString(); break; }
            //                case 9: { this.DepositKind09_Title.Text = title; this.DepositKind09.DataField = field + (ix + 1).ToString(); this.Section_DepositKind09.DataField = field + (ix + 1).ToString(); this.Total_DepositKind09.DataField = field + (ix + 1).ToString(); break; }
            //            }
            //        }
            //    }
            //}

            //// 2008.03.03 �C�� >>>>>>>>>>>>>>>>>>>>
            ////if (cnt < this._depositKindCd.Count)
            //if (cnt <= this._depositKindCd.Count)
            //// 2008.03.03 �C�� <<<<<<<<<<<<<<<<<<<<
            //{
            //    // 2008.03.03 �C�� >>>>>>>>>>>>>>>>>>>>
            //    //for (int ix = cnt + 1; ix <= this._depositKindCd.Count; ix++)
            //    for (int ix = cnt + 1; ix <= this._depositKindCd.Count + 1; ix++)
            //    // 2008.03.03 �C�� <<<<<<<<<<<<<<<<<<<<
            //    {
            //        switch (ix)
            //        {
            //            case 1:
            //                {
            //                    this.DepositKind01_Title.Text = "";
            //                    this.DepositKind01_Title.Visible = false;
            //                    this.DepositKind01.DataField = "";
            //                    this.DepositKind01.Visible = false;
            //                    this.Section_DepositKind01.DataField = "";
            //                    this.Section_DepositKind01.Visible = false;
            //                    this.Total_DepositKind01.DataField = "";
            //                    this.Total_DepositKind01.Visible = false;
            //                    break;
            //                }
            //            case 2:
            //                {
            //                    this.DepositKind02_Title.Text = "";
            //                    this.DepositKind02_Title.Visible = false;
            //                    this.DepositKind02.DataField = "";
            //                    this.DepositKind02.Visible = false;
            //                    this.Section_DepositKind02.DataField = "";
            //                    this.Section_DepositKind02.Visible = false;
            //                    this.Total_DepositKind02.DataField = "";
            //                    this.Total_DepositKind02.Visible = false;
            //                    break;
            //                }
            //            case 3:
            //                {
            //                    this.DepositKind03_Title.Text = "";
            //                    this.DepositKind03_Title.Visible = false;
            //                    this.DepositKind03.DataField = "";
            //                    this.DepositKind03.Visible = false;
            //                    this.Section_DepositKind03.DataField = "";
            //                    this.Section_DepositKind03.Visible = false;
            //                    this.Total_DepositKind03.DataField = "";
            //                    this.Total_DepositKind03.Visible = false;
            //                    break;
            //                }
            //            case 4:
            //                {
            //                    this.DepositKind04_Title.Text = "";
            //                    this.DepositKind04_Title.Visible = false;
            //                    this.DepositKind04.DataField = "";
            //                    this.DepositKind04.Visible = false;
            //                    this.Section_DepositKind04.DataField = "";
            //                    this.Section_DepositKind04.Visible = false;
            //                    this.Total_DepositKind04.DataField = "";
            //                    this.Total_DepositKind04.Visible = false;
            //                    break;
            //                }
            //            case 5:
            //                {
            //                    this.DepositKind05_Title.Text = "";
            //                    this.DepositKind05_Title.Visible = false;
            //                    this.DepositKind05.DataField = "";
            //                    this.DepositKind05.Visible = false;
            //                    this.Section_DepositKind05.DataField = "";
            //                    this.Section_DepositKind05.Visible = false;
            //                    this.Total_DepositKind05.DataField = "";
            //                    this.Total_DepositKind05.Visible = false;
            //                    break;
            //                }
            //            case 6:
            //                {
            //                    this.DepositKind06_Title.Text = "";
            //                    this.DepositKind06_Title.Visible = false;
            //                    this.DepositKind06.DataField = "";
            //                    this.DepositKind06.Visible = false;
            //                    this.Section_DepositKind06.DataField = "";
            //                    this.Section_DepositKind06.Visible = false;
            //                    this.Total_DepositKind06.DataField = "";
            //                    this.Total_DepositKind06.Visible = false;
            //                    break;
            //                }
            //            case 7:
            //                {
            //                    this.DepositKind07_Title.Text = "";
            //                    this.DepositKind07_Title.Visible = false;
            //                    this.DepositKind07.DataField = "";
            //                    this.DepositKind07.Visible = false;
            //                    this.Section_DepositKind07.DataField = "";
            //                    this.Section_DepositKind07.Visible = false;
            //                    this.Total_DepositKind07.DataField = "";
            //                    this.Total_DepositKind07.Visible = false;
            //                    break;
            //                }
            //            case 8:
            //                {
            //                    this.DepositKind08_Title.Text = "";
            //                    this.DepositKind08_Title.Visible = false;
            //                    this.DepositKind08.DataField = "";
            //                    this.DepositKind08.Visible = false;
            //                    this.Section_DepositKind08.DataField = "";
            //                    this.Section_DepositKind08.Visible = false;
            //                    this.Total_DepositKind08.DataField = "";
            //                    this.Total_DepositKind08.Visible = false;
            //                    break;
            //                }
            //            case 9:
            //                {
            //                    this.DepositKind09_Title.Text = "";
            //                    this.DepositKind09_Title.Visible = false;
            //                    this.DepositKind09.DataField = "";
            //                    this.DepositKind09.Visible = false;
            //                    this.Section_DepositKind09.DataField = "";
            //                    this.Section_DepositKind09.Visible = false;
            //                    this.Total_DepositKind09.DataField = "";
            //                    this.Total_DepositKind09.Visible = false;
            //                    break;
            //                }
            //        }
            //    }
            //}
            // 2008.07.18 30413 ���� ���햼�̂̃^�C�g���Ɩ���/���v�̈󎚐ݒ���폜 >>>>>>START
            // --- ADD ���j�� 2012/12/14 for Redmine#33271---------->>>>>
            //�r���󎚋敪
            if (this._depositMainCndtn.LineMaSqOfChDiv == 0)
            {
                //�r���󎚂���
                this.Line37.Visible = true;
                this.Line43.Visible = true;
                this.Line45.Visible = true;
                this.TitleHeader_Line1.Visible = true;
                this.line2.Visible = false;
            }
            else
            {
                //�r���󎚂��Ȃ�
                this.Line37.Visible = false;
                this.Line43.Visible = false;
                this.Line45.Visible = false;
                this.TitleHeader_Line1.Visible = false;
                this.line2.Visible = true;
            }
            // --- ADD ���j�� 2012/11/14 for Redmine#33271----------<<<<<

            // ----- ADD zhuhh 2013/01/05 for Redmine #33796 ----->>>>>
            if (this._depositMainCndtn.NewPageType == 0)
            {
                //���_
                SectionHeader.NewPage = NewPage.Before;
                SectionHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
            }
            else
            {
                //���ł��Ȃ�
                SectionHeader.NewPage = NewPage.None;
                SectionHeader.RepeatStyle = RepeatStyle.None;
            }
            // ----- ADD zhuhh 2013/01/05 for Redmine #33796 -----<<<<<


        }
		#endregion
		#endregion

		#region �� Control Event
		#region �� MAHNB02012P_03A4C_ReportStart Event
		/// <summary>
		/// MAHNB02012P_03A4C_ReportStart Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="eArgs">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note        : ���|�[�g�̐ݒ������C�x���g�ł��B</br>
        /// <br>Programmer	: 980035  ���� ��`</br>
        /// <br>Date		: 2007.11.14</br>
        /// </remarks>
		private void MAHNB02012P_03A4C_ReportStart(object sender, System.EventArgs eArgs)
		{
			// ���|�[�g�v�f�o�͐ݒ�
			SetOfReportMembersOutput();

            // ����R�[�h�̈���ݒ�
            SettingKindName();
		}
		#endregion �� MAHNB02012P_03A4C_ReportStart Event

		#region �� PageHeader_Format Event
		/// <summary>
		/// PageHeader_Format Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="eArgs">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �y�[�W�w�b�_�[�O���[�v�̏������C�x���g�ł��B</br>
        /// <br>Programmer	: 980035  ���� ��`</br>
        /// <br>Date		: 2007.11.14</br>
        /// </remarks>
		private void PageHeader_Format(object sender, System.EventArgs eArgs)
		{
			// �쐬���t
			this.tb_PrintDate.Text = TDateTime.DateTimeToString( DepositMainCndtn.ct_DateFomat, DateTime.Now );
			// �쐬����
			this.tb_PrintTime.Text   = DateTime.Now.ToString("HH:mm");
		}
		#endregion �� PageHeader_Format Event

		#region �� ExtraHeader_Format Event
		/// <summary>
		/// ExtraHeader_Format Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="eArgs">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: ExtraHeader�O���[�v�̏������C�x���g�ł��B</br>
        /// <br>Programmer	: 980035  ���� ��`</br>
        /// <br>Date		: 2007.11.14</br>
        /// </remarks>
		private void ExtraHeader_Format(object sender, System.EventArgs eArgs)
		{
			// ���o�����ݒ�
            // --- DEL 2009/03/27 -------------------------------->>>>>
            //// �w�b�_�o�͐���
            //if (this._extraCondHeadOutDiv == 0)
            //{
            //    // ���y�[�W�o��
            //    this.ExtraHeader.RepeatStyle = RepeatStyle.OnPageIncludeNoDetail;
            //} 
            //else 
            //{
            //    // �擪�y�[�W�̂�
            //    this.ExtraHeader.RepeatStyle = RepeatStyle.None;
            //}
            // --- DEL 2009/03/27 --------------------------------<<<<<
			
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

			// ���_�I�v�V�����L������
            // 2008.10.10 30413 ���� �����v�㋒�_���狒�_�ɕύX >>>>>>START
            //if (this._depositMainCndtn.IsOptSection)
            //{
            //    // 2008.01.30 �C�� >>>>>>>>>>>>>>>>>>>>
            //    //this._rptExtraHeader.SectionCondition.Text = "�����v�㋒�_�F" + this.tb_AddUpSecName.Text;
            //    if (this.tb_AddUpSecCode.Text.Trim() == string.Empty)
            //    {
            //        this._rptExtraHeader.SectionCondition.Text = "";
            //    }
            //    else
            //    {
            //        this._rptExtraHeader.SectionCondition.Text = "�����v�㋒�_�F" + this.tb_AddUpSecCode.Value + " " + this.tb_AddUpSecName.Text;
            //    }
            //    // 2008.01.30 �C�� <<<<<<<<<<<<<<<<<<<<
            //} 
            //else 
            //{
            //    this._rptExtraHeader.SectionCondition.Text = "";
            //}
            //this._rptExtraHeader.SectionCondition.Text = "���_�F" + this.tb_AddUpSecCode.Value + " " + this.tb_AddUpSecName.Text; // DEL 2009/03/27
            // 2008.10.10 30413 ���� �����v�㋒�_���狒�_�ɕύX <<<<<<END
            
			// ���o�����󎚍��ڐݒ�
			this._rptExtraHeader.ExtraConditions = this._extraConditions;
			
			this.Header_SubReport.Report = this._rptExtraHeader;
		}
		#endregion �� ExtraHeader_Format Event

		#region �� Detail_BeforePrint Event
		/// <summary>
		/// Detail_BeforePrint Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="eArgs">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note        : Detail�Z�N�V�����̈���O�ɔ�������C�x���g�ł��B</br>
        /// <br>Programmer  : 980035  ���� ��`</br>
        /// <br>Date	    : 2007.11.14</br>
        /// </remarks>
		private void Detail_BeforePrint(object sender, System.EventArgs eArgs)
		{
			// Wordrap�v���p�e�B�ŕ��������r���[�ȂƂ���ŋ�؂��Ȃ��悤�ɂ��邽�߂̑Ή�
			PrintCommonLibrary.ConvertReportString(this.Detail);

		}
		#endregion �� Detail_BeforePrint Event

		#region �� Detail_AfterPrint Event
		/// <summary>
		/// Detail_AfterPrint Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="eArgs">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note        : �Z�N�V�������y�[�W�ɕ`�悳�ꂽ��ɔ������܂��B</br>
        /// <br>Programmer	: 980035  ���� ��`</br>
        /// <br>Date		: 2007.11.14</br>
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
		#endregion �� Detail_AfterPrint Event

		#region �� PageFooter_Format Event
		/// <summary>
		/// PageFooter_Format Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="eArgs">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note        : PageFooter_Format�O���[�v�̏������C�x���g�ł��B</br>
        /// <br>Programmer	: 980035  ���� ��`</br>
        /// <br>Date		: 2007.11.14</br>
        /// </remarks>
		private void PageFooter_Format(object sender, System.EventArgs eArgs)
		{
            // �t�b�^�[�o�͂���H
            if (this._pageFooterOutCode == 0)
            {
                // �C���X�^���X���쐬����Ă��Ȃ���΍쐬
                if ( _rptPageFooter == null)
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
		#endregion �� PageFooter_Format Event

		#endregion �� Control Event

		#region ActiveReports Designer generated code
		private DataDynamics.ActiveReports.PageHeader PageHeader;
		private DataDynamics.ActiveReports.Label tb_ReportTitle;
		private DataDynamics.ActiveReports.Line Line1;
		private DataDynamics.ActiveReports.TextBox tb_SortOrderName;
		private DataDynamics.ActiveReports.Label Label1;
		private DataDynamics.ActiveReports.TextBox tb_PrintDate;
		private DataDynamics.ActiveReports.Label Label4;
		private DataDynamics.ActiveReports.TextBox tb_PrintPage;
		private DataDynamics.ActiveReports.TextBox tb_PrintTime;
		private DataDynamics.ActiveReports.GroupHeader ExtraHeader;
        private DataDynamics.ActiveReports.SubReport Header_SubReport;
        private DataDynamics.ActiveReports.GroupHeader TitleHeader;
        private DataDynamics.ActiveReports.Line Line42;
		private DataDynamics.ActiveReports.GroupHeader GrandTotalHeader;
		private DataDynamics.ActiveReports.GroupHeader SectionHeader;
        private DataDynamics.ActiveReports.TextBox tb_AddUpSecName;
        private DataDynamics.ActiveReports.Detail Detail;
        private DataDynamics.ActiveReports.Line Line37;
		private DataDynamics.ActiveReports.GroupFooter SectionFooter;
        private DataDynamics.ActiveReports.Line Line45;
        private DataDynamics.ActiveReports.GroupFooter GrandTotalFooter;
        private DataDynamics.ActiveReports.Line Line43;
		private DataDynamics.ActiveReports.GroupFooter TitleFooter;
		private DataDynamics.ActiveReports.Line Line41;
		private DataDynamics.ActiveReports.GroupFooter ExtraFooter;
		private DataDynamics.ActiveReports.PageFooter PageFooter;
		private DataDynamics.ActiveReports.SubReport Footer_SubReport;
		public void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAHNB02012P_04A4C));
            this.Detail = new DataDynamics.ActiveReports.Detail();
            this.Deposit = new DataDynamics.ActiveReports.TextBox();
            this.CustomerCode = new DataDynamics.ActiveReports.TextBox();
            this.CustomerName = new DataDynamics.ActiveReports.TextBox();
            this.DepositKind01 = new DataDynamics.ActiveReports.TextBox();
            this.DepositKind02 = new DataDynamics.ActiveReports.TextBox();
            this.DepositKind04 = new DataDynamics.ActiveReports.TextBox();
            this.DepositKind03 = new DataDynamics.ActiveReports.TextBox();
            this.DepositKind05 = new DataDynamics.ActiveReports.TextBox();
            this.DepositKind09 = new DataDynamics.ActiveReports.TextBox();
            this.DepositKind06 = new DataDynamics.ActiveReports.TextBox();
            this.DepositKind07 = new DataDynamics.ActiveReports.TextBox();
            this.DepositKind08 = new DataDynamics.ActiveReports.TextBox();
            this.Line37 = new DataDynamics.ActiveReports.Line();
            this.PageHeader = new DataDynamics.ActiveReports.PageHeader();
            this.tb_ReportTitle = new DataDynamics.ActiveReports.Label();
            this.Line1 = new DataDynamics.ActiveReports.Line();
            this.tb_SortOrderName = new DataDynamics.ActiveReports.TextBox();
            this.Label1 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintDate = new DataDynamics.ActiveReports.TextBox();
            this.Label4 = new DataDynamics.ActiveReports.Label();
            this.tb_PrintPage = new DataDynamics.ActiveReports.TextBox();
            this.tb_PrintTime = new DataDynamics.ActiveReports.TextBox();
            this.PageFooter = new DataDynamics.ActiveReports.PageFooter();
            this.Footer_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Header_SubReport = new DataDynamics.ActiveReports.SubReport();
            this.ExtraFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.TitleHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.Label104 = new DataDynamics.ActiveReports.Label();
            this.Label105 = new DataDynamics.ActiveReports.Label();
            this.DepositKind01_Title = new DataDynamics.ActiveReports.Label();
            this.DepositKind02_Title = new DataDynamics.ActiveReports.Label();
            this.DepositKind04_Title = new DataDynamics.ActiveReports.Label();
            this.DepositKind03_Title = new DataDynamics.ActiveReports.Label();
            this.DepositKind05_Title = new DataDynamics.ActiveReports.Label();
            this.DepositKind06_Title = new DataDynamics.ActiveReports.Label();
            this.DepositKind07_Title = new DataDynamics.ActiveReports.Label();
            this.DepositKind08_Title = new DataDynamics.ActiveReports.Label();
            this.DepositKind10_Title = new DataDynamics.ActiveReports.Label();
            this.Line42 = new DataDynamics.ActiveReports.Line();
            this.DepositKind09_Title = new DataDynamics.ActiveReports.Label();
            this.line2 = new DataDynamics.ActiveReports.Line();
            this.TitleFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Line41 = new DataDynamics.ActiveReports.Line();
            this.GrandTotalHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.GrandTotalFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Total_DepositKind01 = new DataDynamics.ActiveReports.TextBox();
            this.Total_Deposit = new DataDynamics.ActiveReports.TextBox();
            this.Total_DepositKind02 = new DataDynamics.ActiveReports.TextBox();
            this.Total_DepositKind04 = new DataDynamics.ActiveReports.TextBox();
            this.Total_DepositKind03 = new DataDynamics.ActiveReports.TextBox();
            this.Total_DepositKind05 = new DataDynamics.ActiveReports.TextBox();
            this.Total_DepositKind09 = new DataDynamics.ActiveReports.TextBox();
            this.Total_DepositKind06 = new DataDynamics.ActiveReports.TextBox();
            this.Label109 = new DataDynamics.ActiveReports.Label();
            this.Total_DepositKind07 = new DataDynamics.ActiveReports.TextBox();
            this.Total_DepositKind08 = new DataDynamics.ActiveReports.TextBox();
            this.Line43 = new DataDynamics.ActiveReports.Line();
            this.SectionHeader = new DataDynamics.ActiveReports.GroupHeader();
            this.tb_AddUpSecName = new DataDynamics.ActiveReports.TextBox();
            this.tb_AddUpSecCode = new DataDynamics.ActiveReports.TextBox();
            this.label15 = new DataDynamics.ActiveReports.Label();
            this.TitleHeader_Line1 = new DataDynamics.ActiveReports.Line();
            this.SectionFooter = new DataDynamics.ActiveReports.GroupFooter();
            this.Section_DepositKind01 = new DataDynamics.ActiveReports.TextBox();
            this.Section_Deposit = new DataDynamics.ActiveReports.TextBox();
            this.Section_DepositKind02 = new DataDynamics.ActiveReports.TextBox();
            this.Section_DepositKind04 = new DataDynamics.ActiveReports.TextBox();
            this.Section_DepositKind03 = new DataDynamics.ActiveReports.TextBox();
            this.Section_DepositKind05 = new DataDynamics.ActiveReports.TextBox();
            this.Section_DepositKind09 = new DataDynamics.ActiveReports.TextBox();
            this.Section_DepositKind06 = new DataDynamics.ActiveReports.TextBox();
            this.MONEYKINDNAME13 = new DataDynamics.ActiveReports.TextBox();
            this.Section_DepositKind07 = new DataDynamics.ActiveReports.TextBox();
            this.Section_DepositKind08 = new DataDynamics.ActiveReports.TextBox();
            this.Line45 = new DataDynamics.ActiveReports.Line();
            this.DepositKind11_Title = new DataDynamics.ActiveReports.Label();
            this.DepositKind11 = new DataDynamics.ActiveReports.TextBox();
            this.Section_DepositKind11 = new DataDynamics.ActiveReports.TextBox();
            this.Total_DepositKind11 = new DataDynamics.ActiveReports.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Deposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SortOrderName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label104)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label105)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind01_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind02_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind04_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind03_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind05_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind06_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind07_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind08_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind10_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind09_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_Deposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_AddUpSecName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_AddUpSecCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_Deposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MONEYKINDNAME13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind11_Title)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.CanShrink = true;
            this.Detail.ColumnSpacing = 0F;
            this.Detail.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Deposit,
            this.CustomerCode,
            this.CustomerName,
            this.DepositKind01,
            this.DepositKind02,
            this.DepositKind04,
            this.DepositKind03,
            this.DepositKind05,
            this.DepositKind09,
            this.DepositKind06,
            this.DepositKind07,
            this.DepositKind08,
            this.Line37,
            this.DepositKind11});
            this.Detail.Height = 0.25F;
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
            this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
            // 
            // Deposit
            // 
            this.Deposit.Border.BottomColor = System.Drawing.Color.Black;
            this.Deposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Deposit.Border.LeftColor = System.Drawing.Color.Black;
            this.Deposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Deposit.Border.RightColor = System.Drawing.Color.Black;
            this.Deposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Deposit.Border.TopColor = System.Drawing.Color.Black;
            this.Deposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Deposit.DataField = "DepositTotal";
            this.Deposit.Height = 0.125F;
            this.Deposit.Left = 2.875F;
            this.Deposit.MultiLine = false;
            this.Deposit.Name = "Deposit";
            this.Deposit.OutputFormat = resources.GetString("Deposit.OutputFormat");
            this.Deposit.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: �l�r �S�V�b�N; verti" +
                "cal-align: top; ";
            this.Deposit.Text = "1,234,567,890";
            this.Deposit.Top = 0.0625F;
            this.Deposit.Width = 0.71F;
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
            this.CustomerCode.DataField = "ClaimCode";
            this.CustomerCode.Height = 0.125F;
            this.CustomerCode.Left = 0F;
            this.CustomerCode.MultiLine = false;
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.OutputFormat = resources.GetString("CustomerCode.OutputFormat");
            this.CustomerCode.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: �l�r �S�V�b�N; vertic" +
                "al-align: top; ";
            this.CustomerCode.Text = "123456789";
            this.CustomerCode.Top = 0.0625F;
            this.CustomerCode.Width = 0.5625F;
            // 
            // CustomerName
            // 
            this.CustomerName.Border.BottomColor = System.Drawing.Color.Black;
            this.CustomerName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerName.Border.LeftColor = System.Drawing.Color.Black;
            this.CustomerName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerName.Border.RightColor = System.Drawing.Color.Black;
            this.CustomerName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerName.Border.TopColor = System.Drawing.Color.Black;
            this.CustomerName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.CustomerName.DataField = "ClaimSnm";
            this.CustomerName.Height = 0.125F;
            this.CustomerName.Left = 0.625F;
            this.CustomerName.MultiLine = false;
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.OutputFormat = resources.GetString("CustomerName.OutputFormat");
            this.CustomerName.Style = "ddo-char-set: 128; text-align: left; font-size: 7pt; font-family: �l�r ����; vertical" +
                "-align: top; ";
            this.CustomerName.Text = "12345678901234567890";
            this.CustomerName.Top = 0.0625F;
            this.CustomerName.Width = 1.75F;
            // 
            // DepositKind01
            // 
            this.DepositKind01.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind01.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind01.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind01.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind01.Height = 0.125F;
            this.DepositKind01.Left = 3.585F;
            this.DepositKind01.MultiLine = false;
            this.DepositKind01.Name = "DepositKind01";
            this.DepositKind01.OutputFormat = resources.GetString("DepositKind01.OutputFormat");
            this.DepositKind01.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: �l�r �S�V�b�N; verti" +
                "cal-align: top; ";
            this.DepositKind01.Text = "1,234,567,890";
            this.DepositKind01.Top = 0.063F;
            this.DepositKind01.Width = 0.71F;
            // 
            // DepositKind02
            // 
            this.DepositKind02.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind02.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind02.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind02.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind02.Height = 0.125F;
            this.DepositKind02.Left = 4.295F;
            this.DepositKind02.MultiLine = false;
            this.DepositKind02.Name = "DepositKind02";
            this.DepositKind02.OutputFormat = resources.GetString("DepositKind02.OutputFormat");
            this.DepositKind02.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: �l�r �S�V�b�N; verti" +
                "cal-align: top; ";
            this.DepositKind02.Text = "1,234,567,890";
            this.DepositKind02.Top = 0.063F;
            this.DepositKind02.Width = 0.71F;
            // 
            // DepositKind04
            // 
            this.DepositKind04.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind04.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind04.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind04.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind04.Height = 0.125F;
            this.DepositKind04.Left = 5.715F;
            this.DepositKind04.MultiLine = false;
            this.DepositKind04.Name = "DepositKind04";
            this.DepositKind04.OutputFormat = resources.GetString("DepositKind04.OutputFormat");
            this.DepositKind04.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: �l�r �S�V�b�N; verti" +
                "cal-align: top; ";
            this.DepositKind04.Text = "1,234,567,890";
            this.DepositKind04.Top = 0.063F;
            this.DepositKind04.Width = 0.71F;
            // 
            // DepositKind03
            // 
            this.DepositKind03.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind03.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind03.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind03.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind03.Height = 0.125F;
            this.DepositKind03.Left = 5.005F;
            this.DepositKind03.MultiLine = false;
            this.DepositKind03.Name = "DepositKind03";
            this.DepositKind03.OutputFormat = resources.GetString("DepositKind03.OutputFormat");
            this.DepositKind03.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: �l�r �S�V�b�N; verti" +
                "cal-align: top; ";
            this.DepositKind03.Text = "1,234,567,890";
            this.DepositKind03.Top = 0.063F;
            this.DepositKind03.Width = 0.71F;
            // 
            // DepositKind05
            // 
            this.DepositKind05.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind05.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind05.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind05.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind05.Height = 0.125F;
            this.DepositKind05.Left = 6.425F;
            this.DepositKind05.MultiLine = false;
            this.DepositKind05.Name = "DepositKind05";
            this.DepositKind05.OutputFormat = resources.GetString("DepositKind05.OutputFormat");
            this.DepositKind05.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: �l�r �S�V�b�N; verti" +
                "cal-align: top; ";
            this.DepositKind05.Text = "1,234,567,890";
            this.DepositKind05.Top = 0.063F;
            this.DepositKind05.Width = 0.71F;
            // 
            // DepositKind09
            // 
            this.DepositKind09.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind09.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind09.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind09.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind09.Height = 0.125F;
            this.DepositKind09.Left = 9.265F;
            this.DepositKind09.MultiLine = false;
            this.DepositKind09.Name = "DepositKind09";
            this.DepositKind09.OutputFormat = resources.GetString("DepositKind09.OutputFormat");
            this.DepositKind09.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: �l�r �S�V�b�N; verti" +
                "cal-align: top; ";
            this.DepositKind09.Text = "1,234,567,890";
            this.DepositKind09.Top = 0.063F;
            this.DepositKind09.Width = 0.71F;
            // 
            // DepositKind06
            // 
            this.DepositKind06.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind06.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind06.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind06.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind06.Height = 0.125F;
            this.DepositKind06.Left = 7.135F;
            this.DepositKind06.MultiLine = false;
            this.DepositKind06.Name = "DepositKind06";
            this.DepositKind06.OutputFormat = resources.GetString("DepositKind06.OutputFormat");
            this.DepositKind06.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: �l�r �S�V�b�N; verti" +
                "cal-align: top; ";
            this.DepositKind06.Text = "1,234,567,890";
            this.DepositKind06.Top = 0.063F;
            this.DepositKind06.Width = 0.71F;
            // 
            // DepositKind07
            // 
            this.DepositKind07.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind07.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind07.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind07.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind07.Height = 0.125F;
            this.DepositKind07.Left = 7.845F;
            this.DepositKind07.MultiLine = false;
            this.DepositKind07.Name = "DepositKind07";
            this.DepositKind07.OutputFormat = resources.GetString("DepositKind07.OutputFormat");
            this.DepositKind07.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: �l�r �S�V�b�N; verti" +
                "cal-align: top; ";
            this.DepositKind07.Text = "1,234,567,890";
            this.DepositKind07.Top = 0.063F;
            this.DepositKind07.Width = 0.71F;
            // 
            // DepositKind08
            // 
            this.DepositKind08.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind08.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind08.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind08.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind08.Height = 0.125F;
            this.DepositKind08.Left = 8.555F;
            this.DepositKind08.MultiLine = false;
            this.DepositKind08.Name = "DepositKind08";
            this.DepositKind08.OutputFormat = resources.GetString("DepositKind08.OutputFormat");
            this.DepositKind08.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: �l�r �S�V�b�N; verti" +
                "cal-align: top; ";
            this.DepositKind08.Text = "1,234,567,890";
            this.DepositKind08.Top = 0.063F;
            this.DepositKind08.Width = 0.71F;
            // 
            // Line37
            // 
            this.Line37.Border.BottomColor = System.Drawing.Color.Black;
            this.Line37.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line37.Border.LeftColor = System.Drawing.Color.Black;
            this.Line37.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line37.Border.RightColor = System.Drawing.Color.Black;
            this.Line37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line37.Border.TopColor = System.Drawing.Color.Black;
            this.Line37.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line37.Height = 0F;
            this.Line37.Left = 0F;
            this.Line37.LineWeight = 1F;
            this.Line37.Name = "Line37";
            this.Line37.Top = 0F;
            this.Line37.Width = 10.8F;
            this.Line37.X1 = 0F;
            this.Line37.X2 = 10.8F;
            this.Line37.Y1 = 0F;
            this.Line37.Y2 = 0F;
            // 
            // PageHeader
            // 
            this.PageHeader.CanShrink = true;
            this.PageHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.tb_ReportTitle,
            this.Line1,
            this.tb_SortOrderName,
            this.Label1,
            this.tb_PrintDate,
            this.Label4,
            this.tb_PrintPage,
            this.tb_PrintTime});
            this.PageHeader.Height = 0.3229167F;
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
            this.tb_ReportTitle.Height = 0.21875F;
            this.tb_ReportTitle.HyperLink = "";
            this.tb_ReportTitle.Left = 0.21875F;
            this.tb_ReportTitle.MultiLine = false;
            this.tb_ReportTitle.Name = "tb_ReportTitle";
            this.tb_ReportTitle.Style = "ddo-char-set: 1; font-weight: bold; font-style: italic; font-size: 14.25pt; font-" +
                "family: �l�r ����; vertical-align: middle; ";
            this.tb_ReportTitle.Text = "�����m�F�\�i�W�v�\�j";
            this.tb_ReportTitle.Top = 0F;
            this.tb_ReportTitle.Width = 2.78125F;
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
            // tb_SortOrderName
            // 
            this.tb_SortOrderName.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_SortOrderName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SortOrderName.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_SortOrderName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SortOrderName.Border.RightColor = System.Drawing.Color.Black;
            this.tb_SortOrderName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SortOrderName.Border.TopColor = System.Drawing.Color.Black;
            this.tb_SortOrderName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_SortOrderName.CanShrink = true;
            this.tb_SortOrderName.Height = 0.15625F;
            this.tb_SortOrderName.Left = 3.063F;
            this.tb_SortOrderName.MultiLine = false;
            this.tb_SortOrderName.Name = "tb_SortOrderName";
            this.tb_SortOrderName.Style = "ddo-char-set: 1; font-size: 8pt; font-family: �l�r ����; vertical-align: top; ";
            this.tb_SortOrderName.Text = "[�\�[�g����]";
            this.tb_SortOrderName.Top = 0.063F;
            this.tb_SortOrderName.Width = 2.1875F;
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
            this.Label1.Height = 0.15625F;
            this.Label1.HyperLink = "";
            this.Label1.Left = 7.9375F;
            this.Label1.MultiLine = false;
            this.Label1.Name = "Label1";
            this.Label1.Style = "ddo-char-set: 1; font-size: 8pt; font-family: �l�r ����; vertical-align: top; ";
            this.Label1.Text = "�쐬���t�F";
            this.Label1.Top = 0.0625F;
            this.Label1.Width = 0.625F;
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
            // Label4
            // 
            this.Label4.Border.BottomColor = System.Drawing.Color.Black;
            this.Label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label4.Border.LeftColor = System.Drawing.Color.Black;
            this.Label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label4.Border.RightColor = System.Drawing.Color.Black;
            this.Label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label4.Border.TopColor = System.Drawing.Color.Black;
            this.Label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label4.Height = 0.15625F;
            this.Label4.HyperLink = "";
            this.Label4.Left = 9.9375F;
            this.Label4.MultiLine = false;
            this.Label4.Name = "Label4";
            this.Label4.Style = "ddo-char-set: 1; font-size: 8pt; font-family: �l�r ����; vertical-align: top; ";
            this.Label4.Text = "�y�[�W�F";
            this.Label4.Top = 0.0625F;
            this.Label4.Width = 0.5F;
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
            // PageFooter
            // 
            this.PageFooter.CanShrink = true;
            this.PageFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Footer_SubReport});
            this.PageFooter.Height = 0F;
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
            // 
            // TitleHeader
            // 
            this.TitleHeader.CanShrink = true;
            this.TitleHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Label104,
            this.Label105,
            this.DepositKind01_Title,
            this.DepositKind02_Title,
            this.DepositKind04_Title,
            this.DepositKind03_Title,
            this.DepositKind05_Title,
            this.DepositKind06_Title,
            this.DepositKind07_Title,
            this.DepositKind08_Title,
            this.DepositKind10_Title,
            this.Line42,
            this.DepositKind09_Title,
            this.DepositKind11_Title,
            this.line2});
            this.TitleHeader.Height = 0.25F;
            this.TitleHeader.Name = "TitleHeader";
            this.TitleHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // Label104
            // 
            this.Label104.Border.BottomColor = System.Drawing.Color.Black;
            this.Label104.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label104.Border.LeftColor = System.Drawing.Color.Black;
            this.Label104.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label104.Border.RightColor = System.Drawing.Color.Black;
            this.Label104.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label104.Border.TopColor = System.Drawing.Color.Black;
            this.Label104.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label104.Height = 0.14F;
            this.Label104.HyperLink = "";
            this.Label104.Left = 0F;
            this.Label104.MultiLine = false;
            this.Label104.Name = "Label104";
            this.Label104.Style = "ddo-char-set: 128; text-align: left; font-weight: bold; font-size: 7pt; font-fami" +
                "ly: �l�r ����; vertical-align: top; ";
            this.Label104.Text = "���Ӑ�";
            this.Label104.Top = 0.0625F;
            this.Label104.Width = 0.563F;
            // 
            // Label105
            // 
            this.Label105.Border.BottomColor = System.Drawing.Color.Black;
            this.Label105.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label105.Border.LeftColor = System.Drawing.Color.Black;
            this.Label105.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label105.Border.RightColor = System.Drawing.Color.Black;
            this.Label105.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label105.Border.TopColor = System.Drawing.Color.Black;
            this.Label105.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label105.Height = 0.125F;
            this.Label105.HyperLink = "";
            this.Label105.Left = 2.875F;
            this.Label105.MultiLine = false;
            this.Label105.Name = "Label105";
            this.Label105.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r ����; vertical-align: top; ";
            this.Label105.Text = "���v���z";
            this.Label105.Top = 0.0625F;
            this.Label105.Width = 0.71F;
            // 
            // DepositKind01_Title
            // 
            this.DepositKind01_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind01_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind01_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind01_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind01_Title.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind01_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind01_Title.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind01_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind01_Title.Height = 0.125F;
            this.DepositKind01_Title.HyperLink = "";
            this.DepositKind01_Title.Left = 3.585F;
            this.DepositKind01_Title.MultiLine = false;
            this.DepositKind01_Title.Name = "DepositKind01_Title";
            this.DepositKind01_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r ����; vertical-align: top; ";
            this.DepositKind01_Title.Text = "����";
            this.DepositKind01_Title.Top = 0.063F;
            this.DepositKind01_Title.Width = 0.71F;
            // 
            // DepositKind02_Title
            // 
            this.DepositKind02_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind02_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind02_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind02_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind02_Title.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind02_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind02_Title.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind02_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind02_Title.Height = 0.125F;
            this.DepositKind02_Title.HyperLink = "";
            this.DepositKind02_Title.Left = 4.295F;
            this.DepositKind02_Title.MultiLine = false;
            this.DepositKind02_Title.Name = "DepositKind02_Title";
            this.DepositKind02_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r ����; vertical-align: top; ";
            this.DepositKind02_Title.Text = "�U��";
            this.DepositKind02_Title.Top = 0.063F;
            this.DepositKind02_Title.Width = 0.71F;
            // 
            // DepositKind04_Title
            // 
            this.DepositKind04_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind04_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind04_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind04_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind04_Title.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind04_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind04_Title.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind04_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind04_Title.Height = 0.125F;
            this.DepositKind04_Title.HyperLink = "";
            this.DepositKind04_Title.Left = 5.715F;
            this.DepositKind04_Title.MultiLine = false;
            this.DepositKind04_Title.Name = "DepositKind04_Title";
            this.DepositKind04_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r ����; vertical-align: top; ";
            this.DepositKind04_Title.Text = "���E";
            this.DepositKind04_Title.Top = 0.063F;
            this.DepositKind04_Title.Width = 0.71F;
            // 
            // DepositKind03_Title
            // 
            this.DepositKind03_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind03_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind03_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind03_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind03_Title.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind03_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind03_Title.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind03_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind03_Title.Height = 0.125F;
            this.DepositKind03_Title.HyperLink = "";
            this.DepositKind03_Title.Left = 5.005F;
            this.DepositKind03_Title.MultiLine = false;
            this.DepositKind03_Title.Name = "DepositKind03_Title";
            this.DepositKind03_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r ����; vertical-align: top; ";
            this.DepositKind03_Title.Text = "��`";
            this.DepositKind03_Title.Top = 0.063F;
            this.DepositKind03_Title.Width = 0.71F;
            // 
            // DepositKind05_Title
            // 
            this.DepositKind05_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind05_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind05_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind05_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind05_Title.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind05_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind05_Title.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind05_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind05_Title.Height = 0.125F;
            this.DepositKind05_Title.HyperLink = "";
            this.DepositKind05_Title.Left = 6.425F;
            this.DepositKind05_Title.MultiLine = false;
            this.DepositKind05_Title.Name = "DepositKind05_Title";
            this.DepositKind05_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r ����; vertical-align: top; ";
            this.DepositKind05_Title.Text = "���؎�";
            this.DepositKind05_Title.Top = 0.063F;
            this.DepositKind05_Title.Width = 0.71F;
            // 
            // DepositKind06_Title
            // 
            this.DepositKind06_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind06_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind06_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind06_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind06_Title.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind06_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind06_Title.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind06_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind06_Title.Height = 0.125F;
            this.DepositKind06_Title.HyperLink = "";
            this.DepositKind06_Title.Left = 7.135F;
            this.DepositKind06_Title.MultiLine = false;
            this.DepositKind06_Title.Name = "DepositKind06_Title";
            this.DepositKind06_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r ����; vertical-align: top; ";
            this.DepositKind06_Title.Text = "�����U��";
            this.DepositKind06_Title.Top = 0.063F;
            this.DepositKind06_Title.Width = 0.71F;
            // 
            // DepositKind07_Title
            // 
            this.DepositKind07_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind07_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind07_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind07_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind07_Title.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind07_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind07_Title.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind07_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind07_Title.Height = 0.125F;
            this.DepositKind07_Title.HyperLink = "";
            this.DepositKind07_Title.Left = 7.845F;
            this.DepositKind07_Title.MultiLine = false;
            this.DepositKind07_Title.Name = "DepositKind07_Title";
            this.DepositKind07_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r ����; vertical-align: top; ";
            this.DepositKind07_Title.Text = "�t�@�N�^�����O";
            this.DepositKind07_Title.Top = 0.063F;
            this.DepositKind07_Title.Width = 0.71F;
            // 
            // DepositKind08_Title
            // 
            this.DepositKind08_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind08_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind08_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind08_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind08_Title.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind08_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind08_Title.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind08_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind08_Title.Height = 0.125F;
            this.DepositKind08_Title.HyperLink = "";
            this.DepositKind08_Title.Left = 8.555F;
            this.DepositKind08_Title.MultiLine = false;
            this.DepositKind08_Title.Name = "DepositKind08_Title";
            this.DepositKind08_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r ����; vertical-align: top; ";
            this.DepositKind08_Title.Text = "�萔��";
            this.DepositKind08_Title.Top = 0.063F;
            this.DepositKind08_Title.Width = 0.71F;
            // 
            // DepositKind10_Title
            // 
            this.DepositKind10_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind10_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind10_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind10_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind10_Title.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind10_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind10_Title.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind10_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind10_Title.Height = 0.125F;
            this.DepositKind10_Title.HyperLink = "";
            this.DepositKind10_Title.Left = 9.735F;
            this.DepositKind10_Title.MultiLine = false;
            this.DepositKind10_Title.Name = "DepositKind10_Title";
            this.DepositKind10_Title.Style = "color: #E0E0E0; ddo-char-set: 128; text-align: right; font-weight: bold; font-siz" +
                "e: 7pt; font-family: �l�r ����; vertical-align: top; ";
            this.DepositKind10_Title.Text = "�l��";
            this.DepositKind10_Title.Top = 0.063F;
            this.DepositKind10_Title.Visible = false;
            this.DepositKind10_Title.Width = 0.24F;
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
            // DepositKind09_Title
            // 
            this.DepositKind09_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind09_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind09_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind09_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind09_Title.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind09_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind09_Title.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind09_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind09_Title.Height = 0.125F;
            this.DepositKind09_Title.HyperLink = "";
            this.DepositKind09_Title.Left = 9.2575F;
            this.DepositKind09_Title.MultiLine = false;
            this.DepositKind09_Title.Name = "DepositKind09_Title";
            this.DepositKind09_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r ����; vertical-align: top; ";
            this.DepositKind09_Title.Text = "���̑�";
            this.DepositKind09_Title.Top = 0.063F;
            this.DepositKind09_Title.Width = 0.71F;
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
            this.line2.Top = 0.1875F;
            this.line2.Width = 10.8F;
            this.line2.X1 = 0F;
            this.line2.X2 = 10.8F;
            this.line2.Y1 = 0.1875F;
            this.line2.Y2 = 0.1875F;
            // 
            // TitleFooter
            // 
            this.TitleFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Line41});
            this.TitleFooter.Height = 0F;
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
            this.Total_DepositKind01,
            this.Total_Deposit,
            this.Total_DepositKind02,
            this.Total_DepositKind04,
            this.Total_DepositKind03,
            this.Total_DepositKind05,
            this.Total_DepositKind09,
            this.Total_DepositKind06,
            this.Label109,
            this.Total_DepositKind07,
            this.Total_DepositKind08,
            this.Line43,
            this.Total_DepositKind11});
            this.GrandTotalFooter.Height = 0.25F;
            this.GrandTotalFooter.KeepTogether = true;
            this.GrandTotalFooter.Name = "GrandTotalFooter";
            // 
            // Total_DepositKind01
            // 
            this.Total_DepositKind01.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_DepositKind01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind01.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_DepositKind01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind01.Border.RightColor = System.Drawing.Color.Black;
            this.Total_DepositKind01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind01.Border.TopColor = System.Drawing.Color.Black;
            this.Total_DepositKind01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind01.Height = 0.125F;
            this.Total_DepositKind01.Left = 3.585F;
            this.Total_DepositKind01.MultiLine = false;
            this.Total_DepositKind01.Name = "Total_DepositKind01";
            this.Total_DepositKind01.OutputFormat = resources.GetString("Total_DepositKind01.OutputFormat");
            this.Total_DepositKind01.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.Total_DepositKind01.SummaryGroup = "GrandTotalHeader";
            this.Total_DepositKind01.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Total_DepositKind01.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Total_DepositKind01.Text = "1,234,567,890";
            this.Total_DepositKind01.Top = 0.063F;
            this.Total_DepositKind01.Width = 0.71F;
            // 
            // Total_Deposit
            // 
            this.Total_Deposit.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_Deposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_Deposit.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_Deposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_Deposit.Border.RightColor = System.Drawing.Color.Black;
            this.Total_Deposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_Deposit.Border.TopColor = System.Drawing.Color.Black;
            this.Total_Deposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_Deposit.DataField = "DepositTotal";
            this.Total_Deposit.Height = 0.125F;
            this.Total_Deposit.Left = 2.835F;
            this.Total_Deposit.MultiLine = false;
            this.Total_Deposit.Name = "Total_Deposit";
            this.Total_Deposit.OutputFormat = resources.GetString("Total_Deposit.OutputFormat");
            this.Total_Deposit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.Total_Deposit.SummaryGroup = "GrandTotalHeader";
            this.Total_Deposit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Total_Deposit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Total_Deposit.Text = "1,234,567,890";
            this.Total_Deposit.Top = 0.063F;
            this.Total_Deposit.Width = 0.75F;
            // 
            // Total_DepositKind02
            // 
            this.Total_DepositKind02.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_DepositKind02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind02.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_DepositKind02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind02.Border.RightColor = System.Drawing.Color.Black;
            this.Total_DepositKind02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind02.Border.TopColor = System.Drawing.Color.Black;
            this.Total_DepositKind02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind02.Height = 0.125F;
            this.Total_DepositKind02.Left = 4.295F;
            this.Total_DepositKind02.MultiLine = false;
            this.Total_DepositKind02.Name = "Total_DepositKind02";
            this.Total_DepositKind02.OutputFormat = resources.GetString("Total_DepositKind02.OutputFormat");
            this.Total_DepositKind02.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.Total_DepositKind02.SummaryGroup = "GrandTotalHeader";
            this.Total_DepositKind02.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Total_DepositKind02.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Total_DepositKind02.Text = "1,234,567,890";
            this.Total_DepositKind02.Top = 0.063F;
            this.Total_DepositKind02.Width = 0.71F;
            // 
            // Total_DepositKind04
            // 
            this.Total_DepositKind04.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_DepositKind04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind04.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_DepositKind04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind04.Border.RightColor = System.Drawing.Color.Black;
            this.Total_DepositKind04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind04.Border.TopColor = System.Drawing.Color.Black;
            this.Total_DepositKind04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind04.Height = 0.125F;
            this.Total_DepositKind04.Left = 5.715F;
            this.Total_DepositKind04.MultiLine = false;
            this.Total_DepositKind04.Name = "Total_DepositKind04";
            this.Total_DepositKind04.OutputFormat = resources.GetString("Total_DepositKind04.OutputFormat");
            this.Total_DepositKind04.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.Total_DepositKind04.SummaryGroup = "GrandTotalHeader";
            this.Total_DepositKind04.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Total_DepositKind04.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Total_DepositKind04.Text = "1,234,567,890";
            this.Total_DepositKind04.Top = 0.063F;
            this.Total_DepositKind04.Width = 0.71F;
            // 
            // Total_DepositKind03
            // 
            this.Total_DepositKind03.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_DepositKind03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind03.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_DepositKind03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind03.Border.RightColor = System.Drawing.Color.Black;
            this.Total_DepositKind03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind03.Border.TopColor = System.Drawing.Color.Black;
            this.Total_DepositKind03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind03.Height = 0.125F;
            this.Total_DepositKind03.Left = 5.005F;
            this.Total_DepositKind03.MultiLine = false;
            this.Total_DepositKind03.Name = "Total_DepositKind03";
            this.Total_DepositKind03.OutputFormat = resources.GetString("Total_DepositKind03.OutputFormat");
            this.Total_DepositKind03.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.Total_DepositKind03.SummaryGroup = "GrandTotalHeader";
            this.Total_DepositKind03.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Total_DepositKind03.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Total_DepositKind03.Text = "1,234,567,890";
            this.Total_DepositKind03.Top = 0.063F;
            this.Total_DepositKind03.Width = 0.71F;
            // 
            // Total_DepositKind05
            // 
            this.Total_DepositKind05.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_DepositKind05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind05.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_DepositKind05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind05.Border.RightColor = System.Drawing.Color.Black;
            this.Total_DepositKind05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind05.Border.TopColor = System.Drawing.Color.Black;
            this.Total_DepositKind05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind05.Height = 0.125F;
            this.Total_DepositKind05.Left = 6.425F;
            this.Total_DepositKind05.MultiLine = false;
            this.Total_DepositKind05.Name = "Total_DepositKind05";
            this.Total_DepositKind05.OutputFormat = resources.GetString("Total_DepositKind05.OutputFormat");
            this.Total_DepositKind05.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.Total_DepositKind05.SummaryGroup = "GrandTotalHeader";
            this.Total_DepositKind05.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Total_DepositKind05.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Total_DepositKind05.Text = "1,234,567,890";
            this.Total_DepositKind05.Top = 0.063F;
            this.Total_DepositKind05.Width = 0.71F;
            // 
            // Total_DepositKind09
            // 
            this.Total_DepositKind09.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_DepositKind09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind09.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_DepositKind09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind09.Border.RightColor = System.Drawing.Color.Black;
            this.Total_DepositKind09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind09.Border.TopColor = System.Drawing.Color.Black;
            this.Total_DepositKind09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind09.Height = 0.125F;
            this.Total_DepositKind09.Left = 9.265F;
            this.Total_DepositKind09.MultiLine = false;
            this.Total_DepositKind09.Name = "Total_DepositKind09";
            this.Total_DepositKind09.OutputFormat = resources.GetString("Total_DepositKind09.OutputFormat");
            this.Total_DepositKind09.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.Total_DepositKind09.SummaryGroup = "GrandTotalHeader";
            this.Total_DepositKind09.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Total_DepositKind09.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Total_DepositKind09.Text = "1,234,567,890";
            this.Total_DepositKind09.Top = 0.063F;
            this.Total_DepositKind09.Width = 0.71F;
            // 
            // Total_DepositKind06
            // 
            this.Total_DepositKind06.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_DepositKind06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind06.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_DepositKind06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind06.Border.RightColor = System.Drawing.Color.Black;
            this.Total_DepositKind06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind06.Border.TopColor = System.Drawing.Color.Black;
            this.Total_DepositKind06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind06.Height = 0.125F;
            this.Total_DepositKind06.Left = 7.135F;
            this.Total_DepositKind06.MultiLine = false;
            this.Total_DepositKind06.Name = "Total_DepositKind06";
            this.Total_DepositKind06.OutputFormat = resources.GetString("Total_DepositKind06.OutputFormat");
            this.Total_DepositKind06.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.Total_DepositKind06.SummaryGroup = "GrandTotalHeader";
            this.Total_DepositKind06.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Total_DepositKind06.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Total_DepositKind06.Text = "1,234,567,890";
            this.Total_DepositKind06.Top = 0.063F;
            this.Total_DepositKind06.Width = 0.71F;
            // 
            // Label109
            // 
            this.Label109.Border.BottomColor = System.Drawing.Color.Black;
            this.Label109.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label109.Border.LeftColor = System.Drawing.Color.Black;
            this.Label109.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label109.Border.RightColor = System.Drawing.Color.Black;
            this.Label109.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label109.Border.TopColor = System.Drawing.Color.Black;
            this.Label109.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Label109.Height = 0.1875F;
            this.Label109.HyperLink = "";
            this.Label109.Left = 2.0625F;
            this.Label109.MultiLine = false;
            this.Label109.Name = "Label109";
            this.Label109.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: �l�r ����; vertical-align: top; ";
            this.Label109.Text = "�����v";
            this.Label109.Top = 0.0625F;
            this.Label109.Width = 0.5625F;
            // 
            // Total_DepositKind07
            // 
            this.Total_DepositKind07.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_DepositKind07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind07.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_DepositKind07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind07.Border.RightColor = System.Drawing.Color.Black;
            this.Total_DepositKind07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind07.Border.TopColor = System.Drawing.Color.Black;
            this.Total_DepositKind07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind07.Height = 0.125F;
            this.Total_DepositKind07.Left = 7.845F;
            this.Total_DepositKind07.MultiLine = false;
            this.Total_DepositKind07.Name = "Total_DepositKind07";
            this.Total_DepositKind07.OutputFormat = resources.GetString("Total_DepositKind07.OutputFormat");
            this.Total_DepositKind07.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.Total_DepositKind07.SummaryGroup = "GrandTotalHeader";
            this.Total_DepositKind07.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Total_DepositKind07.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Total_DepositKind07.Text = "1,234,567,890";
            this.Total_DepositKind07.Top = 0.063F;
            this.Total_DepositKind07.Width = 0.71F;
            // 
            // Total_DepositKind08
            // 
            this.Total_DepositKind08.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_DepositKind08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind08.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_DepositKind08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind08.Border.RightColor = System.Drawing.Color.Black;
            this.Total_DepositKind08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind08.Border.TopColor = System.Drawing.Color.Black;
            this.Total_DepositKind08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind08.Height = 0.125F;
            this.Total_DepositKind08.Left = 8.555F;
            this.Total_DepositKind08.MultiLine = false;
            this.Total_DepositKind08.Name = "Total_DepositKind08";
            this.Total_DepositKind08.OutputFormat = resources.GetString("Total_DepositKind08.OutputFormat");
            this.Total_DepositKind08.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.Total_DepositKind08.SummaryGroup = "GrandTotalHeader";
            this.Total_DepositKind08.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Total_DepositKind08.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Total_DepositKind08.Text = "1,234,567,890";
            this.Total_DepositKind08.Top = 0.063F;
            this.Total_DepositKind08.Width = 0.71F;
            // 
            // Line43
            // 
            this.Line43.Border.BottomColor = System.Drawing.Color.Black;
            this.Line43.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line43.Border.LeftColor = System.Drawing.Color.Black;
            this.Line43.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line43.Border.RightColor = System.Drawing.Color.Black;
            this.Line43.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line43.Border.TopColor = System.Drawing.Color.Black;
            this.Line43.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line43.Height = 0F;
            this.Line43.Left = 0F;
            this.Line43.LineWeight = 2F;
            this.Line43.Name = "Line43";
            this.Line43.Top = 0F;
            this.Line43.Width = 10.8125F;
            this.Line43.X1 = 0F;
            this.Line43.X2 = 10.8125F;
            this.Line43.Y1 = 0F;
            this.Line43.Y2 = 0F;
            // 
            // SectionHeader
            // 
            this.SectionHeader.CanShrink = true;
            this.SectionHeader.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.tb_AddUpSecName,
            this.tb_AddUpSecCode,
            this.label15,
            this.TitleHeader_Line1});
            this.SectionHeader.DataField = "AddUpSecCode";
            this.SectionHeader.Height = 0.25F;
            this.SectionHeader.Name = "SectionHeader";
            this.SectionHeader.NewPage = DataDynamics.ActiveReports.NewPage.Before;
            this.SectionHeader.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail;
            // 
            // tb_AddUpSecName
            // 
            this.tb_AddUpSecName.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_AddUpSecName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_AddUpSecName.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_AddUpSecName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_AddUpSecName.Border.RightColor = System.Drawing.Color.Black;
            this.tb_AddUpSecName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_AddUpSecName.Border.TopColor = System.Drawing.Color.Black;
            this.tb_AddUpSecName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_AddUpSecName.DataField = "AddUpSecName";
            this.tb_AddUpSecName.Height = 0.125F;
            this.tb_AddUpSecName.Left = 0.5005F;
            this.tb_AddUpSecName.MultiLine = false;
            this.tb_AddUpSecName.Name = "tb_AddUpSecName";
            this.tb_AddUpSecName.Style = "ddo-char-set: 128; font-size: 7pt; font-family: �l�r ����; vertical-align: top; ";
            this.tb_AddUpSecName.Text = "��������������������";
            this.tb_AddUpSecName.Top = 0.0625F;
            this.tb_AddUpSecName.Width = 1.19F;
            // 
            // tb_AddUpSecCode
            // 
            this.tb_AddUpSecCode.Border.BottomColor = System.Drawing.Color.Black;
            this.tb_AddUpSecCode.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_AddUpSecCode.Border.LeftColor = System.Drawing.Color.Black;
            this.tb_AddUpSecCode.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_AddUpSecCode.Border.RightColor = System.Drawing.Color.Black;
            this.tb_AddUpSecCode.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_AddUpSecCode.Border.TopColor = System.Drawing.Color.Black;
            this.tb_AddUpSecCode.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.tb_AddUpSecCode.CanShrink = true;
            this.tb_AddUpSecCode.DataField = "AddUpSecCode";
            this.tb_AddUpSecCode.Height = 0.125F;
            this.tb_AddUpSecCode.Left = 0.3125F;
            this.tb_AddUpSecCode.MultiLine = false;
            this.tb_AddUpSecCode.Name = "tb_AddUpSecCode";
            this.tb_AddUpSecCode.Style = "ddo-char-set: 128; font-size: 7pt; font-family: �l�r �S�V�b�N; vertical-align: top; ";
            this.tb_AddUpSecCode.Text = "99";
            this.tb_AddUpSecCode.Top = 0.0625F;
            this.tb_AddUpSecCode.Width = 0.188F;
            // 
            // label15
            // 
            this.label15.Border.BottomColor = System.Drawing.Color.Black;
            this.label15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label15.Border.LeftColor = System.Drawing.Color.Black;
            this.label15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label15.Border.RightColor = System.Drawing.Color.Black;
            this.label15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label15.Border.TopColor = System.Drawing.Color.Black;
            this.label15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.label15.Height = 0.125F;
            this.label15.HyperLink = "";
            this.label15.Left = 0F;
            this.label15.Name = "label15";
            this.label15.Style = "color: Black; ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 7p" +
                "t; vertical-align: top; ";
            this.label15.Text = "���_";
            this.label15.Top = 0.0625F;
            this.label15.Width = 0.3125F;
            // 
            // TitleHeader_Line1
            // 
            this.TitleHeader_Line1.Border.BottomColor = System.Drawing.Color.Black;
            this.TitleHeader_Line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TitleHeader_Line1.Border.LeftColor = System.Drawing.Color.Black;
            this.TitleHeader_Line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TitleHeader_Line1.Border.RightColor = System.Drawing.Color.Black;
            this.TitleHeader_Line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TitleHeader_Line1.Border.TopColor = System.Drawing.Color.Black;
            this.TitleHeader_Line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.TitleHeader_Line1.Height = 0F;
            this.TitleHeader_Line1.Left = 0F;
            this.TitleHeader_Line1.LineWeight = 2F;
            this.TitleHeader_Line1.Name = "TitleHeader_Line1";
            this.TitleHeader_Line1.Top = 0F;
            this.TitleHeader_Line1.Width = 10.8125F;
            this.TitleHeader_Line1.X1 = 0F;
            this.TitleHeader_Line1.X2 = 10.8125F;
            this.TitleHeader_Line1.Y1 = 0F;
            this.TitleHeader_Line1.Y2 = 0F;
            // 
            // SectionFooter
            // 
            this.SectionFooter.CanShrink = true;
            this.SectionFooter.Controls.AddRange(new DataDynamics.ActiveReports.ARControl[] {
            this.Section_DepositKind01,
            this.Section_Deposit,
            this.Section_DepositKind02,
            this.Section_DepositKind04,
            this.Section_DepositKind03,
            this.Section_DepositKind05,
            this.Section_DepositKind09,
            this.Section_DepositKind06,
            this.MONEYKINDNAME13,
            this.Section_DepositKind07,
            this.Section_DepositKind08,
            this.Line45,
            this.Section_DepositKind11});
            this.SectionFooter.Height = 0.25F;
            this.SectionFooter.KeepTogether = true;
            this.SectionFooter.Name = "SectionFooter";
            // 
            // Section_DepositKind01
            // 
            this.Section_DepositKind01.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_DepositKind01.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind01.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_DepositKind01.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind01.Border.RightColor = System.Drawing.Color.Black;
            this.Section_DepositKind01.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind01.Border.TopColor = System.Drawing.Color.Black;
            this.Section_DepositKind01.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind01.Height = 0.125F;
            this.Section_DepositKind01.Left = 3.585F;
            this.Section_DepositKind01.MultiLine = false;
            this.Section_DepositKind01.Name = "Section_DepositKind01";
            this.Section_DepositKind01.OutputFormat = resources.GetString("Section_DepositKind01.OutputFormat");
            this.Section_DepositKind01.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.Section_DepositKind01.SummaryGroup = "SectionHeader";
            this.Section_DepositKind01.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_DepositKind01.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_DepositKind01.Text = "1,234,567,890";
            this.Section_DepositKind01.Top = 0.063F;
            this.Section_DepositKind01.Width = 0.71F;
            // 
            // Section_Deposit
            // 
            this.Section_Deposit.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_Deposit.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_Deposit.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_Deposit.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_Deposit.Border.RightColor = System.Drawing.Color.Black;
            this.Section_Deposit.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_Deposit.Border.TopColor = System.Drawing.Color.Black;
            this.Section_Deposit.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_Deposit.DataField = "DepositTotal";
            this.Section_Deposit.Height = 0.125F;
            this.Section_Deposit.Left = 2.835F;
            this.Section_Deposit.MultiLine = false;
            this.Section_Deposit.Name = "Section_Deposit";
            this.Section_Deposit.OutputFormat = resources.GetString("Section_Deposit.OutputFormat");
            this.Section_Deposit.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.Section_Deposit.SummaryGroup = "SectionHeader";
            this.Section_Deposit.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_Deposit.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_Deposit.Text = "1,234,567,890";
            this.Section_Deposit.Top = 0.063F;
            this.Section_Deposit.Width = 0.75F;
            // 
            // Section_DepositKind02
            // 
            this.Section_DepositKind02.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_DepositKind02.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind02.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_DepositKind02.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind02.Border.RightColor = System.Drawing.Color.Black;
            this.Section_DepositKind02.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind02.Border.TopColor = System.Drawing.Color.Black;
            this.Section_DepositKind02.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind02.Height = 0.125F;
            this.Section_DepositKind02.Left = 4.295F;
            this.Section_DepositKind02.MultiLine = false;
            this.Section_DepositKind02.Name = "Section_DepositKind02";
            this.Section_DepositKind02.OutputFormat = resources.GetString("Section_DepositKind02.OutputFormat");
            this.Section_DepositKind02.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.Section_DepositKind02.SummaryGroup = "SectionHeader";
            this.Section_DepositKind02.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_DepositKind02.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_DepositKind02.Text = "1,234,567,890";
            this.Section_DepositKind02.Top = 0.063F;
            this.Section_DepositKind02.Width = 0.71F;
            // 
            // Section_DepositKind04
            // 
            this.Section_DepositKind04.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_DepositKind04.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind04.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_DepositKind04.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind04.Border.RightColor = System.Drawing.Color.Black;
            this.Section_DepositKind04.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind04.Border.TopColor = System.Drawing.Color.Black;
            this.Section_DepositKind04.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind04.Height = 0.125F;
            this.Section_DepositKind04.Left = 5.715F;
            this.Section_DepositKind04.MultiLine = false;
            this.Section_DepositKind04.Name = "Section_DepositKind04";
            this.Section_DepositKind04.OutputFormat = resources.GetString("Section_DepositKind04.OutputFormat");
            this.Section_DepositKind04.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.Section_DepositKind04.SummaryGroup = "SectionHeader";
            this.Section_DepositKind04.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_DepositKind04.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_DepositKind04.Text = "1,234,567,890";
            this.Section_DepositKind04.Top = 0.063F;
            this.Section_DepositKind04.Width = 0.71F;
            // 
            // Section_DepositKind03
            // 
            this.Section_DepositKind03.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_DepositKind03.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind03.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_DepositKind03.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind03.Border.RightColor = System.Drawing.Color.Black;
            this.Section_DepositKind03.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind03.Border.TopColor = System.Drawing.Color.Black;
            this.Section_DepositKind03.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind03.Height = 0.125F;
            this.Section_DepositKind03.Left = 5.005F;
            this.Section_DepositKind03.MultiLine = false;
            this.Section_DepositKind03.Name = "Section_DepositKind03";
            this.Section_DepositKind03.OutputFormat = resources.GetString("Section_DepositKind03.OutputFormat");
            this.Section_DepositKind03.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.Section_DepositKind03.SummaryGroup = "SectionHeader";
            this.Section_DepositKind03.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_DepositKind03.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_DepositKind03.Text = "1,234,567,890";
            this.Section_DepositKind03.Top = 0.063F;
            this.Section_DepositKind03.Width = 0.71F;
            // 
            // Section_DepositKind05
            // 
            this.Section_DepositKind05.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_DepositKind05.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind05.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_DepositKind05.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind05.Border.RightColor = System.Drawing.Color.Black;
            this.Section_DepositKind05.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind05.Border.TopColor = System.Drawing.Color.Black;
            this.Section_DepositKind05.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind05.Height = 0.125F;
            this.Section_DepositKind05.Left = 6.425F;
            this.Section_DepositKind05.MultiLine = false;
            this.Section_DepositKind05.Name = "Section_DepositKind05";
            this.Section_DepositKind05.OutputFormat = resources.GetString("Section_DepositKind05.OutputFormat");
            this.Section_DepositKind05.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.Section_DepositKind05.SummaryGroup = "SectionHeader";
            this.Section_DepositKind05.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_DepositKind05.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_DepositKind05.Text = "1,234,567,890";
            this.Section_DepositKind05.Top = 0.063F;
            this.Section_DepositKind05.Width = 0.71F;
            // 
            // Section_DepositKind09
            // 
            this.Section_DepositKind09.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_DepositKind09.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind09.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_DepositKind09.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind09.Border.RightColor = System.Drawing.Color.Black;
            this.Section_DepositKind09.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind09.Border.TopColor = System.Drawing.Color.Black;
            this.Section_DepositKind09.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind09.Height = 0.125F;
            this.Section_DepositKind09.Left = 9.265F;
            this.Section_DepositKind09.MultiLine = false;
            this.Section_DepositKind09.Name = "Section_DepositKind09";
            this.Section_DepositKind09.OutputFormat = resources.GetString("Section_DepositKind09.OutputFormat");
            this.Section_DepositKind09.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.Section_DepositKind09.SummaryGroup = "SectionHeader";
            this.Section_DepositKind09.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_DepositKind09.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_DepositKind09.Text = "1,234,567,890";
            this.Section_DepositKind09.Top = 0.063F;
            this.Section_DepositKind09.Width = 0.71F;
            // 
            // Section_DepositKind06
            // 
            this.Section_DepositKind06.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_DepositKind06.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind06.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_DepositKind06.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind06.Border.RightColor = System.Drawing.Color.Black;
            this.Section_DepositKind06.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind06.Border.TopColor = System.Drawing.Color.Black;
            this.Section_DepositKind06.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind06.Height = 0.125F;
            this.Section_DepositKind06.Left = 7.135F;
            this.Section_DepositKind06.MultiLine = false;
            this.Section_DepositKind06.Name = "Section_DepositKind06";
            this.Section_DepositKind06.OutputFormat = resources.GetString("Section_DepositKind06.OutputFormat");
            this.Section_DepositKind06.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.Section_DepositKind06.SummaryGroup = "SectionHeader";
            this.Section_DepositKind06.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_DepositKind06.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_DepositKind06.Text = "1,234,567,890";
            this.Section_DepositKind06.Top = 0.063F;
            this.Section_DepositKind06.Width = 0.71F;
            // 
            // MONEYKINDNAME13
            // 
            this.MONEYKINDNAME13.Border.BottomColor = System.Drawing.Color.Black;
            this.MONEYKINDNAME13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MONEYKINDNAME13.Border.LeftColor = System.Drawing.Color.Black;
            this.MONEYKINDNAME13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MONEYKINDNAME13.Border.RightColor = System.Drawing.Color.Black;
            this.MONEYKINDNAME13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MONEYKINDNAME13.Border.TopColor = System.Drawing.Color.Black;
            this.MONEYKINDNAME13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.MONEYKINDNAME13.DataField = "MONEYKINDNAME";
            this.MONEYKINDNAME13.Height = 0.18F;
            this.MONEYKINDNAME13.Left = 2.0625F;
            this.MONEYKINDNAME13.MultiLine = false;
            this.MONEYKINDNAME13.Name = "MONEYKINDNAME13";
            this.MONEYKINDNAME13.OutputFormat = resources.GetString("MONEYKINDNAME13.OutputFormat");
            this.MONEYKINDNAME13.Style = "ddo-char-set: 1; text-align: left; font-weight: bold; font-size: 10.8pt; font-fam" +
                "ily: �l�r ����; vertical-align: top; ";
            this.MONEYKINDNAME13.Text = "���_�v";
            this.MONEYKINDNAME13.Top = 0.0625F;
            this.MONEYKINDNAME13.Width = 0.5625F;
            // 
            // Section_DepositKind07
            // 
            this.Section_DepositKind07.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_DepositKind07.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind07.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_DepositKind07.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind07.Border.RightColor = System.Drawing.Color.Black;
            this.Section_DepositKind07.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind07.Border.TopColor = System.Drawing.Color.Black;
            this.Section_DepositKind07.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind07.Height = 0.125F;
            this.Section_DepositKind07.Left = 7.845F;
            this.Section_DepositKind07.MultiLine = false;
            this.Section_DepositKind07.Name = "Section_DepositKind07";
            this.Section_DepositKind07.OutputFormat = resources.GetString("Section_DepositKind07.OutputFormat");
            this.Section_DepositKind07.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.Section_DepositKind07.SummaryGroup = "SectionHeader";
            this.Section_DepositKind07.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_DepositKind07.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_DepositKind07.Text = "1,234,567,890";
            this.Section_DepositKind07.Top = 0.063F;
            this.Section_DepositKind07.Width = 0.71F;
            // 
            // Section_DepositKind08
            // 
            this.Section_DepositKind08.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_DepositKind08.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind08.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_DepositKind08.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind08.Border.RightColor = System.Drawing.Color.Black;
            this.Section_DepositKind08.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind08.Border.TopColor = System.Drawing.Color.Black;
            this.Section_DepositKind08.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind08.Height = 0.125F;
            this.Section_DepositKind08.Left = 8.555F;
            this.Section_DepositKind08.MultiLine = false;
            this.Section_DepositKind08.Name = "Section_DepositKind08";
            this.Section_DepositKind08.OutputFormat = resources.GetString("Section_DepositKind08.OutputFormat");
            this.Section_DepositKind08.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.Section_DepositKind08.SummaryGroup = "SectionHeader";
            this.Section_DepositKind08.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_DepositKind08.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_DepositKind08.Text = "1,234,567,890";
            this.Section_DepositKind08.Top = 0.063F;
            this.Section_DepositKind08.Width = 0.71F;
            // 
            // Line45
            // 
            this.Line45.Border.BottomColor = System.Drawing.Color.Black;
            this.Line45.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line45.Border.LeftColor = System.Drawing.Color.Black;
            this.Line45.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line45.Border.RightColor = System.Drawing.Color.Black;
            this.Line45.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line45.Border.TopColor = System.Drawing.Color.Black;
            this.Line45.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Line45.Height = 0F;
            this.Line45.Left = 0F;
            this.Line45.LineWeight = 2F;
            this.Line45.Name = "Line45";
            this.Line45.Top = 0F;
            this.Line45.Width = 10.8F;
            this.Line45.X1 = 0F;
            this.Line45.X2 = 10.8F;
            this.Line45.Y1 = 0F;
            this.Line45.Y2 = 0F;
            // 
            // DepositKind11_Title
            // 
            this.DepositKind11_Title.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind11_Title.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind11_Title.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind11_Title.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind11_Title.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind11_Title.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind11_Title.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind11_Title.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind11_Title.Height = 0.125F;
            this.DepositKind11_Title.HyperLink = "";
            this.DepositKind11_Title.Left = 9.989583F;
            this.DepositKind11_Title.MultiLine = false;
            this.DepositKind11_Title.Name = "DepositKind11_Title";
            this.DepositKind11_Title.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r ����; vertical-align: top; ";
            this.DepositKind11_Title.Text = "�l��";
            this.DepositKind11_Title.Top = 0.0625F;
            this.DepositKind11_Title.Width = 0.71F;
            // 
            // DepositKind11
            // 
            this.DepositKind11.Border.BottomColor = System.Drawing.Color.Black;
            this.DepositKind11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind11.Border.LeftColor = System.Drawing.Color.Black;
            this.DepositKind11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind11.Border.RightColor = System.Drawing.Color.Black;
            this.DepositKind11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind11.Border.TopColor = System.Drawing.Color.Black;
            this.DepositKind11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.DepositKind11.DataField = "DiscountDeposit";
            this.DepositKind11.Height = 0.125F;
            this.DepositKind11.Left = 9.96875F;
            this.DepositKind11.MultiLine = false;
            this.DepositKind11.Name = "DepositKind11";
            this.DepositKind11.OutputFormat = resources.GetString("DepositKind11.OutputFormat");
            this.DepositKind11.Style = "ddo-char-set: 128; text-align: right; font-size: 7pt; font-family: �l�r �S�V�b�N; verti" +
                "cal-align: top; ";
            this.DepositKind11.Text = "1,234,567,890";
            this.DepositKind11.Top = 0.0625F;
            this.DepositKind11.Width = 0.71F;
            // 
            // Section_DepositKind11
            // 
            this.Section_DepositKind11.Border.BottomColor = System.Drawing.Color.Black;
            this.Section_DepositKind11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind11.Border.LeftColor = System.Drawing.Color.Black;
            this.Section_DepositKind11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind11.Border.RightColor = System.Drawing.Color.Black;
            this.Section_DepositKind11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind11.Border.TopColor = System.Drawing.Color.Black;
            this.Section_DepositKind11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Section_DepositKind11.DataField = "DiscountDeposit";
            this.Section_DepositKind11.Height = 0.125F;
            this.Section_DepositKind11.Left = 9.96875F;
            this.Section_DepositKind11.MultiLine = false;
            this.Section_DepositKind11.Name = "Section_DepositKind11";
            this.Section_DepositKind11.OutputFormat = resources.GetString("Section_DepositKind11.OutputFormat");
            this.Section_DepositKind11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.Section_DepositKind11.SummaryGroup = "SectionHeader";
            this.Section_DepositKind11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Section_DepositKind11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Section_DepositKind11.Text = "1,234,567,890";
            this.Section_DepositKind11.Top = 0.0625F;
            this.Section_DepositKind11.Width = 0.71F;
            // 
            // Total_DepositKind11
            // 
            this.Total_DepositKind11.Border.BottomColor = System.Drawing.Color.Black;
            this.Total_DepositKind11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind11.Border.LeftColor = System.Drawing.Color.Black;
            this.Total_DepositKind11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind11.Border.RightColor = System.Drawing.Color.Black;
            this.Total_DepositKind11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind11.Border.TopColor = System.Drawing.Color.Black;
            this.Total_DepositKind11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None;
            this.Total_DepositKind11.DataField = "DiscountDeposit";
            this.Total_DepositKind11.Height = 0.125F;
            this.Total_DepositKind11.Left = 9.96875F;
            this.Total_DepositKind11.MultiLine = false;
            this.Total_DepositKind11.Name = "Total_DepositKind11";
            this.Total_DepositKind11.OutputFormat = resources.GetString("Total_DepositKind11.OutputFormat");
            this.Total_DepositKind11.Style = "ddo-char-set: 128; text-align: right; font-weight: bold; font-size: 7pt; font-fam" +
                "ily: �l�r �S�V�b�N; vertical-align: top; ";
            this.Total_DepositKind11.SummaryGroup = "GrandTotalHeader";
            this.Total_DepositKind11.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group;
            this.Total_DepositKind11.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal;
            this.Total_DepositKind11.Text = "1,234,567,890";
            this.Total_DepositKind11.Top = 0.0625F;
            this.Total_DepositKind11.Width = 0.71F;
            // 
            // MAHNB02012P_04A4C
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
            this.PrintWidth = 10.813F;
            this.Sections.Add(this.PageHeader);
            this.Sections.Add(this.ExtraHeader);
            this.Sections.Add(this.TitleHeader);
            this.Sections.Add(this.GrandTotalHeader);
            this.Sections.Add(this.SectionHeader);
            this.Sections.Add(this.Detail);
            this.Sections.Add(this.SectionFooter);
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
            this.ReportStart += new System.EventHandler(this.MAHNB02012P_03A4C_ReportStart);
            ((System.ComponentModel.ISupportInitialize)(this.Deposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ReportTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_SortOrderName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_PrintTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label104)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label105)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind01_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind02_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind04_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind03_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind05_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind06_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind07_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind08_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind10_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind09_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_Deposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label109)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_AddUpSecName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_AddUpSecCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_Deposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MONEYKINDNAME13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind11_Title)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepositKind11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Section_DepositKind11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Total_DepositKind11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		 }

		#endregion


         #region �� ����R�[�h�̈���ݒ�
         /// <summary>
         /// ����R�[�h�̈���ݒ�
         /// </summary>
         /// <remarks>
         /// <br>Note       : ���|�[�g�̋���R�[�h�̈���ݒ�</br>
         /// <br>Programmer : 30413 ����</br>
         /// <br>Date		: 2008.07.11</br>
         /// </remarks>
         public void SettingKindName()
         {
             // --- ADD 2009/03/25 -------------------------------->>>>>
             string CT_FeeTitle = "�萔��";
             string CT_FeeDataField = "FeeDeposit";
             // --- DEL m.suzuki 2010/05/26 ---------->>>>>
             // ---------//ADD BY ������ on 2011/10/27 for Redmine#26259 ------------>>>>>>>>>>>>
             string CT_DiscountTitle = "�l��";
             string CT_DiscountDataField = "DiscountDeposit";
             // ---------//ADD BY ������ on 2011/10/27 for Redmine#26259 ------------<<<<<<<<<<<<
             // --- DEL m.suzuki 2010/05/26 ----------<<<<<

             string CT_DepositKind_No = "DepositKind_No";

             ArrayList depositKindCodeList = (ArrayList)this._otherDataList[1];

             // ��Ɨp���X�g�쐬
             #region ��Ɨp���X�g�쐬
             List<Label> titleList = new List<Label>();
             titleList.AddRange(new Label[] { 
                                                DepositKind01_Title,
                                                DepositKind02_Title,
                                                DepositKind03_Title,
                                                DepositKind04_Title,
                                                DepositKind05_Title,
                                                DepositKind06_Title,
                                                DepositKind07_Title,
                                                DepositKind08_Title,
                                                // --- UPD m.suzuki 2010/05/26 ---------->>>>>
                                                //DepositKind09_Title,                                              
                                                //DepositKind10_Title
                                                DepositKind09_Title,
                                                DepositKind11_Title//ADD BY ������ on 2011/10/27 for Redmine#26259
                                                // --- UPD m.suzuki 2010/05/26 ----------<<<<<
                                            });

             List<TextBox> detailList = new List<TextBox>();
             detailList.AddRange(new TextBox[] { 
                                                DepositKind01,
                                                DepositKind02,
                                                DepositKind03,
                                                DepositKind04,
                                                DepositKind05,
                                                DepositKind06,
                                                DepositKind07,
                                                DepositKind08,
                                                 // 2009/11/20 >>>
                                                //DepositKind09,                                               
                                                //DepositKind10
                                                DepositKind09,
                                                DepositKind11//ADD BY ������ on 2011/10/27 for Redmine#26259
                                                // 2009/11/20 <<<
                                             });

             List<TextBox> sectionList = new List<TextBox>();
             sectionList.AddRange(new TextBox[] {
                                                Section_DepositKind01,
                                                Section_DepositKind02,
                                                Section_DepositKind03,
                                                Section_DepositKind04,
                                                Section_DepositKind05,
                                                Section_DepositKind06,
                                                Section_DepositKind07,
                                                Section_DepositKind08,
                                                // 2009/11/20 >>>
                                                // �l���͂��̑��ƍ��Z�̈׍폜
                                                //Section_DepositKind09,                                               
                                                //Section_DepositKind10
                                                Section_DepositKind09,
                                                Section_DepositKind11//ADD BY ������ on 2011/10/27 for Redmine#26259
                                                // 2009/11/20 <<<
                                             });

             List<TextBox> totalList = new List<TextBox>();
             totalList.AddRange(new TextBox[] {
                                                Total_DepositKind01,
                                                Total_DepositKind02,
                                                Total_DepositKind03,
                                                Total_DepositKind04,
                                                Total_DepositKind05,
                                                Total_DepositKind06,
                                                Total_DepositKind07,
                                                Total_DepositKind08,
                                                // 2009/11/20 >>>
                                                // �l���͂��̑��ƍ��Z�̈׍폜
                                                //Total_DepositKind09,                                                
                                                //Total_DepositKind10
                                                Total_DepositKind09,
                                                Total_DepositKind11//ADD BY ������ on 2011/10/27 for Redmine#26259
                                                // 2009/11/20 <<<
                                             });
             #endregion

             int setColIndex = 0;

             // --- UPD m.suzuki 2010/05/26 ---------->>>>>
             //for (int index = 0; index <= 8; index++)
             for ( int index = 0; index < titleList.Count; index++ )
             // --- UPD m.suzuki 2010/05/26 ----------<<<<<
             {
                 if (index >= depositKindCodeList.Count)
                 {
                     // �萔���A�l���̐ݒ�
                     if (index == depositKindCodeList.Count)
                     {
                         // �萔��
                         titleList[setColIndex].Text = CT_FeeTitle;
                         detailList[setColIndex].DataField = CT_FeeDataField;
                         sectionList[setColIndex].DataField = CT_FeeDataField;
                         totalList[setColIndex].DataField = CT_FeeDataField;
                         // �l��
                         // 2009/11/20 Del >>>
                         // �l���͂��̑��ƍ��Z�̈׍폜
                         //---------ADD BY ������ on 2011/10/27 for Redmine#26259 ------>>>>>>>>
                         titleList[setColIndex + 1].Text = CT_DiscountTitle;
                         detailList[setColIndex + 1].DataField = CT_DiscountDataField;
                         sectionList[setColIndex + 1].DataField = CT_DiscountDataField;
                         totalList[setColIndex + 1].DataField = CT_DiscountDataField;
                         //---------ADD BY ������ on 2011/10/27 for Redmine#26259 -------<<<<<<<<<
                         // 2009/11/20 Del <<<
                     }
                 }
                 else
                 {
                     if ((int)depositKindCodeList[index] != -1)
                     {
                         int dataFieldIndex = index + 1;

                         titleList[setColIndex].Text = this._dicKindName[index];
                         detailList[setColIndex].DataField = CT_DepositKind_No + dataFieldIndex.ToString();
                         sectionList[setColIndex].DataField = CT_DepositKind_No + dataFieldIndex.ToString();
                         totalList[setColIndex].DataField = CT_DepositKind_No + dataFieldIndex.ToString();

                         setColIndex++;
                     }
                     else
                     {
                         continue;
                     }
                 }
             }

             // --- UPD m.suzuki 2010/05/26 ---------->>>>>
             //// �󎚑ΏۊO���ڂ��\����
             //for (int i = 7; i > 0; i--)
             //{
             //    if (setColIndex <= i)
             //    {
             //        titleList[i + 2].Visible = false;
             //        detailList[i + 2].Visible = false;
             //        sectionList[i + 2].Visible = false;
             //        totalList[i + 2].Visible = false;
             //    }
             //}

             //for ( int i = setColIndex + 1; i < titleList.Count; i++ )//DEL BY ������ on 2011/10/27 for Redmine#26259
             for (int i = setColIndex + 2; i < titleList.Count; i++)//ADD BY ������ on 2011/10/27 for Redmine#26259
             {
                 titleList[i].Visible = false;
                 detailList[i].Visible = false;
                 sectionList[i].Visible = false;
                 totalList[i].Visible = false;
             }
             // --- UPD m.suzuki 2010/05/26 ----------<<<<<      
             // --- ADD 2009/03/25 --------------------------------<<<<<
             // --- DEL 2009/03/25 -------------------------------->>>>>
            //for (int index = 0; index < 10; index++)
            //{
            //    if (index < this._dicKindName.Count)
            //    {
            //        switch (index)
            //        {
            //            case 0:
            //                {
            //                    this.DepositKind01_Title.Text = this._dicKindName[index];
            //                    break;
            //                }
            //            case 1:
            //                {
            //                    this.DepositKind02_Title.Text = this._dicKindName[index];
            //                    break;
            //                }
            //            case 2:
            //                {
            //                    this.DepositKind03_Title.Text = this._dicKindName[index];
            //                    break;
            //                }
            //            case 3:
            //                {
            //                    this.DepositKind04_Title.Text = this._dicKindName[index];
            //                    break;
            //                }
            //            case 4:
            //                {
            //                    this.DepositKind05_Title.Text = this._dicKindName[index];
            //                    break;
            //                }
            //            case 5:
            //                {
            //                    this.DepositKind06_Title.Text = this._dicKindName[index];
            //                    break;
            //                }
            //            case 6:
            //                {
            //                    this.DepositKind07_Title.Text = this._dicKindName[index];
            //                    break;
            //                }
            //            case 7:
            //                {
            //                    this.DepositKind08_Title.Text = this._dicKindName[index];
            //                    this.TitleHeader_Line1.Visible = false;
            //                    this.TitleHeader_Line2.Visible = true;
            //                    break;
            //                }
            //            case 8:
            //                {
            //                    this.DepositKind09_Title.Text = this._dicKindName[index];
            //                    break;
            //                }
            //            case 9:
            //                {
            //                    this.DepositKind10_Title.Text = this._dicKindName[index];
            //                    break;
            //                }
            //        }
            //    }
            //    else
            //    {
            //        switch (index)
            //        {
            //            case 0:
            //                {
            //                    this.DepositKind01_Title.Visible = false;
            //                    this.DepositKind01.Visible = false;
            //                    this.Section_DepositKind01.Visible = false;
            //                    this.Total_DepositKind01.Visible = false;
            //                    break;
            //                }
            //            case 1:
            //                {
            //                    this.DepositKind02_Title.Visible = false;
            //                    this.DepositKind02.Visible = false;
            //                    this.Section_DepositKind02.Visible = false;
            //                    this.Total_DepositKind02.Visible = false;
            //                    break;
            //                }
            //            case 2:
            //                {
            //                    this.DepositKind03_Title.Visible = false;
            //                    this.DepositKind03.Visible = false;
            //                    this.Section_DepositKind03.Visible = false;
            //                    this.Total_DepositKind03.Visible = false;
            //                    break;
            //                }
            //            case 3:
            //                {
            //                    this.DepositKind04_Title.Visible = false;
            //                    this.DepositKind04.Visible = false;
            //                    this.Section_DepositKind04.Visible = false;
            //                    this.Total_DepositKind04.Visible = false;
            //                    break;
            //                }
            //            case 4:
            //                {
            //                    this.DepositKind05_Title.Visible = false;
            //                    this.DepositKind05.Visible = false;
            //                    this.Section_DepositKind05.Visible = false;
            //                    this.Total_DepositKind05.Visible = false;
            //                    break;
            //                }
            //            case 5:
            //                {
            //                    this.DepositKind06_Title.Visible = false;
            //                    this.DepositKind06.Visible = false;
            //                    this.Section_DepositKind06.Visible = false;
            //                    this.Total_DepositKind06.Visible = false;
            //                    break;
            //                }
            //            case 6:
            //                {
            //                    this.DepositKind07_Title.Visible = false;
            //                    this.DepositKind07.Visible = false;
            //                    this.Section_DepositKind07.Visible = false;
            //                    this.Total_DepositKind07.Visible = false;
            //                    break;
            //                }
            //            case 7:
            //                {
            //                    this.DepositKind08_Title.Visible = false;
            //                    this.DepositKind08.Visible = false;
            //                    this.Section_DepositKind08.Visible = false;
            //                    this.Total_DepositKind08.Visible = false;
            //                    this.TitleHeader_Line1.Visible = true;
            //                    this.TitleHeader_Line2.Visible = false;
            //                    break;
            //                }
            //            case 8:
            //                {
            //                    this.DepositKind09_Title.Visible = false;
            //                    this.DepositKind09.Visible = false;
            //                    this.Section_DepositKind09.Visible = false;
            //                    this.Total_DepositKind09.Visible = false;
            //                    break;
            //                }
            //            case 9:
            //                {
            //                    this.DepositKind10_Title.Visible = false;
            //                    this.DepositKind10.Visible = false;
            //                    this.Section_DepositKind10.Visible = false;
            //                    this.Total_DepositKind10.Visible = false;
            //                    break;
            //                }
            //        }
            //    }
            //}
            // --- DEL 2009/03/25 --------------------------------<<<<<
        }
        #endregion
    }
}
