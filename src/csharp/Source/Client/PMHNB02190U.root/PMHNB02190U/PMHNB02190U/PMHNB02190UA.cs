using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win.UltraWinTree;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���Ӑ挳��UI�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ挳��UI�t�H�[���N���X</br>
    /// <br>Programmer : 20081 �D�c �E�l</br>
    /// <br>Date       : 2007.11.12</br>
    /// <br>Programmer : 30009 �a�J ���</br>
    /// <br>Date       : 2009.01.21</br>
    /// <br>Note       : PM.NS�p�ɏC��</br>
    /// <br>Update Note: 2014/02/26 �c����</br>
    /// <br>           : Redmine#42188 �o�͋��z�敪�ǉ�</br>
    /// </remarks>
	public partial class PMHNB02190UA : Form,
                                IPrintConditionInpType,					// ���[���ʁi�������̓^�C�v�j
                                IPrintConditionInpTypeSelectedSection,	// ���[�Ɩ��i�������́j���_�I��
                                IPrintConditionInpTypePdfCareer			// ���[�Ɩ��i�������́jPDF�o�͗����Ǘ�
	{
		#region �� Constructor
		/// <summary>
        /// ���Ӑ挳��UI�t�H�[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���Ӑ挳��UI�t�H�[���N���X�̏���������уC���X�^���X�̐������s��</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.11.12</br>
        /// <br>Update Note: 2014/02/26 �c����</br>
        /// <br>           : Redmine#42188 �o�͋��z�敪�ǉ�</br>
		/// <br></br>
		/// </remarks>
		public PMHNB02190UA ()
		{
			InitializeComponent();

			// ��ƃR�[�h�擾
			this._enterpriseCode		= LoginInfoAcquisition.EnterpriseCode;

			// ���_�p��Hashtable�쐬
			this._selectedSectionList	= new Hashtable();

            // ���Ӑ挳���A�N�Z�X�N���X
            this._csLedgerDmdAcs        = new CsLedgerDmdAcs();

            // ���t�擾���i
            _dateGet = DateGetAcs.GetInstance();

            //----- ADD 2014/02/26 �c���� Redmine#42188 ---------->>>>>
            List<Control> ctrlList = new List<Control>();
            ctrlList.Add(this.PrintMoneyDiv_tComboEditor);

            uiMemInput1.TargetControls = ctrlList;
            //----- ADD 2014/02/26 �c���� Redmine#42188 ----------<<<<<
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

		// ���_�R�[�h
		private string _enterpriseCode = "";
        // ���Ӑ挳���A�N�Z�X�N���X
        private CsLedgerDmdAcs _csLedgerDmdAcs;

        // ��ʃC���[�W�R���g���[�����i
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		// ���Ӑ�K�C�h�p
		private string _customerTag = "";

        // ���t�擾���i
        private DateGetAcs _dateGet;

		#endregion �� Private Member

		#region �� Private Const
		#region �� Interface member
        //--IPrintConditionInpTypePdfCareer�̃v���p�e�B�p�ϐ� -------------------------
		// �N���XID
		private const string ct_ClassID			= "PMHNB02190UA";
		// �v���O����ID
		private const string ct_PGID			= "PMHNB02190U";
		// ���[����
        private const string ct_PrintName		= "���Ӑ挳��";
        // ���[�L�[	
        private const string ct_PrintKey        = "32dd64d0-337b-40fe-810f-cc6f416e21f9";
		#endregion �� Interface member

		// ExporerBar �O���[�v����
		private const string ct_ExBarGroupNm_ReportSelectGroup		= "ReportSelectGroup";		// �o�͏���
		private const string ct_ExBarGroupNm_PrintConditionGroup	= "PrintConditionGroup";	// ���o����
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
        /// <br>Programmer	: 20081 �D�c �E�l</br>
        /// <br>Date		: 2007.11.12</br>
        /// </remarks>
		public int Print ( ref object parameter )
		{
			SFCMN06001U printDialog	= new SFCMN06001U();		// ���[�I���K�C�h
			SFCMN06002C printInfo	= parameter as SFCMN06002C;	// ������p�����[�^

			// ��ƃR�[�h���Z�b�g
			printInfo.enterpriseCode	= this._enterpriseCode;
			printInfo.kidopgid			= ct_PGID;				// �N��PGID

			// PDF�o�͗���p
			printInfo.key				= ct_PrintKey;
			printInfo.prpnm				= ct_PrintName;
			printInfo.PrintPaperSetCd	= 0;
			// ���o�����N���X
            LedgerCmnCndtn extrInfo = new LedgerCmnCndtn();

			// ��ʁ����o�����N���X
			int status = this.SetExtraInfoFromScreen( extrInfo );
			if( status != 0 )
			{
				return -1;
			}

            // ���o�����̐ݒ�
			printInfo.jyoken			= extrInfo;
			printDialog.PrintInfo		= printInfo;
			
			// ���[�I���K�C�h
			DialogResult dialogResult = printDialog.ShowDialog();

			if( printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN ) {
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
        /// <br>Programmer	: 20081 �D�c �E�l</br>
        /// <br>Date		: 2007.11.12</br>
        /// </remarks>
		public bool PrintBeforeCheck ()
		{
			bool status = true;

			string errMessage = "";
			Control errComponent = null;

			if( !this.ScreenInputCheck( ref errMessage, ref errComponent ) )
			{
				// ���b�Z�[�W��\��
				this.MsgDispProc( emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0 );

				// �R���g���[���Ƀt�H�[�J�X���Z�b�g
				if( errComponent != null ) {
					errComponent.Focus();
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
        /// <br>Programmer	: 20081 �D�c �E�l</br>
        /// <br>Date		: 2007.11.12</br>
        /// </remarks>
		public void Show ( object parameter )
		{
			// Todo:�N���p�����[�^��ύX����ꍇ�͂����ōs���B
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
        /// <br>Programmer	: 20081 �D�c �E�l</br>
        /// <br>Date		: 2007.11.12</br>
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
                    this._selectedSectionList.Add( sectionCode, sectionCode );
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
        /// <br>Programmer	: 20081 �D�c �E�l</br>
        /// <br>Date		: 2007.11.12</br>
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
        /// <br>Programmer	: 20081 �D�c �E�l</br>
        /// <br>Date		: 2007.11.12</br>
        /// </remarks>
		public void InitSelectSection ( string[] sectionCodeLst )
		{
            // �I�����X�g������
            this._selectedSectionList.Clear();
            foreach ( string wk in sectionCodeLst )
            {
                this._selectedSectionList.Add( wk, wk );
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
        /// <br>Programmer	: 20081 �D�c �E�l</br>
        /// <br>Date		: 2007.11.12</br>
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
        /// <br>Programmer	: 20081 �D�c �E�l</br>
        /// <br>Date		: 2007.11.12</br>
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
            get { return ct_PrintKey; }
		}

        /// <summary> ���[���v���p�e�B </summary>
		public string PrintName
		{
            get { return ct_PrintName; }
		}

		#endregion �� Public Method
		#endregion �� IPrintConditionInpTypePdfCareer �����o

		#region �� Private Method
		#region �� ��ʏ������֌W
		#region �� ��ʏ���������
		/// <summary>
		/// ��ʏ���������
		/// </summary>
        /// <remarks>
        /// <br>Note		: ���͍��ڂ̏��������s��</br>
        /// <br>Programmer	: 20081 �D�c �E�l</br>
        /// <br>Date		: 2007.11.12</br>
        /// <br>Update Note : 2014/02/26 �c����</br>
        /// <br>            : Redmine#42188 �o�͋��z�敪�ǉ�</br>
        /// </remarks>
		private int InitializeScreen( out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;

			try
			{
                DateTime yearMonth;
                this._dateGet.GetThisYearMonth(out yearMonth);
                this.St_AddUpYearMonth_tDateEdit.DateFormat = emDateFormat.df4Y2M;
                this.St_AddUpYearMonth_tDateEdit.SetDateTime(yearMonth);
                this.Ed_AddUpYearMonth_tDateEdit.DateFormat = emDateFormat.df4Y2M;
                this.Ed_AddUpYearMonth_tDateEdit.SetDateTime(yearMonth);
                // (�N����yyyyMMdd���N��yyyyMM���N����yyyyMM01�ɕϊ�)
                this.St_AddUpYearMonth_tDateEdit.LongDate = this.St_AddUpYearMonth_tDateEdit.LongDate / 100 * 100 + 1;
                this.Ed_AddUpYearMonth_tDateEdit.LongDate = this.Ed_AddUpYearMonth_tDateEdit.LongDate / 100 * 100 + 1;

                // ���Ӑ�R�[�h
				this.tne_St_CustomerCode.SetInt( 0 );
				this.tne_Ed_CustomerCode.SetInt( 0 );
                // �o�͋敪
                this.tce_OutDiv.SelectedIndex = 0;

                this.PrintMoneyDiv_tComboEditor.SelectedIndex = 0; // ADD 2014/02/26 �c���� Redmine#42188
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
			((Infragistics.Win.Misc.UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
			((Infragistics.Win.Misc.UltraButton)settingControl).Appearance.Image = iconIndex;
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
        /// <br>Programmer	: 20081 �D�c �E�l</br>
        /// <br>Date		: 2007.11.12</br>
        /// </remarks>
		private bool ScreenInputCheck( ref string errMessage, ref Control errComponent )
		{
			bool status = true;

            DateGetAcs.CheckDateRangeResult cdrResult;

			const string ct_InputError = "�̓��͂��s���ł�";
			const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂�";
            const string ct_RangeError1 = "�͈͎̔w��Ɍ�肪����܂�(�P�Q�����ȓ��Őݒ肵�ĉ�����)";

            // �������i�J�n�`�I���j
            if (CallCheckDateRange(out cdrResult, ref St_AddUpYearMonth_tDateEdit, ref Ed_AddUpYearMonth_tDateEdit) == false)
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            errMessage = string.Format("������(�J�n){0}", ct_InputError);
                            errComponent = St_AddUpYearMonth_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("������(�J�n){0}", ct_InputError);
                            errComponent = St_AddUpYearMonth_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            errMessage = string.Format("������(�I��){0}", ct_InputError);
                            errComponent = Ed_AddUpYearMonth_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("������(�I��){0}", ct_InputError);
                            errComponent = Ed_AddUpYearMonth_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("������{0}", ct_RangeError);
                            errComponent = this.St_AddUpYearMonth_tDateEdit;
                        }
                        break;
                    case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                        {
                            errMessage = string.Format("������{0}", ct_RangeError1);
                            errComponent = this.St_AddUpYearMonth_tDateEdit;
                        }
                        break;
                }
                status = false;
            }
			// ���Ӑ�R�[�h
            else if ((this.tne_St_CustomerCode.GetInt() > this.tne_Ed_CustomerCode.GetInt()) && (this.tne_Ed_CustomerCode.GetInt() != 0))
			{
				errMessage		= string.Format( "���Ӑ�R�[�h{0}", ct_RangeError );
				errComponent	= this.tne_St_CustomerCode;
				status			= false;
			}

			return status;
		}
		#endregion

		#region �� �N�����̓`�F�b�N����
        /// <summary>
        /// ���t�`�F�b�N�����Ăяo��
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_AddUpYearMonth"></param>
        /// <param name="tde_Ed_AddUpYearMonth"></param>
        /// <returns></returns>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_AddUpYearMonth, ref TDateEdit tde_Ed_AddUpYearMonth)
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 12, ref tde_St_AddUpYearMonth, ref tde_Ed_AddUpYearMonth, false, false);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }
        #endregion

		#region �� ���o�����ݒ菈��(��ʁ����o����)
		/// <summary>
        /// ���o�����ݒ菈��(��ʁ����o����)
        /// </summary>
		/// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: ��ʁ����o�����֐ݒ肷��B</br>
        /// <br>Programmer	: 20081 �D�c �E�l</br>
        /// <br>Date		: 2007.11.12</br>
        /// <br>Update Note : 2014/02/26 �c����</br>
        /// <br>            : Redmine#42188 �o�͋��z�敪�ǉ�</br>
        /// </remarks>
        private int SetExtraInfoFromScreen(LedgerCmnCndtn extraInfo)
        {
            string errMsg = string.Empty;
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			try
			{
				// ���_�I�v�V����
				extraInfo.IsOptSection = this._isOptSection;
				// ��ƃR�[�h
				extraInfo.EnterpriseCode = this._enterpriseCode;

				// �I�����_
                string[] SecCodeList = (string[])new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));
                ArrayList secList = new ArrayList();
                
                foreach (string wk in SecCodeList)
                {
                    secList.Add(wk);
                }
                extraInfo.AddupSecCodeList = secList;

                // �Ώ۔N��
                Int32 iSMonth = 0;
                Int32 iEMonth = 0;

                iSMonth = this.St_AddUpYearMonth_tDateEdit.GetLongDate() / 100;
                iEMonth = this.Ed_AddUpYearMonth_tDateEdit.GetLongDate() / 100;

                extraInfo.StartTargetYearMonth = iSMonth;
                extraInfo.EndTargetYearMonth   = iEMonth;
                // ���Ӑ�R�[�h
                extraInfo.StartCustomerCode = this.tne_St_CustomerCode.GetInt();				// �J�n
                extraInfo.EndCustomerCode   = this.tne_Ed_CustomerCode.GetInt();				// �I��
                //extraInfo.OutMoneyDiv = 0; // DEL 2014/02/26 �c���� Redmine#42188
                // �o�͋��z�敪
                extraInfo.OutMoneyDiv = (LedgerCmnCndtn.OutMoneyDivState)this.PrintMoneyDiv_tComboEditor.SelectedIndex; // ADD 2014/02/26 �c���� Redmine#42188
                // �o�͒��[�敪
                extraInfo.ListDivCode = (int)this.tce_OutDiv.SelectedItem.DataValue;
			}
			catch ( Exception ex)
            {
                errMsg = ex.Message;
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
		/// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date	   : 2007.11.12</br>
		/// </remarks>
		private void MsgDispProc( emErrorLevel iLevel, string message,int status )
		{
			TMsgDisp.Show( 
				iLevel, 							// �G���[���x��
				ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
				ct_PrintName,						// �v���O��������
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
		/// <br>Programmer : 20081 �D�c �E�l</br>
        /// <br>Date	   : 2007.11.12</br>
		/// </remarks>
		private void MsgDispProc( string message,int status, string procnm, Exception ex )
		{
			string errMessage = message + "\r\n" + ex.Message;

			TMsgDisp.Show( 
				this, 								// �e�E�B���h�E�t�H�[��
				emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
				ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
				ct_PrintName,						// �v���O��������
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
		#endregion �� Private Method

		#region �� Control Event
		#region �� PMHNB02190UA
        #region �� PMHNB02190UA_Load Event
        /// <summary>
        /// DCKAU02580UA_Load Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer	: 20081 �D�c �E�l</br>
        /// <br>Date		: 2007.11.12</br>
        /// </remarks>
        private void PMHNB02190UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // �������^�C�}�[�N��
            Initialize_Timer.Enabled = true;

            // ��ʃC���[�W����
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);

            // �����f�[�^�Ǎ�
            string message;
            int status = this._csLedgerDmdAcs.InitSettingDataRead(this._enterpriseCode, out message);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, message, status);
                this.Close();
                return;
            }
        }
        #endregion
        #endregion �� PMHNB02190UA

        #region �� ueb_MainExplorerBar
        #region �� GroupCollapsing Event
        /// <summary>
		/// GroupCollapsing Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: UltraExplorerBarGroup���k�������O�ɔ�������B</br>
        /// <br>Programmer	: 20081 �D�c �E�l</br>
        /// <br>Date		: 2007.11.12</br>
        /// </remarks>
		private void ueb_MainExplorerBar_GroupCollapsing ( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
		{
			if( ( e.Group.Key == ct_ExBarGroupNm_ReportSelectGroup ) || 
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
        /// <br>Programmer	: 20081 �D�c �E�l</br>
        /// <br>Date		: 2007.11.12</br>
        /// </remarks>
		private void ueb_MainExplorerBar_GroupExpanding ( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
		{
			if( ( e.Group.Key == ct_ExBarGroupNm_ReportSelectGroup ) || 
				( e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup ) )
			{
				// �O���[�v�̓W�J���L�����Z��
				e.Cancel = true;
			}

		}
		#endregion
		#endregion �� ueb_MainExplorerBar Event
		#endregion

		#region �� Initialize_Timer
		#region �� Tick Event
		/// <summary>
		/// Tick Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Update Note: 2014/02/26 �c����</br>
        /// <br>           : Redmine#42188 �o�͋��z�敪�ǉ�</br>
        /// </remarks>
		private void Initialize_Timer_Tick ( object sender, EventArgs e )
		{
			Initialize_Timer.Enabled = false;
			string errMsg = string.Empty;

			try
			{
				this.Cursor = Cursors.WaitCursor;

				// �R���g���[��������
				int status = this.InitializeScreen(out errMsg);
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					MsgDispProc( emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status );
					return;
				}

				// �K�C�h�{�^���̃A�C�R���ݒ�
				this.SetIconImage( this.ub_St_CustomerCdGuid, Size16_Index.STAR1 );
				this.SetIconImage( this.ub_Ed_CustomerCdGuid, Size16_Index.STAR1 );

				ParentToolbarSettingEvent( this );	// �c�[���o�[�ݒ�C�x���g
			}
			finally
			{
                uiMemInput1.ReadMemInput(); // ADD 2014/02/26 �c���� Redmine#42188
                this.St_AddUpYearMonth_tDateEdit.Focus();

				this.Cursor = Cursors.Default;
			}
		}
		#endregion
		#endregion �� Initialize_Timer

		#region �� ub_St_CustomerCdGuid
		#region �� Click Event
		/// <summary>
		/// Click Event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ub_St_CustomerCdGuid_Click ( object sender, EventArgs e )
		{
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            this._customerTag = ((Infragistics.Win.Misc.UltraButton)sender).Tag.ToString();
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);
        }
		#endregion
		#endregion �� ub_St_CustomerCdGuid

        #region �� Private Event
        #region �� ���Ӑ�(�x����)�I���������C�x���g

        /// <summary>
		/// ���Ӑ�(�x����)�I���������C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        /// <remarks>
        /// <br>Note        :���Ӑ�K�C�h�œ��Ӑ��I���������ɔ������܂�</br>
        /// <br>Programmer  :20081 �D�c �E�l</br>
        /// <br>Date        :2007.11.12</br>
        /// </remarks>
		private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
		{
			if (customerSearchRet == null) return;

            //���Ӑ�(�d����)�R�[�h���Z�b�g     
			if ( this._customerTag.CompareTo("1") == 0 )
			{
				this.tne_St_CustomerCode.SetInt(customerSearchRet.CustomerCode);
			}
			else
			{
				this.tne_Ed_CustomerCode.SetInt(customerSearchRet.CustomerCode);
			}

		}
    
        #endregion

        private void tne_Ed_CustomerCode_ValueChanged(object sender, EventArgs e)
        {

        }

        #endregion

    }
}