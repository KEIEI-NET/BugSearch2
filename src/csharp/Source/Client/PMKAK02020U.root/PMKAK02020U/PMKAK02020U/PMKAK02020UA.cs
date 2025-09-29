//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���|�c���ꗗ�\(����)
// �v���O�����T�v   : ���|�c���ꗗ�\(����)�̈�����s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : FSI�y�~ �їR��
// �� �� ��  2012/09/14  �C�����e : �V�K�쐬 �d�������@�\�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570208-00 �쐬�S�� : 3H ������
// �C �� ��  2020/04/10  �C�����e : �y���ŗ��Ή�
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

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win.UltraWinTree;
// --- ADD START 3H ������ 2020/04/10 ---------->>>>>
using Broadleaf.Application.Resources;
using System.Text.RegularExpressions;
using System.IO;
// --- ADD END 3H ������ 2020/04/10 ----------<<<<<

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���|�c���ꗗ�\(����) UI�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���|�c���ꗗ�\(����) UI�t�H�[���N���X</br>
    /// <br>Programmer : FSI�y�~ �їR��</br>
    /// <br>Date       : 2012/09/14</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : 11570208-00 �y���ŗ��Ή�</br>
    /// <br>Programmer : 3H ������</br>
    /// <br>Date	   : 2020/04/10</br>
    /// </remarks>
	public partial class PMKAK02020UA : Form,
                                IPrintConditionInpType,					// ���[���ʁi�������̓^�C�v�j
                                IPrintConditionInpTypeSelectedSection,	// ���[�Ɩ��i�������́j���_�I��
                                IPrintConditionInpTypePdfCareer			// ���[�Ɩ��i�������́jPDF�o�͗����Ǘ�
	{

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
        private bool _isOptSection              = false;
        // �{�Ћ@�\�L��
        private bool _isMainOfficeFunc          = false;
		// �I�����_���X�g
        private Hashtable _selectedSectionList	= new Hashtable();
		#endregion �� Interface member

		// ���_�R�[�h
		private string _enterpriseCode = "";

        // ��ʃC���[�W�R���g���[�����i
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // �d����K�C�h�p
        private string _supplierTag = "";

        // �d����K�C�h
        private SupplierAcs _supplierAcs;
        
        // ���t�擾���i
        private DateGetAcs _dateGetAcs;

        private Employee _loginEmployee = null;

        // �O�񌎎������N��(�������Ƃ���)
        private DateTime _baseDate;

		#endregion �� Private Member

		#region �� Private Const
		#region �� Interface member
        //--IPrintConditionInpTypePdfCareer�̃v���p�e�B�p�ϐ� -------------------------
		// �N���XID
		private const string ct_ClassID			= "PMKAK02020UA";
		// �v���O����ID
		private const string ct_PGID			= "PMKAK02020U";
		// ���[����
        private const string ct_PrintName		= "���|�c���ꗗ�\(����)";
        // ���[�L�[	
        private const string ct_PrintKey        = "87a23c28-01a8-4ac9-a84b-4620c392b5ce";
		#endregion �� Interface member

   		// ExporerBar �O���[�v����
		private const string ct_ExBarGroupNm_ReportSelectGroup		= "ReportSelectGroup";		// �o�͏���
		private const string ct_ExBarGroupNm_PrintOderGroup			= "PrintOderGroup";			// �\�[�g��
		private const string ct_ExBarGroupNm_PrintConditionGroup	= "PrintConditionGroup";	// ���o����
        private const string ct_ExBarGroupNm_BuyPrintGroup = "BuyPrintGroup";                   // ���|����ݒ�

        // --- ADD START 3H ������ 2020/04/10 ---------->>>>>
        // �ŗ��ݒ�t�@�C��
        private const string ct_PrintXmlFileName = "TaxRate_UserSetting.XML";
        // --- ADD END 3H ������ 2020/04/10 ----------<<<<<
		#endregion

        #region �� Constructor
        /// <summary>
        /// ���|�c���ꗗ�\(����) UI�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���|�c���ꗗ�\(����)UI�t�H�[���N���X�̏���������уC���X�^���X�̐������s��</br>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
        /// <br></br>
        /// </remarks>
        public PMKAK02020UA ()
        {
            InitializeComponent();

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ���_�p��Hashtable�쐬
            this._selectedSectionList = new Hashtable();

            // �d����A�N�Z�X�N���X
            this._supplierAcs = new SupplierAcs();            

            // ���t�擾���i
            _dateGetAcs = DateGetAcs.GetInstance();

            // ���O�C���S����
            this._loginEmployee = LoginInfoAcquisition.Employee.Clone();
        }
        #endregion �� Constructor

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
        /// <br>Note	   : ����������s���B</br>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
        /// <br>Update Note : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer  : 3H ������</br>
        /// <br>Date	    : 2020/04/10</br>
        /// </remarks>
		public int Print ( ref object parameter )
		{
            // --- ADD START 3H ������ 2020/04/10 ---------->>>>>
            // �ŗ�����󎚃��b�Z�[�W�ǉ�
            if (this.tComboEditor_TaxPrintDiv.SelectedIndex == 0)
            {
                DialogResult result = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION, ct_ClassID, "����ŗ��ʂ̓�����󎚂���ƁA�������x���Ȃ�\��������܂��B\n��낵���ł����H", 0, MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                {
                    return -1;
                }
            }
            // --- ADD END 3H ������ 2020/04/10 ----------<<<<<

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
            SumAccPaymentListCndtn extrInfo = new SumAccPaymentListCndtn();

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
        /// <br>Note	   : ����O�m�F�������s���B(���̓`�F�b�N�Ȃ�)</br>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
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
        /// <br>Note	   : ��ʕ\�����s���B</br>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
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
        /// <br>Note	   : ���_�I���������s���B</br>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
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
        /// <br>Note	   : ������</br>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
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
        /// <br>Note	   : ���_���X�g�̏��������s���B</br>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
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
        /// <br>Note	   : ���_�I���X���C�_�[�̕\���L���𔻒肷��B</br>
        /// <br>		   : ���_�I�v�V�����A�{�Ћ@�\�ȊO�̌ʂ̕\���L��������s���B</br>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
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
        /// <br>Note	   : ������</br>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
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
        /// <br>Note	   : ���͍��ڂ̏��������s��</br>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
        /// <br>UpdateNote : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date	   : 2020/04/10</br>
        /// </remarks>
		private int InitializeScreen( out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;

			try
			{
                // ������
                this.tde_AddUpYearMonth.DateFormat = emDateFormat.df4Y2M;
                
                TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance();
                DateTime prevTotalDay;
                DateTime currentTotalDay;
                DateTime currentTotalMonth;

                totalDayCalculator.InitializeHisMonthlyAccPay();
                totalDayCalculator.GetHisTotalDayMonthlyAccPay("", out prevTotalDay, out currentTotalDay, out this._baseDate, out currentTotalMonth);
                
                if (this._baseDate != DateTime.MinValue)
                {
                    // �O�����������ݒ�
                    this.tde_AddUpYearMonth.SetDateTime(this._baseDate);
                }
                else
                {
                    // ��x�����ߏ��������Ă��Ȃ���΋�
                    this.tde_AddUpYearMonth.SetDateTime(DateTime.MinValue);
                }

                // ����
                this.tComboEditor_NewPageType.Value = 0;
                // �d����R�[�h
				this.tNedit_SupplierCd_St.SetInt( 0 );
                this.tNedit_SupplierCd_Ed.SetInt( 0 );
                // �o�͋��z�敪
                this.tce_OutMoneyDiv.SelectedIndex = 0;
                // ��������
                this.SumSuppDtl_tComboEditor.Value = 1;
                // �x������
                this.PaymentDtl_tComboEditor.Value = 1;

                // --- ADD START 3H ������ 2020/04/10 ---------->>>>>
                // �ŕʓ����
                this.tComboEditor_TaxPrintDiv.Value = 1;
                // --- ADD END 3H ������ 2020/04/10 ----------<<<<<
            }
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}

			return status;
		}
		#endregion

        #region �� �o�͏�����������
        /// <summary>
        /// �o�͏�����������
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �o�͏��̏��������s��</br>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
        /// </remarks>
        private void InitializeSortOrderDiv()
        {
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
        /// <br>Note	   : ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
        /// <br>UpdateNote  : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer  : 3H ������</br>
        /// <br>Date	    : 2020/04/10</br>
        /// </remarks>
		private bool ScreenInputCheck( ref string errMessage, ref Control errComponent )
		{
            bool status = true;

            DateGetAcs.CheckDateResult cdResult;

            const string ct_InputError = "�̓��͂��s���ł�";
            const string ct_NoInputError = "����͂��ĉ�����";
            const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂�";

            // �Ώ۔N��
            if ( CallCheckDate( out cdResult, ref tde_AddUpYearMonth ) == false )
            {
                switch ( cdResult )
                {
                    case DateGetAcs.CheckDateResult.ErrorOfNoInput:
                        {
                            errMessage = string.Format( "������{0}", ct_NoInputError );
                            errComponent = tde_AddUpYearMonth;
                        }
                        break;
                    case DateGetAcs.CheckDateResult.ErrorOfInvalid:
                        {
                            errMessage = string.Format( "������{0}", ct_InputError );
                            errComponent = tde_AddUpYearMonth;
                        }
                        break;
                }
                status = false;
            }

            // --- ADD START 3H ������ 2020/04/10 ----->>>>>
            // XML�̐ŗ����
            if (tComboEditor_TaxPrintDiv.SelectedIndex == 0)
            {
                string errMsg = string.Empty;
                TaxRatePrintInfo taxRatePrintInfo = null;
                Deserialize(out taxRatePrintInfo, out errMsg);
                if (errMsg != string.Empty)
                {
                    errMessage = errMsg;
                    errComponent = tComboEditor_TaxPrintDiv;
                    status = false;
                    return status;
                }
            }
            // --- ADD END 3H ������ 2020/04/10 -----<<<<<

            // �d����R�[�h
            if ( this.tNedit_SupplierCd_St.GetInt() > GetEndCode(this.tNedit_SupplierCd_Ed) )
            {
                errMessage = string.Format("�d����R�[�h{0}", ct_RangeError);
                errComponent = this.tNedit_SupplierCd_St;
                status = false;
            }

			return status;
		}
        /// <summary>
        /// ���t�`�F�b�N�����Ăяo��
        /// </summary>
        /// <param name="cdResult"></param>
        /// <param name="targetDateEdit"></param>
        /// <returns></returns>
        private bool CallCheckDate( out DateGetAcs.CheckDateResult cdResult, ref TDateEdit targetDateEdit )
        {
            cdResult = _dateGetAcs.CheckDate( ref targetDateEdit, false );
            return (cdResult == DateGetAcs.CheckDateResult.OK);
        }

        /// <summary>
        /// ���l���ځ@�I���R�[�h�擾����
        /// </summary>
        /// <param name="tNedit"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>���l�R�[�h���ڂ̓��e���擾����</br>
        /// <br>�@�R�[�h�l���[���@���@�l�`�w�l</br>
        /// <br>�@�R�[�h�l���[���@���@���͒l</br>
        /// </remarks>
        private int GetEndCode( TNedit tNedit )
        {
            // ��ʏ�R���|�[�l���g��Column�ŏI���R�[�h���擾
            return GetEndCode( tNedit, Int32.Parse( new string( '9', (tNedit.ExtEdit.Column) ) ) );
        }

        /// <summary>
        /// ���l���ځ@�I���R�[�h�擾����
        /// </summary>
        /// <param name="tNedit"></param>
        /// <param name="endCodeOnDB"></param>
        /// <returns></returns>
        private int GetEndCode( TNedit tNedit, int endCodeOnDB )
        {
            if ( tNedit.GetInt() == 0 )
            {
                return endCodeOnDB;
            }
            else
            {
                return tNedit.GetInt();
            }
        }

		#endregion

		#region �� ���o�����ݒ菈��(��ʁ����o����)
		/// <summary>
        /// ���o�����ݒ菈��(��ʁ����o����)
        /// </summary>
		/// <returns>Status</returns>
        /// <remarks>
        /// <br>Note	   : ��ʁ����o�����֐ݒ肷��B</br>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
        /// <br>UpdateNote : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date	   : 2020/04/10</br>
        /// </remarks>
        private int SetExtraInfoFromScreen(SumAccPaymentListCndtn extraInfo)
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			try
			{
                // �S�Ђ��I�����ꂽ�ꍇ�̓��X�g���N���A
                bool allSections = false;
                foreach ( object obj in this._selectedSectionList.Values )
                {
                    if ( obj is string )
                    {
                        if ( (obj as string) == "0" )
                        {
                            allSections = true;
                            break;
                        }
                    }
                }
                if ( allSections )
                {
                    this._selectedSectionList.Clear();
                    extraInfo.IsSelectAllSection = true;
                }

				// ���_�I�v�V����
				extraInfo.IsOptSection = this._isOptSection;
				// ��ƃR�[�h
				extraInfo.EnterpriseCode = this._enterpriseCode;
				// �I�����_
                extraInfo.SectionCodes = (string[])new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));

                Int32 idate = this.tde_AddUpYearMonth.GetLongDate();
                if ((idate % 100) == 0)
                {
                    // �ҏW������Ɠ��t��"00"�ƂȂ�AGetDateTime()�Œl���擾�ł��Ȃ��Ȃ�Ή�
                    idate++;
                    this.tde_AddUpYearMonth.SetLongDate(idate);
                }
                else
                {
                    int imanyDay = idate % 100;
                    if (imanyDay != 1)
                    {
                        // �J�����_�[���͂ɂ����t��"01"�ȊO�̏ꍇ�A���t��"01"�ɕύX
                        idate -= (imanyDay - 1);
                        this.tde_AddUpYearMonth.SetLongDate(idate);
                    }
                }

                DateTime compDate = this.tde_AddUpYearMonth.GetDateTime();
                
                // �������Ɋ֌W�Ȃ����В�����ݒ肷��
                DateTime startMonthDate;
                DateTime endMonthDate;
                this._dateGetAcs.GetDaysFromMonth(compDate, out startMonthDate, out endMonthDate);
                extraInfo.AddUpYearMonth = compDate;
                extraInfo.AddUpDate = endMonthDate;

                // �d����R�[�h
                extraInfo.St_PayeeCode = this.tNedit_SupplierCd_St.GetInt();
                extraInfo.Ed_PayeeCode = this.tNedit_SupplierCd_Ed.GetInt();
                
                // �o�͋��z�敪
                extraInfo.OutMoneyDiv = (SumAccPaymentListCndtn.OutMoneyDivState)this.tce_OutMoneyDiv.SelectedItem.DataValue;

                // ����
                extraInfo.NewPageType = (int)this.tComboEditor_NewPageType.Value;

                // ��������
                extraInfo.SumSuppDtlDiv = (int)this.SumSuppDtl_tComboEditor.Value;

                // �x������
                extraInfo.PayDtlDiv = (int)this.PaymentDtl_tComboEditor.Value;

                // --- ADD START 3H ������ 2020/04/10 ---------->>>>>
                // �ŕʓ���󎚋敪
                extraInfo.TaxPrintDiv = Convert.ToInt32(tComboEditor_TaxPrintDiv.SelectedIndex);

                // �ŕʓ���󎚂���
                if (extraInfo.TaxPrintDiv == 0)
                {
                    TaxRatePrintInfo taxInfo = null;
                    string errMsg = string.Empty;

                    status = Deserialize(out taxInfo, out errMsg);
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        // �ŗ�1
                        extraInfo.TaxRate1 = Convert.ToDouble(taxInfo.TaxRate1);
                        // �ŗ�2
                        extraInfo.TaxRate2 = Convert.ToDouble(taxInfo.TaxRate2);
                    }
                }
                // --- ADD END 3H ������ 2020/04/10 ----------<<<<<
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
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
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
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
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
		#region �� PMKAK02020UA
        #region �� PMKAK02020UA_Load Event
        /// <summary>
        /// PMKAK02020UA_Load Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note	   : ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
        /// </remarks>
        private void PMKAK02020UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // �������^�C�}�[�N��
            Initialize_Timer.Enabled = true;

            // ��ʃC���[�W����
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);
        }
		#endregion
        #endregion �� PMKAK02020UA

        #region �� ueb_MainExplorerBar
        #region �� GroupCollapsing Event
        /// <summary>
		/// GroupCollapsing Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note	   : UltraExplorerBarGroup���k�������O�ɔ�������B</br>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
        /// </remarks>
		private void ueb_MainExplorerBar_GroupCollapsing ( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
		{
			if( ( e.Group.Key == ct_ExBarGroupNm_ReportSelectGroup ) || 
				( e.Group.Key == ct_ExBarGroupNm_PrintOderGroup ) ||
				( e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup ) ||
                ( e.Group.Key == ct_ExBarGroupNm_BuyPrintGroup))
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
		/// <br>Note	   : UltraExplorerBarGroup���W�J�����O�ɔ�������B</br>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
        /// </remarks>
		private void ueb_MainExplorerBar_GroupExpanding ( object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e )
		{
			if( ( e.Group.Key == ct_ExBarGroupNm_ReportSelectGroup ) || 
				( e.Group.Key == ct_ExBarGroupNm_PrintOderGroup ) ||
				( e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup ) ||
                ( e.Group.Key == ct_ExBarGroupNm_BuyPrintGroup))
			{
                // �O���[�v�̓W�J���L�����Z��
                e.Cancel = true;
			}
		}
		#endregion
		#endregion �� ueb_MainExplorerBar Event
		#endregion

        # region �� �������^�C�}�[�C�x���g ��
        /// <summary>
		/// Tick Event
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
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

                // �o�͏�
                this.InitializeSortOrderDiv();

				// �K�C�h�{�^���̃A�C�R���ݒ�
				this.SetIconImage( this.ub_St_CustomerCdGuid, Size16_Index.STAR1 );
				this.SetIconImage( this.ub_Ed_CustomerCdGuid, Size16_Index.STAR1 );

				ParentToolbarSettingEvent( this );	// �c�[���o�[�ݒ�C�x���g
			}
			finally
			{
                this.tde_AddUpYearMonth.Focus();

				this.Cursor = Cursors.Default;
			}
        }
        # endregion �� �������^�C�}�[�C�x���g ��

        # region �� �K�C�h�{�^���N���b�N�C�x���g ��
        /// <summary>
		/// �d����K�C�h�{�^���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ub_St_CustomerCdGuid_Click ( object sender, EventArgs e )
		{
            int status = -1;

            this._supplierTag = ((Infragistics.Win.Misc.UltraButton)sender).Tag.ToString();
            // �K�C�h�N��
            Supplier supplier = new Supplier();
            status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "0");

            // ���ڂɓW�J
            if (status == 0)
            {
                if (this._supplierTag.CompareTo("1") == 0)
                {
                    this.tNedit_SupplierCd_St.SetInt(supplier.SupplierCd);
                }
                else
                {
                    this.tNedit_SupplierCd_Ed.SetInt(supplier.SupplierCd);
                }

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        # endregion �� �K�C�h�{�^���N���b�N�C�x���g ��

        # region �� �E�o�C�x���g ��
        /// <summary>
        /// �J�n���l���ځ@�E�o�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tne_St_Leave ( object sender, EventArgs e )
        {
        }
        /// <summary>
        /// �I�����l���ځ@�E�o�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tne_Ed_Leave ( object sender, EventArgs e )
        {
        }
        # endregion �� �E�o�C�x���g ��

        /// <summary>
        /// ���L�[�ł̃t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                // SHIFT�L�[������
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tNedit_SupplierCd_St)
                    {
                        // �d����(�J�n)���d����(�I��)
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        // �d����(�I��)���o�͋��z�敪
                        e.NextCtrl = this.tce_OutMoneyDiv;
                    }
                }
            }
            else
            {
                // SHIFT�L�[����
                if ((e.Key == Keys.Enter) || e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.tce_OutMoneyDiv)
                    {
                        // �o�͋��z�敪���d����(�I��)
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        // �d����(�I��)���d����(�J�n)
                        e.NextCtrl = this.tNedit_SupplierCd_St;
                    }
                }
            }
        }

        // --- ADD START 3H ������ 2020/04/10---------->>>>>
        # region [����p�ŗ����XML]
        /// <summary>
        /// ����p�ŗ����
        /// </summary>
        /// <remarks>
        /// </remarks>
        public class TaxRatePrintInfo
        {
            /// <summary>����p�ŗ��ݒ���ŗ��P</summary>
            private string _taxRate1;

            /// <summary>����p�ŗ��ݒ���ŗ��Q</summary>
            private string _taxRate2;

            /// <summary>����p�ŗ��ݒ���ŗ��P</summary>
            public string TaxRate1
            {
                get { return _taxRate1; }
                set { _taxRate1 = value; }
            }

            /// <summary>����p�ŗ��ݒ���ŗ��Q</summary>
            public string TaxRate2
            {
                get { return _taxRate2; }
                set { _taxRate2 = value; }
            }
        }
        # endregion

        # region
        /// <summary>
        /// �f�V���A���C�Y����
        /// </summary>
        /// <returns>�f�V���A���C�Y����</returns>
        /// <remarks>
        /// </remarks>
        public static Int32 Deserialize(out TaxRatePrintInfo taxRatePrintInfo, out String errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_WARNING;

            errMsg = string.Empty;
            taxRatePrintInfo = null;

            // ����p�ŗ����XML�t�@�C�����݂̔��f
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ct_PrintXmlFileName)))
            {
                try
                {
                    taxRatePrintInfo = UserSettingController.DeserializeUserSetting<TaxRatePrintInfo>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ct_PrintXmlFileName));
                    // �ŗ��ݒ���ŗ��P
                    double dTaxRate1 = -1;
                    Boolean bTaxRate1 = double.TryParse(taxRatePrintInfo.TaxRate1, out dTaxRate1);
                    // �ŗ��ݒ���ŗ��Q
                    double dTaxRate2 = -1;
                    Boolean bTaxRate2 = double.TryParse(taxRatePrintInfo.TaxRate2, out dTaxRate2);

                    // �ŗ����ݒ�̏ꍇ�A
                    if ((taxRatePrintInfo.TaxRate1 == string.Empty) || (taxRatePrintInfo.TaxRate2 == string.Empty) ||
                        // �����ŗ��l�̏ꍇ
                        (taxRatePrintInfo.TaxRate1 == taxRatePrintInfo.TaxRate2) ||
                        // �����ȊO�̏ꍇ�A
                        (!bTaxRate1) || (!bTaxRate2) ||
                        // �ŗ��l��0�ȉ��̏ꍇ
                        (dTaxRate1 <= 0) || (dTaxRate2 <= 0) ||
                        // �ŗ��l��10�ȏ�̏ꍇ
                        (dTaxRate1 >= 10) || (dTaxRate2 >= 10))
                    {
                        errMsg = "�ŗ��ݒ��񂪐������ݒ肳��Ă��܂���B";
                        return status;
                    }

                }
                catch (System.InvalidOperationException)
                {
                    errMsg = "�ŗ��ݒ��񂪐������ݒ肳��Ă��܂���B";
                    return status;
                }
            }
            else
            {
                errMsg = "�ŗ��ݒ���t�@�C��(" + ct_PrintXmlFileName + ")�����݂��܂���B";
                return status;
            }

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        # endregion
        // --- ADD END 3H ������ 2020/04/10----------<<<<<
    }
}