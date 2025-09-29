//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �L�����y�[�����ѕ\
// �v���O�����T�v   : �L�����y�[�����ѕ\ �t�h�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �c����
// �� �� ��  2011/05/19  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/07/11  �C�����e : Redmine �d�l�ύX #22915�A��Q�� #22858 �̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/07/12  �C�����e : Redmine �d�l�ύX #22934 �̑Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;

using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinEditors;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �L�����y�[�����ѕ\UI�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �L�����y�[�����ѕ\UI�t�H�[���N���X</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2011/05/19</br>
    /// <br></br>
    /// </remarks>
	public partial class PMKHN02050UA : Form,
                                IPrintConditionInpType,					// ���[���ʁi�������̓^�C�v�j
                                IPrintConditionInpTypeSelectedSection,	// ���[�Ɩ��i�������́j���_�I��
                                IPrintConditionInpTypePdfCareer,			// ���[�Ɩ��i�������́jPDF�o�͗����Ǘ�
                                IPrintConditionInpTypeGuidExecuter
	{
		#region �� Constructor
		/// <summary>
		/// �L�����y�[�����ѕ\UI�t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �L�����y�[�����ѕ\UI�t�H�[���N���X�̏���������уC���X�^���X�̐������s��</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/05/19</br>
		/// <br></br>
		/// </remarks>
		public PMKHN02050UA ()
		{
			InitializeComponent();
            
			// ��ƃR�[�h�擾
			this._enterpriseCode		= LoginInfoAcquisition.EnterpriseCode;

			// ���_�p��Hashtable�쐬
			this._selectedSectionList	= new Hashtable();

            this._secInfoSetAcs = new SecInfoSetAcs();          // ���_

            this._campaignStAcs = new CampaignStAcs();

			//���t�擾���i
			this._dateGet = DateGetAcs.GetInstance();
		}
		#endregion �� Constructor

		#region �� Private Member
		#region �� Interface member 

		//--IPrintConditionInpType�̃v���p�e�B�p�ϐ� ----------------------------------
        // ���o�{�^����Ԏ擾�v���p�e�B
        private bool _canExtract				= false;
        // PDF�o�̓{�^����Ԏ擾�v���p�e�B    
        private bool _canPdf					= true;
        // ����{�^����Ԏ擾�v���p�e�B
        private bool _canPrint					= true;
        // ���o�{�^���\���L���v���p�e�B
        private bool _visibledExtractButton		= false;
        // PDF�o�̓{�^���\���L���v���p�e�B	
        private bool _visibledPdfButton			= true;
        // ����{�^���\���L���v���p�e�B
        private bool _visibledPrintButton		= true;

        //--IPrintConditionInpTypeSelectedSection�̃v���p�e�B�p�ϐ� -------------------
        // �v�㋒�_�I��\���擾�v���p�e�B
        private bool _visibledSelectAddUpCd		= false;
        // ���_�I�v�V�����L��
        private bool _isOptSection				= false;
        // �{�Ћ@�\�L��
        private bool _isMainOfficeFunc			= false;
		// �I�����_���X�g
        private Hashtable _selectedSectionList	= new Hashtable();
		#endregion �� Interface member

		// ��ƃR�[�h
		private string _enterpriseCode = string.Empty;
		// ��ʃC���[�W�R���g���[�����i
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		// ���o�����N���X
        private CampaignRsltList _campaignRsltList;

		// �K�C�h�n�A�N�Z�X�N���X
		EmployeeAcs _employeeAcs;

        // ���Ӑ�K�C�h�p
        private UltraButton _customerGuideSender;

        // ���Ӑ�K�C�h����OK�t���O
        private bool _customerGuideOK;

        /// <summary>���_�A�N�Z�X�N���X</summary>
        private SecInfoSetAcs _secInfoSetAcs;

        //�L�����y�[���K�C�h�p
        private CampaignStAcs _campaignStAcs;

        // ���[�U�[�K�C�h�p
        private UserGuideAcs _userGuideAcs;

        // �O���[�v�R�[�h�K�C�h�p
        private BLGroupUAcs _blGroupUAcs;
        // BL�R�[�h�K�C�h
        private BLGoodsCdAcs _blGoodsCdAcs;

		//���t�擾���i
		private DateGetAcs _dateGet;

        // �L�����y�[���R�[�h�i�O��l�j
        private int _preCampaignCode;

        /// <summary>�L�����y�[�����{���_</summary>
        private string _campExecSecCode = string.Empty;

        private Control _errComponent;

		#endregion �� Private Member

		#region �� Private Const
		#region �� Interface member
        //--IPrintConditionInpTypePdfCareer�̃v���p�e�B�p�ϐ� -------------------------
		// �N���XID
		private const string ct_ClassID = "PMKHN02050UA";
		// �v���O����ID
		private const string ct_PGID = "PMKHN02050U";
		//// ���[����
		private const string PDF_PRINT_NAME = "�L�����y�[�����ѕ\";
		private string _printName = PDF_PRINT_NAME;
        // ���[�L�[	
		private const string PDF_PRINT_KEY = "461a402f-20c6-4b5e-817f-790237550131";
		private string _printKey = PDF_PRINT_KEY;

        private bool _campaignCodeExistFlg = true;
		#endregion �� Interface member

		// ExporerBar �O���[�v����
		private const string ct_ExBarGroupNm_ReportSelectGroup		= "ReportSelectGroup";		// �o�͏���
		private const string ct_ExBarGroupNm_PrintOderGroup         = "PrintOderGroup";
		private const string ct_ExBarGroupNm_PrintConditionGroup	= "PrintConditionGroup";	// ���o����

        //�G���[�������b�Z�[�W
		const string ct_NoExist = "�L�����y�[���R�[�h�����݂��܂���B";
        const string ct_GetError = "�L�����y�[���R�[�h�̎擾�Ɏ��s���܂����B";
        const string ct_NoInput = "�L�����y�[���R�[�h��ݒ肵�ĉ������B";
        const string ct_DateNoInput = "����͂��ĉ������B";
        const string ct_InputError = "�̓��͂��s���ł��B";
        const string ct_OutRange = "�L�����y�[���K�p���͈͊O�ł��B";
        const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂�";
        const string ct_NotOnYearError = "12�����ȓ��œ��͂��ĉ������B";

		#endregion

		#region �� IPrintConditionInpType �����o
		#region �� Public Event
		/// <summary> �e�c�[���o�[�ݒ�C�x���g </summary>
		public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
		#endregion �� Public Event

		#region �� Public Property
		/// <summary> ���o�{�^����Ԏ擾�v���p�e�B </summary>
		public bool CanExtract
		{
			get { return this._canExtract; }
		}

		/// <summary> PDF�o�̓{�^����Ԏ擾�v���p�e�B </summary>
		public bool CanPdf
		{
			get { return this._canPdf; }
		}

		/// <summary> ����{�^����Ԏ擾�v���p�e�B </summary>
		public bool CanPrint
		{
			get { return this._canPrint; }
		}

        /// <summary> ���o�{�^���\���L���v���p�e�B </summary>
		public bool VisibledExtractButton
		{
			get { return this._visibledExtractButton; }
		}

        /// <summary> PDF�o�̓{�^���\���L���v���p�e�B </summary>
		public bool VisibledPdfButton
		{
			get { return this._visibledPdfButton; }
		}

        /// <summary> ����{�^���\���v���p�e�B </summary>
		public bool VisibledPrintButton
		{
			get { return this._visibledPrintButton; }
		}

		#endregion �� Public Property

		#region �� Public Method
		#region �� ���o����
		/// <summary>
        /// ���o����
        /// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <returns>0( �Œ� )</returns>
		public int Extract ( ref object parameter )
		{
            // ���o�����͖����̂ŏ����I��
            return 0;
		}
		#endregion

		#region �� �������
		/// <summary>
		/// �������
		/// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: ����������s���B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
		public int Print ( ref object parameter )
		{
			SFCMN06001U printDialog	= new SFCMN06001U();		// ���[�I���K�C�h
			SFCMN06002C printInfo	= parameter as SFCMN06002C;	// ������p�����[�^

			// ��ƃR�[�h���Z�b�g
			printInfo.enterpriseCode	= this._enterpriseCode;
			printInfo.kidopgid			= ct_PGID;				// �N��PGID

			// PDF�o�͗���p
			printInfo.key				= this._printKey;
			printInfo.prpnm				= this._printName;

            // �I���\�Ȓ��[�̃��X�g�͋N�����̃p�����[�^�Ő���
            switch (this._campaignRsltList.TotalType)
            {
                case CampaignRsltList.TotalTypeState.EachGoods: // ���i��
                    {
                        // ����^�C�v:���Ԃ̏ꍇ
                        if ((int)this.tComboEditor_PrintType.Value == 1)
                        {
                            printInfo.PrintPaperSetCd = 20;
                        }
                        else
                        {
                            printInfo.PrintPaperSetCd = 10;
                        }
                        break;
                    }
                case CampaignRsltList.TotalTypeState.EachCustomer: // ���Ӑ��
                    {
                        if ((int)this.tComboEditor_PrintType.Value == 1)
                        {
                            printInfo.PrintPaperSetCd = 12;
                        }
                        else
                        {
                            printInfo.PrintPaperSetCd = 11;
                        }
                        break;
                    }
                case CampaignRsltList.TotalTypeState.EachEmployee: // �S���ҕ�
                    {
                        if ((int)this.tComboEditor_PrintType.Value == 1)
                        {
                            printInfo.PrintPaperSetCd = 22;
                        }
                        else
                        {
                            printInfo.PrintPaperSetCd = 21; 
                        }
                        break;
                    }
                case CampaignRsltList.TotalTypeState.EachAcceptOdr: // �󒍎ҕ�
                    {
                        if ((int)this.tComboEditor_PrintType.Value == 1)
                        {
                            printInfo.PrintPaperSetCd = 32;
                        }
                        else
                        {
                            printInfo.PrintPaperSetCd = 31;
                        }
                        break;
                    }
                case CampaignRsltList.TotalTypeState.EachPrinter: // ���s�ҕ�
                    {
                        if ((int)this.tComboEditor_PrintType.Value == 1)
                        {
                            printInfo.PrintPaperSetCd = 42;
                        }
                        else
                        {
                            printInfo.PrintPaperSetCd = 41;
                        }
                        break;
                    }
                case CampaignRsltList.TotalTypeState.EachArea: // �n���
                    {
                        if ((int)this.tComboEditor_PrintType.Value == 1)
                        {
                            printInfo.PrintPaperSetCd = 52;
                        }
                        else
                        {
                            printInfo.PrintPaperSetCd = 51;
                        }
                        break;
                    }
                case CampaignRsltList.TotalTypeState.EachSales: // �̔��敪��
                    {
                        if ((int)this.tComboEditor_PrintType.Value == 1)
                        {
                            printInfo.PrintPaperSetCd = 62;
                        }
                        else
                        {
                            printInfo.PrintPaperSetCd = 61;
                        }
                        break;
                    }
            }
            
			// ��ʁ����o�����N���X
			int status = this.SetExtraInfoFromScreen();
			if( status != 0 )
			{
				return -1;
			}

			// ���o�����̐ݒ�
			printInfo.jyoken			= this._campaignRsltList;
			printDialog.PrintInfo		= printInfo;
			
			// ���[�I���K�C�h
			DialogResult dialogResult = printDialog.ShowDialog();

			if( printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN ) 
            {
				MsgDispProc( emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���", 0 );
			}

			parameter = printInfo;

			return printInfo.status;
		}
		#endregion

		#region �� ����O�m�F����
		/// <summary>
		/// ����O�m�F����
		/// </summary>
		/// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: ����O�m�F�������s���B(���̓`�F�b�N�Ȃ�)</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
		public bool PrintBeforeCheck ()
		{
			bool status = true;

			string errMessage = string.Empty;

            _errComponent = null;
			if( !this.ScreenInputCheck( ref errMessage, ref _errComponent ) )
			{
                if (!string.IsNullOrEmpty(errMessage))
                {
                    // ���b�Z�[�W��\��
                    this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                    // �R���g���[���Ƀt�H�[�J�X���Z�b�g
                    if (_errComponent != null)
                    {
                        // �L�����y�[���R�[�h�i�O��l�j
                        if (_errComponent == this.tNedit_CampaignCode)
                        {
                            this.tNedit_CampaignCode.Text = this._preCampaignCode.ToString();
                            if ("000000".Equals(this._preCampaignCode.ToString().PadLeft(6, '0')))
                            {
                                this.tNedit_CampaignCode.Clear();
                            }
                        }

                        //errComponent.Focus();
                        this.SetControlFocus(_errComponent);
                    }
                }
				status = false;
			}

			return status;
		}
		#endregion

		#region �� ��ʕ\������
		/// <summary>
		/// ��ʕ\������
		/// </summary>
		/// <param name="parameter">�N���p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ��ʕ\�����s���B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
		public void Show( object parameter )
		{
			this._campaignRsltList = new CampaignRsltList();

            // ���o�����ɋN���p�����[�^���Z�b�g
            if (parameter.ToString().CompareTo("0") == 0)
            {
                // 0:���i��
                this._campaignRsltList.TotalType = CampaignRsltList.TotalTypeState.EachGoods;
            }
            else if (parameter.ToString().CompareTo("1") == 0)
            {
                // 1:���Ӑ��
                this._campaignRsltList.TotalType = CampaignRsltList.TotalTypeState.EachCustomer;
            }
            else if (parameter.ToString().CompareTo("2") == 0)
            {
                // 2:�S���ҕ�
                this._campaignRsltList.TotalType = CampaignRsltList.TotalTypeState.EachEmployee;
            }
            else if (parameter.ToString().CompareTo("3") == 0)
            {
                // 3:�󒍎ҕ�
                this._campaignRsltList.TotalType = CampaignRsltList.TotalTypeState.EachAcceptOdr;
            }
            else if (parameter.ToString().CompareTo("4") == 0)
            {
                // 4:���s�ҕ�
                this._campaignRsltList.TotalType = CampaignRsltList.TotalTypeState.EachPrinter;
            }
            else if (parameter.ToString().CompareTo("5") == 0)
            {
                // 5:�n���
                this._campaignRsltList.TotalType = CampaignRsltList.TotalTypeState.EachArea;
            }
            else if (parameter.ToString().CompareTo("6") == 0)
            {
                // 6:�̔��敪��
                this._campaignRsltList.TotalType = CampaignRsltList.TotalTypeState.EachSales;
            }

			this.Show();
			return;
		}
		#endregion

		#endregion �� Public Method
		#endregion �� IPrintConditionInpType �����o

		#region �� IPrintConditionInpTypeSelectedSection �����o
		#region �� Public Property

        /// <summary> �{�Ћ@�\�v���p�e�B </summary>
		public bool IsMainOfficeFunc
		{
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
		}

        /// <summary> ���_�I�v�V�����v���p�e�B </summary>
		public bool IsOptSection
		{
            get { return _isOptSection; }
            set { _isOptSection = value; }
		}

        /// <summary> �v�㋒�_�I��\���擾�v���p�e�B </summary>
		public bool VisibledSelectAddUpCd
		{
            get { return _visibledSelectAddUpCd; }
		}

		#endregion �� Public Property

		#region �� Public Method

		#region �� ���_�I������
		/// <summary>
		/// ���_�I������
		/// </summary>
		/// <param name="sectionCode">�I�����_�R�[�h</param>
		/// <param name="checkState">�I�����</param>
        /// <remarks>
        /// <br>Note		: ���_�I���������s���B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
		public void CheckedSection ( string sectionCode, CheckState checkState )
		{
            // ���_��I��������
            if ( checkState == CheckState.Checked )
            {
                // �S�Ђ��I�����ꂽ�ꍇ
                if ( sectionCode == "0" )
                {
                    this._selectedSectionList.Clear();

                }

                if ( !this._selectedSectionList.ContainsKey( sectionCode ) )
                {
					this._selectedSectionList.Add(sectionCode, checkState);
                }

            }
            // ���_�I��������������
            else if ( checkState == CheckState.Unchecked )
            {
                if ( this._selectedSectionList.ContainsKey( sectionCode ) )
                {
                    this._selectedSectionList.Remove( sectionCode );
                }
            }
		}
		#endregion

		#region �� �����I���v�㋒�_�ݒ菈��( ������ )
		/// <summary>
		/// �����I���v�㋒�_�ݒ菈��( ������ )
		/// </summary>
		/// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: ������</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
		public void InitSelectAddUpCd ( int addUpCd )
		{
			// �v�㋒�_�I�����Ȃ��̂Ŗ�����
		}
		#endregion

		#region �� �����I�����_�ݒ菈��
		/// <summary>
		/// �����I�����_�ݒ菈��
		/// </summary>
		/// <param name="sectionCodeLst">�I�����_�R�[�h���X�g</param>
        /// <remarks>
        /// <br>Note		: ���_���X�g�̏��������s���B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
		public void InitSelectSection ( string[] sectionCodeLst )
		{
            // �I�����X�g������
            this._selectedSectionList.Clear();
            foreach ( string wk in sectionCodeLst )
            {
				this._selectedSectionList.Add(wk, CheckState.Checked);
            }
		}
		#endregion

		#region �� �������_�I��\���`�F�b�N����
        /// <summary>
        /// �������_�I��\���`�F�b�N����
        /// </summary>
        /// <param name="isDefaultState">true�F�X���C�_�[�\���@false�F�X���C�_�[��\��</param>
        /// <remarks>
        /// <br>Note		: ���_�I���X���C�_�[�̕\���L���𔻒肷��B</br>
        /// <br>			: ���_�I�v�V�����A�{�Ћ@�\�ȊO�̌ʂ̕\���L��������s���B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
		public bool InitVisibleCheckSection ( bool isDefaultState )
		{
            return isDefaultState;
		}
		#endregion

		#region �� �v�㋒�_�I������( ������ )
        /// <summary>
        /// �v�㋒�_�I������( ������ )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: ������</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
		public void SelectedAddUpCd (int addUpCd )
		{
            // �v�㋒�_�I�����Ȃ��̂Ŗ�����
		}
		#endregion

		#endregion �� Public Method
		#endregion �� IPrintConditionInpTypeSelectedSection �����o

		#region �� IPrintConditionInpTypePdfCareer �����o
		#region �� Public Property

        /// <summary> ���[�L�[�v���p�e�B </summary>
		public string PrintKey
		{
            get { return this._printKey; }
		}

        /// <summary> ���[���v���p�e�B </summary>
		public string PrintName
		{
			get { return _printName; }
		}

		#endregion �� Public Method
		#endregion �� IPrintConditionInpTypePdfCareer �����o

        #region �� IPrintConditionInpTypeGuidExecuter �����o
        #region �� Public Event
        /// <summary> �e����ݒ�C�x���g </summary>
        public event ParentPrint ParentPrintCall;
        /// <summary> �e�c�[���o�[�K�C�h�ݒ�C�x���g </summary>
        public event ParentToolbarGuideSettingEventHandler ParentToolbarGuideSettingEvent;
        #endregion �� Public Event

        #region �� Public Method
        #region �� �K�C�h�{�^���̏���
        /// <summary>
        /// �K�C�h�{�^���̏���
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �K�C�h�{�^�����N���b�N����B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        public void ExcuteGuide(object sender, EventArgs e)
        {
            if (this.tNedit_CampaignCode.Focused)
            {
                uButton_CampaignCodeGuid_Click(uButton_CampaignGuid, e);
            }
            else if (this.tEdit_SalesEmployeeCode_St.Focused)
            {
                uButton_EmployeeCdStGuid_Click(uButton_EmployeeCdStGuid, e);
            }
            else if (this.tEdit_SalesEmployeeCode_Ed.Focused)
            {
                uButton_EmployeeCdStGuid_Click(uButton_EmployeeCdEdGuid, e);
            }
            else if (this.tEdit_SalesInputCode_St.Focused)
            {
                uButton_EmployeeCdStGuid_Click(uButton_PrinterStGuid, e);
            }
            else if (this.tEdit_SalesInputCode_Ed.Focused)
            {
                uButton_EmployeeCdStGuid_Click(uButton_PrinterEdGuid, e);
            }
            else if (this.tNedit_SalesAreaCode_St.Focused)
            {
                uButton_AreaCdStGuide_Click(uButton_AreaCdStGuide, e);
            }
            else if (this.tNedit_SalesAreaCode_Ed.Focused)
            {
                uButton_AreaCdStGuide_Click(uButton_BLCodeEdGuide, e);
            }
            else if (this.tNedit_CustomerCode_St.Focused)
            {
                uButton_CustomerCdStGuide_Click(uButton_CustomerCdStGuide, e);
            }
            else if (this.tNedit_CustomerCode_Ed.Focused)
            {
                uButton_CustomerCdStGuide_Click(uButton_CustomerCdEdGuide, e);
            }
            else if (this.tNedit_SalesCode_St.Focused)
            {
                uButton_GuideCodeStGuide_Click(uButton_GuideCodeStGuide, e);
            }
            else if (this.tNedit_SalesCode_Ed.Focused)
            {
                uButton_GuideCodeStGuide_Click(uButton_GuideCodeEdGuide, e);
            }
            else if (this.tNedit_GroupCode_St.Focused)
            {
                uButton_GroupCodeStGuide_Click(uButton_GroupCodeStGuide, e);
            }
            else if (this.tNedit_GroupCode_Ed.Focused)
            {
                uButton_GroupCodeStGuide_Click(uButton_GroupCodeEdGuide, e);
            }
            else if (this.tNedit_BLCode_St.Focused)
            {
                uButton_BLCodeStGuide_Click(uButton_BLCodeStGuide, e);
            }
            else if (this.tNedit_BLCode_Ed.Focused)
            {
                uButton_BLCodeStGuide_Click(uButton_BLCodeEdGuide, e);
            }
            else if (this.tEdit_AcceptOdrCode_St.Focused)
            {
                uButton_EmployeeCdStGuid_Click(uButton_AcceptOdrCdStGuid, e);
            }
            else if (this.tEdit_AcceptOdrCode_Ed.Focused)
            {
                uButton_EmployeeCdStGuid_Click(uButton_AcceptOdrCdEdGuid, e);
            }
        }
        #endregion
        #endregion �� Public Method
        #endregion �� IPrintConditionInpTypeGuidExecuter �����o

        #region �� Private Method
        #region �� ��ʏ������֌W
        #region �� ��ʏ���������
        /// <summary>
		/// ��ʏ���������
		/// </summary>
        /// <remarks>
        /// <br>Note		: ���͍��ڂ̏��������s��</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/05/19</br>
		/// </remarks>
		private int InitializeScreen( out string errMsg )
		{            
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;
                        
			try
            {                
                #region �o�͏���                
                // ����^�C�v
                this.tComboEditor_PrintType.Value = 0;

                // ���גP��
                this.tComboEditor_Detail.Value = 0;

                // ���v�P��
                this.tComboEditor_Total.Value = 0;
               
                #endregion

                #region ��ʃR���|�[�l���g�̐���
                // �o�͏�
                Infragistics.Win.ValueListItem listItem;

                switch (this._campaignRsltList.TotalType)
                {
                    case CampaignRsltList.TotalTypeState.EachGoods: // ���i��
                        {
                            // ���y�[�W
                            this.ulCheckEdt_Section.Checked = true;
                            this.ulCheckEdt_Emp.Visible = false;
                            this.ulCheckEdt_Area.Visible = false;
                            // �\�[�g��
                            this.OutputSort_panel.Visible = false;
                            this.tComboEditor_OutputSort.Value = 0;
                            this.ultraExplorerBarContainerControl1.Height = this.PrintSort_panel.Location.Y + 4;
                            this.PrintSort_panel.Location = this.OutputSort_panel.Location;
                            // ���o����
                            this.salesEmployee_panel.Visible = false;
                            // ----- UPD 2011/07/11 ----->>>>>
                            //this.Customer_panel.Visible = false;
                            this.Customer_panel.Visible = true;
                            this.uebcc_ExtractCondition.Height = this.GroupCode_panel.Location.Y + 4;
                            // ----- UPD 2011/07/11 -----<<<<<
                            this.GuideCode_panel.Visible = false;
                            this.GroupCode_panel.Location = this.salesEmployee_panel.Location;
                            this.BLCode_panel.Location = this.Customer_panel.Location;
                            this.Customer_panel.Location = new Point(this.GuideCode_panel.Location.X, this.GuideCode_panel.Location.Y + 4); // ADD 2011/07/11
                            // this.uebcc_ExtractCondition.Height = this.GuideCode_panel.Location.Y + 4; // DEL 2011/07/11
                            
                            break;
                        }
                    case CampaignRsltList.TotalTypeState.EachCustomer: // ���Ӑ��
                        {
                            // �Ώۓ��t(�J�n)(�I��) = ��
                            this.tde_SalesDateSt.Clear();
                            this.tde_SalesDateEd.Clear();
                            // ���y�[�W
                            this.ulCheckEdt_Section.Checked = true;
                            this.ulCheckEdt_Emp.Visible = true;
                            this.ulCheckEdt_Emp.Text = "���Ӑ斈�ŉ���";
                            // �\�[�g��
                            this.OutputSort_panel.Visible = true;
                            this.tComboEditor_OutputSort.Value = 0;
                            this.PrintSort_panel.Visible = true;
                            // ���o����
                            this.Customer_panel.Visible = true;
                            this.salesEmployee_panel.Visible = false;
                            this.GuideCode_panel.Visible = false;
                            this.GroupCode_panel.Visible = false;
                            this.BLCode_panel.Visible = false;
                            this.Customer_panel.Location = this.salesEmployee_panel.Location;
                            this.uebcc_ExtractCondition.Height = 35;
                            this.tNedit_CustomerCode_St.Value = string.Empty;
                            this.tNedit_CustomerCode_Ed.Value = string.Empty;
                            break;
                        }
                    case CampaignRsltList.TotalTypeState.EachEmployee: // �S���ҕ�
                        {
                            //���y�[�W
                            this.ulCheckEdt_Section.Checked = true;
                            this.tComboEditor_OutputSort.Items.Clear();

                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.Tag = 0;
                            listItem.DataValue = 0;
                            listItem.DisplayText = "0�F�S����";
                            this.tComboEditor_OutputSort.Items.Add(listItem);

                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.Tag = 1;
                            listItem.DataValue = 1;
                            listItem.DisplayText = "1�F���Ӑ�";
                            this.tComboEditor_OutputSort.Items.Add(listItem);

                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.Tag = 2;
                            listItem.DataValue = 2;
                            listItem.DisplayText = "2�F�S���ҁ|���_";
                            this.tComboEditor_OutputSort.Items.Add(listItem);

                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.Tag = 3;
                            listItem.DataValue = 3;
                            listItem.DisplayText = "3�F�Ǘ����_";
                            this.tComboEditor_OutputSort.Items.Add(listItem);

                            this.tComboEditor_OutputSort.Value = 0;
                            this.Customer_panel.Visible = true;
                            this.GuideCode_panel.Visible = false;
                            this.GroupCode_panel.Visible = false;
                            this.BLCode_panel.Visible = false;
                            this.uebcc_ExtractCondition.Height = this.GuideCode_panel.Location.Y + 4;
                            break;
                        }
                    case CampaignRsltList.TotalTypeState.EachAcceptOdr: // �󒍎ҕ�
                        {
                            //���y�[�W
                            this.ulCheckEdt_Section.Checked = true;
                            this.ulCheckEdt_Emp.Visible = true;
                            this.ulCheckEdt_Emp.Text = "�󒍎Җ��ŉ���";
                            //���o����
                            this.tComboEditor_OutputSort.Items.Clear();

                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.Tag = 0;
                            listItem.DataValue = 0;
                            listItem.DisplayText = "0�F�󒍎�";
                            this.tComboEditor_OutputSort.Items.Add(listItem);

                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.Tag = 1;
                            listItem.DataValue = 1;
                            listItem.DisplayText = "1�F���Ӑ�";
                            this.tComboEditor_OutputSort.Items.Add(listItem);

                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.Tag = 2;
                            listItem.DataValue = 2;
                            listItem.DisplayText = "2�F�󒍎ҁ|���_";
                            this.tComboEditor_OutputSort.Items.Add(listItem);

                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.Tag = 3;
                            listItem.DataValue = 3;
                            listItem.DisplayText = "3�F�Ǘ����_";
                            this.tComboEditor_OutputSort.Items.Add(listItem);

                            this.tComboEditor_OutputSort.Value = 0;

                            // ��\���̍��ڐ���
                            this.salesEmployee_panel.Visible = false;
                            this.GuideCode_panel.Visible = false;
                            this.GroupCode_panel.Visible = false;
                            this.BLCode_panel.Visible = false;
                            this.AcceptOdr_panel.Visible = true;
                            this.AcceptOdr_panel.Location = this.salesEmployee_panel.Location;
                            this.uebcc_ExtractCondition.Height = this.GuideCode_panel.Location.Y + 4;
                            break;
                        }
                    case CampaignRsltList.TotalTypeState.EachPrinter: // ���s�ҕ�
                        {
                            //���y�[�W
                            this.ulCheckEdt_Section.Checked = true;
                            this.ulCheckEdt_Emp.Visible = true;
                            this.ulCheckEdt_Emp.Text = "���s�Җ��ŉ���";
                            //���o����
                            this.tComboEditor_OutputSort.Items.Clear();

                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.Tag = 0;
                            listItem.DataValue = 0;
                            listItem.DisplayText = "0�F���s��";
                            this.tComboEditor_OutputSort.Items.Add(listItem);

                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.Tag = 1;
                            listItem.DataValue = 1;
                            listItem.DisplayText = "1�F���Ӑ�";
                            this.tComboEditor_OutputSort.Items.Add(listItem);

                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.Tag = 2;
                            listItem.DataValue = 2;
                            listItem.DisplayText = "2�F���s�ҁ|���_";
                            this.tComboEditor_OutputSort.Items.Add(listItem);

                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.Tag = 3;
                            listItem.DataValue = 3;
                            listItem.DisplayText = "3�F�Ǘ����_";
                            this.tComboEditor_OutputSort.Items.Add(listItem);

                            this.tComboEditor_OutputSort.Value = 0;

                            // ��\���̍��ڐ���
                            this.salesEmployee_panel.Visible = false;
                            this.GuideCode_panel.Visible = false;
                            this.GroupCode_panel.Visible = false;
                            this.BLCode_panel.Visible = false;
                            this.Printer_panel.Visible = true;
                            this.Printer_panel.Location = this.salesEmployee_panel.Location;
                            this.uebcc_ExtractCondition.Height = this.GuideCode_panel.Location.Y + 4;
                            break;
                        }
                    case CampaignRsltList.TotalTypeState.EachArea: // �n���
                        {
                            this.ulCheckEdt_Section.Checked = true;

                            this.tComboEditor_OutputSort.Items.Clear();

                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.Tag = 0;
                            listItem.DataValue = 0;
                            listItem.DisplayText = "0�F�n��";
                            this.tComboEditor_OutputSort.Items.Add(listItem);

                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.Tag = 1;
                            listItem.DataValue = 1;
                            listItem.DisplayText = "1�F���Ӑ�";
                            this.tComboEditor_OutputSort.Items.Add(listItem);

                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.Tag = 2;
                            listItem.DataValue = 2;
                            listItem.DisplayText = "2�F�n��|���_";
                            this.tComboEditor_OutputSort.Items.Add(listItem);

                            listItem = new Infragistics.Win.ValueListItem();
                            listItem.Tag = 3;
                            listItem.DataValue = 3;
                            listItem.DisplayText = "3�F�Ǘ����_";
                            this.tComboEditor_OutputSort.Items.Add(listItem);

                            this.tComboEditor_OutputSort.Value = 0;

                            // ��\���̍��ڐ���
                            this.ulCheckEdt_Area.Visible = true;
                            this.ulCheckEdt_Area.Location = this.ulCheckEdt_Emp.Location;

                            this.salesEmployee_panel.Visible = false;
                            this.GuideCode_panel.Visible = false;
                            this.GroupCode_panel.Visible = false;
                            this.BLCode_panel.Visible = false;
                            this.AcceptOdr_panel.Visible = false;
                            this.Area_panel.Visible = true;
                            this.Area_panel.Location = this.salesEmployee_panel.Location;
                            this.uebcc_ExtractCondition.Height = this.GuideCode_panel.Location.Y + 4;
                            break;
                        }
                    case CampaignRsltList.TotalTypeState.EachSales: // �̔��敪��
                        {
                            this.ultraExplorerBarContainerControl1.Height = this.PrintSort_panel.Location.Y + 4;
                            this.uebcc_ExtractCondition.Height = 79 + 4;
                            //���y�[�W
                            this.ulCheckEdt_Section.Checked = true;
                            this.ulCheckEdt_Emp.Visible = false;
                            //�\�[�g��
                            this.OutputSort_panel.Visible = false;
                            this.PrintSort_panel.Location = this.OutputSort_panel.Location;
                            //���o����
                            this.salesEmployee_panel.Visible = false;
                            this.GuideCode_panel.Location = this.salesEmployee_panel.Location;

                            // ��\���̍��ڐ���
                            this.salesEmployee_panel.Visible = false;
                            this.GroupCode_panel.Visible = false;
                            this.BLCode_panel.Visible = false;
                            break;
                        }
                }

                // �����
                this.tComboEditor_PrintSort.Value = 0;

				// �K�C�h�{�^���ݒ�
                this.SetIconImage(this.uButton_CampaignGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_EmployeeCdStGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_EmployeeCdEdGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_AcceptOdrCdStGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_AcceptOdrCdEdGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_CustomerCdStGuide, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_CustomerCdEdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_GuideCodeStGuide, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_GuideCodeEdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_GroupCodeStGuide, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_GroupCodeEdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_BLCodeStGuide, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_BLCodeEdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_AreaCdStGuide, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_AreaCdEdGuide, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_PrinterStGuid, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_PrinterEdGuid, Size16_Index.STAR1);
                #endregion
			}
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}

			return status;
		}
		#endregion

		#region �� �{�^���A�C�R���ݒ菈��
		/// <summary>
		/// �{�^���A�C�R���ݒ菈��
		/// </summary>
		/// <param name="settingControl">�A�C�R���Z�b�g����R���g���[��</param>
		/// <param name="iconIndex">�A�C�R���C���f�b�N�X</param>
		private void SetIconImage ( object settingControl, Size16_Index iconIndex )
		{
			((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
			((UltraButton)settingControl).Appearance.Image = iconIndex;
		}
		#endregion
		#endregion �� ��ʏ������֌W

		#region �� ����O����
		#region �� ���̓`�F�b�N����		
		/// <summary>
		/// ���̓`�F�b�N����
		/// </summary>
		/// <param name="errMessage">�G���[���b�Z�[�W</param>
		/// <param name="errComponent">�G���[�����R���|�[�l���g</param>
		/// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;
            DateGetAcs.CheckDateRangeResult cdrResult;
            CampaignSt campaignSt;
            int campaignCode = 0;

            // ����߰ݺ���
            if (string.IsNullOrEmpty(this.tNedit_CampaignCode.Text) || "000000".Equals(this.tNedit_CampaignCode.Text.PadLeft(6, '0')))
            {
                errMessage = string.Format("{0}", ct_NoInput);
                errComponent = this.tNedit_CampaignCode;

                this.tNedit_CampaignCode.Clear();
                this.tNedit_CampaignName.Clear();
                this.tDateEdit_ApplyDateSt.Clear();
                this.tDateEdit_ApplyDateEd.Clear();

                this._preCampaignCode = 0;

                status = false;
                return status;
            }

            else if (!string.IsNullOrEmpty(this.tNedit_CampaignCode.Text))
            {
                campaignCode = Convert.ToInt32(this.tNedit_CampaignCode.Text);

                int campStatus = this._campaignStAcs.Read(out campaignSt, this._enterpriseCode, campaignCode);

                if (campStatus != 0)
                {
                    errMessage = string.Format("{0}", ct_NoExist);
                    errComponent = this.tNedit_CampaignCode;

                    status = false;
                    return status;
                }
                else
                {
                    if (campaignSt.LogicalDeleteCode != 0)
                    {
                        errMessage = string.Format("{0}", ct_NoExist);
                        errComponent = this.tNedit_CampaignCode;

                        status = false;
                        return status;
                    }
                    else
                    {
                        this.tNedit_CampaignCode_Leave(null, null);
                    }
                }
            }
            else
            {
                if (this.checkCampaignCode() != 0)
                {
                    status = false;
                    return status;
                }
            }

            // �Ώۓ��t
            if ((int)this.tComboEditor_PrintType.Value != 2 && CallCheckDateRange(out cdrResult, ref tde_SalesDateSt, ref tde_SalesDateEd, false, true, true) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            errMessage = string.Format("�J�n�Ώۓ��t{0}", ct_InputError);
                            errComponent = this.tde_SalesDateSt;
                            status = false;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            errMessage = string.Format("�I���Ώۓ��t{0}", ct_InputError);
                            errComponent = this.tde_SalesDateEd;
                            status = false;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("�J�n�Ώۓ��t{0}", ct_InputError);
                            errComponent = this.tde_SalesDateSt;
                            status = false;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("�I���Ώۓ��t{0}", ct_InputError);
                            errComponent = this.tde_SalesDateEd;
                            status = false;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("�Ώۓ��t{0}", ct_RangeError);
                            errComponent = this.tde_SalesDateEd;
                            status = false;
                        }
                        break;
                    default:
                        {
                            //�͈͂�12�����𒴂���
                            if (!DateCheck(tde_SalesDateEd.GetDateTime(), tde_SalesDateSt.GetDateTime()))
                            {
                                errMessage = string.Format("{0}", ct_NotOnYearError);
                                errComponent = this.tde_SalesDateEd;
                                status = false;
                            }
                        }
                        break;
                }
            }
            else if ((int)this.tComboEditor_PrintType.Value == 2)
            {
                if (CallCheckDateRange(out cdrResult, ref tDateEdit_St, ref tDateEdit_End, false, true, true) == false)
                {
                    switch (cdrResult)
                    {
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                            {
                                errMessage = string.Format("�J�n�Ώۓ��t{0}", ct_DateNoInput);
                                errComponent = this.tDateEdit_St;
                                status = false;
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                            {
                                errMessage = string.Format("�I���Ώۓ��t{0}", ct_DateNoInput);
                                errComponent = this.tDateEdit_End;
                                status = false;
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                            {
                                errMessage = string.Format("�J�n�Ώۓ��t{0}", ct_InputError);
                                errComponent = this.tDateEdit_St;
                                status = false;
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                            {
                                errMessage = string.Format("�I���Ώۓ��t{0}", ct_InputError);
                                errComponent = this.tDateEdit_End;
                                status = false;
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                            {
                                errMessage = string.Format("�Ώۓ��t{0}", ct_RangeError);
                                errComponent = this.tDateEdit_End;
                                status = false;
                            }
                            break;
                        default:
                            {
                                //�͈͂�12�����𒴂���
                                if (!DateCheck(tDateEdit_End.GetDateTime(), tDateEdit_St.GetDateTime()))
                                {
                                    errMessage = string.Format("{0}", ct_NotOnYearError);
                                    errComponent = this.tDateEdit_End;
                                    status = false;
                                }
                            }
                            break;
                    }

                }
            }

            if (status)
            {
                if ((int)this.tComboEditor_PrintType.Value != 2)
                {
                    DateTime staratDate1;
                    DateTime endDate1;
                    DateTime staratDate2;
                    DateTime endDate2;
                    this._dateGet.GetDaysFromMonth(this.tde_SalesDateSt.GetDateTime(), out staratDate1, out endDate1);
                    this._dateGet.GetDaysFromMonth(this.tde_SalesDateEd.GetDateTime(), out staratDate2, out endDate2);

                    if (staratDate1 < this.tDateEdit_ApplyDateSt.GetDateTime() &&
                         endDate2 < this.tDateEdit_ApplyDateSt.GetDateTime())
                    {
                        errMessage = string.Format("{0}", ct_OutRange);
                        errComponent = this.tde_SalesDateEd;
                        status = false;
                        return status;
                    }

                    if (staratDate1 > this.tDateEdit_ApplyDateEd.GetDateTime() &&
                         endDate2 > this.tDateEdit_ApplyDateEd.GetDateTime())
                    {
                        errMessage = string.Format("{0}", ct_OutRange);
                        errComponent = this.tde_SalesDateSt;
                        status = false;
                        return status;
                    }
                }
                else
                {
                    if (tDateEdit_St.GetDateTime() < tDateEdit_ApplyDateSt.GetDateTime() && tDateEdit_End.GetDateTime() < tDateEdit_ApplyDateSt.GetDateTime())
                    {
                        errMessage = string.Format("{0}", ct_OutRange);
                        errComponent = this.tDateEdit_End;
                        status = false;
                        return status;
                    }

                    if (tDateEdit_St.GetDateTime() > tDateEdit_ApplyDateEd.GetDateTime() && tDateEdit_End.GetDateTime() > tDateEdit_ApplyDateEd.GetDateTime())
                    {
                        errMessage = string.Format("{0}", ct_OutRange);
                        errComponent = this.tDateEdit_St;
                        status = false;
                        return status;
                    }
                }

                // �S����
                if (
                    (this.tEdit_SalesEmployeeCode_St.DataText.TrimEnd() != string.Empty) &&
                    (this.tEdit_SalesEmployeeCode_Ed.DataText.TrimEnd() != string.Empty) &&
                    (this.tEdit_SalesEmployeeCode_St.DataText.TrimEnd().CompareTo(this.tEdit_SalesEmployeeCode_Ed.DataText.TrimEnd()) > 0))
                {
                    errMessage = string.Format("�S����{0}", ct_RangeError);
                    errComponent = this.tEdit_SalesEmployeeCode_Ed;
                    status = false;
                    return status;
                }

                // �n��
                if (
                    (this.tNedit_SalesAreaCode_St.GetInt() != 0) &&
                    (this.tNedit_SalesAreaCode_Ed.GetInt() != 0) &&
                    this.tNedit_SalesAreaCode_St.GetInt() > this.tNedit_SalesAreaCode_Ed.GetInt())
                {
                    errMessage = string.Format("�n��{0}", ct_RangeError);
                    errComponent = this.tNedit_SalesAreaCode_Ed;
                    status = false;
                    return status;
                }

                // �󒍎�
                if (
                    (this.tEdit_AcceptOdrCode_St.DataText.TrimEnd() != string.Empty) &&
                    (this.tEdit_AcceptOdrCode_Ed.DataText.TrimEnd() != string.Empty) &&
                    (this.tEdit_AcceptOdrCode_St.DataText.TrimEnd().CompareTo(this.tEdit_AcceptOdrCode_Ed.DataText.TrimEnd()) > 0))
                {
                    errMessage = string.Format("�󒍎�{0}", ct_RangeError);
                    errComponent = this.tEdit_AcceptOdrCode_Ed;
                    status = false;
                    return status;
                }

                // ���s��
                if (
                    (this.tEdit_SalesInputCode_St.DataText.TrimEnd() != string.Empty) &&
                    (this.tEdit_SalesInputCode_Ed.DataText.TrimEnd() != string.Empty) &&
                    (this.tEdit_SalesInputCode_St.DataText.TrimEnd().CompareTo(this.tEdit_SalesInputCode_Ed.DataText.TrimEnd()) > 0))
                {
                    errMessage = string.Format("���s��{0}", ct_RangeError);
                    errComponent = this.tEdit_SalesInputCode_Ed;
                    status = false;
                    return status;
                }

                // ���Ӑ�
                else if ((this.tNedit_CustomerCode_St.Text.Trim() != string.Empty)
                    && (this.tNedit_CustomerCode_Ed.Text.Trim() != string.Empty)
                    && (this.tNedit_CustomerCode_St.GetInt() > this.tNedit_CustomerCode_Ed.GetInt()))
                {
                    errMessage = string.Format("���Ӑ�{0}", ct_RangeError);
                    errComponent = this.tNedit_CustomerCode_Ed;
                    status = false;
                    return status;
                }

                // �̔��敪
                if (
                    (this.tNedit_SalesCode_St.GetInt() != 0) &&
                    (this.tNedit_SalesCode_Ed.GetInt() != 0) &&
                    this.tNedit_SalesCode_St.GetInt() > this.tNedit_SalesCode_Ed.GetInt())
                {
                    errMessage = string.Format("�̔��敪{0}", ct_RangeError);
                    errComponent = this.tNedit_SalesCode_Ed;
                    status = false;
                    return status;
                }

                // �O���[�v�R�[�h
                if (
                    (this.tNedit_GroupCode_St.GetInt() != 0) &&
                    (this.tNedit_GroupCode_Ed.GetInt() != 0) &&
                    this.tNedit_GroupCode_St.GetInt() > this.tNedit_GroupCode_Ed.GetInt())
                {
                    errMessage = string.Format("�O���[�v�R�[�h{0}", ct_RangeError);
                    errComponent = this.tNedit_GroupCode_Ed;
                    status = false;
                    return status;
                }

                // �a�k�R�[�h
                if (
                    (this.tNedit_BLCode_St.GetInt() != 0) &&
                    (this.tNedit_BLCode_Ed.GetInt() != 0) &&
                    this.tNedit_BLCode_St.GetInt() > this.tNedit_BLCode_Ed.GetInt())
                {
                    errMessage = string.Format("�a�k�R�[�h{0}", ct_RangeError);
                    errComponent = this.tNedit_BLCode_Ed;
                    status = false;
                    return status;
                }
            }
            return status;
        }

        /// <summary>
        /// �ݒ��ʓ��͂̎��ԃ`�F�b�N����
        /// </summary>
        ///  <remarks>
        /// <br>Note       : �ݒ��ʓ��͂̎��ԃ`�F�b�N�������܂��B </br>
        /// <returns>FLAG</returns>
        /// </remarks>
        private bool DateCheck(DateTime endDt, DateTime staDt)
        {
            bool flag = true;

            if ((endDt.Year - staDt.Year) > 1)//���ԑ嘰�P�N�Ԃ̏ꍇ
            {
                flag = false;
            }
            else if (endDt.Year - staDt.Year == 1)
            {
                if (endDt.Month > staDt.Month) //����r
                {
                    flag = false;
                }
                else if ((endDt.Month == staDt.Month) && (endDt.Day >= staDt.Day))
                {
                    flag = false;
                }
            }
            return flag;
        }

		#endregion

        /// <summary>
        /// ���t�`�F�b�N�����Ăяo��
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="startDateEdit"></param>
        /// <param name="endDateEdit"></param>
        /// <param name="allowNoInput"></param>
        /// <param name="yearCheck"></param>
        /// <param name="rangeCheck"></param>
        /// <returns></returns>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit startDateEdit, ref TDateEdit endDateEdit, bool allowNoInput, bool yearCheck, bool rangeCheck)
        {
            int range;
            DateGetAcs.YmdType rangType = DateGetAcs.YmdType.YearMonth;
            if ((int)this.tComboEditor_PrintType.Value == 2)
            {
                rangType = DateGetAcs.YmdType.YearMonthDay;
            }

            range = 0;

            cdrResult = _dateGet.CheckDateRange(rangType, range, ref startDateEdit, ref endDateEdit, allowNoInput, yearCheck);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

		#region �� ���t���̓`�F�b�N����
		/// <summary>
		/// ���t���̓`�F�b�N����
		/// </summary>
		/// <param name="targetDateEdit">�`�F�b�N�ΏۃR���g���[��</param>
		/// <param name="allowEmpty">�����͋���[true:����, false:�s����]</param>
		/// <returns>�`�F�b�N����(true/false)</returns>
		/// <remarks>
		/// <br>Note		: ���t���͂̃`�F�b�N���s���B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/05/19</br>
		/// </remarks>
		private bool DateEditInputCheck( TDateEdit targetDateEdit, bool allowEmpty )
		{
            bool status = true;

            // ���͓��t�𐔒l�^�Ŏ擾
            int date = targetDateEdit.GetLongDate();
            int yy = date / 10000;
            int mm = (date / 100) % 100;
            int dd = date % 100;

            // ���t�����̓`�F�b�N
            if (targetDateEdit.LongDate < 10101 && targetDateEdit.GetDateTime() == DateTime.MinValue)
            {
                if (allowEmpty == true)
                {
                    return status;
                }
                else
                {
                    status = false;
                }
            }
            // �V�X�e���T�|�[�g�`�F�b�N
            else if (yy < 1900)
            {
                status = false;
            }
            // �N�����ʓ��̓`�F�b�N
            else if ((yy == 0) || (mm == 0) || (dd == 0))
            {
                status = false;
            }
            // �P�����t�Ó����`�F�b�N
            else if (TDateTime.IsAvailableDate(targetDateEdit.GetDateTime()) == false)
            {
                status = false;
            }

            return status;
		}
		#endregion

		#region �� ���o�����ݒ菈��(��ʁ����o����)
		/// <summary>
        /// ���o�����ݒ菈��(��ʁ����o����)
        /// </summary>
		/// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: ��ʁ����o�����֐ݒ肷��B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			try
            {
                // ��ƃR�[�h
                this._campaignRsltList.EnterpriseCode = this._enterpriseCode;

                // �I�����_
                // ���_�I�v�V��������̂Ƃ�
                if (IsOptSection)
                {
                    ArrayList secList = new ArrayList();
                    // �S�БI�����ǂ���
                    if ((this._selectedSectionList.Count == 1) && (this._selectedSectionList.ContainsKey("0")))
                    {
                        this._campaignRsltList.SectionCodes = null;

                    }
                    else
                    {
                        foreach (DictionaryEntry dicEntry in this._selectedSectionList)
                        {
                            if ((CheckState)dicEntry.Value == CheckState.Checked)
                            {
                                secList.Add(dicEntry.Key);
                            }
                        }
                        this._campaignRsltList.SectionCodes = (string[])secList.ToArray(typeof(string));
                    }
                }
                // ���_�I�v�V�����Ȃ��̎�
                else
                {
                    this._campaignRsltList.SectionCodes = null;
                }

                // �L�����y�[���R�[�h
                this._campaignRsltList.CampaignCode = Convert.ToInt32(this.tNedit_CampaignCode.Text);

                // �L�����y�[������
                this._campaignRsltList.ApplyStaDate = TDateTime.DateTimeToLongDate(this.tDateEdit_ApplyDateSt.GetDateTime());
                this._campaignRsltList.ApplyEndDate = TDateTime.DateTimeToLongDate(this.tDateEdit_ApplyDateEd.GetDateTime());

                // ����^�C�v
                this._campaignRsltList.PrintType = (int)this.tComboEditor_PrintType.Value;

                // �Ώۓ��t
                if (this._campaignRsltList.PrintType == 2)
                {
                    this._campaignRsltList.AddUpYearMonthDaySt = this.tDateEdit_St.GetDateTime();
                    this._campaignRsltList.AddUpYearMonthDayEd = this.tDateEdit_End.GetDateTime();
                }
                else
                {
                    this._campaignRsltList.AddUpYearMonthSt = this.tde_SalesDateSt.GetDateTime();
                    this._campaignRsltList.AddUpYearMonthEd = this.tde_SalesDateEd.GetDateTime();

                    DateTime startDate1;
                    DateTime endDate1;
                    DateTime startDate2;
                    DateTime endDate2;
                    this._dateGet.GetDaysFromMonth(this._campaignRsltList.AddUpYearMonthSt, out startDate1, out endDate1);
                    this._dateGet.GetDaysFromMonth(this._campaignRsltList.AddUpYearMonthEd, out startDate2, out endDate2);

                    this._campaignRsltList.AddUpYearMonthDaySt = startDate1;
                    this._campaignRsltList.AddUpYearMonthDayEd = endDate2;
                }
                // ���גP��
                this._campaignRsltList.Detail = (int)this.tComboEditor_Detail.Value;

                if (this._campaignRsltList.Detail == 0)
                {
                    // ���v�P��
                    this._campaignRsltList.Total = (int)this.tComboEditor_Total.Value;
                    
                    if (this._campaignRsltList.PrintType != 1)
                    {
                        // �����
                        this._campaignRsltList.PrintSort = (int)this.tComboEditor_PrintSort.Value;
                    }
                }

                if (_campaignRsltList.TotalType != CampaignRsltList.TotalTypeState.EachSales)
                {
                    // �o�͏�
                    this._campaignRsltList.OutputSort = (int)this.tComboEditor_OutputSort.Value;
                }

                // ����(���_���ŉ���)
                if (this.ulCheckEdt_Section.Checked)
                {
                    this._campaignRsltList.CrModeSec = 1;
                }
                else
                {
                    this._campaignRsltList.CrModeSec = 0;
                }
                // ����(�S���Җ��ŉ���)
                if (this.ulCheckEdt_Emp.Checked)
                {
                    this._campaignRsltList.CrModeEmp = 1;
                }
                else
                {
                    this._campaignRsltList.CrModeEmp = 0;
                }
                // ����(�n�斈�ŉ���)
                if (this.ulCheckEdt_Area.Checked)
                {
                    this._campaignRsltList.CrModeArea = 1;
                }
                else
                {
                    this._campaignRsltList.CrModeArea = 0;
                }

                // ----- UPD 2011/07/11 ----- >>>>>
                //if (_campaignRsltList.TotalType == CampaignRsltList.TotalTypeState.EachCustomer)
                if (_campaignRsltList.TotalType == CampaignRsltList.TotalTypeState.EachCustomer || _campaignRsltList.TotalType == CampaignRsltList.TotalTypeState.EachGoods)
                // ----- UPD 2011/07/11 ----- <<<<<
                {
                    // ���Ӑ�
                    this._campaignRsltList.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();
                    this._campaignRsltList.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();
                }

                if (_campaignRsltList.TotalType == CampaignRsltList.TotalTypeState.EachEmployee)
                {
                    // �S����
                    if (this.tEdit_SalesEmployeeCode_St.DataText == string.Empty) this._campaignRsltList.EmployeeCodeSt = string.Empty;
                    else this._campaignRsltList.EmployeeCodeSt = this.tEdit_SalesEmployeeCode_St.DataText.PadLeft(4, '0');

                    if (this.tEdit_SalesEmployeeCode_Ed.DataText == string.Empty) this._campaignRsltList.EmployeeCodeEd = string.Empty;
                    else this._campaignRsltList.EmployeeCodeEd = this.tEdit_SalesEmployeeCode_Ed.DataText.PadLeft(4, '0');

                    // ���Ӑ�
                    this._campaignRsltList.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();
                    this._campaignRsltList.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();
                }

                if (_campaignRsltList.TotalType == CampaignRsltList.TotalTypeState.EachArea)
                {
                    // �n��
                    this._campaignRsltList.AreaCodeSt = this.tNedit_SalesAreaCode_St.GetInt();
                    this._campaignRsltList.AreaCodeEd = this.tNedit_SalesAreaCode_Ed.GetInt();

                    // ���Ӑ�
                    this._campaignRsltList.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();
                    this._campaignRsltList.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();
                }

                if (_campaignRsltList.TotalType == CampaignRsltList.TotalTypeState.EachSales)
                {
                    // �̔��敪
                    this._campaignRsltList.SalesCodeSt = this.tNedit_SalesCode_St.GetInt();
                    this._campaignRsltList.SalesCodeEd = this.tNedit_SalesCode_Ed.GetInt();

                    // ���Ӑ�
                    this._campaignRsltList.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();
                    this._campaignRsltList.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();
                }

                if (_campaignRsltList.TotalType == CampaignRsltList.TotalTypeState.EachAcceptOdr)
                {
                    // �󒍎�
                    if (this.tEdit_AcceptOdrCode_St.DataText == string.Empty) this._campaignRsltList.AcceptOdrCodeSt = string.Empty;
                    else this._campaignRsltList.AcceptOdrCodeSt = this.tEdit_AcceptOdrCode_St.DataText.PadLeft(4, '0');

                    if (this.tEdit_AcceptOdrCode_Ed.DataText == string.Empty) this._campaignRsltList.AcceptOdrCodeEd = string.Empty;
                    else this._campaignRsltList.AcceptOdrCodeEd = this.tEdit_AcceptOdrCode_Ed.DataText.PadLeft(4, '0');

                    // ���Ӑ�
                    this._campaignRsltList.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();
                    this._campaignRsltList.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();
                }

                if (_campaignRsltList.TotalType == CampaignRsltList.TotalTypeState.EachPrinter)
                {
                    // ���s��
                    if (this.tEdit_SalesInputCode_St.DataText == string.Empty) this._campaignRsltList.PrinterCodeSt = string.Empty;
                    else this._campaignRsltList.PrinterCodeSt = this.tEdit_SalesInputCode_St.DataText.PadLeft(4, '0');

                    if (this.tEdit_SalesInputCode_Ed.DataText == string.Empty) this._campaignRsltList.PrinterCodeEd = string.Empty;
                    else this._campaignRsltList.PrinterCodeEd = this.tEdit_SalesInputCode_Ed.DataText.PadLeft(4, '0');

                    // ���Ӑ�
                    this._campaignRsltList.CustomerCodeSt = this.tNedit_CustomerCode_St.GetInt();
                    this._campaignRsltList.CustomerCodeEd = this.tNedit_CustomerCode_Ed.GetInt();
                }

                // �O���[�v�R�[�h
                this._campaignRsltList.BLGroupCodeSt = this.tNedit_GroupCode_St.GetInt();
                this._campaignRsltList.BLGroupCodeEd = this.tNedit_GroupCode_Ed.GetInt();

                // �a�k�R�[�h
                this._campaignRsltList.BLGoodsCodeSt = this.tNedit_BLCode_St.GetInt();
                this._campaignRsltList.BLGoodsCodeEd = this.tNedit_BLCode_Ed.GetInt();
            }
			catch ( Exception )
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}

			return status;
		}
		#endregion
		#endregion �� ����O����		

		#region �� �G���[���b�Z�[�W�\������ ( +1�̃I�[�o�[���[�h )
		#region �� �G���[���b�Z�[�W�\������
		/// <summary>
		/// �G���[���b�Z�[�W�\������
		/// </summary>
		/// <param name="iLevel">�G���[���x��</param>
		/// <param name="message">�\�����b�Z�[�W</param>
		/// <param name="status">�X�e�[�^�X</param>
		/// <remarks>
		/// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
		/// <br>Programmer : �c����</br>
		/// <br>Date       : 2011/05/19</br>
		/// </remarks>
		private void MsgDispProc( emErrorLevel iLevel, string message,int status )
		{
			TMsgDisp.Show( 
				iLevel, 							// �G���[���x��
				ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
				this._printName,					// �v���O��������
				"", 								// ��������
				"",									// �I�y���[�V����
				message,							// �\�����郁�b�Z�[�W
				status, 							// �X�e�[�^�X�l
				null, 								// �G���[�����������I�u�W�F�N�g
				MessageBoxButtons.OK, 				// �\������{�^��
				MessageBoxDefaultButton.Button1 );	// �����\���{�^��
		}
		#endregion

		#region �� �G���[���b�Z�[�W�\������
		/// <summary>
		/// �G���[���b�Z�[�W�\������
		/// </summary>
		/// <param name="message">�\�����b�Z�[�W</param>
		/// <param name="status">�X�e�[�^�X</param>
		/// <param name="procnm">�������\�b�hID</param>
		/// <param name="ex">��O���</param>
		/// <remarks>
		/// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
		/// <br>Programmer : �c����</br>
		/// <br>Date       : 2011/05/19</br>
		/// </remarks>
		private void MsgDispProc( string message,int status, string procnm, Exception ex )
		{
			string errMessage = message + "\r\n" + ex.Message;

			TMsgDisp.Show( 
				this, 								// �e�E�B���h�E�t�H�[��
				emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
				ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
				this._printName,					// �v���O��������
				procnm, 							// ��������
				"",									// �I�y���[�V����
				errMessage,							// �\�����郁�b�Z�[�W
				status, 							// �X�e�[�^�X�l
				null, 								// �G���[�����������I�u�W�F�N�g
				MessageBoxButtons.OK, 				// �\������{�^��
				MessageBoxDefaultButton.Button1 );	// �����\���{�^��
		}
		#endregion
        
        #endregion �� �G���[���b�Z�[�W�\������ ( +1�̃I�[�o�[���[�h )

        /// <summary>
        /// �Ώۓ��t�ɒl�̃Z�b�g
        /// </summary>
        /// <remarks>
        /// <br>Note		: �Ώۓ��t�ɒl���Z�b�g����B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
        private void SetDateTime()
        {
            TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
            DateTime prevTotalDay;
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;

            // ����^�C�v���u2�F���t�v��I����
            if ((int)this.tComboEditor_PrintType.Value == 2)
            {
                this.panel1.Visible = false;
                this.panel2.Visible = true;

                if (this.tDateEdit_ApplyDateSt.GetDateTime() != DateTime.MinValue)
                {
                    this.tDateEdit_St.SetDateTime(this.tDateEdit_ApplyDateSt.GetDateTime());
                    this.tDateEdit_End.SetDateTime(this.tDateEdit_ApplyDateEd.GetDateTime());
                }
            }
            else
            {
                this.panel1.Visible = true;
                this.panel2.Visible = false;

                totalDayCalculator.InitializeHisMonthlyAccRec();
                totalDayCalculator.GetHisTotalDayMonthlyAccRec(LoginInfoAcquisition.Employee.BelongSectionCode, out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);
                if (currentTotalMonth != DateTime.MinValue)
                {
                    // ���㍡�񌎎��X�V����ݒ�
                    this.tde_SalesDateSt.SetDateTime(currentTotalMonth);
                    this.tde_SalesDateEd.SetDateTime(currentTotalMonth);
                }
                else
                {
                    // ������ݒ�
                    DateTime nowYearMonth;
                    this._dateGet.GetThisYearMonth(out nowYearMonth);

                    this.tde_SalesDateSt.SetDateTime(nowYearMonth);
                    this.tde_SalesDateEd.SetDateTime(nowYearMonth);
                }
            }
        }

        /// <summary>
        /// �L�����y�[�����̎擾
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length">�擾��</param>
        /// <returns></returns>
        private string CutSubstring(string str, int length)
        {
            string returnstr = string.Empty;

            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            byte[] bt = System.Text.Encoding.Default.GetBytes(str);
            int btlength = bt.Length;

            if (length == 0)
            {
                return string.Empty;
            }
            else if (length >= btlength)
            {
                return str;
            }
            string sr = "";
            int num = 0;
            for (int i = 0; i < length; i++)
            {
                sr = str.Substring(i, 1);
                byte[] bt2 = System.Text.Encoding.Default.GetBytes(sr);
                if (bt2.Length == 1)
                {
                    num = num + 1;
                }
                if (bt2.Length == 2)
                {
                    num = num + 2;
                }

                if (num <= length)
                {
                    returnstr = returnstr + sr;
                }
                else
                {
                    break;
                }
            }
            return returnstr;
        }

        /// <summary>
        /// Initial_Timer_Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/06/03</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            // �����t�H�[�J�X�Z�b�g
            this.tNedit_CampaignCode.Focus();

            if (ParentToolbarSettingEvent != null)
                ParentToolbarSettingEvent(this);	// �c�[���o�[�{�^���ݒ�C�x���g�N��

            ParentToolbarGuideSettingEvent(true);
        }

        /// <summary>
        /// �t�H�[�J�X��ݒ肷��
        /// </summary>
        /// <param name="control"></param>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/06/03</br>
        /// </remarks>
        private void SetControlFocus(Control control)
        {
            control.Focus();
            switch (control.Name)
            {
                case "tNedit_CampaignCode":     // �L�����y�[���R�[�h
                case "tEdit_SalesEmployeeCode_St":   // �J�n�S���҃R�[�h
                case "tEdit_SalesEmployeeCode_Ed":   // �I���S���҃R�[�h
                case "tEdit_SalesInputCode_St": // �J�n���s�҃R�[�h
                case "tEdit_SalesInputCode_Ed": // �I�����s�҃R�[�h
                case "tNedit_CustomerCode_St":  // �J�n���Ӑ�R�[�h
                case "tNedit_CustomerCode_Ed":  // �I�����Ӑ�R�[�h
                case "tNedit_SalesCode_St":     // �J�n�̔��敪
                case "tNedit_SalesCode_Ed":     // �I���̔��敪
                case "tNedit_GroupCode_St":     // �J�n�O���[�v�R�[�h
                case "tNedit_GroupCode_Ed":     // �I���O���[�v�R�[�h
                case "tNedit_BLCode_St":        // �J�n�a�k�R�[�h
                case "tNedit_BLCode_Ed":        // �I���a�k�R�[�h
                case "tNedit_SalesAreaCode_St": // �J�n�n��R�[�h
                case "tNedit_SalesAreaCode_Ed": // �I���n��R�[�h
                case "tEdit_AcceptOdrCode_St":   // �J�n�󒍎҃R�[�h
                case "tEdit_AcceptOdrCode_Ed":   // �I���󒍎҃R�[�h
                    {
                        ParentToolbarGuideSettingEvent(true);
                        break;
                    }
                default:
                    {
                        ParentToolbarGuideSettingEvent(false);
                        break;
                    }
            }
        }

        /// <summary>
        /// timer1_Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/06/03</br>
        /// </remarks>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            this.tNedit_CampaignCode.Leave += new EventHandler(this.tNedit_CampaignCode_Leave);
            if (!this._campaignCodeExistFlg)
            {
                this.SetControlFocus(this.tNedit_CampaignCode);
            }
            this._campaignCodeExistFlg = true;
        }
        #endregion �� Private Method

        #region �� Control Event
        #region �� PMKHN02050UA
        #region �� PMKHN02050UA_Load Event
        /// <summary>
		/// PMKHN02050UA_Load Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
		private void PMKHN02050UA_Load ( object sender, EventArgs e )
		{
            this.tComboEditor_PrintType.ValueChanged -= new System.EventHandler(this.tComboEditor_PrintType_ValueChanged);

			string errMsg = string.Empty;

			// �R���g���[��������
			int status = this.InitializeScreen( out errMsg );
			if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
			{
				MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
				return;
			}

			// ��ʃC���[�W����
			this._controlScreenSkin.LoadSkin();						// ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
			this._controlScreenSkin.SettingScreenSkin(this);		// ��ʃX�L���ύX

            this.Initial_Timer.Enabled = true;

		}
		#endregion

        /// <summary>
        /// PMKHN02050UA_Shown�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: �Ώۓ��t��ValueChanged�C�x���g��ǉ�����B</br>
        /// <br>Programmer  : �c����</br>
        /// <br>Date        : 2011/05/19</br>
        /// </remarks>
        private void PMKHN02050UA_Shown(object sender, EventArgs e)
        {
            this.tComboEditor_PrintType.ValueChanged += new System.EventHandler(this.tComboEditor_PrintType_ValueChanged);
        }

        #region �� �K�C�h����
        /// <summary>
        /// �L�����y�[���R�[�h�K�C�h
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �I�����ꂽ�R�[�h�A���̂���ʂփZ�b�g����B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
        private void uButton_CampaignCodeGuid_Click(object sender, EventArgs e)
        {
            CampaignSt campaignSt;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // �K�C�h�N��
                int status = this._campaignStAcs.ExecuteGuid(this._enterpriseCode, out campaignSt);
                if (status == 0)
                {
                    this.tNedit_CampaignCode.Text = campaignSt.CampaignCode.ToString().PadLeft(6, '0');
                    this.tNedit_CampaignName.Text = CutSubstring(campaignSt.CampaignName, 40);
                    this.tDateEdit_ApplyDateSt.SetDateTime(campaignSt.ApplyStaDate);
                    this.tDateEdit_ApplyDateEd.SetDateTime(campaignSt.ApplyEndDate);

                    this._preCampaignCode = campaignSt.CampaignCode;

                    // �Ώۓ��t�̃Z�b�g
                    this.SetDateTime();

                    // �t�H�[�J�X
                    this.SetControlFocus(tComboEditor_PrintType);

                }
                else
                {
                    return;
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// �S���҃K�C�h
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���o����͈͂��w�肷��B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
        private void uButton_EmployeeCdStGuid_Click(object sender, EventArgs e)
        {
            if (this._employeeAcs == null)
            {
                this._employeeAcs = new EmployeeAcs();
            }

            Employee employee;
            int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);

            if (status == 0)
            {
                if (sender == this.uButton_EmployeeCdStGuid)
                {
                    this.tEdit_SalesEmployeeCode_St.Text = employee.EmployeeCode.TrimEnd();
                    this.SetControlFocus(this.tEdit_SalesEmployeeCode_Ed);
                }
                else if (sender == this.uButton_EmployeeCdEdGuid)
                {
                    this.tEdit_SalesEmployeeCode_Ed.Text = employee.EmployeeCode.TrimEnd();
                    this.SetControlFocus(this.tNedit_CustomerCode_St);
                }
                else if (sender == this.uButton_PrinterStGuid)
                {
                    this.tEdit_SalesInputCode_St.Text = employee.EmployeeCode.TrimEnd();
                    this.SetControlFocus(this.tEdit_SalesInputCode_Ed);
                }
                else if (sender == this.uButton_PrinterEdGuid)
                {
                    this.tEdit_SalesInputCode_Ed.Text = employee.EmployeeCode.TrimEnd();
                    this.SetControlFocus(this.tNedit_CustomerCode_St);
                }
                else if (sender == this.uButton_AcceptOdrCdStGuid)
                {
                    this.tEdit_AcceptOdrCode_St.Text = employee.EmployeeCode.TrimEnd();
                    this.SetControlFocus(this.tEdit_AcceptOdrCode_Ed);
                }
                else if (sender == this.uButton_AcceptOdrCdEdGuid)
                {
                    this.tEdit_AcceptOdrCode_Ed.Text = employee.EmployeeCode.TrimEnd();
                    this.SetControlFocus(this.tNedit_CustomerCode_St);
                }
            }
        }

        /// <summary>
        /// ���Ӑ�K�C�h
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���o����͈͂��w�肷��B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
        private void uButton_CustomerCdStGuide_Click(object sender, EventArgs e)
        {
            _customerGuideOK = false;

            // �������ꂽ�{�^����ޔ�
            if (sender is UltraButton)
            {
                _customerGuideSender = (UltraButton)sender;
            }

            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.customerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);

            if (_customerGuideOK)
            {
                this.SetControlFocus(this.tNedit_CustomerCode_Ed);
            }
        }


        /// <summary>
        /// ���Ӑ�K�C�h�I���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">�C�x���g�p�����[�^</param>
        void customerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

            int status = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);
            if (status != 0) return;

            if (_customerGuideSender == this.uButton_CustomerCdStGuide)
            {
                this.tNedit_CustomerCode_St.SetInt(customerInfo.CustomerCode);
            }
            else
            {
                this.tNedit_CustomerCode_Ed.SetInt(customerInfo.CustomerCode);
            }

            _customerGuideOK = true;
        }

        /// <summary>
        /// �O���[�v�R�[�h�K�C�h�̃N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �O���[�v�R�[�h�K�C�h�̃N���b�N���s��</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private void uButton_GroupCodeStGuide_Click(object sender, EventArgs e)
        {
            // �O���[�v�R�[�h�K�C�h�N��
            BLGroupU blGroupU;

            if (this._blGroupUAcs == null)
            {
                this._blGroupUAcs = new BLGroupUAcs();
            }

            int status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);
            if (status != 0) return;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                this.tNedit_GroupCode_St.SetInt(blGroupU.BLGroupCode);
                this.SetControlFocus(tNedit_GroupCode_Ed);
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_GroupCode_Ed.SetInt(blGroupU.BLGroupCode);
                this.SetControlFocus(tNedit_BLCode_St);
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// �a�k�R�[�h�K�C�h�̃N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �a�k�R�[�h�K�C�h�̃N���b�N���s��</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private void uButton_BLCodeStGuide_Click(object sender, EventArgs e)
        {
            // �a�k�R�[�h�K�C�h�N��
            BLGoodsCdUMnt bLGoodsCdUMnt;

            if (_blGoodsCdAcs == null)
            {
                _blGoodsCdAcs = new BLGoodsCdAcs();
            }

            int status = _blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);
            if (status != 0) return;

            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                this.tNedit_BLCode_St.SetInt(bLGoodsCdUMnt.BLGoodsCode);
                this.SetControlFocus(tNedit_BLCode_Ed);
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                this.tNedit_BLCode_Ed.SetInt(bLGoodsCdUMnt.BLGoodsCode);
                this.SetControlFocus(tNedit_CampaignCode);
            }
            else
            {
                return;
            }
        }
        #endregion        

		#endregion �� PMKHN02050UA

		#region �� ueb_MainExplorerBar
		#region �� GroupCollapsing Event
		/// <summary>
		/// GroupCollapsing Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: UltraExplorerBarGroup���k�������O�ɔ�������B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
		private void ueb_MainExplorerBar_GroupCollapsing ( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
		{
			if( ( e.Group.Key == ct_ExBarGroupNm_ReportSelectGroup ) ||
				(e.Group.Key == ct_ExBarGroupNm_PrintOderGroup) ||
				( e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup ) )
			{
				// �O���[�v�̏k�����L�����Z��
				e.Cancel = true;
			}
		}
		#endregion

		#region �� GroupExpanding Event
		/// <summary>
		/// GroupExpanding Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: UltraExplorerBarGroup���W�J�����O�ɔ�������B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
		private void ueb_MainExplorerBar_GroupExpanding ( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
		{
			if( ( e.Group.Key == ct_ExBarGroupNm_ReportSelectGroup ) ||
				(e.Group.Key == ct_ExBarGroupNm_PrintOderGroup) ||
				(e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup))
			{
				// �O���[�v�̓W�J���L�����Z��
				e.Cancel = true;
			}

		}
		#endregion

		#endregion �� ueb_MainExplorerBar        
        
        /// <summary>
        /// �L�����y�[���R�[�h��Leave�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
        private void tNedit_CampaignCode_Leave(object sender, EventArgs e)
        {
            this.tNedit_CampaignCode.Leave -= new EventHandler(this.tNedit_CampaignCode_Leave);
            CampaignSt campaignSt;
            int campaignCode = 0;
            if (!string.IsNullOrEmpty(this.tNedit_CampaignCode.Text))
            {
                campaignCode = Convert.ToInt32(this.tNedit_CampaignCode.Text);
            }
            else
            {
                this.tNedit_CampaignName.Clear();
                this.tDateEdit_ApplyDateSt.Clear();
                this.tDateEdit_ApplyDateEd.Clear();
                this._preCampaignCode = 0;
                this.timer1.Enabled = true;
                return ;
            }

            int status = this._campaignStAcs.Read(out campaignSt, this._enterpriseCode, campaignCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (campaignSt.LogicalDeleteCode == 0)
                {
                    if (Int32.Parse(this.tNedit_CampaignCode.Text) != this._preCampaignCode)
                    {
                        this.tNedit_CampaignCode.Text = campaignSt.CampaignCode.ToString().PadLeft(6, '0');
                        this.tNedit_CampaignName.Text = CutSubstring(campaignSt.CampaignName, 40);
                        this.tDateEdit_ApplyDateSt.SetDateTime(campaignSt.ApplyStaDate);
                        this.tDateEdit_ApplyDateEd.SetDateTime(campaignSt.ApplyEndDate);

                        // �Ώۓ��t�̃Z�b�g
                        this.SetDateTime();
                        this._campExecSecCode = campaignSt.SectionCode;
                        this._preCampaignCode = campaignSt.CampaignCode;
                    }
                }
                else
                {
                    this.SetControlFocus(tNedit_CampaignCode);
                    // ���b�Z�[�W��\��
                    this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, ct_NoExist, 0);
                    this._campaignCodeExistFlg = false;

                    this.tNedit_CampaignCode.Text = this._preCampaignCode.ToString();
                    if ("000000".Equals(this._preCampaignCode.ToString().PadLeft(6, '0')))
                    {
                        this.tNedit_CampaignCode.Clear();
                    }
                }
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                this.SetControlFocus(tNedit_CampaignCode);
                // ���b�Z�[�W��\��
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, ct_NoExist, 0);
                this._campaignCodeExistFlg = false;

                this.tNedit_CampaignCode.Text = this._preCampaignCode.ToString();
                if ("000000".Equals(this._preCampaignCode.ToString().PadLeft(6, '0')))
                {
                    this.tNedit_CampaignCode.Clear();
                }
            }
            else
            {
                this.SetControlFocus(tNedit_CampaignCode);
                // ���b�Z�[�W��\��
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, ct_GetError, 0);
                this._campaignCodeExistFlg = false;

                this.tNedit_CampaignCode.Text = this._preCampaignCode.ToString();
                if ("000000".Equals(this._preCampaignCode.ToString().PadLeft(6, '0')))
                {
                    this.tNedit_CampaignCode.Clear();
                }
            }
            this.timer1.Enabled = true;
        }

        /// <summary>
        /// �}�X�^�`�F�b�N�L��
        /// </summary>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
        private int checkCampaignCode()
        {
            CampaignSt campaignSt;
            int campaignCode = 0;
            if (!string.IsNullOrEmpty(this.tNedit_CampaignCode.Text))
            {
                campaignCode = Convert.ToInt32(this.tNedit_CampaignCode.Text);
            }
            else
            {
                this.tNedit_CampaignName.Clear();
                this.tDateEdit_ApplyDateSt.Clear();
                this.tDateEdit_ApplyDateEd.Clear();
                return -1;
            }

            int status = this._campaignStAcs.Read(out campaignSt, this._enterpriseCode, campaignCode);

            if (status == 0)
            {
                this.tNedit_CampaignCode.Text = campaignSt.CampaignCode.ToString().PadLeft(6, '0');
                this.tNedit_CampaignName.Text = CutSubstring(campaignSt.CampaignName, 40);
                this.tDateEdit_ApplyDateSt.SetDateTime(campaignSt.ApplyStaDate);
                this.tDateEdit_ApplyDateEd.SetDateTime(campaignSt.ApplyEndDate);
                this._campExecSecCode = campaignSt.SectionCode;
                this._preCampaignCode = campaignSt.CampaignCode;
            }
            else
            {
                this.SetControlFocus(tNedit_CampaignCode);
                // ���b�Z�[�W��\��
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, ct_NoExist, 0);

                this.tNedit_CampaignCode.Text = this._preCampaignCode.ToString();
                if ("000000".Equals(this._preCampaignCode.ToString().PadLeft(6, '0')))
                {
                    this.tNedit_CampaignCode.Clear();
                }
            }
            return status;
        }
        /// <summary>
        /// tComboEditor_PrintType��ValueChanged�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ����^�C�v�ɏ]���āA�Ώۓ��t��N���̌`���ɕύX����B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
        private void tComboEditor_PrintType_ValueChanged(object sender, EventArgs e)
        {
            this.SetDateTime();

            // ����^�C�v�����Ԃ̏ꍇ
            if ((int)this.tComboEditor_PrintType.Value == 1)
            {
                // ----- UPD 2011/07/12 ----- >>>>>
                //this.tComboEditor_PrintSort.Items.Clear();
                this.tComboEditor_PrintSort.SelectedIndex = 0;
                // ----- UPD 2011/07/12 ----- <<<<<
                this.tComboEditor_PrintSort.Enabled = false;
            }
            else
            {
                if ((int)this.tComboEditor_Detail.Value == 0)
                {
                    // ----- DEL 2011/07/12 ----- >>>>>
                    //this.tComboEditor_PrintSort.Items.Clear();
                    //Infragistics.Win.ValueListItem listItem;

                    //listItem = new Infragistics.Win.ValueListItem();
                    //listItem.Tag = 0;
                    //listItem.DataValue = 0;
                    //listItem.DisplayText = "0�F�i�ԁ{���[�J�[";
                    //this.tComboEditor_PrintSort.Items.Add(listItem);

                    //listItem = new Infragistics.Win.ValueListItem();
                    //listItem.Tag = 1;
                    //listItem.DataValue = 1;
                    //listItem.DisplayText = "1�F���[�J�[�{�i��";
                    //this.tComboEditor_PrintSort.Items.Add(listItem);

                    //this.tComboEditor_PrintSort.Value = 0;
                    // ----- DEL 2011/07/12 ----- <<<<<
                    this.tComboEditor_PrintSort.Enabled = true;
                }
                else
                {
                    //this.tComboEditor_PrintSort.Items.Clear(); // DEL 2011/07/12
                    this.tComboEditor_PrintSort.Enabled = false;
                }
            }
        }

        /// <summary>
        /// tComboEditor_Detail��ValueChanged�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���גP�ʂɏ]���āA���v�P�ʂƈ�����̓��͏�Ԃ𐧌䂷��B</br>
        /// <br>Programmer	: �c����</br>
        /// <br>Date		: 2011/05/19</br>
        /// </remarks>
        private void tComboEditor_Detail_ValueChanged(object sender, EventArgs e)
        {
            if ((int)this.tComboEditor_Detail.Value != 0)
            {
                // ----- UPD 2011/07/12 ----- >>>>>
                //this.tComboEditor_Total.Items.Clear();
                //this.tComboEditor_PrintSort.Items.Clear();
                this.tComboEditor_Total.SelectedIndex = 0;
                this.tComboEditor_PrintSort.SelectedIndex = 0;
                // ----- UPD 2011/07/12 ----- <<<<<
                this.tComboEditor_Total.Enabled = false;
                this.tComboEditor_PrintSort.Enabled = false;
            }
            else
            {
                // ����^�C�v�����Ԃ̏ꍇ
                if ((int)this.tComboEditor_PrintType.Value == 1)
                {
                    //this.tComboEditor_PrintSort.Items.Clear(); // DEL 2011/07/12
                    this.tComboEditor_PrintSort.Enabled = false;
                }
                else
                {
                    // ----- DEL 2011/07/12 ----- >>>>>
                    //this.tComboEditor_PrintSort.Items.Clear();
                    //Infragistics.Win.ValueListItem listItemPrint;

                    //listItemPrint = new Infragistics.Win.ValueListItem();
                    //listItemPrint.Tag = 0;
                    //listItemPrint.DataValue = 0;
                    //listItemPrint.DisplayText = "0�F�i�ԁ{���[�J�[";
                    //this.tComboEditor_PrintSort.Items.Add(listItemPrint);

                    //listItemPrint = new Infragistics.Win.ValueListItem();
                    //listItemPrint.Tag = 1;
                    //listItemPrint.DataValue = 1;
                    //listItemPrint.DisplayText = "1�F���[�J�[�{�i��";
                    //this.tComboEditor_PrintSort.Items.Add(listItemPrint);

                    //this.tComboEditor_PrintSort.Value = 0;
                    // ----- DEL 2011/07/12 ----- <<<<<
                    this.tComboEditor_PrintSort.Enabled = true;
                }

                this.tComboEditor_Total.Items.Clear();
                Infragistics.Win.ValueListItem listItemTotal;

                listItemTotal = new Infragistics.Win.ValueListItem();
                listItemTotal.Tag = 0;
                listItemTotal.DataValue = 0;
                listItemTotal.DisplayText = "0�F��ٰ�ߺ���";
                this.tComboEditor_Total.Items.Add(listItemTotal);

                listItemTotal = new Infragistics.Win.ValueListItem();
                listItemTotal.Tag = 1;
                listItemTotal.DataValue = 1;
                listItemTotal.DisplayText = "1�FBL����";
                this.tComboEditor_Total.Items.Add(listItemTotal);

                this.tComboEditor_Total.Value = 0;
                this.tComboEditor_Total.Enabled = true;
            }
        }
        
        /// <summary>
        /// ���[�U�[�K�C�h�̃N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ���[�U�[�K�C�h�̃N���b�N���s��</br>
        /// <br>Programmer : �k���r</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void uButton_GuideCodeStGuide_Click(object sender, EventArgs e)
        {
            if (this._userGuideAcs == null)
            {
                this._userGuideAcs = new UserGuideAcs();
            }

            UserGdHd userGdHd = new UserGdHd();
            UserGdBd userGdBd = new UserGdBd();

            //�̔��敪 
            int GuideNo = 71;

            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, GuideNo);

            if (status != 0) return;

            TNedit targetControl;
            Control nextControl;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_SalesCode_St;
                nextControl = this.tNedit_SalesCode_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_SalesCode_Ed;
                nextControl = this.tNedit_SalesCode_Ed;
            }
            else
            {
                return;
            }

            targetControl.DataText = userGdBd.GuideCode.ToString("0000");

            // �t�H�[�J�X�ړ�
            this.SetControlFocus(nextControl);
        }

        /// <summary>
        /// �n��K�C�h�̃N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �n��K�C�h�̃N���b�N���s��</br>
        /// <br>Programmer : �����Y</br>
        /// <br>Date       : 2011/05/26</br>
        /// </remarks>
        private void uButton_AreaCdStGuide_Click(object sender, EventArgs e)
        {
            if (this._userGuideAcs == null)
            {
                this._userGuideAcs = new UserGuideAcs();
            }

            UserGdHd userGdHd = new UserGdHd();
            UserGdBd userGdBd = new UserGdBd();

            //�n��
            int GuideNo = 21;

            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, GuideNo);

            if (status != 0) return;

            TNedit targetControl;
            Control nextControl;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_SalesAreaCode_St;
                nextControl = this.tNedit_SalesAreaCode_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_SalesAreaCode_Ed;
                nextControl = this.tNedit_SalesAreaCode_Ed;
            }
            else
            {
                return;
            }

            targetControl.DataText = userGdBd.GuideCode.ToString("0000");

            // �t�H�[�J�X�ړ�
            this.SetControlFocus(nextControl);
        }

        /// <summary>
        /// uebcc_SelectList��SizeChanged�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �R���g���[���̕��ɏ]���āA�����̕����Z�b�g����B</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/05/19</br>
        /// </remarks>
        private void uebcc_SelectList_SizeChanged(object sender, EventArgs e)
        {
            this.tLine1.Width = this.uebcc_SelectList.Width;
        }    

        /// <summary>
        /// ���L�[�ł̃t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: �Ȃ�</br>
        /// <br>Programmer  : �c����</br>
        /// <br>Date        : 2011/05/19</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.NextCtrl == null) return;
            if (e.PrevCtrl == null) return;

            if (e.PrevCtrl != null && e.PrevCtrl.Name == "tNedit_CampaignCode")
            {
                if (!e.ShiftKey)
                {
                    switch (e.Key)
                    {
                        case Keys.Enter:
                        case Keys.Tab:
                            {
                                if (string.IsNullOrEmpty(this.tNedit_CampaignCode.Text))
                                {
                                    e.NextCtrl = uButton_CampaignGuid;
                                }
                                else
                                {
                                    e.NextCtrl = tComboEditor_PrintType;
                                }
                                break;
                            }
                        case Keys.Right:
                            {
                                e.NextCtrl = uButton_CampaignGuid;
                                break;
                            }
                    }
                }
                else
                {
                    switch (e.Key)
                    {
                        case Keys.Enter:
                        case Keys.Tab:
                            {
                                if (string.IsNullOrEmpty(this.tNedit_CampaignCode.Text))
                                {
                                    e.NextCtrl = uButton_CampaignGuid;
                                }
                                else
                                {
                                    // 0:���i��
                                    if (this._campaignRsltList.TotalType == CampaignRsltList.TotalTypeState.EachGoods)
                                    {
                                        e.NextCtrl = tNedit_BLCode_Ed;
                                    }
                                    else
                                    {
                                        e.NextCtrl = tNedit_CustomerCode_Ed;
                                    }
                                }
                                break;
                            }
                    }
                }
            }
            if (e.NextCtrl.Name != "tNedit_CampaignCode" && e.NextCtrl.Name != "uButton_CampaignGuid")
            {
                if (string.IsNullOrEmpty(this.tNedit_CampaignCode.Text) || "000000".Equals(this.tNedit_CampaignCode.Text.PadLeft(6, '0')))
                {
                    this.tNedit_CampaignCode.Clear();
                    this.tNedit_CampaignName.Clear();
                    this.tDateEdit_ApplyDateSt.Clear();
                    this.tDateEdit_ApplyDateEd.Clear();

                    this._preCampaignCode = 0;
                    // ���b�Z�[�W��\��
                    this.MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, ct_NoInput, 0);
                    e.NextCtrl = tNedit_CampaignCode;
                }
            }

            switch (e.PrevCtrl.Name)
            {
                case "tNedit_CampaignCode":     // �L�����y�[���R�[�h
                    {
                        try
                        {
                            int code = Convert.ToInt32(tNedit_CampaignCode.Value);
                        }
                        catch
                        {
                            if (this._preCampaignCode != 0)
                            {
                                tNedit_CampaignCode.Value = this._preCampaignCode;
                            }
                            else
                            {
                                tNedit_CampaignCode.Clear();
                            }
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    break;
                case "tEdit_SalesEmployeeCode_St":   // �J�n�S���҃R�[�h
                    {
                        try
                        {
                            int code = Convert.ToInt32(tEdit_SalesEmployeeCode_St.Value);
                        }
                        catch
                        {
                            tEdit_SalesEmployeeCode_St.Clear();
                            e.NextCtrl = e.NextCtrl;
                        }
                    }
                    break;
                case "tEdit_SalesEmployeeCode_Ed":   // �I���S���҃R�[�h
                    {
                        try
                        {
                            int code = Convert.ToInt32(tEdit_SalesEmployeeCode_Ed.Value);
                        }
                        catch
                        {
                            tEdit_SalesEmployeeCode_Ed.Clear();
                            e.NextCtrl = e.NextCtrl;
                        }
                    }
                    break;
                case "tEdit_SalesInputCode_St": // �J�n���s�҃R�[�h
                    {
                        try
                        {
                            int code = Convert.ToInt32(tEdit_SalesInputCode_St.Value);
                        }
                        catch
                        {
                            tEdit_SalesInputCode_St.Clear();
                            e.NextCtrl = e.NextCtrl;
                        }
                    }
                    break;
                case "tEdit_SalesInputCode_Ed": // �I�����s�҃R�[�h
                    {
                        try
                        {
                            int code = Convert.ToInt32(tEdit_SalesInputCode_Ed.Value);
                        }
                        catch
                        {
                            tEdit_SalesInputCode_Ed.Clear();
                            e.NextCtrl = e.NextCtrl;
                        }
                    }
                    break;
                case "tNedit_CustomerCode_St":  // �J�n���Ӑ�R�[�h
                    {
                        try
                        {
                            int code = Convert.ToInt32(tNedit_CustomerCode_St.Value);
                        }
                        catch
                        {
                            tNedit_CustomerCode_St.Clear();
                            e.NextCtrl = e.NextCtrl;
                        }
                    }
                    break;
                case "tNedit_CustomerCode_Ed":  // �I�����Ӑ�R�[�h
                    {
                        try
                        {
                            int code = Convert.ToInt32(tNedit_CustomerCode_Ed.Value);
                        }
                        catch
                        {
                            tNedit_CustomerCode_Ed.Clear();
                            e.NextCtrl = e.NextCtrl;
                        }
                    }
                    break;
                case "tNedit_SalesCode_St":     // �J�n�̔��敪
                    {
                        try
                        {
                            int code = Convert.ToInt32(tNedit_SalesCode_St.Value);
                        }
                        catch
                        {
                            tNedit_SalesCode_St.Clear();
                            e.NextCtrl = e.NextCtrl;
                        }
                    }
                    break;
                case "tNedit_SalesCode_Ed":     // �I���̔��敪
                    {
                        try
                        {
                            int code = Convert.ToInt32(tNedit_SalesCode_Ed.Value);
                        }
                        catch
                        {
                            tNedit_SalesCode_Ed.Clear();
                            e.NextCtrl = e.NextCtrl;
                        }
                    }
                    break;
                case "tNedit_GroupCode_St":     // �J�n�O���[�v�R�[�h
                    {
                        try
                        {
                            int code = Convert.ToInt32(tNedit_GroupCode_St.Value);
                        }
                        catch
                        {
                            tNedit_GroupCode_St.Clear();
                            e.NextCtrl = e.NextCtrl;
                        }
                    }
                    break;
                case "tNedit_GroupCode_Ed":     // �I���O���[�v�R�[�h
                    {
                        try
                        {
                            int code = Convert.ToInt32(tNedit_GroupCode_Ed.Value);
                        }
                        catch
                        {
                            tNedit_GroupCode_Ed.Clear();
                            e.NextCtrl = e.NextCtrl;
                        }
                    }
                    break;
                case "tNedit_BLCode_St":        // �J�n�a�k�R�[�h
                    {
                        try
                        {
                            int code = Convert.ToInt32(tNedit_BLCode_St.Value);
                        }
                        catch
                        {
                            tNedit_BLCode_St.Clear();
                            e.NextCtrl = e.NextCtrl;
                        }
                    }
                    break;
                case "tNedit_BLCode_Ed":        // �I���a�k�R�[�h
                    {
                        try
                        {
                            int code = Convert.ToInt32(tNedit_BLCode_Ed.Value);
                        }
                        catch
                        {
                            tNedit_BLCode_Ed.Clear();
                            e.NextCtrl = e.NextCtrl;
                        }
                    }
                    break;
                case "tNedit_SalesAreaCode_St": // �J�n�n��R�[�h
                    {
                        try
                        {
                            int code = Convert.ToInt32(tNedit_SalesAreaCode_St.Value);
                        }
                        catch
                        {
                            tNedit_SalesAreaCode_St.Clear();
                            e.NextCtrl = e.NextCtrl;
                        }
                    }
                    break;
                case "tNedit_SalesAreaCode_Ed": // �I���n��R�[�h
                    {
                        try
                        {
                            int code = Convert.ToInt32(tNedit_SalesAreaCode_Ed.Value);
                        }
                        catch
                        {
                            tNedit_SalesAreaCode_Ed.Clear();
                            e.NextCtrl = e.NextCtrl;
                        }
                    }
                    break;
                case "tEdit_AcceptOdrCode_St":   // �J�n�󒍎҃R�[�h
                    {
                        try
                        {
                            int code = Convert.ToInt32(tEdit_AcceptOdrCode_St.Value);
                        }
                        catch
                        {
                            tEdit_AcceptOdrCode_St.Clear();
                            e.NextCtrl = e.NextCtrl;
                        }
                    }
                    break;
                case "tEdit_AcceptOdrCode_Ed":   // �I���󒍎҃R�[�h
                    {
                        try
                        {
                            int code = Convert.ToInt32(tEdit_AcceptOdrCode_Ed.Value);
                        }
                        catch
                        {
                            tEdit_AcceptOdrCode_Ed.Clear();
                            e.NextCtrl = e.NextCtrl;
                        }
                    }
                    break;
            }

            switch (e.NextCtrl.Name)
            {
                case "tNedit_CampaignCode":     // �L�����y�[���R�[�h
                case "tEdit_SalesEmployeeCode_St":   // �J�n�S���҃R�[�h
                case "tEdit_SalesEmployeeCode_Ed":   // �I���S���҃R�[�h
                case "tEdit_SalesInputCode_St": // �J�n���s�҃R�[�h
                case "tEdit_SalesInputCode_Ed": // �I�����s�҃R�[�h
                case "tNedit_CustomerCode_St":  // �J�n���Ӑ�R�[�h
                case "tNedit_CustomerCode_Ed":  // �I�����Ӑ�R�[�h
                case "tNedit_SalesCode_St":     // �J�n�̔��敪
                case "tNedit_SalesCode_Ed":     // �I���̔��敪
                case "tNedit_GroupCode_St":     // �J�n�O���[�v�R�[�h
                case "tNedit_GroupCode_Ed":     // �I���O���[�v�R�[�h
                case "tNedit_BLCode_St":        // �J�n�a�k�R�[�h
                case "tNedit_BLCode_Ed":        // �I���a�k�R�[�h
                case "tNedit_SalesAreaCode_St": // �J�n�n��R�[�h
                case "tNedit_SalesAreaCode_Ed": // �I���n��R�[�h
                case "tEdit_AcceptOdrCode_St":   // �J�n�󒍎҃R�[�h
                case "tEdit_AcceptOdrCode_Ed":   // �I���󒍎҃R�[�h
                    {
                        ParentToolbarGuideSettingEvent(true);
                        break;
                    }
                default:
                    {
                        if (e.NextCtrl.CanSelect || e.NextCtrl is TEdit || e.NextCtrl is TNedit || e.NextCtrl is TComboEditor
                            || e.NextCtrl is TDateEdit || e.NextCtrl is UltraButton)
                        {
                            ParentToolbarGuideSettingEvent(false);
                        }
                        break;
                    }
            }

            // ----- ADD 2011/07/11 ----- >>>>>
            if (this.ulCheckEdt_Area.Visible)
            {
                if (!e.ShiftKey)
                {
                    if (e.PrevCtrl.Name == "ulCheckEdt_Area")
                    {
                        e.NextCtrl = this.tComboEditor_OutputSort;
                    }
                }
                else
                {
                    if (e.PrevCtrl.Name == "tComboEditor_OutputSort")
                    {
                        e.NextCtrl = this.ulCheckEdt_Area;
                    }
                }
            }
            // ----- ADD 2011/07/11 ----- <<<<<

            // ----- UPD 2011/07/11 ----- >>>>>
            //if (e.PrevCtrl != null 
            //    && ("tNedit_CustomerCode_Ed".Equals(e.PrevCtrl.Name) 
            //    || "tNedit_BLCode_Ed".Equals(e.PrevCtrl.Name)))
            if (e.PrevCtrl != null
                && ("tNedit_CustomerCode_Ed".Equals(e.PrevCtrl.Name)))
            // ----- UPD 2011/07/11 ----- <<<<<
            {
                if (!e.ShiftKey)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab) || (e.Key == Keys.Right))
                    {
                        ParentPrintCall();
                        if (this._errComponent != null)
                        {                            
                            e.NextCtrl = this._errComponent;
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                        e.NextCtrl.Text = this.uiSetControl1.GetZeroPadCanceledText(e.NextCtrl.Name, e.NextCtrl.Text);
                    }
                }
            }
        }

        /// <summary>
        /// tNedit_CampaignCode_Enter�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: �Ȃ�</br>
        /// <br>Programmer  : �c����</br>
        /// <br>Date        : 2011/05/19</br>
        /// </remarks>
        private void tNedit_CampaignCode_Enter(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = true;
            if (!string.IsNullOrEmpty(this.tNedit_CampaignCode.Text))
            {
                this.tNedit_CampaignCode.Text = (Convert.ToInt32(this.tNedit_CampaignCode.Text)).ToString();
            }
        }

        /// <summary>
        /// ulCheckEdt_Section_CheckedChanged�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: �Ȃ�</br>
        /// <br>Programmer  : �c����</br>
        /// <br>Date        : 2011/05/19</br>
        /// </remarks>
        private void ulCheckEdt_Section_CheckedChanged(object sender, EventArgs e)
        {
            if (this.tComboEditor_OutputSort.Value == null)
            {
                return;
            }

            if ((int)this.tComboEditor_OutputSort.Value == 2)            
            {
                if (this.ulCheckEdt_Section.Checked == true)
                {
                    this.ulCheckEdt_Emp.Checked = true;
                    this.ulCheckEdt_Emp.Enabled = false;
                    this.ulCheckEdt_Area.Checked = true;
                    this.ulCheckEdt_Area.Enabled = false;
                }
                else
                {
                    this.ulCheckEdt_Emp.Enabled = true;
                    this.ulCheckEdt_Area.Enabled = true;
                }
            }
        }

        /// <summary>
        /// ulCheckEdt_Emp_CheckedChanged�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: �Ȃ�</br>
        /// <br>Programmer  : �c����</br>
        /// <br>Date        : 2011/05/19</br>
        /// </remarks>
        private void ulCheckEdt_Emp_CheckedChanged(object sender, EventArgs e)
        {
            if (this.tComboEditor_OutputSort.Value == null)
            {
                return;
            }

            if ((int)this.tComboEditor_OutputSort.Value != 2)
            {
                if (this.ulCheckEdt_Emp.Checked == true)
                {
                    this.ulCheckEdt_Section.Checked = true;
                    this.ulCheckEdt_Section.Enabled = false;
                }
                else
                {
                    this.ulCheckEdt_Section.Enabled = true;
                }
            }
        }

        /// <summary>
        /// tComboEditor_OutputSort_ValueChanged�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: �Ȃ�</br>
        /// <br>Programmer  : �c����</br>
        /// <br>Date        : 2011/05/19</br>
        /// </remarks>
        private void tComboEditor_OutputSort_ValueChanged(object sender, EventArgs e)
        {
            // �o�͏� = ���Ӑ�|���_ �̏ꍇ
            if ((int)tComboEditor_OutputSort.Value == 2)
            {
                // ���_�ŉ��Ń`�F�b�NON�̏ꍇ
                if (this.ulCheckEdt_Section.Checked == true)
                {
                    this.ulCheckEdt_Section.Enabled = true;
                    this.ulCheckEdt_Emp.Checked = true;
                    this.ulCheckEdt_Emp.Enabled = false;
                    // �n�斈�ŉ��łɂ���
                    this.ulCheckEdt_Area.Checked = true;
                    this.ulCheckEdt_Area.Enabled = false;
                }
                else
                {
                    this.ulCheckEdt_Emp.Enabled = true;
                    // �n�斈�ŉ��łɂ���
                    this.ulCheckEdt_Area.Enabled = true;
                }
            }
            // �o�͏� = ���Ӑ�|���_ �ȊO�̏ꍇ
            else
            {
                // �S���҂ŉ��Ń`�F�b�NON�̏ꍇ
                if (this.ulCheckEdt_Emp.Checked == true)
                {
                    this.ulCheckEdt_Emp.Enabled = true;
                    this.ulCheckEdt_Section.Checked = true;
                    this.ulCheckEdt_Section.Enabled = false;
                }
                // �S���҂ŉ��Ń`�F�b�NOFF�̏ꍇ
                else
                {
                    this.ulCheckEdt_Section.Enabled = true;
                }

                // �n�斈�ŉ��łɂ���
                if (this.ulCheckEdt_Area.Visible == true)
                {
                    // �n�斈�ŉ��Ń`�F�b�NON�̏ꍇ
                    if (this.ulCheckEdt_Area.Checked == true)
                    {
                        this.ulCheckEdt_Area.Enabled = true;
                        this.ulCheckEdt_Section.Checked = true;
                        this.ulCheckEdt_Section.Enabled = false;
                    }
                    // �n�斈�ŉ��Ń`�F�b�NOFF�̏ꍇ
                    else
                    {
                        this.ulCheckEdt_Section.Enabled = true;
                    }
                }
            }
        }

        /// <summary>
        /// ulCheckEdt_Area_CheckedChanged�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: �Ȃ�</br>
        /// <br>Programmer  : �����Y</br>
        /// <br>Date        : 2011/05/19</br>
        /// </remarks>
        private void ulCheckEdt_Area_CheckedChanged(object sender, EventArgs e)
        {
            if (this.tComboEditor_OutputSort.Value == null)
            {
                return;
            }

            if ((int)this.tComboEditor_OutputSort.Value != 2)
            {
                if (this.ulCheckEdt_Area.Checked == true)
                {
                    this.ulCheckEdt_Section.Checked = true;
                    this.ulCheckEdt_Section.Enabled = false;
                }
                else
                {
                    this.ulCheckEdt_Section.Enabled = true;
                }
            }
        }
        #endregion �� Control Event
    }
}